/*=========================== Assignment 10 ===========================*/

-- Part 01 --

--Use ITI DB :
use ITI
--•	Create an index on column (Hiredate) that allows you to cluster the data in table Department. What will happen?
use iti 

GO
CREATE CLUSTERED INDEX IX_Employee_HiringDate
ON DEPARTMENT(Manager_hiredate)
GO

-- ** This will raise an error because there is already a clustered index in the table on  its primary key and the table
-- can't have more than on clustered index for each table.
-- **if this index creation is a must , we should drop the index on the dept_id First.



--•	Create an index that allows you to enter unique ages in the student table. What will happen?
create unique nonclustered index IX_STUD_AGE
on student(st_age)

-- IT WILL RAISE AN ERROR BECAUSE OF DUPLICATE VALUES
--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student' and the index name 'IX_STUD_AGE'.

--•	Try to Create Login Named(RouteStudent) who can access Only student and Course tables from ITI DB then allow him to select and insert data into tables and deny Delete and update
Insert into Student (St_Id , St_Fname)
Values( 201, 'Rawan') -- Done

Select *
From Student -- Done

Update Student
Set St_Lname = 'Tarek'
Where St_Id = 201 -- Denied

Delete 
From Student
Where St_Id = 201 -- Denied
----------------------------------------------------------------------------------------------------

/*========================================================================================================*/
--Part 02

-- Use MyCompany DB
Use MyCompany

-- 1. Create a trigger to prevent anyone from Modifying or
-- Delete or Insert in the Employee table ( Display a message for user to tell him that he can’t take any action with this Table) 

GO
Create Trigger PreventAllOperations
On Employee
Instead of Insert , Update , Delete
As
	Print 'You can''t do any operation on this table'

GO


Insert into Employee (SSN)
Values (113344)

----------------------------------------------------------------------------------------------------------------------------------------
-- Testing Referential Integrity , Mention What Will Happen When: 
-- Create an index on column (Salary) that allows you to cluster the data in table Employee.

Create clustered Index IX_Salary 
On Employee(Salary)

-- The operation failed because an index or statistics with name 'IX_Salary' already exists on table 'Employee'.

----------------------------------------------------------------------------------------------------------------------------------------

-- 3. Try to Create Login With Your Name And give yourself access Only to Employee then allow this login to
-- select and insert data into tables and deny Delete and update 



Select *
From Employee -- Done

Insert Into Employee(SSN)
Values(100) -- Done


Update Employee
Set Fname = 'Shahd'
Where SSN = 112244 -- Denied

Delete 
From Employee
Where SSN = 112244 -- Denied

----------------------------------------------------------------------------------------------------------------------------------------








/*========================================================================================================*/
--Part 03

--Create a database “by Wizard” named “RouteCompany”
--1.	Create the following tables with all the required information and load the required data as specified in each table using insert statements[at least two rows]
use RouteCompany

--Table Name				Details										Comments

--Department		--DeptNo (PK)	DeptName	Location      --	1-Create it programmatically	--[By Code]						
					--d1			Research		NY
					--d2			Accounting		DS
					--d3			Marketing		KW
															
create table Department
(
DeptNo int Primary Key,
DeptName varchar(50),
[Location] varchar(20)
)

insert into Department
values (1 , 'Research' , 'NY'),
       (2 ,'Accounting','DS'),
	   (3 , 'Marketing','KW')


--Employee	--EmpNo (PK)	Emp Fname	Emp Lname	DeptNo		Salary
			--25348			Mathew		Smith		d3			2500
			--10102			Ann			Jones		d3			3000
			--18316			John		Barrymore	d1			2400
			--29346			James		James		d2			2800
			--9031			Lisa		Bertoni		d2			4000
			--2581			Elisa		Hansel		d2			3600
			--28559			Sybl		Moser		d1			2900
--1-Create it programmatically
--2-PK constraint on EmpNo
--3-FK constraint on DeptNo
--4-Unique constraint on Salary
--5-EmpFname, EmpLname don’t accept null values 


create table Employee
(
EmpNo int Primary Key,
EmpFname varchar(40) not null,
EmpLname varchar(40) not null,
DeptNo int foreign key references Department(DeptNo) ,
Salary int unique
)

insert into Employee
values (25348 , 'Mathew' , 'Smith' , 3 , 2500),
       (10102 , 'Ann' , 'Jones' , 3 , 3500),
	   (18316 , 'John' , 'Barrimore' , 1 , 2400),
       (29346 , 'James' , 'James' , 2 , 2800),
	   (9031 , 'Lisa' , 'Bertoni' , 2 , 4000),
	   (2581 , 'Elisa' , 'Hansel' , 2 , 3600),
	   (28559 , 'Sybl' , 'Moser' , 1 , 2900)

--Project	--ProjectNo (PK)	ProjectName		Budget
			--p1				Apollo			120000
			--p2				Gemini			95000
			--p3				Mercury			185600

--1-Create it by Wizard
--2-ProjectName can't contain null values
--3-Budget allow null

insert into Project
values ( 1 , 'Apollo' , 120000),
       ( 2 , 'Gemini' , 95000),
       ( 3 , 'Mercury' , 185600)

