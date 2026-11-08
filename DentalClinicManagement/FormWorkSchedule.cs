using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BLL_DCM;
using DTO_DCM;

namespace DentalClinicManagement
{
    public partial class FormWorkSchedule : Form
    {
        private readonly WorkScheduleBLL _workScheduleBLL = new();

        // Quản lý tuần làm việc đang xem trên lịch
        private DateTime _currentWeekStart;

        // Mảng lưu trữ các control của 7 cột lịch (Thứ Hai -> Chủ Nhật)
        private readonly Panel[] _headerPanels = new Panel[7];
        private readonly Label[] _headerDayLabels = new Label[7];
        private readonly Label[] _headerDateLabels = new Label[7];
        private readonly FlowLayoutPanel[] _dayPanels = new FlowLayoutPanel[7];

        public FormWorkSchedule()
        {
            InitializeComponent();
            InitCalendarGrid();
        }

        private void FormWorkSchedule_Load(object sender, EventArgs e)
        {
            // Thiết lập tuần hiện tại bắt đầu từ Thứ Hai
            _currentWeekStart = GetStartOfWeek(DateTime.Today);

            // Nạp danh sách nhân viên vào cả 2 ComboBox
            LoadEmployeeList();

            // Mặc định ô ca làm việc ở chế độ xem tuần là "Cả ngày" (Index 0)
            if (cboWeeklyShift.Items.Count > 0)
                cboWeeklyShift.SelectedIndex = 0;

            dtpWeeklyDate.Value = DateTime.Today;

            // Nạp dữ liệu
            ResetForm();
            LoadWeeklyCalendar();
            LoadScheduleList();

            // Lắng nghe sự kiện thay đổi kích thước để căn chỉnh lại độ rộng các thẻ lịch
            tlpCalendar.SizeChanged += (s, ev) => AdjustCardWidths();
        }

        #region Khởi tạo giao diện Lịch theo tuần (Weekly Calendar View)

        /// <summary>
        /// Tìm ngày Thứ Hai của tuần chứa ngày truyền vào (chuẩn tuần bắt đầu từ Thứ Hai)
        /// </summary>
        private static DateTime GetStartOfWeek(DateTime dt)
        {
            int diff = (7 + (dt.DayOfWeek - DayOfWeek.Monday)) % 7;
            return dt.Date.AddDays(-1 * diff);
        }

        /// <summary>
        /// Khởi tạo cấu trúc 7 cột cho TableLayoutPanel
        /// </summary>
        private void InitCalendarGrid()
        {
            tlpCalendar.Controls.Clear();
            tlpCalendar.SuspendLayout();

            for (int col = 0; col < 7; col++)
            {
                int dayIndex = col;

                // 1. Header panel cho từng ngày
                Panel pnlHeader = new Panel
                {
                    Dock = DockStyle.Fill,
                    BackColor = Color.FromArgb(245, 247, 250),
                    Margin = new Padding(0)
                };

                Label lblDay = new Label
                {
                    Dock = DockStyle.Top,
                    Height = 22,
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.FromArgb(40, 40, 40)
                };

                Label lblDate = new Label
                {
                    Dock = DockStyle.Bottom,
                    Height = 20,
                    Font = new Font("Segoe UI", 8.5F, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.DimGray
                };

                pnlHeader.Controls.Add(lblDay);
                pnlHeader.Controls.Add(lblDate);

                // Cho phép người dùng click vào header để chọn ngày nhập nhanh
                pnlHeader.Cursor = Cursors.Hand;
                lblDay.Cursor = Cursors.Hand;
                lblDate.Cursor = Cursors.Hand;

                pnlHeader.Click += (s, e) => SelectDayInCalendar(dayIndex);
                lblDay.Click += (s, e) => SelectDayInCalendar(dayIndex);
                lblDate.Click += (s, e) => SelectDayInCalendar(dayIndex);

                _headerPanels[col] = pnlHeader;
                _headerDayLabels[col] = lblDay;
                _headerDateLabels[col] = lblDate;

                tlpCalendar.Controls.Add(pnlHeader, col, 0);

                // 2. FlowLayoutPanel chứa các card lịch làm việc của ngày
                FlowLayoutPanel flpDay = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    BackColor = Color.White,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(3),
                    Margin = new Padding(0)
                };

                flpDay.Cursor = Cursors.Hand;
                flpDay.Click += (s, e) => SelectDayInCalendar(dayIndex);

                _dayPanels[col] = flpDay;
                tlpCalendar.Controls.Add(flpDay, col, 1);
            }

            tlpCalendar.ResumeLayout();
        }

