﻿/*=========================== Part 01 (Views) ===========================*/

--Use ITI DB:
use ITI
--1. Create a view that displays the student's full name, course name if the student has a grade more than 50.
Go
Create View vw_StudentsWithGradeAbove50
As
	Select CONCAT(S.st_Fname , ' ' , S.St_Lname) As [Full Name] , C.Crs_Name As [Course Name] , SC.Grade
	From Student S join Stud_Course SC
	On S.St_Id = SC.St_Id join Course C
	On C.Crs_Id = Sc.Crs_Id
	Where Sc.Grade > 50

Go

--Run

Select *
From vw_StudentsWithGradeAbove50


----------------------------------------------------------------------------------------------------------------------------------------


--2.	 Create an Encrypted view that displays manager names and the topics they teach. 

Go
Create View vw_ManagersWithTopics
With Encryption
As
Select Distinct Ins.Ins_Name , T.Top_Name
From Instructor Ins join Department Dept
On Ins.Ins_Id = Dept.Dept_Manager join Ins_Course IC
On IC.Ins_Id = IC.Ins_Id join Course C
On IC.Crs_Id = C.Crs_Id join Topic T
On C.Top_Id = T.Top_Id

Go


--Run

Select *
From vw_ManagersWithTopics

----------------------------------------------------------------------------------------------------------------------------------------


--3.Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department “use Schema binding” and describe 
-- what is the meaning of Schema Binding
Go
Create view vw_SDJavaInstructors
With SchemaBinding
As
	Select  Ins.Ins_Name , Dept.Dept_Name
	From dbo.Instructor Ins join dbo.Department Dept
	On Ins.Dept_Id = Dept.Dept_Id
	Where Dept.Dept_Name in ('SD' , 'Java')
Go

--Run

Select *
from  vw_SDJavaInstructors


----------------------------------------------------------------------------------------------------------------------------------------



--4. Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;

Go
Create View V1
As

	Select *
	From Student
	Where St_Address in ('Alex' , 'Cairo')
	With Check option
GO


--Run

Select *
From V1

Update V1 set st_address='tanta'
Where st_address='alex'


----------------------------------------------------------------------------------------------------------------------------------------


--5.	Create a view that will display the project name and the number of employees working on it. (Use Company DB)
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


----------------------------------------------------------------------------------------------------------------------------------------

--use IKEA_Company_DB:

use [IKEA_Company]
--1.	Create a view named   “v_clerk” that will display employee Number ,project Number,
-- the date of hiring of all the jobs of the type 'Clerk'.

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

----------------------------------------------------------------------------------------------------------------------------------------


--2.	 Create view named  “v_without_budget” that will display all the projects data without budget
Go
Create View v_without_budget
As
	Select ProjectNo , ProjectName
	From [HR].[Project]
Go

--Run

Select *
From v_without_budget

----------------------------------------------------------------------------------------------------------------------------------------


--3.	Create view named  “v_count “ that will display the project name and the Number of jobs in it

Go
Create View v_Count
As

	Select P.ProjectName , Count(W.job) As [Number of jobs]
	From [HR].[Project] P join Works_on W
	On P.ProjectNo = W.ProjectNo
	Group by P.ProjectName
Go

--Run

Select *
From v_Count

----------------------------------------------------------------------------------------------------------------------------------------


--4.	 Create view named ” v_project_p2” that will display the emp# s for the project# ‘p2’ . (use the previously created view  “v_clerk”)

Go
Create View v_project_p2
As
	Select EmpNo [Employee Number]
	From v_clerk
	Where ProjectNo = 2
GO


--Run

Select *
From v_project_p2


-----------------------------------------------------------------------------------------------------

--5.	modify the view named  “v_without_budget”  to display all DATA in project p1 and p2.

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

-----------------------------------------------------------------------------------------------------

--6.	Delete the views  “v_ clerk” and “v_count”
Drop View v_clerk , v_Count




-----------------------------------------------------------------------------------------------------

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

-----------------------------------------------------------------------------------------------------

