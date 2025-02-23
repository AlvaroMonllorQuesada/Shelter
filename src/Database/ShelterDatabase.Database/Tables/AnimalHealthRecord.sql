CREATE TABLE [dbo].[AnimalHealthRecord] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [AnimalId] INT NOT NULL,
    [VisitDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [VeterinarianName] NVARCHAR(100) NULL,
    [Diagnosis] NVARCHAR(255),
    [Treatment] NVARCHAR(255),
    [Medication] NVARCHAR(255),
    [Notes] NVARCHAR(MAX),
    CONSTRAINT FK_AnimalHealthRecord_Animal FOREIGN KEY (AnimalId) REFERENCES Animal(Id)
);