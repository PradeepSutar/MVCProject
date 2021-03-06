USE [master]
GO
/****** Object:  Database [TEST]    Script Date: 03-06-2019 16:33:39 ******/
CREATE DATABASE [TEST]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TEST', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.FLOLOGIC2\MSSQL\DATA\TEST.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TEST_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.FLOLOGIC2\MSSQL\DATA\TEST_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TEST] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TEST].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TEST] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TEST] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TEST] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TEST] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TEST] SET ARITHABORT OFF 
GO
ALTER DATABASE [TEST] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TEST] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [TEST] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TEST] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TEST] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TEST] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TEST] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TEST] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TEST] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TEST] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TEST] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TEST] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TEST] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TEST] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TEST] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TEST] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TEST] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TEST] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TEST] SET RECOVERY FULL 
GO
ALTER DATABASE [TEST] SET  MULTI_USER 
GO
ALTER DATABASE [TEST] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TEST] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TEST] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TEST] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [TEST]
GO
/****** Object:  Table [dbo].[TBLEMPLOYEE]    Script Date: 03-06-2019 16:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLEMPLOYEE](
	[PK_EMP_ID] [int] IDENTITY(1,1) NOT NULL,
	[EMP_NAME] [nvarchar](100) NULL,
	[AGE] [numeric](18, 1) NULL,
	[MARTIAL_STATUS] [nvarchar](50) NULL,
	[LOCATION] [int] NULL,
	[SALARY] [numeric](18, 2) NULL,
	[USER_ID] [nvarchar](50) NULL,
	[ISACTIVE] [int] NULL,
	[PASSWORD] [nvarchar](100) NULL,
	[CREATED_BY] [nvarchar](50) NULL,
	[CREATED_DATE] [datetime] NULL,
	[SKILL_ID] [int] NULL,
	[RELEVANT_EXPR] [nvarchar](50) NULL,
 CONSTRAINT [PK_TBLEMPLOYEE] PRIMARY KEY CLUSTERED 
(
	[PK_EMP_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLLOCATION]    Script Date: 03-06-2019 16:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLLOCATION](
	[PK_LOC_ID] [int] IDENTITY(1,1) NOT NULL,
	[LOCATION] [nvarchar](50) NULL,
	[ISACTIVE] [int] NULL,
 CONSTRAINT [PK_TBLLOCATION] PRIMARY KEY CLUSTERED 
(
	[PK_LOC_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TBLSKILL]    Script Date: 03-06-2019 16:33:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBLSKILL](
	[PK_SKILL_ID] [int] IDENTITY(1,1) NOT NULL,
	[SKILL_NAME] [nvarchar](200) NULL,
	[ISACTIVE] [int] NULL,
 CONSTRAINT [PK_TBLSKILL] PRIMARY KEY CLUSTERED 
(
	[PK_SKILL_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[TBLEMPLOYEE] ON 

INSERT [dbo].[TBLEMPLOYEE] ([PK_EMP_ID], [EMP_NAME], [AGE], [MARTIAL_STATUS], [LOCATION], [SALARY], [USER_ID], [ISACTIVE], [PASSWORD], [CREATED_BY], [CREATED_DATE], [SKILL_ID], [RELEVANT_EXPR]) VALUES (1, N'Admin', CAST(27.0 AS Numeric(18, 1)), N'Married', 1, CAST(30000.00 AS Numeric(18, 2)), N'admin', 1, N'123', N'paddy', CAST(0x0000AA5C0106D96D AS DateTime), 2, N'1')
INSERT [dbo].[TBLEMPLOYEE] ([PK_EMP_ID], [EMP_NAME], [AGE], [MARTIAL_STATUS], [LOCATION], [SALARY], [USER_ID], [ISACTIVE], [PASSWORD], [CREATED_BY], [CREATED_DATE], [SKILL_ID], [RELEVANT_EXPR]) VALUES (2, N'Pradip Sutar', CAST(30.0 AS Numeric(18, 1)), N'Married', 1, CAST(30000.00 AS Numeric(18, 2)), N'paddy', 1, N'123', N'admin', CAST(0x0000AA5B00CDBEDB AS DateTime), 3, N'1')
INSERT [dbo].[TBLEMPLOYEE] ([PK_EMP_ID], [EMP_NAME], [AGE], [MARTIAL_STATUS], [LOCATION], [SALARY], [USER_ID], [ISACTIVE], [PASSWORD], [CREATED_BY], [CREATED_DATE], [SKILL_ID], [RELEVANT_EXPR]) VALUES (3, N'harshraj sutar', CAST(25.0 AS Numeric(18, 1)), N'Single', 1, CAST(20000.00 AS Numeric(18, 2)), N'harsh', 1, N'123', N'admin', CAST(0x0000AA5C01032785 AS DateTime), 1, N'1')
INSERT [dbo].[TBLEMPLOYEE] ([PK_EMP_ID], [EMP_NAME], [AGE], [MARTIAL_STATUS], [LOCATION], [SALARY], [USER_ID], [ISACTIVE], [PASSWORD], [CREATED_BY], [CREATED_DATE], [SKILL_ID], [RELEVANT_EXPR]) VALUES (4, N'rohit s. more', CAST(26.0 AS Numeric(18, 1)), N'Single', 1, CAST(25000.00 AS Numeric(18, 2)), N'rm', 1, N'123', N'admin', CAST(0x0000AA5C0102F67E AS DateTime), 3, N'2')
SET IDENTITY_INSERT [dbo].[TBLEMPLOYEE] OFF
SET IDENTITY_INSERT [dbo].[TBLLOCATION] ON 

INSERT [dbo].[TBLLOCATION] ([PK_LOC_ID], [LOCATION], [ISACTIVE]) VALUES (1, N'Pune', 1)
INSERT [dbo].[TBLLOCATION] ([PK_LOC_ID], [LOCATION], [ISACTIVE]) VALUES (2, N'Mumbai', 1)
INSERT [dbo].[TBLLOCATION] ([PK_LOC_ID], [LOCATION], [ISACTIVE]) VALUES (3, N'Kolhapur', 1)
SET IDENTITY_INSERT [dbo].[TBLLOCATION] OFF
SET IDENTITY_INSERT [dbo].[TBLSKILL] ON 

INSERT [dbo].[TBLSKILL] ([PK_SKILL_ID], [SKILL_NAME], [ISACTIVE]) VALUES (1, N'ASP .NET', 1)
INSERT [dbo].[TBLSKILL] ([PK_SKILL_ID], [SKILL_NAME], [ISACTIVE]) VALUES (2, N'C', 1)
INSERT [dbo].[TBLSKILL] ([PK_SKILL_ID], [SKILL_NAME], [ISACTIVE]) VALUES (3, N'ASP .NET AND MVC', 1)
INSERT [dbo].[TBLSKILL] ([PK_SKILL_ID], [SKILL_NAME], [ISACTIVE]) VALUES (4, N'JQUERY', 1)
INSERT [dbo].[TBLSKILL] ([PK_SKILL_ID], [SKILL_NAME], [ISACTIVE]) VALUES (5, N'ANGULAR JS', 1)
SET IDENTITY_INSERT [dbo].[TBLSKILL] OFF
USE [master]
GO
ALTER DATABASE [TEST] SET  READ_WRITE 
GO
