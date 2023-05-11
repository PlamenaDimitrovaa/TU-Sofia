-- 2
DROP PROCEDURE IF EXISTS procExercise2;
DELIMITER |
CREATE PROCEDURE procExercise2()
BEGIN
	DECLARE planId INT;
    DECLARE tax DOUBLE;
    DECLARE id_of_customer INT;
    DECLARE currAmount DOUBLE;
	DECLARE DONE INT DEFAULT FALSE;
	DECLARE cur CURSOR FOR (SELECT a.customer_id, a.amount 
							FROM accounts a
							WHERE a.amount > 0);
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;
    
	SET planId = 1;
    SET tax = (SELECT monthly_fee FROM plans WHERE planID = planId);
    
    -- start transaction
   BEGIN
		OPEN cur;
		read_loop: LOOP
			FETCH cur INTO id_of_customer, currAmount;
			IF done THEN 
				LEAVE read_loop;
			END IF;
            
			IF tax > currAmount
				THEN INSERT INTO debtors (customer_id, plan_id, debt_amount)
							VALUES (id_of_customer, planId, tax);
			ELSE 
				INSERT INTO payments (paymentAmount, month, year, dateOfPayment, customer_id, plan_id)
							VALUES (tax, MONTH(CURDATE()), YEAR(CURDATE()), CURDATE(), id_of_customer, planId);
				
				UPDATE accounts
				SET amount = amount - tax
				WHERE customer_id = id_of_customer;
			END IF;
		END LOOP;
	END;
	COMMIT;
END;
|
DELIMITER ;

CALL procExercise2();

-- 3
DELIMITER |
CREATE EVENT exercise3Event
ON SCHEDULE EVERY 1 MONTH
STARTS '2023-05-28'
DO
BEGIN
	CALL procExercise2();
END ;
|
DELIMITER ;

-- 4
CREATE VIEW view_name AS
SELECT c.firstName, c.middleName, c.lastName, p.month, p.year, pl.name, d.debt_amount
FROM customers c
JOIN payments p ON p.customer_id = c.customerID
JOIN plans pl ON pl.planID = p.plan_id
JOIN debtors d ON d.customer_id = c.customerID;

-- 5
DROP TRIGGER IF EXISTS triggerName;
DELIMITER |
CREATE TRIGGER triggerName BEFORE INSERT ON plans
FOR EACH ROW
BEGIN
	IF(new.monthly_fee < 10)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid monthly fee';
	END IF;
END;
|
DELIMITER ;

-- 6
DROP TRIGGER IF EXISTS triggerExercise6;
DELIMITER |
CREATE TRIGGER triggerExercise6 BEFORE INSERT ON accounts
FOR EACH ROW
BEGIN
	DECLARE debt DOUBLE;
    SET debt = (SELECT debt_amount FROM debtors WHERE customer_id = new.customer_id);
    
    IF (debt > new.amount)
		THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Invalid amount';
    END IF;
END;
|
DELIMITER ;

-- 7
DROP PROCEDURE IF EXISTS procExercise7;
DELIMITER |
CREATE PROCEDURE procExercise7(IN first_name VARCHAR(100), IN middle_name VARCHAR(100), IN last_name VARCHAR(100))
BEGIN
	SELECT * 
    FROM customers c
    LEFT JOIN payments p ON p.customer_id = c.customerID
    WHERE c.firstName = first_name AND c.middleName = middle_name AND c.lastName = last_name;
END;
|
DELIMITER ;

CALL procExercise7('Ivan', 'Ivanov', 'Ivanov');