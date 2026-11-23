-- ============================================================
-- FIX DATABASE SCRIPT - Dental Clinic Management
-- Chạy script này trong MySQL Workbench
-- ============================================================

USE DentalClinic;

-- 1. Sửa cột InvoiceID trong bảng PrescriptionDetail cho phép NULL
-- (Bắt buộc chạy để sửa lỗi kê đơn thuốc)
ALTER TABLE PrescriptionDetail 
MODIFY COLUMN InvoiceID INT NULL;

-- 2. Thêm cột IsDeleted cho bảng Medicine nếu chưa có
-- (Nếu chạy dòng dưới mà báo lỗi Duplicate column name 'IsDeleted' nghĩa là đã có sẵn, có thể bỏ qua)
ALTER TABLE Medicine 
ADD COLUMN IsDeleted TINYINT(1) NOT NULL DEFAULT 0;

-- 3. Bảng MedicalRecord lưu hồ sơ bệnh án của từng bệnh nhân
CREATE TABLE IF NOT EXISTS MedicalRecord (
    MedicalRecordID INT AUTO_INCREMENT PRIMARY KEY,
    PatientID INT NOT NULL,
    RecordCode VARCHAR(30) NOT NULL UNIQUE,
    CreatedDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    RecordStatus VARCHAR(20) NOT NULL DEFAULT 'Active',
    IsDeleted BOOLEAN NOT NULL DEFAULT FALSE,
    DeletedAt DATETIME NULL,

    CONSTRAINT UQ_MedicalRecord_Patient
        UNIQUE (PatientID),

    CONSTRAINT FK_MedicalRecord_Patient
        FOREIGN KEY (PatientID)
        REFERENCES Patient(PatientID)
);

SELECT 'Cập nhật CSDL hoàn tất thành công!' AS ThongBao;


