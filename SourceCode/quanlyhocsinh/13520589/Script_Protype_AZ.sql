USE Trung_Tam_Anh_Ngu_A_Z

-----
--INSERT Trình Độ Giảng Viên

INSERT INTO TrinhDo(MaTD,TrinhDo)
VALUES (1,'Sinh Viên')
INSERT INTO TrinhDo(MATD,TrinhDo)
VALUES (2,'Cử nhân')
INSERT INTO TrinhDo(MATD,TrinhDo)
VALUES (3,'Thạc Sĩ')
INSERT INTO TrinhDo(MATD,TrinhDo)
VALUES (4,'Tiến Sĩ')
INSERT INTO TrinhDo(MATD,TrinhDo)
VALUES (5,'Giáo Sư')

--INSERT GiangVien

INSERT INTO Giang_Vien(STT_GV, MaGV,TenGV,DiaChi,GioiTinh,NgaySinh,SDT,Email,MaTD)
VALUES(1,'GV0001','PHUONG TAI','BINH THUAN','NAM','05/10/1995','0909090909','PHUONGTAI@GMAIL.COM',1)
 
--INSERT DOI_KHAI_GIANG
  
INSERT INTO Doi_Khai_Giang(STT_DoiHoc,STT_NienKhoa,MaDoiHoc,TenDoiHoc)
VALUES(1,1,'DOT001','Dot 1')

--INSERT NIÊN KHÓA
 
INSERT INTO Nien_Khoa(STT_NienKhoa,MaNienKhoa,TenNienKhoa)
VALUES(1,'Nam001','2014 2015')

--INSERT khóa học   
              
INSERT INTO Khoa_Hoc(STT_KhoaHoc,MaKhoaHoc,TenKhoaHoc)
      VALUES(1,'KH0001','Dịch Thuật')

--INSERT ThongTinLop
 
INSERT INTO ThongTinLop(STT_Lop,MaLop,TenLop,NBT,NKT,SS,SBD,STT_GV,STT_KhoaHoc,STT_DoiHoc,STT_NienKhoa)
VALUES(1,'Eng001','Trung Cấp','10/02/2015','06/03/2015',50,1,1,1,1,1)

--INSERT học viên
   
INSERT INTO Hoc_Vien(STT_HV,MaHV,HoTen,GioiTinh,NgaySinh,DiaChi,SDT,STT_Lop,STT_KhoaHoc)
                VALUES(1,'AZ0001','Phương Thảo','Nữ','08/31/1995','KTX Khu B','0912938923',1,1)

--INSERT Bảng điểm
  
INSERT INTO BangDiem(STT_HV,STT_Lop,STT_KhoaHoc,Diem)
VALUES (1,1,1,9)
INSERT INTO BangDiem(STT_HV,STT_LOP,STT_KhoaHoc,Diem)
VALUES (2,1,1,8)