        /// <summary>
        /// Nạp và vẽ lại dữ liệu lịch của tuần đang xem lên lưới
        /// </summary>
        private void LoadWeeklyCalendar()
        {
            DateTime weekEnd = _currentWeekStart.AddDays(6);
            lblWeekRange.Text = $"Tuần: {_currentWeekStart:dd/MM/yyyy} - {weekEnd:dd/MM/yyyy}";

            // Lấy danh sách lịch trong khoảng từ Thứ Hai đến Chủ Nhật
            List<WorkScheduleDTO> weekSchedules;
            try
            {
                weekSchedules = _workScheduleBLL.GetSchedulesByDateRange(_currentWeekStart, weekEnd);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải lịch làm việc theo tuần: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] dayNames = { "Thứ Hai", "Thứ Ba", "Thứ Tư", "Thứ Năm", "Thứ Sáu", "Thứ Bảy", "Chủ Nhật" };

            for (int col = 0; col < 7; col++)
            {
                DateTime dayDate = _currentWeekStart.AddDays(col);
                int dayIndex = col;

                // 1. Cập nhật tiêu đề ngày
                _headerDayLabels[col].Text = dayNames[col];
                _headerDateLabels[col].Text = dayDate.ToString("dd/MM/yyyy");

                // Highlight nếu là ngày hôm nay
                bool isToday = dayDate.Date == DateTime.Today;
                if (isToday)
                {
                    _headerPanels[col].BackColor = Color.FromArgb(227, 242, 253);
                    _headerDayLabels[col].ForeColor = Color.RoyalBlue;
                    _headerDayLabels[col].Text = $"{dayNames[col]} (Hôm nay)";
                    _headerDateLabels[col].ForeColor = Color.RoyalBlue;
                }
                else
                {
                    _headerPanels[col].BackColor = Color.FromArgb(245, 247, 250);
                    _headerDayLabels[col].ForeColor = Color.FromArgb(40, 40, 40);
                    _headerDateLabels[col].ForeColor = Color.DimGray;
                }

                // 2. Đổ các card lịch làm việc vào cột
                FlowLayoutPanel pnl = _dayPanels[col];
                pnl.SuspendLayout();
                pnl.Controls.Clear();

                var dayList = weekSchedules.Where(s => s.WorkDate.Date == dayDate.Date).ToList();

                if (dayList.Count == 0)
                {
                    Label lblEmpty = new Label
                    {
                        Text = "+ Chọn để thêm lịch",
                        Font = new Font("Segoe UI", 8.5F, FontStyle.Italic),
                        ForeColor = Color.DarkGray,
                        AutoSize = false,
                        Height = 40,
                        Width = Math.Max(pnl.ClientSize.Width - 10, 100),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Cursor = Cursors.Hand
                    };
                    lblEmpty.Click += (s, e) => SelectDayInCalendar(dayIndex);
                    pnl.Controls.Add(lblEmpty);
                }
                else
                {
                    foreach (var schedule in dayList)
                    {
                        Panel card = CreateScheduleCard(schedule, pnl.ClientSize.Width - 10, dayIndex);
                        pnl.Controls.Add(card);
                    }
                }

                pnl.ResumeLayout();
            }
        }

