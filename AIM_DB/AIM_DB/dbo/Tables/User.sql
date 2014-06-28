CREATE TABLE [dbo].[User] (
    [UserID]                    INT           IDENTITY(1,1) NOT NULL, 
    [applicationID]             INT           NULL,
    [email]                     NVARCHAR (100) NULL,
    [employeeID]                INT           NULL,
    [firstName]                 NVARCHAR (25) NULL,
    [lastName]                  NVARCHAR (25) NULL,
    [middleName]                NVARCHAR (25) NULL,
    [password]                  NVARCHAR (200) NULL,
    [passwordCoder]             NVARCHAR (200) NULL,
    [socialSecurityNumber]      DECIMAL(9) NULL,
    [socialSecurityNumberCoder] NVARCHAR (50) NULL,
    [PersonalInfoID]            INT           NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_ToTable] FOREIGN KEY ([PersonalInfoID]) REFERENCES [dbo].[PersonalInfo] ([PersonalInfoID]),
    CONSTRAINT [FK_User_ToTable_1] FOREIGN KEY ([employeeID]) REFERENCES [dbo].[Employee] ([employeeID])
);

