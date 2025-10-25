CREATE TABLE Schedules (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    StartTime DATETIME NOT NULL,
    EndTime DATETIME NOT NULL,
    Date DATE NOT NULL,
    IsCompleted BIT DEFAULT 0
);

CREATE TABLE Subjects (
    SubjectID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Progress INT DEFAULT 0,
    TargetHours INT DEFAULT 0
);

CREATE TABLE Goals (
    GoalID INT IDENTITY(1,1) PRIMARY KEY,
    GoalTitle NVARCHAR(150) NOT NULL,
    GoalDescription NVARCHAR(255),
    TargetDate DATE,
    IsAchieved BIT DEFAULT 0
);

CREATE TABLE Notes (
    NoteID INT IDENTITY(1,1) PRIMARY KEY,
    SubjectID INT,
    NoteTitle NVARCHAR(150),
    NoteContent NVARCHAR(MAX),
    DateCreated DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);
