
-- =========================================
-- 1. DATABASE
-- =========================================

CREATE DATABASE DentalClinic
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE DentalClinic;


-- =========================================
-- 2. SPECIALTY
-- Soft delete
-- =========================================

CREATE TABLE Specialty (
    SpecialtyID INT AUTO_INCREMENT PRIMARY KEY,
    SpecialtyName VARCHAR(100) NOT NULL UNIQUE,

    IsDeleted BOOLEAN NOT NULL DEFAULT FALSE,
    DeletedAt DATETIME NULL
) ENGINE=InnoDB;


-- =========================================
-- 3. PATIENT
-- PatientStatus: Active / Inactive
-- Không xóa hồ sơ bệnh nhân
-- =========================================

CREATE TABLE Patient (
    PatientID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    DateOfBirth DATE,

    Gender ENUM('Male', 'Female', 'Other'),

    Phone VARCHAR(15) UNIQUE,
    Email VARCHAR(100),
    Address VARCHAR(255),

    MedicalHistory TEXT,
    Allergies TEXT,

    RegistrationDate DATE NOT NULL DEFAULT (CURRENT_DATE),

    PatientStatus ENUM(
        'Active',
        'Inactive'
    ) NOT NULL DEFAULT 'Active'
) ENGINE=InnoDB;


-- =========================================
-- 4. EMPLOYEE
-- Không xóa nhân viên
-- =========================================

CREATE TABLE Employee (
    EmployeeID INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,

    Position ENUM(
        'Admin',
        'Doctor',
        'Receptionist',
        'Cashier',
        'Nurse'
    ) NOT NULL,

    Phone VARCHAR(15),
    Email VARCHAR(100),
    HireDate DATE,

    SpecialtyID INT,
    PracticeLicenseNumber VARCHAR(50),

    EmploymentStatus ENUM(
        'Active',
        'Resigned'
    ) NOT NULL DEFAULT 'Active',

    FOREIGN KEY (SpecialtyID)
        REFERENCES Specialty(SpecialtyID)
        ON DELETE RESTRICT,

    CONSTRAINT CHK_EMPLOYEE_SPECIALTY
    CHECK (
        (Position = 'Doctor' AND SpecialtyID IS NOT NULL)
        OR
        (Position <> 'Doctor'
         AND SpecialtyID IS NULL
         AND PracticeLicenseNumber IS NULL)
    )
) ENGINE=InnoDB;


-- =========================================
-- 5. ACCOUNT
-- Không xóa tài khoản
-- =========================================

