create database QLyQuanCaPhe2
go
use QLyQuanCaPhe2

create table NhanVien(
	idNV int identity primary key,
	tenNV nvarchar(30) not null,
	tenDangnhap  nvarchar(50),
	gioiTinh nvarchar(5),
	namSinh int, 
	chucVu nvarchar(30),
	luong float,
	matKhau varchar(50),
	hinh image 
)
go

create table Ban(
	idBan int identity primary key,
	tenBan nvarchar(100) not null,
	loai nvarchar(100),
	tinhTrangBan nvarchar(100)not null default N'Trống'--kiểm tra có người hay chưa
)
go
create table DonHang(
   idDH int identity primary key,
   ngayDatHang date,
)
create table HoaDon(
	idHD int identity primary key,
	idBan int,
	idNV int,
	idDH int,
	ngayVao date not null,
	ngayRa date not null,
	ghiChu int default 0, --thanh toán 1 hay chưa 0
	giamGia int default 0,
	tongTien float,
	foreign key (idBan) references Ban(idBan),
	foreign key (idNV) references NhanVien(idNV),
	foreign key (idDH) references DonHang(idDH),
)
go


create table LoaiSanPham(
 id int identity primary key,
 tenLoaiSanPham nvarchar(100) not null
)
go
select * from  LoaiSanPham
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




insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  (
          N'Nguyễn Kim Ngân' , 
		  N'Quanly',
          N'Nữ' , 
		  '2003',
		  N'Quản lý',
		  9000000,
          '123456789'
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  ( 
          N'Nguyễn Huỳnh Bảo An' , 
		  null,
          N'Nữ' , 
		  '2001',
		  N'Thu ngân',
		  9000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  (
          N' Lê Thanh Ngân ' , 
		  null,
          N'Nữ' , 
		  '2001',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  (
          N'Trương Mỹ Vy' , 
		  null,
          N'Nữ' , 
		  '2001',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  (
          N'Phạm Văn Mạnh' , 
		  null,
          N'Nam' , 
		  '2002',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  ( 
          N'Nguyễn Gia Huy' , 
		  null,
          N'Nam' , 
		  '2003',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  ( 
          N'Trần Thanh Hiền' , 
		  null,
          N'Nam' , 
		  '2001',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  (
          N'Nguyễn Trung Tín' , 
		  null,
          N'Nam' , 
		  '2004',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
insert into NhanVien (tenNV, tenDangnhap , gioiTinh, namSinh, chucVu, luong, matKhau)
VALUES  ( 
          N'Trần Ngọc Hoài Sang' , 
		  null,
          N'Nam' , 
		  '2005',
		  N'Phục vụ',
		  8000000,
          null 
        )
go
update NhanVien set  tenNV = N'Nhu', gioiTinh = N'nữ', chucVu = N'phục vụ', namSinh = '2003' , luong  where idNV = {5}
SELECT idNV, tenNV, gioiTinh, namSinh, chucVu, luong, matKhau FROM NhanVien
Select Round(luong, 8) as luong  from NhanVien
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

WHILE @ban <= 50 
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
insert LoaiSanPham(tenLoaiSanPham) values (N'Nước ngọt')
insert LoaiSanPham(tenLoaiSanPham) values (N'Bánh kẹo')
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
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (2,1,2)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (2,2,5)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (2,3,1)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (4,4,6)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (4,5,5)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (4,6,5)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (3,7,8)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (3,8,2)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (5,9,2)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (6,10,2)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (7,11,2)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (8,12,4)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (8,13,2)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (8,14,6)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (8,15,4)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (10,15,4)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (1,15,4)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (9,7,3)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (10,5,4)
--insert  ChiTietHoaDon(idHD,id, soLuong)
--values (13,8,1)

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

-- xóa hóa đơn 
--CREATE PROCEDURE deleteHoaDon
--@idHoaDon int
--AS
--BEGIN
--    DELETE FROM HoaDon WHERE idHoaDon = @idHoaDon
--END

-- xóa hóa đơn
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
--delete ChiTietHoaDon
--delete HoaDon
create  trigger CapnhatCTHD
on ChiTietHoaDon for insert, update
as
begin

	declare @idHD int 
	select @idHD = idHD from Inserted
	
	declare @idBan int
	SELECT @idBan = idBan from HoaDon where idHD = @idHD and ghiChu = 0

	declare @soLuong int
	SELECT soLuong = count(*) from ChiTietHoaDon where idHD =@idHD


	if (@soLuong > 0)
	begin 
	    print @idBan 
		print @idHD
		print @soLuong 

		update Ban set tinhTrangBan = N'Có người' where  idBan = @idBan 
	end
	else 
	begin 
	    print @idBan 
		print @idHD
		print @soLuong 
		update Ban set tinhTrangBan = N'Có người' where  idBan = @idBan
	end
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





--create trigger CapnhatBan
--on Ban for update
--as
--begin
--   declare @idBan int
--	declare @tinhTrangBan  nvarchar(100)

--	select @idBan = idBan, @tinhTrangBan = Inserted.tinhTrangBan from Inserted

--	declare @idHD int 
--	select @idHD = idHD from HoaDon where idBan = @idBan and ghiChu = 0
	
	
--	declare @demCTHD INT
--	SELECT count(*) from ChiTietHoaDon where idHD =@idHD

--	if (@demCTHD>0 and @tinhTrangBan <> N'Có người')
--		update Ban set tinhTrangBan = N'Có người' where  idBan = @idBan 
--	else if (@demCTHD <= 0 and @tinhTrangBan <> N'Trống')
--		update Ban set tinhTrangBan = N'Trống' where  idBan = @idBan
--end 
--go

create proc UPS_SwitchTabel
@idBan1 int , @idBan2 int
AS begin

	declare @idHD1 int 
	declare @idHD2 int 

	declare @Ban1tam1 int = 1
	declare @Ban2tam2 int = 1

	select @idHD2= idHD from HoaDon where idBan = @idBan2 and ghiChu = 0
	select @idHD1= idHD from HoaDon where idBan = @idBan1 and ghiChu = 0

	print @idHD1
	print @idHD2
	PRINT '-----------'

	if(@idHD1 is null)
	begin
	       print '0000001'
		  insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
		  values (getdate(), getdate() , @idBan1 , 0)
		  
		  select @idHD1=max(idHD) from HoaDon where idBan=@idBan1 and ghiChu = 0
		  
	end

	select @Ban1tam1 = count(*) from ChiTietHoaDon where idHD = @idHD1 

	print @idHD1
	print @idHD2
	PRINT '-----------'

	if(@idHD2 is null)
	begin
	      print '0000002'
		  insert HoaDon(ngayVao, ngayRa, idBan, ghiChu)
		  values (getdate(), getdate() , @idBan2 , 0)
		  
		  select @idHD2 = max(idHD) from HoaDon where idBan = @idBan2 and ghiChu = 0

	end

	select @Ban2tam2 = count(*) from ChiTietHoaDon where idHD = @idHD2 

	print @idHD1
	print @idHD2
	PRINT '-----------'

	select idCTHD into idHD from ChiTietHoaDon where idHD= @idHD2

	update ChiTietHoaDon set idHD = @idHD2 where idHD = @idHD1
	update Ban set tinhTrangBan = N'Trống' where idBan = @idBan1
	update Ban set tinhTrangBan = N'Có người' where idBan = @idBan2
	update ChiTietHoaDon set idHD = @idHD1 where idCTHD in(select *  from idHD)

	drop table idHD

	if (@Ban1tam1 = 0)
	    update Ban set tinhTrangBan = N'Trống' where idBan = @idBan2
	if (@Ban2tam2 = 0)
	    update Ban set tinhTrangBan = N'Trống' where idBan = @idBan1
end
go
--drop proc UPS_SwitchTabel


go
create trigger XoaChiTietHoaDon
on ChiTietHoaDon for delete 
as 
begin
	declare @idCTHD int 
	declare @idHD int 
	select @idCTHD = idCTHD, @idHD = Deleted.idHD from Deleted
	
	declare @idBan int 
	select @idBan = idBan from HoaDon where idHD = @idHD
	
	declare @soLuong int  = 0
	
	select @soLuong = COUNT(*) FROM ChiTietHoaDon as cthd, HoaDon as hd where hd.idHD = cthd.idHD AND hd.idHD = @idHD AND hd.ghiChu = 0
	
	if (@soLuong = 0)
		update Ban set tinhTrangBan = N'Trống' where idBan = @idBan
END
GO


update Ban set tinhTrangBan = N'Trống'

select * from SanPham  

Select tenNV as [Tên hiển thị], tenDangnhap as [Tên đăng nhập], matKhau as [Mật khẩu], chucVu as [Quyền] from NhanVien

update SanPham set tenSP= N' ', idloaiSP = 4, giaTien = 0, donViTinh = N'VNĐ' where id=4
insert SanPham(tenSP,idloaiSP,giaTien) 
values (N'Sinh tố lun', 4, 30000)
DELETE FROM Ban
WHERE idBan = 50
insert Ban(tenBan,tinhTrangBan)
values (N'Bàn 49', N'Trống')




go
-- lấy hd theo ngày 
create proc USP_GetListBillByDate
@ngayVao date, @ngayRa date
as
begin
	--select B.tenBan as [Tên bàn], ngayVao as [Ngày vào] , ngayRa as [Ngày ra], HD.tongTien as [Thành tiền] from HoaDon as HD, Ban as B, ChiTietHoaDon as CTHD, SanPham as SP
	--where ngayVao >= @ngayVao and ngayRa <= @ngayRa and HD.ghiChu=1
	--and B.idBan=HD.idBan and CTHD.idHD=HD.idHD and CTHD.id=SP.id
	select B.tenBan as [Tên bàn], ngayVao as [Ngày vào] , ngayRa as [Ngày ra], HD.tongTien as [Thành tiền] from HoaDon as HD,  Ban as B 
	where ngayVao >= @ngayVao and ngayRa <= @ngayRa and HD.ghiChu=1
	and B.idBan=HD.idBan
end
go
--lấy hd theo tháng 
	select B.tenBan as [Tên bàn], ngayVao as [Ngày vào] , ngayRa as [Ngày ra], HD.tongTien as [Thành tiền] from HoaDon as HD,  Ban as B 
	where ngayVao >= getdate() and ngayRa <= getdate() and HD.ghiChu=1
create PROCEDURE USP_GetListBillByMonth
@thang int
AS
BEGIN
    DECLARE @ngayVaoFrom date, @ngayVaoTo date

    SET @ngayVaoFrom = DATEFROMPARTS(YEAR(GETDATE()), @thang, 1) -- Ngày đầu tháng
    SET @ngayVaoTo = DATEADD(DAY, -1, DATEADD(MONTH, 1, @ngayVaoFrom)) -- Ngày cuối tháng

    SELECT B.tenBan as [Tên bàn], ngayVao as [Ngày vào], ngayRa as [Ngày ra], HD.tongTien as [Thành tiền]
    FROM HoaDon as HD
    JOIN Ban as B ON B.idBan = HD.idBan
    WHERE MONTH(ngayVao) = @thang AND HD.ghiChu = 1
END
-- lấy hdd theo năm 
create proc USP_GetListBillByNam
@nam int
as
begin
    select B.tenBan as [Tên bàn], ngayVao as [Ngày vào] , ngayRa as [Ngày ra], HD.tongTien as [Thành tiền] 
    from HoaDon as HD, Ban as B
    where year(ngayVao) = @nam and HD.ghiChu = 1 and B.idBan = HD.idBan
end
go



delete ChiTietHoaDon
delete HoaDon

select * from HoaDon
select * from ChiTietHoaDon
select * from SanPham 

	select B.tenBan as [Tên bàn], ngayVao as [Ngày vào] , ngayRa as [Ngày ra], HD.tongTien as [Thành tiền] from HoaDon as HD,  Ban as B 
	where ngayVao >= '20230511' and ngayRa <= '20230511' and HD.ghiChu=1
	and B.idBan=HD.idBan

-- report 
create proc USP_GetListBillByDateForReport
@ngayVao date, @ngayRa date
as
begin
	select B.tenBan , ngayVao , ngayRa , HD.tongTien  from HoaDon as HD, Ban as B, ChiTietHoaDon as CTHD, SanPham as SP
	where ngayVao >= @ngayVao and ngayRa <= @ngayRa and HD.ghiChu=1
	and B.idBan=HD.idBan and CTHD.idHD=HD.idHD and CTHD.id=SP.id
end
go
