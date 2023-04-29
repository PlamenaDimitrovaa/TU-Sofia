use school_sport_clubs;
drop table if exists salarypayments_log;
create table salarypayments_log(
id int auto_increment primary key,
operation ENUM('INSERT','UPDATE','DELETE') not null,
old_coach_id int,
old_month int,
old_year int,
old_salaryAmount decimal,
old_dateOfPayment datetime,
dateOfLog datetime
);

DROP TRIGGER if exists after_salarypayment_delete;
DELIMITER |
CREATE TRIGGER after_salarypayment_delete AFTER DELETE ON salarypayments
FOR EACH ROW
BEGIN
INSERT INTO salarypayments_log(operation,
old_coach_id,
old_month,
old_year,
old_salaryAmount,
old_dateOfPayment,
dateOfLog)
VALUES ('DELETE', OLD.coach_id, OLD.month, OLD.year, OLD.salaryAmount, OLD.dateOfPayment, NOW());
END;
|
DELIMITER ;

DELETE FROM salarypayments WHERE coach_id = 1;

INSERT INTO salarypayments (coach_id, month, year, salaryAmount, dateOfPayment)
SELECT old_coach_id, old_month, old_year,old_salaryAmount, old_dateOfPayment 
FROM salarypayments_log;

DROP TRIGGER IF EXISTS after_student_add;
DELIMITER |
CREATE TRIGGER after_student_add BEFORE INSERT ON student_sport
FOR EACH ROW
BEGIN
DECLARE groupCount INT;
SELECT COUNT(*) INTO groupCount
FROM student_sport 
WHERE student_id = NEW.student_id;
 IF group_count >= 2
	THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT =  'Един ученик не може да тренира в повече от една група';
 END IF;
END |
DELIMITER ;

CREATE VIEW studentsInGroups_view AS 
SELECT s.name AS StudentName, COUNT(sg.id) AS GroupCount
FROM students AS s
JOIN student_sport AS ss ON ss.student_id = s.id
JOIN sportgroups AS sg ON sg.id = ss.sportGroup_id
GROUP BY s.name

DELIMITER |
DROP PROCEDURE IF EXISTS SportTrainingProcedure |
CREATE PROCEDURE SportTrainingProcedure(IN sportName VARCHAR(50))
BEGIN
SELECT c.name AS CoachName, sg.id, sg.location, sg.hourOfTraining, sg.dayOfWeek
FROM sports AS s
JOIN sportgroups AS sg ON sg.sport_id = s.id
JOIN coaches AS c ON c.id = sg.coach_id
WHERE s.name = sportName;
END |
DELIMITER ;

CALL SportTrainingProcedure('Football');