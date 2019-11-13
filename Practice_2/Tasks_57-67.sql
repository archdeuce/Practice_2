/* 57. Write a query in SQL to display the first name, last name, department number, and department name for each employee. */
SELECT e.first_name
	,e.last_name
	,e.department_id
	,d.department_name
FROM employees AS e
INNER JOIN departments AS d ON e.department_id = d.department_id

/* 58. Write a query in SQL to display the first and last name, department, city, and state province for each employee. */
SELECT e.first_name
	,e.last_name
	,d.department_name
	,l.city
	,l.state_province
FROM employees AS e
INNER JOIN departments AS d ON e.department_id = d.department_id
INNER JOIN locations AS l ON d.location_id = l.location_id;

/* 59. Write a query in SQL to display the first name, last name, salary, and job grade for all employees. */
SELECT first_name
	,last_name
	,salary
	,grade_level
FROM employees AS e
INNER JOIN job_grades AS j ON e.salary BETWEEN j.lowest_sal
		AND j.highest_sal;

/* 60. Write a query in SQL to display the first name, last name, department number and department name, for all employees for departments 80 or 40. */
SELECT first_name
	,last_name
	,salary
	,department_name
FROM employees AS e
INNER JOIN departments AS d ON e.department_id = d.department_id
WHERE e.department_id IN (
		80
		,40
		)

/* 61. Write a query in SQL to display those employees who contain a letter z to their first name and also display their last name, department, city, and state province. */
SELECT e.first_name
	,e.last_name
	,d.department_name
	,l.city
	,l.state_province
FROM employees AS e
INNER JOIN departments AS d ON e.department_id = d.department_id
INNER JOIN locations AS l ON d.location_id = l.location_id
WHERE first_name LIKE '%z%'

/* 62. Write a query in SQL to display all departments including those where does not have any employee. */
SELECT e.first_name
	,e.last_name
	,d.department_id
	,d.department_name
FROM employees AS e
RIGHT OUTER JOIN departments AS d ON e.department_id = d.department_id

/* 63. Write a query in SQL to display the first and last name and salary for those employees who earn less than the employee earn whose number is 182. */
SELECT e1.first_name
	,e1.last_name
	,e1.salary
FROM employees AS e1
INNER JOIN employees AS e2 ON e1.salary < e2.salary
	AND e2.emplyee_id = 182

/* 64. Write a query in SQL to display the first name of all employees including the first name of their manager. */
SELECT e.first_name AS employee_name
	,m.first_name AS manager_name
FROM employees AS e
INNER JOIN employees AS m ON e.manager_id = m.emplyee_id;

/* 65. Write a query in SQL to display the department name, city, and state province for each department. */
SELECT d.department_name
	,l.city
	,l.state_province
FROM departments AS d
INNER JOIN locations AS l ON d.location_id = l.location_id

/* 66. Write a query in SQL to display the first name, last name, department number and name, for all employees who have or have not any department. */
SELECT e.first_name
	,e.last_name
	,d.department_id
	,d.department_name
FROM employees AS e
LEFT OUTER JOIN departments AS d ON e.department_id = d.department_id

/* 67. Write a query in SQL to display the first name of all employees and the first name of their manager including those who does not working under any manager. */
SELECT e.first_name AS employee_name
	,m.first_name AS manager_name
FROM employees AS e
LEFT OUTER JOIN employees AS m ON e.manager_id = m.emplyee_id;