-- =============================================================
-- CƠ SỞ DỮ LIỆU: QUẢN LÝ PHÒNG KHÁM NHA KHOA (DentalClinicDB)
-- =============================================================

CREATE DATABASE DentalClinicDB;
GO

USE DentalClinicDB;
GO

-- 1. BẢNG TÀI KHOẢN (Accounts)
CREATE TABLE Accounts (
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(255) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20) NOT NULL -- 'Admin', 'Doctor', 'Receptionist'
);
GO

-- 2. BẢNG BÁC SĨ (Dentists)
CREATE TABLE Dentists (
    DentistId NVARCHAR(20) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100),
    Specialization NVARCHAR(100) -- Chuyên khoa (vd: Chỉnh nha, Nhổ răng, Nha chu)
);
GO

-- 3. BẢNG BỆNH NHÂN (Patients)
CREATE TABLE Patients (
    PatientId NVARCHAR(20) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(10), -- 'Nam', 'Nữ'
    DateOfBirth DATE,
    PhoneNumber NVARCHAR(15) NOT NULL,
    Address NVARCHAR(255),
    MedicalHistory NVARCHAR(500), -- Tiền sử bệnh lý (dị ứng, tiểu đường, tim mạch,...)
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO

-- 4. BẢNG DỊCH VỤ NHA KHOA (Services)
CREATE TABLE Services (
    ServiceId NVARCHAR(20) PRIMARY KEY,
    ServiceName NVARCHAR(150) NOT NULL,
    Price DECIMAL(18, 0) NOT NULL,
    Unit NVARCHAR(20) -- Đơn vị tính: Răng, Hàm, Lần, Gói
);
GO

-- 5. BẢNG LỊCH HẸN KHÁM (Appointments)
CREATE TABLE Appointments (
    AppointmentId INT IDENTITY(1,1) PRIMARY KEY,
    PatientId NVARCHAR(20) FOREIGN KEY REFERENCES Patients(PatientId),
    DentistId NVARCHAR(20) FOREIGN KEY REFERENCES Dentists(DentistId),
    AppointmentDate DATETIME NOT NULL,
    Reason NVARCHAR(255),
    Status NVARCHAR(50) DEFAULT N'Chờ khám' -- 'Chờ khám', 'Đang khám', 'Đã hoàn thành', 'Đã hủy'
);
GO

-- 6. BẢNG HÓA ĐƠN (Invoices)
CREATE TABLE Invoices (
    InvoiceId NVARCHAR(20) PRIMARY KEY,
    PatientId NVARCHAR(20) FOREIGN KEY REFERENCES Patients(PatientId),
    DentistId NVARCHAR(20) FOREIGN KEY REFERENCES Dentists(DentistId),
    CreatedDate DATETIME DEFAULT GETDATE(),
    TotalAmount DECIMAL(18, 0) DEFAULT 0,
    Discount DECIMAL(5, 2) DEFAULT 0, -- Phần trăm giảm giá
    FinalAmount DECIMAL(18, 0) DEFAULT 0,
    PaymentStatus NVARCHAR(30) DEFAULT N'Đã thanh toán'
);
GO

-- 7. BẢNG CHI TIẾT HÓA ĐƠN (InvoiceDetails)
CREATE TABLE InvoiceDetails (
    InvoiceDetailId INT IDENTITY(1,1) PRIMARY KEY,
    InvoiceId NVARCHAR(20) FOREIGN KEY REFERENCES Invoices(InvoiceId) ON DELETE CASCADE,
    ServiceId NVARCHAR(20) FOREIGN KEY REFERENCES Services(ServiceId),
    Quantity INT DEFAULT 1,
    UnitPrice DECIMAL(18, 0) NOT NULL,
    SubTotal DECIMAL(18, 0) NOT NULL
);
GO

-- =============================================================
-- DỮ LIỆU MẪU (Sample Data)
-- =============================================================

-- Dữ liệu tài khoản
INSERT INTO Accounts (Username, Password, FullName, Role) VALUES
('admin', '123456', N'Quản Trị Viên', 'Admin'),
('bacsi', '123456', N'BS. Nguyễn Văn An', 'Doctor'),
('letan', '123456', N'Lễ Tân Trần Thị Mai', 'Receptionist');

-- Dữ liệu bác sĩ
INSERT INTO Dentists (DentistId, FullName, PhoneNumber, Email, Specialization) VALUES
('BS01', N'BS. CKI Nguyễn Văn An', '0901234567', 'an.nguyen@dental.com', N'Chỉnh nha - Niềng răng'),
('BS02', N'BS. Trần Minh Tuấn', '0912345678', 'tuan.tran@dental.com', N'Cấy ghép Implant'),
('BS03', N'BS. Lê Thị Bích', '0987654321', 'bich.le@dental.com', N'Nha khoa tổng quát & Thẩm mỹ');

-- Dữ liệu dịch vụ
INSERT INTO Services (ServiceId, ServiceName, Price, Unit) VALUES
('DV01', N'Cạo vôi răng & Đánh bóng', 250000, N'Hàm'),
('DV02', N'Trám răng thẩm mỹ Composite', 350000, N'Răng'),
('DV03', N'Nhổ răng số 8 (Răng khôn)', 1200000, N'Răng'),
('DV04', N'Tẩy trắng răng tại phòng khám', 1800000, N'Gói'),
('DV05', N'Niềng răng mắc cài kim loại', 28000000, N'Gói'),
('DV06', N'Bọc răng sứ Cercon HT', 4500000, N'Răng');

-- Dữ liệu bệnh nhân ban đầu
INSERT INTO Patients (PatientId, FullName, Gender, DateOfBirth, PhoneNumber, Address, MedicalHistory) VALUES
('BN001', N'Hoàng Đức Thịnh', N'Nam', '1995-04-12', '0905111222', N'Quận 1, TP.HCM', N'Không dị ứng thuốc'),
('BN002', N'Võ Thị Ngọc', N'Nữ', '2001-08-25', '0918333444', N'Bình Thạnh, TP.HCM', N'Huyết áp thấp'),
('BN003', N'Lê Minh Khang', N'Nam', '1988-11-03', '0932555666', N'Quận 7, TP.HCM', N'Dị ứng Penicillin');
GO

