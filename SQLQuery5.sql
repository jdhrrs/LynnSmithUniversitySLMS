DECLARE @FacultyUsername NVARCHAR(100);
SELECT @FacultyUsername = Username FROM Users WHERE Id = 2;

SELECT CourseID, CourseName, Instructor
FROM Courses 
WHERE Instructor = @FacultyUsername;