CREATE TABLE Account (
    AccountID INT AUTO_INCREMENT PRIMARY KEY,
    EmployeeID INT NOT NULL UNIQUE,

    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL,

    AccountStatus ENUM(
        'Active',
        'Locked'
    ) NOT NULL DEFAULT 'Active',

    FOREIGN KEY (EmployeeID)
        REFERENCES Employee(EmployeeID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 6. AUDIT LOG
-- Ghi nhận lịch sử thao tác
-- =========================================

CREATE TABLE AuditLog (
    LogID BIGINT AUTO_INCREMENT PRIMARY KEY,

    AccountID INT NULL,

    ActionType ENUM(
        'INSERT',
        'UPDATE',
        'DELETE',
        'RESTORE',
        'CANCEL',
        'REVERSE'
    ) NOT NULL,

    EntityName VARCHAR(100) NOT NULL,
    EntityID INT NOT NULL,

    Description VARCHAR(500),

    OldData JSON NULL,
    NewData JSON NULL,

    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    FOREIGN KEY (AccountID)
        REFERENCES Account(AccountID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 7. WORK SCHEDULE
-- Soft delete
-- Morning / Afternoon / FullDay
-- Phân lịch cho tất cả nhân viên
-- =========================================

CREATE TABLE WorkSchedule (
    ScheduleID INT AUTO_INCREMENT PRIMARY KEY,

    EmployeeID INT NOT NULL,
    WorkDate DATE NOT NULL,

    Shift ENUM(
        'Morning',
        'Afternoon',
        'FullDay'
    ) NOT NULL,

    IsDeleted BOOLEAN NOT NULL DEFAULT FALSE,
    DeletedAt DATETIME NULL,

    -- Chỉ lấy EmployeeID của lịch chưa bị xóa.
    -- Lịch đã xóa sẽ có giá trị NULL.
    ActiveEmployeeID INT
        GENERATED ALWAYS AS (
            CASE
                WHEN IsDeleted = FALSE THEN EmployeeID
                ELSE NULL
            END
        ) STORED,

    UNIQUE (ActiveEmployeeID, WorkDate, Shift),

    FOREIGN KEY (EmployeeID)
        REFERENCES Employee(EmployeeID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 8. APPOINTMENT
-- Không xóa lịch hẹn
-- =========================================

CREATE TABLE Appointment (
    AppointmentID INT AUTO_INCREMENT PRIMARY KEY,

    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,

    AppointmentDateTime DATETIME NOT NULL,

    AppointmentStatus ENUM(
        'Pending',
        'Confirmed',
        'Completed',
        'Cancelled',
        'NoShow'
    ) NOT NULL DEFAULT 'Pending',

    Notes VARCHAR(255),

    CancelReason VARCHAR(255),
    CancelledAt DATETIME NULL,
    CancelledBy INT NULL,

    FOREIGN KEY (PatientID)
        REFERENCES Patient(PatientID)
        ON DELETE RESTRICT,

    FOREIGN KEY (DoctorID)
        REFERENCES Employee(EmployeeID)
        ON DELETE RESTRICT,

    FOREIGN KEY (CancelledBy)
        REFERENCES Account(AccountID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 9. EXAMINATION
-- Không xóa hồ sơ khám bệnh
-- =========================================

CREATE TABLE Examination (
    ExaminationID INT AUTO_INCREMENT PRIMARY KEY,

    PatientID INT NOT NULL,
    DoctorID INT NOT NULL,

    AppointmentID INT UNIQUE,

    ExaminationDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    ExaminationReason VARCHAR(255),
    Diagnosis TEXT,
    Conclusion TEXT,
    FollowUpDate DATE,

    ExaminationStatus ENUM(
        'Draft',
        'Finalized'
    ) NOT NULL DEFAULT 'Draft',

    FOREIGN KEY (PatientID)
        REFERENCES Patient(PatientID)
        ON DELETE RESTRICT,

    FOREIGN KEY (DoctorID)
        REFERENCES Employee(EmployeeID)
        ON DELETE RESTRICT,

    FOREIGN KEY (AppointmentID)
        REFERENCES Appointment(AppointmentID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 10. SERVICE
-- Soft delete
-- =========================================

CREATE TABLE Service (
    ServiceID INT AUTO_INCREMENT PRIMARY KEY,

    ServiceName VARCHAR(150) NOT NULL,
    ServiceCategory VARCHAR(50),

    UnitPrice DECIMAL(12,0) NOT NULL
        CHECK (UnitPrice >= 0),

    Unit VARCHAR(30),

    IsDeleted BOOLEAN NOT NULL DEFAULT FALSE,
    DeletedAt DATETIME NULL
) ENGINE=InnoDB;


-- =========================================
-- 11. EXAMINATION SERVICE
-- Không xóa tùy tiện sau khi chốt hồ sơ
-- =========================================

CREATE TABLE ExaminationService (
    ExaminationServiceID INT AUTO_INCREMENT PRIMARY KEY,

    ExaminationID INT NOT NULL,
    ServiceID INT NOT NULL,

    ToothNumber VARCHAR(10),

    Quantity INT NOT NULL DEFAULT 1
        CHECK (Quantity > 0),

    UnitPrice DECIMAL(12,0) NOT NULL
        CHECK (UnitPrice >= 0),

    Notes VARCHAR(255),

    IsVoided BOOLEAN NOT NULL DEFAULT FALSE,
    VoidReason VARCHAR(255),
    VoidedAt DATETIME NULL,

    FOREIGN KEY (ExaminationID)
        REFERENCES Examination(ExaminationID)
        ON DELETE RESTRICT,

    FOREIGN KEY (ServiceID)
        REFERENCES Service(ServiceID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 12. MEDICINE
-- Soft delete
-- =========================================

CREATE TABLE Medicine (
    MedicineID INT AUTO_INCREMENT PRIMARY KEY,

    MedicineName VARCHAR(150) NOT NULL,
    Unit VARCHAR(30),

    UnitPrice DECIMAL(12,0) NOT NULL
        CHECK (UnitPrice >= 0),

    StockQuantity INT NOT NULL DEFAULT 0
        CHECK (StockQuantity >= 0),

    IsDeleted BOOLEAN NOT NULL DEFAULT FALSE,
    DeletedAt DATETIME NULL
) ENGINE=InnoDB;


-- =========================================
-- 13. PRESCRIPTION
-- Không xóa đơn thuốc đã phát hành
-- =========================================

CREATE TABLE Prescription (
    PrescriptionID INT AUTO_INCREMENT PRIMARY KEY,

    ExaminationID INT NOT NULL UNIQUE,

    PrescriptionDate DATE NOT NULL DEFAULT (CURRENT_DATE),
    Instructions TEXT,

    PrescriptionStatus ENUM(
        'Draft',
        'Issued',
        'Cancelled'
    ) NOT NULL DEFAULT 'Draft',

    CancelReason VARCHAR(255),
    CancelledAt DATETIME NULL,

    FOREIGN KEY (ExaminationID)
        REFERENCES Examination(ExaminationID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 14. INVOICE
-- Không xóa hóa đơn
-- =========================================

CREATE TABLE Invoice (
    InvoiceID INT AUTO_INCREMENT PRIMARY KEY,

    ExaminationID INT NOT NULL UNIQUE,
    EmployeeID INT NOT NULL,

    InvoiceDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    TotalAmountMedicine DECIMAL(12,0) NOT NULL DEFAULT 0
        CHECK (TotalAmountMedicine >= 0),

    TotalAmountService DECIMAL(12,0) NOT NULL DEFAULT 0
        CHECK (TotalAmountService >= 0),

    DiscountAmount DECIMAL(12,0) NOT NULL DEFAULT 0
        CHECK (DiscountAmount >= 0),

    PaymentStatus ENUM(
        'Unpaid',
        'PartiallyPaid',
        'Paid'
    ) NOT NULL DEFAULT 'Unpaid',

    InvoiceStatus ENUM(
        'Issued',
        'Cancelled'
    ) NOT NULL DEFAULT 'Issued',

    CancelReason VARCHAR(255),
    CancelledAt DATETIME NULL,
    CancelledBy INT NULL,

    CHECK (DiscountAmount <= (TotalAmountMedicine + TotalAmountService)),

    FOREIGN KEY (ExaminationID)
        REFERENCES Examination(ExaminationID)
        ON DELETE RESTRICT,

    FOREIGN KEY (EmployeeID)
        REFERENCES Employee(EmployeeID)
        ON DELETE RESTRICT,

    FOREIGN KEY (CancelledBy)
        REFERENCES Account(AccountID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;

-- =========================================
-- 15. PRESCRIPTION DETAIL
-- Mỗi dòng thuốc thuộc một hóa đơn
-- =========================================

CREATE TABLE PrescriptionDetail (
    PrescriptionID INT NOT NULL,
    MedicineID INT NOT NULL,
    InvoiceID INT NOT NULL,

    Quantity INT NOT NULL
        CHECK (Quantity > 0),

    Dosage VARCHAR(255),

    IsVoided BOOLEAN NOT NULL DEFAULT FALSE,
    VoidReason VARCHAR(255),
    VoidedAt DATETIME NULL,

    PRIMARY KEY (PrescriptionID, MedicineID),

    FOREIGN KEY (PrescriptionID)
        REFERENCES Prescription(PrescriptionID)
        ON DELETE RESTRICT,

    FOREIGN KEY (MedicineID)
        REFERENCES Medicine(MedicineID)
        ON DELETE RESTRICT,

    FOREIGN KEY (InvoiceID)
        REFERENCES Invoice(InvoiceID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;


-- =========================================
-- 16. INVOICE SERVICE DETAIL
-- Chi tiết dịch vụ được tính tiền trên hóa đơn
-- Amount = Quantity * UnitPrice
-- =========================================

CREATE TABLE InvoiceServiceDetail (
    InvoiceServiceDetailID INT AUTO_INCREMENT PRIMARY KEY,

    InvoiceID INT NOT NULL,
    ServiceID INT NOT NULL,

    Quantity INT NOT NULL
        CHECK (Quantity > 0),

    UnitPrice DECIMAL(12,0) NOT NULL
        CHECK (UnitPrice >= 0),

    Amount DECIMAL(14,0)
        GENERATED ALWAYS AS (Quantity * UnitPrice) STORED,

    FOREIGN KEY (InvoiceID)
        REFERENCES Invoice(InvoiceID)
        ON DELETE RESTRICT,

    FOREIGN KEY (ServiceID)
        REFERENCES Service(ServiceID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;



-- =========================================
-- 17. PAYMENT
-- Không xóa giao dịch thanh toán
-- =========================================

CREATE TABLE Payment (
    PaymentID INT AUTO_INCREMENT PRIMARY KEY,

    InvoiceID INT NOT NULL,

    PaymentDate DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    Amount DECIMAL(12,0) NOT NULL
        CHECK (Amount > 0),

    PaymentMethod ENUM(
        'Cash',
        'BankTransfer',
        'Card',
        'EWallet'
    ) NOT NULL,

    PaymentStatus ENUM(
        'Completed',
        'Reversed'
    ) NOT NULL DEFAULT 'Completed',

    ReversalReason VARCHAR(255),
    ReversedAt DATETIME NULL,
    ReversedBy INT NULL,

    FOREIGN KEY (InvoiceID)
        REFERENCES Invoice(InvoiceID)
        ON DELETE RESTRICT,

    FOREIGN KEY (ReversedBy)
        REFERENCES Account(AccountID)
        ON DELETE RESTRICT
) ENGINE=InnoDB;
commit

USE DentalClinic;

-- 1. Cho phép InvoiceID nhận giá trị NULL khi kê đơn thuốc
ALTER TABLE PrescriptionDetail 
MODIFY COLUMN InvoiceID INT NULL;

-- 2. Thêm cột IsDeleted cho bảng Medicine nếu chưa có (hỗ trợ xóa mềm)
ALTER TABLE Medicine 
ADD COLUMN IF NOT EXISTS IsDeleted TINYINT(1) NOT NULL DEFAULT 0;


USE DentalClinic;

CREATE TABLE MedicalRecord (
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