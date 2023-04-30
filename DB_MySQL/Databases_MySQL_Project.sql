#ТемаNo7 
#Да  се  разработи  база  данни  за  система  за  резервиране  на  маси  в дискотека/ресторант. 
#Пази се информация за масата – за колко човека, на  чие  име  е  резервацията,  пушачи/непушачи, 
#с  колко  стола,  от  колко часа,  сума  за  капаро.  
#Пази  се  информация  за  резервиралите –трите имена, телефон за обратна връзка, имейл. 
#Позволява се един човек да може  да  направи  повече  от  една  резервация.
#Допълнете  таблиците  с необходима информация по ваш избор.


DROP DATABASE IF EXISTS RestaurantReservationSystem;
CREATE DATABASE RestaurantReservationSystem;
USE RestaurantReservationSystem;

CREATE TABLE Departments
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    `Name` VARCHAR(50) NOT NULL 
);

CREATE TABLE Employees
(	
	Id INT PRIMARY KEY AUTO_INCREMENT,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    DepartmentId INT NOT NULL,
    PhoneNumber VARCHAR(100) NULL,
    Salary DECIMAL(18,2) NULL,
    
    CONSTRAINT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

CREATE TABLE SalaryPayments
(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	`Month` INT NOT NULL,
	`Year` YEAR NOT NULL,
	SalaryAmount DOUBLE NOT NULL,
	DateOfPayment DATETIME NOT NULL,
    
	CONSTRAINT FOREIGN KEY (EmployeeId) REFERENCES Employees(Id),
	UNIQUE KEY(`EmployeeId`, `Month`, `Year`)    
);

CREATE TABLE Restaurants
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    `Name` VARCHAR(255) NOT NULL,
    Location VARCHAR(255) NOT NULL,
    PeopleCapacity INT NOT NULL,
    ManagerId INT NOT NULL,
    
    CONSTRAINT FOREIGN KEY (ManagerId) REFERENCES Employees(Id)
);

CREATE TABLE Clients
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    ClientName VARCHAR(255) NOT NULL,
    Phone VARCHAR(10) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL 
);

CREATE TABLE MenuForPlates
(
	PlateId INT PRIMARY KEY AUTO_INCREMENT,
    PlateName VARCHAR(200) NOT NULL,
    `Description` VARCHAR(255) NOT NULL,
    Price DECIMAL(18, 2) NOT NULL
);

CREATE TABLE MenuForDrinks
(
	DrinkId INT PRIMARY KEY AUTO_INCREMENT,
    DrinkName VARCHAR(200) NOT NULL,
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
	EarnestAmount DECIMAL(18, 2) NOT NULL,
    ReservationStatus ENUM('Confirmed', 'Non-Confirmed', 'Completed', 'Cancelled', 'Missed') NOT NULL,
    
	CONSTRAINT FOREIGN KEY (RestaurantId) REFERENCES Restaurants(Id),
    CONSTRAINT FOREIGN KEY (ClientId) REFERENCES Clients(Id)
);

CREATE TABLE `Tables`
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    NumberOfPlaces INT NOT NULL,
    TableNumber INT NOT NULL,
    ReservationId INT NULL,
    Smoker BOOL NOT NULL,
    NumberOfChairs INT NOT NULL,
    TableState ENUM('Free', 'Busy', 'Reserved'),
    
    CONSTRAINT FOREIGN KEY (ReservationId) REFERENCES Reservations(Id)
);

CREATE TABLE Orders
(
	Id INT PRIMARY KEY AUTO_INCREMENT,
    ReservationId INT NOT NULL,
    PlateId INT NULL,
    DrinkId INT NULL,
    DrinkQuantity INT NULL,
    PlateQuantity INT NULL,
    `Status` ENUM('Completed', 'Cancelled') NOT NULL,
    WaiterId INT NOT NULL,
    
  CONSTRAINT FOREIGN KEY (ReservationId) REFERENCES Reservations(Id),
  CONSTRAINT FOREIGN KEY (PlateId) REFERENCES MenuForPlates(PlateId),
  CONSTRAINT FOREIGN KEY (DrinkId) REFERENCES MenuForDrinks(DrinkId),
  CONSTRAINT FOREIGN KEY (WaiterId) REFERENCES Employees(Id)
);

