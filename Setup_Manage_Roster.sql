-- Ensure we're in the correct database
USE LynnSmithUniversityDB;
GO

-- ✅ Step 1: Ensure Users Table Has a Faculty Member
IF NOT EXISTS (SELECT * FROM Users WHERE Username = 'faculty1')
BEGIN
    INSERT INTO Users (Username, Password, Role) VALUES ('faculty1', 'password123', 'Faculty');
    PRINT '✅ Faculty user faculty1 added.';
END
ELSE
BEGIN
    PRINT '✅ Faculty user faculty1 already exists.';
END
GO

-- ✅ Step 2: Ensure Students Exist
IF NOT EXISTS (SELECT * FROM Students WHERE FirstName = 'Alice' AND LastName = 'Johnson')
BEGIN
    INSERT INTO Students (FirstName, LastName) VALUES ('Alice', 'Johnson');
    PRINT '✅ Student Alice Johnson added.';
END
ELSE
BEGIN
    PRINT '✅ Student Alice Johnson already exists.';
END
GO

-- ✅ Step 3: Assign Courses to Faculty
IF NOT EXISTS (SELECT * FROM Courses WHERE CourseName = 'Computer Science 101')
BEGIN
    INSERT INTO Courses (CourseName, Instructor) VALUES ('Computer Science 101', 'faculty1');
    INSERT INTO Courses (CourseName, Instructor) VALUES ('English 101', 'faculty1');
    INSERT INTO Courses (CourseName, Instructor) VALUES ('History 202', 'faculty1');
    INSERT INTO Courses (CourseName, Instructor) VALUES ('Math 101', 'faculty1');
    PRINT '✅ Faculty courses added.';
END
ELSE
BEGIN
    PRINT '✅ Faculty courses already exist.';
END
GO

-- ✅ Step 4: Enroll Students in Courses
DECLARE @StudentID INT;
SELECT @StudentID = StudentID FROM Students WHERE FirstName = 'Alice' AND LastName = 'Johnson';

IF @StudentID IS NOT NULL
BEGIN
    INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate)
    SELECT @StudentID, CourseID, GETDATE() FROM Courses WHERE Instructor = 'faculty1';

    PRINT '✅ Student Alice Johnson enrolled in faculty1 courses.';
END
ELSE
BEGIN
    PRINT '⚠ ERROR: Student Alice Johnson not found!';
END
GO

-- ✅ Step 5: Verify Enrollment
SELECT u.Username AS Faculty, c.CourseName, s.FirstName, s.LastName 
FROM Enrollments e
JOIN Courses c ON e.CourseID = c.CourseID
JOIN Students s ON e.StudentID = s.StudentID
JOIN Users u ON c.Instructor = u.Username
WHERE u.Username = 'faculty1';
GO
