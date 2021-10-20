
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/20/2021 21:34:02
-- Generated from EDMX file: D:\Visual Studio 2019\BadmintonGitRepo2021\DB\bgDBNew.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [DB_A142CC_BGDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AddressTypePersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonAddress] DROP CONSTRAINT [FK_AddressTypePersonAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_CountryPersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonAddress] DROP CONSTRAINT [FK_CountryPersonAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_EmailTypePersonEmail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonEmail] DROP CONSTRAINT [FK_EmailTypePersonEmail];
GO
IF OBJECT_ID(N'[dbo].[FK_JobTitlePersonOccupation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonOccupation] DROP CONSTRAINT [FK_JobTitlePersonOccupation];
GO
IF OBJECT_ID(N'[dbo].[FK_LogTypeLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Log] DROP CONSTRAINT [FK_LogTypeLog];
GO
IF OBJECT_ID(N'[dbo].[FK_MailoutParameterMailoutTypeParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutTypeParameter] DROP CONSTRAINT [FK_MailoutParameterMailoutTypeParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_MailoutQueueMailoutQueueParameterValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutQueueParameterValue] DROP CONSTRAINT [FK_MailoutQueueMailoutQueueParameterValue];
GO
IF OBJECT_ID(N'[dbo].[FK_MailoutQueueMailoutTracker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutTracker] DROP CONSTRAINT [FK_MailoutQueueMailoutTracker];
GO
IF OBJECT_ID(N'[dbo].[FK_MailoutTypeMailoutQueue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutQueue] DROP CONSTRAINT [FK_MailoutTypeMailoutQueue];
GO
IF OBJECT_ID(N'[dbo].[FK_MailoutTypeMailoutTypeParameter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutTypeParameter] DROP CONSTRAINT [FK_MailoutTypeMailoutTypeParameter];
GO
IF OBJECT_ID(N'[dbo].[FK_MailoutTypeParameterMailoutQueueParameterValue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutQueueParameterValue] DROP CONSTRAINT [FK_MailoutTypeParameterMailoutQueueParameterValue];
GO
IF OBJECT_ID(N'[dbo].[FK_OccupationPersonOccupation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonOccupation] DROP CONSTRAINT [FK_OccupationPersonOccupation];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonAttendance]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Attendance] DROP CONSTRAINT [FK_PersonAttendance];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonLog]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Log] DROP CONSTRAINT [FK_PersonLog];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonLogin]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Login] DROP CONSTRAINT [FK_PersonLogin];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonMailoutQueue]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MailoutQueue] DROP CONSTRAINT [FK_PersonMailoutQueue];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonAddress] DROP CONSTRAINT [FK_PersonPersonAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonEmail]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonEmail] DROP CONSTRAINT [FK_PersonPersonEmail];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonOccupation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonOccupation] DROP CONSTRAINT [FK_PersonPersonOccupation];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonPhone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonPhone] DROP CONSTRAINT [FK_PersonPersonPhone];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonSocialProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSocialProfile] DROP CONSTRAINT [FK_PersonPersonSocialProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPersonUpload]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonUpload] DROP CONSTRAINT [FK_PersonPersonUpload];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonPlayer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Member] DROP CONSTRAINT [FK_PersonPlayer];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonSecurityCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SecurityCode] DROP CONSTRAINT [FK_PersonSecurityCode];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK_PersonTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonTypeMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Member] DROP CONSTRAINT [FK_PersonTypeMember];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonTypePersonRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonRole] DROP CONSTRAINT [FK_PersonTypePersonRole];
GO
IF OBJECT_ID(N'[dbo].[FK_PhoneTypePersonPhone]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonPhone] DROP CONSTRAINT [FK_PhoneTypePersonPhone];
GO
IF OBJECT_ID(N'[dbo].[FK_RolePersonRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonRole] DROP CONSTRAINT [FK_RolePersonRole];
GO
IF OBJECT_ID(N'[dbo].[FK_SalutationPerson]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Person] DROP CONSTRAINT [FK_SalutationPerson];
GO
IF OBJECT_ID(N'[dbo].[FK_SecurityTypeSecurityCode]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SecurityCode] DROP CONSTRAINT [FK_SecurityTypeSecurityCode];
GO
IF OBJECT_ID(N'[dbo].[FK_SocialProfileTypePersonSocialProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonSocialProfile] DROP CONSTRAINT [FK_SocialProfileTypePersonSocialProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionTypeTransaction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Transaction] DROP CONSTRAINT [FK_TransactionTypeTransaction];
GO
IF OBJECT_ID(N'[dbo].[FK_UploadTypePersonUpload]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonUpload] DROP CONSTRAINT [FK_UploadTypePersonUpload];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AddressType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AddressType];
GO
IF OBJECT_ID(N'[dbo].[Attendance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Attendance];
GO
IF OBJECT_ID(N'[dbo].[Country]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Country];
GO
IF OBJECT_ID(N'[dbo].[EmailType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmailType];
GO
IF OBJECT_ID(N'[dbo].[JobTitle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[JobTitle];
GO
IF OBJECT_ID(N'[dbo].[Log]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log];
GO
IF OBJECT_ID(N'[dbo].[Login]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Login];
GO
IF OBJECT_ID(N'[dbo].[LogType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LogType];
GO
IF OBJECT_ID(N'[dbo].[MailoutParameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailoutParameter];
GO
IF OBJECT_ID(N'[dbo].[MailoutQueue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailoutQueue];
GO
IF OBJECT_ID(N'[dbo].[MailoutQueueParameterValue]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailoutQueueParameterValue];
GO
IF OBJECT_ID(N'[dbo].[MailoutTracker]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailoutTracker];
GO
IF OBJECT_ID(N'[dbo].[MailoutType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailoutType];
GO
IF OBJECT_ID(N'[dbo].[MailoutTypeParameter]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailoutTypeParameter];
GO
IF OBJECT_ID(N'[dbo].[Member]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Member];
GO
IF OBJECT_ID(N'[dbo].[Occupation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Occupation];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[PersonAddress]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonAddress];
GO
IF OBJECT_ID(N'[dbo].[PersonEmail]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonEmail];
GO
IF OBJECT_ID(N'[dbo].[PersonOccupation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonOccupation];
GO
IF OBJECT_ID(N'[dbo].[PersonPhone]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonPhone];
GO
IF OBJECT_ID(N'[dbo].[PersonRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonRole];
GO
IF OBJECT_ID(N'[dbo].[PersonSocialProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonSocialProfile];
GO
IF OBJECT_ID(N'[dbo].[PersonType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonType];
GO
IF OBJECT_ID(N'[dbo].[PersonUpload]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonUpload];
GO
IF OBJECT_ID(N'[dbo].[PhoneType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PhoneType];
GO
IF OBJECT_ID(N'[dbo].[Role]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role];
GO
IF OBJECT_ID(N'[dbo].[Salutation]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Salutation];
GO
IF OBJECT_ID(N'[dbo].[SecurityCode]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityCode];
GO
IF OBJECT_ID(N'[dbo].[SecurityType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SecurityType];
GO
IF OBJECT_ID(N'[dbo].[SocialProfileType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SocialProfileType];
GO
IF OBJECT_ID(N'[dbo].[Transaction]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Transaction];
GO
IF OBJECT_ID(N'[dbo].[TransactionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionType];
GO
IF OBJECT_ID(N'[dbo].[UploadType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UploadType];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AddressType'
CREATE TABLE [dbo].[AddressType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Attendance'
CREATE TABLE [dbo].[Attendance] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NOT NULL,
    [AttendanceDate] datetime  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'Country'
CREATE TABLE [dbo].[Country] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CountryCode] nvarchar(2)  NOT NULL,
    [EnglishName] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'EmailType'
CREATE TABLE [dbo].[EmailType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'JobTitle'
CREATE TABLE [dbo].[JobTitle] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Log'
CREATE TABLE [dbo].[Log] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LogTypeId] int  NOT NULL,
    [PersonId] int  NULL,
    [Description] nvarchar(max)  NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [dbo].[Login] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(15)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ModifiedOn] datetime  NULL,
    [LockedOn] datetime  NULL,
    [IsActive] bit  NOT NULL,
    [IsLock] bit  NOT NULL,
    [MustChangepassword] bit  NOT NULL,
    [Person_Id] int  NOT NULL
);
GO

-- Creating table 'LogType'
CREATE TABLE [dbo].[LogType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'MailoutParameter'
CREATE TABLE [dbo].[MailoutParameter] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'MailoutQueue'
CREATE TABLE [dbo].[MailoutQueue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Status] smallint  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [UpdateOn] datetime  NULL,
    [EmailAddress] nvarchar(200)  NOT NULL,
    [HtmlBody] nvarchar(max)  NOT NULL,
    [PersonId] int  NOT NULL,
    [MailoutTypeId] int  NOT NULL
);
GO

-- Creating table 'MailoutQueueParameterValue'
CREATE TABLE [dbo].[MailoutQueueParameterValue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NULL,
    [MailoutQueueId] int  NOT NULL,
    [MailoutTypeParameterId] int  NULL
);
GO

-- Creating table 'MailoutTracker'
CREATE TABLE [dbo].[MailoutTracker] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [IPAddress] nvarchar(50)  NOT NULL,
    [OpenedOn] datetime  NOT NULL,
    [MailoutQueueId] int  NOT NULL
);
GO

-- Creating table 'MailoutType'
CREATE TABLE [dbo].[MailoutType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Subject] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'MailoutTypeParameter'
CREATE TABLE [dbo].[MailoutTypeParameter] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [MailoutTypeId] int  NOT NULL,
    [MailoutParameterId] int  NOT NULL
);
GO

-- Creating table 'Member'
CREATE TABLE [dbo].[Member] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NOT NULL,
    [JoiningDate] datetime  NULL,
    [IsActive] bit  NOT NULL,
    [PersonTypeId] int  NOT NULL
);
GO

-- Creating table 'Occupation'
CREATE TABLE [dbo].[Occupation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fname] nvarchar(50)  NOT NULL,
    [Mname] nvarchar(50)  NOT NULL,
    [Lname] nvarchar(50)  NOT NULL,
    [DOB] datetime  NOT NULL,
    [GenderId] smallint  NOT NULL,
    [IsActive] bit  NOT NULL,
    [SalutationId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [IPAddress] nvarchar(max)  NULL,
    [GroupID] int  NULL
);
GO

-- Creating table 'PersonAddress'
CREATE TABLE [dbo].[PersonAddress] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AddressTypeId] int  NOT NULL,
    [CountryId] int  NOT NULL,
    [Line1] nvarchar(max)  NOT NULL,
    [Line2] nvarchar(max)  NULL,
    [State] nvarchar(100)  NOT NULL,
    [Landmark] nvarchar(max)  NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [City] nvarchar(50)  NOT NULL,
    [Postcode] nvarchar(10)  NOT NULL
);
GO

-- Creating table 'PersonEmail'
CREATE TABLE [dbo].[PersonEmail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(50)  NOT NULL,
    [EmailTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'PersonOccupation'
CREATE TABLE [dbo].[PersonOccupation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OccupationId] int  NOT NULL,
    [JobTitleId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [OrganizationName] nvarchar(max)  NULL,
    [OrganizationAddress] nvarchar(max)  NULL,
    [Fdate] datetime  NULL,
    [Tdate] datetime  NULL,
    [ReportingInformation] nvarchar(max)  NULL,
    [CreatedOn] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'PersonPhone'
CREATE TABLE [dbo].[PersonPhone] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PhoneTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Value] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'PersonRole'
CREATE TABLE [dbo].[PersonRole] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [RoleId] int  NOT NULL,
    [PersonTypeId] int  NOT NULL
);
GO

-- Creating table 'PersonSocialProfile'
CREATE TABLE [dbo].[PersonSocialProfile] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SocialProfileTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonType'
CREATE TABLE [dbo].[PersonType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'PersonUpload'
CREATE TABLE [dbo].[PersonUpload] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [UploadTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'PhoneType'
CREATE TABLE [dbo].[PhoneType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [dbo].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'Salutation'
CREATE TABLE [dbo].[Salutation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'SecurityCode'
CREATE TABLE [dbo].[SecurityCode] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ExpiredOn] datetime  NULL,
    [Code] nvarchar(20)  NOT NULL,
    [SecurityTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL
);
GO

-- Creating table 'SecurityType'
CREATE TABLE [dbo].[SecurityType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'SocialProfileType'
CREATE TABLE [dbo].[SocialProfileType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Transaction'
CREATE TABLE [dbo].[Transaction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransactionTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [Amount] decimal(18,4)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'TransactionType'
CREATE TABLE [dbo].[TransactionType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(5)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL,
    [Multiplier] decimal(18,4)  NOT NULL
);
GO

-- Creating table 'UploadType'
CREATE TABLE [dbo].[UploadType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AddressType'
ALTER TABLE [dbo].[AddressType]
ADD CONSTRAINT [PK_AddressType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attendance'
ALTER TABLE [dbo].[Attendance]
ADD CONSTRAINT [PK_Attendance]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Country'
ALTER TABLE [dbo].[Country]
ADD CONSTRAINT [PK_Country]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailType'
ALTER TABLE [dbo].[EmailType]
ADD CONSTRAINT [PK_EmailType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobTitle'
ALTER TABLE [dbo].[JobTitle]
ADD CONSTRAINT [PK_JobTitle]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogType'
ALTER TABLE [dbo].[LogType]
ADD CONSTRAINT [PK_LogType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutParameter'
ALTER TABLE [dbo].[MailoutParameter]
ADD CONSTRAINT [PK_MailoutParameter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutQueue'
ALTER TABLE [dbo].[MailoutQueue]
ADD CONSTRAINT [PK_MailoutQueue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutQueueParameterValue'
ALTER TABLE [dbo].[MailoutQueueParameterValue]
ADD CONSTRAINT [PK_MailoutQueueParameterValue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutTracker'
ALTER TABLE [dbo].[MailoutTracker]
ADD CONSTRAINT [PK_MailoutTracker]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutType'
ALTER TABLE [dbo].[MailoutType]
ADD CONSTRAINT [PK_MailoutType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutTypeParameter'
ALTER TABLE [dbo].[MailoutTypeParameter]
ADD CONSTRAINT [PK_MailoutTypeParameter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Member'
ALTER TABLE [dbo].[Member]
ADD CONSTRAINT [PK_Member]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Occupation'
ALTER TABLE [dbo].[Occupation]
ADD CONSTRAINT [PK_Occupation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonAddress'
ALTER TABLE [dbo].[PersonAddress]
ADD CONSTRAINT [PK_PersonAddress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonEmail'
ALTER TABLE [dbo].[PersonEmail]
ADD CONSTRAINT [PK_PersonEmail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonOccupation'
ALTER TABLE [dbo].[PersonOccupation]
ADD CONSTRAINT [PK_PersonOccupation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonPhone'
ALTER TABLE [dbo].[PersonPhone]
ADD CONSTRAINT [PK_PersonPhone]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonRole'
ALTER TABLE [dbo].[PersonRole]
ADD CONSTRAINT [PK_PersonRole]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSocialProfile'
ALTER TABLE [dbo].[PersonSocialProfile]
ADD CONSTRAINT [PK_PersonSocialProfile]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonType'
ALTER TABLE [dbo].[PersonType]
ADD CONSTRAINT [PK_PersonType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonUpload'
ALTER TABLE [dbo].[PersonUpload]
ADD CONSTRAINT [PK_PersonUpload]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhoneType'
ALTER TABLE [dbo].[PhoneType]
ADD CONSTRAINT [PK_PhoneType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [dbo].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Salutation'
ALTER TABLE [dbo].[Salutation]
ADD CONSTRAINT [PK_Salutation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecurityCode'
ALTER TABLE [dbo].[SecurityCode]
ADD CONSTRAINT [PK_SecurityCode]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecurityType'
ALTER TABLE [dbo].[SecurityType]
ADD CONSTRAINT [PK_SecurityType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SocialProfileType'
ALTER TABLE [dbo].[SocialProfileType]
ADD CONSTRAINT [PK_SocialProfileType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [PK_Transaction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionType'
ALTER TABLE [dbo].[TransactionType]
ADD CONSTRAINT [PK_TransactionType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UploadType'
ALTER TABLE [dbo].[UploadType]
ADD CONSTRAINT [PK_UploadType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AddressTypeId] in table 'PersonAddress'
ALTER TABLE [dbo].[PersonAddress]
ADD CONSTRAINT [FK_AddressTypePersonAddress]
    FOREIGN KEY ([AddressTypeId])
    REFERENCES [dbo].[AddressType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressTypePersonAddress'
CREATE INDEX [IX_FK_AddressTypePersonAddress]
ON [dbo].[PersonAddress]
    ([AddressTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Attendance'
ALTER TABLE [dbo].[Attendance]
ADD CONSTRAINT [FK_PersonAttendance]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonAttendance'
CREATE INDEX [IX_FK_PersonAttendance]
ON [dbo].[Attendance]
    ([PersonId]);
GO

-- Creating foreign key on [CountryId] in table 'PersonAddress'
ALTER TABLE [dbo].[PersonAddress]
ADD CONSTRAINT [FK_CountryPersonAddress]
    FOREIGN KEY ([CountryId])
    REFERENCES [dbo].[Country]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryPersonAddress'
CREATE INDEX [IX_FK_CountryPersonAddress]
ON [dbo].[PersonAddress]
    ([CountryId]);
GO

-- Creating foreign key on [EmailTypeId] in table 'PersonEmail'
ALTER TABLE [dbo].[PersonEmail]
ADD CONSTRAINT [FK_EmailTypePersonEmail]
    FOREIGN KEY ([EmailTypeId])
    REFERENCES [dbo].[EmailType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailTypePersonEmail'
CREATE INDEX [IX_FK_EmailTypePersonEmail]
ON [dbo].[PersonEmail]
    ([EmailTypeId]);
GO

-- Creating foreign key on [JobTitleId] in table 'PersonOccupation'
ALTER TABLE [dbo].[PersonOccupation]
ADD CONSTRAINT [FK_JobTitlePersonOccupation]
    FOREIGN KEY ([JobTitleId])
    REFERENCES [dbo].[JobTitle]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitlePersonOccupation'
CREATE INDEX [IX_FK_JobTitlePersonOccupation]
ON [dbo].[PersonOccupation]
    ([JobTitleId]);
GO

-- Creating foreign key on [LogTypeId] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [FK_LogTypeLog]
    FOREIGN KEY ([LogTypeId])
    REFERENCES [dbo].[LogType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogTypeLog'
CREATE INDEX [IX_FK_LogTypeLog]
ON [dbo].[Log]
    ([LogTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Log'
ALTER TABLE [dbo].[Log]
ADD CONSTRAINT [FK_PersonLog]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonLog'
CREATE INDEX [IX_FK_PersonLog]
ON [dbo].[Log]
    ([PersonId]);
GO

-- Creating foreign key on [Person_Id] in table 'Login'
ALTER TABLE [dbo].[Login]
ADD CONSTRAINT [FK_PersonLogin]
    FOREIGN KEY ([Person_Id])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonLogin'
CREATE INDEX [IX_FK_PersonLogin]
ON [dbo].[Login]
    ([Person_Id]);
GO

-- Creating foreign key on [MailoutParameterId] in table 'MailoutTypeParameter'
ALTER TABLE [dbo].[MailoutTypeParameter]
ADD CONSTRAINT [FK_MailoutParameterMailoutTypeParameter]
    FOREIGN KEY ([MailoutParameterId])
    REFERENCES [dbo].[MailoutParameter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutParameterMailoutTypeParameter'
CREATE INDEX [IX_FK_MailoutParameterMailoutTypeParameter]
ON [dbo].[MailoutTypeParameter]
    ([MailoutParameterId]);
GO

-- Creating foreign key on [MailoutQueueId] in table 'MailoutQueueParameterValue'
ALTER TABLE [dbo].[MailoutQueueParameterValue]
ADD CONSTRAINT [FK_MailoutQueueMailoutQueueParameterValue]
    FOREIGN KEY ([MailoutQueueId])
    REFERENCES [dbo].[MailoutQueue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutQueueMailoutQueueParameterValue'
CREATE INDEX [IX_FK_MailoutQueueMailoutQueueParameterValue]
ON [dbo].[MailoutQueueParameterValue]
    ([MailoutQueueId]);
GO

-- Creating foreign key on [MailoutQueueId] in table 'MailoutTracker'
ALTER TABLE [dbo].[MailoutTracker]
ADD CONSTRAINT [FK_MailoutQueueMailoutTracker]
    FOREIGN KEY ([MailoutQueueId])
    REFERENCES [dbo].[MailoutQueue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutQueueMailoutTracker'
CREATE INDEX [IX_FK_MailoutQueueMailoutTracker]
ON [dbo].[MailoutTracker]
    ([MailoutQueueId]);
GO

-- Creating foreign key on [MailoutTypeId] in table 'MailoutQueue'
ALTER TABLE [dbo].[MailoutQueue]
ADD CONSTRAINT [FK_MailoutTypeMailoutQueue]
    FOREIGN KEY ([MailoutTypeId])
    REFERENCES [dbo].[MailoutType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutTypeMailoutQueue'
CREATE INDEX [IX_FK_MailoutTypeMailoutQueue]
ON [dbo].[MailoutQueue]
    ([MailoutTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'MailoutQueue'
ALTER TABLE [dbo].[MailoutQueue]
ADD CONSTRAINT [FK_PersonMailoutQueue]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMailoutQueue'
CREATE INDEX [IX_FK_PersonMailoutQueue]
ON [dbo].[MailoutQueue]
    ([PersonId]);
GO

-- Creating foreign key on [MailoutTypeParameterId] in table 'MailoutQueueParameterValue'
ALTER TABLE [dbo].[MailoutQueueParameterValue]
ADD CONSTRAINT [FK_MailoutTypeParameterMailoutQueueParameterValue]
    FOREIGN KEY ([MailoutTypeParameterId])
    REFERENCES [dbo].[MailoutTypeParameter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutTypeParameterMailoutQueueParameterValue'
CREATE INDEX [IX_FK_MailoutTypeParameterMailoutQueueParameterValue]
ON [dbo].[MailoutQueueParameterValue]
    ([MailoutTypeParameterId]);
GO

-- Creating foreign key on [MailoutTypeId] in table 'MailoutTypeParameter'
ALTER TABLE [dbo].[MailoutTypeParameter]
ADD CONSTRAINT [FK_MailoutTypeMailoutTypeParameter]
    FOREIGN KEY ([MailoutTypeId])
    REFERENCES [dbo].[MailoutType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutTypeMailoutTypeParameter'
CREATE INDEX [IX_FK_MailoutTypeMailoutTypeParameter]
ON [dbo].[MailoutTypeParameter]
    ([MailoutTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Member'
ALTER TABLE [dbo].[Member]
ADD CONSTRAINT [FK_PersonPlayer]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPlayer'
CREATE INDEX [IX_FK_PersonPlayer]
ON [dbo].[Member]
    ([PersonId]);
GO

-- Creating foreign key on [PersonTypeId] in table 'Member'
ALTER TABLE [dbo].[Member]
ADD CONSTRAINT [FK_PersonTypeMember]
    FOREIGN KEY ([PersonTypeId])
    REFERENCES [dbo].[PersonType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTypeMember'
CREATE INDEX [IX_FK_PersonTypeMember]
ON [dbo].[Member]
    ([PersonTypeId]);
GO

-- Creating foreign key on [OccupationId] in table 'PersonOccupation'
ALTER TABLE [dbo].[PersonOccupation]
ADD CONSTRAINT [FK_OccupationPersonOccupation]
    FOREIGN KEY ([OccupationId])
    REFERENCES [dbo].[Occupation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OccupationPersonOccupation'
CREATE INDEX [IX_FK_OccupationPersonOccupation]
ON [dbo].[PersonOccupation]
    ([OccupationId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonAddress'
ALTER TABLE [dbo].[PersonAddress]
ADD CONSTRAINT [FK_PersonPersonAddress]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonAddress'
CREATE INDEX [IX_FK_PersonPersonAddress]
ON [dbo].[PersonAddress]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonEmail'
ALTER TABLE [dbo].[PersonEmail]
ADD CONSTRAINT [FK_PersonPersonEmail]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonEmail'
CREATE INDEX [IX_FK_PersonPersonEmail]
ON [dbo].[PersonEmail]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonOccupation'
ALTER TABLE [dbo].[PersonOccupation]
ADD CONSTRAINT [FK_PersonPersonOccupation]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonOccupation'
CREATE INDEX [IX_FK_PersonPersonOccupation]
ON [dbo].[PersonOccupation]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonPhone'
ALTER TABLE [dbo].[PersonPhone]
ADD CONSTRAINT [FK_PersonPersonPhone]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonPhone'
CREATE INDEX [IX_FK_PersonPersonPhone]
ON [dbo].[PersonPhone]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonSocialProfile'
ALTER TABLE [dbo].[PersonSocialProfile]
ADD CONSTRAINT [FK_PersonPersonSocialProfile]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonSocialProfile'
CREATE INDEX [IX_FK_PersonPersonSocialProfile]
ON [dbo].[PersonSocialProfile]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonUpload'
ALTER TABLE [dbo].[PersonUpload]
ADD CONSTRAINT [FK_PersonPersonUpload]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonUpload'
CREATE INDEX [IX_FK_PersonPersonUpload]
ON [dbo].[PersonUpload]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'SecurityCode'
ALTER TABLE [dbo].[SecurityCode]
ADD CONSTRAINT [FK_PersonSecurityCode]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonSecurityCode'
CREATE INDEX [IX_FK_PersonSecurityCode]
ON [dbo].[SecurityCode]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [FK_PersonTransaction]
    FOREIGN KEY ([PersonId])
    REFERENCES [dbo].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTransaction'
CREATE INDEX [IX_FK_PersonTransaction]
ON [dbo].[Transaction]
    ([PersonId]);
GO

-- Creating foreign key on [SalutationId] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [FK_SalutationPerson]
    FOREIGN KEY ([SalutationId])
    REFERENCES [dbo].[Salutation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalutationPerson'
CREATE INDEX [IX_FK_SalutationPerson]
ON [dbo].[Person]
    ([SalutationId]);
GO

-- Creating foreign key on [PhoneTypeId] in table 'PersonPhone'
ALTER TABLE [dbo].[PersonPhone]
ADD CONSTRAINT [FK_PhoneTypePersonPhone]
    FOREIGN KEY ([PhoneTypeId])
    REFERENCES [dbo].[PhoneType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhoneTypePersonPhone'
CREATE INDEX [IX_FK_PhoneTypePersonPhone]
ON [dbo].[PersonPhone]
    ([PhoneTypeId]);
GO

-- Creating foreign key on [PersonTypeId] in table 'PersonRole'
ALTER TABLE [dbo].[PersonRole]
ADD CONSTRAINT [FK_PersonTypePersonRole]
    FOREIGN KEY ([PersonTypeId])
    REFERENCES [dbo].[PersonType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTypePersonRole'
CREATE INDEX [IX_FK_PersonTypePersonRole]
ON [dbo].[PersonRole]
    ([PersonTypeId]);
GO

-- Creating foreign key on [RoleId] in table 'PersonRole'
ALTER TABLE [dbo].[PersonRole]
ADD CONSTRAINT [FK_RolePersonRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePersonRole'
CREATE INDEX [IX_FK_RolePersonRole]
ON [dbo].[PersonRole]
    ([RoleId]);
GO

-- Creating foreign key on [SocialProfileTypeId] in table 'PersonSocialProfile'
ALTER TABLE [dbo].[PersonSocialProfile]
ADD CONSTRAINT [FK_SocialProfileTypePersonSocialProfile]
    FOREIGN KEY ([SocialProfileTypeId])
    REFERENCES [dbo].[SocialProfileType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SocialProfileTypePersonSocialProfile'
CREATE INDEX [IX_FK_SocialProfileTypePersonSocialProfile]
ON [dbo].[PersonSocialProfile]
    ([SocialProfileTypeId]);
GO

-- Creating foreign key on [UploadTypeId] in table 'PersonUpload'
ALTER TABLE [dbo].[PersonUpload]
ADD CONSTRAINT [FK_UploadTypePersonUpload]
    FOREIGN KEY ([UploadTypeId])
    REFERENCES [dbo].[UploadType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UploadTypePersonUpload'
CREATE INDEX [IX_FK_UploadTypePersonUpload]
ON [dbo].[PersonUpload]
    ([UploadTypeId]);
GO

-- Creating foreign key on [SecurityTypeId] in table 'SecurityCode'
ALTER TABLE [dbo].[SecurityCode]
ADD CONSTRAINT [FK_SecurityTypeSecurityCode]
    FOREIGN KEY ([SecurityTypeId])
    REFERENCES [dbo].[SecurityType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SecurityTypeSecurityCode'
CREATE INDEX [IX_FK_SecurityTypeSecurityCode]
ON [dbo].[SecurityCode]
    ([SecurityTypeId]);
GO

-- Creating foreign key on [TransactionTypeId] in table 'Transaction'
ALTER TABLE [dbo].[Transaction]
ADD CONSTRAINT [FK_TransactionTypeTransaction]
    FOREIGN KEY ([TransactionTypeId])
    REFERENCES [dbo].[TransactionType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionTypeTransaction'
CREATE INDEX [IX_FK_TransactionTypeTransaction]
ON [dbo].[Transaction]
    ([TransactionTypeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------