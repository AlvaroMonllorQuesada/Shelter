CREATE TABLE [dbo].[UserRole] (
    [Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [RoleName] NVARCHAR(50) NOT NULL,-- CHECK (RoleName IN ('Admin', 'Staff', 'Volunteer'))
);