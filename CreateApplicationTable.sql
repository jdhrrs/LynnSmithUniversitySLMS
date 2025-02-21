USE LynnSmithUniversityDB;
CREATE TABLE Applications (
    ApplicationID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) NOT NULL,
    DocumentPath NVARCHAR(500),
    Status NVARCHAR(50) NOT NULL DEFAULT 'Pending',
    SubmissionDate DATETIME DEFAULT GETDATE()
);
