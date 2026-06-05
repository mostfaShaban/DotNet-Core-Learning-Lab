--=================================================================
------------------------ Execution Order --------------------------
--=================================================================

Select CONCAT_WS(' ' , St_Fname , St_Lname) FullName
From Student
Where FullName = 'Ahmed Hassan' -- Invalid column name 'FullName'

Select CONCAT_WS(' ' , St_Fname , St_Lname) FullName
From Student
Order by FullName -- Valid 

-- Execution Order 


Select FullName
From ( Select CONCAT_WS(' ' , St_Fname , St_Lname) FullName
       From Student ) As StudentFullNames
Where FullName = 'Ahmed Hassan'

--=================================================================
------------------------- Union Family ----------------------------
--=================================================================
-- Union - Union All - Intersect - Except 

Select St_Fname From Student
Except
Select Ins_Name From Instructor

Select St_id , St_Fname From Student -- Invalid
Union
Select Ins_Name From Instructor 
-- All queries combined using a UNION, INTERSECT or EXCEPT operator must have an equal number of expressions in their target lists.


Select St_id , St_Fname From Student -- Invalid
Union
Select Ins_Name , Ins_Id From Instructor 
-- Conversion failed when converting the nvarchar value 'Ahmed' to data type int.


--=================================================================
----------------------------- Schema ------------------------------
--=================================================================

Create Table [Server].[Database].[Schema].Test 
(

)

-- Dbo : Database Owner [Default Schema]
SELECT @@SERVERNAME;

Select *
From [DESKTOP-DK3RCHS].[ITI].[Dbo].Student

Select *
From Student

Select *
From MyCompany.dbo.Employee


-- Create Schema [Structure]
-------------------------------------------------------------------
go
Create Schema HR
go 
-- Transfer Database Object From Schema To Another Schema
-------------------------------------------------------------------

Alter Schema HR
Transfer Student


Select *
From Student -- Invalid object name 'Student'

Select *
From HR.Student 

Alter Schema dbo
Transfer HR.Student

Select *
From Student -- Valid 

-- Create New Table Department
-------------------------------------------------------------------

Create Table Department
(Id int Primary key) -- There is already an object named 'Department' in the database

Create Table HR.Department 
(Id int Primary key) 
-- Valid Created In Schema HR


-- Drop Schema
-------------------------------------------------------------------

Drop Schema HR
--  Cannot drop schema 'HR' because it is being referenced by object 'Department'.

-- Drop Table Then Drop Schema
Drop Table HR.Department
Drop Schema HR


--=================================================================
-------------------------- Select Into ----------------------------
--=================================================================

Select * into NewProject
From MyCompany.dbo.Project


Select Pname , Pnumber into NewProject02
From MyCompany.dbo.Project

Go
create Schema HR
Go
Select Pname , Pnumber into HR.NewProject02
From MyCompany.dbo.Project
     
Select Plocation , City into HR.NewProject03 -- Plocation , City Has Null Values
From MyCompany.dbo.Project
     
Select * into NewProject04
From MyCompany.dbo.Project
Where 1 = 2

Select Plocation , City into NewProject05
From MyCompany.dbo.Project
Where 1 = 2

--=================================================================
-------------------- Insert Based On Select  ----------------------
--=================================================================

Insert into NewProject04
Select * From MyCompany.dbo.Project


Insert into NewProject05
Select * From MyCompany.dbo.Project
-- Invalid Column name or number of supplied values does not match table definition.


Insert into NewProject05
Select Plocation , City From MyCompany.dbo.Project


Select Pname , Pnumber into NewProject06
From MyCompany.dbo.Project
Where 1 = 2

Insert into NewProject06(Pnumber)
Select Pnumber  From MyCompany.dbo.Project


--=================================================================
---------------- Delete Vs Drop Vs Truncate -----------------------
--=================================================================

Drop Table NewProject 
-- Drop Table Structure With Data 

Delete From NewProject02 
-- Delete All Records From Table NewProject02 Doesn't Affect Structure

Truncate Table NewProject04
-- Removes all rows from a table without logging the individual row deletions


