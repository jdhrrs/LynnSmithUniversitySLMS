<<<<<<< HEAD
﻿USE LynnSmithUniversityDB;
CREATE TABLE dbo.PendingRegistrations (
    RegistrationID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Pending'
);
=======
﻿USE LynnSmithUniversityDB;
CREATE TABLE dbo.PendingRegistrations (
    RegistrationID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    RegistrationDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Pending'
);
>>>>>>> ab6290af3d3c1f3152b8793e1f1d1f34f1c8f02b
