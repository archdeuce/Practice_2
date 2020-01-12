--Stored Procedures--
/*1. WorldEvents db � ������� ��������, ������� ���������� ��� ������ ������������ � �������.*/
USE WorldEvents;

CREATE PROCEDURE task_1
AS
SELECT EventName
FROM tblEvent
WHERE EventDate LIKE '%-08-%';

EXECUTE task_1;

/*2. WorldEvents db � ������� ��������, ������� ���������� ��� ������ � ContinentId ������ 1 � ���������� �������.*/
USE WorldEvents;

CREATE PROCEDURE task_2
AS
SELECT CountryName
FROM tblCountry
WHERE ContinentId = 1
ORDER BY CountryName;

EXECUTE task_2;

/*3. �Doctor Who db � ������� ��������, ������� ������� ��� ������� � ������� �������� ��� Matt Smith.*/
USE DoctorWho;

CREATE PROCEDURE task_3
AS
SELECT COUNT(Title)
FROM tblEpisode
WHERE DoctorId = (SELECT DoctorId FROM tblDoctor WHERE DoctorName = 'Matt Smith');

EXECUTE task_3;

/*4. �Doctor Who db � ������� ��������, ������� ������� ��� ������� � ����������� ������� (����� ��������).*/
USE DoctorWho;

CREATE PROCEDURE task_4 @Actor nvarchar(30)
AS
SELECT Title
FROM tblEpisode
WHERE DoctorId = (SELECT DoctorId FROM tblDoctor WHERE DoctorName LIKE @Actor);

EXECUTE task_4 'Peter Capaldi';

/*5. Doctor Who db - ������� ��������, ������� ������� 3 �������� ����� ����������� companions.*/
USE DoctorWho;

CREATE PROCEDURE task_5
AS
SELECT TOP 3 CompanionName, COUNT(CompanionName) as CompanionCount
FROM tblEpisode AS e
INNER JOIN tblEpisodeCompanion as ec
ON e.EpisodeId = ec.EpisodeId
INNER JOIN tblCompanion as c
ON ec.CompanionId = c.CompanionId
GROUP BY CompanionName
ORDER BY CompanionCount DESC;

EXECUTE task_5;

--Triggers--
/*1. WorldEvents db � �������� �������, ������� ����� ����������� ��������� ��������� CountryName (UPDATE) � ������� Country. ���� ��� �������� ������ ��������, �� ��������� ������ ��������. 
����� ������� ������ ������� ��� ��������� CountryName � ��������� �������. */
CREATE TRIGGER [dbo].[country_name_update] ON [dbo].[tblCountry]
INSTEAD OF UPDATE
AS
BEGIN
	IF 
		UPDATE (CountryName)

	DECLARE @newCountryName NVARCHAR(50) = (
			SELECT inserted.CountryName
			FROM inserted
			)
	DECLARE @oldCountryName NVARCHAR(50) = (
			SELECT deleted.CountryName
			FROM deleted
			)

	IF @newCountryName <> ''
	BEGIN
		UPDATE tblCountry
		SET CountryName = inserted.CountryName
		FROM inserted
		INNER JOIN tblCountry ON inserted.CountryID = tblCountry.CountryId;

		INSERT INTO ChangeCountryNameLog
		VALUES (
			@oldCountryName
			,@newCountryName
			,Getdate()
			)
	END
END

/*2. ����� �� � ������� ������� �� ���� ������, ������� ����� ��������� (���� �� ����������) ������� � ������� ��� ��������� � ���� ������ � ������� EventType, PostTime�, ObjectName, 
CommandText���������� EVENTDATA() ������. ������ �������������: EVENTDATA().value('(/EVENT_INSTANCE/TSQLCommand/CommandText)[1]', 'nvarchar(max)'). */
CREATE TRIGGER log ON DATABASE
FOR DDL_DATABASE_LEVEL_EVENTS AS

BEGIN
	DECLARE @data XML

	SET @data = EVENTDATA()

	IF (
			(
				SELECT TABLE_NAME
				FROM information_schema.tables
				WHERE TABLE_NAME = 'ddl_log'
				) IS NULL
			)
	BEGIN
		CREATE TABLE ddl_log (
			PostTime DATETIME
			,DB_User NVARCHAR(100)
			,Event NVARCHAR(100)
			,TSQL NVARCHAR(2000)
			);
	END

	INSERT ddl_log (
		PostTime
		,DB_User
		,Event
		,TSQL
		)
	VALUES (
		GETDATE()
		,CONVERT(NVARCHAR(100), CURRENT_USER)
		,@data.value('(/EVENT_INSTANCE/EventType)[1]', 'nvarchar(100)')
		,@data.value('(/EVENT_INSTANCE/TSQLCommand)[1]', 'nvarchar(2000)')
		);
END
GO