﻿USE [master]
GO
/****** Object:  Database [Trung_Tam_Anh_Ngu_A_Z]    Script Date: 6/2/2015 8:55:34 PM ******/
CREATE DATABASE [Trung_Tam_Anh_Ngu_A_Z]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Trung_Tam_Anh_Ngu_A_Z', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup\Trung_Tam_Anh_Ngu_A_Z.mdf' , SIZE = 2944KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Trung_Tam_Anh_Ngu_A_Z_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup\Trung_Tam_Anh_Ngu_A_Z_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Trung_Tam_Anh_Ngu_A_Z].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET ARITHABORT OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET  MULTI_USER 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Trung_Tam_Anh_Ngu_A_Z', N'ON'
GO
USE [Trung_Tam_Anh_Ngu_A_Z]
GO
/****** Object:  Table [dbo].[BangDiem]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangDiem](
	[STT_HV] [int] NOT NULL,
	[STT_Lop] [int] NOT NULL,
	[STT_KhoaHoc] [int] NOT NULL,
	[Diem] [int] NULL,
 CONSTRAINT [PK_BangDiem] PRIMARY KEY CLUSTERED 
(
	[STT_HV] ASC,
	[STT_Lop] ASC,
	[STT_KhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Chung_Chi]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Chung_Chi](
	[MaChungChi] [varchar](10) NOT NULL,
	[TenChungChi] [nvarchar](50) NULL,
	[MaHV] [varchar](10) NULL,
	[MaKiThi] [varchar](10) NULL,
 CONSTRAINT [PK_Chung_Chi] PRIMARY KEY CLUSTERED 
(
	[MaChungChi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Doi_Khai_Giang]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Doi_Khai_Giang](
	[STT_DoiHoc] [int] IDENTITY(1,1) NOT NULL,
	[STT_NienKhoa] [int] NULL,
	[MaDoiHoc] [varchar](50) NULL,
	[TenDoiHoc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Doi_Khai_Giang] PRIMARY KEY CLUSTERED 
(
	[STT_DoiHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Giang_Vien]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Giang_Vien](
	[STT_GV] [int] IDENTITY(1,1) NOT NULL,
	[MaGV] [varchar](10) NULL,
	[TenGV] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[NgaySinh] [date] NULL,
	[SDT] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[MaTD] [int] NULL,
 CONSTRAINT [PK_Giang_Vien_1] PRIMARY KEY CLUSTERED 
(
	[STT_GV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hoc_Vien]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hoc_Vien](
	[STT_HV] [int] IDENTITY(1,1) NOT NULL,
	[MaHV] [varchar](30) NULL,
	[HoTen] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](3) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SDT] [char](11) NULL,
	[STT_Lop] [int] NULL,
	[STT_KhoaHoc] [int] NULL,
 CONSTRAINT [PK_Hoc_Vien] PRIMARY KEY CLUSTERED 
(
	[STT_HV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Khoa_Hoc]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Khoa_Hoc](
	[STT_KhoaHoc] [int] IDENTITY(1,1) NOT NULL,
	[MaKhoaHoc] [varchar](10) NULL,
	[TenKhoaHoc] [nvarchar](50) NULL,
 CONSTRAINT [PK_Khoa_Hoc_1] PRIMARY KEY CLUSTERED 
(
	[STT_KhoaHoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Ky_Thi]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Ky_Thi](
	[MaKiThi] [varchar](10) NOT NULL,
	[TenKiThi] [nvarchar](50) NULL,
 CONSTRAINT [PK_Ky_Thi] PRIMARY KEY CLUSTERED 
(
	[MaKiThi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Nien_Khoa]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Nien_Khoa](
	[STT_NienKhoa] [int] IDENTITY(1,1) NOT NULL,
	[MaNienKhoa] [varchar](50) NULL,
	[TenNienKhoa] [nvarchar](50) NULL,
 CONSTRAINT [PK_Nien_Khoa_1] PRIMARY KEY CLUSTERED 
(
	[STT_NienKhoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ThongTinLop]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ThongTinLop](
	[STT_Lop] [int] IDENTITY(1,1) NOT NULL,
	[MaLop] [varchar](50) NULL,
	[TenLop] [nvarchar](50) NULL,
	[NBT] [date] NULL,
	[NKT] [date] NULL,
	[SS] [int] NULL,
	[SBD] [int] NULL,
	[STT_GV] [int] NULL,
	[STT_KhoaHoc] [int] NULL,
	[STT_DoiHoc] [int] NULL,
	[STT_NienKhoa] [int] NULL,
 CONSTRAINT [PK_ThongTinLop] PRIMARY KEY CLUSTERED 
(
	[STT_Lop] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TrinhDo]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TrinhDo](
	[MaTD] [int] NOT NULL,
	[TrinhDo] [nvarchar](50) NULL,
 CONSTRAINT [PK_TrinhDo] PRIMARY KEY CLUSTERED 
(
	[MaTD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[View_ThongTinHocVien]    Script Date: 6/2/2015 8:55:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[View_ThongTinHocVien]
AS
	select h.MaHV,h.HoTen,h.GioiTinh,h.NgaySinh,h.DiaChi,h.SDT,t.TenLop,k.TenKhoaHoc,t.NBT,t.NKT,g.TenGV
	from ((((Hoc_Vien h inner join ThongTinLop t
			on h.STT_Lop=t.STT_Lop) inner join Khoa_Hoc k
			on k.STT_KhoaHoc=h.STT_KhoaHoc) inner join Giang_Vien g
			on g.STT_GV=t.STT_GV) inner join Doi_Khai_Giang d
			on d.STT_DoiHoc=t.STT_DoiHoc) inner join Nien_Khoa n
			on n.STT_NienKhoa=t.STT_NienKhoa
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BD_HV] FOREIGN KEY([STT_HV])
REFERENCES [dbo].[Hoc_Vien] ([STT_HV])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BD_HV]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BD_KH] FOREIGN KEY([STT_KhoaHoc])
REFERENCES [dbo].[Khoa_Hoc] ([STT_KhoaHoc])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BD_KH]
GO
ALTER TABLE [dbo].[BangDiem]  WITH CHECK ADD  CONSTRAINT [FK_BD_TTL] FOREIGN KEY([STT_Lop])
REFERENCES [dbo].[ThongTinLop] ([STT_Lop])
GO
ALTER TABLE [dbo].[BangDiem] CHECK CONSTRAINT [FK_BD_TTL]
GO
ALTER TABLE [dbo].[Doi_Khai_Giang]  WITH CHECK ADD  CONSTRAINT [FK_Doi_Khai_Giang_Nien_Khoa] FOREIGN KEY([STT_NienKhoa])
REFERENCES [dbo].[Nien_Khoa] ([STT_NienKhoa])
GO
ALTER TABLE [dbo].[Doi_Khai_Giang] CHECK CONSTRAINT [FK_Doi_Khai_Giang_Nien_Khoa]
GO
ALTER TABLE [dbo].[Giang_Vien]  WITH CHECK ADD  CONSTRAINT [FK_GV_TD] FOREIGN KEY([MaTD])
REFERENCES [dbo].[TrinhDo] ([MaTD])
GO
ALTER TABLE [dbo].[Giang_Vien] CHECK CONSTRAINT [FK_GV_TD]
GO
ALTER TABLE [dbo].[Hoc_Vien]  WITH CHECK ADD  CONSTRAINT [FK_HV_KH] FOREIGN KEY([STT_KhoaHoc])
REFERENCES [dbo].[Khoa_Hoc] ([STT_KhoaHoc])
GO
ALTER TABLE [dbo].[Hoc_Vien] CHECK CONSTRAINT [FK_HV_KH]
GO
ALTER TABLE [dbo].[Hoc_Vien]  WITH CHECK ADD  CONSTRAINT [FK_HV_TTL] FOREIGN KEY([STT_Lop])
REFERENCES [dbo].[ThongTinLop] ([STT_Lop])
GO
ALTER TABLE [dbo].[Hoc_Vien] CHECK CONSTRAINT [FK_HV_TTL]
GO
ALTER TABLE [dbo].[ThongTinLop]  WITH CHECK ADD  CONSTRAINT [FK_ThongTinLop_Nien_Khoa] FOREIGN KEY([STT_NienKhoa])
REFERENCES [dbo].[Nien_Khoa] ([STT_NienKhoa])
GO
ALTER TABLE [dbo].[ThongTinLop] CHECK CONSTRAINT [FK_ThongTinLop_Nien_Khoa]
GO
ALTER TABLE [dbo].[ThongTinLop]  WITH CHECK ADD  CONSTRAINT [FK_TTL_DKG] FOREIGN KEY([STT_DoiHoc])
REFERENCES [dbo].[Doi_Khai_Giang] ([STT_DoiHoc])
GO
ALTER TABLE [dbo].[ThongTinLop] CHECK CONSTRAINT [FK_TTL_DKG]
GO
ALTER TABLE [dbo].[ThongTinLop]  WITH CHECK ADD  CONSTRAINT [FK_TTL_GV] FOREIGN KEY([STT_GV])
REFERENCES [dbo].[Giang_Vien] ([STT_GV])
GO
ALTER TABLE [dbo].[ThongTinLop] CHECK CONSTRAINT [FK_TTL_GV]
GO
ALTER TABLE [dbo].[ThongTinLop]  WITH CHECK ADD  CONSTRAINT [FK_TTL_KH] FOREIGN KEY([STT_KhoaHoc])
REFERENCES [dbo].[Khoa_Hoc] ([STT_KhoaHoc])
GO
ALTER TABLE [dbo].[ThongTinLop] CHECK CONSTRAINT [FK_TTL_KH]
GO
USE [master]
GO
ALTER DATABASE [Trung_Tam_Anh_Ngu_A_Z] SET  READ_WRITE 
GO
