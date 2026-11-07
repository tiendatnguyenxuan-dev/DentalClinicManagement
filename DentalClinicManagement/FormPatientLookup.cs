using BLL_DCM;
using DTO_DCM;

namespace GUI_DCM
{
    public partial class FormPatientLookup : Form
    {
        private readonly PatientBLL _patientBLL = new PatientBLL();
        public PatientLookupDTO? SelectedPatient { get; private set; }

        private List<PatientLookupDTO> _allPatients = new List<PatientLookupDTO>();

        public FormPatientLookup()
        {
            InitializeComponent();
            LoadPatientData();
        }

        private void LoadPatientData()
        {
            var appointmentBLL = new AppointmentBLL();
            _allPatients = appointmentBLL.GetPatientLookupList();
            dgvPatients.DataSource = _allPatients;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(kw))
            {
                dgvPatients.DataSource = _allPatients;
            }
            else
            {
                dgvPatients.DataSource = _allPatients.Where(p =>
                    p.PatientID.ToString().Contains(kw) ||
                    p.FullName.ToLower().Contains(kw) ||
                    (!string.IsNullOrEmpty(p.Phone) && p.Phone.Contains(kw))
                ).ToList();
            }
        }

        private void dgvPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectAndClose();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SelectAndClose();
        }

        private void SelectAndClose()
        {
            if (dgvPatients.CurrentRow?.DataBoundItem is PatientLookupDTO patient)
            {
                SelectedPatient = patient;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bệnh nhân.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}