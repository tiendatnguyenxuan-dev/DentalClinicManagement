using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class ReportBLL
    {
        private readonly ReportDAL _dal = new();

        public List<RevenueReportDTO> GetRevenueByDate(DateTime fromDate, DateTime toDate)
        {
            return _dal.GetRevenueByDate(fromDate, toDate);
        }

        public List<QuarterRevenueDTO> GetRevenueByDoctorAndQuarter(int year) => _dal.GetRevenueByDoctorAndQuarter(year);
        public List<QuarterRevenueDTO> GetRevenueByPatientAndQuarter(int year) => _dal.GetRevenueByPatientAndQuarter(year);
        public List<QuarterRevenueDTO> GetRevenueByMedicineAndQuarter(int year) => _dal.GetRevenueByMedicineAndQuarter(year);

        public (decimal TotalRevenue, int TotalExams, int TotalPatients, int TotalAppointments) GetDashboardSummary()
        {
            return _dal.GetDashboardSummary();
        }
    }
}