CREATE TABLE OrderPayments
(
    OrderPaymentId INT PRIMARY KEY AUTO_INCREMENT,
    OrderId INT NOT NULL,
    OrderPaymentMethod ENUM('Cash', 'Credit Card', 'Debit Card', 'Online Payment') NOT NULL,
    OrderPaymentDate DATETIME NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,
    
    CONSTRAINT FOREIGN KEY (OrderId) REFERENCES Orders(Id)
);

INSERT INTO Departments (`Name`) VALUES
('Management'),
('Kitchen'),
('Bar'),
('Service'),
('Cleaning');

INSERT INTO Employees (FirstName, LastName, DepartmentId, PhoneNumber, Salary) VALUES
('John', 'Doe', 1, '1234567890', 5000.00),
('Jane', 'Doe', 1, '0987654321', 5500.00),
('Bob', 'Smith', 2, '5551234', 4500.00),
('Alice', 'Johnson', 3, '5555678', 4200.00),
('Tom', 'Jones', 4, '5553322', 4800.00);

INSERT INTO SalaryPayments (EmployeeId, `Month`, `Year`, SalaryAmount, DateOfPayment) VALUES
(1, 1, 2023, 5000.00, '2023-01-31 10:50:00'),
(2, 2, 2023, 5500.00, '2023-02-09 12:45:42'),
(3, 2, 2023, 4500.00, '2023-02-18 16:18:02'),
(4, 3, 2023, 4200.00, '2023-03-07 17:08:07'),
(5, 4, 2023, 4800.00, '2023-04-05 09:05:06');

INSERT INTO Restaurants (`Name`, Location, PeopleCapacity, ManagerId) VALUES
('La Piazza', 'Sofia, Bulgaria', 100, 1),
('The Great Wall', 'New York, USA', 150, 2),
('Chez Maurice', 'Paris, France', 80, 3),
('Sushi Garden', 'Tokyo, Japan', 120, 4),
('El Fuego', 'Mexico City, Mexico', 90, 5),
('La Dolce Vita',	'123 Main Street',	50,	3),
('The Brasserie',	'456 Elm Street',	80,	5),
('The Steakhouse',	'789 Oak Street',	100,	2),
('Le Bistro Francais',	'345 Maple Street',	70,	4),
('The Sushi Bar',	'678 Pine Street',	60,	1);

INSERT INTO Clients (ClientName, Phone, Email, Balance) VALUES
('John Smith', '5551234', 'john.smith@example.com', 12000),
('Jane Smith', '5555678', 'jane.smith@example.com', 12700),
('Bob Johnson', '5553322', 'bob.johnson@example.com', 1100),
('Alice Williams', '5558765', 'alice.williams@example.com', 2500),
('Tom Brown', '5559012', 'tom.brown@example.com', 7000),
('John Johnson',	'0888888888',	'john.johnson@gmail.com', 9000),
('Maria Garcia',	'0899999999',	'maria.garcia@yahoo.com', 14000),
('Peter Kim',	'0877777777',	'peter.kim@hotmail.com', 1278),
('Emma Johnson',	'0866666666',	'emma.johnson@gmail.com', 5890),
('Alex Lee',	'0855555555',	'alex.lee@gmail.com', 4580);

INSERT INTO MenuForPlates (PlateName, `Description`, Price) VALUES
('Spaghetti Carbonara', 'Spaghetti with bacon and egg sauce', 10.50),
('Beef Stroganoff', 'Sautéed pieces of beef in sour cream sauce', 11.00),
('Spaghetti Carbonara',	'Spaghetti with bacon, eggs and Parmesan cheese.',	14.99),
('Margherita Pizza',	'Tomato sauce, mozzarella cheese and basil.',	12.99),
('Caesar Salad',	'Romaine lettuce, croutons, Parmesan cheese, and Caesar dressing.',	8.99),
('Beef Burger',	'Beef patty, lettuce, tomato, onion, and pickles.',	10.99),
('Fish and Chips',	'Battered fish fillets with fries.',	16.99);

INSERT INTO MenuForDrinks(DrinkName, `Description`, Price) VALUES
('Coca-Cola', 'Refreshing carbonated soft drink', 2.50),
('Orange Juice', 'Freshly squeezed orange juice', 4.00),
('Espresso', 'Strong coffee served in a small cup', 2.00),
('Tea', 'Aromatic hot beverage made from steeping tea leaves in hot water', 2.50),
('Mojito', 'Traditional Cuban highball cocktail', 7.00);

