--=================================================================
---------------------------- Views --------------------------------
--=================================================================
-- 1. Basic User-Defined Views [Standard View]
-------------------------------------------------------------------
-- Students In Cairo
-------------------------------------------------------------------
use  ITI

Create View VCairoStudents
As
    Select St_Id , St_Fname , St_Address
	From Student
	Where St_Address = 'Cairo'

Select * From VCairoStudents

-------------------------------------------------------------------
-- Students In Alex
-------------------------------------------------------------------
Create Or ALTER View VAlexStudents
As
    Select St_Id , St_Fname , St_Address
	From Student
	Where St_Address = 'Alex'

Alter View VAlexStudents
As
    Select St_Id , St_Fname , St_Address
	From Student
	Where St_Address = 'Alex'
	Order by St_Fname -- Invalid 
-- The ORDER BY clause is invalid in views unless TOP Is  also specified.

Alter View VAlexStudents
As
    Select TOP(2) St_Id , St_Fname , St_Address
	From Student
	Where St_Address = 'Alex'
	Order by St_Fname

Select St_Id , St_fname From VAlexStudents

-------------------------------------------------------------------
-- Students And Their Departments
-------------------------------------------------------------------
Create View VStudentsInDepartment
As 
  Select S.St_Id , S.St_Fname , D.Dept_Id , D.Dept_Name
  From Student S inner join Department D
  On D.Dept_Id = S.Dept_Id 


Select * from VStudentsInDepartment
Where Dept_Id = 10


-------------------------------------------------------------------
-- Transfer View To Another Schema
-------------------------------------------------------------------
GO
Create Schema HR
GO
Alter Schema HR 
Transfer VStudentsInDepartment

Select * from HR.VStudentsInDepartment
Where Dept_Id = 10


-------------------------------------------------------------------
-- Hide Source Code Of View 
-------------------------------------------------------------------

Sp_HelpText 'HR.VStudentsInDepartment'


Create Or Alter View HR.VStudentsInDepartment
With Encryption
As 
  Select S.St_Id , S.St_Fname , D.Dept_Id , D.Dept_Name
  From Student S inner join Department D
  On D.Dept_Id = S.Dept_Id

Sp_HelpText 'HR.VStudentsInDepartment'
-- The text for object 'HR.VStudentsInDepartment' is encrypted.


-------------------------------------------------------------------
-- Hide Meta Data Of View 
-------------------------------------------------------------------

Create Or Alter View HR.VStudentsInDepartment(StudentId , StudentName , DepartmentId , DepartmentName)
With Encryption
As 
  Select S.St_Id , S.St_Fname , D.Dept_Id , D.Dept_Name
  From Student S inner join Department D
  On D.Dept_Id = S.Dept_Id

  Select * From HR.VStudentsInDepartment


-------------------------------------------------------------------
-- Student , Course And Their Grades 
-------------------------------------------------------------------

Create OR Alter View VStudentsGrades(StudentName , CourseName , StudentGrade)
With Encryption 
As
    Select St_Fname , Crs_Name , Grade
	From Student std , Stud_Course StdCrs , Course Crs
	Where Std.St_Id = StdCrs.St_Id And Crs.Crs_Id = StdCrs.Crs_Id

Select * from VStudentsGrades
Where Dept_Id = 10  -- Invalid 


-------------------------------------------------------------------
-- 2. Partitioned Views
-------------------------------------------------------------------
GO
Create OR ALter View VCairoAlexStudents
With Encryption
As
   Select St_Id , St_Fname , St_Address From Student Where St_Address = 'Cairo'
   Union All 
   Select St_Id , St_Fname , St_Address From Student Where St_Address = 'Alex'
GO
Create Or Alter  View CairoAlexStudents
With Encryption
As
   Select * From VCairoStudents -- view1
   Union All 
   Select * From VAlexStudents  -- view2
GO

Select * From CairoAlexStudents

--=================================================================
----------------------- Views With DMl ----------------------------
--=================================================================
-- Using Insert , Update and Delete Through View
-------------------------------------------------------------------
-- Insert 
Insert into VCairoStudents
Values(22 ,'Mohamed' ,'Cairo') -- table Student and view