--Works_on	--EmpNo (PK)	ProjectNo(PK)	Job			Enter_Date
			--10102				p1			Analyst		2006.10.1
			--10102				p3			Manager		2012.1.1
			--25348				p2			Clerk		2007.2.15
			--18316				p2			NULL		2007.6.1
			--29346				p2			NULL		2006.12.15
			--2581				p3			Analyst		2007.10.15
			--9031				p1			Manager		2007.4.15
			--28559				p1			NULL		2007.8.1
			--28559				p2			Clerk		2012.2.1
			--9031				p3			Clerk		2006.11.15
			--29346				p1			Clerk		2007.1.4

--1-Create it Wizard
--2- EmpNo INTEGER NOT NULL
--3-ProjectNo doesn't accept null values
--4-Job can accept null
--5-Enter_Date can’t accept null
--and has the current system date as a default value[visually]
--6-The primary key will be EmpNo,ProjectNo) 
--7-there is a relation between works_on and employee, Project  tables

insert into Works_on
values (10102 , 1 , 'Analyst' ,'2006.10.1'),
       (10102 , 3 , 'Manager' ,'2012.1.1'),
	   (25348 , 2 , 'Clerk' ,'2007.2.15'),
       (18316 ,2,NULL,'2007.6.1'),
       (29346,2,NULL,'2006.12.15'),
       (2581,3,'Analyst','2007.10.15'),
       (9031,1,'Manager','2007.4.15'),
       (28559,1,NULL,'2007.8.1'),
       (28559,2, 'Clerk','2012.2.1'),
       (9031,3,'Clerk','2006.11.15'),
       (29346,1,'Clerk','2007.1.4')

---------------------------------------------------------------------------------------------

--Testing Referential Integrity	
--1-Add new employee with EmpNo =11111 In the works_on table [what will happen]
insert into works_on (EmpNo)
values (11111)

-- The statement has been terminated (INSERT fails) 
-- Cannot insert the value NULL into column 'ProjectNo'column does not allow nulls
---------------------------------------------------------------------------------------------
--2-Change the employee number 10102  to 11111  in the works on table [what will happen]

update Works_on
set EmpNo = 11111
where EmpNo = 10102

-- because there is no employee with number 11111 
-- The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Works_on_Employee".
-- The conflict occurred in database "RouteCompany", table "HR.Employee", column 'EmpNo'.

---------------------------------------------------------------------------------------------
--3-Modify the employee number 10102 in the employee table to 22222. [what will happen]

update Employee
set EmpNo = 22222
where EmpNo = 10102

-- The statement has been terminated.
-- The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "RouteCompany", table "dbo.Works_on", column 'EmpNo'.

---------------------------------------------------------------------------------------------
--4-Delete the employee with id 10102

delete from Employee 
where EmpNo = 10102

-- The statement has been terminated.
--The DELETE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee". 
-- The conflict occurred in database "RouteCompany", table "dbo.Works_on", column 'EmpNo'.

---------------------------------------------------------------------------------------------

--Table Modification

--1-Add  TelephoneNumber column to the employee table[programmatically]
alter table Employee
add TelephoneNumber varchar(15)

--2-drop this column[programmatically]
alter table Employee
drop column TelephoneNumber

--3-Build A diagram to show Relations between tables
----------------------------------------------------------------------------------------------
--2.	Create the following schema and transfer the following tables to it 
	--a.	Company Schema 
		--i.	Department table 
		--ii.	Project table
		
Go
create  schema Company 
Go

Go
alter schema Company transfer Department
Go

Go
alter schema Company transfer Project
Go



	--b.	Human Resource Schema
		--i.	  Employee table 
Go
create schema HR
Go

alter schema HR transfer Employee

--3.	Increase the budget of the project where the manager number is 10102 by 10%.


-- First Select the target data

Select *
from  Company.Project Pro join Works_on Wo
on  Pro.ProjectNo = Wo.ProjectNo 
and  Emp.EmpNo = 10102
and Wo.Job = 'manager' 

update [Company].[PROJECT]
set Budget += Budget * 0.1
from  Company.Project Pro join Works_on Wo
on  Pro.ProjectNo = Wo.ProjectNo 
Where  Emp.EmpNo = 10102
and Wo.Job = 'manager' 




--4.	Change the name of the department for which the employee named James works.The new department name is Sales.
update	Company.Department
set DeptName = 'Sales'
from Company.Department Dep join HR.Employee Emp
on Dep.DeptNo = Emp.DeptNo 
where Emp.EmpFname = 'James'

--5.	Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. The new date is 12.12.2007.
update Works_on 
Set Enter_Date = '12.12.2007'
From HR.Employee Emp join Company.Department Dep 
On  Dep.DeptNo = Emp.DeptNo join  Works_on Wo 
On Emp.EmpNo = Wo.EmpNo 
Where Wo.ProjectNo =1 
and dep.DeptName = 'Sales'

--6.Delete the information in the works_on table for all employees who work for the department located in KW.

delete from Works_on
where EmpNo in (select EmpNo from HR.Employee E join Department D On D.DeptNo = E.DeptNo Where D.Location = 'KW') 

------------------------------------------------------------------------------------------------------------------------
