DROP DATABASE IF EXISTS RestaurantReservationSystem;
CREATE DATABASE RestaurantReservationSystem;
USE RestaurantReservationSystem;

CREATE TABLE Restaurants
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    `Name` VARCHAR(255) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    PeopleCapacity INT NOT NULL
);

CREATE TABLE Clients
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    ClientName VARCHAR(255) NOT NULL,
    Phone VARCHAR(10) NOT NULL,
    Email VARCHAR(100) NOT NULL
);

CREATE TABLE Menu
(
	PlateId INT PRIMARY KEY AUTO_INCREMENT,
    PlateName VARCHAR(200) NOT NULL,
    `Description` VARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Reservations
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    RestaurantId INT NOT NULL,
    ClientId INT NOT NULL,
    GuestsCount INT NOT NULL,
    DurationInHours INT NOT NULL,
    ReservationTime DATETIME NOT NULL,
    TablesCount INT NOT NULL,
    ReservationStatus ENUM('Confirmed', 'Non-Confirmed', 'Completed', 'Cancelled', 'Missed') NOT NULL,
    
	CONSTRAINT FOREIGN KEY (RestaurantId) REFERENCES Restaurants(Id),
    CONSTRAINT FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

CREATE TABLE `Tables`
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    NumberOfPlaces INT NOT NULL,
    TableNumber INT NOT NULL,
    ReservationId INT NOT NULL,
    Smoker BOOL NOT NULL,
    NumberOfChairs INT NOT NULL,
    EarnestAmount DECIMAL(18, 2) NOT NULL,
    TableState ENUM('Free', 'Busy', 'Reserved'),
    
    CONSTRAINT FOREIGN KEY (ReservationId) REFERENCES Reservations(Id)
);

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY AUTO_INCREMENT,
    ReservationId INT NOT NULL,
    PlateId INT NOT NULL,
    Quantity INT NOT NULL,
	TotalAmount DECIMAL(18, 2) NOT NULL,
    `Status` ENUM('Completed', 'Cancelled') NOT NULL,
    
  CONSTRAINT FOREIGN KEY (ReservationId) REFERENCES Reservations(Id),
  CONSTRAINT FOREIGN KEY (PlateId) REFERENCES Menu(PlateId)
);

INSERT INTO Restaurants (`Name`, Location, PeopleCapacity)
VALUES
    ('Pizzeria', 'New York City', 50),
    ('Sushi Bar', 'Tokyo', 30),
    ('Steakhouse', 'Houston', 100),
    ('Bistro', 'Paris', 40),
    ('Mexican Grill', 'Los Angeles', 70);
    
INSERT INTO Clients (ClientName, Phone, Email)
VALUES
    ('John Doe', '555-1234', 'johndoe@example.com'),
    ('Jane Smith', '555-5678', 'janesmith@example.com'),
    ('Bob Johnson', '555-9012', 'bobjohnson@example.com'),
    ('Sara Lee', '555-3456', 'saralee@example.com'),
    ('Mike Brown', '555-7890', 'mikebrown@example.com');
    
INSERT INTO Menu (PlateName, `Description`, Price)
VALUES
    ('Pepperoni Pizza', 'Classic pizza with tomato sauce, mozzarella cheese, and pepperoni', 12.99),
    ('California Roll', 'Sushi roll with crab, avocado, and cucumber', 8.99),
    ('Ribeye Steak', 'Grilled ribeye steak with garlic butter and mashed potatoes', 24.99),
    ('Croque Monsieur', 'Toasted sandwich with ham and cheese, served with fries', 9.99),
    ('Taco Plate', 'Three soft shell tacos with seasoned ground beef, lettuce, tomato, and cheese', 10.99);
  
INSERT INTO Reservations (RestaurantId, ClientId, GuestsCount, DurationInHours, ReservationTime, TablesCount, ReservationStatus)
VALUES
    (1, 2, 4, 120, '2023-04-10 18:00:00', 1, 'Confirmed'),
    (3, 1, 6, 90, '2023-04-12 19:30:00', 2, 'Non-Confirmed'),
    (2, 3, 2, 60, '2023-04-14 12:30:00', 1, 'Completed'),
    (4, 5, 3, 75, '2023-04-16 20:00:00', 1, 'Cancelled'),
    (5, 4, 8, 180, '2023-04-18 17:00:00', 3, 'Missed');
    
INSERT INTO `Tables` (NumberOfPlaces, TableNumber, ReservationId, Smoker, NumberOfChairs, EarnestAmount, TableState)
VALUES
(4, 1, 1, false, 4, 5.00, 'Reserved'),
(2, 2, 2, true, 2, 100.00, 'Free'),
(6, 3, 3, false, 6, 10.00, 'Reserved'),
(10, 2, 4, true, 10, 10.00, 'Reserved'),
(3, 2, 5, true, 3, 05.00, 'Free');

INSERT INTO Orders (ReservationId, PlateId, Quantity, TotalAmount, `Status`)
VALUES
(1, 1, 2, 21.98, 'Completed'),
(1, 2, 4, 35.96, 'Completed'),
(3, 3, 6, 107.94, 'Cancelled'),
(3, 3, 4, 48.00, 'Cancelled'),
(4, 4, 3, 75.00, 'Completed');