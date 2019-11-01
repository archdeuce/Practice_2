-- ��������� 6-10 ������� � sql-ex.ru --
/*�������_6*/
SELECT DISTINCT Product.maker
	,Laptop.speed
FROM Product
INNER JOIN Laptop ON Laptop.model = Product.model
WHERE Laptop.hd >= 10

/*�������_7*/
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

/*�������_8*/
SELECT DISTINCT Product.maker
FROM Product
WHERE Product.type = 'PC'
	AND Product.maker NOT IN (
		SELECT Product.maker
		FROM Product
		WHERE Product.type = 'Laptop'
		)

/*�������_9*/
SELECT DISTINCT Product.maker
FROM Product
JOIN PC ON PC.model = Product.model
WHERE speed >= 450

/*�������_10*/
SELECT Printer.model
	,Printer.price
FROM Printer
WHERE price = (
		SELECT MAX(Printer.price)
		FROM Printer
		)
