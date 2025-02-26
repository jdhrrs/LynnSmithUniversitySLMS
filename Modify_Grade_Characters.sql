USE LynnSmithUniversityDB;

-- Check grades for students and courses
SELECT sp.StudentID, sp.CourseID, sp.Grade, c.CourseName
FROM StudentProgress sp
JOIN Courses c ON sp.CourseID = c.CourseID
WHERE sp.StudentID IN (1001, 1002, 1003) -- Check for specific students
  AND sp.CourseID IN (1, 2, 3);           -- Check for specific courses
