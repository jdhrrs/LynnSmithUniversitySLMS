-- Switch to the correct database
USE LynnSmithUniversityDB;
GO

-- Ensure Students table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Students')
BEGIN
    CREATE TABLE Students (
        StudentID INT PRIMARY KEY,
        FirstName NVARCHAR(50) NOT NULL,
        LastName NVARCHAR(50) NOT NULL,
        GPA FLOAT NULL
    );
END;

-- Ensure Enrollments table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Enrollments')
BEGIN
    CREATE TABLE Enrollments (
        EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL,
        CourseID NVARCHAR(50) NOT NULL,
        EnrollmentDate DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_Enrollments_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
        CONSTRAINT FK_Enrollments_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
    );
END;

-- Ensure StudentProgress table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'StudentProgress')
BEGIN
    CREATE TABLE StudentProgress (
        ProgressID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL,
        CourseID NVARCHAR(50) NOT NULL,
        Grade CHAR(2),
        GPA DECIMAL(3,2),
        CONSTRAINT FK_StudentProgress_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
        CONSTRAINT FK_StudentProgress_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
    );
END;

-- Ensure StudentRegistrations table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'StudentRegistrations')
BEGIN
    CREATE TABLE StudentRegistrations (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        StudentName NVARCHAR(100) NOT NULL,
        CourseName NVARCHAR(100) NOT NULL,
        Status NVARCHAR(20) DEFAULT 'Pending',
        AdminComments NVARCHAR(255)
    );
END;

-- Ensure Users table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Users')
BEGIN
    CREATE TABLE Users (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        Password NVARCHAR(255) NOT NULL,
        Role NVARCHAR(50) NOT NULL
    );
END;

-- Ensure Courses table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Courses')
BEGIN
    CREATE TABLE Courses (
        CourseID NVARCHAR(50) PRIMARY KEY,  
        CourseName NVARCHAR(100) NOT NULL,
        Credits INT NOT NULL,
        Instructor NVARCHAR(100) NULL,
        AvailableSeats INT NOT NULL DEFAULT 30
    );
END;

-- Ensure StudentCourses table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'StudentCourses')
BEGIN
    CREATE TABLE StudentCourses (
        EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL,
        CourseID NVARCHAR(50) NOT NULL,  
        CONSTRAINT FK_StudentCourses_Student FOREIGN KEY (StudentID) REFERENCES Users(Id),
        CONSTRAINT FK_StudentCourses_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
        CONSTRAINT UQ_StudentCourses UNIQUE (StudentID, CourseID) -- Ensure no duplicate enrollments
    );
END;

-- Ensure PendingRegistrations table exists
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'PendingRegistrations')
BEGIN
    CREATE TABLE PendingRegistrations (
        RequestID INT IDENTITY(1,1) PRIMARY KEY,
        StudentID INT NOT NULL,
        CourseID NVARCHAR(50) NOT NULL,  
        Status NVARCHAR(20) DEFAULT 'Pending',
        CONSTRAINT FK_PendingRegistrations_Student FOREIGN KEY (StudentID) REFERENCES Users(Id),
        CONSTRAINT FK_PendingRegistrations_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
    );
END;

-- Insert sample users
IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'admin')
BEGIN
    INSERT INTO Users (Username, Password, Role) VALUES ('admin', 'admin123', 'Administrator');
END;

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'faculty1')
BEGIN
    INSERT INTO Users (Username, Password, Role) VALUES ('faculty1', 'faculty123', 'Faculty');
END;

IF NOT EXISTS (SELECT 1 FROM Users WHERE Username = 'student1')
BEGIN
    INSERT INTO Users (Username, Password, Role) VALUES ('student1', 'student123', 'Student');
END;

-- Insert sample courses
IF NOT EXISTS (SELECT 1 FROM Courses WHERE CourseID = 'MATH101')
BEGIN
    INSERT INTO Courses (CourseID, CourseName, Credits, Instructor, AvailableSeats) 
    VALUES ('MATH101', 'Math 101', 3, 'Dr. Smith', 30);
END;

IF NOT EXISTS (SELECT 1 FROM Courses WHERE CourseID = 'HIST202')
BEGIN
    INSERT INTO Courses (CourseID, CourseName, Credits, Instructor, AvailableSeats) 
    VALUES ('HIST202', 'History 202', 4, 'Dr. Jones', 25);
END;

-- Insert test students
IF NOT EXISTS (SELECT 1 FROM Students WHERE StudentID = 2003)
BEGIN
    INSERT INTO Students (StudentID, FirstName, LastName, GPA) VALUES
    (2003, 'Alice', 'Johnson', 3.8),
    (2004, 'Bob', 'Smith', 3.5),
    (2005, 'Charlie', 'Brown', 3.0),
    (2006, 'Diana', 'Prince', 4.0);
END;

-- Insert test enrollments
IF NOT EXISTS (SELECT 1 FROM Enrollments WHERE StudentID = 2003)
BEGIN
    INSERT INTO Enrollments (StudentID, CourseID, EnrollmentDate) VALUES
    (2003, 'MATH101', '2025-02-10'),
    (2004, 'HIST202', '2025-02-11'),
    (2005, 'MATH101', '2025-02-12'),
    (2006, 'HIST202', '2025-02-13');
END;

-- Insert test student progress
IF NOT EXISTS (SELECT 1 FROM StudentProgress WHERE StudentID = 2003)
BEGIN
    INSERT INTO StudentProgress (StudentID, CourseID, Grade, GPA) VALUES
    (2003, 'MATH101', 'A', 4.0),
    (2004, 'HIST202', 'B+', 3.5),
    (2005, 'MATH101', 'C', 2.5),
    (2006, 'HIST202', 'A-', 3.8);
END;

-- Admin Report Query
SELECT 
    e.EnrollmentID, 
    s.FirstName + ' ' + s.LastName AS StudentName,  
    c.CourseName, 
    e.EnrollmentDate, 
    sp.Grade, 
    sp.GPA
FROM Enrollments e
JOIN Students s ON e.StudentID = s.StudentID
JOIN Courses c ON e.CourseID = c.CourseID
LEFT JOIN StudentProgress sp ON e.StudentID = sp.StudentID AND e.CourseID = sp.CourseID
ORDER BY e.EnrollmentDate DESC;
