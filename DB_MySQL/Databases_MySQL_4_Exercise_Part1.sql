SELECT s.name, s.class, s.phone
	FROM students as s
		JOIN student_sport AS ss ON ss.student_id = s.id
			JOIN sportgroups as sg ON sg.id = ss.sportGroup_id
				JOIN sports as sp ON sp.id = sg.sport_id
					WHERE sp.name = 'Football';
	   
SELECT DISTINCT c.name
	FROM coaches as c	 
		JOIN sportgroups AS sg ON sg.coach_id = c.id
			JOIN sports as s on s.id = sg.sport_id
				WHERE s.name = 'Volleyball';
                
SELECT c.name, s.name
	FROM coaches AS c 
		JOIN sportgroups AS sg ON sg.coach_id = c.id
			JOIN sports as s on s.id = sg.sport_id
				JOIN student_sport AS ss ON ss.sportGroup_id = sg.id
					JOIN students AS st ON st.id = ss.student_id
						WHERE st.name = 'Iliyan Ivanov';
                        
SELECT st.name AS StudentName, st.class, sg.location, c.name AS CoachName
	FROM coaches AS c 
		JOIN sportgroups AS sg ON sg.coach_id = c.id
			JOIN sports as s on s.id = sg.sport_id
				JOIN student_sport AS ss ON ss.sportGroup_id = sg.id
					JOIN students AS st ON st.id = ss.student_id
						WHERE sg.hourOfTraining = '08:00:00';
					