---------------------------------------------------------------------
------------------------- Sub Query ---------------------------------
--===================================================================
-- Using Output Of Subquery [Inner Query]  As an Input For Another Query [Outer Query]

-- Select Student Id , Student First Name , Student Age Of Student 
-- That Their Age Is More Than Average Of All Student
-------------------------------------------------------------------
use ITI

Select St_Id , St_Fname , St_Age
From Student
Where St_Age > AVG(St_Age) -- Invalid (An aggregate may not appear in the WHERE clause)


Select St_Id , St_Fname , St_Age
From Student
Having AVG(St_Age) < St_Age 
-- Invalid (Column 'Student.St_Age' is invalid in the HAVING clause because it is not contained in either an aggregate function or the GROUP BY clause)

Select St_Id , St_Fname , St_Age
From Student
Where St_Age > (Select AVG(St_Age) From Student) -- Sub Query 

-----------------------------------------------------------
-- Page 1 From 20
-- Page 2 From 20
-- Page 3 From 20
-- ............
-- Page 20 From 20

-- Select Id Of Each Student And Count Of All Students
---------------------------------------------------------

Select St_Id , COUNT(*) Over (Partition by  *) -- Invalid
From Student

Select St_Id , (Select COUNT(St_Id) From Student)
From Student

----------------------------------------------------------
-- Get Departments Name That Has Students 
----------------------------------------------------------

Select Distinct D.Dept_Name
From Student S , Department D
Where D.Dept_Id = S.Dept_Id

Select Dept_Name
From Department
Where Dept_Id in (Select Distinct Dept_Id 
                  From Student 
				  Where Dept_Id is not null)

SELECT Dept_Name
FROM Department D
WHERE EXISTS (SELECT 1 FROM Student S WHERE S.Dept_Id = D.Dept_Id);
-- بمجرد ما تلاقي "طالب واحد" في القسم، بتوقف تدوير وتدخل على القسم اللي بعده (Short-circuit).

-- Best practice For This Example Is Using Join Instead Of Subquery

----------------------------------------------------------
-- Delete Student's grade who are Living In Mansoura
----------------------------------------------------------

Delete Stdcrs
From Stud_Course Stdcrs inner Join Student Std  
On std.St_Id  = Stdcrs.St_Id
Where St_Address = 'Mansoura'


Delete From Stud_Course
Where St_Id in (Select St_Id
                From Student
				Where St_Address = 'Mansoura')

-- Best practice For This Example Is Using Join Instead Of Subquery

---------------------------------------------------------------------
----------------------------- Top -----------------------------------
--===================================================================
-- Select All Data Of First 5 Students From Student Table 
---------------------------------------------

Select Top(5)*
From Student


-- Select Id , First name and Age Of First 10 Students From Student Table 
---------------------------------------------

Select Top(10) St_Id , St_Fname , St_Age
From Student

-- Select All Data Of Last 5 Students From Student Table 
---------------------------------------------------------

Select Top(5)*
From Student
Order by St_Id Desc

-- Select Instructor who Has Highest Salary 
--------------------------------------------------------

-- Max Value 
Select Max(Salary) [Max Salary]
From Instructor

-- Id And Name Of Instructor Has Highest Salary 
---------------------------------------------------

Select Top(1)  Ins_Id , Ins_Name
From Instructor
Order by Salary Desc

-- Id And Name Of Instructor Has Lowest Salary 
---------------------------------------------------
Select   Ins_Id , Ins_Name , Salary
From Instructor
where Salary is not null
Order by Salary 

Select  Top(1) Ins_Id , Ins_Name 
From Instructor
where Salary is not null
Order by Salary 

-- Get Id And Name Of Instructor Has 2 Highest Salary 
---------------------------------------------------

Select Top(2)  Ins_Id , Ins_Name
From Instructor
Order by Salary desc


-- Get 2nd Highest Salary Without Using Top 
---------------------------------------------------

Select Max(Salary)
From Instructor
Where Salary != (Select Max(Salary) From Instructor)

-- Get Id And Name Of Instructor Has 2nd Highest Salary 
---------------------------------------------------

Select  TOP(1) Ins_Id , Ins_Name
From (Select Top(2)  Ins_Id , Ins_Name , Salary
      From Instructor
      Order by Salary desc) As Highest_Two_Salaries
Order by Salary


-- Select 25% From Students In Student Table
-----------------------------------------------------------

