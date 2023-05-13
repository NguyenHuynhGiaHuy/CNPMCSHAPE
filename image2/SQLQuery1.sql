create database QLyQuanCaPhe2
go
use QLyQuanCaPhe2

create table NhanVien(
	idNV nvarchar(100) primary key,
	tenNV nvarchar(30) not null,
	tenDangnhap  nvarchar(50) not null,
	gioiTinh nvarchar(5),
	namSinh int, 
	chucVu nvarchar(30),
	luong float,
	matKhau varchar(50) not null,

)
go

create table TaiKhoan(
    id int identity primary key,
	tenNV nvarchar(30) not null,
	matKhau varchar(50) not null,
	tenDangnhap nvarchar(50) not null,
	Type int not null,
)

go


create table Ban(
	idBan int identity primary key,
	tenBan nvarchar(100) not null,
	loai nvarchar(100),
	tinhTrangBan nvarchar(100)not null default N'Trống'--kiểm tra có người hay chưa
)
go

create table HoaDon(
	idHD int identity primary key,
	idBan int,
	ngayVao date not null,
	ngayRa date not null,
	ghiChu int default 0, --thanh toán 1 hay chưa 0
	giamGia int default 0
	foreign key (idBan) references Ban(idBan),
)
go


create table LoaiSanPham(
 id int identity primary key,
 tenLoaiSanPham nvarchar(100) not null
)
go
create table SanPham(
	id int identity primary key,
	idloaiSP int,
	tenSP nvarchar(50)not null,
	giaTien float not null,
	donViTinh varchar(03) default 'VNĐ',
	foreign key (idloaiSP) references LoaiSanPham(id)
)
go
select id as [Mã sản phẩm], tenSP as [Tên sản phẩm], giaTien as [Giá tiền], donViTinh as [Đơn vị tính] 
from SanPham
go
--drop table ChiTietHoaDon
--drop table HoaDon 
--drop table SanPham
--drop table LoaiSanPham
create table ChiTietHoaDon(
    idCTHD int identity primary key,
	idHD int,
	id int,
	soLuong int,
	ghiChu nvarchar(100), --ít đá,....
	foreign key (idHD) references HoaDon(idHD),
    foreign key (id) references SanPham(id)
)
go

insert into TaiKhoan (tenNV, matKhau, tenDangnhap, Type)
VALUES  ( N'Nguyễn Kim Ngân ' , 
          '123456789' , 
          N'Quanly' , 
          1
        )
insert into TaiKhoan (tenNV, matKhau, tenDangnhap, Type)
VALUES  ( N'Trần Thu Hương' , 
          '123456789' , 
          N'Thungan' , 
          0
        )
select * from TaiKhoan 
insert into NhanVien (idNV, tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  ( 'NV001', 
          N'Nguyễn Kim Ngân' , 
		  N'Quanly',
          N'Nữ' , 
		  '2003',
		  N'Quản lý',
		  '100',
          '123456789'
        )
go
Select * from NhanVien 
Select tenNV as [Tên nhân viên], matKhau as [Mật khẩu], tenDangnhap as [Tên đăng nhập], Type as [Quyền]  from TaiKhoan
Go 
--CREATE PROC USP_GetAccountByUserName
--@tenDangnhap nvarchar(50)
--AS 
--BEGIN
--	SELECT * FROM TaiKhoan WHERE tenDangnhap = @tenDangnhap
--END
--GO

--EXEC dbo.USP_GetAccountByUserName @tenDangnhap = N'Quanly' 

--EXEC dbo.USP_GetAccountByUserName @tenDangnhap = N'Thungan ' 

--ban 
DECLARE @ban  INT = 0

WHILE @ban <= 19
BEGIN
	INSERT Ban (tenBan)VALUES  ( N'Bàn ' + CAST(@ban AS nvarchar(100)))
	SET @ban = @ban + 1
END

select * from Ban 
go

create proc gettableList
as select  * from Ban
go
update Ban set tinhTrangBan = N'Có người' where idBan = 4
exec  gettableList
go 
--ban 

--Loại sp 
insert LoaiSanPham(tenLoaiSanPham) values (N'Cà phê')
insert LoaiSanPham(tenLoaiSanPham) values (N'Trà')
insert LoaiSanPham(tenLoaiSanPham) values (N'Nước ép')
insert LoaiSanPham(tenLoaiSanPham) values (N'Sinh tố')
--Sản phẩm 

insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Cà phê đen', 1, 22000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Cà phê sữa', 1, 24000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Bạc xĩu', 1, 28000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Cà phê sữa tươi', 1, 24000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Cà phê cốt dừa', 1, 20000)

insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Trà nhiệt đới', 2, 25000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Trà lài đát thơm', 2, 25000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Trà đào', 2, 25000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Trà bí đao hạt chia', 2, 10000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Trà dưa gang', 2, 25000)

insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Nước ép dưa hấu', 3, 20000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Nước ép thơm', 3, 20000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Nước ép cà chua', 3, 15000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Nước ép táo', 3, 20000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Nước ép mix tự chọn', 3, 30000)

insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Sinh tố dâu', 4, 36000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Sinh tố việt quất', 4, 36000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Sinh tố xoài', 4, 30000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Sinh tố Sapoche', 4, 30000)
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Sinh tố mảng cầu', 4, 30000)

