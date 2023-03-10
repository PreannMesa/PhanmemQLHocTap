CREATE DATABASE QUANLYHOCTAP
GO
USE  QUANLYHOCTAP
GO
DROP TABLE DMLOPHOC
CREATE TABLE NGUOIDUNG
(
	TAIKHOAN NVARCHAR(20) NOT NULL,
	MATKHAU NVARCHAR(20),
	PRIMARY KEY(TAIKHOAN)
)
CREATE TABLE DMLOPHOC
(
	MALOPHOC CHAR(10) NOT NULL,
	TENLOP NVARCHAR(50),
	PRIMARY KEY(MALOPHOC)
)
DROP TABLE HOIDONG
CREATE TABLE HOIDONG
(
	MAHOIDONG CHAR(10) NOT NULL,
	TENHOIDONG NVARCHAR(50),
	DIACHI NVARCHAR(50),
	TINHTHANHPHO NVARCHAR(50),
	PRIMARY KEY(MAHOIDONG)
)
DROP TABLE TUSI
CREATE TABLE TUSI
(
	IDTS CHAR(5) NOT NULL,
	TENTUSI NVARCHAR(50) NOT NULL,
	PHAI NVARCHAR(10),
	NGAYSINH DATE,
	MAHOIDONG CHAR(10),
	QUEQUAN NVARCHAR(50),
	MALOPHOC CHAR(10),
	PRIMARY KEY(IDTS),
	FOREIGN KEY(MAHOIDONG) REFERENCES HOIDONG(MAHOIDONG),
	FOREIGN KEY(MALOPHOC) REFERENCES DMLOPHOC(MALOPHOC)
)

CREATE TABLE MONHOC
(
	MAMONHOC CHAR(10) NOT NULL,
	TENMONHOC NVARCHAR(50),
	SOTIET INT,
	PRIMARY KEY(MAMONHOC)
)
DROP TABLE GIAOVIEN
CREATE TABLE GIAOVIEN
(
	MAGIAOVIEN CHAR(10) NOT NULL,
	TENGIAOVIEN NVARCHAR(50),
	PHAI NVARCHAR(10),
	NGAYSINH DATE,
	DIACHI NVARCHAR(50),
	SODT CHAR(20)
	PRIMARY KEY(MAGIAOVIEN)
)
DROP TABLE KHANANG
CREATE TABLE KHANANG
(
	MAKHANANG CHAR(10) NOT NULL,
	MAGIAOVIEN CHAR(10),
	MAMONHOC CHAR(10),
	PRIMARY KEY(MAKHANANG),
	FOREIGN KEY(MAGIAOVIEN) REFERENCES GIAOVIEN(MAGIAOVIEN),
	FOREIGN KEY(MAMONHOC) REFERENCES MONHOC(MAMONHOC)
)
DROP TABLE KHOAHOC
CREATE TABLE KHOAHOC
(
	MAKHOAHOC CHAR(5) NOT NULL,
	TENKHOA NVARCHAR(50) NOT NULL,
	NGAYBATDAU DATE NOT NULL,
	NGAYKETTHUC DATE NOT NULL,
	MAKHANANG CHAR(10) NOT NULL,
	MAMONHOC CHAR(10) NOT NULL,
	PRIMARY KEY(MAKHOAHOC),
	FOREIGN KEY(MAKHANANG) REFERENCES KHANANG(MAKHANANG),
	FOREIGN KEY(MAMONHOC) REFERENCES MONHOC(MAMONHOC)
)
DROP TABLE KETQUAHOCTAP
CREATE TABLE KETQUAHOCTAP
(
	IDTS CHAR(5) ,
	MAKHOAHOC CHAR(5),
	DIEMTHI INT,
	DIEMTIEULUAN INT,
	PRIMARY KEY(IDTS,MAKHOAHOC),
	FOREIGN KEY(IDTS) REFERENCES TUSI(IDTS),
	FOREIGN KEY(MAKHOAHOC) REFERENCES KHOAHOC(MAKHOAHOC),
)

INSERT INTO DMLOPHOC VALUES('LH001',N'LỚP A'),
							('LH002',N'LỚP B'),
							('LH003',N'LỚP C'),
							('LH004',N'LỚP D'),
							('LH005',N'LỚP E')

INSERT INTO HOIDONG VALUES('HD01',N'HỘI DÒNG A',N'123 Nguyễn Hữu Thọ',N'TPHCM'),
						  ('HD02',N'HỘI DÒNG B',N'12 Nguyễn Đình Chiểu',N'Đà Nẵng'),
						  ('HD03',N'HỘI DÒNG C',N'16 Linh Chiểu',N'Đà Nẵng'),
						  ('HD04',N'HỘI DÒNG D',N'19 Trần Hưng Đạo',N'Hải Phòng'),
						  ('HD05',N'HỘI DÒNG E',N'14 Hai Bà Trưng',N'Hà Nội')

SET DATEFORMAT DMY
INSERT INTO TUSI VALUES('TS001',N'Trần Kiều Loan',N'Nữ','27/08/1950','HD01',N'Hà Nội','LH001')
INSERT INTO TUSI VALUES('TS002',N'Trần Văn Nam',N'Nam','06/12/1975','HD02',N'HCM','LH002')
INSERT INTO TUSI VALUES('TS003',N'Nguyễn Thanh Huyền',N'Nữ','07/03/1978','HD03',N'Hà Nội','LH003')
INSERT INTO TUSI VALUES('TS004',N'Lê Tuyết Anh',N'Nữ','02/03/1977','HD04',N'HCM','LH004')
INSERT INTO TUSI VALUES('TS005',N'Nguyễn Anh Tú',N'Nam','07/04/1942','HD05',N'Đà Năng','LH005')
SELECT  IDTS FROM TUSI

