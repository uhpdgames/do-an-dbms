---------------------------------Kiểm tra tồn tại cơ sở dữ liệu Database Trung Tam Anh Ngu hay ko?-------------------------

select * from sys.tables where
exists (select * from sys.tables where name = 'Chung_Chi') 
and exists (select * from sys.tables where name = 'Doi_Khai_Giang') 
and exists (select * from sys.tables where name = 'Giang_Vien') 
and exists (select * from sys.tables where name = 'Hoc_Vien') 
and exists (select * from sys.tables where name = 'Khoa_Hoc') 
and exists (select * from sys.tables where name = 'Ky_Thi') 
and exists (select * from sys.tables where name = 'Nien_Khoa') 
and exists (select * from sys.tables where name = 'ThongTinLop') 
and exists (select * from sys.tables where name = 'TrinhDo')
and exists (select * from sys.tables where name = 'BangDiem')
