CREATE TABLE [dbo].[VolunteerShiftAssignment] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [VolunteerShiftId] INT NOT NULL,
    [VolunteerId] INT NOT NULL,
    CONSTRAINT FK_VolunteerShiftAssignment_Shift FOREIGN KEY (VolunteerShiftId) REFERENCES VolunteerShift(Id),
    CONSTRAINT FK_VolunteerShiftAssignment_Volunteer FOREIGN KEY (VolunteerId) REFERENCES Volunteer(Id)
);