# Write your MySQL query statement below

/*
firstName, lastName, city, state
*/

SELECT p.firstName, p.lastName, a.city, a.state
FROM Person AS P
LEFT JOIN Address as a
ON p.personId = a.personId;