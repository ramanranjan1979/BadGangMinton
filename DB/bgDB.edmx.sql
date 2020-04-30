
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/04/2020 19:33:15
-- Generated from EDMX file: D:\Visual Studio 2019\BadGangMinton\BadGangMinton\BadGangMinton\DB\bgDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [BGDB];
GO
IF SCHEMA_ID(N'BG') IS NULL EXECUTE(N'CREATE SCHEMA [BG]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[BG].[FK_EmailTypePersonEmail]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonEmail] DROP CONSTRAINT [FK_EmailTypePersonEmail];
GO
IF OBJECT_ID(N'[BG].[FK_PhoneTypePersonPhone]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonPhone] DROP CONSTRAINT [FK_PhoneTypePersonPhone];
GO
IF OBJECT_ID(N'[BG].[FK_AddressTypePersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonAddress] DROP CONSTRAINT [FK_AddressTypePersonAddress];
GO
IF OBJECT_ID(N'[BG].[FK_UploadTypePersonUpload]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonUpload] DROP CONSTRAINT [FK_UploadTypePersonUpload];
GO
IF OBJECT_ID(N'[BG].[FK_OccupationPersonOccupation]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonOccupation] DROP CONSTRAINT [FK_OccupationPersonOccupation];
GO
IF OBJECT_ID(N'[BG].[FK_CountryPersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonAddress] DROP CONSTRAINT [FK_CountryPersonAddress];
GO
IF OBJECT_ID(N'[BG].[FK_SalutationPerson]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Person] DROP CONSTRAINT [FK_SalutationPerson];
GO
IF OBJECT_ID(N'[BG].[FK_SocialProfileTypePersonSocialProfile]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonSocialProfile] DROP CONSTRAINT [FK_SocialProfileTypePersonSocialProfile];
GO
IF OBJECT_ID(N'[BG].[FK_JobTitlePersonOccupation]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonOccupation] DROP CONSTRAINT [FK_JobTitlePersonOccupation];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPersonAddress]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonAddress] DROP CONSTRAINT [FK_PersonPersonAddress];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPersonEmail]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonEmail] DROP CONSTRAINT [FK_PersonPersonEmail];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPersonOccupation]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonOccupation] DROP CONSTRAINT [FK_PersonPersonOccupation];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPersonPhone]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonPhone] DROP CONSTRAINT [FK_PersonPersonPhone];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPersonSocialProfile]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonSocialProfile] DROP CONSTRAINT [FK_PersonPersonSocialProfile];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPersonUpload]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonUpload] DROP CONSTRAINT [FK_PersonPersonUpload];
GO
IF OBJECT_ID(N'[BG].[FK_LogTypeLog]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Log] DROP CONSTRAINT [FK_LogTypeLog];
GO
IF OBJECT_ID(N'[BG].[FK_PersonLog]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Log] DROP CONSTRAINT [FK_PersonLog];
GO
IF OBJECT_ID(N'[BG].[FK_TransactionTypeTransaction]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Transaction] DROP CONSTRAINT [FK_TransactionTypeTransaction];
GO
IF OBJECT_ID(N'[BG].[FK_PersonTransaction]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Transaction] DROP CONSTRAINT [FK_PersonTransaction];
GO
IF OBJECT_ID(N'[BG].[FK_PersonPlayer]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Member] DROP CONSTRAINT [FK_PersonPlayer];
GO
IF OBJECT_ID(N'[BG].[FK_PersonLogin]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Login] DROP CONSTRAINT [FK_PersonLogin];
GO
IF OBJECT_ID(N'[BG].[FK_RolePersonRole]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonRole] DROP CONSTRAINT [FK_RolePersonRole];
GO
IF OBJECT_ID(N'[BG].[FK_PersonTypeMember]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Member] DROP CONSTRAINT [FK_PersonTypeMember];
GO
IF OBJECT_ID(N'[BG].[FK_PersonTypePersonRole]', 'F') IS NOT NULL
    ALTER TABLE [BG].[PersonRole] DROP CONSTRAINT [FK_PersonTypePersonRole];
GO
IF OBJECT_ID(N'[BG].[FK_PersonMailoutQueue]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutQueue] DROP CONSTRAINT [FK_PersonMailoutQueue];
GO
IF OBJECT_ID(N'[BG].[FK_MailoutTypeMailoutQueue]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutQueue] DROP CONSTRAINT [FK_MailoutTypeMailoutQueue];
GO
IF OBJECT_ID(N'[BG].[FK_MailoutTypeMailoutTypeParameter]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutTypeParameter] DROP CONSTRAINT [FK_MailoutTypeMailoutTypeParameter];
GO
IF OBJECT_ID(N'[BG].[FK_MailoutParameterMailoutTypeParameter]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutTypeParameter] DROP CONSTRAINT [FK_MailoutParameterMailoutTypeParameter];
GO
IF OBJECT_ID(N'[BG].[FK_MailoutQueueMailoutQueueParameterValue]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutQueueParameterValue] DROP CONSTRAINT [FK_MailoutQueueMailoutQueueParameterValue];
GO
IF OBJECT_ID(N'[BG].[FK_MailoutTypeParameterMailoutQueueParameterValue]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutQueueParameterValue] DROP CONSTRAINT [FK_MailoutTypeParameterMailoutQueueParameterValue];
GO
IF OBJECT_ID(N'[BG].[FK_MailoutQueueMailoutTracker]', 'F') IS NOT NULL
    ALTER TABLE [BG].[MailoutTracker] DROP CONSTRAINT [FK_MailoutQueueMailoutTracker];
GO
IF OBJECT_ID(N'[BG].[FK_PersonAttendance]', 'F') IS NOT NULL
    ALTER TABLE [BG].[Attendance] DROP CONSTRAINT [FK_PersonAttendance];
GO
IF OBJECT_ID(N'[BG].[FK_SecurityTypeSecurityCode]', 'F') IS NOT NULL
    ALTER TABLE [BG].[SecurityCode] DROP CONSTRAINT [FK_SecurityTypeSecurityCode];
GO
IF OBJECT_ID(N'[BG].[FK_PersonSecurityCode]', 'F') IS NOT NULL
    ALTER TABLE [BG].[SecurityCode] DROP CONSTRAINT [FK_PersonSecurityCode];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[BG].[Country]', 'U') IS NOT NULL
    DROP TABLE [BG].[Country];
GO
IF OBJECT_ID(N'[BG].[LogType]', 'U') IS NOT NULL
    DROP TABLE [BG].[LogType];
GO
IF OBJECT_ID(N'[BG].[EmailType]', 'U') IS NOT NULL
    DROP TABLE [BG].[EmailType];
GO
IF OBJECT_ID(N'[BG].[AddressType]', 'U') IS NOT NULL
    DROP TABLE [BG].[AddressType];
GO
IF OBJECT_ID(N'[BG].[PhoneType]', 'U') IS NOT NULL
    DROP TABLE [BG].[PhoneType];
GO
IF OBJECT_ID(N'[BG].[Person]', 'U') IS NOT NULL
    DROP TABLE [BG].[Person];
GO
IF OBJECT_ID(N'[BG].[Member]', 'U') IS NOT NULL
    DROP TABLE [BG].[Member];
GO
IF OBJECT_ID(N'[BG].[Salutation]', 'U') IS NOT NULL
    DROP TABLE [BG].[Salutation];
GO
IF OBJECT_ID(N'[BG].[Occupation]', 'U') IS NOT NULL
    DROP TABLE [BG].[Occupation];
GO
IF OBJECT_ID(N'[BG].[JobTitle]', 'U') IS NOT NULL
    DROP TABLE [BG].[JobTitle];
GO
IF OBJECT_ID(N'[BG].[TransactionType]', 'U') IS NOT NULL
    DROP TABLE [BG].[TransactionType];
GO
IF OBJECT_ID(N'[BG].[UploadType]', 'U') IS NOT NULL
    DROP TABLE [BG].[UploadType];
GO
IF OBJECT_ID(N'[BG].[PersonUpload]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonUpload];
GO
IF OBJECT_ID(N'[BG].[SocialProfileType]', 'U') IS NOT NULL
    DROP TABLE [BG].[SocialProfileType];
GO
IF OBJECT_ID(N'[BG].[PersonSocialProfile]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonSocialProfile];
GO
IF OBJECT_ID(N'[BG].[PersonPhone]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonPhone];
GO
IF OBJECT_ID(N'[BG].[PersonEmail]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonEmail];
GO
IF OBJECT_ID(N'[BG].[PersonAddress]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonAddress];
GO
IF OBJECT_ID(N'[BG].[PersonOccupation]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonOccupation];
GO
IF OBJECT_ID(N'[BG].[Log]', 'U') IS NOT NULL
    DROP TABLE [BG].[Log];
GO
IF OBJECT_ID(N'[BG].[Transaction]', 'U') IS NOT NULL
    DROP TABLE [BG].[Transaction];
GO
IF OBJECT_ID(N'[BG].[Login]', 'U') IS NOT NULL
    DROP TABLE [BG].[Login];
GO
IF OBJECT_ID(N'[BG].[PersonRole]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonRole];
GO
IF OBJECT_ID(N'[BG].[Role]', 'U') IS NOT NULL
    DROP TABLE [BG].[Role];
GO
IF OBJECT_ID(N'[BG].[PersonType]', 'U') IS NOT NULL
    DROP TABLE [BG].[PersonType];
GO
IF OBJECT_ID(N'[BG].[MailoutQueue]', 'U') IS NOT NULL
    DROP TABLE [BG].[MailoutQueue];
GO
IF OBJECT_ID(N'[BG].[MailoutType]', 'U') IS NOT NULL
    DROP TABLE [BG].[MailoutType];
GO
IF OBJECT_ID(N'[BG].[MailoutParameter]', 'U') IS NOT NULL
    DROP TABLE [BG].[MailoutParameter];
GO
IF OBJECT_ID(N'[BG].[MailoutTypeParameter]', 'U') IS NOT NULL
    DROP TABLE [BG].[MailoutTypeParameter];
GO
IF OBJECT_ID(N'[BG].[MailoutQueueParameterValue]', 'U') IS NOT NULL
    DROP TABLE [BG].[MailoutQueueParameterValue];
GO
IF OBJECT_ID(N'[BG].[MailoutTracker]', 'U') IS NOT NULL
    DROP TABLE [BG].[MailoutTracker];
GO
IF OBJECT_ID(N'[BG].[Attendance]', 'U') IS NOT NULL
    DROP TABLE [BG].[Attendance];
GO
IF OBJECT_ID(N'[BG].[SecurityType]', 'U') IS NOT NULL
    DROP TABLE [BG].[SecurityType];
GO
IF OBJECT_ID(N'[BG].[SecurityCode]', 'U') IS NOT NULL
    DROP TABLE [BG].[SecurityCode];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Country'
CREATE TABLE [BG].[Country] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CountryCode] nvarchar(2)  NOT NULL,
    [EnglishName] nvarchar(50)  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'LogType'
CREATE TABLE [BG].[LogType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'EmailType'
CREATE TABLE [BG].[EmailType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AddressType'
CREATE TABLE [BG].[AddressType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'PhoneType'
CREATE TABLE [BG].[PhoneType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [BG].[Person] (
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

-- Creating table 'Member'
CREATE TABLE [BG].[Member] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NOT NULL,
    [JoiningDate] datetime  NULL,
    [IsActive] bit  NOT NULL,
    [PersonTypeId] int  NOT NULL
);
GO

-- Creating table 'Salutation'
CREATE TABLE [BG].[Salutation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Occupation'
CREATE TABLE [BG].[Occupation] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'JobTitle'
CREATE TABLE [BG].[JobTitle] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'TransactionType'
CREATE TABLE [BG].[TransactionType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(5)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL,
    [Multiplier] decimal(18,4)  NOT NULL
);
GO

-- Creating table 'UploadType'
CREATE TABLE [BG].[UploadType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'PersonUpload'
CREATE TABLE [BG].[PersonUpload] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(max)  NOT NULL,
    [UploadTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'SocialProfileType'
CREATE TABLE [BG].[SocialProfileType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'PersonSocialProfile'
CREATE TABLE [BG].[PersonSocialProfile] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SocialProfileTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PersonPhone'
CREATE TABLE [BG].[PersonPhone] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PhoneTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Value] nvarchar(15)  NOT NULL
);
GO

-- Creating table 'PersonEmail'
CREATE TABLE [BG].[PersonEmail] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(50)  NOT NULL,
    [EmailTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'PersonAddress'
CREATE TABLE [BG].[PersonAddress] (
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

-- Creating table 'PersonOccupation'
CREATE TABLE [BG].[PersonOccupation] (
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

-- Creating table 'Log'
CREATE TABLE [BG].[Log] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LogTypeId] int  NOT NULL,
    [PersonId] int  NULL,
    [Description] nvarchar(max)  NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'Transaction'
CREATE TABLE [BG].[Transaction] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TransactionTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL,
    [Amount] decimal(18,4)  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [IsActive] bit  NULL
);
GO

-- Creating table 'Login'
CREATE TABLE [BG].[Login] (
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

-- Creating table 'PersonRole'
CREATE TABLE [BG].[PersonRole] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [RoleId] int  NOT NULL,
    [PersonTypeId] int  NOT NULL
);
GO

-- Creating table 'Role'
CREATE TABLE [BG].[Role] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [CreatedOn] datetime  NOT NULL
);
GO

-- Creating table 'PersonType'
CREATE TABLE [BG].[PersonType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'MailoutQueue'
CREATE TABLE [BG].[MailoutQueue] (
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

-- Creating table 'MailoutType'
CREATE TABLE [BG].[MailoutType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [IsActive] bit  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [Subject] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'MailoutParameter'
CREATE TABLE [BG].[MailoutParameter] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'MailoutTypeParameter'
CREATE TABLE [BG].[MailoutTypeParameter] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IsActive] bit  NOT NULL,
    [MailoutTypeId] int  NOT NULL,
    [MailoutParameterId] int  NOT NULL
);
GO

-- Creating table 'MailoutQueueParameterValue'
CREATE TABLE [BG].[MailoutQueueParameterValue] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] nvarchar(max)  NULL,
    [MailoutQueueId] int  NOT NULL,
    [MailoutTypeParameterId] int  NULL
);
GO

-- Creating table 'MailoutTracker'
CREATE TABLE [BG].[MailoutTracker] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [IPAddress] nvarchar(50)  NOT NULL,
    [OpenedOn] datetime  NOT NULL,
    [MailoutQueueId] int  NOT NULL
);
GO

-- Creating table 'Attendance'
CREATE TABLE [BG].[Attendance] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int  NOT NULL,
    [AttendanceDate] datetime  NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [IsActive] bit  NOT NULL
);
GO

-- Creating table 'SecurityType'
CREATE TABLE [BG].[SecurityType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(20)  NOT NULL
);
GO

-- Creating table 'SecurityCode'
CREATE TABLE [BG].[SecurityCode] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CreatedOn] datetime  NOT NULL,
    [ExpiredOn] datetime  NULL,
    [Code] nvarchar(20)  NOT NULL,
    [SecurityTypeId] int  NOT NULL,
    [PersonId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Country'
ALTER TABLE [BG].[Country]
ADD CONSTRAINT [PK_Country]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogType'
ALTER TABLE [BG].[LogType]
ADD CONSTRAINT [PK_LogType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'EmailType'
ALTER TABLE [BG].[EmailType]
ADD CONSTRAINT [PK_EmailType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AddressType'
ALTER TABLE [BG].[AddressType]
ADD CONSTRAINT [PK_AddressType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PhoneType'
ALTER TABLE [BG].[PhoneType]
ADD CONSTRAINT [PK_PhoneType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Person'
ALTER TABLE [BG].[Person]
ADD CONSTRAINT [PK_Person]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Member'
ALTER TABLE [BG].[Member]
ADD CONSTRAINT [PK_Member]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Salutation'
ALTER TABLE [BG].[Salutation]
ADD CONSTRAINT [PK_Salutation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Occupation'
ALTER TABLE [BG].[Occupation]
ADD CONSTRAINT [PK_Occupation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'JobTitle'
ALTER TABLE [BG].[JobTitle]
ADD CONSTRAINT [PK_JobTitle]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionType'
ALTER TABLE [BG].[TransactionType]
ADD CONSTRAINT [PK_TransactionType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UploadType'
ALTER TABLE [BG].[UploadType]
ADD CONSTRAINT [PK_UploadType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonUpload'
ALTER TABLE [BG].[PersonUpload]
ADD CONSTRAINT [PK_PersonUpload]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SocialProfileType'
ALTER TABLE [BG].[SocialProfileType]
ADD CONSTRAINT [PK_SocialProfileType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonSocialProfile'
ALTER TABLE [BG].[PersonSocialProfile]
ADD CONSTRAINT [PK_PersonSocialProfile]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonPhone'
ALTER TABLE [BG].[PersonPhone]
ADD CONSTRAINT [PK_PersonPhone]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonEmail'
ALTER TABLE [BG].[PersonEmail]
ADD CONSTRAINT [PK_PersonEmail]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonAddress'
ALTER TABLE [BG].[PersonAddress]
ADD CONSTRAINT [PK_PersonAddress]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonOccupation'
ALTER TABLE [BG].[PersonOccupation]
ADD CONSTRAINT [PK_PersonOccupation]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Log'
ALTER TABLE [BG].[Log]
ADD CONSTRAINT [PK_Log]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Transaction'
ALTER TABLE [BG].[Transaction]
ADD CONSTRAINT [PK_Transaction]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Login'
ALTER TABLE [BG].[Login]
ADD CONSTRAINT [PK_Login]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonRole'
ALTER TABLE [BG].[PersonRole]
ADD CONSTRAINT [PK_PersonRole]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role'
ALTER TABLE [BG].[Role]
ADD CONSTRAINT [PK_Role]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PersonType'
ALTER TABLE [BG].[PersonType]
ADD CONSTRAINT [PK_PersonType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutQueue'
ALTER TABLE [BG].[MailoutQueue]
ADD CONSTRAINT [PK_MailoutQueue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutType'
ALTER TABLE [BG].[MailoutType]
ADD CONSTRAINT [PK_MailoutType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutParameter'
ALTER TABLE [BG].[MailoutParameter]
ADD CONSTRAINT [PK_MailoutParameter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutTypeParameter'
ALTER TABLE [BG].[MailoutTypeParameter]
ADD CONSTRAINT [PK_MailoutTypeParameter]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutQueueParameterValue'
ALTER TABLE [BG].[MailoutQueueParameterValue]
ADD CONSTRAINT [PK_MailoutQueueParameterValue]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailoutTracker'
ALTER TABLE [BG].[MailoutTracker]
ADD CONSTRAINT [PK_MailoutTracker]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Attendance'
ALTER TABLE [BG].[Attendance]
ADD CONSTRAINT [PK_Attendance]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecurityType'
ALTER TABLE [BG].[SecurityType]
ADD CONSTRAINT [PK_SecurityType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SecurityCode'
ALTER TABLE [BG].[SecurityCode]
ADD CONSTRAINT [PK_SecurityCode]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [EmailTypeId] in table 'PersonEmail'
ALTER TABLE [BG].[PersonEmail]
ADD CONSTRAINT [FK_EmailTypePersonEmail]
    FOREIGN KEY ([EmailTypeId])
    REFERENCES [BG].[EmailType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmailTypePersonEmail'
CREATE INDEX [IX_FK_EmailTypePersonEmail]
ON [BG].[PersonEmail]
    ([EmailTypeId]);
GO

-- Creating foreign key on [PhoneTypeId] in table 'PersonPhone'
ALTER TABLE [BG].[PersonPhone]
ADD CONSTRAINT [FK_PhoneTypePersonPhone]
    FOREIGN KEY ([PhoneTypeId])
    REFERENCES [BG].[PhoneType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PhoneTypePersonPhone'
CREATE INDEX [IX_FK_PhoneTypePersonPhone]
ON [BG].[PersonPhone]
    ([PhoneTypeId]);
GO

-- Creating foreign key on [AddressTypeId] in table 'PersonAddress'
ALTER TABLE [BG].[PersonAddress]
ADD CONSTRAINT [FK_AddressTypePersonAddress]
    FOREIGN KEY ([AddressTypeId])
    REFERENCES [BG].[AddressType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AddressTypePersonAddress'
CREATE INDEX [IX_FK_AddressTypePersonAddress]
ON [BG].[PersonAddress]
    ([AddressTypeId]);
GO

-- Creating foreign key on [UploadTypeId] in table 'PersonUpload'
ALTER TABLE [BG].[PersonUpload]
ADD CONSTRAINT [FK_UploadTypePersonUpload]
    FOREIGN KEY ([UploadTypeId])
    REFERENCES [BG].[UploadType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UploadTypePersonUpload'
CREATE INDEX [IX_FK_UploadTypePersonUpload]
ON [BG].[PersonUpload]
    ([UploadTypeId]);
GO

-- Creating foreign key on [OccupationId] in table 'PersonOccupation'
ALTER TABLE [BG].[PersonOccupation]
ADD CONSTRAINT [FK_OccupationPersonOccupation]
    FOREIGN KEY ([OccupationId])
    REFERENCES [BG].[Occupation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OccupationPersonOccupation'
CREATE INDEX [IX_FK_OccupationPersonOccupation]
ON [BG].[PersonOccupation]
    ([OccupationId]);
GO

-- Creating foreign key on [CountryId] in table 'PersonAddress'
ALTER TABLE [BG].[PersonAddress]
ADD CONSTRAINT [FK_CountryPersonAddress]
    FOREIGN KEY ([CountryId])
    REFERENCES [BG].[Country]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CountryPersonAddress'
CREATE INDEX [IX_FK_CountryPersonAddress]
ON [BG].[PersonAddress]
    ([CountryId]);
GO

-- Creating foreign key on [SalutationId] in table 'Person'
ALTER TABLE [BG].[Person]
ADD CONSTRAINT [FK_SalutationPerson]
    FOREIGN KEY ([SalutationId])
    REFERENCES [BG].[Salutation]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SalutationPerson'
CREATE INDEX [IX_FK_SalutationPerson]
ON [BG].[Person]
    ([SalutationId]);
GO

-- Creating foreign key on [SocialProfileTypeId] in table 'PersonSocialProfile'
ALTER TABLE [BG].[PersonSocialProfile]
ADD CONSTRAINT [FK_SocialProfileTypePersonSocialProfile]
    FOREIGN KEY ([SocialProfileTypeId])
    REFERENCES [BG].[SocialProfileType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SocialProfileTypePersonSocialProfile'
CREATE INDEX [IX_FK_SocialProfileTypePersonSocialProfile]
ON [BG].[PersonSocialProfile]
    ([SocialProfileTypeId]);
GO

-- Creating foreign key on [JobTitleId] in table 'PersonOccupation'
ALTER TABLE [BG].[PersonOccupation]
ADD CONSTRAINT [FK_JobTitlePersonOccupation]
    FOREIGN KEY ([JobTitleId])
    REFERENCES [BG].[JobTitle]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_JobTitlePersonOccupation'
CREATE INDEX [IX_FK_JobTitlePersonOccupation]
ON [BG].[PersonOccupation]
    ([JobTitleId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonAddress'
ALTER TABLE [BG].[PersonAddress]
ADD CONSTRAINT [FK_PersonPersonAddress]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonAddress'
CREATE INDEX [IX_FK_PersonPersonAddress]
ON [BG].[PersonAddress]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonEmail'
ALTER TABLE [BG].[PersonEmail]
ADD CONSTRAINT [FK_PersonPersonEmail]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonEmail'
CREATE INDEX [IX_FK_PersonPersonEmail]
ON [BG].[PersonEmail]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonOccupation'
ALTER TABLE [BG].[PersonOccupation]
ADD CONSTRAINT [FK_PersonPersonOccupation]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonOccupation'
CREATE INDEX [IX_FK_PersonPersonOccupation]
ON [BG].[PersonOccupation]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonPhone'
ALTER TABLE [BG].[PersonPhone]
ADD CONSTRAINT [FK_PersonPersonPhone]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonPhone'
CREATE INDEX [IX_FK_PersonPersonPhone]
ON [BG].[PersonPhone]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonSocialProfile'
ALTER TABLE [BG].[PersonSocialProfile]
ADD CONSTRAINT [FK_PersonPersonSocialProfile]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonSocialProfile'
CREATE INDEX [IX_FK_PersonPersonSocialProfile]
ON [BG].[PersonSocialProfile]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'PersonUpload'
ALTER TABLE [BG].[PersonUpload]
ADD CONSTRAINT [FK_PersonPersonUpload]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPersonUpload'
CREATE INDEX [IX_FK_PersonPersonUpload]
ON [BG].[PersonUpload]
    ([PersonId]);
GO

-- Creating foreign key on [LogTypeId] in table 'Log'
ALTER TABLE [BG].[Log]
ADD CONSTRAINT [FK_LogTypeLog]
    FOREIGN KEY ([LogTypeId])
    REFERENCES [BG].[LogType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LogTypeLog'
CREATE INDEX [IX_FK_LogTypeLog]
ON [BG].[Log]
    ([LogTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Log'
ALTER TABLE [BG].[Log]
ADD CONSTRAINT [FK_PersonLog]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonLog'
CREATE INDEX [IX_FK_PersonLog]
ON [BG].[Log]
    ([PersonId]);
GO

-- Creating foreign key on [TransactionTypeId] in table 'Transaction'
ALTER TABLE [BG].[Transaction]
ADD CONSTRAINT [FK_TransactionTypeTransaction]
    FOREIGN KEY ([TransactionTypeId])
    REFERENCES [BG].[TransactionType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransactionTypeTransaction'
CREATE INDEX [IX_FK_TransactionTypeTransaction]
ON [BG].[Transaction]
    ([TransactionTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'Transaction'
ALTER TABLE [BG].[Transaction]
ADD CONSTRAINT [FK_PersonTransaction]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTransaction'
CREATE INDEX [IX_FK_PersonTransaction]
ON [BG].[Transaction]
    ([PersonId]);
GO

-- Creating foreign key on [PersonId] in table 'Member'
ALTER TABLE [BG].[Member]
ADD CONSTRAINT [FK_PersonPlayer]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonPlayer'
CREATE INDEX [IX_FK_PersonPlayer]
ON [BG].[Member]
    ([PersonId]);
GO

-- Creating foreign key on [Person_Id] in table 'Login'
ALTER TABLE [BG].[Login]
ADD CONSTRAINT [FK_PersonLogin]
    FOREIGN KEY ([Person_Id])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonLogin'
CREATE INDEX [IX_FK_PersonLogin]
ON [BG].[Login]
    ([Person_Id]);
GO

-- Creating foreign key on [RoleId] in table 'PersonRole'
ALTER TABLE [BG].[PersonRole]
ADD CONSTRAINT [FK_RolePersonRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [BG].[Role]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RolePersonRole'
CREATE INDEX [IX_FK_RolePersonRole]
ON [BG].[PersonRole]
    ([RoleId]);
GO

-- Creating foreign key on [PersonTypeId] in table 'Member'
ALTER TABLE [BG].[Member]
ADD CONSTRAINT [FK_PersonTypeMember]
    FOREIGN KEY ([PersonTypeId])
    REFERENCES [BG].[PersonType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTypeMember'
CREATE INDEX [IX_FK_PersonTypeMember]
ON [BG].[Member]
    ([PersonTypeId]);
GO

-- Creating foreign key on [PersonTypeId] in table 'PersonRole'
ALTER TABLE [BG].[PersonRole]
ADD CONSTRAINT [FK_PersonTypePersonRole]
    FOREIGN KEY ([PersonTypeId])
    REFERENCES [BG].[PersonType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonTypePersonRole'
CREATE INDEX [IX_FK_PersonTypePersonRole]
ON [BG].[PersonRole]
    ([PersonTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'MailoutQueue'
ALTER TABLE [BG].[MailoutQueue]
ADD CONSTRAINT [FK_PersonMailoutQueue]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonMailoutQueue'
CREATE INDEX [IX_FK_PersonMailoutQueue]
ON [BG].[MailoutQueue]
    ([PersonId]);
GO

-- Creating foreign key on [MailoutTypeId] in table 'MailoutQueue'
ALTER TABLE [BG].[MailoutQueue]
ADD CONSTRAINT [FK_MailoutTypeMailoutQueue]
    FOREIGN KEY ([MailoutTypeId])
    REFERENCES [BG].[MailoutType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutTypeMailoutQueue'
CREATE INDEX [IX_FK_MailoutTypeMailoutQueue]
ON [BG].[MailoutQueue]
    ([MailoutTypeId]);
GO

-- Creating foreign key on [MailoutTypeId] in table 'MailoutTypeParameter'
ALTER TABLE [BG].[MailoutTypeParameter]
ADD CONSTRAINT [FK_MailoutTypeMailoutTypeParameter]
    FOREIGN KEY ([MailoutTypeId])
    REFERENCES [BG].[MailoutType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutTypeMailoutTypeParameter'
CREATE INDEX [IX_FK_MailoutTypeMailoutTypeParameter]
ON [BG].[MailoutTypeParameter]
    ([MailoutTypeId]);
GO

-- Creating foreign key on [MailoutParameterId] in table 'MailoutTypeParameter'
ALTER TABLE [BG].[MailoutTypeParameter]
ADD CONSTRAINT [FK_MailoutParameterMailoutTypeParameter]
    FOREIGN KEY ([MailoutParameterId])
    REFERENCES [BG].[MailoutParameter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutParameterMailoutTypeParameter'
CREATE INDEX [IX_FK_MailoutParameterMailoutTypeParameter]
ON [BG].[MailoutTypeParameter]
    ([MailoutParameterId]);
GO

-- Creating foreign key on [MailoutQueueId] in table 'MailoutQueueParameterValue'
ALTER TABLE [BG].[MailoutQueueParameterValue]
ADD CONSTRAINT [FK_MailoutQueueMailoutQueueParameterValue]
    FOREIGN KEY ([MailoutQueueId])
    REFERENCES [BG].[MailoutQueue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutQueueMailoutQueueParameterValue'
CREATE INDEX [IX_FK_MailoutQueueMailoutQueueParameterValue]
ON [BG].[MailoutQueueParameterValue]
    ([MailoutQueueId]);
GO

-- Creating foreign key on [MailoutTypeParameterId] in table 'MailoutQueueParameterValue'
ALTER TABLE [BG].[MailoutQueueParameterValue]
ADD CONSTRAINT [FK_MailoutTypeParameterMailoutQueueParameterValue]
    FOREIGN KEY ([MailoutTypeParameterId])
    REFERENCES [BG].[MailoutTypeParameter]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutTypeParameterMailoutQueueParameterValue'
CREATE INDEX [IX_FK_MailoutTypeParameterMailoutQueueParameterValue]
ON [BG].[MailoutQueueParameterValue]
    ([MailoutTypeParameterId]);
GO

-- Creating foreign key on [MailoutQueueId] in table 'MailoutTracker'
ALTER TABLE [BG].[MailoutTracker]
ADD CONSTRAINT [FK_MailoutQueueMailoutTracker]
    FOREIGN KEY ([MailoutQueueId])
    REFERENCES [BG].[MailoutQueue]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MailoutQueueMailoutTracker'
CREATE INDEX [IX_FK_MailoutQueueMailoutTracker]
ON [BG].[MailoutTracker]
    ([MailoutQueueId]);
GO

-- Creating foreign key on [PersonId] in table 'Attendance'
ALTER TABLE [BG].[Attendance]
ADD CONSTRAINT [FK_PersonAttendance]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonAttendance'
CREATE INDEX [IX_FK_PersonAttendance]
ON [BG].[Attendance]
    ([PersonId]);
GO

-- Creating foreign key on [SecurityTypeId] in table 'SecurityCode'
ALTER TABLE [BG].[SecurityCode]
ADD CONSTRAINT [FK_SecurityTypeSecurityCode]
    FOREIGN KEY ([SecurityTypeId])
    REFERENCES [BG].[SecurityType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SecurityTypeSecurityCode'
CREATE INDEX [IX_FK_SecurityTypeSecurityCode]
ON [BG].[SecurityCode]
    ([SecurityTypeId]);
GO

-- Creating foreign key on [PersonId] in table 'SecurityCode'
ALTER TABLE [BG].[SecurityCode]
ADD CONSTRAINT [FK_PersonSecurityCode]
    FOREIGN KEY ([PersonId])
    REFERENCES [BG].[Person]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonSecurityCode'
CREATE INDEX [IX_FK_PersonSecurityCode]
ON [BG].[SecurityCode]
    ([PersonId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------