        /// <summary>
        /// Tạo một card hiển thị thông tin ca làm việc với màu sắc phân biệt
        /// </summary>
        private Panel CreateScheduleCard(WorkScheduleDTO schedule, int cardWidth, int dayIndex)
        {
            Color bgColor;
            Color borderColor;
            string shiftBadge;

            // Phân biệt màu sắc theo đúng yêu cầu:
            // Sáng: xanh dương nhạt
            // Chiều: xanh lá nhạt
            // Cả ngày: tím nhạt
            string shift = schedule.Shift;
            if (shift.Equals("Morning", StringComparison.OrdinalIgnoreCase))
            {
                bgColor = Color.FromArgb(227, 242, 253);
                borderColor = Color.FromArgb(144, 202, 249);
                shiftBadge = "☀️ Sáng (08:00 - 12:00)";
            }
            else if (shift.Equals("Afternoon", StringComparison.OrdinalIgnoreCase))
            {
                bgColor = Color.FromArgb(232, 245, 233);
                borderColor = Color.FromArgb(165, 214, 167);
                shiftBadge = "🌤️ Chiều (13:00 - 20:30)";
            }
            else // FullDay
            {
                bgColor = Color.FromArgb(243, 229, 245);
                borderColor = Color.FromArgb(206, 147, 216);
                shiftBadge = "⭐ Cả ngày (08:00 - 20:30)";
            }

            Panel card = new Panel
            {
                Width = Math.Max(cardWidth, 100),
                Height = 60,
                BackColor = bgColor,
                Margin = new Padding(2, 3, 2, 3),
                Cursor = Cursors.Hand,
                Tag = schedule
            };

            // Vẽ viền cho card
            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid,
                    borderColor, 1, ButtonBorderStyle.Solid);
            };