--=================================================================
------------------- Delete And update Rules -----------------------
--=================================================================

-- Delete Rule
Delete From Department
Where Dept_Id = 10 
-- The DELETE statement conflicted with the REFERENCE constraint "FK_Student_Department".
-- The conflict occurred in database "ITI", table "dbo.Student", column 'Dept_Id'.

-- 1. Cascade
     Delete From Student
	 Where Dept_Id = 10

-- 2. Set Null 
     Update Student
	 Set Dept_Id = NULL
	 Where Dept_Id = 10

-- 3. Set Default 
     Update Student
	 Set Dept_Id = 20
	 Where Dept_Id = 10
     

    Delete From Department
    Where Dept_Id = 10
--The DELETE statement conflicted with the REFERENCE constraint "FK_Instructor_Department". 
-- The conflict occurred in database "ITI", table "dbo.Instructor", column 'Dept_Id'.

-- 1. Cascade
     Delete From Instructor
	 Where Dept_Id = 10

-- 2. Set Null 
     Update Instructor
	 Set Dept_Id = NULL
	 Where Dept_Id = 10

-- 3. Set Default 
     Update Instructor
	 Set Dept_Id = 20
	 Where Dept_Id = 10
   
   
    Delete From Department
    Where Dept_Id = 10 -- Deleted successfully 



-- Set Delete Rule For Student-Department RelationShip Cascade 
-- Set Delete Rule For Instructor-Department RelationShip Set Null 

    Delete From Department
    Where Dept_Id = 40
-- The DELETE statement conflicted with the SAME TABLE REFERENCE constraint "FK_Student_Student". 
-- The conflict occurred in database "ITI", table "dbo.Student", column 'St_super'.    -- (St_super)


-- Self Relationship Rules Using Code Only 

   Update Student
   Set St_super = NULL
   Where St_super in (Select st_Id 
                      From Student
					  Where Dept_Id = 40)
    
	Update Std
    Set St_super = NULL
	From Student Std , Student SuperVisors
	Where SuperVisors.St_Id = Std.St_super And SuperVisors.Dept_Id = 40


    Delete From Department
    Where Dept_Id = 40 -- Deleted successfully 

-- Set Relationship Rule Code  (من الاول يعني )

	Create table Test 
	(Id int Primary key , 
	Testing int References Student(st_Id) ON DELETE CASCADE
	)


--=================================================================
-------------------- User Defined Functions -----------------------
--=================================================================

-- Scalar Function 
-------------------------------------------------------------------
-- Create Function Take Id Of Student And Returns His Full Name 
-------------------------------------------------------------------
Go
CREATE FUNCTION GETStudentNameByID(@Id Int)
RETURNS Varchar(40)
Begin
  Declare @StudentName varchar(30)
  select @StudentName = CONCAT_WS('  ', St_Fname , St_Lname)
  from Student
  where St_Id=@id
  Return @studentName
End
GO
select dbo.GETStudentNameByID(10)[fullName]
Select dbo.GetStudentNameById(1) [Full Name]
Select dbo.GetStudentNameById('1') [Full Name]
Select dbo.GetStudentNameById('Aliaa') [Full Name] -- Invalid
Print dbo.GetStudentNameById(1) 

-------------------------------------------------------------------
-- Create Function Take Department Name And Return Name Of Its Manager
-------------------------------------------------------------------
Use MyCompany

select em.Fname
  from Employee em join Departments Dep
  on em.Dno=Dep.Dnum --EmployeeOFDepts

Select  Emp.Fname
  From Departments Dept  Join Employee Emp 
  On Emp.SSN = Dept.MGRSSN --- managersOfDepts

Go
CREATE Or Alter FUNCTION GETNameMangbyDeptName(@DeptName varchar(30))
Returns Varchar(20)
Begin
  Declare @MangName varchar(30)
  select @MangName = em.Fname
  from Employee em join Departments Dep
  on em.SSN = Dep.MGRSSN and Dep.Dname=@DeptName
  Return @MangName
End
GO

