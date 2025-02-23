CREATE TABLE [dbo].[AnimalMedia] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [AnimalId] INT NOT NULL,
    [MediaType] NVARCHAR(20) NOT NULL,-- CHECK (MediaType IN ('Photo', 'Video')),
    [MediaUrl] NVARCHAR(255) NOT NULL,  -- URL or file path to media
    [Description] NVARCHAR(255),
    [UploadedDate] DATETIME NOT NULL DEFAULT GETDATE(),
    [IsPrimary] BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_AnimalMedia_Animal FOREIGN KEY (AnimalId) REFERENCES Animal(Id)
);