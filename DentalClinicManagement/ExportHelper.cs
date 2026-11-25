using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace DentalClinicManagement
{
    public static class ExportHelper
    {
        /// <summary>
        /// Xuất dữ liệu DataGridView ra định dạng Excel / CSV tương thích Excel (.xls / .csv)
        /// </summary>
        public static void ExportToExcel(DataGridView dgv, string defaultFileName = "ExportData.csv")
        {
            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV / Excel (*.csv)|*.csv|All Files (*.*)|*.*";
            sfd.FileName = defaultFileName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sb = new StringBuilder();

                    // Ghi dòng tiêu đề cột
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (dgv.Columns[i].Visible)
                        {
                            sb.Append($"\"{dgv.Columns[i].HeaderText}\",");
                        }
                    }
                    if (sb.Length > 0 && sb[^1] == ',') sb.Remove(sb.Length - 1, 1);
                    sb.AppendLine();

                    // Ghi từng dòng dữ liệu
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dgv.Columns.Count; i++)
                            {
                                if (dgv.Columns[i].Visible)
                                {
                                    string val = row.Cells[i].Value?.ToString()?.Replace("\"", "\"\"") ?? "";
                                    sb.Append($"\"{val}\",");
                                }
                            }
                            if (sb.Length > 0 && sb[^1] == ',') sb.Remove(sb.Length - 1, 1);
                            sb.AppendLine();
                        }
                    }

                    // Lưu với UTF-8 BOM để Excel hiển thị đúng tiếng Việt có dấu
                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Xuất file thành công!\nĐường dẫn: " + sfd.FileName, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// In / Xuất hóa đơn ra máy in ảo (Microsoft Print to PDF) tạo file PDF
        /// </summary>
        public static void PrintInvoiceToPdf(string invoiceId, string patientName, string doctorName, 
                                             string serviceTotal, string medTotal, string discount, string finalTotal)
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = $"HoaDon_{invoiceId}_{DateTime.Now:yyyyMMdd}";

                pd.PrintPage += (sender, e) =>
                {
                    Graphics g = e.Graphics!;
                    Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
                    Font fontHeader = new Font("Arial", 11, FontStyle.Bold);
                    Font fontRegular = new Font("Arial", 10, FontStyle.Regular);
                    Font fontTotal = new Font("Arial", 12, FontStyle.Bold);
                    Brush brush = Brushes.Black;

                    float y = 50;
                    float left = 50;

                    // Tiêu đề phòng khám
                    g.DrawString("PHÒNG KHÁM NHA KHOA ĐẠI HỌC", fontHeader, brush, left, y); y += 25;
                    g.DrawString("HÓA ĐƠN THANH TOÁN VIỆN PHÍ", fontTitle, Brushes.DarkSlateBlue, left + 120, y); y += 45;

                    g.DrawLine(Pens.Black, left, y, left + 700, y); y += 15;

                    // Thông tin chung
                    g.DrawString($"Số hóa đơn: #{invoiceId}", fontRegular, brush, left, y);
                    g.DrawString($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}", fontRegular, brush, left + 350, y); y += 25;
                    g.DrawString($"Bệnh nhân: {patientName}", fontRegular, brush, left, y);
                    g.DrawString($"Bác sĩ điều trị: {doctorName}", fontRegular, brush, left + 350, y); y += 35;

                    g.DrawLine(Pens.Gray, left, y, left + 700, y); y += 20;

                    // Chi tiết thanh toán
                    g.DrawString("NỘI DUNG THANH TOÁN", fontHeader, brush, left, y); y += 30;
                    g.DrawString("1. Tiền dịch vụ điều trị nha khoa:", fontRegular, brush, left + 20, y);
                    g.DrawString(serviceTotal, fontRegular, brush, left + 450, y); y += 25;

                    g.DrawString("2. Tiền thuốc kê đơn:", fontRegular, brush, left + 20, y);
                    g.DrawString(medTotal, fontRegular, brush, left + 450, y); y += 25;

                    g.DrawString("3. Giảm giá / Ưu đãi:", fontRegular, brush, left + 20, y);
                    g.DrawString(discount, fontRegular, brush, left + 450, y); y += 35;

                    g.DrawLine(Pens.Black, left, y, left + 700, y); y += 15;

                    // Tổng tiền
                    g.DrawString("TỔNG TIỀN PHẢI THANH TOÁN:", fontTotal, Brushes.Crimson, left + 20, y);
                    g.DrawString(finalTotal, fontTotal, Brushes.Crimson, left + 450, y); y += 50;

                    g.DrawString("Người lập hóa đơn", fontRegular, brush, left + 100, y);
                    g.DrawString("Khách hàng / Bệnh nhân", fontRegular, brush, left + 450, y); y += 20;
                    g.DrawString("(Ký, ghi rõ họ tên)", fontRegular, Brushes.Gray, left + 100, y);
                    g.DrawString("(Ký, ghi rõ họ tên)", fontRegular, Brushes.Gray, left + 450, y);
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = pd;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn / xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