Select dbo.GETNameMangbyDeptName('DP3')

Drop Function GETNameMangbyDeptName


Create Schema HR2 
Go
Create Function HR.GETNameMangbyDeptName(@DeptName varchar(30))
Returns Varchar(20)
Begin
  Declare @MangName varchar(30)
  select @MangName = em.Fname
  from Employee em join Departments Dep
  on em.Dno=Dep.Dnum and Dep.Dname=@DeptName
  Return @MangName  ----فيها غلطة صححتها فوق 
End
GO

Select HR.GETNameMangbyDeptName('DP3') ---not maged but edward
Drop Function GETNameMangbyDeptName -- Drop Function in dbo (Default Schema)
Drop Function HR.GETNameMangbyDeptName -- Drop Function in dbo (Default Schema)

-------------------------------------------------------------------
-- Alter Function GetDepartmentManagerByDeptName
-------------------------------------------------------------------
Create Function GetDeptManagerByDeptName (@DeptName varchar(20)) -- Alter   / Create or Alter
Returns varchar(20)
Begin 
  Declare @managerName Varchar(20)
   
   Select @managerName = Emp.Fname
   From Departments Dept Inner Join Employee Emp 
   On Emp.SSN = Dept.MGRSSN And Dept.Dname = @DeptName
   Return @managerName
End 

Select dbo.GetDepartmentManagerByDeptName('DP1') -- Invalid object name 'Department'

Alter Schema HR
Transfer GetDepartmentManagerByDeptName



-- Inline table-valued function
-------------------------------------------------------------------
-- Create Function That Take Department Id 
-- and Return Instructors That Works In It
-------------------------------------------------------------------
use ITI
Go
CREATE Function GetInstructorsByDeptId(@Id int)
Returns Table
As
  Return
  (
  Select Ins_Id , ins_name , Salary , Dept_Id
      From Instructor
      Where Dept_id=@Id 
  )
GO
Select * From GetInstructorsByDeptId(10)


-- Multi-Statement Table-valued function
-------------------------------------------------------------------
-- Create Function That Take Format And Return Student Name Based 
-- On Format (First , Last , Fullname)
-------------------------------------------------------------------
Create Function GetStudentNameBasedOnFormat (@Format varchar(20))
Returns @Data Table  ( StdId int ,  StdName varchar(50) )
AS
Begin 
   if @Format = 'First'
     Insert into @Data
	 Select St_id , St_Fname
	 From Student
   Else If @Format = 'Last'
   Insert into @Data
	 Select St_id , St_Lname
	 From Student
   Else If  @Format = 'Fullname'
   Insert into @Data
	 Select St_id , CONCAT_WS(' ' , St_Fname , St_Lname)
	 From Student
	 Return
End 
Select * From GetStudentNameBasedOnFormat('Fullname')


----------------------------------------------------------------------------------
---------------------------------------ASS#7--------------------------------------
use ITI
--1.Create a scalar function that takes a date and returns the Month name of that date.
Go
Create Function GetMonthNameFromDate(@Date date)
returns varchar(50)
Begin
 return Format(@date , 'MMMM')

End
Go

select dbo.GetMonthNameFromDate(GETDATE())[Month Name]

--2.Create a multi-statements table-valued function that takes 2 integers and returns 
--   the values between them

Go
Create or Alter Function GetValuesBetween (@Lower int , @Upper int )
returns @Numbers Table ([Values] int)

as
Begin
IF @Lower > @Upper
    BEGIN
        DECLARE @Temp INT = @Lower;
        SET @Lower = @Upper;
        SET @Upper = @Temp;
    END
	
	While(@Lower < @upper - 1)
		Begin
			Set @Lower += 1 -- Lower = Lower + 1
			Insert into @Numbers values (@Lower)
		End

		return

End
Go
select * from GetValuesBetween(10,15)
select * from GetValuesBetween(15,10)

---3.	Create a table-valued function that 
--      takes Student No and returns Department Name with Student full name.

