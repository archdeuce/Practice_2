/*Задача_11*/
SELECT AVG(speed)
FROM PC

/*Задача_12*/
SELECT AVG(speed)
FROM Laptop
WHERE price > 1000

/*Задача_13*/
SELECT AVG(speed)
FROM PC
WHERE model IN (
		SELECT model
		FROM Product
		WHERE type = 'PC'
			AND maker = 'A'
		)

/*Задача_14*/
SELECT Ships.class
	,Ships.name
	,Classes.country
FROM Ships
INNER JOIN Classes ON Classes.class = Ships.class
WHERE Classes.numGuns >= 10

/*Задача_15*/
SELECT PC.hd
FROM PC
GROUP BY PC.hd
HAVING COUNT(PC.hd) > 1

/*Задача_19*/
SELECT Product.maker
	,AVG(Laptop.screen)
FROM Product
INNER JOIN Laptop ON Product.model = Laptop.model
GROUP BY Product.maker

/*Задача_21*/
SELECT Product.maker
	,MAX(PC.price) AS max_price
FROM Product
INNER JOIN PC ON Product.model = PC.model
GROUP BY Product.maker

/*Задача_22*/
SELECT PC.speed
	,AVG(PC.price) AS avg_price
FROM PC
WHERE PC.speed > 600
GROUP BY PC.speed

/*Задача_28*/
SELECT COUNT(Product.maker)
FROM Product
WHERE maker IN (
		SELECT Product.maker
		FROM Product
		GROUP BY Product.maker
		HAVING COUNT(Product.model) = 1
		)

/*Задача_31*/
SELECT Classes.class
	,Classes.country
FROM Classes
WHERE Classes.bore >= 16

/*Задача_33*/
SELECT Outcomes.ship
FROM Outcomes
WHERE battle = 'North Atlantic'
	AND result = 'sunk'

/*Задача_38*/
SELECT Classes.country
FROM Classes
WHERE Classes.type LIKE 'bc'

INTERSECT

SELECT Classes.country
FROM Classes
WHERE Classes.type LIKE 'bb'

/*Задача_42*/
SELECT Outcomes.ship
	,Outcomes.battle
FROM Outcomes
WHERE Outcomes.result = 'sunk'

/*Задача_44*/
SELECT Ships.name
FROM Ships
WHERE Ships.name LIKE 'r%'

UNION

SELECT Outcomes.ship
FROM Outcomes
WHERE Outcomes.ship LIKE 'r%'

/*Задача_45*/
SELECT Ships.name
FROM Ships
WHERE Ships.name LIKE '% % %'

UNION

SELECT Outcomes.ship
FROM Outcomes
WHERE Outcomes.ship LIKE '% % %'

/*Задача_49*/
SELECT Ships.name
FROM Ships
INNER JOIN Classes ON Classes.class = Ships.class
WHERE Classes.bore = 16

UNION

SELECT Outcomes.ship
FROM Outcomes
INNER JOIN Classes ON Classes.class = Outcomes.ship
WHERE Classes.bore = 16

/*Задача_50*/
SELECT DISTINCT Outcomes.battle
FROM Outcomes
INNER JOIN Ships ON Outcomes.ship = Ships.name
WHERE Ships.class = 'Kongo'