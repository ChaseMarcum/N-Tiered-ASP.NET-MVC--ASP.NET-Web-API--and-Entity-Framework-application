CREATE TABLE [dbo].[Applicant] (
    [applicantID]   INT IDENTITY(1,1) NOT NULL,
    [educationID]   INT NULL,
    [jobHistoryID]  INT NULL,
    [referenceID]   INT NULL,
    [userID]        INT NULL,
    [applicationID] INT NULL,
    [answerID] INT NULL, 
    [hoursID] INT NULL, 
    PRIMARY KEY CLUSTERED ([applicantID] ASC)
);