Go
create Function GetDepNumStudFnum(@StudId int)
Returns Table
As
  Return
  (
  Select Dep.Dept_Name, CONCAT_WS(' ',std.St_Fname,std.St_Lname)[fullName]
      From Department Dep join Student Std
      on Dep.Dept_Id=Std.Dept_Id and std.St_Id=@StudId 
  )
GO
Select * From GetDepNumStudFnum('10')
Select * From GetDepNumStudFnum('12')

---4.	Create a scalar function that takes Student ID and returns a message to user.
 --   a. If first name and Last name are null, then display 'First name & last name are null
--    b. If First name is null, then display 'first name is null'
--    c. If Last name is null, then display 'last name is null.'
--    d. Else display 'First name & last name are not null'

Go
Create or alter Function GetMessageToUser(@StudId int)
returns varchar(max)
Begin
  declare @massage varchar(max)
  declare @fristName varchar(20),@lastName varchar(20)
  select @fristName=St_Fname, @lastName= St_Lname
  from Student
  where St_Id=@StudId
  if (@fristName is null) and (@lastName is null)
		Select @massage = 'First name & last name are null'
  else if (@fristName is null)
   		Select @massage = 'First name is null'
  else if (@lastName is null)
   		Select @massage = 'last name is null'
  else
		Select @massage = 'First name & last name are not null'
		return @massage

End
Go

select dbo.GetMessageToUser(16)[[Name Status]
select dbo.GetMessageToUser(20)[[Name Status]
select dbo.GetMessageToUser(21)[[Name Status]

--5.Create a function that takes an integer which represents the format of the Manager hiring date
--  and displays department name, Manager Name and hiring date with this format.

SELECT CONVERT(varchar, '2017-08-25', 101);--- example 

Go
create Function GetDataofDepMagByHiringDate(@Format int)
Returns @ManagerData Table 
          (      DeptName varchar(20) , InsName varchar(20), ManagerHiredate varchar(max))
As
   Begin
  
  Insert into @ManagerData
  Select Dep.Dept_Name,ins.Ins_Name, Convert(varchar(max) , Dep.Manager_hiredate , @Format)
      From Department Dep join Instructor ins
      on Dep.Dept_Manager=ins.Ins_Id 
     Return

  End
GO
Select * From GetDataofDepMagByHiringDate(101)-- US Date
Select * From GetDataofDepMagByHiringDate(102)-- yyyy.mm.dd    -- US Date
Select * From GetDataofDepMagByHiringDate(5)-- dd-mm-yy
   
--6. Create multi-statement table-valued function that takes a string.
  --a.	If string='first name' returns student first name
  --b.  If string='last name' returns student last name 
  --c.	If string='full name' returns Full Name from student table 
   --  (Note: Use “ISNULL” function)


Go
create Function GetStutesNameByString(@FormatString varchar(max))
Returns @StutesName Table 
          (       StudentName varchar(max))
As
   Begin
  
  if(@FormatString ='fristname')
     insert Into @StutesName
     select isnull(St_Fname,'fristname is null')
     from student
  else if(@FormatString ='lastname')
     insert Into @StutesName
     select isnull(St_Lname,'lastname is null')
     from student
  else if(@FormatString ='Fullname')
     insert Into @StutesName
     select isnull(isnull(St_fname,'fristname is null')+' '+isnull(St_Lname,'lastname is null'),'Full Name is not found')
     from student
     Return

  End
GO
Select * From GetStutesNameByString('fristname')-- 

Select * From GetStutesNameByString('Fullname')-- 


--7.Create function that takes project number and display all employees 
--  in this project (Use My Company DB)
Use MyCompany 

Go
Create Function GetAllEmployeeInProject(@ProjectNo int)
Returns @Data Table ([Employee Name] varchar(max))
As
Begin

	Insert Into @Data
	Select Concat(Emp.Fname , ' ' , Emp.Lname) As [Full Name]
	From Employee Emp join Works_For WF
	On Emp.SSN = WF.ESSN join Project P
	On P.Pnumber = WF.Pno
	Where P.Pnumber = @ProjectNo

	return

End
Go

--Run 

Select *
From GetAllEmployeeInProject(100)