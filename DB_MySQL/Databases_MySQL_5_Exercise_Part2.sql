CREATE VIEW  sportLocation (Sport, Place)
AS
SELECT sports.name, sportgroups.location
FROM sports 
JOIN sportgroups ON sports.id = sportgroups.sport_id;

SELECT * FROM sportLocation;

DROP VIEW sportLocation;

SELECT COUNT(coach_id) 
FROM sportgroups;

SELECT COUNT(*) 
FROM sportgroups;

SELECT group_id, SUM(paymentAmount)
FROM taxesPayments
WHERE group_id = 1;

SELECT group_id, SUM(paymentAmount)
FROM taxesPayments
GROUP BY (group_id)
HAVING SUM(paymentAmount) > 11000;