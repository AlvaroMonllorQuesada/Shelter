CREATE TABLE [dbo].[Animal]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Species] NVARCHAR(50) NOT NULL,
	[BirthDate] DATETIME,
	[HealthStatus] NVARCHAR(50),
	[AdmissionDate] DATETIME,
	[AdoptionDate] DATETIME,
	[UbicationName] NVARCHAR(50),
	[UbicationPoint] GEOGRAPHY,
	[Notes] NVARCHAR(MAX),
	[Status] NVARCHAR(50) NOT NULL,
	[ShelterId] INT NOT NULL FOREIGN KEY REFERENCES Shelter(Id)
)
