create database HotelManagement
go

use HotelManagement
go

create table NGUOIDUNG
(
	MaNgDung int IDENTITY(1000, 1) primary key,
	TenTaiKhoan varchar(30) not null,
	MatKhau varchar(30) not null,
	TinhTrangTK int not null, --Tinh trang tai khoan: 0 => Block, 1 => Active
)

create table TTNguoiDung --Thong tin nguoi dung
(
	MaNgDung int references NGUOIDUNG(MaNgDung) primary key,
	Ho nvarchar(30),
	Ten nvarchar(30),
	SoDienThoai varchar(10),
	GioiTinh nvarchar(5),
	Email varchar(100),
	NgaySinh smalldatetime,
	QuyenHan int not null, --Quyen han su dung cac chuc nang cua ung dung: 0 => master(admin), 1 => Manager, 2 => staff
)

create table LOAIKHACHHANG
(
	MaLoaiKhach int IDENTITY(1, 1) primary key,
	TenLoaiKhach nvarchar(30), 
)

create table KHACHHANG
(
	MaKH int IDENTITY(1000, 1) primary key,
	TenKH nvarchar(50) not null,
	MaLoaiKhach int not null foreign key references LOAIKHACHHANG(MaLoaiKhach), 
	CMND varchar(10) not null,
	SoDienThoai varchar(10) not null,
	DiaChi nvarchar(100) not null,
	GioiTinh nvarchar(5) not null,
)

create table LOAIPHONG
(
	MaLoaiPhong int IDENTITY(1, 1) primary key,
	TenLoaiPhong nvarchar(30) not null,
	DonGia int not null,
	SoNgToiDa int not null,
)

create table PHONG
(
	MaPhong int IDENTITY(100, 1) primary key,
	TenPhong nvarchar(30) not null,
	MaLoaiPhong int not null foreign key references LOAIPHONG(MaLoaiPhong),
	GhiChu nvarchar(100),
)

create table PHIEUTHUEPHONG
(
	MaPhieuThue int IDENTITY(10000, 1) primary key,
	MaPhong int not null foreign key references PHONG(MaPhong),
	MaKH int not null foreign key references KHACHHANG(MaKH),
	NgayLapPhieu smalldatetime not null,
	NgayBatDau smalldatetime not null,
	NgayTraPhong smalldatetime ,-- khách thuê chưa biết khi nào trả thì null
	SoLuongKhach int,
	TinhTrang nvarchar(30) not null, -- có 3 tình trạng: "booked" / "checkin" /"cheokout"
	NguoiLapPhieu int foreign key references NGUOIDUNG(MaNgDung), --MaNguoiDung
	TienCoc int,
)

create table HOADON
(
	MaHoaDon int IDENTITY(10000, 1) primary key,
	MaPhieuThue int not null foreign key references PHIEUTHUEPHONG(MaPhieuThue),
	PhuThu int, -- lúc khách checkout, dựa vào số lượng khách, loại khách và bảng PHUTHU tính được tiền phụ thu
	TongTien int,
)


create table PHUTHU
(
	KhachThu3 int not null,
	KhachNuocNgoai int not null,
)



--Du lieu
insert NGUOIDUNG(TenTaiKhoan, MatKhau, TinhTrangTK) values 
('admin', '1', '1'),
('staff','1','2')

insert LOAIPHONG(TenLoaiPhong, DonGia, SoNgToiDa) values
('Standard (STD)', 300000, 2),
('Superior (SUP)', 500000, 2),
('Deluxe (DLX)', 750000, 3),
('Suite (SUT)', 1000000, 4)

insert PHONG(TenPhong, MaLoaiPhong) values
('101', 1),
('102', 1),
('103', 1),
('201', 2),
('202', 2),
('301', 3),
('302', 3),
('401', 4)


insert LOAIKHACHHANG(TenLoaiKhach) values
('Nuoc Ngoai'),
('Viet Nam')

insert KHACHHANG(TenKH,MaLoaiKhach,CMND,SoDienThoai,DiaChi,GioiTinh) values
('James Nguyen',1,86868686,09999999,'Ho Chi Minh City','Nam'),
('Tien Nam',1,88888888,01234567,'Ho Chi Minh City','Nam'),
('Xuan Bach',1,9999999,024681012,'Ho Chi Minh City','Nam'),
('Quoc Minh',1,86868686,0123456789,'Ho Chi Minh City','Nam')

insert PHIEUTHUEPHONG(MaPhong,MaKH,NgayLapPhieu,NgayBatDau,NgayTraPhong,SoLuongKhach,TinhTrang,NguoiLapPhieu,TienCoc) values
(102,1002,'7-2-2021','7-2-2021','7-24-2021',3,'Checkin',1001,200000),
(104,1001,'12-10-2021','12-12-2021','12-30-2021',3,'Checkin',1000,500000),
(105,1003,'4-12-2021','4-12-2021','4-28-2021',3,'Checkin',1001,300000),
(103,1000,'4-12-2021','4-15-2021','4-20-2021',2,'Checkout',1001,300000),
(103,1000,'3-29-2021','3-29-2021','4-1-2021',2,'Checkout',1001,300000),
(103,1000,'4-29-2021','4-30-2021','5-3-2021',2,'Checkin',1001,300000),
(103,1000,'6-17-2021','6-22-2021','7-1-2021',2,'Booked',1001,300000),
(101,1000,'6-18-2021','6-22-2021','6-25-2021',2,'Checkin',1001,300000),
(102,1000,'6-20-2021','6-22-2021','6-28-2021',2,'Booked',1001,300000),
(103,1000,'6-22-2021','6-22-2021','6-25-2021',2,'Checkin',1001,300000),
(105,1000,'6-16-2021','6-17-2021','6-22-2021',3,'Checkin',1001,300000),
(104,1000,'6-13-2021','6-20-2021','6-22-2021',3,'Checkout',1001,300000)

insert HOADON(MaPhieuThue,TongTien) values
(10000, 5200000), (10001, 4750000), (10002, 4400000), (10003, 1800000), (10004, 1000000),
(10005, 2000000), (10006, 4600000), (10007, 850000), (10008, 3300000), (10009, 1150000),
(10010, 2650000), (10011, 4750000)