INSERT INTO Schedules (Title, Description, StartTime, EndTime, Date)
VALUES 
('Calculus Practice', 'Review differentiation problems', '2025-10-24 08:00', '2025-10-24 09:30', '2025-10-24'),
('Programming Project', 'Work on Study Planner UI', '2025-10-24 10:00', '2025-10-24 12:00', '2025-10-24');

INSERT INTO Subjects (SubjectName, Description, Progress, TargetHours)
VALUES
('Mathematics', 'Calculus, Trigonometry, and Algebra', 75, 50),
('Programming', 'C#, Data Structures, Algorithms', 45, 60),
('Physics', 'Mechanics, Motion, and Energy', 60, 40);

INSERT INTO Goals (GoalTitle, GoalDescription, TargetDate)
VALUES
('Finish Physics Chapter 3', 'Complete exercises and notes', '2025-10-27'),
('Complete C# Project', 'Implement UI navigation and save data', '2025-11-01');

INSERT INTO Notes (SubjectID, NoteTitle, NoteContent)
VALUES
(1, 'Trigonometric Identities', 'sin²x + cos²x = 1; tanx = sinx/cosx'),
(2, 'C# Classes', 'Classes are blueprints for objects. Use PascalCase naming.');
