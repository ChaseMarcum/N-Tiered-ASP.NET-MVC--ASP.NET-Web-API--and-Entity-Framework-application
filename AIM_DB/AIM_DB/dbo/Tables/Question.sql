CREATE TABLE [dbo].[Question] (
    [questionID]    INT           IDENTITY(1,1) NOT NULL,
    [qType]         NVARCHAR (50) NULL,
    [qText]         NVARCHAR(MAX)          NULL,
    [qAnswerString] NVARCHAR(MAX)          NULL,
    [qOptionString] NVARCHAR(MAX)          NULL,
    [questionnaireID] INT NULL, 
    [interviewQuestionsID] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([questionID] ASC) 
);

