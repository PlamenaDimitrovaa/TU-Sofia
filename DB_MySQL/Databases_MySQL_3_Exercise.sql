SELECT coaches.Name, sports.name
FROM coaches JOIN sports
ON coaches.id IN 
(
	SELECT coach_id 
    FROM sportgroups
    WHERE sportgroups.sport_id = sports.id
);

SELECT DISTINCT coaches.name, sports.name
FROM Coaches JOIN sportgroups
ON coaches.id = sportgroups.coach_id
JOIN sports ON sports.id = sportgroups.sport_id;

INSERT INTO students (name, egn, address, phone, class)
VALUES 
('Ivan Ivanov Ivanov', '9207186371', 'Sofia-Serdika', '0888892950', '10');

SELECT * FROM students
ORDER BY name;

DELETE FROM students AS s
	WHERE s.id = 7;
    
SELECT st.name, sp.name
FROM student_sport as ss
JOIN students as st on st.id = ss.student_id
JOIN sportgroups as sg on sg.id = ss.sportGroup_id
JOIN sports as sp on sp.id = ss.sportGroup_id;

SELECT s.name, s.class, sg.id
FROM students as s JOIN sportgroups as sg 
JOIN student_sport as ss ON ss.sportGroup_id = sg.id
ON s.id = ss.student_id
WHERE sg.dayOfWeek = 'Monday';

SELECT c.name 
FROM coaches as c
JOIN sportgroups as sg ON sg.coach_id = c.id
JOIN sports as s ON s.id = sg.sport_id
WHERE s.name = 'Football';

SELECT sg.location, sg.hourOfTraining, sg.dayOfWeek
FROM sportgroups as sg 
JOIN sports as s on s.id = sg.sport_id
WHERE s.name = 'Volleyball';

SELECT s.name 
FROM sports as s 
JOIN sportgroups as sg ON sg.sport_id = s.id
JOIN student_sport as ss ON ss.sportGroup_id = sg.id
JOIN students as st ON st.id = ss.student_id
WHERE st.name = 'Iliyan Ivanov';

SELECT s.name 
FROM students as s 
JOIN student_sport as ss ON ss.student_id = s.id
JOIN sportgroups as sg On sg.sport_id = ss.sportGroup_id
JOIN coaches as c ON c.id = sg.coach_id
JOIN sports as sp ON sp.id = sg.sport_id
WHERE sp.name = 'Football' AND c.name = 'Ivan Todorov Petkov';


 
 