Create Or Alter View StudentsAge 
As 
 Select St_Fname , St_Age
 From Student

 Insert into StudentsAge 
 Values('ali' , 25) -- Invalid

 Insert into HR.VStudentsInDepartment
 Values(30,'Mona', 10 , 'SD')
 -- not updatable because the modification affects multiple base tables.

 Insert into HR.VStudentsInDepartment(StudentId , StudentName)
 Values(30,'Mona') -- Valid
 
 Insert into HR.VStudentsInDepartment(DepartmentId , DepartmentName)
 Values(80,'HR') -- Valid


 -- Update 
Select * From VCairoStudents

 Update VCairoStudents
 set St_Fname ='Omar'
 Where St_Id = 2


 Select * From HR.VStudentsInDepartment

 Update HR.VStudentsInDepartment
 Set StudentName = 'salma' 
 Where StudentId = 5


  Update HR.VStudentsInDepartment
 Set StudentName = 'Samy' , DepartmentName = 'HR'
 Where StudentId = 5
 -- not updatable because the modification affects multiple base tables.


-- Delete 

Select * From VCairoStudents

Delete From VCairoStudents
Where St_Id = 20


 Select * From HR.VStudentsInDepartment

Delete From HR.VStudentsInDepartment
Where StudentId = 1
-- not updatable because the modification affects multiple base tables.



--=================================================================
-------------------- Views With Check Option ----------------------
--=================================================================
Insert into VCairoStudents
Values(40 ,'Aliaa' , 'Alex')

Update VCairoStudents
Set St_Fname = 'Samar'
Where st_Id = 40             -- مش موجودة في الفيو لكن موجودة في الجدول 

Delete From VCairoStudents
Where St_Id = 40

Create Or alter  View VCairoStudents
With Encryption
As
    Select St_Id , St_Fname , St_Address
	From Student
	Where St_Address = 'Cairo'  
	With Check Option

Insert into VCairoStudents
Values(50 ,'Aliaa' , 'Alex') -- Invalid

--=================================================================
------------------------ Stored procedures ------------------------
--=================================================================

-- Get Stduent by Id 
--------------------------------------------------------------------
Create Proc SPGetStudentById (@Stdid int)
As
   Select *
   From Student
   Where St_Id = @Stdid


 SPGetStudentById 1
 Execute  SPGetStudentById 1
 Exec  SPGetStudentById 1

 Declare @StdId int = 5
 Exec  SPGetStudentById @Stdid
 -- For Display Only 


--------------------------------------------------------------------
-- Alter Stored procedure
--------------------------------------------------------------------
Create OR Alter Proc SPGetStudentById @Stdid int
With Encryption
As
   SET NOCOUNT on -- Default --     off -> disply Messages (n row affected)
   -- Controls whether a message that shows the number of rows affected by a Transact-SQL statement or stored procedure is returned after the result set
   Select St_Id [id] , St_Fname [Name] , St_Age [Age]
   From Student
   Where St_Id = @Stdid


 Exec  SPGetStudentById 1

--------------------------------------------------------------------
-- Transfer Stored procedure To Another Schema
--------------------------------------------------------------------

Alter Schema HR
Transfer SPGetStudentById

 Exec HR.SPGetStudentById 1
 

--=================================================================
---------------------- Insert Based On Execute --------------------
--=================================================================

Create Proc SpGetStudentByAddress @StdAddress Varchar(20)
With Encryption 
as
   Select St_Id [id], St_Fname [Name] , St_Address [Address]
   From Student
   Where St_Address = @StdAddress

Exec SpGetStudentByAddress 'Alex'

Create Table StudentsWithAddress
(
StdId int Primary key ,
StdName Varchar(Max),
StdAddress Varchar(Max)
)

Insert Into StudentsWithAddress
Exec SpGetStudentByAddress 'Alex'


--=================================================================
-------------------- Stored procedure Examples --------------------
--=================================================================
-- Error Handling 
-------------------------------------------------------------------
Delete From Topic 
Where Top_Id = 1
-- The DELETE statement conflicted with the REFERENCE constraint "FK_Course_Topic". 
-- The conflict occurred in database "ITI", table "dbo.Course", column 'Top_Id'.

Create Or Alter Proc SpDeleteTopicbyId @TopId int 
With Encryption 
as
  Set NOCOUNT ON;
   Begin Try 
      Delete From Topic 
      Where Top_Id = 1
   End Try 
   Begin Catch
   -- Print ERROR_MESSAGE()
   -- Print ERROR_NUMBER()
   /* Select */ 
   Print 'You Can not Delete This Topic'
   End Catch

