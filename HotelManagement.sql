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
	DonGia money not null,
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
	NgayBatDau smalldatetime not null,
	NgayTraPhong smalldatetime ,-- khách thuê chưa biết khi nào trả thì null
	SoLuongKhach int,
	TinhTrang nvarchar(30) not null, -- có 3 tình trạng: "booked" / "checkin" /"cheokout"
	NguoiLapPhieu int foreign key references NGUOIDUNG(MaNgDung), --MaNguoiDung
	TienCoc money,
)


create table HOADON
(
	MaHoaDon int IDENTITY(10000, 1) primary key,
	MaPhieuThue int not null foreign key references PHIEUTHUEPHONG(MaPhieuThue),
	PhuThu money, -- lúc khách checkout, dựa vào số lượng khách, loại khách và bảng PHUTHU tính được tiền phụ thu
	TongTien money,
)


create table PHUTHU
(
	KhachThu3 float not null,
	KhachNuocNgoai float not null,
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

insert PHIEUTHUEPHONG(MaPhong,MaKH,NgayBatDau,NgayTraPhong,SoLuongKhach,TinhTrang,NguoiLapPhieu,TienCoc) values
(102,1002,7/2/2021,7/24/2021,3,'Checkin',1001,200000),
(104,1001,12/12/2021,12/30/2021,3,'Checkin',1000,500000),
(105,1003,4/12/2021,4/28/2021,3,'Checkin',1001,300000)


insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (101, 1000, '1-10-2020', '2-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (102, 1000, '2-10-2020', '3-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (103, 1000, '3-10-2020', '4-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (104, 1000, '4-10-2020', '5-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (101, 1000, '5-10-2020', '6-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (102, 1000, '6-10-2020', '7-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (103, 1000, '7-10-2020', '8-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (103, 1000, '2-10-2020', '3-10-2020', 'checkout');
insert into PHIEUTHUEPHONG(MaPhong, MaKH, NgayBatDau, NgayTraPhong, TinhTrang) values (103, 1000, '2-10-2020', '3-13-2020', 'checkout');


insert into HOADON(MaPhieuThue, TongTien) values (10036, 1000000);
insert into HOADON(MaPhieuThue, TongTien) values (10037, 2000000);
insert into HOADON(MaPhieuThue, TongTien) values (10038, 1500000);
insert into HOADON(MaPhieuThue, TongTien) values (10039, 1700000);
insert into HOADON(MaPhieuThue, TongTien) values (10040, 800000);
insert into HOADON(MaPhieuThue, TongTien) values (10041, 2200000);
insert into HOADON(MaPhieuThue, TongTien) values (10042, 950000);
insert into HOADON(MaPhieuThue, TongTien) values (10043, 1000000);
insert into HOADON(MaPhieuThue, TongTien) values (10044, 750000);
insert into HOADON(MaPhieuThue, TongTien) values (10045, 1200000);