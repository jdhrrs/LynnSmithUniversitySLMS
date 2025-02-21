USE LynnSmithUniversityDB;

CREATE TABLE StudentProgress (
    ProgressID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT NOT NULL,
    CourseID INT NOT NULL,
    Grade CHAR(2) NULL,
    GPA DECIMAL(3,2) NULL,
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)
);
