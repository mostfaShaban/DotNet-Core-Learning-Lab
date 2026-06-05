/*======================Assignment 06======================*/
/*== Part 01 ==*/
-- Use ITI DB
use ITI

--1.Display instructors who have salaries less than the average salary of all instructors.

Select *
From Instructor
Where Salary < (Select Avg(Salary) From Instructor)




--2.Display the Department name that contains the instructor who receives the minimum salary.

Select Department.Dept_Name
From Instructor join Department 
On Instructor.Dept_Id = Department.Dept_Id
Where Instructor.Salary = (Select Min(Salary) From Instructor)





--3.Select max two salaries in instructor table. 

Select top(2) Salary
From Instructor
order by Salary Desc



/*=========================================================================================================================*/

--Use MyCompany DB
use MyCompany

--1.Display the data of the department which has the smallest employee ID over all employees' ID.

Select Dept.*
From Employee emp join Departments Dept
On emp.Dno = Dept.Dnum
Where emp.SSN = (Select Min(SSN) From Employee where Dno is not null)




--2.List the last name of all managers who have no dependents.

Select emp.Lname , Dept.Dname
From Employee emp join Departments Dept
On Dept.MGRSSN = emp.SSN
Where emp.SSN not in (Select ESSN from [Dependent])



--3.For each department-- if its average salary is less than the average salary of all employees display its number,
--  name and number of its employees.

Select Dept.Dnum , Dept.Dname , Count(emp.SSN) [Number of employees]
From Departments Dept join Employee emp
On Dept.Dnum = emp.Dno
Group By Dept.Dnum , Dept.Dname
Having AVG(emp.Salary) < ( Select Avg(Salary) From Employee)



--4.Try to get the max 2 salaries using subquery

-- Using union & subquery

Select Max(Salary) 
From Employee
union
Select Max(Salary)
From Employee
Where Salary < (Select Max(Salary) From Employee)


-------------------------------------------------------------------------

-- Pure subquery solution

Select (Select Max(Salary) From Employee) [ 1st max salary],
( Select Max(Salary) From Employee Where Salary < (Select Max(Salary) From Employee) ) [ 2nd max salary]


-----------------------------------------------------------------------------------------------------------------------------------

--5.Display the employee number and name if he/she has at least one dependent (use exists keyword) self-study.

Select Distinct Fname , SSN
From Employee emp join [Dependent] D
On D.ESSN = emp.SSN
Where exists(select ESSN From [Dependent] where ESSN = SSN)


--Use ITI DB
use ITI

--1.Write a query to select the highest two salaries in Each Department for instructors
-- who have salaries. “using one of Ranking Functions”

Select *
From
(Select  Salary , Dept_Id ,ROW_NUMBER() over (partition by Dept_id order by salary desc) as [Rank]
From Instructor
Where Salary is not null) as [New Table]
Where  [Rank] In (1 ,2)



--2.Write a query to select a random  student from each department.  “using one of Ranking Functions”

Select *
From (Select St_Fname , Dept_Id , ROW_NUMBER() over ( partition by Dept_id order by newid()) as [Rank]
	  From Student
	  Where Dept_Id is not null) as [New Table]
Where [Rank] = 1 


/*=========================================================================================================================*/


/*== Part 02 ==*/
--Restore adventureworks2012 Database Then :
use AdventureWorks2012
--1.Display the SalesOrderID, ShipDate of the SalesOrderHearder table (Sales schema) to designate SalesOrders
-- that occurred within the period ‘7/28/2002’ and ‘7/29/2014’

Select SalesOrderID , ShipDate
From Sales.SalesOrderHeader
Where OrderDate between '7/28/2002' and '7/29/2014'


--2.Display only Products(Production schema) with a StandardCost below $110.00 (show ProductID, Name only)

Select ProductID , [Name] , StandardCost
From Production.Product
Where StandardCost < 100




--3.Display ProductID, Name if its weight is unknown

 Select ProductID , Name
 From Production.Product
 where [Weight] is null


--4.Display all Products with a Silver, Black, or Red Color

Select *
From Production.Product
Where Color in ('Silver' , 'Black' , 'Red')




--5.Display any Product with a Name starting with the letter B

Select *
From Production.Product
Where [Name] like 'B%'


--6.Run the following Query
--UPDATE Production.ProductDescription
--SET Description = 'Chromoly steel_High of defects'
--WHERE ProductDescriptionID = 3
--Then write a query that displays any Product description with underscore value in its description.
UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

Select [Description]
From Production.ProductDescription
Where [Description] like '%[_]%'


--7.Display the Employees HireDate (note no repeated values are allowed)

Select Distinct  HireDate
From HumanResources.Employee


--8.Display the Product Name and its ListPrice within the values of 100 and 120 the list should have the following format 
-- "The [product name] is only!= [List price]" (the list will be sorted according to its ListPrice value)

Select CONCAT_WS(' ' , 'The' ,[Name] , 'is only! =' , ListPrice)  [Product With Price]
From Production.Product
Where ListPrice between 100 and 120
Order by ListPrice





