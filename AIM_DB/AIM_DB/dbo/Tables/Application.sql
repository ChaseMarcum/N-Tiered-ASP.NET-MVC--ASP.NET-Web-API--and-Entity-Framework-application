CREATE TABLE [dbo].[Application] (
    [applicationID]          INT           IDENTITY(1,1) NOT NULL,
	[applicantID]			 INT		   NULL,
    [dateCreated]            DATE          NULL,
    [preEmploymentStatement] NVARCHAR (100) NULL,
    [jobID]                  INT           NULL,
    PRIMARY KEY CLUSTERED ([applicationID] ASC),
    CONSTRAINT [FK_Application_Job] FOREIGN KEY ([jobID]) REFERENCES [dbo].[Job] ([jobID]), 
    CONSTRAINT [FK_Application_Applicant] FOREIGN KEY ([applicantID]) REFERENCES [Applicant]([applicantID])
);

