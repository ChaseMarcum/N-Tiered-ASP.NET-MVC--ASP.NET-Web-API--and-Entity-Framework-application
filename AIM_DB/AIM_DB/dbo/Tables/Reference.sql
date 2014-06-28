CREATE TABLE [dbo].[Reference] (
    [referenceID] INT           IDENTITY(1,1) NOT NULL,
	[applicantID] INT           NULL,
    [refCompany]  NVARCHAR (50) NULL,
    [refFullName] NVARCHAR (50) NULL,
    [refPhone]    DECIMAL(10) NULL,
    [refTitle]    NVARCHAR(50)    NULL,
    PRIMARY KEY CLUSTERED ([referenceID] ASC), 
    CONSTRAINT [FK_Reference_Applicant] FOREIGN KEY ([applicantID]) REFERENCES [Applicant]([applicantID])
);

