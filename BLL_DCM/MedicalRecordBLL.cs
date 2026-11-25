using System;
using System.Collections.Generic;
using DAL_DCM;
using DTO_DCM;

namespace BLL_DCM
{
    public class MedicalRecordBLL
    {
        private readonly MedicalRecordDAL _dal = new();

        public MedicalRecordDTO? GetByPatientId(int patientId)
        {
            if (patientId <= 0) return null;
            return _dal.GetByPatientId(patientId);
        }

        public MedicalRecordDTO EnsureMedicalRecordExists(int patientId)
        {
            return _dal.EnsureMedicalRecordExists(patientId);
        }

        public List<ExaminationDTO> GetExaminationsByPatientId(int patientId)
        {
            if (patientId <= 0) return new List<ExaminationDTO>();
            return _dal.GetExaminationsByPatientId(patientId);
        }
    }
}
