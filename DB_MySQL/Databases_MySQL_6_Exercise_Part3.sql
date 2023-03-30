USE school_sport_clubs;

#1
SELECT s.name, s.class, s.phone
FROM students AS s
JOIN student_sport AS ss ON ss.student_id = s.id
JOIN sportgroups AS sg ON sg.id = ss.sportGroup_id
JOIN sports AS sp ON sp.Id = sg.sport_id
WHERE sp.name = "Football";

#2
SELECT c.name
FROM coaches AS c
JOIN sportGroups AS sg ON sg.coach_id = c.id
JOIN sports AS s ON s.id = sg.sport_id
WHERE s.name = "Volleyball";

#3
SELECT c.name, s.name, sg.dayOfWeek, sg.location
FROM students AS st
JOIN student_sport AS ss ON ss.student_id = st.id
JOIN sportGroups AS sg ON sg.id = ss.sportGroup_id
JOIN coaches AS c ON c.id = sg.coach_id
JOIN sports AS s ON s.id = sg.sport_id
WHERE st.name = "Maria Hristova Dimova";

#4
SELECT tp.month, SUM(tp.paymentAmount) AS Sum
FROM taxespayments AS tp
JOIN sportGroups AS sg ON sg.id = tp.group_id
JOIN coaches AS c ON c.id = sg.coach_id
WHERE c.egn = 7509041245
GROUP BY tp.month, tp.student_id
HAVING SUM(tp.paymentAmount) > 700;

#5
SELECT COUNT(s.id) AS StudentCount
FROM students AS s 
JOIN student_sport AS ss ON ss.student_id = s.id
JOIN sportGroups AS sg ON sg.id = ss.sportGroup_id
JOIN sports AS sp ON sp.id = sg.sport_id
WHERE sp.name = "Football";

#6
SELECT DISTINCT c.name, s.name
FROM sports AS s 
RIGHT JOIN sportGroups AS sg ON sg.sport_id = s.id
RIGHT JOIN coaches AS c ON c.id = sg.coach_id;

#7
SELECT s.name AS SportName, sg.location, COUNT(st.id) AS StudentCount 
FROM students AS st
JOIN student_sport AS ss ON ss.student_id = st.id
JOIN sportGroups AS sg ON sg.id = ss.sportGroup_id
JOIN sports AS s ON s.id = sg.sport_id
GROUP BY s.name, sg.location
HAVING COUNT(st.id) > 3;

#8
USE transaction_test;

BEGIN;

UPDATE customer_accounts
SET amount = amount - 50000
WHERE customer_id = (SELECT c.id
FROM customers AS c 
WHERE c.name = "Stoyan Pavlov Pavlov") AND amount >= 50000;

UPDATE customer_accounts
SET amount = amount + 50000
WHERE customer_id =(SELECT c.id
FROM customers AS c 
WHERE c.name = "Ivan Petrov Iordanov");

COMMIT;