INSERT INTO Reservations(RestaurantId, ClientId, GuestsCount, DurationInHours, ReservationTime, TablesCount, EarnestAmount, ReservationStatus) VALUES
(1, 2, 4, 2, '2023-05-01 19:00:00', 1, 20.00, 'Confirmed'),
(1, 1, 2, 1, '2023-05-02 12:30:00', 1, 10.00, 'Cancelled'),
(2, 3, 6, 3, '2023-05-05 18:00:00', 2, 40.00, 'Confirmed'),
(3, 4, 3, 1, '2023-05-07 20:00:00', 1, 15.00, 'Confirmed'),
(2, 5, 2, 2, '2023-05-08 13:00:00', 1, 10.00, 'Confirmed');

INSERT INTO `Tables`(NumberOfPlaces, TableNumber, ReservationId, Smoker, NumberOfChairs, TableState) VALUES
(2, 1, 1, 0, 2, 'Free'),
(4, 2, 2, 0, 4, 'Reserved'),
(6, 1, 3, 0, 6, 'Free'),
(2, 2, 4, 1, 2, 'Reserved'),
(4, 1, 5, 0, 4, 'Free');
    
INSERT INTO Orders(ReservationId, PlateId, DrinkId, PlateQuantity, DrinkQuantity, `Status`, WaiterId) VALUES
(1, 1, NULL, 2, 0, 'Completed', 3),
(2, NULL, 3, 0, 2, 'Completed', 2),
(3, 4, 5, 2, 6, 'Completed', 3),
(4, 2, 3, 1, 8, 'Cancelled', 1),
(5, 3, NULL, 2, 0, 'Completed', 4);

INSERT INTO OrderPayments (OrderId, OrderPaymentMethod, OrderPaymentDate, TotalAmount)
VALUES (1, 'Cash', '2023-04-25 15:30:00', 120.50),
(2, 'Credit Card', '2023-04-26 09:45:00', 256.75),
(3, 'Debit Card', '2023-04-27 12:15:00', 50.00),
(4, 'Online Payment', '2023-04-28 16:20:00', 75.30),
(5, 'Credit Card', '2023-04-29 14:00:00', 182.90);

#2 SELECT с ограничаващо условие по избор
SELECT * FROM Restaurants
WHERE `Name` LIKE '%The%';

SELECT * FROM `Tables`
WHERE TableState = 'Free';

SELECT * FROM Reservations 
WHERE ReservationStatus = 'Confirmed';

#3 агрегатна функция и GROUP BY
SELECT e.Id, AVG(sp.SalaryAmount) AS AverageOfAllPayment
FROM Employees AS e 
JOIN SalaryPayments AS sp ON sp.EmployeeId = e.Id
GROUP BY e.Id;

#4 INNER JOIN
SELECT restaurant.Name, CONCAT(e.FirstName, ' ', e.LastName) AS ManagerName, res.Id AS ReservationId, 
t.TableNumber, t.Smoker, c.ClientName
FROM Reservations AS res
JOIN Restaurants AS restaurant ON restaurant.Id = res.RestaurantId
JOIN Employees AS e ON e.Id = restaurant.ManagerId
JOIN `Tables` AS t ON t.ReservationId = res.Id
JOIN Clients AS c ON c.Id = res.ClientId;

#5 OUTER JOIN изваждаме всички поръчки, в които може и да няма напитка или ястие
SELECT o.Id AS OrderId, p.PlateName, d.DrinkName, CONCAT(e.FirstName, ' ', e.LastName) AS WaiterName
FROM Orders AS o
LEFT OUTER JOIN Employees AS e ON e.Id = o.WaiterId
LEFT OUTER JOIN MenuForPlates AS p ON p.PlateId = o.PlateId
LEFT OUTER JOIN MenuForDrinks AS d ON d.DrinkId = o.DrinkId;

#6 вложен SELECT ??
SELECT CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, t.TableNumber, t.NumberOfPlaces
FROM Employees AS e
JOIN `Tables` AS t ON t.Id IN (
    SELECT Id
    FROM `Tables`
    WHERE NumberOfPlaces >= 5
);

