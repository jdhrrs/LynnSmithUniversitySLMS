-- Drop the Users table if it already exists
IF OBJECT_ID('dbo.Users', 'U') IS NOT NULL
    DROP TABLE dbo.Users;
GO

-- Create the Users table
CREATE TABLE dbo.Users (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    Password NVARCHAR(255) NOT NULL, -- Store hashed passwords in production
    Role NVARCHAR(50) NOT NULL
);
GO

-- Insert sample users if they do not already exist
IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'admin')
    INSERT INTO dbo.Users (Username, Password, Role) VALUES ('admin', 'admin123', 'Administrator');

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'faculty1')
    INSERT INTO dbo.Users (Username, Password, Role) VALUES ('faculty1', 'faculty123', 'Faculty');

IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Username = 'student1')
    INSERT INTO dbo.Users (Username, Password, Role) VALUES ('student1', 'student123', 'Student');
GO