--8.	Display the employee  lastname that contains letter “J” (Use the previous view created in Q#7)


Select EmpLname
From vw_employeeInDepartment 
Where EmpLname like '%J%'


-----------------------------------------------------------------------------------------------------

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


-----------------------------------------------------------------------------------------------------


--10) using the previous view try enter new department data where dept# is (d4) and dept name is ‘Development’

Insert Into v_dept
Values (4 , 'Development')

Select *
From v_dept


-----------------------------------------------------------------------------------------------------

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
Set Enter_Date = '01-15-2006'
Where [Employee Number] = 22222

----------------------------------------------------------------------------------------------------------------------------------------

﻿/*=========================== Part 02 (Stored Procedure) ===========================*/

Use ITI
--1.	Create a stored procedure to show the number of students per department.[use ITI DB] 

Go
Create Procedure SP_GetStudentsInDeparmtent
As
	Begin
	Select Dept.Dept_Name , Count(Stud.St_Id) [Number of students]
	From Student Stud join Department Dept
	On Stud.Dept_Id = Dept.Dept_Id
	Group by Dept.Dept_Name
	End;
Go


--Run
Execute SP_GetStudentsInDeparmtent
----------------------------------------------------------------------------------------------------------------------------------------

Use [MyCompany]

--2.Create a stored procedure that will check for the Number of employees in the project 100
-- if they are more than 3 print message to the user “'The number of employees in the project 100 is 3 or more'”
-- if they are less display a message to the user “'The following employees work for the project 100'” 
-- in addition to the first name and last name of each one. [MyCompany DB] 

GO
Create Procedure SP_CheckEmployeesNumber
AS
	Begin
		Declare @EmployeesNumber int

		Select  @EmployeesNumber =  Count(ESSN)
		From Works_For
		Where Pno = 100

		If (@EmployeesNumber > 3)
			Select 'The number of employees in the project 100 is 3 or more'
		Else
			Select 'The following employees work for the project 100'

			Select CONCAT (Fname , ' ' , Lname) [Full Name] 
			From Employee join Works_for
			On Employee.SSN = Works_for.ESSn
			Where Pno = 100
			


	End
Go


--Run

Execute SP_CheckEmployeesNumber

-----------------------------------------------------------------------------------------------------

--3.Create a stored procedure that will be used in case an old employee has left the project and a new one becomes his replacement. The procedure should take 3 parameters
-- (old Emp. number, new Emp. number and the project number) and it will be used to update works_on table. [MyCompany DB]
Go
Create Procedure SP_UpdateEmployeeInProject @OldEmp# int , @NewEmp# int , @Pnum int
As
	Begin
		Update Works_for
		Set ESSn = @NewEmp#
		Where ESSn = @OldEmp# and Pno = @Pnum
	End
Go

--Run

Execute SP_UpdateEmployeeInProject 223344 , 669955 , 100
﻿/*===================================================== Part 03 (StoredProcedure) ===================================================================*/

--1.	Create a stored procedure that calculates the sum of a given range of numbers


Go
Create or Alter Procedure SP_CalculateSum @StartNumber int , @EndNumber int , @Sum int Output
As
	Begin
		Set @Sum = 0

		While @StartNumber <= @EndNumber
			Begin
				Set @Sum += @StartNumber
				Set @StartNumber+=1
			End
	End
Go
-- Run

Declare @Result int
Execute SP_CalculateSum 1 , 10 , @Result Output

Select @Result As [Summation]

----------------------------------------------------------------------------------------------------------------------------------------

--2.Create a stored procedure that calculates the area of a circle given its radius

Go
Create Procedure SP_CalculateArea @radius float , @Area float output
As
	Begin
		Set @Area = PI() * POWER(@radius , 2)
	End
Go



--Run

Declare @Result Float
Execute SP_CalculateArea 5 , @Result output
Select @Result As [Circle Area]

----------------------------------------------------------------------------------------------------------------------------------------

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

----------------------------------------------------------------------------------------------------------------------------------------

--4.	Create a stored procedure that determines the maximum, minimum, and average of a given set of numbers
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


----------------------------------------------------------------------------------------------------------------------------------------
