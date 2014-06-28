CREATE TABLE [dbo].[Education] (
    [educationID]   INT           IDENTITY(1,1) NOT NULL,
	[applicantID]   INT           NULL,
    [city]          NVARCHAR (100) NULL,
    [degree]        NVARCHAR (100) NULL,
    [graduated]     DATE          NULL,
    [schoolName]    NVARCHAR (100) NULL,
    [state]         NCHAR(2) NULL,
    [street]        NVARCHAR (100) NULL,
    [street2]       NVARCHAR (100) NULL,
    [yearsAttended] NVARCHAR (100) NULL,
    [zip]           DECIMAL(10)           NULL,
    PRIMARY KEY CLUSTERED ([educationID] ASC), 
    CONSTRAINT [FK_Education_Applicant] FOREIGN KEY ([applicantID]) REFERENCES [Applicant]([applicantID])
);

