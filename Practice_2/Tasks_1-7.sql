--Stored Procedures--
/*1. WorldEvents db Ц создать хранимку, котора€ показывает все ивенты произошедшие в јвгусте.*/
USE WorldEvents;

CREATE PROCEDURE task_1
AS
SELECT EventName
FROM tblEvent
WHERE EventDate LIKE '%-08-%';

EXECUTE task_1;

/*2. WorldEvents db Ц создать хранимку, котора€ показывает все страны с ContinentId равным 1 в алфавитном пор€дке.*/
USE WorldEvents;

CREATE PROCEDURE task_2
AS
SELECT CountryName
FROM tblCountry
WHERE ContinentId = 1
ORDER BY CountryName;

EXECUTE task_2;

/*3. †Doctor Who db Ц —оздать хранимку, котора€ считает все эпизоды в которых ƒоктором был Matt Smith.*/
USE DoctorWho;

CREATE PROCEDURE task_3
AS
SELECT COUNT(Title)
FROM tblEpisode
WHERE DoctorId = (SELECT DoctorId FROM tblDoctor WHERE DoctorName = 'Matt Smith');

EXECUTE task_3;

/*4. †Doctor Who db Ц создать хранимку, котора€ выводит все эпизоды с определЄнным актером (актер параметр).*/
USE DoctorWho;

CREATE PROCEDURE task_4 @Actor nvarchar(30)
AS
SELECT Title
FROM tblEpisode
WHERE DoctorId = (SELECT DoctorId FROM tblDoctor WHERE DoctorName LIKE @Actor);

EXECUTE task_4 'Peter Capaldi';

/*5. Doctor Who db - создать хранимку, котора€ выводит 3 наиболее часто снимающихс€ companions.*/
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
/*1. WorldEvents db Ц написать триггер, который будет отслеживать изменение аттрибута CountryName (UPDATE) в таблице Country. ≈сли при приходит пустое значение, то оставл€ть старое значение. 
“акже триггер должен вносить все изменени€ CountryName в отдельную таблицу. */
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

/*2. Ћюба€ Ѕƒ Ц создать триггер на базу данных, который будет создавать (если не существует) таблицу и трэкать все изменени€ в базе данных в формате EventType, PostTime†, ObjectName, 
CommandText†использу€ EVENTDATA() объект. ѕример использовани€: EVENTDATA().value('(/EVENT_INSTANCE/TSQLCommand/CommandText)[1]', 'nvarchar(max)'). */
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