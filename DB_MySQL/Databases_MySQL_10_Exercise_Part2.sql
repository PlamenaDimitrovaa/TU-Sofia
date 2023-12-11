USE `cableCompany`;

-- 1
DELIMITER //
CREATE PROCEDURE monthly_payment(
    IN customer_id INT,
    IN payment_amount DOUBLE,
    OUT success BIT
)
BEGIN
	DECLARE total_debt DOUBLE DEFAULT 0;	
	-- Получаване на дължимата сума за клиента, ако има такава
	SELECT debt_amount INTO total_debt
	FROM debtors
	WHERE customer_id = customer_id
	LIMIT 1;
	
	IF total_debt > 0 THEN
	    -- Ако има дължима сума, извеждаме съобщение и не извършваме плащане
	    SELECT 'This customer has an outstanding debt of ' AS message, total_debt AS amount;
	    SET success = 0;
	ELSE
	    -- Ако няма дължима сума, извършваме плащането
	    UPDATE accounts
	    SET amount = amount - payment_amount
	    WHERE customer_id = customer_id;
	    
	    INSERT INTO payments(paymentAmount, month, year, dateOfPayment, customer_id, plan_id)
	    VALUES (payment_amount, MONTH(NOW()), YEAR(NOW()), NOW(), customer_id, (SELECT planID FROM customers WHERE customerID = customer_id));
	    
	    -- Проверка за успешно плащане и задаване на стойността на параметъра "success"
	    SELECT ROW_COUNT() INTO success;
	END IF;	
END //
DELIMITER ;

-- 2
DELIMITER $$
CREATE PROCEDURE `make_payments`()
BEGIN
	DECLARE done INT DEFAULT FALSE;
	DECLARE customerID INT UNSIGNED;
	DECLARE planID INT UNSIGNED;
	DECLARE remainingAmount DOUBLE;
	DECLARE paymentAmount DOUBLE;
	DECLARE cursor1 CURSOR FOR 
		SELECT accounts.customer_id, accounts.amount, plans.planID, plans.monthly_fee
		FROM cableCompany.accounts
		INNER JOIN cableCompany.plans
			ON accounts.customer_id = plans.customer_id
		WHERE accounts.amount > 0;
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = TRUE;

	START TRANSACTION;
	OPEN cursor1;
	cursor_loop: LOOP
		FETCH cursor1 INTO customerID, remainingAmount, planID, paymentAmount;
		IF done THEN
			LEAVE cursor_loop;
		END IF;
		IF remainingAmount >= paymentAmount THEN
			UPDATE cableCompany.accounts
			SET amount = amount - paymentAmount
			WHERE customer_id = customerID;
			INSERT INTO cableCompany.payments (paymentAmount, month, year, dateOfPayment, customer_id, plan_id)
			VALUES (paymentAmount, MONTH(CURRENT_DATE - INTERVAL 1 MONTH), YEAR(CURRENT_DATE - INTERVAL 1 MONTH), NOW(), customerID, planID);
		ELSE
			INSERT INTO cableCompany.debtors (customer_id, plan_id, debt_amount)
			VALUES (customerID, planID, paymentAmount - remainingAmount);
			UPDATE cableCompany.accounts
			SET amount = 0
			WHERE customer_id = customerID;
			INSERT INTO cableCompany.payments (paymentAmount, month, year, dateOfPayment, customer_id, plan_id)
			VALUES (remainingAmount, MONTH(CURRENT_DATE - INTERVAL 1 MONTH), YEAR(CURRENT_DATE - INTERVAL 1 MONTH), NOW(), customerID, planID);
		END IF;
	END LOOP;
	CLOSE cursor1;
	COMMIT;
END$$
DELIMITER ;

-- 3
DELIMITER |
CREATE EVENT `payment_event`
ON SCHEDULE
EVERY 1 MONTH STARTS '2023-01-28' -- event-ът започва на 28-ми януари 2023 г.
DO
BEGIN
	CALL make_payments();
END
| 
DELIMITER ;

-- 4
CREATE VIEW `customer_debts` AS
SELECT CONCAT(c.`firstName`, ' ', c.`middleName`, ' ', c.`lastName`) AS `customer_name`,
       p.`month`,
       p.`year`,
       pl.`name` AS `plan_name`,
       d.`debt_amount`
FROM `customers` c
JOIN payments p ON p.customer_id = c.customerID
JOIN plans pl ON pl.planID = p.plan_id
JOIN debtors d ON d.customer_id = c.customerID;

-- 5
DELIMITER //
CREATE TRIGGER `check_monthly_fee`
BEFORE INSERT ON plans
FOR EACH ROW
BEGIN
    IF NEW.monthly_fee < 10 THEN
        SIGNAL SQLSTATE '45000' 
        SET MESSAGE_TEXT = 'Monthly fee must be at least 10';
    END IF;
END //
DELIMITER ;

-- 6
DELIMITER //
CREATE TRIGGER `check_account_amount`
BEFORE INSERT ON accounts
FOR EACH ROW
BEGIN
    DECLARE debt_amount DOUBLE;
    SELECT debt_amount INTO debt_amount
    FROM debtors
    WHERE customer_id = NEW.customer_id AND plan_id = (
        SELECT plan_id
        FROM payments
        WHERE customer_id = NEW.customer_id
        ORDER BY year DESC, month DESC
        LIMIT 1
    );
    IF debt_amount IS NOT NULL AND NEW.amount < debt_amount THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Amount must not be less than the outstanding debt';
    END IF;
END //
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
DELIMITER |
CREATE PROCEDURE GetCustomerPayments (IN firstName VARCHAR(55), IN lastName VARCHAR(55))
BEGIN
	DECLARE customerId INT UNSIGNED;
    -- Намираме ID-то на клиента, използвайки подадените имена
	SELECT customerID INTO customerId FROM customers
	WHERE firstName = firstName AND lastName = lastName;
    -- Ако не намерим клиент с тези имена, прекратяваме изпълнението на процедурата
	IF customerId IS NULL THEN
		SELECT 'Customer not found' AS message;
		LEAVE GetCustomerPayments;
	END IF;    
    -- Извеждаме всички данни за клиента
	SELECT * FROM customers WHERE customerID = customerId;
    -- Извеждаме информацията за всички плащания на клиента
	SELECT p.paymentID, p.paymentAmount, p.month, p.year, p.dateOfPayment, pl.name AS planName, pl.monthly_fee
	FROM payments p
	INNER JOIN plans pl ON p.plan_id = pl.planID
	WHERE p.customer_id = customerId;
END |
DELIMITER ;
