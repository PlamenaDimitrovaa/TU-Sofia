DROP DATABASE IF EXISTS AirportWebSystemDB;
CREATE DATABASE AirportWebSystemDB;
USE AirportWebSystemDB;

CREATE TABLE Departments
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(50) NOT NULL
);

CREATE TABLE Employees
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    ManagerId INT NOT NULL,
    PhoneNumber VARCHAR(100) NULL,
    Salary DECIMAL(18,2) NULL,
    
    CONSTRAINT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    CONSTRAINT FOREIGN KEY (ManagerId) REFERENCES Employees(Id)
);

CREATE TABLE Aircrafts
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    Brand VARCHAR(100) NOT NULL,
    Number VARCHAR(100) NOT NULL,
    DateOfProduction DATE NOT NULL,
    Manufacturer VARCHAR(100) NOT NULL,
    PassengersCount INT NOT NULL
);

CREATE TABLE Flights
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    FlightNumber VARCHAR(100) NOT NULL,
    AircraftId INT NOT NULL,
    PilotId INT NOT NULL,
    StewardessId INT NOT NULL,
    DepartureTime DATE NOT NULL,
    ArrivalTime DATE NOT NULL,
    
    CONSTRAINT FOREIGN KEY (AircraftId) REFERENCES Aircrafts(Id),
    CONSTRAINT FOREIGN KEY (PilotId) REFERENCES Employees(Id),
    CONSTRAINT FOREIGN KEY (StewardessId) REFERENCES Employees(Id)
);