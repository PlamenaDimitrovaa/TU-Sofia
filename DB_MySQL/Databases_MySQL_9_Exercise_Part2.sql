USE school_sport_clubs;

delimiter |
CREATE TRIGGER after_salarypayment_update AFTER UPDATE ON salarypayments
FOR EACH ROW 
BEGIN
INSERT INTO salarypayments_log(operation,
old_coach_id,
new_coach_id,
old_month,
new_month,
old_year,
new_year,
old_salaryAmount,
new_salaryAmount,
old_dateOfPayment,
new_dateOfPayment,
dateOfLog)
VALUES ('UPDATE',OLD.coach_id,NEW.coach_id,OLD.month,NEW.month,
OLD.year,NEW.year,OLD.salaryAmount,NEW.salaryAmount,OLD.dateOfPayment,NEW.dateOfPayment,NOW());
END;
|
Delimiter ;

UPDATE `salarypayments` SET `salaryAmount`='2000' WHERE `id`='13';

DROP TRIGGER if exists after_salarypayment_update;
delimiter |
CREATE TRIGGER after_salarypayment_update AFTER UPDATE ON salarypayments
FOR EACH ROW 
BEGIN
INSERT INTO salarypayments_log(operation,
old_coach_id,
new_coach_id,
old_month,
new_month,
old_year,
new_year,
old_salaryAmount,
new_salaryAmount,
old_dateOfPayment,
new_dateOfPayment,
dateOfLog)
VALUES ('UPDATE',
OLD.coach_id,
CASE NEW.coach_id WHEN OLD.coach_id THEN NULL ELSE NEW.coach_id END,
OLD.month,
CASE NEW.month WHEN OLD.month THEN NULL ELSE NEW.month END,
OLD.year,
CASE NEW.year WHEN OLD.year THEN NULL ELSE NEW.year END,
OLD.salaryAmount,
CASE NEW.salaryAmount WHEN OLD.salaryAmount THEN NULL ELSE NEW.salaryAmount END,
OLD.dateOfPayment,
CASE NEW.dateOfPayment WHEN OLD.dateOfPayment THEN NULL ELSE NEW.dateOfPayment END,
NOW());
END;
|
Delimiter ;

UPDATE `school_sport_clubs`.`salarypayments` SET `month`='5' WHERE `id`='15';

DROP TRIGGER if exists before_coaches_insert;
delimiter |
CREATE TRIGGER before_coaches_insert BEFORE INSERT ON coaches
FOR EACH ROW
BEGIN
IF(CHAR_LENGTH(NEW.egn) < 10)
THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'The egn must be 10 characters.';
end if;
END;
|
delimiter ;

INSERT INTO `school_sport_clubs`.`coaches` (`name`, `egn`, `month_salary`, `hour_salary`) VALUES ('Ivan Iordanov Petrov', '7452', '1500', '14');

delimiter |
CREATE EVENT monthly_Payment
ON SCHEDULE EVERY 1 MONTH
STARTS '2016-05-01 06:05:00'
DO
BEGIN
CALL OPTIMIZED_monthHonorariumPayment(MONTH(NOW()),YEAR(NOW()));
END;
|
delimiter ;