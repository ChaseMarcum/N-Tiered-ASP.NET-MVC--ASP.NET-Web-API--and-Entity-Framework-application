CREATE TABLE [dbo].[Job] (
    [jobID]            INT           IDENTITY(1,1) NOT NULL,
    [description]      NVARCHAR (MAX) NULL,
    [fullPartTime]     NVARCHAR (50) NULL,
    [operatingHoursID] INT           NULL,
    [position]         NVARCHAR (150) NULL,
    [questionnaireID]  INT           NULL,
    [salaryRange]      NVARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([jobID] ASC),
    CONSTRAINT [FK_Job_ToTable] FOREIGN KEY ([operatingHoursID]) REFERENCES [dbo].[OperatingHours] ([hoursID]),
    CONSTRAINT [FK_Job_ToTable_1] FOREIGN KEY ([questionnaireID]) REFERENCES [dbo].[Questionnaire] ([questionnaireID])
);