----Hóa đơn 
--insert HoaDon(ngayVao, ngayRa, idBan)
--values (GETDATE(), GETDATE(), 1)
--insert HoaDon(ngayVao, ngayRa, idBan)
--values (GETDATE(), GETDATE(), 2)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 3, 1)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 4, 0)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 5, 1)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 6, 1)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 7, 0)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 8, 1)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 9, 0)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(), 10, 1)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(),11, 0)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(),19, 0)
--insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
--values (GETDATE(), GETDATE(),20, 0)

----Chi tiết hóa đơn  
insert  ChiTietHoaDon(idHD,id, soLuong)
values (2,1,2)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (2,2,5)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (2,3,1)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (4,4,6)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (4,5,5)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (4,6,5)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (3,7,8)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (3,8,2)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (5,9,2)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (6,10,2)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (7,11,2)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (8,12,4)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (8,13,2)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (8,14,6)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (8,15,4)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (10,15,4)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (1,15,4)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (9,7,3)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (10,5,4)
insert  ChiTietHoaDon(idHD,id, soLuong)
values (13,8,1)

 select * from Ban
select * from HoaDon
select * from ChiTietHoaDon
select * from SanPham
select * from LoaiSanPham
select Max(idHD) from HoaDon 



--thêm hóa đơn theo bàn 
go
create proc InsertHoaDon
@idBan int 
as
begin 
  insert HoaDon(ngayVao, ngayRa, idBan, giamGia)
  values (getdate(), getdate(), @idBan, 0)
end
go
--ThemChiTietHoaDon
go
create proc InsertChiTietHoaDon
@idHD int, @id int, @soLuong int
as
begin 
    declare @HDdaco int 
	declare @soLuongsp int = 1 

	select @HDdaco = idCTHD, @soLuongsp = soLuong from ChiTietHoaDon where idHD = @idHD and id = @id 
	if (@HDdaco > 0)
	begin 
	   declare @soLuongmoi int = @soLuongsp + @soLuong
	   if (@soLuongmoi > 0)
	      update ChiTietHoaDon set soLuong = @soLuongsp + @soLuong where id = @id 
	   else 
	      delete ChiTietHoaDon where idHD = @idHD and id = @id 
	end 
	else
	begin 
		insert  ChiTietHoaDon(idHD, id, soLuong)
		values (@idHD, @id, @soLuong)
	end 
end
go
delete ChiTietHoaDon
delete HoaDon
create trigger CapnhatCTHD
on ChiTietHoaDon for insert, update
as
begin
	declare @idHD int 
	
	select @idHD = idHD from inserted
	
	declare @idBan int
	
	select @idBan = idBan FROM HoaDon where  idHD = @idHD AND ghiChu = 0
	
	update Ban set tinhTrangBan = N'Có người' where  idBan = @idBan
end 
go

create trigger CapnhatHD
on HoaDon for update
as 
begin
	declare @idHD int
	
	select  @idHD  = idHD from Inserted	
	
	declare @idBan int
	
	select @idBan = idBan from HoaDon where  idHD = @idHD 
	
	declare @soLuong int = 0
	
	select @soLuong = COUNT(*) from HoaDon where  idBan = @idBan AND ghiChu = 0
	
	if (@soLuong = 0)
		update Ban SET tinhTrangBan = N'Trống' where idBan = @idBan
end
go 

create TRIGGER Kiemtrahoadon
ON HoaDon FOR UPDATE
AS
BEGIN
	DECLARE @idHD INT
	SELECT @idHD = idHD FROM Inserted
	DECLARE @idBan INT
	SELECT @idBan = idBan FROM HoaDon WHERE idHD = @idHD AND ghiChu = 1
	UPDATE Ban SET tinhTrangBan = N'Trống' WHERE idBan = @idBan 
END
GO
select * from HoaDon