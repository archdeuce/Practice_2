CREATE DATABASE test;

USE test;

/*�������_1*/
-- �������� SQL script ��� �������� �������� Planets. ��������� ���������� �� �������:
CREATE TABLE Planets (
	ID INT IDENTITY(1, 1) PRIMARY KEY
	,PlanetName VARCHAR(255) NOT NULL
	,Radius INT
	,SunSeason FLOAT
	,OpeningYear SMALLINT
	,HavingRings BIT
	,Opener VARCHAR(255)
	);

INSERT INTO Planets (
	PlanetName
	,Radius
	,SunSeason
	,OpeningYear
	,HavingRings
	,Opener
	)
VALUES (
	'Mars'
	,3396
	,687
	,1659
	,0
	,'Christiaan Huygens'
	)
	,(
	'Saturn'
	,60268
	,10759.22
	,NULL
	,1
	,'�'
	)
	,(
	'Neptune'
	,24764
	,60190
	,1846
	,1
	,'John Couch Adams'
	)
	,(
	'Mercury'
	,2439
	,115.88
	,1631
	,0
	,'Nicolaus Copernicus'
	)
	,(
	'Venus'
	,6051
	,243
	,1610
	,0
	,'Galileo Galilei'
	);

/*�������_2*/
-- ��������� �������� SQL WHERE ������� ������, �������� ������� (Radius) ������� ��������� � �������� �� 3000 �� 9000:
SELECT *
FROM Planets
WHERE Radius BETWEEN 3000
		AND 9000;

/*�������_3*/
-- ��������� �������� SQL WHERE ������� �������� ������� (PlanetName), ��� �� �������� (OpeningYear) � ��� ���������������� (Opener), ������, ��� �������� �� ���������� ��� �� ������������� �� ����� �s�:
SELECT PlanetName
	,OpeningYear
	,Opener
FROM Planets
WHERE (
		PlanetName NOT LIKE 's%'
		AND PlanetName NOT LIKE '%s'
		);

/*�������_4*/
-- ��������� ��������� SQL WHERE  ������� ������ ������, � ������� ������ ������� ������ 10000 � �������� (OpeningYear) ����� 1620:
SELECT PlanetName
	,Radius
	,OpeningYear
FROM Planets
WHERE (
		Radius < 10000
		AND OpeningYear > 1620
		);

/*�������_5*/
-- ��������� ��������� SQL WHERE ������� ������ ������, �������� ������� ���������� � ����� �N� ��� ������������� �� ����� �s� � �� ������� �����:
SELECT PlanetName
	,HavingRings
FROM Planets
WHERE (
		(
			PlanetName LIKE 'N%'
			OR PlanetName LIKE '%s'
			)
		AND HavingRings = 0
		);

/*�������_6*/
-- � ������� ��������� SQL UPDATE �������� �������� ������� Neptune �� Pluton:
UPDATE Planets
SET PlanetName = 'Pluton'
WHERE PlanetName = 'Neptune';

/*�������_7*/
-- � ������� ��������� SQL UPDATE � ������ ���� ������� ������� �������� �������� ������� ����� (HavingRings) �� �No�:
UPDATE Planets
SET HavingRings = 0
WHERE ID BETWEEN 1
		AND 3;

/*�������_8*/
-- � ������� ��������� SQL INSERT �������� ������ �� ������� Planets, ������� ����� ������ � ������� PlanetsWithRings:
SELECT *
INTO PlanetsWithRings
FROM Planets
WHERE HavingRings = 1;

/*�������_9*/
-- ������� �� ����� ��������:
SELECT *
FROM Planets;

/*�������_10*/
-- ��������� �������� DELETE ������� �� ������� ������ ��� ����� � � �������������� ������:
DELETE
FROM Planets
WHERE HavingRings = 0;

-- ��������� 1-5 ������� � sql-ex.ru --
/*�������_1*/
SELECT model
	,speed
	,hd
FROM PC
WHERE price < 500;

/*�������_2*/
SELECT DISTINCT maker
FROM Product
WHERE type = 'Printer'

/*�������_3*/
SELECT model
	,ram
	,screen
FROM Laptop
WHERE price > 1000

/*�������_4*/
SELECT *
FROM Printer
WHERE color = 'y'

/*�������_5*/
SELECT model
	,speed
	,hd
FROM PC
WHERE (
		cd = '12x'
		OR cd = '24x'
		)
	AND price < 600
