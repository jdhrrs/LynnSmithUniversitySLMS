USE LynnSmithUniversityDB;

-- Declare the parameters
DECLARE @StudentID INT = 1001;   -- Example StudentID, change as needed
DECLARE @CourseID INT = 1;       -- Example CourseID, change as needed
DECLARE @Grade NVARCHAR(10) = 'A';  -- Example grade, change as needed

-- MERGE statement to insert or update the grade
MERGE INTO StudentProgress AS target
USING (SELECT @StudentID AS StudentID, @CourseID AS CourseID, @Grade AS Grade) AS source
ON target.StudentID = source.StudentID AND target.CourseID = source.CourseID
WHEN MATCHED THEN
    UPDATE SET Grade = source.Grade
WHEN NOT MATCHED THEN
    INSERT (StudentID, CourseID, Grade)
    VALUES (source.StudentID, source.CourseID, source.Grade);
