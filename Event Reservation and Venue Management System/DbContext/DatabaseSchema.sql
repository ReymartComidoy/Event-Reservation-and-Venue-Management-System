USE master;
GO

IF DB_ID(N'EventReservationDb') IS NULL
BEGIN
	CREATE DATABASE EventReservationDb;
END
GO

USE EventReservationDb;
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Users
	(
		Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Users PRIMARY KEY,
		Email NVARCHAR(255) NOT NULL CONSTRAINT UQ_Users_Email UNIQUE,
		PasswordHash NVARCHAR(128) NOT NULL,
		FullName NVARCHAR(150) NOT NULL,
		Role NVARCHAR(20) NOT NULL,
		IsActive BIT NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1)
	);
END
GO

CREATE OR ALTER PROCEDURE dbo.Client_Create
	@Email NVARCHAR(255),
	@PasswordHash NVARCHAR(128),
	@FullName NVARCHAR(150)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT dbo.Users (Email, PasswordHash, FullName, Role, IsActive)
	VALUES (@Email, @PasswordHash, @FullName, 'Client', 1);
END
GO

CREATE OR ALTER PROCEDURE dbo.Client_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id AS ClientId, FullName AS ClientName, Email,
		   CAST('' AS NVARCHAR(50)) AS Phone,
		   CAST('' AS NVARCHAR(150)) AS Company,
		   CAST('Individual' AS NVARCHAR(30)) AS ClientType,
		   CASE WHEN IsActive = 1 THEN 'Active' ELSE 'Inactive' END AS Status
	FROM dbo.Users
	WHERE Role = 'Client'
	ORDER BY FullName;
END
GO

CREATE OR ALTER PROCEDURE dbo.Client_Update
	@Id INT,
	@FullName NVARCHAR(150),
	@Email NVARCHAR(255),
	@IsActive BIT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Users
	SET FullName = @FullName, Email = @Email, IsActive = @IsActive
	WHERE Id = @Id AND Role = 'Client';
END
GO

CREATE OR ALTER PROCEDURE dbo.Client_Delete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Users SET IsActive = 0 WHERE Id = @Id AND Role = 'Client';
END
GO

