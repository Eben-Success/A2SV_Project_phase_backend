# Write your MySQL query statement below
SELECT Department.name AS Department, Employee.name AS Employee, Salary
FROM Employee JOIN Department ON Employee.departmentId = department.Id
WHERE (DepartmentId, Salary) IN
(SELECT DepartmentId, MAX(salary) FROM Employee
GROUP BY DepartmentId)
