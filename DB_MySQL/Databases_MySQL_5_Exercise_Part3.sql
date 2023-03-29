USE CinemaProjections;

SELECT c.Name, h.Id, p.BroadcastTime
FROM Cinemas AS c
JOIN Halls AS h ON h.CinemaId = c.Id
JOIN Projections AS p ON p.HallId = h.Id
JOIN Films AS f ON f.Id = p.FilmId
WHERE f.Name = 'Final Destination 7' AND h.Status = 'VIP' OR h.Status = 'Deluxe'
ORDER BY c.Name, h.Id;

SELECT SUM(p.VisitorsCount), f.Name AS FilmName, h.Name AS HallName, h.Status
FROM Projections AS p
JOIN Halls AS h ON p.HallId = h.Id
JOIN Films AS f ON f.Id = p.FilmId
JOIN Cinemas AS c ON c.id = h.cinemaId
WHERE f.Name = 'Final Destination 7' AND h.Status = 'VIP' AND h.Name = 'Arena Mladost';

USE school_sport_clubs;

SELECT DISTINCT firstStudent.name AS Student1, secondStudent.name AS Student2, sports.name AS Sport
FROM students AS firstStudent 
JOIN students AS secondStudent
ON firstStudent.id < secondStudent.id
JOIN sports ON ( firstStudent.id IN (
										SELECT student_id
                                        FROM student_sport
                                        WHERE sportGroup_id IN 
																(
																	SELECT id
																	FROM sportgroups
																	WHERE sportGroups.sport_id = sports.id
                                                                )
									)
AND ( secondStudent.id IN (
							SELECT student_id
                            FROM student_sport
                            WHERE sportGroup_id IN (
														SELECT id
														FROM sportgroups
														WHERE sportGroups.sport_id = sports.id
													)
							)  
	)
)
WHERE firstStudent.id IN (
								SELECT student_id
                                FROM student_sport
                                WHERE sportGroup_id IN (
															SELECT sportGroup_id
                                                            FROM student_sport
                                                            WHERE student_id = secondStudent.id
														)
						 )
AND sports.name = 'Football'
ORDER BY Sport;

CREATE VIEW StudentsTrainingIn8 
AS
SELECT st.name AS StudentName, st.class AS StudentClass, sg.location AS SportGroupLocation, c.name AS CoachName
FROM students AS st 
JOIN student_sport AS ss ON ss.student_id = st.id
JOIN sportgroups AS sg ON sg.sport_id = ss.sportGroup_id
JOIN coaches AS c ON c.id = sg.coach_id
WHERE sg.hourOfTraining = '08:00:00';

SELECT s.name AS SportName, COUNT(st.id) AS CountOfStudents
FROM sports s
LEFT JOIN sportGroups sg ON sg.sport_id = s.id
LEFT JOIN student_sport ss ON ss.sportGroup_id = sg.id
LEFT JOIN students st ON st.id = ss.student_id
GROUP BY s.name;