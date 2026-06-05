--=================================================================
---------------------------- Index --------------------------------
--=================================================================
 -- Clustered Index on St_Fname In Table student 
 ------------------------------------------------------------------
 Create Clustered Index Ix_Fname 
 On Student (St_Fname)
 -- Cannot create more than one clustered index on table Student

 Create NonClustered Index Ix_Fname -- Non-Unique , NonClustered Index
 On Student (St_Fname)

 Select *
 From Student
 Where St_Fname = 'Ahmed' -- Faster Search 

 ------------------------------------------------------------------
 -- New Table With Primary Key and Unique Key Constraints
 ------------------------------------------------------------------
 Create Table TestTable 
 (X int Primary Key , 
  Y int Unique ,
  Z int Unique )


 ------------------------------------------------------------------
 -- Unique Index on St_age In Table student 
 ------------------------------------------------------------------
 
 Create Unique Index Ix_Age
 On Student(St_age)
--  Make Unique Non-Clustered Index on Column

 Create Index Ix_Age02
 On Student(St_age)
 --  Make Non-Unique Non-Clustered Index on Column


 Select * From Student
 Where St_Id = 5

 select @@SERVERNAME
--=================================================================
------------------------ Indexed View -----------------------------
--=================================================================
Go
Create View StudentDepartmentViews
With Encryption 
As
   Select S.St_Id , S.St_Fname , D.Dept_Id , D.Dept_Name
   From Department D inner Join Student S 
   On D.Dept_Id = S.Dept_Id

Go 

Create OR Alter View StudentDepartmentViews
With Encryption , SchemaBinding
As
   Select S.St_Id , S.St_Fname , D.Dept_Id , D.Dept_Name
   From dbo.Department D inner Join dbo.Student S 
   On D.Dept_Id = S.Dept_Id

   Create Index Ix_Test 
   On StudentDepartmentViews([St_Id])
-- Cannot create index on view 'StudentDepartmentViews'. 
-- It does not have a unique clustered index.

   Create unique Clustered Index Ix_Test 
   On StudentDepartmentViews([St_Id])

   Create Index Ix_Test02 
   On StudentDepartmentViews([St_Id])


--=================================================================
----------------------------- TCL ---------------------------------
--=================================================================
-- Implicit transactions

Insert into Student(St_id ,St_Fname)
Values(100 ,'Aliaa') -- Implicit transaction

Update Student
Set St_Fname = 'Mona'
Where St_Id = 100 --Implicit transaction

-- Explicit transactions
-- Set of Implicit transactions 

Begin Transaction 
--Set of Implicit transactions 
Commit Transaction | Rollback Transaction

Create Table Parent 
(id int Primary Key)

Insert into Parent
Values(1),(2),(3),(4),(5)

Create Table Child
(id int Primary Key , 
Parent_Id int References Parent(id))


Insert into Child
Values(1,1),(2,200),(3,3)


Insert into Child Values(1,1)
Insert into Child Values(2,200) -- Error
Insert into Child Values(3,3)   



Begin Tran 
Insert into Child Values(1,1)
Insert into Child Values(2,200) 
Insert into Child Values(3,3)   
Commit Tran


Begin Tran 
Insert into Child Values(4,1)
Insert into Child Values(5,200) 
Insert into Child Values(6,3)   
rollback Tran



Begin Try 
    Begin Tran 
    Insert into Child Values(1,1) 
    Insert into Child Values(2,2) 
    Insert into Child Values(3,3) 
    Insert into Child Values(4,4) 
    Insert into Child Values(5,3)
	Commit Tran
End Try 
Begin Catch 
    Rollback Tran 
End Catch 




Begin Try 
    Begin Tran 
    Insert into Child Values(1,1) -- Request An OTP To Tran
    Insert into Child Values(2,200) -- Send OTP To My Mobile 
    Insert into Child Values(3,3) -- Enter Number And OTP At ATM
	Save Tran Tran01
    Insert into Child Values(4,100) -- Cash Withdrawal From ATM
    Insert into Child Values(5,3) -- Withdrawal from the account
	Commit Tran
End Try 
Begin Catch 
    Rollback Tran Tran01
End Catch 

Select * From Child

Delete From Child

--=================================================================
----------------------------- DCL ---------------------------------
--=================================================================-------------------------------------------------------------------
-- Create Login 
-------------------------------------------------------------------
CREATE LOGIN Salma
WITH PASSWORD = 'Salma123';

-------------------------------------------------------------------
-- Create User For Login 
-------------------------------------------------------------------
CREATE USER SalmaUser
FOR LOGIN Salma

-------------------------------------------------------------------
-- Give User Access To Table Course , Topic , Stud_Course
-------------------------------------------------------------------
Go
Create Schema Crs 

Alter Schema Crs 
Transfer Stud_Course 
 
GRANT SELECT 
ON  crs.Course  
TO SalmaUser

Revoke SELECT 
ON crs.Course  
From SalmaUser




------------------------------------------Ass#10-------------------------------------------------
----------------------------------Part 01--------------------------------------------
--Use ITI DB :
use ITI
-- 1- Create an index on column (Hiredate) that allows you to cluster the data in table Department. What will happen?
select Manager_hiredate from Department

create Clustered index IX_Hiredate
on Department(Manager_hiredate)
--Cannot create more than one clustered index on table 'Department'.
--Drop the existing clustered index 'PK_Department' before creating another.

-- 2- Create an index that allows you to enter unique ages in the student table. What will happen?

create unique index IX_Ages
on Student(St_Age) --error
--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for the object name 'dbo.Student'
-- and the index name 'IX_Ages'. The duplicate key value is (<NULL>).

--03  Try to Create Login Named(RouteStudent) who can access Only student and Course tables from ITI DB 
--      then allow him to select and insert data into tables and deny Delete and update

CREATE LOGIN RouteStudent
WITH PASSWORD = '123';

GO
CREATE USER [RouteStudent] FOR LOGIN [RouteStudent];
GO

-- Grant SELECT and INSERT on specific tables
GRANT SELECT, INSERT ON [dbo].[Student] TO [RouteStudent];
GRANT SELECT, INSERT ON [dbo].[Course] TO [RouteStudent];

--  Explicitly Deny UPDATE and DELETE
DENY UPDATE, DELETE ON [dbo].[Student] TO [RouteStudent];
DENY UPDATE, DELETE ON [dbo].[Course] TO [RouteStudent];
GO

EXECUTE AS USER = 'RouteStudent';
-- Try to select (Should work)
SELECT * FROM Student;
-- Try to delete (Should fail)
DELETE FROM Student WHERE St_Id = 1; 
REVERT;


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

-- Testing Referential Integrity , Mention What Will Happen When: 
-- Create an index on column (Salary) that allows you to cluster the data in table Employee.

Create clustered Index IX_Salary 
On Employee(Salary)

-- The operation failed because an index or statistics with name 'IX_Salary' already exists on table 'Employee'.
