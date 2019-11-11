/* 16. Display all the information of an employee whose id is any of the number 134, 159 and 183. */
SELECT *
FROM employees
WHERE emplyee_id IN (
		134
		,159
		,183
		)

/* 17. Write a query to display all the information of the employees whose salary is within the range 1000 and 3000. */
SELECT *
FROM employees
WHERE salary BETWEEN 1000
		AND 3000

/* 18. Write a query to display all the information of the employees whose salary is within the range of smallest salary and 2500. */
SELECT *
FROM employees
WHERE salary BETWEEN (
				SELECT MIN(salary)
				FROM employees
				)
		AND 2500

/* 19. Write a query to display all the information of the employees who does not work in those departments where some employees works whose manager id within the range 100 and 200. */
SELECT *
FROM employees AS e
	,departments AS d
WHERE e.department_id = d.department_id
	AND d.manager_id NOT BETWEEN 100
		AND 200

/* 20. Write a query to display all the information for those employees whose id is any id who earn the second highest salary. */
SELECT *
FROM employees
WHERE salary = (
		SELECT MAX(salary)
		FROM employees
		WHERE salary != (
				SELECT MAX(salary)
				FROM employees
				)
		)