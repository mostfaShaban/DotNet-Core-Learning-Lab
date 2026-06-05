
---------------------Ass#10------------------------------------
----------------------------Part03-----------------------------

select @@SERVERNAME

SELECT name, is_disabled, create_date
FROM sys.server_triggers
WHERE name LIKE '%owner%' OR is_disabled = 0;

use RouteCompany

 create table Department
(
 DeptNo varchar(30) primary key,
 DeptName varchar(20),
 [Location] varchar(30)
);

 Insert into Department
 values('d1','Research','NY'),
       ('d2','Accounting','DS'),
       ('d3','Marketing','KW')

create table Employee
(
 EmpNo int primary key,
 Emp_Fname varchar(20) not null,
 Emp_Lname varchar(20) not null,
 DeptNo varchar(30) REFERENCES Department (DeptNo),
 Salary Int unique , 
);

USE RouteCompany; -- Replace with your database name
GO
ALTER AUTHORIZATION ON DATABASE::RouteCompany TO sa;
GO

INSERT INTO Works_on (EmpNo, ProjectNo, Job, Enter_Date)
VALUES 
    (28559, 'p1', NULL, '2007-08-01'),
    (28559, 'p2', 'Clerk', '2012-02-01'),
    (9031, 'p3', 'Clerk', '2006-11-15'),
    (29346, 'p1', 'Clerk', '2007-01-04');

--------Testing Referential Integrity
-- 1-Add new employee with EmpNo =11111 In the works_on table [what will happen]

INSERT INTO Works_on (EmpNo, ProjectNo, Job, Enter_Date)
VALUES (11111, 'p1', 'Analyst', GETDATE());

-- The conflict occurred in database "RouteCompany", table "dbo.Employee", column 'EmpNo'.

-- 2-Change the employee number 10102  to 11111  in the works on table [what will happen]
update Works_on
set EmpNo=11111
where EmpNo=10102 --The conflict occurred in database "RouteCompany", table "dbo.Employee", column 'EmpNo'.


--3-Modify the employee number 10102 in the employee table to 22222. [what will happen]
update Employee
set EmpNo=22222
where EmpNo=10102 --error

--4-Delete the employee with id 10102

delete from Employee
where EmpNo=10102

----------------------Table Modification
-- 1-Add  TelephoneNumber column to the employee table[programmatically]

ALTER TABLE employee
ADD TelephoneNumber VARCHAR(20);

-- 2-drop this column[programmatically]
ALTER TABLE employee
DROP COLUMN TelephoneNumber;

/*  2.Create the following schema and transfer the following tables to it 
         Company Schema 
                 1. Department table 
                   2..Project table 
Human Resource Schema
                  1.Employee table      */ 
Go           
CREATE SCHEMA Company
CREATE SCHEMA [Human Resource]
Go

ALTER SCHEMA Company TRANSFER dbo.Department;
ALTER SCHEMA Company TRANSFER dbo.Project;

ALTER SCHEMA [Human Resource] TRANSFER [dbo].[Employee];

-- 3.Increase the budget of the project where the manager number is 10102 by 10%.

UPDATE Company.Project
SET Budget += Budget * 0.1
WHERE ProjectNo IN (
    SELECT ProjectNo 
    FROM Works_on 
    WHERE EmpNo = 10102 AND Job = 'Manager'
);

select *
from Company.Project

select *
from dbo.Works_on

--4.Change the name of the department for which the employee named James works.
--  The new department name is Sales.
select *
from Company.Department-- accounting


select *
from [Human Resource].[Employee]

UPDATE Company.Department
SET DeptName = 'Sales'
WHERE DeptNo IN (
    SELECT DeptNo 
    FROM [Human Resource].Employee 
    WHERE Emp_Fname = 'James'
);
select *
from Company.Department-- Sales

-- 5.Change the enter date for the projects for those employees who work in project p1 
--    and belong to department ‘Sales’. The new date is 12.12.2007.

SELECT * FROM [Human Resource].Employee
WHERE DeptNo = (
    SELECT DeptNo 
    FROM Company.Department 
    WHERE DeptName = 'Sales'
);

UPDATE Works_on
SET Enter_Date = '2007-12-12'
WHERE EmpNo IN (
    SELECT EmpNo 
    FROM [Human Resource].Employee 
    WHERE DeptNo = (SELECT DeptNo FROM Company.Department WHERE DeptName = 'Sales')
); --(5 rows affected)


--  6.Delete the information in the works_on table for all employees who work 
--    for the department located in KW.

delete  from [dbo].[Works_on]
WHERE EmpNo IN (
    SELECT EmpNo 
    FROM [Human Resource].Employee 
    WHERE DeptNo IN (SELECT DeptNo FROM Company.Department WHERE Location = 'KW'))

---finished ################################333