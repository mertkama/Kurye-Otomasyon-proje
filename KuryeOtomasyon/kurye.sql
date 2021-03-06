USE [master]
GO
/****** Object:  Database [KuryeOtomasyon]    Script Date: 23.01.2022 12:39:57 ******/
CREATE DATABASE [KuryeOtomasyon]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'KuryeOtomasyon', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KuryeOtomasyon.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'KuryeOtomasyon_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\KuryeOtomasyon_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [KuryeOtomasyon] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KuryeOtomasyon].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KuryeOtomasyon] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET ARITHABORT OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KuryeOtomasyon] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KuryeOtomasyon] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KuryeOtomasyon] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KuryeOtomasyon] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET RECOVERY FULL 
GO
ALTER DATABASE [KuryeOtomasyon] SET  MULTI_USER 
GO
ALTER DATABASE [KuryeOtomasyon] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KuryeOtomasyon] SET DB_CHAINING OFF 
GO
ALTER DATABASE [KuryeOtomasyon] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [KuryeOtomasyon] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [KuryeOtomasyon] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [KuryeOtomasyon] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'KuryeOtomasyon', N'ON'
GO
ALTER DATABASE [KuryeOtomasyon] SET QUERY_STORE = OFF
GO
USE [KuryeOtomasyon]
GO
/****** Object:  Table [dbo].[Gonderi]    Script Date: 23.01.2022 12:39:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gonderi](
	[GonderiId] [int] IDENTITY(1,1) NOT NULL,
	[SiparisId] [int] NOT NULL,
	[KuryeId] [int] NULL,
	[YuklenmeTarihi] [datetime] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
	[Durum] [int] NULL,
 CONSTRAINT [PK_Gonderi] PRIMARY KEY CLUSTERED 
(
	[GonderiId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 23.01.2022 12:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[KullaniciId] [int] IDENTITY(1,1) NOT NULL,
	[KullaniciAdi] [nvarchar](100) NULL,
	[Sifre] [nvarchar](100) NULL,
	[YuklenmeTarihi] [datetime] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[KullaniciId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kurye]    Script Date: 23.01.2022 12:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kurye](
	[KuryeId] [int] IDENTITY(1,1) NOT NULL,
	[KuryeAd] [nvarchar](100) NULL,
	[KuryeSoyad] [nvarchar](100) NULL,
	[DogumTarihi] [datetime] NULL,
	[EhliyetTarihi] [datetime] NULL,
	[YuklenmeTarihi] [datetime] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
 CONSTRAINT [PK_Kurye] PRIMARY KEY CLUSTERED 
(
	[KuryeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Musteri]    Script Date: 23.01.2022 12:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Musteri](
	[MusteriId] [int] IDENTITY(1,1) NOT NULL,
	[MusteriAd] [nvarchar](100) NULL,
	[MusteriSoyad] [nvarchar](100) NULL,
	[Adres] [nvarchar](max) NULL,
	[Telefon] [nvarchar](10) NULL,
	[OzelMusteri] [bit] NULL,
	[YuklenmeTarihi] [datetime] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
 CONSTRAINT [PK_Musteri] PRIMARY KEY CLUSTERED 
(
	[MusteriId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Siparis]    Script Date: 23.01.2022 12:39:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Siparis](
	[SiparisId] [int] IDENTITY(1,1) NOT NULL,
	[PaketAciklama] [nvarchar](max) NULL,
	[Agirlik] [decimal](18, 2) NULL,
	[Fiyat] [decimal](18, 2) NULL,
	[GonderiAdresi] [nvarchar](max) NULL,
	[MusteriId] [int] NULL,
	[SiparisDurumu] [int] NULL,
	[YuklenmeTarihi] [datetime] NULL,
	[GuncellenmeTarihi] [datetime] NULL,
 CONSTRAINT [PK_Siparis] PRIMARY KEY CLUSTERED 
(
	[SiparisId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Gonderi] ON 

INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (1, 1, 1, CAST(N'2022-09-01T00:00:00.000' AS DateTime), CAST(N'2022-09-01T00:00:00.000' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (2, 1, 1, CAST(N'2022-01-23T11:20:21.767' AS DateTime), CAST(N'2022-01-23T11:20:21.767' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (3, 5, 1, CAST(N'2022-01-23T12:23:38.650' AS DateTime), CAST(N'2022-01-23T12:23:38.650' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (4, 6, 3, CAST(N'2022-01-23T12:23:48.603' AS DateTime), CAST(N'2022-01-23T12:23:48.603' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (5, 7, 4, CAST(N'2022-01-23T12:23:54.387' AS DateTime), CAST(N'2022-01-23T12:23:54.387' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (6, 8, 1, CAST(N'2022-01-23T12:33:52.900' AS DateTime), CAST(N'2022-01-23T12:33:52.900' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (7, 9, 3, CAST(N'2022-01-23T12:34:08.700' AS DateTime), CAST(N'2022-01-23T12:34:08.700' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (8, 10, 4, CAST(N'2022-01-23T12:34:27.477' AS DateTime), CAST(N'2022-01-23T12:34:27.477' AS DateTime), 0)
INSERT [dbo].[Gonderi] ([GonderiId], [SiparisId], [KuryeId], [YuklenmeTarihi], [GuncellenmeTarihi], [Durum]) VALUES (9, 11, 0, CAST(N'2022-01-23T12:34:31.690' AS DateTime), CAST(N'2022-01-23T12:34:31.690' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Gonderi] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanici] ON 

INSERT [dbo].[Kullanici] ([KullaniciId], [KullaniciAdi], [Sifre], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (1, N'1', N'1', CAST(N'2021-01-09T00:00:00.000' AS DateTime), CAST(N'2021-01-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Kullanici] OFF
GO
SET IDENTITY_INSERT [dbo].[Kurye] ON 

INSERT [dbo].[Kurye] ([KuryeId], [KuryeAd], [KuryeSoyad], [DogumTarihi], [EhliyetTarihi], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (1, N'Ahmet', N'Ahmets', CAST(N'1990-05-06T00:00:00.000' AS DateTime), CAST(N'2015-07-07T00:00:00.000' AS DateTime), CAST(N'2021-09-01T00:00:00.000' AS DateTime), CAST(N'2021-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Kurye] ([KuryeId], [KuryeAd], [KuryeSoyad], [DogumTarihi], [EhliyetTarihi], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (3, N'Ali', N'Alis', CAST(N'2022-01-23T12:21:08.893' AS DateTime), CAST(N'2022-01-23T12:21:08.893' AS DateTime), CAST(N'2022-01-23T12:21:39.320' AS DateTime), CAST(N'2022-01-23T12:21:37.017' AS DateTime))
INSERT [dbo].[Kurye] ([KuryeId], [KuryeAd], [KuryeSoyad], [DogumTarihi], [EhliyetTarihi], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (4, N'Mehmet', N'Mehmets', CAST(N'2022-01-23T12:21:42.440' AS DateTime), CAST(N'2022-01-23T12:21:42.440' AS DateTime), CAST(N'2022-01-23T12:21:51.623' AS DateTime), CAST(N'2022-01-23T12:21:51.623' AS DateTime))
SET IDENTITY_INSERT [dbo].[Kurye] OFF
GO
SET IDENTITY_INSERT [dbo].[Musteri] ON 

INSERT [dbo].[Musteri] ([MusteriId], [MusteriAd], [MusteriSoyad], [Adres], [Telefon], [OzelMusteri], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (1, N'Ali', N'Alis', N'istanbul', N'11111111', 1, CAST(N'2022-09-01T00:00:00.000' AS DateTime), CAST(N'2022-09-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Musteri] ([MusteriId], [MusteriAd], [MusteriSoyad], [Adres], [Telefon], [OzelMusteri], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (2, N'Ayşe', N'Ayses', N'Ankara', N'222222222', 0, CAST(N'2022-09-01T00:00:00.000' AS DateTime), CAST(N'2022-09-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Musteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Siparis] ON 

INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (1, N'test', CAST(10.00 AS Decimal(18, 2)), CAST(100.00 AS Decimal(18, 2)), N'istanbul', 1, 1, CAST(N'2022-09-01T00:00:00.000' AS DateTime), CAST(N'2022-01-23T11:20:21.763' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (3, N'test', CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'istanbul', 2, 1, CAST(N'2022-01-23T11:06:06.330' AS DateTime), CAST(N'2022-01-23T11:06:06.330' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (4, N'test', CAST(10.00 AS Decimal(18, 2)), CAST(10.00 AS Decimal(18, 2)), N'istanbul', 1, 1, CAST(N'2022-01-23T11:20:10.347' AS DateTime), CAST(N'2022-01-23T11:20:10.347' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (5, N'test', CAST(1.00 AS Decimal(18, 2)), CAST(1.00 AS Decimal(18, 2)), N'test', 2, 1, CAST(N'2022-01-23T12:22:28.027' AS DateTime), CAST(N'2022-01-23T12:23:38.650' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (6, N'test', CAST(12.00 AS Decimal(18, 2)), CAST(12.00 AS Decimal(18, 2)), N'test', 1, 1, CAST(N'2022-01-23T12:22:44.850' AS DateTime), CAST(N'2022-01-23T12:23:48.603' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (7, N'test', CAST(235.00 AS Decimal(18, 2)), CAST(235.00 AS Decimal(18, 2)), N'test', 1, 1, CAST(N'2022-01-23T12:22:52.547' AS DateTime), CAST(N'2022-01-23T12:23:54.387' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (8, N'1', CAST(11.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), N'1', 1, 1, CAST(N'2022-01-23T12:33:42.587' AS DateTime), CAST(N'2022-01-23T12:33:52.900' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (9, N'12', CAST(112.00 AS Decimal(18, 2)), CAST(112.00 AS Decimal(18, 2)), N'1', 2, 1, CAST(N'2022-01-23T12:34:02.163' AS DateTime), CAST(N'2022-01-23T12:34:08.697' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (10, N'122', CAST(1122.00 AS Decimal(18, 2)), CAST(1122.00 AS Decimal(18, 2)), N'12', 2, 1, CAST(N'2022-01-23T12:34:15.530' AS DateTime), CAST(N'2022-01-23T12:34:27.473' AS DateTime))
INSERT [dbo].[Siparis] ([SiparisId], [PaketAciklama], [Agirlik], [Fiyat], [GonderiAdresi], [MusteriId], [SiparisDurumu], [YuklenmeTarihi], [GuncellenmeTarihi]) VALUES (11, N'122', CAST(1122.00 AS Decimal(18, 2)), CAST(1122.00 AS Decimal(18, 2)), N'12', 1, 1, CAST(N'2022-01-23T12:34:19.267' AS DateTime), CAST(N'2022-01-23T12:34:31.690' AS DateTime))
SET IDENTITY_INSERT [dbo].[Siparis] OFF
GO
USE [master]
GO
ALTER DATABASE [KuryeOtomasyon] SET  READ_WRITE 
GO
