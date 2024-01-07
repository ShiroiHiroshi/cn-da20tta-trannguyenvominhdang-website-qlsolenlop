Create Database QuanLySoLenLop
Use QuanLySoLenLop

Create Table Admin(
	Username Varchar(50) PRIMARY KEY NOT NULL,
	Password varchar(50) NOT NULL,
)

Create table Khoa(
	MaKhoa varchar(10) NOT NULL PRIMARY KEY,
	TenKhoa Nvarchar(100) NOT NULL,
)

create table BoMon(
	MaBoMon varchar(10) NOT NULL PRIMARY KEY,
	TenBoMon Nvarchar(100) NOT NULL,
)

Create Table GiangVien(
	MaGVGD Varchar(10) NOT NULL PRIMARY KEY,
	HoTenGVGD NVarchar(100) NOT NULL,
	Matkhau varchar(50) NOT NULL,
	
	MaKhoa varchar(10) NOT NULL,
	MaBoMon varchar(10) NOT NULL,

	FOREIGN KEY (MaKhoa) REFERENCES Khoa(MaKhoa), 
	FOREIGN KEY (MaBoMon) REFERENCES BoMon(MaBoMon),
)

Create Table MonHoc(
	MaMH Varchar(10) NOT NULL PRIMARY KEY,
	TenMH NVarchar(50) NOT NULL,
	SoTietLT int NOT NULL,
	SoTietTH int NOT NULL,
)

create table Lop(
	MaLop varchar(10) NOT NULL PRIMARY KEY,
	TenLop Nvarchar(50) NOT NULL,
)


create table Phong(
	MaPhong varchar(10) NOT NULL PRIMARY KEY,
	TenPhong Nvarchar(100),
)


 create table SoLenLop(
	ID int PRIMARY KEY IDENTITY(1,1),
	HocKy int NOT NULL,
	NamHoc varchar(11) NOT NULL,
	Nhom int NOT NULL,
	NgayLenLop Date NOT NULL,
	Buoi int NOT NULL,
	SoTietDayLT int NOT NULL,
	SoTietDayTH int NOT NULL,
	SinhVienVang Nvarchar(200),
	Tomtatnoidung Nvarchar(200),

	MaMH varchar(10) NOT NULL,
	MaLop varchar(10) NOT NULL,
	MaPhong varchar(10) NOT NULL,
	MaGVGD varchar(10) NOT NULL,
	FOREIGN KEY (MaGVGD) REFERENCES GiangVien(MaGVGD), 
	FOREIGN KEY (MaMH) REFERENCES MonHoc(MaMH), 
	FOREIGN KEY (MaPhong) REFERENCES Phong(MaPhong), 
	FOREIGN KEY (MaLop) REFERENCES Lop(MaLop), 
 )
 insert into Admin values('Admin','123')
 select *
 from Admin
 ---Thêm dữ liệu Khoa Phòng---
Insert into Khoa values('KH01',N'Khoa Kỹ Thuật & Công nghệ')
Insert into Khoa values('KH02',N'Khoa Y - Dược')
Insert into Khoa values('KH03',N'Khoa Lý luận chính trị')
Insert into Khoa values('KH04',N'Khoa Nông nghiệp - Thủy sản')
Insert into Khoa values('KH05',N'Khoa Ngoại ngữ')
Select *
From Khoa
---Thêm dữ liệu Bộ môn---
Insert into BoMon values('BM01',N'Bộ môn Công nghệ thông tin')
Insert into BoMon values('BM02',N'Bộ môn Điện điện tử')
Insert into BoMon values('BM03',N'Bộ môn Tiếng anh')
Insert into BoMon values('BM04',N'Bộ môn Chăn nuôi thú y')
Insert into BoMon values('BM05',N'Bộ môn Thủy sản')
Insert into BoMon values('BM06',N'Bộ môn Dược')
select *
From BoMon
---Thêm dữ liệu Phòng---
Insert into Phong values('C71-204',N'Phòng máy')
Insert into Phong values('C71-205',N'Phòng máy')
Insert into Phong values('C71-206',N'Phòng máy')
Insert into Phong values('B21-101',N'Phòng học')
Insert into Phong values('B21-102',N'Phòng học')
select *
From Phong
--Thêm dữ liệu Lớp---
Insert into Lop values('DA20TTA',N'Công nghệ thông tin A')
Insert into Lop values('DA20TTB',N'Công nghệ thông tin B')
select *
From Lop
--Thêm dữ liệu môn học--
Insert into MonHoc values('MH01',N'Xử lý ảnh',30,30)
Insert into MonHoc values('MH02',N'Công nghệ phần mềm',30,30)
Insert into MonHoc values('MH03',N'Lập trình thiết bị di động',30,30)
select *
From MonHoc
select *
From SoLenLop




