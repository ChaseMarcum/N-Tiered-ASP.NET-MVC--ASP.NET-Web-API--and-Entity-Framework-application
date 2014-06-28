CREATE TABLE [dbo].[QuestionQuestionnaire]
(
	[questionID] INT NOT NULL, 
    [questionnaireID] INT NOT NULL, 
    [numberOfQuestions] INT NULL, 
    CONSTRAINT [FK_QuestionQuestionnaire_Question] FOREIGN KEY ([questionID]) REFERENCES [Question]([questionID]), 
    CONSTRAINT [FK_QuestionQuestionnaire_Questionnaire] FOREIGN KEY ([questionnaireID]) REFERENCES [Questionnaire]([questionnaireID]),
	PRIMARY KEY ([questionID], [questionnaireID])
)