            Label lblName = new Label
            {
                Text = string.IsNullOrEmpty(schedule.DoctorName) ? $"Mã NV: {schedule.DoctorID}" : schedule.DoctorName,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 33, 33),
                Dock = DockStyle.Top,
                Height = 24,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(6, 4, 2, 0),
                Cursor = Cursors.Hand
            };

            Label lblShift = new Label
            {
                Text = shiftBadge,
                Font = new Font("Segoe UI", 8F, FontStyle.Regular),
                ForeColor = Color.FromArgb(70, 70, 70),
                Dock = DockStyle.Bottom,
                Height = 26,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(6, 0, 2, 4),
                Cursor = Cursors.Hand
            };

            card.Controls.Add(lblName);
            card.Controls.Add(lblShift);

            // ContextMenu chuột phải để xóa hoặc sửa nhanh
            ContextMenuStrip menu = new ContextMenuStrip();
            var itemDelete = menu.Items.Add("❌ Xóa lịch làm việc này");
            itemDelete.Click += (s, e) => DeleteScheduleFromCard(schedule);

            var itemEdit = menu.Items.Add("✏️ Chuyển sang chỉnh sửa chi tiết");
            itemEdit.Click += (s, e) => EditScheduleFromCard(schedule);

            card.ContextMenuStrip = menu;
            lblName.ContextMenuStrip = menu;
            lblShift.ContextMenuStrip = menu;

            // Click vào card để tự động chọn ngày vào khung thêm nhanh
            void HandleCardClick(object? sender, EventArgs e)
            {
                SelectDayInCalendar(dayIndex);
                if (cboWeeklyEmployee.DataSource != null)
                {
                    cboWeeklyEmployee.SelectedValue = schedule.DoctorID;
                }
            }

            card.Click += HandleCardClick;
            lblName.Click += HandleCardClick;
            lblShift.Click += HandleCardClick;

            return card;
        }

        /// <summary>
        /// Tự động cập nhật độ rộng các card lịch khi form thay đổi kích thước
        /// </summary>
        private void AdjustCardWidths()
        {
            for (int col = 0; col < 7; col++)
            {
                FlowLayoutPanel pnl = _dayPanels[col];
                if (pnl == null) continue;

                int targetWidth = Math.Max(pnl.ClientSize.Width - 10, 80);
                foreach (Control ctrl in pnl.Controls)
                {
                    ctrl.Width = targetWidth;
                }
            }
        }

        /// <summary>
        /// Người dùng nhấn vào một ngày trên lịch tuần
        /// </summary>
        private void SelectDayInCalendar(int dayIndex)
        {
            DateTime selectedDate = _currentWeekStart.AddDays(dayIndex);
            dtpWeeklyDate.Value = selectedDate;
        }

        /// <summary>
        /// Xóa nhanh lịch từ context menu trên card
        /// </summary>
        private void DeleteScheduleFromCard(WorkScheduleDTO schedule)
        {
            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lịch làm việc của nhân viên '{schedule.DoctorName}' ngày {schedule.WorkDate:dd/MM/yyyy} ({schedule.ShiftDisplayName}) không?",
                "Xác nhận xóa lịch",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (isSuccess, message) = _workScheduleBLL.DeleteSchedule(schedule.ScheduleID);
                if (isSuccess)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadWeeklyCalendar();
                    LoadScheduleList();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Chuyển sang Tab 2 để sửa chi tiết lịch
        /// </summary>
        private void EditScheduleFromCard(WorkScheduleDTO schedule)
        {
            tabMain.SelectedIndex = 1;
            txtScheduleID.Text = schedule.ScheduleID.ToString();
            cboEmployees.SelectedValue = schedule.DoctorID;
            dtpWorkDate.Value = schedule.WorkDate;
            SetShiftIndex(schedule.Shift);

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        #endregion

        #region Các sự kiện điều hướng Tuần (Navigation) & Thêm nhanh

        private void btnPrevWeek_Click(object sender, EventArgs e)
        {
            _currentWeekStart = _currentWeekStart.AddDays(-7);
            LoadWeeklyCalendar();
        }

        private void btnNextWeek_Click(object sender, EventArgs e)
        {
            _currentWeekStart = _currentWeekStart.AddDays(7);
            LoadWeeklyCalendar();
        }

        private void btnCurrentWeek_Click(object sender, EventArgs e)
        {
            _currentWeekStart = GetStartOfWeek(DateTime.Today);
            LoadWeeklyCalendar();
        }

        /// <summary>
        /// Thêm lịch làm việc từ khu vực nhập nhanh của Lịch tuần
        /// </summary>
        private void btnWeeklyAdd_Click(object sender, EventArgs e)
        {
            if (cboWeeklyEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboWeeklyEmployee.Focus();
                return;
            }

            DateTime workDate = dtpWeeklyDate.Value.Date;

            // Lấy mã ca:
            // Index 0: Cả ngày (FullDay)
            // Index 1: Sáng (Morning)
            // Index 2: Chiều (Afternoon)
            string shiftCode = cboWeeklyShift.SelectedIndex switch
            {
                1 => "Morning",
                2 => "Afternoon",
                _ => "FullDay"
            };

            WorkScheduleDTO newSchedule = new WorkScheduleDTO
            {
                DoctorID = Convert.ToInt32(cboWeeklyEmployee.SelectedValue),
                WorkDate = workDate,
                Shift = shiftCode
            };

            var (isSuccess, message) = _workScheduleBLL.AddSchedule(newSchedule);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Tải lại lịch tuần hiện tại (không chuyển tuần nếu ngày vừa thêm thuộc tuần khác)
                LoadWeeklyCalendar();
                LoadScheduleList();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Quản lý danh sách chi tiết (Tab 2 - Giữ nguyên toàn bộ CRUD hiện có)

        /// <summary>
        /// Nạp danh sách Nhân viên vào cả 2 ComboBox
        /// </summary>
        private void LoadEmployeeList()
        {
            try
            {
                var employees = _workScheduleBLL.GetDoctorLookupList();

                // ComboBox trên Tab 2 (Danh sách chi tiết)
                cboEmployees.DataSource = employees;
                cboEmployees.DisplayMember = "DisplayText";
                cboEmployees.ValueMember = "EmployeeID";
                cboEmployees.SelectedIndex = -1;

                // ComboBox trên Tab 1 (Lịch theo tuần - tạo bản sao danh sách để không xung đột binding)
                var employeesWeekly = _workScheduleBLL.GetDoctorLookupList();
                cboWeeklyEmployee.DataSource = employeesWeekly;
                cboWeeklyEmployee.DisplayMember = "DisplayText";
                cboWeeklyEmployee.ValueMember = "EmployeeID";
                cboWeeklyEmployee.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể tải danh sách nhân viên: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Tải danh sách lịch làm việc lên DataGridView
        /// </summary>
        private void LoadScheduleList(List<WorkScheduleDTO>? list = null)
        {
            try
            {
                dgvSchedules.AutoGenerateColumns = false;
                dgvSchedules.DataSource = null;
                dgvSchedules.DataSource = list ?? _workScheduleBLL.GetAllSchedules();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách lịch làm việc: {ex.Message}", "Lỗi CSDL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Chuyển vị trí chọn ComboBox ca làm việc thành mã ca lưu vào CSDL (Morning, Afternoon, FullDay)
        /// </summary>
        private string GetShiftCode()
        {
            string text = cboShift.SelectedItem?.ToString() ?? cboShift.Text.Trim();
            if (text.Contains("Morning") || text.Contains("Sáng") || cboShift.SelectedIndex == 1) return "Morning";
            if (text.Contains("Afternoon") || text.Contains("Chiều") || cboShift.SelectedIndex == 2) return "Afternoon";
            if (text.Contains("FullDay") || text.Contains("Fullday") || text.Contains("Cả ngày") || cboShift.SelectedIndex == 0) return "FullDay";
            return "FullDay";
        }

        /// <summary>
        /// Chọn đúng mục trên ComboBox khi người dùng chọn dòng trên bảng
        /// </summary>
        private void SetShiftIndex(string shift)
        {
            cboShift.SelectedIndex = shift switch
            {
                "FullDay" => 0,
                "Fullday" => 0,
                "Morning" => 1,
                "Afternoon" => 2,
                _ => 0
            };
        }

        /// <summary>
        /// Xóa trắng các ô nhập và đưa về chế độ Thêm mới
        /// </summary>
        private void ResetForm()
        {
            txtScheduleID.Text = "(Tự động sinh)";
            cboEmployees.SelectedIndex = -1;
            dtpWorkDate.Value = DateTime.Today;
            cboShift.SelectedIndex = 0; // Mặc định là Cả ngày

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            cboEmployees.Focus();
        }

        /// <summary>
        /// Đổ dữ liệu từ hàng được chọn lên form
        /// </summary>
        private void dgvSchedules_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvSchedules.Rows.Count) return;

            if (dgvSchedules.Rows[e.RowIndex].DataBoundItem is WorkScheduleDTO schedule)
            {
                txtScheduleID.Text = schedule.ScheduleID.ToString();
                cboEmployees.SelectedValue = schedule.DoctorID;
                dtpWorkDate.Value = schedule.WorkDate;
                SetShiftIndex(schedule.Shift);

                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        /// <summary>
        /// Xử lý thêm mới lịch làm việc (Tab 2)
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboEmployees.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmployees.Focus();
                return;
            }

            WorkScheduleDTO newSchedule = new WorkScheduleDTO
            {
                DoctorID = Convert.ToInt32(cboEmployees.SelectedValue),
                WorkDate = dtpWorkDate.Value.Date,
                Shift = GetShiftCode()
            };

            var (isSuccess, message) = _workScheduleBLL.AddSchedule(newSchedule);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScheduleList();
                LoadWeeklyCalendar();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý cập nhật lịch làm việc (Tab 2)
        /// </summary>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtScheduleID.Text, out int scheduleID) || scheduleID <= 0)
            {
                MessageBox.Show("Vui lòng chọn lịch làm việc cần cập nhật từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboEmployees.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmployees.Focus();
                return;
            }

            WorkScheduleDTO updatedSchedule = new WorkScheduleDTO
            {
                ScheduleID = scheduleID,
                DoctorID = Convert.ToInt32(cboEmployees.SelectedValue),
                WorkDate = dtpWorkDate.Value.Date,
                Shift = GetShiftCode()
            };

            var (isSuccess, message) = _workScheduleBLL.UpdateSchedule(updatedSchedule);

            if (isSuccess)
            {
                MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadScheduleList();
                LoadWeeklyCalendar();
                ResetForm();
            }
            else
            {
                MessageBox.Show(message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Xử lý xóa lịch làm việc (Tab 2)
        /// </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtScheduleID.Text, out int scheduleID) || scheduleID <= 0)
            {
                MessageBox.Show("Vui lòng chọn lịch cần xóa từ danh sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string employeeName = cboEmployees.Text;
            string dateStr = dtpWorkDate.Value.ToString("dd/MM/yyyy");
            string shiftStr = cboShift.Text;

            DialogResult confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa lịch làm việc của nhân viên: '{employeeName}' ngày {dateStr} ({shiftStr}) không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                var (isSuccess, message) = _workScheduleBLL.DeleteSchedule(scheduleID);
                if (isSuccess)
                {
                    MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadScheduleList();
                    LoadWeeklyCalendar();
                    ResetForm();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Làm mới ô nhập (Tab 2)
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        /// <summary>
        /// Tìm kiếm lịch làm việc
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            var results = _workScheduleBLL.SearchSchedules(keyword);
            LoadScheduleList(results);
        }

        /// <summary>
        /// Tải lại tất cả danh sách
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadScheduleList();
            ResetForm();
        }

        /// <summary>
        /// Nhấn Enter trong ô tìm kiếm
        /// </summary>
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, e);
            }
        }

        #endregion
    }
}
