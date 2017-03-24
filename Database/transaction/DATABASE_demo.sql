create database DEMO_DeadLock
use DEMO_DeadLock
create table Lop
(
	MaLop int,
	TenLop varchar(20),
	HocPhi money
)
INSERT INTO Lop(MaLop,TenLop,HOCPHI)
VALUES (1,'GIAO TIEP',20000)
INSERT INTO Lop(MaLop, TenLop, HOCPHI)
VALUES(2,'TOEIC',30000)