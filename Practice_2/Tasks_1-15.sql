/* 1. Write a query in SQL to display the full name (first and last), hire date, salary, and department number for those employees whose first name does not containing the letter M and make the result set in ascending order by department number.  */
SELECT FIRST_NAME
	,LAST_NAME
	,HIRE_DATE
	,SALARY
	,DEPARTMENT_ID
FROM EMPLOYEES
WHERE FIRST_NAME NOT LIKE '%M%'
ORDER BY DEPARTMENT_ID

/* 2. Write a query in SQL to display all the information of employees whose salary is in the range of 8000 and 12000 and commission is not null or department number is except the number 40, 120 and 70 and they have been hired before June 5th, 2002. */
SELECT *
FROM employees
WHERE (
		salary BETWEEN 8000
			AND 12000
		AND commission_pct IS NOT NULL
		)
	OR (
		department_id IN (
			40
			,120
			,70
			)
		AND hire_date < '1987-06-05'
		);

/* 3. Write a query in SQL to display the full name (first and last), the phone number and email separated by hyphen, and salary, for those employees whose salary is within the range of 9000 and 17000. The column headings assign with Full_Name, Contact_Details and Remuneration respectively. */
SELECT CONCAT (
		first_name
		,'-'
		,last_name
		) AS Full_Name
	,CONCAT (
		phone_number
		,'-'
		,email
		) AS Contact_Details
	,salary
FROM employees
WHERE salary BETWEEN 9000
		AND 17000;

/* 4. Write a query in SQL to display the full name (first and last) name, and salary, for all employees whose salary is out of the range 7000 and 15000 and make the result set in ascending order by the full name. */
SELECT CONCAT (
		first_name
		,' '
		,last_name
		) AS Full_Name
	,last_name
	,salary
FROM employees
WHERE salary NOT BETWEEN 7000
		AND 15000
ORDER BY Full_Name;

/* 5. Write a query in SQL to display the full name (first and last), job id and date of hire for those employees who was hired during November 5th, 2007 and July 5th, 2009 */
SELECT first_name
	,last_name
	,job_id
	,hire_date
FROM employees
WHERE hire_date BETWEEN '2007-11-05'
		AND '2009-07-05';

/* 6. Write a query in SQL to display the full name (first name and last name), hire date, commission percentage, email and telephone separated by '-', and salary for those employees who earn the salary above 11000 or the seventh digit in their phone number equals 3 and make the result set in a descending order by the first name. */
SELECT first_name
	,last_name
	,hire_date
	,CONCAT (
		commission_pct
		,email
		,'-'
		,phone_number
		) AS contact_info
	,salary
FROM employees
WHERE salary > 11000
	OR phone_number LIKE '______3%'
ORDER BY first_name DESC;

/* 7. Write a query in SQL to display the employee ID, first name, job id, and department number for those employees who is working except the departments 50,30 and 80. */
SELECT emplyee_id
	,first_name
	,job_id
	,department_id
FROM employees
WHERE department_id NOT IN (
		50
		,30
		,80
		)

/* 8. Write a query in SQL to display the ID for those employees who did two or more jobs in the past. */
SELECT employee_id
FROM job_history
GROUP BY employee_id
HAVING COUNT(*) >= 2;

/* 9. Write a query to display the name ( first name and last name ) for those employees who gets more salary than the employee whose ID is 163. */
SELECT first_name
	,last_name
FROM employees
WHERE salary > (
		SELECT salary
		FROM employees
		WHERE emplyee_id = 163
		)

/* 10. Write a query to display the name ( first name and last name ), salary, department id, job id for those employees who works in the same designation as the employee works whose id is 169. */
SELECT first_name
	,last_name
	,salary
	,department_id
	,job_id
FROM employees
WHERE job_id = (
		SELECT job_id
		FROM employees
		WHERE emplyee_id = 169
		)

/* 11. Write a query to display the name ( first name and last name ), salary, department id for those employees who earn such amount of salary which is the smallest salary of any of the departments. */
SELECT first_name
	,last_name
	,salary
	,department_id
FROM employees
WHERE salary IN (
		SELECT MIN(salary)
		FROM employees
		GROUP BY department_id
		)

/* 12. Write a query to display the employee id, employee name (first name and last name ) for all employees who earn more than the average salary. */
SELECT emplyee_id
	,first_name
	,last_name
FROM employees
WHERE salary > (
		SELECT DISTINCT AVG(salary)
		FROM employees
		)

/* 13. Write a query to display the employee name ( first name and last name ), employee id and salary of all employees who report to Payam. */
SELECT first_name
	,last_name
	,emplyee_id
	,salary
FROM employees
WHERE manager_id = (
		SELECT emplyee_id
		FROM employees
		WHERE first_name = 'Payam'
		)

/* 14. Write a query to display the department number, name ( first name and last name ), job and department name for all employees in the Finance department. */
SELECT e.department_id
	,e.first_name
	,e.last_name
	,j.job_title AS job_name
	,d.department_name
FROM employees AS e
	,departments AS d
	,jobs AS j
WHERE e.department_id = d.department_id
	AND j.job_id = e.job_id
	AND d.department_name = 'Finance';

/* 15. Write a query to display all the information of an employee whose salary and reporting person id is 3000 and 121 respectively. */
SELECT *
FROM employees
WHERE salary = 3000
	AND manager_id = 121