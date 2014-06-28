CREATE TABLE [dbo].[ApplicantQuestionAnswers]
(
	[answerID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [applicantID] INT NULL, 
    [quesitonID] INT NULL, 
    [answerString] VARCHAR(MAX) NULL, 
    CONSTRAINT [FK_ApplicantQuestionAnswers_Applicant] FOREIGN KEY ([applicantID]) REFERENCES [Applicant]([applicantID])
)
