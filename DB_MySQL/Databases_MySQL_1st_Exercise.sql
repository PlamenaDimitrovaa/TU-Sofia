DROP DATABASE IF EXISTS sportClubs;
CREATE DATABASE sportClubs;
USE sportClubs;

CREATE TABLE Sports
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    SportName VARCHAR(30) NOT NULL
);

CREATE TABLE Students
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    StudentName VARCHAR(255) NOT NULL,
    FacultyNumber VARCHAR(10) NOT NULL UNIQUE,
    Phone VARCHAR(30) NULL
);

CREATE TABLE Coaches
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    CoachName VARCHAR(255) NOT NULL,
    EGN VARCHAR(10) NOT NULL UNIQUE
);

CREATE TABLE `Groups`
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    DayOfWeek ENUM ('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'),
    HourOfDay TIME NOT NULL,
    Location VARCHAR(255) NOT NULL,
    SportId INT NOT NULL,
    CoachId INT NOT NULL,
    
    CONSTRAINT FOREIGN KEY (SportId) REFERENCES Sports(Id),
    CONSTRAINT FOREIGN KEY (CoachId) REFERENCES Coaches(Id),
    UNIQUE KEY (DayOfWeek, HourOfDay, Location)
);

CREATE TABLE StudentsGroups
(
	StudentId INT NOT NULL,
    GroupId INT NOT NULL,
    
    CONSTRAINT FOREIGN KEY (StudentId) REFERENCES Students(Id),
    CONSTRAINT FOREIGN KEY (GroupId) REFERENCES `Groups`(Id),
    PRIMARY KEY(StudentId, GroupId)
);