SpDeleteTopicbyId 1 


-------------------------------------------------------------------
-- Input Parameter  
-------------------------------------------------------------------

Create Or Alter Proc SPSubtarctData @X int = 4 , @Y varchar(10) = '1'
With Encryption 
As
    Select @X - @Y


SPSubtarctData 4 , '2' -- Passing in Order 
SPSubtarctData @Y = '2' , @X = 4 -- Passing By Name 
SPSubtarctData   -- Using Default Values 
SPSubtarctData 5
SPSubtarctData @Y = '3'

-------------------------------------------------------------------
-- Output Parameter  
-------------------------------------------------------------------
-- Return Of Stored Procedure 

Create Proc SpGetStdNameAndAgebyId @id int , @Name varchar(20) Output, @Age int output
With Encryption 
as
   Select @Name = St_Fname , @Age = St_Age
   From Student
   Where St_Id = @id


   Declare @StdAge int , @StdName Varchar(20)
   Exec SpGetStdNameAndAgebyId 1 , @StdName Output , @StdAge output
   Select  @StdName [name] ,@StdAge [Age] 

-------------------------------------------------------------------
-- Input Output Parameter  
-------------------------------------------------------------------

Create Proc SpGetStdNameAndAgebyIdV02 @Data int output, @Name varchar(20) Output
With Encryption 
as
   Select @Name = St_Fname , @Data = St_Age
   From Student
   Where St_Id = @Data


   Declare @Data int = 1, @StdName Varchar(20)
   Exec SpGetStdNameAndAgebyIdV02 @Data output, @StdName Output 
   Select  @StdName [Name], @Data [Age]


----------------------------------------------------------------
---------------------------Assignment 08----------------------
 -----Part 01 (Views)
  -- Note : # means number and for example d2 means department which has id or number 2
  -- Use ITI DB
  use ITI

 -- Create a view that displays the student's full name,
 -- course name if the student has a grade more than 50.

 Create  or alter View VFullNameStudents
As
    
    Select CONCAT_WS(' ', Stu.St_Fname ,Stu.St_Lname) [FullName], Crs.Crs_Name [CourseName],Crs.Crs_Id
	From Student Stu join Stud_Course StuC
	on Stu.St_Id=Stuc.St_Id join Course Crs
	on Crs.Crs_Id=StuC.Crs_Id
	Where  Grade > 50

--Run
Select * From VFullNameStudents

--Create an Encrypted view that displays manager names and the topics they teach.
select Ins_Name,Dept_Name
	From Instructor Ins join Department Dep
	on Ins.Ins_Id=Dep.Dept_Manager
Go
Create   View VMangerNameAndTobic
with encryption
As
    
    Select distinct Ins_Name , Top_Name ,Dep.Dept_Id
	From Instructor Ins join Department Dep
	on Ins.Ins_Id=Dep.Dept_Manager join Ins_Course InC
	on Ins.Ins_Id=InC.Ins_Id join Course Crs
	on Inc.Crs_Id=Crs.Crs_Id join Topic T
	on Crs.Top_Id=T.Top_Id
Go

--run
select * from VMangerNameAndTobic

--3.Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department “use Schema binding” and describe 
-- what is the meaning of Schema Binding
--  with Schemabinding  هي عملية "قفل" أو "ربط" الكود الذي تكتبه بالجداول الأصلية التي يعتمد عليها، بحيث تمنع أي شخص من تعديل أو حذف الجداول الأصلية
Go	
Create or alter   View vw_SDJavaInstructors
with Schemabinding  
As
    
    Select distinct Ins_Name  ,Dep.Dept_Name
	From dbo.Instructor Ins join dbo.Department Dep ---- لاحظ استخدام dbo.
	on Ins.Dept_Id=Dep.Dept_Id
	where Dep.Dept_Name in ('SD','Java')
Go

select * from vw_SDJavaInstructors

----4. Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;
Go	
Create    View  V1
As
    
    Select *
	from Student
	where St_Address in ('Alex','Cairo')
	With Check option

Go

--Run

Select *
From V1

Update V1 set st_address='tanta'
Where st_address='alex'
 
