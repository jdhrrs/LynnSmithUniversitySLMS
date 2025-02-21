SELECT e.EnrollmentID, e.StudentID, e.CourseID, u.Username
FROM Enrollments e
JOIN Users u ON e.StudentID = u.Id
WHERE e.CourseID = 4;
