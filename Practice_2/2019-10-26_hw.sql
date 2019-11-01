-- Выполнить 6-10 задания с sql-ex.ru --
/*Задание_6*/
SELECT DISTINCT Product.maker
	,Laptop.speed
FROM Product
INNER JOIN Laptop ON Laptop.model = Product.model
WHERE Laptop.hd >= 10

/*Задание_7*/
SELECT Product.model
	,PC.price
FROM Product
INNER JOIN PC ON PC.model = Product.model
WHERE Product.maker = 'B'

UNION

SELECT Product.model
	,Laptop.price
FROM Product
INNER JOIN Laptop ON Laptop.model = Product.model
WHERE Product.maker = 'B'

UNION

SELECT Product.model
	,Printer.price
FROM Product
INNER JOIN Printer ON Printer.model = Product.model
WHERE Product.maker = 'B'

/*Задание_8*/
SELECT DISTINCT Product.maker
FROM Product
WHERE Product.type = 'PC'
	AND Product.maker NOT IN (
		SELECT Product.maker
		FROM Product
		WHERE Product.type = 'Laptop'
		)

/*Задание_9*/
SELECT DISTINCT Product.maker
FROM Product
JOIN PC ON PC.model = Product.model
WHERE speed >= 450

/*Задание_10*/
SELECT Printer.model
	,Printer.price
FROM Printer
WHERE price = (
		SELECT MAX(Printer.price)
		FROM Printer
		)

/*
Написать SQL script для создания БД Компьютерная фирма
http://www.sql-tutorial.ru/ru/book_firm_computer.html
*/

CREATE DATABASE ComputerFirm;

USE ComputerFirm;

--Product Table--
CREATE TABLE Product (
	maker VARCHAR(10) NOT NULL
	,model VARCHAR(50) PRIMARY KEY
	,type VARCHAR(10) NOT NULL
	,
	);

--PC Table--
CREATE TABLE PC (
	code INT IDENTITY(1, 1) PRIMARY KEY
	,model VARCHAR(50) NOT NULL
	,speed SMALLINT NOT NULL
	,ram SMALLINT NOT NULL
	,hd REAL NOT NULL
	,cd VARCHAR(10) NOT NULL
	,price MONEY
	);

--Laptop Table--
CREATE TABLE Laptop (
	code INT IDENTITY(1, 1) PRIMARY KEY
	,model VARCHAR(50) NOT NULL
	,speed SMALLINT NOT NULL
	,ram SMALLINT NOT NULL
	,hd REAL NOT NULL
	,price MONEY
	,cd TINYINT NOT NULL
	);

--Printer Table--
CREATE TABLE Printer (
	code INT IDENTITY(1, 1) PRIMARY KEY
	,model VARCHAR(50) NOT NULL
	,color CHAR(1) NOT NULL
	,ram SMALLINT NOT NULL
	,type VARCHAR(10) NOT NULL
	,price MONEY
	);