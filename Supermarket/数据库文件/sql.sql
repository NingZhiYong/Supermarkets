USE [master]
GO
/****** Object:  Database [Supermarket]    Script Date: 2020/5/6 13:09:51 ******/
CREATE DATABASE [Supermarket]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Supermarket', FILENAME = N'D:\新建文件夹 (2)\Supermarket.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Supermarket_log', FILENAME = N'D:\新建文件夹 (2)\Supermarket_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Supermarket] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Supermarket].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Supermarket] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Supermarket] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Supermarket] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Supermarket] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Supermarket] SET ARITHABORT OFF 
GO
ALTER DATABASE [Supermarket] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Supermarket] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Supermarket] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Supermarket] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Supermarket] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Supermarket] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Supermarket] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Supermarket] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Supermarket] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Supermarket] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Supermarket] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Supermarket] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Supermarket] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Supermarket] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Supermarket] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Supermarket] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Supermarket] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Supermarket] SET RECOVERY FULL 
GO
ALTER DATABASE [Supermarket] SET  MULTI_USER 
GO
ALTER DATABASE [Supermarket] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Supermarket] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Supermarket] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Supermarket] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Supermarket] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Supermarket', N'ON'
GO
USE [Supermarket]
GO
/****** Object:  Table [dbo].[T_Audit]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Audit](
	[AuditID] [int] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[AuditState] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_T_Audit] PRIMARY KEY CLUSTERED 
(
	[AuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Employee]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Passwd] [nvarchar](max) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Sex] [int] NOT NULL,
	[Telephone] [nvarchar](22) NOT NULL,
	[Photo] [nvarchar](13) NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_T_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Navigation]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Navigation](
	[NavigationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Url] [nvarchar](max) NOT NULL,
	[CodeID] [nvarchar](50) NOT NULL,
	[ParentID] [int] NOT NULL,
 CONSTRAINT [PK_T_Navigation] PRIMARY KEY CLUSTERED 
(
	[NavigationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Power]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Power](
	[PowerID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ParentID] [nvarchar](20) NULL,
 CONSTRAINT [PK_T_Power] PRIMARY KEY CLUSTERED 
(
	[PowerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Purchase]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Purchase](
	[PurID] [nvarchar](50) NOT NULL,
	[PurTime] [datetime] NOT NULL,
	[PurProID] [int] NOT NULL,
	[PurStart] [int] NOT NULL CONSTRAINT [DF_T_Purchase_PurStart]  DEFAULT ((0)),
 CONSTRAINT [PK_T_Purchase] PRIMARY KEY CLUSTERED 
(
	[PurID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_PurchaseDetailed]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_PurchaseDetailed](
	[PurDetailedID] [int] IDENTITY(1,1) NOT NULL,
	[PurCode] [nvarchar](50) NOT NULL,
	[ShopID] [int] NOT NULL,
	[PurStoreID] [int] NOT NULL,
	[PurNumber] [int] NOT NULL,
 CONSTRAINT [PK_T_PurchaseDetailed] PRIMARY KEY CLUSTERED 
(
	[PurDetailedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Return]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Return](
	[RtnID] [nvarchar](50) NOT NULL,
	[RtnTime] [datetime] NOT NULL,
	[RtnExplain] [nvarchar](200) NULL,
	[RtnAudit] [int] NOT NULL,
 CONSTRAINT [PK_T_Return] PRIMARY KEY CLUSTERED 
(
	[RtnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Role]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[RoleRemake] [nvarchar](50) NULL,
 CONSTRAINT [PK_T_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_RolePermissions]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_RolePermissions](
	[Role_permissionsID] [int] IDENTITY(1,1) NOT NULL,
	[PowerID] [nvarchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
 CONSTRAINT [PK_T_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Role_permissionsID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_SaleDetailed]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SaleDetailed](
	[SaleDetaileID] [int] IDENTITY(1,1) NOT NULL,
	[SaleCode] [nvarchar](50) NOT NULL,
	[ShopID] [int] NOT NULL,
	[SaleNumber] [int] NOT NULL,
 CONSTRAINT [PK_T_SaleDetailed] PRIMARY KEY CLUSTERED 
(
	[SaleDetaileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_SaleOrder]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SaleOrder](
	[SaleID] [nvarchar](50) NOT NULL,
	[SaleTime] [datetime] NOT NULL,
	[SaleEmp] [int] NOT NULL,
 CONSTRAINT [PK_T_SaleOrder] PRIMARY KEY CLUSTERED 
(
	[SaleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_SaleReturn]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_SaleReturn](
	[SaleRtnID] [int] IDENTITY(1,1) NOT NULL,
	[RtnCode] [nvarchar](50) NOT NULL,
	[ShopID] [int] NOT NULL,
	[RtnNumber] [int] NOT NULL,
 CONSTRAINT [PK_T_SaleReturn] PRIMARY KEY CLUSTERED 
(
	[SaleRtnID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Shop]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Shop](
	[ShopID] [int] IDENTITY(1,1) NOT NULL,
	[ShopCode] [nvarchar](13) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Images] [nvarchar](200) NULL,
	[SupplierID] [int] NOT NULL,
	[CostPrice] [money] NOT NULL,
	[SalePrice] [money] NOT NULL,
	[BothTime] [datetime] NULL,
	[ShelfLife] [int] NULL,
	[ShopTypeID] [int] NOT NULL,
	[Number] [int] NULL,
 CONSTRAINT [PK_T_Shop] PRIMARY KEY CLUSTERED 
(
	[ShopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_ShopType]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_ShopType](
	[TypeID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_T_ShopType] PRIMARY KEY CLUSTERED 
(
	[TypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Store]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_Store](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_T_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_StoreProduct]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[T_StoreProduct](
	[StoreProID] [int] IDENTITY(1,1) NOT NULL,
	[ShopID] [int] NOT NULL,
	[StoreID] [int] NOT NULL,
	[Count] [int] NOT NULL,
 CONSTRAINT [PK_T_StoreProduct] PRIMARY KEY CLUSTERED 
(
	[StoreProID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[T_Supplier]    Script Date: 2020/5/6 13:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[T_Supplier](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [nvarchar](20) NOT NULL,
	[LinkMan] [nvarchar](20) NOT NULL,
	[Mobile] [varchar](11) NOT NULL,
	[Address] [nvarchar](256) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_T_Supplier] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[T_Audit] ON 

INSERT [dbo].[T_Audit] ([AuditID], [AuditState]) VALUES (1, N'未审核')
INSERT [dbo].[T_Audit] ([AuditID], [AuditState]) VALUES (2, N'待审核')
INSERT [dbo].[T_Audit] ([AuditID], [AuditState]) VALUES (3, N'已审核')
SET IDENTITY_INSERT [dbo].[T_Audit] OFF
SET IDENTITY_INSERT [dbo].[T_Employee] ON 

INSERT [dbo].[T_Employee] ([EmployeeID], [Login], [Passwd], [Name], [Sex], [Telephone], [Photo], [RoleID]) VALUES (1, N'admin', N'admin', N'店长', 1, N'13388888888', NULL, 1)
INSERT [dbo].[T_Employee] ([EmployeeID], [Login], [Passwd], [Name], [Sex], [Telephone], [Photo], [RoleID]) VALUES (3, N'caigou', N'admin', N'张三', 2, N'156999921313', NULL, 2)
SET IDENTITY_INSERT [dbo].[T_Employee] OFF
SET IDENTITY_INSERT [dbo].[T_Navigation] ON 

INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (2, N'系统管理', N'javascript:;', N'Sys_001', 0)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (3, N'用户管理', N'Employee/EmployeeManager.html', N'Sys_001_01', 2)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (4, N'角色管理', N'', N'Sys_001_02', 2)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (5, N'权限管理', N'', N'Sys_001_03', 2)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (6, N'库存管理', N'javascript:;', N'Sys_002', 0)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (7, N'仓库管理', N'Store/storeManager.html', N'Sys_002_01', 6)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (9, N'采购入库', N'Purchase/CGRKManager.html', N'Sys_002_02', 6)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (10, N'库存盘点', N'', N'Sys_002_03', 6)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (11, N'库存调拨', N'Allot/AllotManager.html', N'Sys_002_04', 6)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (12, N'采购管理', N'javascript:;', N'Sys_003', 0)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (13, N'商品管理', N'Shop/shop.html', N'Sys_003_01', 12)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (14, N'供应商管理', N'Supplier/supplier.html', N'Sys_003_02', 12)
INSERT [dbo].[T_Navigation] ([NavigationID], [Name], [Url], [CodeID], [ParentID]) VALUES (15, N'采购订单管理', N'Purchase/PurchaseManager.html', N'Sys_003_03', 12)
SET IDENTITY_INSERT [dbo].[T_Navigation] OFF
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_001', N'系统管理', NULL)
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_001_01', N'用户管理', N'Sys_001')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_001_02', N'角色管理', N'Sys_001')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_001_03', N'权限管理', N'Sys_001')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_002', N'库存管理', NULL)
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_002_01', N'仓库管理', N'Sys_002')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_002_02', N'采购入库', N'Sys_002')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_002_03', N'库存盘点', N'Sys_002')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_002_04', N'库存调拨', N'Sys_002')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_003', N'采购管理', NULL)
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_003_01', N'商品管理', N'Sys_003')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_003_02', N'供应商管理', N'Sys_003')
INSERT [dbo].[T_Power] ([PowerID], [Name], [ParentID]) VALUES (N'Sys_003_03', N'采购订单管理', N'Sys_003')
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004211455369413', CAST(N'2020-04-21 14:56:15.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004271055363121', CAST(N'2020-04-27 10:55:35.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004271059325312', CAST(N'2020-04-27 10:59:32.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004271433235579', CAST(N'2020-04-27 14:33:46.000' AS DateTime), 1, -1)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004271444241277', CAST(N'2020-04-27 14:44:32.000' AS DateTime), 1, 0)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004301536574054', CAST(N'2020-04-30 15:37:03.000' AS DateTime), 1, 0)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004301653515583', CAST(N'2020-04-30 16:54:04.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202004301705376830', CAST(N'2020-04-30 17:05:44.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202005042338241876', CAST(N'2020-05-04 23:38:44.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202005042346356696', CAST(N'2020-05-04 23:47:02.000' AS DateTime), 1, 2)
INSERT [dbo].[T_Purchase] ([PurID], [PurTime], [PurProID], [PurStart]) VALUES (N'CG202005042349476309', CAST(N'2020-05-04 23:50:01.000' AS DateTime), 1, 2)
SET IDENTITY_INSERT [dbo].[T_PurchaseDetailed] ON 

INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (8, N'CG202004211455369413', 24, 1, 36)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (9, N'CG202004211455369413', 22, 1, 36)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (10, N'CG202004271055363121', 23, 2, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (11, N'CG202004271059325312', 25, 2, 10)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (12, N'CG202004271433235579', 25, 5, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (13, N'CG202004271433235579', 24, 5, 10)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (15, N'CG202004301653515583', 25, 6, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (16, N'CG202004301653515583', 24, 6, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (17, N'CG202004301705376830', 25, 6, 10)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (18, N'CG202005042338241876', 25, 6, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (19, N'CG202005042338241876', 24, 6, 10)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (20, N'CG202005042346356696', 25, 6, 10)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (21, N'CG202005042346356696', 24, 6, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (22, N'CG202005042349476309', 25, 5, 20)
INSERT [dbo].[T_PurchaseDetailed] ([PurDetailedID], [PurCode], [ShopID], [PurStoreID], [PurNumber]) VALUES (23, N'CG202005042349476309', 24, 5, 20)
SET IDENTITY_INSERT [dbo].[T_PurchaseDetailed] OFF
SET IDENTITY_INSERT [dbo].[T_Role] ON 

INSERT [dbo].[T_Role] ([RoleID], [Name], [RoleRemake]) VALUES (1, N'超级管理员', N'超级管理员')
INSERT [dbo].[T_Role] ([RoleID], [Name], [RoleRemake]) VALUES (2, N'采购员', N'采购人员')
SET IDENTITY_INSERT [dbo].[T_Role] OFF
SET IDENTITY_INSERT [dbo].[T_RolePermissions] ON 

INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (1, N'Sys_001', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (2, N'Sys_001_01', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (3, N'Sys_001_02', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (4, N'Sys_001_03', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (5, N'Sys_002', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (6, N'Sys_002_01', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (7, N'Sys_002_02', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (8, N'Sys_002_03', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (9, N'Sys_002_04', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (11, N'Sys_003', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (12, N'Sys_003_01', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (13, N'Sys_003_02', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (14, N'Sys_003_03', 1)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (15, N'Sys_003', 2)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (16, N'Sys_003_01', 2)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (17, N'Sys_003_02', 2)
INSERT [dbo].[T_RolePermissions] ([Role_permissionsID], [PowerID], [RoleID]) VALUES (18, N'Sys_003_03', 2)
SET IDENTITY_INSERT [dbo].[T_RolePermissions] OFF
SET IDENTITY_INSERT [dbo].[T_Shop] ON 

INSERT [dbo].[T_Shop] ([ShopID], [ShopCode], [Name], [Images], [SupplierID], [CostPrice], [SalePrice], [BothTime], [ShelfLife], [ShopTypeID], [Number]) VALUES (22, N'000000', N'怡宝矿泉水', NULL, 3, 1.0000, 2.0000, NULL, 720, 3, NULL)
INSERT [dbo].[T_Shop] ([ShopID], [ShopCode], [Name], [Images], [SupplierID], [CostPrice], [SalePrice], [BothTime], [ShelfLife], [ShopTypeID], [Number]) VALUES (23, N'1234567890000', N'盼盼小面包', NULL, 4, 10.0000, 20.0000, NULL, 180, 4, NULL)
INSERT [dbo].[T_Shop] ([ShopID], [ShopCode], [Name], [Images], [SupplierID], [CostPrice], [SalePrice], [BothTime], [ShelfLife], [ShopTypeID], [Number]) VALUES (24, N'000001', N'农夫山泉', NULL, 4, 1.0000, 2.0000, NULL, 360, 3, NULL)
INSERT [dbo].[T_Shop] ([ShopID], [ShopCode], [Name], [Images], [SupplierID], [CostPrice], [SalePrice], [BothTime], [ShelfLife], [ShopTypeID], [Number]) VALUES (25, N'000002', N'康师傅方便面', NULL, 4, 1.5000, 2.5000, NULL, 180, 6, NULL)
SET IDENTITY_INSERT [dbo].[T_Shop] OFF
SET IDENTITY_INSERT [dbo].[T_ShopType] ON 

INSERT [dbo].[T_ShopType] ([TypeID], [Name]) VALUES (1, N'水果类')
INSERT [dbo].[T_ShopType] ([TypeID], [Name]) VALUES (2, N'零食类')
INSERT [dbo].[T_ShopType] ([TypeID], [Name]) VALUES (3, N'饮料类')
INSERT [dbo].[T_ShopType] ([TypeID], [Name]) VALUES (4, N'面包类')
INSERT [dbo].[T_ShopType] ([TypeID], [Name]) VALUES (5, N'特产类')
INSERT [dbo].[T_ShopType] ([TypeID], [Name]) VALUES (6, N'食品类')
SET IDENTITY_INSERT [dbo].[T_ShopType] OFF
SET IDENTITY_INSERT [dbo].[T_Store] ON 

INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (1, N'一号仓', 1)
INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (2, N'二号仓', 1)
INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (3, N'三号仓', 2)
INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (4, N'四号仓', 3)
INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (5, N'五号仓', 1)
INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (6, N'六号仓', 1)
INSERT [dbo].[T_Store] ([StoreID], [Name], [Status]) VALUES (7, N'七号仓', 2)
SET IDENTITY_INSERT [dbo].[T_Store] OFF
SET IDENTITY_INSERT [dbo].[T_StoreProduct] ON 

INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (8, 24, 2, 11)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (10, 23, 2, 20)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (11, 22, 1, 36)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (12, 24, 1, 36)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (16, 25, 1, 10)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (17, 25, 6, 60)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (18, 24, 6, 50)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (19, 25, 5, 20)
INSERT [dbo].[T_StoreProduct] ([StoreProID], [ShopID], [StoreID], [Count]) VALUES (20, 24, 5, 20)
SET IDENTITY_INSERT [dbo].[T_StoreProduct] OFF
SET IDENTITY_INSERT [dbo].[T_Supplier] ON 

INSERT [dbo].[T_Supplier] ([SupplierID], [SupplierName], [LinkMan], [Mobile], [Address], [Status]) VALUES (3, N'深圳供应商', N'王先生', N'13233333333', N'深圳', 1)
INSERT [dbo].[T_Supplier] ([SupplierID], [SupplierName], [LinkMan], [Mobile], [Address], [Status]) VALUES (4, N'佛山供应商', N'李小三', N'15566666666', N'广州佛山', 1)
INSERT [dbo].[T_Supplier] ([SupplierID], [SupplierName], [LinkMan], [Mobile], [Address], [Status]) VALUES (5, N'长沙供应商', N'黑麻子', N'13455555555', N'湖南长沙', 2)
SET IDENTITY_INSERT [dbo].[T_Supplier] OFF
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Audit', @level2type=N'COLUMN',@level2name=N'AuditID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核状态（待审核，未审核，已审核）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Audit', @level2type=N'COLUMN',@level2name=N'AuditState'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工编号（自增）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'EmployeeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Login'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Passwd'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'员工姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Sex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Telephone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'头像' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'Photo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Employee', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航编号(自增)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Navigation', @level2type=N'COLUMN',@level2name=N'NavigationID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Navigation', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'导航地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Navigation', @level2type=N'COLUMN',@level2name=N'Url'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Navigation', @level2type=N'COLUMN',@level2name=N'CodeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级编号(自连)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Navigation', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Power', @level2type=N'COLUMN',@level2name=N'PowerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Power', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级权限编号(自连接)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Power', @level2type=N'COLUMN',@level2name=N'ParentID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购订单编号（年月日时分秒+1000-9999）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Purchase', @level2type=N'COLUMN',@level2name=N'PurID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Purchase', @level2type=N'COLUMN',@level2name=N'PurTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购员工（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Purchase', @level2type=N'COLUMN',@level2name=N'PurProID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'默认（0） -1=不通过 0=待审核，1=已审核，待入库，2=已入库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Purchase', @level2type=N'COLUMN',@level2name=N'PurStart'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号（自增）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PurchaseDetailed', @level2type=N'COLUMN',@level2name=N'PurDetailedID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购入库订单编号（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PurchaseDetailed', @level2type=N'COLUMN',@level2name=N'PurCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品ID(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PurchaseDetailed', @level2type=N'COLUMN',@level2name=N'ShopID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购入库仓库（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PurchaseDetailed', @level2type=N'COLUMN',@level2name=N'PurStoreID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PurchaseDetailed', @level2type=N'COLUMN',@level2name=N'PurNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货订单编号（年月日时分秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Return', @level2type=N'COLUMN',@level2name=N'RtnID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Return', @level2type=N'COLUMN',@level2name=N'RtnTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Return', @level2type=N'COLUMN',@level2name=N'RtnExplain'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货审核(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Return', @level2type=N'COLUMN',@level2name=N'RtnAudit'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号(自增)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Role', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色权限编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_RolePermissions', @level2type=N'COLUMN',@level2name=N'Role_permissionsID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限编号(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_RolePermissions', @level2type=N'COLUMN',@level2name=N'PowerID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'角色编号(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_RolePermissions', @level2type=N'COLUMN',@level2name=N'RoleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售订单编号（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleDetailed', @level2type=N'COLUMN',@level2name=N'SaleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品ID（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleDetailed', @level2type=N'COLUMN',@level2name=N'ShopID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleDetailed', @level2type=N'COLUMN',@level2name=N'SaleNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售订单编号（年月日时分秒）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleOrder', @level2type=N'COLUMN',@level2name=N'SaleID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleOrder', @level2type=N'COLUMN',@level2name=N'SaleTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售员工（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleOrder', @level2type=N'COLUMN',@level2name=N'SaleEmp'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号(自增)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleReturn', @level2type=N'COLUMN',@level2name=N'SaleRtnID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货订单编号（外键）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleReturn', @level2type=N'COLUMN',@level2name=N'RtnCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品ID(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleReturn', @level2type=N'COLUMN',@level2name=N'ShopID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'退货数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_SaleReturn', @level2type=N'COLUMN',@level2name=N'RtnNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'ShopID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品条形码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'ShopCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'Images'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'SupplierID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品进价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'CostPrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品售价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'SalePrice'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'BothTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保质期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'ShelfLife'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品类型编号(外键)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'ShopTypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'特殊字段 用来完成采购 销售 入库的数量 不做实际操作' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Shop', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品类型编号(自增)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ShopType', @level2type=N'COLUMN',@level2name=N'TypeID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_ShopType', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号(自增)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Store', @level2type=N'COLUMN',@level2name=N'StoreID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Store', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库状态(1=正常、2=已满、3=停用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Store', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号(外键 商品表)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_StoreProduct', @level2type=N'COLUMN',@level2name=N'ShopID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_StoreProduct', @level2type=N'COLUMN',@level2name=N'StoreID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_StoreProduct', @level2type=N'COLUMN',@level2name=N'Count'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Supplier', @level2type=N'COLUMN',@level2name=N'SupplierID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Supplier', @level2type=N'COLUMN',@level2name=N'SupplierName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Supplier', @level2type=N'COLUMN',@level2name=N'LinkMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Supplier', @level2type=N'COLUMN',@level2name=N'Mobile'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Supplier', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商状态(1=正常，2=停用)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_Supplier', @level2type=N'COLUMN',@level2name=N'Status'
GO
USE [master]
GO
ALTER DATABASE [Supermarket] SET  READ_WRITE 
GO
