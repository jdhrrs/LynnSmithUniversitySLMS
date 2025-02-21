ALTER TABLE StudentCourses 
ADD CONSTRAINT UQ_StudentCourses UNIQUE (StudentID, CourseID);