IF OBJECT_ID(N'dbo.Venues', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Venues
	(
		Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Venues PRIMARY KEY,
		VenueName NVARCHAR(150) NOT NULL,
		VenueType NVARCHAR(50) NOT NULL,
		Capacity INT NOT NULL,
		Location NVARCHAR(250) NOT NULL,
		PricePerHour DECIMAL(18,2) NOT NULL,
		Status NVARCHAR(30) NOT NULL,
		ImagePath NVARCHAR(500) NULL,
		CreatedBy INT NULL CONSTRAINT FK_Venues_Users REFERENCES dbo.Users(Id)
	);
END
GO

IF OBJECT_ID(N'dbo.Events', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Events
	(
		Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Events PRIMARY KEY,
		EventName NVARCHAR(200) NOT NULL,
		VenueId INT NULL CONSTRAINT FK_Events_Venues REFERENCES dbo.Venues(Id),
		EventDate DATE NOT NULL,
		EventTime TIME(0) NULL,
		Bookings INT NOT NULL CONSTRAINT DF_Events_Bookings DEFAULT (0),
		Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Events_Status DEFAULT ('Upcoming')
	);
END
GO

CREATE OR ALTER PROCEDURE dbo.Event_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT e.Id, e.EventName, v.VenueName AS Venue, e.VenueId,
		   e.EventDate AS [Date], e.EventTime AS [Time], e.Bookings, e.Status
	FROM dbo.Events e
	LEFT JOIN dbo.Venues v ON v.Id = e.VenueId
	ORDER BY e.EventDate, e.EventName;
END
GO

CREATE OR ALTER PROCEDURE dbo.Event_Save
	@Id INT = NULL,
	@EventName NVARCHAR(200),
	@VenueId INT = NULL,
	@EventDate DATE,
	@EventTime TIME(0) = NULL,
	@Bookings INT = 0,
	@Status NVARCHAR(30) = 'Upcoming'
AS
BEGIN
	SET NOCOUNT ON;
	IF @Id IS NULL OR @Id = 0
		INSERT dbo.Events (EventName, VenueId, EventDate, EventTime, Bookings, Status)
		VALUES (@EventName, @VenueId, @EventDate, @EventTime, @Bookings, @Status);
	ELSE
		UPDATE dbo.Events
		SET EventName=@EventName, VenueId=@VenueId, EventDate=@EventDate,
			EventTime=@EventTime, Bookings=@Bookings, Status=@Status
		WHERE Id=@Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.Event_Delete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Events WHERE Id = @Id;
END
GO

IF OBJECT_ID(N'dbo.Reservations', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.Reservations
	(
		Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Reservations PRIMARY KEY,
		ClientId INT NOT NULL CONSTRAINT FK_Reservations_Users REFERENCES dbo.Users(Id),
		VenueId INT NOT NULL CONSTRAINT FK_Reservations_Venues REFERENCES dbo.Venues(Id),
		EventTitle NVARCHAR(200) NOT NULL,
		ReservationDate DATE NOT NULL,
		TimeSlot NVARCHAR(100) NOT NULL,
		GuestCount INT NOT NULL,
		SpecialRequests NVARCHAR(1000) NULL,
		TotalFee DECIMAL(18,2) NOT NULL,
		Status NVARCHAR(30) NOT NULL CONSTRAINT DF_Reservations_Status DEFAULT ('Pending'),
		CreatedAt DATETIME2 NOT NULL CONSTRAINT DF_Reservations_CreatedAt DEFAULT (SYSUTCDATETIME())
	);
END
GO

DELETE r
FROM dbo.Reservations r
INNER JOIN dbo.Venues v ON v.Id = r.VenueId
WHERE v.VenueName IN ('Auditorium', 'Executive Boardroom', 'Garden Terrace', 'Grand Ballroom', 'Outdoor Pavilion');

DELETE e
FROM dbo.Events e
INNER JOIN dbo.Venues v ON v.Id = e.VenueId
WHERE v.VenueName IN ('Auditorium', 'Executive Boardroom', 'Garden Terrace', 'Grand Ballroom', 'Outdoor Pavilion');

DELETE FROM dbo.Venues
WHERE VenueName IN ('Auditorium', 'Executive Boardroom', 'Garden Terrace', 'Grand Ballroom', 'Outdoor Pavilion');

UPDATE dbo.Venues
SET VenueName = 'Grand Palm', VenueType = 'Grand Palm'
WHERE VenueName = 'Grand palm';
GO

CREATE OR ALTER PROCEDURE dbo.User_Login
	@Email NVARCHAR(255),
	@PasswordHash NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT TOP (1) Id, Email AS Username, FullName, Role
	FROM dbo.Users
	WHERE Email = @Email AND PasswordHash = @PasswordHash AND IsActive = 1;
END
GO

CREATE OR ALTER PROCEDURE dbo.User_SeedDemo
	@Email NVARCHAR(255),
	@PasswordHash NVARCHAR(128),
	@FullName NVARCHAR(150),
	@Role NVARCHAR(20)
AS
BEGIN
	SET NOCOUNT ON;
	IF NOT EXISTS (SELECT 1 FROM dbo.Users WHERE Email = @Email)
		INSERT dbo.Users (Email, PasswordHash, FullName, Role) VALUES (@Email, @PasswordHash, @FullName, @Role);
END
GO

CREATE OR ALTER PROCEDURE dbo.Venue_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Id, VenueName, VenueType, Capacity, Location, PricePerHour, Status, ImagePath
	FROM dbo.Venues ORDER BY VenueName;
END
GO

CREATE OR ALTER PROCEDURE dbo.Venue_Save
	@Id INT = NULL,
	@VenueName NVARCHAR(150),
	@VenueType NVARCHAR(50),
	@Capacity INT,
	@Location NVARCHAR(250),
	@PricePerHour DECIMAL(18,2),
	@Status NVARCHAR(30),
	@ImagePath NVARCHAR(500) = NULL,
	@CreatedBy INT = NULL
AS
BEGIN
	SET NOCOUNT ON;
	IF @Id IS NULL OR @Id = 0
		INSERT dbo.Venues (VenueName, VenueType, Capacity, Location, PricePerHour, Status, ImagePath, CreatedBy)
		VALUES (@VenueName, @VenueType, @Capacity, @Location, @PricePerHour, @Status, @ImagePath, @CreatedBy);
	ELSE
		UPDATE dbo.Venues SET VenueName=@VenueName, VenueType=@VenueType, Capacity=@Capacity,
			Location=@Location, PricePerHour=@PricePerHour, Status=@Status, ImagePath=@ImagePath WHERE Id=@Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.Venue_Delete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Venues WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.Reservation_Save
	@ClientId INT,
	@VenueId INT,
	@EventTitle NVARCHAR(200),
	@ReservationDate DATE,
	@TimeSlot NVARCHAR(100),
	@GuestCount INT,
	@SpecialRequests NVARCHAR(1000),
	@TotalFee DECIMAL(18,2)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT dbo.Reservations (ClientId, VenueId, EventTitle, ReservationDate, TimeSlot, GuestCount, SpecialRequests, TotalFee)
	VALUES (@ClientId, @VenueId, @EventTitle, @ReservationDate, @TimeSlot, @GuestCount, @SpecialRequests, @TotalFee);
END
GO

CREATE OR ALTER PROCEDURE dbo.Reservation_GetAll
AS
BEGIN
	SET NOCOUNT ON;
	SELECT r.Id, r.ClientId, r.VenueId, r.Id AS [Reservation ID],
		   u.FullName AS ClientName, r.EventTitle AS EventName,
		   v.VenueName AS Venue, r.ReservationDate, r.Status,
		   r.TimeSlot, r.GuestCount, r.TotalFee AS TotalAmount
	FROM dbo.Reservations r
	INNER JOIN dbo.Users u ON u.Id = r.ClientId
	INNER JOIN dbo.Venues v ON v.Id = r.VenueId
	ORDER BY r.ReservationDate DESC;
END
GO

CREATE OR ALTER PROCEDURE dbo.Reservation_Update
	@Id INT,
	@ClientId INT,
	@VenueId INT,
	@EventTitle NVARCHAR(200),
	@ReservationDate DATE,
	@TimeSlot NVARCHAR(100),
	@GuestCount INT,
	@TotalFee DECIMAL(18,2),
	@Status NVARCHAR(30)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE dbo.Reservations
	SET ClientId=@ClientId, VenueId=@VenueId, EventTitle=@EventTitle,
		ReservationDate=@ReservationDate, TimeSlot=@TimeSlot,
		GuestCount=@GuestCount, TotalFee=@TotalFee, Status=@Status
	WHERE Id=@Id;
END
GO

CREATE OR ALTER PROCEDURE dbo.Reservation_Delete
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM dbo.Reservations WHERE Id = @Id;
END
GO

EXEC dbo.User_SeedDemo
	@Email = 'admin@demo.com',
	@PasswordHash = 'E86F78A8A3CAF0B60D8E74E5942AA6D86DC150CD3C03338AEF25B7D2D7E3ACC7',
	@FullName = 'Demo Administrator',
	@Role = 'Admin';

EXEC dbo.User_SeedDemo
	@Email = 'client@demo.com',
	@PasswordHash = 'BA6B9CF408A3BC5568CC18317077A3D5FC81849C1B84128180240AB9680D0DD7',
	@FullName = 'Demo Client',
	@Role = 'Client';

IF NOT EXISTS (SELECT 1 FROM dbo.Venues)
BEGIN
	INSERT dbo.Venues (VenueName, VenueType, Capacity, Location, PricePerHour, Status)
	VALUES ('Golden Palace', 'Golden Palace', 500, 'Main Building', 2500, 'Available'),
		   ('Big 8', 'Big 8', 300, 'East Wing', 1800, 'Available'),
		   ('Grand Palm', 'Grand Palm', 200, 'Outdoor Area', 1500, 'Available');
END
GO