INSERT INTO MONHOC VALUES('MH01',N'Phát triển game',30),
						 ('MH02',N'Phát triển ứng dụng di động',15),
						 ('MH03',N'Công nghệ phần mềm',25),
						 ('MH04',N'Lập trình Web và ứng dụng',30),
						 ('MH05',N'Bảo mật thông tin',15)

INSERT INTO GIAOVIEN VALUES('GV01',N'Lê Văn Hải',N'Nam','01/02/1976',N'123 Nguyễn Hữu Thọ','0788388565'),
							('GV02',N'Nguyễn Phương Minh',N'Nam','1/2/1980',N'12 Nguyễn Đình Chiểu','0788388565'),
							('GV03',N'Nguyễn Mạnh Hùng',N'Nam','16/08/1980',N'12 Nguyễn Đình Chiểu','0921964295'),
							('GV04',N'Phạm Thanh Sơn',N'Nam','20/08/1984',N'12 Nguyễn Đình Chiểu','0877512319'),
							('GV05',N'Vũ Thị Hoài',N'Nữ','05/12/1980',N'14 Hai Bà Trưng','0825701316')

INSERT INTO KHANANG VALUES('KN01','GV01','MH01'),
						  ('KN02','GV02','MH02'),
						  ('KN03','GV03','MH03'),
						  ('KN04','GV04','MH04'),
						  ('KN05','GV05','MH05')

INSERT INTO KHOAHOC VALUES('KH01','CNTT','28/09/2022','12/12/2022','KN01','MH01'),
						  ('KH02','QTKD','28/09/2022','12/12/2022','KN02','MH02'),
						  ('KH03','KTT','28/09/2022','12/12/2022','KN03','MH03'),
						  ('KH04','KCTC','28/09/2022','12/12/2022','KN04','MH04'),
						  ('KH05','ĐĐT','28/09/2022','12/12/2022','KN05','MH05')

INSERT INTO KETQUAHOCTAP VALUES('TS001','KH01',8,7),
							   ('TS002','KH02',8,9),
							   ('TS003','KH03',6,7),
							   ('TS004','KH04',8,9),
							   ('TS005','KH05',6,7)
INSERT INTO NGUOIDUNG VALUES('admin','1234')
SELECT * FROM DMLOPHOC
SELECT * FROM HOIDONG
SELECT * FROM TUSI 
SELECT * FROM MONHOC
SELECT * FROM GIAOVIEN
SELECT * FROM KHANANG
SELECT * FROM KHOAHOC
SELECT * FROM KETQUAHOCTAP


--HÀM TẠO MÃ SỐ TỰ ĐÔNG ĐỂ THÊM DỮ LIỆU VÀO BẢNG TU SĨ
DROP FUNCTION AUTO_IDTS
/*CREATE FUNCTION AUTO_IDTS()
RETURNS VARCHAR(5)
AS
BEGIN
	DECLARE @ID VARCHAR(5)
	IF (SELECT COUNT(IDTS) FROM TUSI) = 0
		SET @ID = '0'
	ELSE
		SELECT @ID = MAX(RIGHT(IDTS, 3)) FROM TUSI
		SELECT @ID = CASE
			WHEN @ID >= 0 and @ID < 9 THEN 'TS00' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
			WHEN @ID >= 9 THEN 'TS0' + CONVERT(CHAR, CONVERT(INT, @ID) + 1)
		END
	RETURN @ID
END*/
--TAO TRIGGER KIEM TRA KHOA CHINH KHOA NGOAI CAC MIEN GIA TRI
/*CREATE TRIGGER KIEMTRA 
ON TUSI
INSTEAD OF INSERT
AS
	BEGIN
			DECLARE @IDTS CHAR(5)
			DECLARE @TENTUSI NVARCHAR(50)
			DECLARE @PHAI NVARCHAR(10)
			DECLARE @NGAYSINH DATE
			DECLARE @MAHOIDONG CHAR(10)
			DECLARE @QUEQUAN NVARCHAR(50)
			DECLARE @MALOP CHAR(10)
			SELECT @IDTS = INSERTED.IDTS  FROM INSERTED
			SELECT @TENTUSI = INSERTED.TENTUSI  FROM INSERTED
			SELECT @PHAI = INSERTED.PHAI  FROM INSERTED
			SELECT @NGAYSINH =INSERTED.NGAYSINH  FROM INSERTED
			SELECT @MAHOIDONG=INSERTED.MAHOIDONG FROM INSERTED
			SELECT @QUEQUAN=INSERTED.QUEQUAN FROM INSERTED
			SELECT @MALOP=INSERTED.MALOP FROM INSERTED

	IF (EXISTS(SELECT * FROM  TUSI  WHERE TUSI.IDTS= @IDTS))
	BEGIN
			PRINT N'Khóa chính tồn tại'
			ROLLBACK TRAN
	END
	ELSE IF (EXISTS(SELECT * FROM  TUSI WHERE MALOP = @MALOP))
	BEGIN
			PRINT N'Khóa ngoại đã tồn tại -> Vui lòng nhập khác!'
			ROLLBACK TRAN
	END
	ELSE
	BEGIN
			SELECT * FROM INSERTED
			INSERT INTO TUSI VALUES(@IDTS, @TENTUSI,@PHAI,@NGAYSINH,@MAHOIDONG,@QUEQUAN,@MALOP)
	END
END
--THUC THI
SET DATEFORMAT DMY
INSERT INTO TUSI VALUES('TS001',N'LORN LADIN',N'Nam','14/02/2002','HD06',N'SIEM REAP','LH005')
INSERT INTO TUSI VALUES('TS006',N'LORN LADIN',N'Nam','14/02/2002','HD06',N'SIEM REAP','LH005')
SELECT * FROM TUSI
*/