--5. Create a view that will display the project name and the number of employees working on it. (Use Company DB)
use MyCompany


Go
Create View vw_displayProject
As
	
	Select Project.Pname , Count(Works_for.ESSN) As [Employees number ]
	From Project join Works_for
	On Project.Pnumber = Works_for.Pno
	Group By Project.Pname
Go



--Run

Select *
From vw_displayProject
---------------------------------------------------------------------------
use IKEA_Company
ALTER AUTHORIZATION ON DATABASE::[IKEA_Company] TO [sa];

--1.Create a view named “v_clerk” that will display employee Number, project Number, the date of hiring of all the jobs of the type 'Clerk'.

Go
Create View v_clerk 
As
Select EmpNo , ProjectNo , Enter_Date
From Works_on
Where Job = 'Clerk'
Go

--Run

Select *
From v_clerk

----2.Create view named  “v_without_budget” that will display all the projects data without budget
Go
Create View v_without_budget 
As
Select  ProjectNo , ProjectName
From Hr.Project

Go

--Run

Select *
From v_without_budget

--3.Create view named  “v_count “ that will display the project name and the Number of jobs in it

Go
Create View v_count 
As
     Select  p.ProjectName,COUNT(W.job)[ num of jobs]
	 From [HR].[Project] P join Works_on W
	 On P.ProjectNo = W.ProjectNo
	 GROUP by p.ProjectName
Go

--Run

Select *
From v_count

--4.Create view named ” v_project_p2” that will display the emp# s for the project# ‘p2’ . (use the previously created view  “v_clerk”)

Go
create or alter view v_project_p2
As
     select EmpNo[Employee  Num]
	 from v_clerk
	 where ProjectNo=2
Go

--Run

Select *
From v_project_p2

--5	modify the view named  “v_without_budget”  to display all DATA in project p1 and p2.
Go
Create or Alter View v_without_budget
As
	Select ProjectNo , ProjectName
	From [HR].[Project]
	Where ProjectNo in (1 , 2)
Go

-- Run
Select *
From v_without_budget

--6.Delete the views  “v_ clerk” and “v_count”
Drop View v_clerk , v_Count

--7.	Create view that will display the emp# and emp last name who works on deptNumber is ‘d2’

Go
Create view vw_employeeInDepartment
As
	Select EmpNo , EmpLname
	From [HR].[Employee]
	Where DeptNo = 2
Go


--Run

Select *
From vw_employeeInDepartment
--8.	Display the employee  lastname that contains letter “J” (Use the previous view created in Q#7)


Select EmpLname
From vw_employeeInDepartment 
Where EmpLname like '%J%'

--9.	Create view named “v_dept” that will display the department# and department name
Go
Create or Alter View v_dept 
As
	Select DeptNo [Department Number] , DeptName [Department Name ]
	From Department
Go
--Run

Select *
From v_dept

----10) using the previous view try enter new department data where dept# is (d4) and dept name is ‘Development’

Insert Into v_dept
Values (5 , 'Development')

Select *
From v_dept

--11) Create view name (v_2006_check) that will display employee Number, 
--    the project Number where he works and the date of joining the project 
--    which must be from the first of January and the last of December 2006.
--    this view will be used to insert data so make sure that the coming new data must match the condition
Go
Create View v_2006_check
As
	Select EmpNo [Employee Number] , ProjectNo [Project Number] , Enter_Date
	From Works_on
	Where Enter_Date between '01-01-2006' and '12-31-2006'
	With Check option

Go

--Run
Select *
From v_2006_check


Update v_2006_check
Set Enter_Date = '01-15-2007'
Where [Employee Number] = 22222

---------------------------------Part 02------------------------------------------------------
-------------------------------- stored procedure ------------------------------------

--1.Create a stored procedure to show the number of students per department.[use ITI DB] 
use ITI
Go
create proc SpGetNumStudentPerDep
as
    Select Dept.Dept_Name , Count(Stud.St_Id) [Number of students]
	From Student Stud join Department Dept
	On Stud.Dept_Id = Dept.Dept_Id
	Group by Dept.Dept_Name

Go

--Run
SpGetNumStudentPerDep

