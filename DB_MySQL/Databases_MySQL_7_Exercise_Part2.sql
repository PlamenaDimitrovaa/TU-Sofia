DELIMITER |
DROP PROCEDURE IF EXISTS SportsProc |
CREATE PROCEDURE SportsProc(IN coachName VARCHAR(255))
BEGIN
SELECT s.name, sg.location, sg.dayOfWeek, sg.hourOfTraining, st.name, st.phone
FROM sports AS s
JOIN sportgroups AS sg ON sg.sport_id = s.id
JOIN student_sport AS ss ON ss.sportGroup_id = sg.id
JOIN students AS st ON st.id = ss.student_id
JOIN coaches AS c ON c.id = sg.coach_id
WHERE c.name = coachName;
END |
DELIMITER ;

CALL SportsProc ("Ivan Todorov Petkov");

DELIMITER |
DROP PROCEDURE IF EXISTS ProcById |
CREATE PROCEDURE ProcById(IN sportId INT)
BEGIN
SELECT s.name AS SportName, st.name AS StudentName, c.name AS CoachName
FROM sports AS s 
JOIN sportgroups AS sg ON sg.sport_id = s.id
JOIN student_sport AS ss ON ss.sportGroup_id = sg.id
JOIN students AS st ON st.id = ss.student_id
JOIN coaches AS c ON c.id = sg.coach_id
WHERE s.id = sportId;
END |
DELIMITER ;

CALL ProcById (2);

DELIMITER |
DROP PROCEDURE IF EXISTS ProcByNameAndYear |
CREATE PROCEDURE ProcByNameAndYear(IN studentName VARCHAR(255), IN paymentYear INT)
BEGIN
SELECT AVG(tp.paymentAmount) AS AverageSum
FROM students AS st 
JOIN taxespayments AS tp ON tp.student_id = st.id
WHERE st.name = studentName AND tp.year = paymentYear;
END |
DELIMITER ;

CALL ProcByNameAndYear ("Iliyan Ivanov", 2021);

DELIMITER |
DROP PROCEDURE IF EXISTS ProcByCoachName |
CREATE PROCEDURE ProcByCoachName(IN coachName VARCHAR(255))
BEGIN

	DECLARE coach_id INT;
	DECLARE groupCount INT;
	
	SELECT id 
    INTO coach_id 
    FROM coaches 
    WHERE name = coachName;
    
	SELECT COUNT(*) 
    INTO groupCount
    FROM sportGroups 
    WHERE coach_id = coach_id;
	
	IF groupCount > 0 THEN
		SELECT coachName, groupCount;
	ELSE
		SELECT CONCAT(coachName, ' is not coaching any sport groups');
	END IF;
END |
DELIMITER ;

CALL ProcByCoachName('Ivan Todorov Petkov');

USE transaction_test;

DELIMITER |
DROP PROCEDURE IF EXISTS MoneyTransfer |
CREATE PROCEDURE MoneyTransfer(IN PayerAccountId INT, IN ReceiverAccountId INT, IN sum DECIMAL)
BEGIN

 DECLARE from_balance DECIMAL(10,2);
 DECLARE rows_affected INT;
    
START TRANSACTION;

    SELECT amount 
    INTO from_balance
    FROM customer_accounts 
    WHERE id = PayerAccountId;    
   
    IF from_balance < sum 
    THEN
		SELECT "Transaction failed" AS Result;
        ROLLBACK;
    ELSE
       
        UPDATE customer_accounts SET amount = amount - sum WHERE id = PayerAccountId;
        UPDATE customer_accounts SET amount = amount + sum WHERE id = ReceiverAccountId;
        
        SELECT ROW_COUNT() INTO rows_affected;
        IF rows_affected = 0 THEN
            SELECT "Transaction Failed" AS Result;
            ROLLBACK;
		ELSE 
			SELECT "Success" AS Result;
            COMMIT;
        END IF;
    END IF;
END |
DELIMITER ;

CALL MoneyTransfer(1, 2, 100);

DELIMITER |
DROP PROCEDURE IF EXISTS MoneyTransferWithNames |
CREATE PROCEDURE MoneyTransferWithNames(IN PayerName VARCHAR(255), IN ReceiverName VARCHAR(255), IN Currency VARCHAR(50), IN sum DECIMAL)
BEGIN

 DECLARE from_balance DECIMAL(10,2);
 DECLARE rows_affected INT;
    
START TRANSACTION;

    SELECT ca.amount 
    INTO from_balance
    FROM customer_accounts AS ca
    JOIN customers AS c ON ca.id = c.id
    WHERE c.name = PayerName;    
   
    IF from_balance < sum 
    THEN
		SELECT "Transaction failed" AS Result;
        ROLLBACK;
    ELSE
       
       
        UPDATE customer_accounts SET amount = amount - sum WHERE id = (SELECT c.id AS PayerId 
																		   FROM customers AS c
																		   WHERE c.name = PayerName);
                                                                           
        UPDATE customer_accounts SET amount = amount + sum WHERE id = (SELECT c.id AS ReceiverId 
																		   FROM customers AS c
																		   WHERE c.name = ReceiverName);
        
        SELECT ROW_COUNT() INTO rows_affected;
        IF rows_affected = 0 THEN
            SELECT "Transaction Failed" AS Result;
            ROLLBACK;
		ELSE 
			SELECT "Success" AS Result;
            COMMIT;
        END IF;
    END IF;
END |
DELIMITER ;

CALL MoneyTransferWithNames("Ivan Petrov Iordanov", "Stoyan Pavlov Pavlov", "BGN", 100);

