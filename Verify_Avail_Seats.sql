USE LynnSmithUniversityDB;

-- Verify the AvailableSeats values
SELECT CourseID, CourseName, AvailableSeats
FROM Courses
WHERE CourseID IN (1, 2, 3, 4);