Select Top(25)PERCENT *
From Topic

---------------------------------------------------------------------
----------------------- Top with Ties -------------------------------
--===================================================================
Select  TOP(6) Salary
From Instructor
Where Salary is not null
Order by Salary Desc
-- Return Only Top 6 Records

Select  TOP(6) WITH TIES Salary
From Instructor
Where Salary is not null
Order by Salary Desc
-- Return Top 8 Records


---------------------------------------------------------------------
----------------------- Random Selection  ---------------------------
--===================================================================

Select NEWID ( )  -- Creates a unique value (GUID - Globally Unique Identifier) of type uniqueidentifier 

Select St_Id , St_Fname , St_Age 
From Student
Order by St_Fname

Select TOP(2) St_Id , St_Fname , St_Age 
From Student
Order by St_Fname

Select TOP(2) St_Id , St_Fname , St_Age 
From Student
Order by NEWID()

---------------------------------------------------------------------
----------------------- Ranking Functions ---------------------------
--===================================================================
-- 1. ROW_NUMBER()
-- 2. DENSE_RANK()
-- 3. RANK()

Select Ins_Id , Ins_Name , Salary ,
ROW_NUMBER() Over (Order by Salary Desc) [Row_Number] ,
DENSE_RANK() Over (Order by Salary Desc) [Dense_Rank] ,
RANK()       Over (Order by Salary Desc) [Rank]
From Instructor


---------------------------------------------------------------------
------------------- Ranking Functions Examples ----------------------
--===================================================================


-- Get Id , Name , Age Of The 2 Older Students From student Table 
-------------------------------------------------------------------
-- Using Top 
Select Top 2 St_Id , St_Fname , St_Age
From Student
Order by St_Age Desc

-- Using Rank 

Select St_Id , St_Fname , St_Age , ROW_NUMBER() Over (Order by St_Age Desc) [RNumber]
From Student
Where RNumber <=2 -- Invalid 

Select *
From (Select St_Id , St_Fname , St_Age , ROW_NUMBER() Over (Order by St_Age Desc) [RNumber]
From Student) as Ranking
Where RNumber <=2


-- Get id , Name And Age Of 5th Younger Student
-------------------------------------------------

-- Using Top
select top 1*
from (Select top 5 St_Id , St_Fname , St_Age
From Student
where St_Age is not null
Order by St_Age ) [ Younger Student]
Order by St_Age Desc

-- Using Rank

select *
from(Select  St_Id , St_Fname , St_Age, ROW_NUMBER() Over (Order by St_age) As RNumber
From Student
where St_Age is not null ) [Younger Student]
where  RNumber =5


-- Get id , Name And Age Of Younger Student (For Each Department)
----------------------------------------------------------------

Select *
From (Select St_Id , St_Fname , St_Age , Dept_Id,ROW_NUMBER() Over (Partition by Dept_Id Order by St_Age  ) As RNumber
       From Student
       Where St_Age is not null And Dept_Id is not null ) As Ranking 
Where RNumber = 1

-- Get Id , Name , Salary , Dept_Id For The Instructor Has Min Salary Per Department For Each Department
---------------------------------------------------------------------------------------------------------

Select Dept_Id , Max(Salary)
From Instructor
Group by Dept_Id

Select  *
From (Select Ins_Id , Ins_Name , Salary , Dept_Id , 
       ROW_NUMBER() Over (Partition by Dept_Id  Order by Salary Desc) As Rnumber
From Instructor ) As Ranking
Where Rnumber = 1

---------------------------------------------------------------------
------------------------------ Ntile --------------------------------
--===================================================================

Select *
From
(Select Ins_Id , Ins_Name , Salary ,NTILE(3) Over (Order by Salary Desc) as NRank
From Instructor) As RankedInstructor
Where NRank = 3


Select Crs_Id , Crs_Name , Crs_Duration , NTILE(4) Over (Order by crs_Duration Desc) as NRank
From Course

Select Crs_Id , Crs_Name , Crs_Duration , Top_Id,
NTILE(2) Over (partition by Top_Id Order by crs_Duration Desc) as NRank
From Course


-- Used In Pagination
/* If We Have 100 Product and Want to Display Them in 10 Pages 
Select * 
From 
(Select id , name , Ntile(10) Over (Order by id) [Page]
From Products ) As Pages 
Where Page = 1 */


