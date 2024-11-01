USE [master]
GO
/****** Object:  Database [markettingAppv2]    Script Date: 5/17/2023 4:03:56 PM ******/
CREATE DATABASE [markettingAppv2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'markettingAppv2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\markettingAppv2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'markettingAppv2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\markettingAppv2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [markettingAppv2] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [markettingAppv2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [markettingAppv2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [markettingAppv2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [markettingAppv2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [markettingAppv2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [markettingAppv2] SET ARITHABORT OFF 
GO
ALTER DATABASE [markettingAppv2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [markettingAppv2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [markettingAppv2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [markettingAppv2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [markettingAppv2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [markettingAppv2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [markettingAppv2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [markettingAppv2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [markettingAppv2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [markettingAppv2] SET  ENABLE_BROKER 
GO
ALTER DATABASE [markettingAppv2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [markettingAppv2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [markettingAppv2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [markettingAppv2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [markettingAppv2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [markettingAppv2] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [markettingAppv2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [markettingAppv2] SET RECOVERY FULL 
GO
ALTER DATABASE [markettingAppv2] SET  MULTI_USER 
GO
ALTER DATABASE [markettingAppv2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [markettingAppv2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [markettingAppv2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [markettingAppv2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [markettingAppv2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'markettingAppv2', N'ON'
GO
ALTER DATABASE [markettingAppv2] SET QUERY_STORE = OFF
GO
USE [markettingAppv2]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [markettingAppv2]
GO
/****** Object:  User [saeed]    Script Date: 5/17/2023 4:03:56 PM ******/
CREATE USER [saeed] FOR LOGIN [saeed] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [doctor]    Script Date: 5/17/2023 4:03:56 PM ******/
CREATE USER [doctor] FOR LOGIN [doctor] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/17/2023 4:03:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[UserType] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[Image] [nvarchar](max) NULL,
	[Others] [nvarchar](max) NULL,
	[State] [int] NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CommunicationChannels]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CommunicationChannels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacilityId] [int] NULL,
	[Link] [nvarchar](255) NULL,
	[ChannelType] [nvarchar](255) NULL,
	[PhoneNumber] [nvarchar](255) NULL,
	[State] [int] NOT NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [Pk_CommunicationChannels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departments]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[State] [int] NOT NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [Pk_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartmentServices]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartmentServices](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[ServiceName] [nvarchar](255) NOT NULL,
	[State] [int] NOT NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [Pk_DepartmentServices] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facilities]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facilities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[FacilityActivity] [nvarchar](255) NULL,
	[TradeName] [nvarchar](255) NULL,
	[SpecialistName] [nvarchar](255) NULL,
	[SpecialistAdjective] [nvarchar](255) NULL,
	[Address] [nvarchar](255) NULL,
	[State] [int] NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[FacilityTypeId] [int] NULL,
 CONSTRAINT [Pk_Facilities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FacilityTypes]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FacilityTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[State] [int] NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [Pk_FacilityType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderResults]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentServiceId] [int] NULL,
	[FacilityId] [int] NULL,
	[Note] [nvarchar](255) NULL,
	[State] [int] NOT NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [Pk_OrderResults] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VisitResults]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VisitResults](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacilityId] [int] NOT NULL,
	[ResultType] [nvarchar](255) NULL,
	[Message] [nvarchar](max) NULL,
	[Code] [nvarchar](255) NULL,
	[State] [int] NOT NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [Pk_VisitResult] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 5/17/2023 4:03:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FacilityId] [int] NOT NULL,
	[Reason] [nvarchar](max) NULL,
	[VisitTime] [datetime2](7) NOT NULL,
	[State] [int] NOT NULL,
	[other] [nvarchar](max) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[LastModfiedBy] [nvarchar](max) NULL,
	[LastModfiedAt] [datetime2](7) NULL,
	[IsDeleted] [bit] NOT NULL,
	[DeletedBy] [nvarchar](max) NULL,
	[DeletedAt] [datetime2](7) NULL,
 CONSTRAINT [Pk_Visits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230314003522_v1', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230326205859_v4', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230410190255_v5', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230513153531_finalmgt', N'6.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516174408_v2', N'6.0.10')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'5702da26-6b6b-4e76-a3ec-22c9f3d9a236', N'user', N'USER', N'eb36ca73-d61a-486e-8940-9f12dace01f8')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c4009a49-c474-4c6f-a906-4839fcece0d1', N'admin', N'ADMIN', N'6aea3dc9-7ada-40dc-9ae5-dea91d8eb2fa')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'da4b17a9-baea-4967-9b29-9ef70e9cbd86', N'manager', N'MANAGER', N'a0a67ae2-4076-43f9-9534-719911fd7c41')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'7abbcf19-d03e-4d51-b7e0-10b35cb3d64d', N'c4009a49-c474-4c6f-a906-4839fcece0d1')
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [UserType], [Email], [Image], [Others], [State], [CreatedBy], [CreatedAt], [LastModfiedBy], [LastModfiedAt], [IsDeleted], [DeletedBy], [DeletedAt], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7abbcf19-d03e-4d51-b7e0-10b35cb3d64d', N'abood', N'admin', N'abood@gmail.com', NULL, NULL, 1, NULL, CAST(N'2023-05-16T20:49:50.2529680' AS DateTime2), NULL, NULL, 0, NULL, NULL, N'abood', N'ABOOD', NULL, 0, N'AQAAAAEAACcQAAAAEJgqp73Vn7xIHLFdyiOOGmlyMhGNeb4xAUIARIACGV0Qaurhs4KZJDbltqZ9FfCkUw==', N'PTDJI2QAKH6DGG4C6GAG3TTGADJOHMVV', N'157094d8-5556-49c9-a195-fca05ed719c8', N'123456789', 0, 0, NULL, 1, 0)
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetRoleClaims_RoleId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetRoleClaims_RoleId] ON [dbo].[AspNetRoleClaims]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [RoleNameIndex]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[NormalizedName] ASC
)
WHERE ([NormalizedName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserClaims_UserId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserClaims_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserLogins_UserId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserLogins_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_AspNetUserRoles_RoleId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_AspNetUserRoles_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [EmailIndex]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [EmailIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedEmail] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UserNameIndex]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[NormalizedUserName] ASC
)
WHERE ([NormalizedUserName] IS NOT NULL)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_CommunicationChannels_FacilityId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_CommunicationChannels_FacilityId] ON [dbo].[CommunicationChannels]
(
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_DepartmentServices_DepartmentId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_DepartmentServices_DepartmentId] ON [dbo].[DepartmentServices]
(
	[DepartmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Facilities_FacilityTypeId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Facilities_FacilityTypeId] ON [dbo].[Facilities]
(
	[FacilityTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Facilities_UserId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_Facilities_UserId] ON [dbo].[Facilities]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderResults_DepartmentServiceId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderResults_DepartmentServiceId] ON [dbo].[OrderResults]
(
	[DepartmentServiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_OrderResults_FacilityId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_OrderResults_FacilityId] ON [dbo].[OrderResults]
(
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_VisitResults_FacilityId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE NONCLUSTERED INDEX [IX_VisitResults_FacilityId] ON [dbo].[VisitResults]
(
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Visits_FacilityId]    Script Date: 5/17/2023 4:03:57 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Visits_FacilityId] ON [dbo].[Visits]
(
	[FacilityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CommunicationChannels] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[Departments] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[DepartmentServices] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[OrderResults] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[VisitResults] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[Visits] ADD  DEFAULT ((1)) FOR [State]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[CommunicationChannels]  WITH CHECK ADD  CONSTRAINT [FK_CommunicationChannel_Facility] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facilities] ([Id])
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CommunicationChannels] CHECK CONSTRAINT [FK_CommunicationChannel_Facility]
GO
ALTER TABLE [dbo].[DepartmentServices]  WITH CHECK ADD  CONSTRAINT [FK_DepartmentServices_Department] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[DepartmentServices] CHECK CONSTRAINT [FK_DepartmentServices_Department]
GO
ALTER TABLE [dbo].[Facilities]  WITH CHECK ADD  CONSTRAINT [Fk_Facilities_FacilityType] FOREIGN KEY([FacilityTypeId])
REFERENCES [dbo].[FacilityTypes] ([Id])
GO
ALTER TABLE [dbo].[Facilities] CHECK CONSTRAINT [Fk_Facilities_FacilityType]
GO
ALTER TABLE [dbo].[Facilities]  WITH CHECK ADD  CONSTRAINT [Fk_Facilities_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Facilities] CHECK CONSTRAINT [Fk_Facilities_Users]
GO
ALTER TABLE [dbo].[OrderResults]  WITH CHECK ADD  CONSTRAINT [FK_OrderResults_DepartmentService] FOREIGN KEY([DepartmentServiceId])
REFERENCES [dbo].[DepartmentServices] ([Id])
GO
ALTER TABLE [dbo].[OrderResults] CHECK CONSTRAINT [FK_OrderResults_DepartmentService]
GO
ALTER TABLE [dbo].[OrderResults]  WITH CHECK ADD  CONSTRAINT [FK_OrderResults_Facility] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facilities] ([Id])
GO
ALTER TABLE [dbo].[OrderResults] CHECK CONSTRAINT [FK_OrderResults_Facility]
GO
ALTER TABLE [dbo].[VisitResults]  WITH CHECK ADD  CONSTRAINT [FK_VisitResult_Facility] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facilities] ([Id])
GO
ALTER TABLE [dbo].[VisitResults] CHECK CONSTRAINT [FK_VisitResult_Facility]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visit_Facility] FOREIGN KEY([FacilityId])
REFERENCES [dbo].[Facilities] ([Id])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visit_Facility]
GO
USE [master]
GO
ALTER DATABASE [markettingAppv2] SET  READ_WRITE 
GO
