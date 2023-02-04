USE master
GO

-- Creating Database
CREATE DATABASE TestDatabase
GO

-- Using the Database to create tables.
USE TestDatabase
GO

-- Create random tables
CREATE TABLE Students (
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL
)
GO

CREATE TABLE Grades (
	StudentId INT NOT NULL,
	English FLOAT NOT NULL,
	Math FLOAT NOT NULL,
	ComputerScience FLOAT NOT NULL,

	-- Connecting the tables.
	CONSTRAINT Fk_Student FOREIGN KEY(StudentId)
	REFERENCES Students(Id)
)
GO

-- Insert some data into the tables
INSERT INTO Students (FirstName, LastName)
VALUES ('Alex', 'Smith'), ('Jessica', 'Huston'), ('Peter', 'Johnson'), ('Harry', 'Brown'), ('Karen', 'Jones')
GO

INSERT INTO Grades
VALUES (1, 8, 6, 9), (2, 6, 5, 5), (3, 9, 9, 9), (4, 9, 8, 9), (5, 3, 3, 3)
GO

-- Let's check if the information we added is okay.
SELECT * FROM Students
JOIN Grades ON Students.Id = Grades.StudentId