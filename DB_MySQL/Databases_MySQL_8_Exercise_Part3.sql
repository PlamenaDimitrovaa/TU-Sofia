CREATE VIEW CoachView
AS
SELECT c.name, CONCAT(c.id, ' - ', sg.location) AS groupInfo, s.name, sp.year, sp.month, sp.salaryamount
FROM coaches AS c 
JOIN sportgroups AS sg ON c.id = sg.coach_id
JOIN sports AS s ON s.id = sg.sport_id
JOIN salarypayments AS sp ON sp.coach_id = c.id;

INSERT INTO salarypayments (coach_id, month, year, salaryamount, dateOfPayment)
VALUES 
(1, 5, 2020, 1000, now()),
(2, 2, 2023, 2000, now()),
(3, 4, 2022, 5000, now()),
(4, 10, 2020, 3000, now()),
(5, 7, 2022, 1500, now());

DELIMITER |
DROP PROCEDURE IF EXISTS StudentProc |
CREATE PROCEDURE StudentProc()
BEGIN
SELECT s.name
FROM students AS s
JOIN student_sport AS ss ON s.id = ss.student_id
JOIN sportgroups AS sg ON sg.id = ss.sportGroup_id
GROUP BY (s.name)
HAVING COUNT(sg.id) > 1;
END |
DELIMITER ;

DELIMITER |
DROP PROCEDURE IF EXISTS CoachProc |
CREATE PROCEDURE CoachProc()
BEGIN
SELECT c.name
FROM coaches AS c
WHERE c.id NOT IN (
SELECT DISTINCT coach_id
FROM sportgroups
);
END |
DELIMITER ;

USE transaction_test;

DELIMITER |
DROP PROCEDURE IF EXISTS Converter |
CREATE PROCEDURE Converter(IN sum DECIMAL, IN valuteFrom VARCHAR(10), IN valuteTo VARCHAR(10), OUT result DECIMAL(18,2))
BEGIN
IF(valuteFrom = 'EURO' AND valuteTo = 'BGN')
	THEN SET result = sum * 2; 
ELSEIF(valuteFrom = 'BGN' AND valuteTo = 'EURO')
	THEN SET result = sum / 2; 
ELSE SELECT 'Invalid Parameters!';
END IF;
END |
DELIMITER ;

DELIMITER |
DROP PROCEDURE IF EXISTS MoneyTransfer |
CREATE PROCEDURE MoneyTransfer(IN PayerAccountId INT, IN ReceiverAccountId INT, IN sum DECIMAL, IN currencyFrom VARCHAR(10),  IN currencyTo VARCHAR(10))
BEGIN

 DECLARE from_balance DECIMAL(18,2);
 DECLARE rows_affected INT;
    
START TRANSACTION;

    SELECT amount 
    INTO from_balance
    FROM customer_accounts 
    WHERE id = PayerAccountId;    
   
   IF(currencyFrom = 'BGN' AND currencyTo = 'EURO')
		THEN CALL Converter(sum, currencyFrom, currencyTo, @result);
	ELSEIF(currencyFrom = 'EURO' AND currencyTo = 'BGN')
		THEN CALL Converter(sum, currencyFrom, currencyTo, @result);
	ELSE
		SELECT "Transaction failed" AS Result;
        rollback;
	END IF;
	
    IF from_balance < @result 
    THEN
		SELECT "Transaction failed" AS Result;
        ROLLBACK;
    ELSE
        UPDATE customer_accounts SET amount = amount - @result WHERE id = PayerAccountId;
        UPDATE customer_accounts SET amount = amount + @result WHERE id = ReceiverAccountId;
        
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

CALL MoneyTransfer(1, 2, 100, 'EURO', 'BGN');