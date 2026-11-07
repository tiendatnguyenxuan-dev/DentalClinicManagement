using System;
using System.Collections.Generic;
using System.Linq;
using DTO_DCM;

namespace DAL_DCM
{
    public class PatientDAL
    {
        // Danh sách bệnh nhân mẫu trong bộ nhớ (sẽ được thay bằng SQL Server qua ADO.NET)
        private static readonly List<PatientDTO> _patients = new()
        {
            new PatientDTO("BN001", "Hoàng Đức Thịnh", "Nam", new DateTime(1995, 4, 12), "0905111222", "Quận 1, TP.HCM", "Không dị ứng thuốc"),
            new PatientDTO("BN002", "Võ Thị Ngọc", "Nữ", new DateTime(2001, 8, 25), "0918333444", "Bình Thạnh, TP.HCM", "Huyết áp thấp"),
            new PatientDTO("BN003", "Lê Minh Khang", "Nam", new DateTime(1988, 11, 3), "0932555666", "Quận 7, TP.HCM", "Dị ứng Penicillin")
        };

        public List<PatientDTO> GetAll()
        {
            return _patients.ToList();
        }

        public PatientDTO? GetById(string patientId)
        {
            return _patients.FirstOrDefault(p => p.PatientId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
        }

        public bool Add(PatientDTO patient)
        {
            if (_patients.Any(p => p.PatientId.Equals(patient.PatientId, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // Mã trùng
            }
            _patients.Add(patient);
            return true;
        }

        public bool Update(PatientDTO patient)
        {
            var existing = _patients.FirstOrDefault(p => p.PatientId.Equals(patient.PatientId, StringComparison.OrdinalIgnoreCase));
            if (existing == null) return false;

            existing.FullName = patient.FullName;
            existing.Gender = patient.Gender;
            existing.DateOfBirth = patient.DateOfBirth;
            existing.PhoneNumber = patient.PhoneNumber;
            existing.Address = patient.Address;
            existing.MedicalHistory = patient.MedicalHistory;
            return true;
        }

        public bool Delete(string patientId)
        {
            var existing = _patients.FirstOrDefault(p => p.PatientId.Equals(patientId, StringComparison.OrdinalIgnoreCase));
            if (existing == null) return false;

            _patients.Remove(existing);
            return true;
        }

        public List<PatientDTO> Search(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return GetAll();

            keyword = keyword.Trim().ToLower();
            return _patients.Where(p =>
                p.PatientId.ToLower().Contains(keyword) ||
                p.FullName.ToLower().Contains(keyword) ||
                p.PhoneNumber.Contains(keyword) ||
                p.Address.ToLower().Contains(keyword)
            ).ToList();
        }

        public string GenerateNextId()
        {
            int maxId = 0;
            foreach (var p in _patients)
            {
                if (p.PatientId.StartsWith("BN", StringComparison.OrdinalIgnoreCase))
                {
                    if (int.TryParse(p.PatientId.Substring(2), out int num))
                    {
                        if (num > maxId) maxId = num;
                    }
                }
            }
            return $"BN{(maxId + 1):D3}";
        }
    }
}

