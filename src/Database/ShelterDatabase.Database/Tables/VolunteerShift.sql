CREATE TABLE [dbo].[VolunteerShift] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [ShelterZoneId] INT NOT NULL,
    [ShiftDate] DATE NOT NULL DEFAULT GETDATE(), -- Date of the shift
    [ShiftType] NVARCHAR(20) NOT NULL,-- CHECK (ShiftType IN ('Morning', 'Evening')), -- Shift time
    [ZoneStatus] NVARCHAR(200) NOT NULL,-- CHECK (ZoneStatus IN ('Clean', 'Needs Cleaning', 'Needs Repair', 'Occupied')), -- Condition of the zone
    [Observations] NVARCHAR(MAX), -- General notes
    [CreatedBy] INT NOT NULL, -- Volunteer who logs the shift
    CONSTRAINT FK_VolunteerShift_ShelterZone FOREIGN KEY (ShelterZoneId) REFERENCES ShelterZone(Id),
    CONSTRAINT FK_VolunteerShift_CreatedBy FOREIGN KEY (CreatedBy) REFERENCES Volunteer(Id)
);
