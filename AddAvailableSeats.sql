USE LynnSmithUniversityDB;

-- Update AvailableSeats for each course (example)
UPDATE Courses
SET AvailableSeats = 30
WHERE CourseID IN (1, 2, 3, 4);  -- Replace with the actual CourseIDs you want to update
