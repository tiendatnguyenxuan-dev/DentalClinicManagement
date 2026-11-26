# -*- coding: utf-8 -*-
import os
import random
from datetime import datetime, timedelta

def generate_seed():
    lines = []
    lines.append("-- ===========================================================================")
    lines.append("-- DỮ LIỆU MẪU (SEED DATA) PHÒNG KHÁM NHA KHOA DENTAL CLINIC")
    lines.append("-- Quy chuẩn số lượng:")
    lines.append("--   - Employee: 10 records (Chỉ Bác sĩ, Y tá, Thu ngân)")
    lines.append("--   - Account: 10 records (Tương ứng 10 nhân viên)")
    lines.append("--   - Patient: 10 records")
    lines.append("--   - Còn lại 14 bảng: 30 records mỗi bảng")
    lines.append("-- ===========================================================================")
    lines.append("\nUSE DentalClinic;\n")
    lines.append("SET FOREIGN_KEY_CHECKS = 0;\n")

    # 1. SPECIALTY (30 records)
    lines.append("-- 1. SPECIALTY (30 records)")
    specialties = [
        "Nha khoa Tong quat", "Chinh nha - Nieng rang", "Phuc hinh rang - Rang su", "Cay ghep Implant",
        "Nha chu - Dieu tri nuou", "Noi nha - Lay tuy rang", "Nha khoa Tre em (Pedodontics)", "Phau thuat Ham mat",
        "Tay trang & Tham my rang", "Nho rang tieu phau - Rang khon", "Chan doan hinh anh X-Quang nha", "Dinh duong & Cham soc rang mieng",
        "Nha khoa Du phong", "Phuc hoi khop thai duong ham", "Nha khoa Can thiep toi thieu", "Laser nha khoa ky thuat cao",
        "Chinh nha mat luoi", "Nha khoa ky thuat so CAD/CAM", "Gay me & Giam dau nha khoa", "Benh hoc Mieng & Ham mat",
        "Chinh nha khay trong suot", "Phuc hinh thao lap toan phan", "Phuc hinh co dinh cau rang", "Dieu tri ngung tho khi ngu",
        "Tao hinh nuou tham my", "Nha khoa Nguoi cao tuoi", "Tham my mat dan su Veneer", "Ghep xuong & Nang xoang ham",
        "Cap cuu chan thuong rang", "Quan ly chat luong nha khoa"
    ]
    lines.append("TRUNCATE TABLE Specialty;")
    for i, sp in enumerate(specialties, start=1):
        lines.append(f"INSERT INTO Specialty (SpecialtyID, SpecialtyName, IsDeleted) VALUES ({i}, '{sp}', FALSE);")
    lines.append("")

    # 2. PATIENT (10 records)
    lines.append("-- 2. PATIENT (10 records)")
    patients = [
        (1, "Nguyen Van An", "1990-05-12", "Male", "0901000001", "an.nguyen@gmail.com", "123 Le Loi, Q1, TP.HCM", "Huyet ap binh thuong", "Khong"),
        (2, "Tran Thi Binh", "1985-08-22", "Female", "0901000002", "binh.tran@gmail.com", "456 Nguyen Hue, Q1, TP.HCM", "Da day nhe", "Di ung Penicillin"),
        (3, "Le Minh Chau", "1998-11-03", "Female", "0901000003", "chau.le@gmail.com", "789 Tran Hung Dao, Q5, TP.HCM", "Khong", "Khong"),
        (4, "Pham Quoc Dung", "1992-03-15", "Male", "0901000004", "dung.pham@gmail.com", "101 Vo Van Tan, Q3, TP.HCM", "Tieu duong nhe", "Khong"),
        (5, "Vo Ngoc Ha", "2001-07-19", "Female", "0901000005", "ha.vo@gmail.com", "202 Dien Bien Phu, Binh Thanh, TP.HCM", "Khong", "Di ung Aspirin"),
        (6, "Hoang Gia Kiet", "1995-12-30", "Male", "0901000006", "kiet.hoang@gmail.com", "303 CMT8, Q10, TP.HCM", "Hen suyen nhe", "Khong"),
        (7, "Do Thuy Linh", "1988-09-14", "Female", "0901000007", "linh.do@gmail.com", "404 Nguyen Thi Minh Khai, Q3, TP.HCM", "Khong", "Khong"),
        (8, "Bui Hoang Nam", "1994-01-25", "Male", "0901000008", "nam.bui@gmail.com", "505 Hai Ba Trung, Q1, TP.HCM", "Khong", "Khong"),
        (9, "Dinh Yen Nhi", "2003-04-18", "Female", "0901000009", "nhi.dinh@gmail.com", "606 Ly Thuong Kiet, Tan Binh, TP.HCM", "Khong", "Khong"),
        (10, "Nguyen Xuan Tien Dat", "2004-10-10", "Male", "0826277899", "tiendat@gmail.com", "707 Pham The Hien, Q8, TP.HCM", "Khong", "Khong")
    ]
    lines.append("TRUNCATE TABLE Patient;")
    for p in patients:
        lines.append(f"INSERT INTO Patient (PatientID, FullName, DateOfBirth, Gender, Phone, Email, Address, MedicalHistory, Allergies, RegistrationDate, PatientStatus) VALUES ({p[0]}, '{p[1]}', '{p[2]}', '{p[3]}', '{p[4]}', '{p[5]}', '{p[6]}', '{p[7]}', '{p[8]}', '2026-01-10', 'Active');")
    lines.append("")

    # 3. EMPLOYEE (10 records: Bác sĩ, Y tá, Thu ngân)
    # Check constraint: Position = 'Doctor' AND SpecialtyID IS NOT NULL AND PracticeLicenseNumber
    # Position <> 'Doctor' AND SpecialtyID IS NULL AND PracticeLicenseNumber IS NULL
    lines.append("-- 3. EMPLOYEE (10 records: 6 Bac si, 2 Y ta, 2 Thu ngan)")
    employees = [
        # (ID, Name, Position, Phone, Email, HireDate, SpecialtyID, License)
        (1, "BS Nguyen Van Hoang", "Doctor", "0912000001", "hoang.doctor@dental.vn", "2020-01-15", 1, "CCHN-00123-HCM"),
        (2, "BS Tran Thu Trang", "Doctor", "0912000002", "trang.doctor@dental.vn", "2021-03-10", 2, "CCHN-00124-HCM"),
        (3, "BS Le Hoang Nam", "Doctor", "0912000003", "nam.doctor@dental.vn", "2019-06-20", 3, "CCHN-00125-HCM"),
        (4, "BS Pham Minh Khoa", "Doctor", "0912000004", "khoa.doctor@dental.vn", "2022-02-01", 4, "CCHN-00126-HCM"),
        (5, "BS Vo Thao My", "Doctor", "0912000005", "my.doctor@dental.vn", "2023-05-15", 5, "CCHN-00127-HCM"),
        (6, "BS Dang Quoc Bao", "Doctor", "0912000006", "bao.doctor@dental.vn", "2022-08-18", 6, "CCHN-00128-HCM"),
        (7, "YT Nguyen Thi Mai", "Nurse", "0912000007", "mai.nurse@dental.vn", "2022-09-01", "NULL", "NULL"),
        (8, "YT Le Cam Tu", "Nurse", "0912000008", "tu.nurse@dental.vn", "2023-01-10", "NULL", "NULL"),
        (9, "TN Tran Thuy Nga", "Cashier", "0912000009", "nga.cashier@dental.vn", "2021-11-05", "NULL", "NULL"),
        (10, "TN Vo Thanh Tam", "Cashier", "0912000010", "tam.cashier@dental.vn", "2022-10-12", "NULL", "NULL")
    ]
    lines.append("TRUNCATE TABLE Employee;")
    for emp in employees:
        spec_val = emp[6] if emp[6] == "NULL" else f"{emp[6]}"
        lic_val = emp[7] if emp[7] == "NULL" else f"'{emp[7]}'"
        lines.append(f"INSERT INTO Employee (EmployeeID, FullName, Position, Phone, Email, HireDate, SpecialtyID, PracticeLicenseNumber, EmploymentStatus) VALUES ({emp[0]}, '{emp[1]}', '{emp[2]}', '{emp[3]}', '{emp[4]}', '{emp[5]}', {spec_val}, {lic_val}, 'Active');")
    lines.append("")

    # 4. ACCOUNT (10 records cho 10 nhân viên)
    lines.append("-- 4. ACCOUNT (10 records: mk 123456)")
    # SHA256 of '123456'
    pwd_hash = "ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548"
    accounts = [
        (1, 1, "bs_hoang"),
        (2, 2, "bs_trang"),
        (3, 3, "bs_nam"),
        (4, 4, "bs_khoa"),
        (5, 5, "bs_my"),
        (6, 6, "bs_bao"),
        (7, 7, "yt_mai"),
        (8, 8, "yt_tu"),
        (9, 9, "tn_nga"),
        (10, 10, "tn_tam")
    ]
    lines.append("TRUNCATE TABLE Account;")
    for acc in accounts:
        lines.append(f"INSERT INTO Account (AccountID, EmployeeID, Username, PasswordHash, AccountStatus) VALUES ({acc[0]}, {acc[1]}, '{acc[2]}', '{pwd_hash}', 'Active');")
    lines.append("")

    # 5. AUDITLOG (30 records)
    lines.append("-- 5. AUDITLOG (30 records)")
    lines.append("TRUNCATE TABLE AuditLog;")
    actions = ['INSERT', 'UPDATE', 'DELETE']
    entities = ['Patient', 'Appointment', 'Examination', 'Medicine', 'Invoice', 'Payment']
    for i in range(1, 31):
        acc_id = ((i - 1) % 10) + 1
        act = actions[i % len(actions)]
        ent = entities[i % len(entities)]
        desc = f"Nguoi dung {accounts[acc_id-1][2]} thuc hien {act} ban ghi {ent} ID {i}"
        dt = f"2026-{(i % 11) + 1:02d}-{(i % 25) + 1:02d} {(8 + (i % 9)):02d}:15:00"
        lines.append(f"INSERT INTO AuditLog (LogID, AccountID, ActionType, EntityName, EntityID, Description, CreatedAt) VALUES ({i}, {acc_id}, '{act}', '{ent}', {i}, '{desc}', '{dt}');")
    lines.append("")

    # 6. WORK SCHEDULE (30 records)
    lines.append("-- 6. WORK SCHEDULE (30 records)")
    lines.append("TRUNCATE TABLE WorkSchedule;")
    shifts = ['Morning', 'Afternoon', 'FullDay']
    # 30 ca phan bo trong thang 11/2026 cho 10 nhan vien
    s_idx = 1
    for day in range(1, 11):
        for s_shift in ['Morning', 'Afternoon', 'FullDay']:
            emp_id = ((s_idx - 1) % 10) + 1
            date_str = f"2026-11-{day:02d}"
            lines.append(f"INSERT INTO WorkSchedule (ScheduleID, EmployeeID, WorkDate, Shift, IsDeleted) VALUES ({s_idx}, {emp_id}, '{date_str}', '{s_shift}', FALSE);")
            s_idx += 1
            if s_idx > 30:
                break
        if s_idx > 30:
            break
    lines.append("")

    # 7. SERVICE (30 records)
    lines.append("-- 7. SERVICE (30 records)")
    lines.append("TRUNCATE TABLE Service;")
    services = [
        (1, "Kham tong quat & Tu van", "Tong quat", 100000, "Lan"),
        (2, "Cao voi rang & Danh bong 2 ham", "Ve sinh", 250000, "Lan"),
        (3, "Tram rang Composite loai 1", "Dieu tri", 300000, "Rang"),
        (4, "Tram rang Composite tham my", "Tham my", 500000, "Rang"),
        (5, "Nho rang cua - rang ham nho", "Tieu phau", 400000, "Rang"),
        (6, "Nho rang khon ham tren (Don gian)", "Tieu phau", 1000000, "Rang"),
        (7, "Nho rang khon ham duoi (Phuc tap/Lech)", "Tieu phau", 2000000, "Rang"),
        (8, "Dieu tri tuy rang 1 chan", "Noi nha", 800000, "Rang"),
        (9, "Dieu tri tuy rang nhieu chan", "Noi nha", 1500000, "Rang"),
        (10, "Tay trang rang tai phong (Laser)", "Tham my", 2500000, "Ca"),
        (11, "Rang su Kim loai Ceramco III", "Phuc hinh", 1500000, "Rang"),
        (12, "Rang toan su Zirconia cao cap", "Phuc hinh", 3500000, "Rang"),
        (13, "Rang toan su Cercon HT", "Phuc hinh", 5000000, "Rang"),
        (14, "Dan su Veneer Emax", "Tham my", 6500000, "Rang"),
        (15, "Cay ghep Implant Dentium (Han Quoc)", "Implant", 14000000, "Tru"),
        (16, "Cay ghep Implant Straumann (Thuy Si)", "Implant", 28000000, "Tru"),
        (17, "Nieng rang Mac cai Kim loai truyen thong", "Chinh nha", 30000000, "Goi"),
        (18, "Nieng rang Mac cai Su tham my", "Chinh nha", 45000000, "Goi"),
        (19, "Nieng rang trong suot Invisalign", "Chinh nha", 85000000, "Goi"),
        (20, "Phau thuat cat chóp rang & nao nang", "Tieu phau", 2500000, "Rang"),
        (21, "Chua nha chu & Nao tui loi", "Dieu tri", 1200000, "Ham"),
        (22, "Ham thao lap ban phan nhua deo", "Phuc hinh", 3000000, "Ham"),
        (23, "Ham thao lap toan phan", "Phuc hinh", 7000000, "Ham"),
        (24, "Chup X-quang Panorama toan canh", "Chan doan", 200000, "Phim"),
        (25, "Chup X-quang CT Cone Beam 3D", "Chan doan", 500000, "Phim"),
        (26, "Gan da tham my tren rang", "Tham my", 400000, "Vien"),
        (27, "Tao hinh vien nuou tham my", "Tham my", 1800000, "Rang"),
        (28, "Ghep xuong nhan tao", "Implant", 4000000, "Tep"),
        (29, "Nang xoang kin / xoang ho", "Implant", 6000000, "Xoang"),
        (30, "Mang chong nghieng rang ban dem", "Tong quat", 1500000, "Cai")
    ]
    for s in services:
        lines.append(f"INSERT INTO Service (ServiceID, ServiceName, ServiceCategory, UnitPrice, Unit, IsDeleted) VALUES ({s[0]}, '{s[1]}', '{s[2]}', {s[3]}, '{s[4]}', FALSE);")
    lines.append("")

    # 8. MEDICINE (30 records)
    lines.append("-- 8. MEDICINE (30 records)")
    lines.append("TRUNCATE TABLE Medicine;")
    medicines = [
        (1, "Amoxicillin 500mg", "Vien", 2000, 500),
        (2, "Augmentin 1g (Amoxicillin + Clavulanate)", "Vien", 18000, 300),
        (3, "Paracetamol 500mg (Giam dau)", "Vien", 1000, 1000),
        (4, "Efferalgan Codeine 500mg", "Vien", 6000, 200),
        (5, "Ibuprofen 400mg", "Vien", 1500, 450),
        (6, "Alpha Choay (Khang viem giam phu ne)", "Vien", 2500, 600),
        (7, "Rodogyl (Spiramycin + Metronidazol)", "Vien", 4500, 350),
        (8, "Cefixim 200mg", "Vien", 12000, 250),
        (9, "Metronidazol 250mg", "Vien", 1200, 400),
        (10, "Medrol 16mg (Methylprednisolon)", "Vien", 5000, 300),
        (11, "Nước súc miệng Chlorohexidine 0.12%", "Chai", 95000, 80),
        (12, "Gel bôi nhiệt miệng Kamistad-Gel N", "Tuyp", 65000, 120),
        (13, "Vitamin C 500mg", "Vien", 1000, 800),
        (14, "Vitamin 3B (B1-B6-B12)", "Vien", 1500, 500),
        (15, "Gingival gel trị viêm nướu", "Tuyp", 120000, 60),
        (16, "Ciprofloxacin 500mg", "Vien", 3500, 250),
        (17, "Diclofenac 50mg", "Vien", 2000, 300),
        (18, "Prednisolon 5mg", "Vien", 800, 500),
        (19, "Spiramycin 1.5M UI", "Vien", 3000, 400),
        (20, "Doxycycline 100mg", "Vien", 2500, 200),
        (21, "Thuốc cầm máu Tranexamic acid 500mg", "Vien", 7000, 150),
        (22, "Nước muối sinh lý NaCl 0.9% 500ml", "Chai", 12000, 300),
        (23, "Kem đánh răng chống ê buốt Sensodyne", "Tuyp", 85000, 100),
        (24, "Xịt thơm miệng thảo dược nha khoa", "Chai", 45000, 90),
        (25, "Meloxicam 7.5mg", "Vien", 3500, 320),
        (26, "Omeprazol 20mg (Bao ve da day)", "Vien", 2000, 400),
        (27, "Cephalexin 500mg", "Vien", 1800, 500),
        (28, "Mobic 15mg", "Vien", 15000, 150),
        (29, "Betadine súc họng 1% 125ml", "Chai", 75000, 70),
        (30, "Kẹo ngậm giảm đau họng Strepsils", "Hop", 35000, 150)
    ]
    for m in medicines:
        lines.append(f"INSERT INTO Medicine (MedicineID, MedicineName, Unit, UnitPrice, StockQuantity, IsDeleted) VALUES ({m[0]}, '{m[1]}', '{m[2]}', {m[3]}, {m[4]}, FALSE);")
    lines.append("")

    # 9. MEDICAL RECORD (30 records: 1-10 cho 10 bệnh nhân, 11-30 dự phòng)
    # Ràng buộc UNIQUE (PatientID)
    lines.append("-- 9. MEDICAL RECORD (30 records: 10 records cho 10 PatientID 1..10)")
    lines.append("TRUNCATE TABLE MedicalRecord;")
    for i in range(1, 11):
        lines.append(f"INSERT INTO MedicalRecord (MedicalRecordID, PatientID, RecordCode, CreatedDate, RecordStatus, IsDeleted) VALUES ({i}, {i}, 'MR-2026-{i:04d}', '2026-01-10', 'Active', FALSE);")
    lines.append("")

    # 10. APPOINTMENT (30 records)
    lines.append("-- 10. APPOINTMENT (30 records)")
    lines.append("TRUNCATE TABLE Appointment;")
    reasons = [
        "Kham rang dinh ky", "Dau rang ham duoi", "Tay trang rang don tet", "Tu van nieng rang mac cai",
        "Nho rang khon lech", "Tram rang cua bi me", "Chay mau chan rang", "Kiem tra rang su",
        "Lay tuy rang ham", "Kham viem nuou cap"
    ]
    app_statuses = ['Completed', 'Completed', 'Completed', 'Confirmed', 'Pending', 'Cancelled', 'NoShow']
    for i in range(1, 31):
        pat_id = ((i - 1) % 10) + 1
        doc_id = ((i - 1) % 6) + 1 # Bác sĩ 1..6
        month = (i % 11) + 1
        day = (i % 26) + 1
        hour = 8 + (i % 10)
        dt = f"2026-{month:02d}-{day:02d} {hour:02d}:30:00"
        status = 'Completed' if i <= 20 else app_statuses[i % len(app_statuses)]
        notes = reasons[i % len(reasons)]
        lines.append(f"INSERT INTO Appointment (AppointmentID, PatientID, DoctorID, AppointmentDateTime, AppointmentStatus, Notes) VALUES ({i}, {pat_id}, {doc_id}, '{dt}', '{status}', '{notes}');")
    lines.append("")

    # 11. EXAMINATION (30 records)
    # Ràng buộc: AppointmentID UNIQUE (có thể null nếu khám vãng lai)
    lines.append("-- 11. EXAMINATION (30 records)")
    lines.append("TRUNCATE TABLE Examination;")
    diagnoses = [
        "Sau rang ham so 6, ton thuong men rang", "Viem tuy cap rang 46, can lay tuy",
        "Viem nuou man tinh do voi rang", "Rang khon 38 moc lech 45 do gay chen ep",
        "Me rang cua 11 do chan thuong", "Rang bi nhiem mau khang sinh nang",
        "Vi tri mat rang 36, tieu xuong nhe", "Lech lac khop can hang II",
        "Viem nha chu quanh cuong rang 24", "Mon co rang hang loat do chai rang sai cach"
    ]
    conclusions = [
        "Chi dinh tram rang Composite tham my", "Lay tuy, tao hinh ong tuy va tram bít",
        "Cao voi rang 2 ham, huong dan ve sinh rang mieng", "Phau thuat nho rang khon lech",
        "Phuc hinh rang su toan phan", "Tay trang rang tai phong bang Laser",
        "Tu van cay ghep Implant", "Ke hoach chinh nha mac cai kim loai 18 thang",
        "Dieu tri noi nha ket hop thuoc khang sinh", "Tram co rang va ke kem danh rang chuyen dung"
    ]
    for i in range(1, 31):
        pat_id = ((i - 1) % 10) + 1
        doc_id = ((i - 1) % 6) + 1
        # Gán AppointmentID 1..25, còn lại null (khám vãng lai)
        app_id_val = f"{i}" if i <= 25 else "NULL"
        month = (i % 11) + 1
        day = (i % 26) + 1
        ex_date = f"2026-{month:02d}-{day:02d} {9 + (i % 8):02d}:00:00"
        diag = diagnoses[i % len(diagnoses)]
        conc = conclusions[i % len(conclusions)]
        # 25 ca Finalized, 5 ca Draft
        status = 'Finalized' if i <= 25 else 'Draft'
        f_date = f"2026-{month:02d}-{min(day+14, 28):02d}"
        lines.append(f"INSERT INTO Examination (ExaminationID, PatientID, DoctorID, AppointmentID, ExaminationDate, ExaminationReason, Diagnosis, Conclusion, FollowUpDate, ExaminationStatus) VALUES ({i}, {pat_id}, {doc_id}, {app_id_val}, '{ex_date}', 'Den kham theo lich', '{diag}', '{conc}', '{f_date}', '{status}');")
    lines.append("")

    # 12. EXAMINATION SERVICE (30 records)
    lines.append("-- 12. EXAMINATION SERVICE (30 records)")
    lines.append("TRUNCATE TABLE ExaminationService;")
    tooth_nums = ["11", "21", "36", "46", "38", "48", "16", "26", "Tong quat", "2 ham"]
    for i in range(1, 31):
        exam_id = i # Moi ca kham co 1 chi dinh dich vu
        srv_id = ((i - 1) % 15) + 1
        tooth = tooth_nums[i % len(tooth_nums)]
        qty = 1 if i % 4 != 0 else 2
        price = services[srv_id-1][3]
        lines.append(f"INSERT INTO ExaminationService (ExaminationServiceID, ExaminationID, ServiceID, ToothNumber, Quantity, UnitPrice, Notes, IsVoided) VALUES ({i}, {exam_id}, {srv_id}, '{tooth}', {qty}, {price}, 'Thuc hien dung quy trinh ky thuat', FALSE);")
    lines.append("")

    # 13. PRESCRIPTION (30 records)
    # Ràng buộc: ExaminationID UNIQUE
    lines.append("-- 13. PRESCRIPTION (30 records)")
    lines.append("TRUNCATE TABLE Prescription;")
    for i in range(1, 31):
        exam_id = i
        month = (i % 11) + 1
        day = (i % 26) + 1
        p_date = f"2026-{month:02d}-{day:02d}"
        status = 'Issued' if i <= 25 else 'Draft'
        lines.append(f"INSERT INTO Prescription (PrescriptionID, ExaminationID, PrescriptionDate, Instructions, PrescriptionStatus) VALUES ({i}, {exam_id}, '{p_date}', 'Uong thuoc sau khi an no, tai kham sau 7 ngay neu con dau', '{status}');")
    lines.append("")

    # 14. INVOICE (30 records)
    # Ràng buộc: ExaminationID UNIQUE
    # DiscountAmount <= (TotalAmountMedicine + TotalAmountService)
    lines.append("-- 14. INVOICE (30 records)")
    lines.append("TRUNCATE TABLE Invoice;")
    for i in range(1, 31):
        exam_id = i
        emp_id = 9 if i % 2 == 0 else 10 # Thu ngân 9 hoặc 10
        month = (i % 11) + 1
        day = (i % 26) + 1
        inv_date = f"2026-{month:02d}-{day:02d} {11 + (i % 6):02d}:30:00"
        srv_id = ((i - 1) % 15) + 1
        srv_amount = services[srv_id-1][3]
        med_id = ((i - 1) % 10) + 1
        med_amount = medicines[med_id-1][3] * 10
        discount = 50000 if i % 3 == 0 else 0
        p_status = 'Paid' if i <= 24 else ('PartiallyPaid' if i <= 28 else 'Unpaid')
        inv_status = 'Issued'
        lines.append(f"INSERT INTO Invoice (InvoiceID, ExaminationID, EmployeeID, InvoiceDate, TotalAmountMedicine, TotalAmountService, DiscountAmount, PaymentStatus, InvoiceStatus) VALUES ({i}, {exam_id}, {emp_id}, '{inv_date}', {med_amount}, {srv_amount}, {discount}, '{p_status}', '{inv_status}');")
    lines.append("")

    # 15. PRESCRIPTION DETAIL (30 records)
    # PRIMARY KEY (PrescriptionID, MedicineID)
    lines.append("-- 15. PRESCRIPTION DETAIL (30 records)")
    lines.append("TRUNCATE TABLE PrescriptionDetail;")
    for i in range(1, 31):
        pres_id = i
        med_id = ((i - 1) % 15) + 1
        inv_id = i
        qty = 10 if i % 2 == 0 else 14
        dosage = "Ngay uong 2 lan, moi lan 1 vien sau an"
        lines.append(f"INSERT INTO PrescriptionDetail (PrescriptionID, MedicineID, InvoiceID, Quantity, Dosage, IsVoided) VALUES ({pres_id}, {med_id}, {inv_id}, {qty}, '{dosage}', FALSE);")
    lines.append("")

    # 16. INVOICE SERVICE DETAIL (30 records)
    lines.append("-- 16. INVOICE SERVICE DETAIL (30 records)")
    lines.append("TRUNCATE TABLE InvoiceServiceDetail;")
    for i in range(1, 31):
        inv_id = i
        srv_id = ((i - 1) % 15) + 1
        qty = 1
        price = services[srv_id-1][3]
        lines.append(f"INSERT INTO InvoiceServiceDetail (InvoiceServiceDetailID, InvoiceID, ServiceID, Quantity, UnitPrice) VALUES ({i}, {inv_id}, {srv_id}, {qty}, {price});")
    lines.append("")

    # 17. PAYMENT (30 records)
    # PaymentStatus: 'Completed', 'Reversed'
    # PaymentMethod: 'Cash', 'BankTransfer', 'Card', 'EWallet'
    lines.append("-- 17. PAYMENT (30 records)")
    lines.append("TRUNCATE TABLE Payment;")
    pay_methods = ['Cash', 'BankTransfer', 'Card', 'EWallet']
    for i in range(1, 31):
        inv_id = i
        month = (i % 11) + 1
        day = (i % 26) + 1
        pay_date = f"2026-{month:02d}-{day:02d} {12 + (i % 5):02d}:00:00"
        srv_id = ((i - 1) % 15) + 1
        srv_amount = services[srv_id-1][3]
        med_id = ((i - 1) % 10) + 1
        med_amount = medicines[med_id-1][3] * 10
        discount = 50000 if i % 3 == 0 else 0
        total_pay = srv_amount + med_amount - discount
        method = pay_methods[i % len(pay_methods)]
        status = 'Completed' if i != 15 else 'Reversed'
        rev_reason = "Khach chuyen khoan nham so tien" if i == 15 else "NULL"
        rev_val = f"'{rev_reason}'" if rev_reason != "NULL" else "NULL"
        lines.append(f"INSERT INTO Payment (PaymentID, InvoiceID, PaymentDate, Amount, PaymentMethod, PaymentStatus, ReversalReason) VALUES ({i}, {inv_id}, '{pay_date}', {total_pay}, '{method}', '{status}', {rev_val});")
    lines.append("")

    lines.append("SET FOREIGN_KEY_CHECKS = 1;")
    lines.append("COMMIT;\n")

    seed_sql = "\n".join(lines)
    with open("seed_data.sql", "w", encoding="utf-8") as f:
        f.write(seed_sql)
    print("Tao thanh cong file seed_data.sql!")

if __name__ == '__main__':
    generate_seed()
