CREATE TABLE [dbo].[ShelterZone] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL,
    [ShelterId] INT NOT NULL,
    [Type] NVARCHAR(50) NOT NULL,
    [Capacity] INT NOT NULL,
    [CurrentOccupation] INT NOT NULL DEFAULT 0,
    [Status] NVARCHAR(50) NOT NULL,
    CONSTRAINT FK_ShelterZone_Shelter FOREIGN KEY (ShelterId) REFERENCES Shelter(Id)
);