-----------------------------------------------------------------------------------------------------------
----------------------------------ASS#6----------------------------------
use ITI
-- 1.	Display instructors who have salaries less than the average salary of all instructors.
select AVG(salary) [Avrage Salary]
from Instructor

select *
from Instructor
where Salary < (select AVG(salary) 
from Instructor)

--2.Display the Department name that contains the instructor who receives the minimum salary.
SELECT D.Dept_Name 
FROM Department D JOIN Instructor I
ON D.Dept_Id = I.Dept_Id
WHERE I.Salary = (SELECT MIN(Salary) FROM Instructor);

--3.Select max two salaries in instructor table.

select top 2 *
from Instructor
order by Salary desc


--Use MyCompany DB
use MyCompany

--4.Display the data of the department which has the smallest employee ID over all employees' ID.
SELECT D.*
FROM Departments D JOIN Employee E
ON D.Dnum = E.Dno
WHERE E.SSN = (SELECT MIN(SSN) FROM Employee where Dno is not null)

  --5.	List the last name of all managers who have no dependents
  --- managers  is mange a department

Select emp.Lname , Dept.Dname
From Employee emp join Departments Dept
On Dept.MGRSSN = emp.SSN
Where emp.SSN not in (Select ESSN from [Dependent])

--6. For each department-- if its average salary is less than the average salary of
--   all employees displays its number, name and number of its employees.

Select Dept.Dnum , Dept.Dname , Count(emp.SSN) [Num of employees]
From Employee emp  join Departments Dept
On Dept.Dnum = emp.Dno
group by Dept.Dnum, Dept.Dname
Having AVG(emp.Salary) < ( select AVG(Salary)
from Employee)


-- 7.	Try to get the max 2 salaries using subquery.

select *
from Employee
order by Salary desc

-- Pure subquery solution

Select (Select Max(Salary) From Employee) [ 1st max salary],
( Select Max(Salary) From Employee Where Salary < (Select Max(Salary) From Employee) ) [ 2nd max salary]

--Display the employee number and name if he/she has at least one dependent 
--(use exists keyword) self-study.

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

/*-----------------------------------------------------------------------*/
use AdventureWorks2012
USE master;
ALTER AUTHORIZATION ON DATABASE::AdventureWorks2012 TO sa;

use AdventureWorks2012

--1.Display the SalesOrderID, ShipDate of the SalesOrderHearder table (Sales schema)
--  to designate SalesOrders that occurred within the period ‘7/28/2002’ and ‘7/29/2014’

select SalesOrderID, ShipDate
from  Sales.SalesOrderHeader
where [OrderDate] between '7/28/2002' and '7/29/2014'

--2.Display only Products(Production schema) with a StandardCost
--  below $110.00 (show ProductID, Name only)

select Name,ProductID,StandardCost
from [Production].[Product]
where StandardCost<110.00

--3.Display ProductID, Name if its weight is unknown
select [Name],ProductID
from [Production].[Product]
where [Weight] is null

--4. Display all Products with a Silver, Black, or Red Color
Select *
From Production.Product
Where Color in ('Silver' , 'Black' , 'Red')
 
SELECT *
from [Production].[Product]
WHERE [Name] LIKE 'B%';

--6.Run the following Query
--UPDATE Production.ProductDescription
--SET Description = 'Chromoly steel_High of defects'
--WHERE ProductDescriptionID = 3
--Then write a query that displays any Product description with underscore value in its description.

UPDATE Production.ProductDescription
SET Description = 'Chromoly steel_High of defects'
WHERE ProductDescriptionID = 3

SELECT [Description]
FROM Production.ProductDescription
WHERE Description LIKE '%[_]%';

--8. Display the Employees HireDate (note no repeated values are allowed)

select distinct HireDate
from [HumanResources].[Employee]

--9.Display the Product Name and its ListPrice within the values of 100 and 120 the list should have
--the following format "The [product name] is only! [List price]" (the list will be sorted according
--to its ListPrice value)

SELECT 
    CONCAT_WS('', 'The ' , Name , ' is only! ' ,ListPrice ) [Product With Price]
FROM Production.Product
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice;

SELECT [Name],ListPrice,
    'The ' + Name + ' is only! ' + CAST(ListPrice AS VARCHAR(10)) AS ProductInfo
FROM Production.Product
WHERE ListPrice BETWEEN 100 AND 120
ORDER BY ListPrice;