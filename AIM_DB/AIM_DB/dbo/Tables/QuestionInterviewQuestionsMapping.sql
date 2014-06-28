CREATE TABLE [dbo].[QuestionInterviewQuestionMapping]
(
	[questionID] INT NOT NULL , 
    [interviewQuestionsID] INT NOT NULL, 
    [numberOfQuestions] INT NULL, 
    CONSTRAINT [FK_QuestionInterviewQuestion_Question] FOREIGN KEY ([questionID]) REFERENCES [Question]([questionID]), 
    CONSTRAINT [FK_QuestionInterviewQuestion_InterviewQuestion] FOREIGN KEY ([interviewQuestionsID]) REFERENCES [InterviewQuestions]([interviewQuestionsID]), 
    PRIMARY KEY ([questionID], [interviewQuestionsID])
)
