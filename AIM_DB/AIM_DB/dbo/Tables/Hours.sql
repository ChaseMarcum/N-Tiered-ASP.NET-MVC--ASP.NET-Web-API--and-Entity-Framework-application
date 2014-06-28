CREATE TABLE [dbo].[OperatingHours] (
    [hoursID] INT      IDENTITY(1,1) NOT NULL,
	[applicantID]      INT		NULL,
    [monOpen]          TIME (7) NULL,
    [monClose]         TIME (7) NULL,
    [tueOpen]          TIME (7) NULL,
    [tueClose]         TIME (7) NULL,
    [wedOpen]          TIME (7) NULL,
    [wedClose]         TIME (7) NULL,
    [thursOpen]        TIME (7) NULL,
    [thursClose]       TIME (7) NULL,
    [friOpen]          TIME (7) NULL,
    [friClose]         TIME (7) NULL,
    [satOpen]          TIME (7) NULL,
    [satClose]         TIME (7) NULL,
    [sunOpen]          TIME (7) NULL,
    [sunClose]         TIME (7) NULL,
    PRIMARY KEY CLUSTERED ([hoursID] ASC), 
    CONSTRAINT [FK_OperatingHours_Applicant] FOREIGN KEY ([applicantID]) REFERENCES [Applicant]([applicantID])
);