#7 JOIN и агрегатна функция
SELECT e.Id, CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName, SUM(sp.SalaryAmount) AS SumOfAllPaymentPerEmployee, sp.Month
FROM SalaryPayments AS sp 
JOIN Employees AS e ON sp.EmployeeId = e.Id
GROUP BY sp.Month, e.Id
ORDER BY EmployeeName
LIMIT 3;

#8 TRIGGER
DROP TABLE IF EXISTS SalaryPaymentsLog;
CREATE TABLE SalaryPaymentsLog(
	Id INT AUTO_INCREMENT PRIMARY KEY,
	Operation ENUM('INSERT','UPDATE','DELETE') NOT NULL,
	OldEmployeeId INT,
	NewEmployeeId INT,
	OldMonth INT,
	NewMonth INT,
	OldYear INT,
	NewYear INT,
	OldSalaryAmount DECIMAL,
	NewSalaryAmount DECIMAL,
	OldDateOfPayment DATETIME,
	NewDateOfPayment DATETIME,
	DateOfLog DATETIME
);

DROP TRIGGER IF EXISTS After_SalaryPayment_Update ;
DELIMITER |
CREATE TRIGGER After_SalaryPayment_Update AFTER UPDATE ON SalaryPayments
FOR EACH ROW
BEGIN
INSERT INTO SalaryPaymentsLog(operation, OldEmployeeId, NewEmployeeId, OldMonth,
NewMonth, OldYear, NewYear, OldSalaryAmount, NewSalaryAmount, OldDateOfPayment, 
NewDateOfPayment, dateOfLog)
VALUES ('UPDATE', 
OLD.EmployeeId, 
CASE NEW.EmployeeId WHEN OLD.EmployeeId THEN NULL ELSE NEW.EmployeeId END,
OLD.`Month`, 
CASE NEW.`Month` WHEN OLD.`Month` THEN NULL ELSE NEW.`Month` END,
OLD.`Year`, 
CASE NEW.`Year` WHEN OLD.`Year` THEN NULL ELSE NEW.`Year` END,
OLD.SalaryAmount, 
CASE NEW.SalaryAmount WHEN OLD.SalaryAmount THEN NULL ELSE NEW.SalaryAmount END,
OLD.DateOfPayment, 
CASE NEW.DateOfPayment WHEN OLD.DateOfPayment THEN NULL ELSE NEW.DateOfPayment END,
NOW());
END;
|
DELIMITER ;

UPDATE SalaryPayments SET `Month` = 4 
WHERE Id = 1;

SELECT * FROM SalaryPaymentsLog;

#9 PROCEDURE WITH CURSOS

DROP PROCEDURE IF EXISTS UpdateOrderPayments;
DELIMITER //
CREATE PROCEDURE UpdateOrderPayments()
BEGIN
	DECLARE done INT DEFAULT FALSE;
	DECLARE orderId INT;
	DECLARE orderPaymentMethod ENUM('Cash', 'Credit Card', 'Debit Card', 'Online Payment');
	DECLARE orderPaymentDate DATETIME;
	DECLARE totalAmount DECIMAL(18, 2);

	DECLARE curOrders CURSOR FOR SELECT Id FROM Orders;
	
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
	OPEN curOrders;
	
	orderLoop: LOOP
		FETCH curOrders INTO orderId;
		IF done THEN
			LEAVE orderLoop;
		END IF;
		
		SET orderPaymentMethod = 
        CASE 
			WHEN RAND() < 0.5 THEN 'Cash' 
            ELSE 'Credit Card' 
		END;
		SET orderPaymentDate = NOW(); -- set payment date to current time
        
		SET totalAmount = (SELECT IFNULL(SUM(PlateQuantity * p.Price), 0) 
							+ IFNULL(SUM(DrinkQuantity * d.Price), 0)
							FROM Orders o
							LEFT JOIN MenuForPlates p ON o.PlateId = p.PlateId
							LEFT JOIN MenuForDrinks d ON o.DrinkId = d.DrinkId
							WHERE o.Id = orderId); -- calculate total amount for the order
		
		INSERT INTO OrderPayments (OrderId, OrderPaymentMethod, OrderPaymentDate, TotalAmount)
		VALUES (orderId, orderPaymentMethod, orderPaymentDate, totalAmount);
	END LOOP;
	
	CLOSE curOrders;	
END //
DELIMITER ;

CALL UpdateOrderPayments();

SELECT * FROM OrderPayments;
