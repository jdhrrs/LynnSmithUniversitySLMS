-- Drop the table if it exists
IF OBJECT_ID('dbo.PendingRegistrations', 'U') IS NOT NULL
    DROP TABLE dbo.PendingRegistrations;
GO

-- Create the table with the correct NVARCHAR data type
CREATE TABLE PendingRegistrations (
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID NVARCHAR(50) NOT NULL,  -- Match Courses.CourseID data type
    Status NVARCHAR(20) DEFAULT 'Pending',
    FOREIGN KEY (StudentID) REFERENCES Users(Id),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