--2.Create a stored procedure that will check for the Number of employees in the project 100
-- if they are more than 3 print message to the user “'The number of employees in the project 100 is 3 or more'”
-- if they are less display a message to the user “'The following employees work for the project 100'” 
-- in addition to the first name and last name of each one. [MyCompany DB] 
use MyCompany
Go
create or alter proc Sp_GetNumEmpPerPrj 
as
   Begin
    declare @EmployeesNumber int
    Select @EmployeesNumber=count(ESSn)
	From Works_for
	where Pno=100

  if(@EmployeesNumber > 3)
     select 'The number of employees in the project 100 is 3 or more'
  Else
	 Select 'The following employees work for the project 100'

	 Select CONCAT (Fname , ' ' , Lname) [Full Name] 
			From Employee join Works_for
			On Employee.SSN = Works_for.ESSn
			Where Pno = 100
			
   End
Go
Sp_GetNumEmpPerPrj

--3.Create a stored procedure that will be used in case an old employee has left the project 
--  and a new one becomes his replacement. The procedure should take 3 parameters 
--(old Emp. number, new Emp. number and the project number) and it will be used to update works_on table. [MyCompany DB]

Go
create proc Sp_GetOldEmployee @OldEmNum int , @newEmNum int ,@projectNum int 
as
   Begin
    update Works_for
	set ESSn=@newEmNum
	where Pno=@projectNum and ESSn=@OldEmNum
			
   End
Go

execute Sp_GetOldEmployee 223344 , 669955 , 100


﻿/*===================================================== Part 03 (StoredProcedure) =================================================*/
--1.Create a stored procedure that calculates the sum of a given range of numbers

Go
CREATE PROCEDURE sp_CalculateRangeSum
    @StartNum INT,
    @EndNum INT
AS
BEGIN
    DECLARE @TotalSum BIGINT = 0;
    DECLARE @Current INT = @StartNum;

    WHILE @Current <= @EndNum
    BEGIN
        SET @TotalSum = @TotalSum + @Current;
        SET @Current = @Current + 1;
    END

    -- Return the result as a result set
    SELECT @TotalSum AS FinalSum;
END;
GO

-- To run it:
EXEC sp_CalculateRangeSum @StartNum = 1, @EndNum = 10;

--2.Create a stored procedure that calculates the area of a circle given its radius

Go
CREATE PROCEDURE sp_CalculateCircleArea
    @Radius FLOAT
AS
BEGIN
    DECLARE @Area FLOAT;
    
    -- Formula: PI * Radius squared
    SET @Area = PI() * POWER(@Radius, 2);
    
    SELECT 
        @Radius AS InputRadius, 
        @Area AS CalculatedArea;
END;
GO

-- How to execute:
EXEC sp_CalculateCircleArea @Radius = 5;

--3.Create a stored procedure that calculates the age category based on a person's age
--( Note: IF Age < 18 then Category is Child and if  Age >= 18 AND Age < 60
-- then Category is Adult otherwise  Category is Senior)

GO
Create Procedure SP_CalcAgeCategory @Age int , @Category varchar(max) output
As
	Begin

	IF @Age < 18
		Set @Category = 'Child'
	Else IF @Age >= 18 and @Age < 60
		Set @Category = 'Adult'
	Else
		Set @Category = 'Senior'

	End

Go

--Run

Declare @Category varchar(max)
Execute SP_CalcAgeCategory 70 , @Category output
Select @Category As [Cateogry]

--4.Create a stored procedure that determines the maximum, minimum, and average of a given set of numbers
-- ( Note : set of numbers as Numbers = '5, 10, 15, 20, 25')

Go
Create Procedure SP_Max_Min_Avg @Numbers varchar(max) , @MaxNumber int output,
								@MinNumber int output , @Average Float output

As
	Begin
		Create Table #TempTable (value int )

		Insert Into #TempTable (Value)
		Select Value 
		From string_split(@Numbers , ',')

		Select @MaxNumber = Max(Value) , @MinNumber = Min(Value) , @Average = Avg(Value)
		From #TempTable
		
		Drop Table #TempTable
	End
Go




--Run

Declare @MaxValue int , @MinValue int , @Average Float
Execute SP_Max_Min_Avg '5, 10, 15, 20, 25' , @MaxValue output , @MinValue output , @Average output
Select @MaxValue [Maximum]  , @MinValue [Minimum] , @Average [Average]