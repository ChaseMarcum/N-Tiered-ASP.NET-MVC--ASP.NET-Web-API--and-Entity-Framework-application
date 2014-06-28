CREATE TABLE [dbo].[JobHistory] (
    [jobHistoryID]     INT           IDENTITY(1,1) NOT NULL,
	[applicantID]      INT           NULL,
    [city]             NVARCHAR (50) NULL,
    [dateFrom]         DATE          NULL,
    [dateTo]           DATE          NULL,
    [employerName]     NVARCHAR (50) NULL,
    [endingSalary]     MONEY         NULL,
    [phone]            DECIMAL(10) NULL,
    [position]         NVARCHAR (50) NULL,
    [reasonForLeaving] NVARCHAR(MAX)         NULL,
    [responsibilities] NVARCHAR(MAX)         NULL,
    [startingSalary]   MONEY         NULL,
    [state]            NCHAR(2)    NULL,
    [street]           NVARCHAR (100) NULL,
    [street2]          NVARCHAR (100) NULL,
    [supervisor]       NVARCHAR (50) NULL,
    [zip]              DECIMAL(5)           NULL,
    PRIMARY KEY CLUSTERED ([jobHistoryID] ASC), 
    CONSTRAINT [FK_JobHistory_Applicant] FOREIGN KEY ([applicantID]) REFERENCES [Applicant]([applicantID])
);

