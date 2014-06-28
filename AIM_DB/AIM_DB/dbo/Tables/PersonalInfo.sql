CREATE TABLE [dbo].[PersonalInfo] (
    [PersonalInfoID] INT           IDENTITY(1,1) NOT NULL,
    [alias]          NVARCHAR (25) NULL,
    [city]           NVARCHAR (50) NULL,
    [phone]          DECIMAL(10) NULL,
    [street]         NVARCHAR (100) NULL,
    [street2]        NVARCHAR (100) NULL,
    [zip]            DECIMAL(5)           NULL,
    [userID]         INT           NULL,
    PRIMARY KEY CLUSTERED ([PersonalInfoID] ASC)
);

