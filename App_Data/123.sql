USE [master]
GO
/****** Object:  Database [CG_Appraisal]    Script Date: 7/15/2020 8:38:36 PM ******/
CREATE DATABASE [CG_Appraisal]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CG_Appraisal', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.NGDEVPH\MSSQL\DATA\CG_Appraisal.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CG_Appraisal_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.NGDEVPH\MSSQL\DATA\CG_Appraisal_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CG_Appraisal] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CG_Appraisal].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CG_Appraisal] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CG_Appraisal] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CG_Appraisal] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CG_Appraisal] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CG_Appraisal] SET ARITHABORT OFF 
GO
ALTER DATABASE [CG_Appraisal] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CG_Appraisal] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CG_Appraisal] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CG_Appraisal] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CG_Appraisal] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CG_Appraisal] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CG_Appraisal] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CG_Appraisal] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CG_Appraisal] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CG_Appraisal] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CG_Appraisal] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CG_Appraisal] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CG_Appraisal] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CG_Appraisal] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CG_Appraisal] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CG_Appraisal] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CG_Appraisal] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CG_Appraisal] SET RECOVERY FULL 
GO
ALTER DATABASE [CG_Appraisal] SET  MULTI_USER 
GO
ALTER DATABASE [CG_Appraisal] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CG_Appraisal] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CG_Appraisal] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CG_Appraisal] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CG_Appraisal] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CG_Appraisal', N'ON'
GO
ALTER DATABASE [CG_Appraisal] SET QUERY_STORE = OFF
GO
USE [CG_Appraisal]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [CG_Appraisal]
GO
/****** Object:  User [NGDEVPH-ALVIN\Alvin Manalansan]    Script Date: 7/15/2020 8:38:36 PM ******/
CREATE USER [NGDEVPH-ALVIN\Alvin Manalansan] FOR LOGIN [NGDEVPH-ALVIN\Alvin Manalansan] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[SetAccess]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetAccess](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[Access] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SetAccess] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SetBank]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetBank](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[DateEncoded] [datetime] NULL,
 CONSTRAINT [PK_SetBank] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SetBankBranch]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetBankBranch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BankId] [int] NULL,
	[Name] [nvarchar](150) NULL,
	[AccountNumber] [nvarchar](150) NULL,
	[IsActive] [bit] NULL,
	[DateEncoded] [datetime] NULL,
 CONSTRAINT [PK_SetBankBranch] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SetPaymentDetails]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetPaymentDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[DefaultAmount] [numeric](10, 2) NULL,
	[DateEncoded] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SetPaymentDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SetUser]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SetUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateEncoded] [datetime] NULL,
	[FirstName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[MiddleName] [nvarchar](150) NULL,
	[AccessId] [int] NULL,
	[Username] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_SetUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TxnAppraisal]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TxnAppraisal](
	[Id] [int] NOT NULL,
	[BatchCode] [nvarchar](max) NULL,
	[AccountName] [nvarchar](max) NULL,
	[CompanyName] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CTCNo] [nvarchar](150) NULL,
	[WithVat] [bit] NULL,
	[TimeTable] [nvarchar](150) NULL,
	[BranchId] [int] NULL,
	[PurposeOfAvailingServices] [nvarchar](max) NULL,
	[StatusId] [int] NULL,
	[IsPrintedSOA] [bit] NULL,
 CONSTRAINT [PK_TxnAppraisal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TxnAppraisalPaymentDetails]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TxnAppraisalPaymentDetails](
	[TxnAppraisalId] [int] NULL,
	[RowNo] [int] NULL,
	[PaymentDetails] [nvarchar](max) NULL,
	[Amount] [numeric](10, 2) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TxnAppraisalPaymentLogs]    Script Date: 7/15/2020 8:38:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TxnAppraisalPaymentLogs](
	[TxnAppraisalId] [int] NULL,
	[TransactionDateTime] [datetime] NULL,
	[Payment] [numeric](10, 2) NULL,
	[Notes] [nvarchar](max) NULL,
	[UserId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SetBank] ON 

INSERT [dbo].[SetBank] ([Id], [Name], [IsActive], [DateEncoded]) VALUES (1, N'BDO', 1, CAST(N'2020-03-01T00:00:00.000' AS DateTime))
INSERT [dbo].[SetBank] ([Id], [Name], [IsActive], [DateEncoded]) VALUES (2, N'SECURITY BANK', 1, CAST(N'2020-03-02T00:00:00.000' AS DateTime))
INSERT [dbo].[SetBank] ([Id], [Name], [IsActive], [DateEncoded]) VALUES (1002, N'UNION BANK', 1, CAST(N'2020-03-12T21:42:58.630' AS DateTime))
INSERT [dbo].[SetBank] ([Id], [Name], [IsActive], [DateEncoded]) VALUES (1006, N'UNION BANKs', 1, CAST(N'2020-03-17T13:42:05.613' AS DateTime))
SET IDENTITY_INSERT [dbo].[SetBank] OFF
SET IDENTITY_INSERT [dbo].[SetBankBranch] ON 

INSERT [dbo].[SetBankBranch] ([Id], [BankId], [Name], [AccountNumber], [IsActive], [DateEncoded]) VALUES (1, 1002, N'SAN FERNANDO', N'1234412333', 1, CAST(N'2020-03-13T00:24:20.897' AS DateTime))
SET IDENTITY_INSERT [dbo].[SetBankBranch] OFF
SET IDENTITY_INSERT [dbo].[SetUser] ON 

INSERT [dbo].[SetUser] ([Id], [DateEncoded], [FirstName], [LastName], [MiddleName], [AccessId], [Username], [Password], [IsActive]) VALUES (1, CAST(N'2020-01-01T00:00:00.000' AS DateTime), N'admin', N'admin', N'admin', 1, N'gGo8Q0L84wEfrUaq0KNYJQ==', N'gGo8Q0L84wEfrUaq0KNYJQ==', 1)
SET IDENTITY_INSERT [dbo].[SetUser] OFF
ALTER TABLE [dbo].[SetBankBranch]  WITH CHECK ADD  CONSTRAINT [FK_SetBankBranch_SetBank] FOREIGN KEY([BankId])
REFERENCES [dbo].[SetBank] ([Id])
GO
ALTER TABLE [dbo].[SetBankBranch] CHECK CONSTRAINT [FK_SetBankBranch_SetBank]
GO
ALTER TABLE [dbo].[TxnAppraisal]  WITH CHECK ADD  CONSTRAINT [FK_TxnAppraisal_SetBankBranch] FOREIGN KEY([BranchId])
REFERENCES [dbo].[SetBankBranch] ([Id])
GO
ALTER TABLE [dbo].[TxnAppraisal] CHECK CONSTRAINT [FK_TxnAppraisal_SetBankBranch]
GO
ALTER TABLE [dbo].[TxnAppraisalPaymentDetails]  WITH CHECK ADD  CONSTRAINT [FK_TxnApprailsaPaymentDetails_TxnAppraisal] FOREIGN KEY([TxnAppraisalId])
REFERENCES [dbo].[TxnAppraisal] ([Id])
GO
ALTER TABLE [dbo].[TxnAppraisalPaymentDetails] CHECK CONSTRAINT [FK_TxnApprailsaPaymentDetails_TxnAppraisal]
GO
ALTER TABLE [dbo].[TxnAppraisalPaymentLogs]  WITH CHECK ADD  CONSTRAINT [FK_TxnAppraisalPaymentLogs_TxnAppraisal] FOREIGN KEY([TxnAppraisalId])
REFERENCES [dbo].[TxnAppraisal] ([Id])
GO
ALTER TABLE [dbo].[TxnAppraisalPaymentLogs] CHECK CONSTRAINT [FK_TxnAppraisalPaymentLogs_TxnAppraisal]
GO
/****** Object:  StoredProcedure [dbo].[BankBranchLoad]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankBranchLoad]
@id int,
@keyword nvarchar(max),
@dateFrom datetime,
@dateto datetime
AS
BEGIN 
	SET NOCOUNT ON; 

	select Row_Number() OVER(order by a.id) as RowNo, a.*,b.Name as BankName	
	from SetBankBranch a left join SetBank b on b.Id = a.BankId  
	where 
	(a.id = @id OR @id = '' or @id = -1) and
	(a.Name like +'%'+@keyword+'%' or b.Name like +'%'+@keyword+'%' ) and
	(a.DateEncoded >= @dateFrom OR @dateFrom = '') and 
	(a.DateEncoded <= @dateto OR @dateto = '')
	order by a.DateEncoded desc
END
GO
/****** Object:  StoredProcedure [dbo].[BankBranchSaveUpdate]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankBranchSaveUpdate]
	@isEdit bit,
	@id int,
	@bankId int,
	@name nvarchar(max),
	@accountNo nvarchar(max),
	@isActive bit
AS
BEGIN 
	SET NOCOUNT ON;

	if @isEdit = 1
		begin
			update SetBankBranch set BankId = @bankId, name = @name, IsActive = @isActive
			, AccountNumber = @accountNo
			where id = @id
		end
	else
		begin
			insert into SetBankBranch(name,BankId,DateEncoded, IsActive,AccountNumber )
			values
			(@name,@bankId, GETDATE(), @isActive,@accountNo)
		end
END
GO
/****** Object:  StoredProcedure [dbo].[BankLoad]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankLoad]
@id int,
@keyword nvarchar(max),
@dateFrom datetime,
@dateto datetime
AS
BEGIN 
	SET NOCOUNT ON; 

	select Row_Number() OVER(order by id) as RowNo, * from SetBank where 
	(id = @id OR @id = '' or @id = -1) and
	(name like +'%'+@keyword+'%') and
	(DateEncoded >= @dateFrom OR @dateFrom = '') and 
	(DateEncoded <= @dateto OR @dateto = '')
	ORDER BY DateEncoded desc
END
GO
/****** Object:  StoredProcedure [dbo].[BankSaveUpdate]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[BankSaveUpdate]
	@isEdit bit,
	@id int,
	@name nvarchar(max),
	@isActive bit
AS
BEGIN 
	SET NOCOUNT ON;

	if @isEdit = 1
		begin
			update SetBank set name = @name, IsActive = @isActive
			where id = @id
		end
	else
		begin
			insert into SetBank(name,DateEncoded, IsActive)
			values
			(@name, GETDATE(), @isActive)
		end
END
GO
/****** Object:  StoredProcedure [dbo].[PaymentDetailsLoad]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PaymentDetailsLoad]
@id int,
@keyword nvarchar(max),
@dateFrom datetime,
@dateto datetime
AS
BEGIN 
	SET NOCOUNT ON; 

	select Row_Number() OVER(order by a.id) as RowNo, a.* 
	from SetPaymentDetails a  
	where 
	(a.id = @id OR @id = '' or @id = -1) and
	(a.Name like +'%'+@keyword+'%') and
	(a.DateEncoded >= @dateFrom OR @dateFrom = '') and 
	(a.DateEncoded <= @dateto OR @dateto = '')
	order by a.DateEncoded desc
END
GO
/****** Object:  StoredProcedure [dbo].[PaymentDetailsSaveUpdate]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[PaymentDetailsSaveUpdate]
	@isEdit bit,
	@id int,
	@name nvarchar(max),
	@defaultPayment numeric(10,2),
	@isActive bit
AS
BEGIN 
	SET NOCOUNT ON;

	if @isEdit = 1
		begin
			update SetPaymentDetails set name = @name, IsActive = @isActive
			where id = @id
		end
	else
		begin
			insert into SetPaymentDetails(name,DateEncoded, IsActive,DefaultAmount)
			values
			(@name, GETDATE(), @isActive, @defaultPayment)
		end
END
GO
/****** Object:  StoredProcedure [dbo].[SaveUpdateUser]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SaveUpdateUser]
@IsEdit bit,
@Id int,
@FirstName nvarchar(max),
@LastName nvarchar(max),
@MiddleName nvarchar(max),
@AccessId int,
@Username nvarchar(max),
@Password nvarchar(max),
@IsActive bit

AS
BEGIN 
	SET NOCOUNT ON; 

	if @IsEdit = 0  
		BEGIN
		INSERT INTO [dbo].[SetUser]
           ([DateEncoded]
           ,[FirstName]
           ,[LastName]
           ,[MiddleName]
           ,[AccessId]
           ,[Username]
           ,[Password]
           ,[IsActive])
     VALUES
           (GETDATE()
           ,@FirstName
           ,@LastName
           ,@MiddleName
           ,@AccessId
           ,@Username
           ,@Password
           ,@IsActive)
		end
	else
	begin
	UPDATE [dbo].[SetUser]
		SET [FirstName] = @FirstName
			,[LastName] = @LastName
			,[MiddleName] = @MiddleName
			,[AccessId] = @AccessId
			,[Username] = @Username
			,[Password] = @Password
			,[IsActive] = @IsActive
		WHERE [Id] = @Id
	end

END
GO
/****** Object:  StoredProcedure [dbo].[UserLogin]    Script Date: 7/15/2020 8:38:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserLogin]
	@userName nvarchar(max),
	@password nvarchar(max)
AS
BEGIN 
	SET NOCOUNT ON;
	 
	Select * from [SetUser] where [Username] = @userName and [Password] = @Password and IsActive = 1
END
GO
USE [master]
GO
ALTER DATABASE [CG_Appraisal] SET  READ_WRITE 
GO
