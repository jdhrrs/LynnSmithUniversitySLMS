USE LynnSmithUniversityDB;

-- Update grades for specific enrollments

UPDATE StudentCourses
SET Grade = 'A'
WHERE EnrollmentID = 1;  -- Update grade for EnrollmentID 1

UPDATE StudentCourses
SET Grade = 'B+'
WHERE EnrollmentID = 2;  -- Update grade for EnrollmentID 2

UPDATE StudentCourses
SET Grade = 'C'
WHERE EnrollmentID = 3;  -- Update grade for EnrollmentID 3

UPDATE StudentCourses
SET Grade = 'A'
WHERE EnrollmentID = 5;  -- Update grade for EnrollmentID 5

UPDATE StudentCourses
SET Grade = 'B+'
WHERE EnrollmentID = 6;  -- Update grade for EnrollmentID 6

UPDATE StudentCourses
SET Grade = 'A'
WHERE EnrollmentID = 7;  -- Update grade for EnrollmentID 7

UPDATE StudentCourses
SET Grade = 'A-'
WHERE EnrollmentID = 8;  -- Update grade for EnrollmentID 8

UPDATE StudentCourses
SET Grade = 'B'
WHERE EnrollmentID = 9;  -- Update grade for EnrollmentID 9

UPDATE StudentCourses
SET Grade = 'C'
WHERE EnrollmentID = 10;  -- Update grade for EnrollmentID 10
