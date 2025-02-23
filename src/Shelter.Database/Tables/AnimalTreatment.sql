CREATE TABLE [dbo].[AnimalTreatment] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [AnimalId] INT NOT NULL,
    [TreatmentType] NVARCHAR(100) NOT NULL, -- E.g., "Surgery", "Vaccination", "Fever Treatment"
    [StartDate] DATETIME NOT NULL DEFAULT GETDATE(), -- Treatment start date
    [EndDate] DATETIME, -- Optional end date for the treatment
    [Status] NVARCHAR(50) NOT NULL,-- CHECK (Status IN ('Ongoing', 'Completed', 'Scheduled')), -- Ongoing or completed
    [Notes] NVARCHAR(MAX), -- Any additional notes for the treatment
    CONSTRAINT FK_AnimalTreatment_Animal FOREIGN KEY (AnimalId) REFERENCES Animal(Id)
);