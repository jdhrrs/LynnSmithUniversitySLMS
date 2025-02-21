-- 🔥 Step 1: Drop the existing Enrollments table if it exists
DROP TABLE IF EXISTS Enrollments;

CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,  -- 🔥 FIXED: Now Matches Courses.CourseID as INT
    FOREIGN KEY (StudentID) REFERENCES Users(Id),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

