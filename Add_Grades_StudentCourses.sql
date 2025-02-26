-- Use your database
USE LynnSmithUniversityDB;

-- 1. Create the CoursePrerequisites table
-- This table links courses to their prerequisites
CREATE TABLE CoursePrerequisites (
    CourseID INT,
    PrerequisiteCourseID INT,
    PRIMARY KEY (CourseID, PrerequisiteCourseID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (PrerequisiteCourseID) REFERENCES Courses(CourseID)
);

-- 2. Create the DegreeRequirements table
-- This table links required courses to a specific degree program
CREATE TABLE DegreeRequirements (
    DegreeID INT,
    CourseID INT,
    PRIMARY KEY (DegreeID, CourseID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- 3. Create the StudentCourses table
-- This table records which courses a student has completed or is currently enrolled in
CREATE TABLE StudentCourses (
    EnrollmentID INT PRIMARY KEY,
    StudentID INT,
    CourseID INT,
    Grade CHAR(2),  -- Added Grade column to track student grades
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);

-- 4. Example data to test the schema
-- Add some example courses
INSERT INTO Courses (CourseID, CourseName, Instructor)
VALUES
(1, 'Computer Science 101', 'faculty1'),
(2, 'English 101', 'faculty1'),
(3, 'History 202', 'faculty1'),
(4, 'Math 101', 'faculty1');

-- Add some example students
INSERT INTO Students (StudentID, FirstName, LastName)
VALUES
(1001, 'Alice', 'Johnson'),
(1002, 'Bob', 'Smith'),
(1003, 'Charlie', 'Brown');

-- Assign some prerequisites
INSERT INTO CoursePrerequisites (CourseID, PrerequisiteCourseID)
VALUES
(1, 2),  -- Computer Science 101 requires English 101
(3, 2);  -- History 202 requires English 101

-- Assign some degree requirements (for example, Degree 1 requires courses 1, 2, and 3)
INSERT INTO DegreeRequirements (DegreeID, CourseID)
VALUES
(1, 1),  -- Degree 1 requires Computer Science 101
(1, 2),  -- Degree 1 requires English 101
(1, 3);  -- Degree 1 requires History 202

-- Enroll students in courses and assign grades
INSERT INTO StudentCourses (StudentID, CourseID, Grade)
VALUES
(1001, 1, 'A'),  -- Alice completed Computer Science 101
(1001, 2, 'B+'), -- Alice completed English 101
(1002, 3, 'A');  -- Bob completed History 202
