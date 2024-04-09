
SELECT e.name as Employee
FROM Employee as e
WHERE e.salary > (SELECT salary FROM Employee WHERE id = e.managerId); 
