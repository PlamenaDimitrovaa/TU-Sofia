DELIMITER $
DROP PROCEDURE IF EXISTS testProc $
CREATE PROCEDURE testProc()
BEGIN
SELECT sports.name, sportGroups.location
FROM sports 
JOIN sportGroups
ON sports.id = sportGroups.sport_id;
END $
DELIMITER ;
CALL testProc();

#BY VALUE
DELIMITER $
DROP PROCEDURE IF EXISTS testProc $
CREATE PROCEDURE testProc(IN testParam VARCHAR(255))
BEGIN
SELECT testParam;
SET testParam = "Ivan";
SELECT testParam;
END $
DELIMITER ;
SET @name = "Georgi";
CALL testProc(@name);
SELECT @name;

#BY REFERENCE
DELIMITER $
DROP PROCEDURE IF EXISTS testProc $
CREATE PROCEDURE testProc(OUT testParam VARCHAR(255))
BEGIN
SELECT testParam;
SET testParam = "Ivan";
SELECT testParam;
END $
DELIMITER ;
SET @name = "Georgi";
CALL testProc(@name);
SELECT @name;

#BY REFERENCE
DELIMITER $
DROP PROCEDURE IF EXISTS testProc $
CREATE PROCEDURE testProc(INOUT testParam VARCHAR(255))
BEGIN
SELECT testParam;
SET testParam = "Ivan";
SELECT testParam;
END $
DELIMITER ;
SET @name = "Georgi";
CALL testProc(@name);
SELECT @name;

use school_sport_clubs;


#drop procedure getAllPaymentsAmount;
delimiter |
CREATE procedure getAllPaymentsAmount(IN firstMonth INT, IN secMonth INT, IN paymentYear INT, IN studId INT)
BEGIN
	DECLARE iterator int;
	IF(firstMonth >= secMonth)
    THEN 
		SELECT 'Please enter correct months!' as RESULT;
	ELSE IF((SELECT COUNT(*)
			FROM taxesPayments
			WHERE student_id = studId ) = 0)
        THEN SELECT 'Please enter correct student_id!' as RESULT;
		ELSE
	
	SET ITERATOR = firstMonth;

		WHILE(iterator >= firstMonth AND iterator <= secMonth)
		DO
			SELECT student_id, group_id, paymentAmount, month
			FROM taxespayments
			WHERE student_id = studId
			AND year = paymentYear
			AND month = iterator;
    
			SET iterator = iterator + 1;
		END WHILE;
		END IF;
    
    END IF;
END;
|
DELIMITER ;
CALL getAllPaymentsAmount(1, 6, 2021, 1);


#WITH TEMPORARY TABLE
use school_sport_clubs;
#drop procedure getAllPaymentsAmountOptimized;
delimiter |
CREATE procedure getAllPaymentsAmountOptimized(IN firstMonth INT, IN secMonth INT, IN paymentYear INT, IN studId INT)
BEGIN
    DECLARE iterator int;
    CREATE TEMPORARY TABLE tempTbl(
    student_id int, 
    group_id int,
    paymentAmount double,
    month int
    ) ENGINE = Memory;
    
    
	IF(firstMonth >= secMonth)
    THEN 
		SELECT 'Please enter correct months!' as RESULT;
	ELSE IF((SELECT COUNT(*)
			FROM taxesPayments
			WHERE student_id =studId ) = 0)
        THEN SELECT 'Please enter correct student_id!' as RESULT;
		ELSE
	
	SET ITERATOR = firstMonth;

		WHILE(iterator >= firstMonth AND iterator <= secMonth)
		DO
			INSERT INTO tempTbl
			SELECT student_id, group_id, paymentAmount, month
			FROM taxespayments
			WHERE student_id = studId
			AND year = paymentYear
			AND month = iterator;
    
			SET iterator = iterator + 1;
		END WHILE;
		END IF;
    
    END IF;
		SELECT *
        FROM tempTbl;
        DROP TABLE tempTbl;
END;
|
DELIMITER ;

CALL getAllPaymentsAmountOptimized(1, 6, 2021, 1);