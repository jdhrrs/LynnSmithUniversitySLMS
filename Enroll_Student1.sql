-- Ensure we are in the correct database
USE LynnSmithUniversityDB;
GO

-- ✅ Step 1: Ensure student1 exists in the Users table
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'student1')
BEGIN
    INSERT INTO Users (Username, UserType) VALUES ('student1', 'Student');
    PRINT '✅ student1 added to Users table.';
END
ELSE
BEGIN
    PRINT '✅ student1 already exists.';
END
GO

-- ✅ Step 2: Get student1's ID
DECLARE @StudentID INT;
SELECT @StudentID = Id FROM Users WHERE Username = 'student1';

-- ✅ Step 3: Enroll student1 in all courses assigned to faculty1
INSERT INTO Enrollments (StudentID, CourseID)
SELECT @StudentID, CourseID FROM Courses WHERE Instructor = 'faculty1';

PRINT '✅ student1 has been enrolled in all courses.';
GO

-- ✅ Step 4: Verify Enrollment
SELECT u.Username, c.CourseName 
FROM Enrollments e
JOIN Users u ON e.StudentID = u.Id
JOIN Courses c ON e.CourseID = c.CourseID
WHERE u.Username = 'student1';
GO
