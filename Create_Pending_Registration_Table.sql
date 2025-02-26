USE LynnSmithUniversityDB;
CREATE TABLE dbo.PendingRegistrations (
    RegistrationID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Pending'
);
