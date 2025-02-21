-- 🚨 STEP 1: BACK UP DATA BEFORE CHANGING ANYTHING 🚨
SELECT * INTO Backup_Courses FROM Courses;
SELECT * INTO Backup_StudentCourses FROM StudentCourses;
SELECT * INTO Backup_PendingRegistrations FROM PendingRegistrations;
SELECT * INTO Backup_Enrollments FROM Enrollments;

-- 🚨 STEP 2: DROP FOREIGN KEY CONSTRAINTS 🚨
DECLARE @sql NVARCHAR(MAX) = '';
SELECT @sql += 'ALTER TABLE ' + TABLE_NAME + ' DROP CONSTRAINT ' + CONSTRAINT_NAME + ';'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE CONSTRAINT_TYPE = 'FOREIGN KEY' 
AND TABLE_NAME IN ('StudentCourses', 'PendingRegistrations', 'Enrollments');
EXEC sp_executesql @sql;

-- 🚨 STEP 3: DROP AND RECREATE THE COURSES TABLE 🚨
DROP TABLE IF EXISTS Courses;
CREATE TABLE Courses (
    CourseID INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL,
    Instructor NVARCHAR(100) NOT NULL,
    AvailableSeats INT NOT NULL
);

-- 🚨 STEP 4: RELOAD COURSES DATA WITH CORRECT CourseID VALUES 🚨
INSERT INTO Courses (CourseName, Instructor, AvailableSeats) VALUES
('Computer Science 101', 'faculty1', 25),
('English 101', 'Dr. Brown', 20),
('History 202', 'Dr. Jones', 25),
('Math 101', 'faculty2', 30);

-- 🚨 STEP 5: DROP AND RECREATE RELATED TABLES 🚨
DROP TABLE IF EXISTS StudentCourses;
CREATE TABLE StudentCourses (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

DROP TABLE IF EXISTS PendingRegistrations;
CREATE TABLE PendingRegistrations (
    RequestID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    Status NVARCHAR(40) NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

DROP TABLE IF EXISTS Enrollments;
CREATE TABLE Enrollments (
    EnrollmentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- 🚨 STEP 6: VERIFY EVERYTHING 🚨
SELECT * FROM Courses;
SELECT * FROM StudentCourses;
SELECT * FROM PendingRegistrations;
SELECT * FROM Enrollments;
