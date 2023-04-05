-- Q1.1
--Write a query that lists all Customers in either Paris or London. Include Customer ID, Company Name and all address fields.
--SELECT CustomerID, CompanyName, City, Postalcode, Country
--FROM Customers
--WHERE City IN ('Paris', 'London')

-- Q1.2
--List all products stored in bottles.
--SELECT ProductName, QuantityPerUnit	   
--FROM Products							   
--WHERE QuantityPerUnit LIKE '%bottle%'	   
										   
-- Q1.3
--Repeat question above, but add in the Supplier Name and Country.
--SELECT ProductName, QuantityPerUnit, CompanyName, Country
--FROM Products
--JOIN Suppliers ON products.SupplierID = suppliers.SupplierID
--WHERE QuantityPerUnit LIKE '%bottle%'

--Q1.4
--Write an SQL Statement that shows how many products there are in each category. Include Category Name in result set and list the highest number first.
--SELECT c.CategoryName, 
--	COUNT(p.ProductName) AS "No of Products"
--FROM Categories c
--JOIN Products p ON c.CategoryID = p.CategoryID
--GROUP BY c.CategoryName
--ORDER BY COUNT(p.ProductName) DESC

--Q1.5
--List all UK employees using concatenation to join their title of courtesy, first name and last name together. Also include their city of residence.
--SELECT 'Mr. ' + FirstName + ' ' + LastName AS "Employee", City
--FROM Employees
--WHERE City = 'London'

--Q1.6
--Count how many Orders have a Freight amount greater than 100.00 and either USA or UK as Ship Country.
--SELECT SUM(
--	CASE 
--		WHEN Freight > 100.00 AND 
--		ShipCountry IN ('USA', 'UK') 
--		THEN 1 
--		ELSE 0
--	END)
--	AS "No of Orders > 100 from US or UK"
--FROM Orders

--Q1.7
--Write an SQL statement which finds the Orderline with the highest discount applied. Report the Order Number of the order which contains this order line, 
--and the discount applied.
--SELECT Top 1 WITH TIES od.OrderID, od.Discount * od.UnitPrice * od.Quantity AS "Total Discount"
--FROM [Order Details] od
--ORDER BY "Total Discount" DESC


--Q1.8
--List all Employees from the Employees table and who they report to.
SELECT e1.FirstName + ' ' + e1.LastName AS EmployeeName, 
	e2.FirstName + ' ' + e2.LastName AS ManagerName 
FROM Employees e1
LEFT JOIN Employees e2 ON e1.ReportsTo = e2.EmployeeID

----------------------------------------------------------------------------------------------------

--Non aggegrate inside of SELECT clause must also be within GROUP BY

--SELECT 
--SUM(*) AS "JBs", Colour
--FROM JellyBabies
--GROUP BY Colour
-- 10 jbs, 3 yellow, 3 red, 4 blue

--SELECT et.EmployeeID,
--	CONCAT(e.firstname, ' ', e.lastname) AS "FULL Name",
--	COUNT(et.TerritoryId) AS "Number of territories covered"
--FROM EmployeeTerritories et
--JOIN Employees e ON e.EmployeeID = et.EmployeeID
--GROUP BY et.EmployeeID, e.FirstName, e.LastName
--Having COUNT(et.TerritoryId) > 5;

----------------------------------------------------------------------------------------------------

--List Orders from the Order table and JOIN to the [Customers] and [Employees] tables
--to include 'Customer Name' (Company Name) and 'Employee Name' (First and Last Name)
--
--From the Orders table, include OrderID, OrderDate and Freight
--SELECT o.OrderID, 
--	o.OrderDate, 
--	o.Freight,
--	c.CompanyName AS "Customer Name",
--	CONCAT(e.FirstName, ' ', e.LastName) AS 'Employee Name'
--From Orders o
--JOIN Customers c ON c.CustomerID = o.CustomerID
--JOIN Employees e ON e.EmployeeID = o.EmployeeID

--Using rows from Products, Group By Supplier showing an average of Units On Order for each Supplier
--Include the Supplier Name (use CompanyName) in the result set using an INNER JOIN to the Suppliers table
--Also remember the GROUP BY clause will need to include the Supplier Name
--
--Note: In the SELECT statement, you will need to specify which table you are requesting or use Aliases on 
--ALL columns that have the same name in multiple tables (eg. whatever SupplierID appears in the SQL)
--SELECT s.CompanyName, AVG(p.UnitsOnOrder)
--FROM Products p
--JOIN Suppliers s ON s.SupplierID = p.SupplierID
--GROUP BY s.CompanyName