USE LynnSmithUniversityDB;

-- Degree audit for a specific student (StudentID = 1001)
SELECT 
    sr.StudentID, 
    sr.CourseID, 
    c.CourseName, 
    c.Instructor, 
    sr.Grade,
    CASE
        WHEN dr.CourseID IS NULL THEN 'Missing Required Course'
        ELSE 'Completed'
    END AS Status
FROM StudentCourses sr
JOIN DegreeRequirements dr ON sr.CourseID = dr.CourseID
JOIN Courses c ON sr.CourseID = c.CourseID
WHERE sr.StudentID = 1001;  -- Replace 1001 with the desired StudentID
