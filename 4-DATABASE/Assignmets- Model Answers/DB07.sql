/*======================================== Assignment 07 ========================================*/

/*== (Functions) ==*/

--Use ITI DB:
use ITI
--1.	Create a scalar function that takes a date and returns the Month name of that date.

-- Using Format()

Go
Create Function GetMonthNameFromDate(@Date date)
returns varchar(50)

Begin

 return Format(@date , 'MMMM')

End
Go


--Run

Select DBO.GetMonthNameFromDate(Getdate()) [Month Name]


-- Using DATENAME()
Go
Create Function GetMonthNameFromDate_2(@date date)
returns varchar(50)
Begin

return DateName(m , @date)

End
GO

-- Run

Select DBO.GetMonthNameFromDate_2(GetDate()) [Month Name]
--------------------------------------------------------------------------------------------------

--2.Create a multi-statements table-valued function that takes 2
-- integers and returns the values between them.

Go
Create Function GetValuesBetween (@Lower int , @Upper int )
returns @Numbers Table ([Values] int)

as

Begin

	While(@Lower < @upper - 1)
		Begin
			Set @Lower += 1 -- Lower = Lower + 1
			Insert into @Numbers values (@Lower)
		End

		return

End

Go



--Run
Select *
From GetValuesBetween(1 , 10)



--------------------------------------------------------------------------------------------------

--3.	 Create a table-valued function that takes Student No and returns Department Name with Student full name.
Go
Create Function GetDeptNameByStudentNumber(@StudentId int)
Returns @StudentInDepartment Table (FullName varchar(max) , DeptName varchar(20))
As

Begin
insert into @StudentInDepartment
Select  CONCAT(St_Fname , ' ' , St_Lname) , Dept_Name
From Student join Department
On Student.Dept_Id = Department.Dept_Id
Where St_Id = @StudentId

return

End

Go



--Run

Select *
From GetDeptNameByStudentNumber(9)


--------------------------------------------------------------------------------------------------
--4.	Create a scalar function that takes Student ID and returns a message to user 
	--a.	If first name and Last name are null then display 'First name & last name are null'
	--b.	If First name is null then display 'first name is null'
	--c.	If Last name is null then display 'last name is null'
	--d.	Else display 'First name & last name are not null'

Go
Create or alter Function ShowMessageBasedOnName(@StudentId int)
returns varchar(max)

Begin

	Declare @Message varchar(max) , @FName varchar(50) , @LName varchar(50)

	Select @FName = St_Fname , @LName = St_Lname
	From Student
	Where St_Id = @StudentId


	if (@FName is null) and (@LName is null)
		Select @Message = 'First name & last name are null'
	else if (@FName is null)
		Select @Message = 'First name is null'
	else if (@LName is null)
		Select @Message = 'Last name is null'
	else
		Select @Message = 'First name & last name are not null'

	return @Message


End

Go




--Run

Select DBO.ShowMessageBasedOnName(9) [Name Status] -- First Name and Last Name are not null
Select DBO.ShowMessageBasedOnName(13) [Name Status] -- Last Name is null
Select DBO.ShowMessageBasedOnName(11) [Name Status]




-- 5.Create a function that takes an integer which represents the
-- format of the Manager hiring date and displays department name,
-- Manager Name and hiring date with this format.  
Go
Create Function FormatManagersHiringDate(@Format int)
Returns @ManagerData Table (
							DeptName varchar(50),
							ManagerName varchar(50),
							HiringDate varchar(50)
						 )
As

Begin

Insert into @ManagerData
	Select I.Ins_Name , Dept_Name , Convert(varchar(max) , D.Manager_Hiredate , @Format)
	From Instructor I join Department D
	On I.Ins_Id = D.Dept_Manager

Return

End

Go




--Run

Select *
From FormatManagersHiringDate(131) -- التاريخ الهجري

Select *
From FormatManagersHiringDate(110) -- mm-dd-yyyy

Select *
From FormatManagersHiringDate(105) -- dd-mm-yyyy

Select *
From FormatManagersHiringDate(5) -- dd-mm-yy



--------------------------------------------------------------------------------------------------


--6.Create multi-statement table-valued function that takes a string
	--a.	If string='first name' returns student first name
	--b.	If string='last name' returns student last name 
	--c.	If string='full name' returns Full Name from student table 
	--      (Note: Use “ISNULL” function)

Go
Create Function GetStudentName (@FormatString varchar(max))
returns @StudentName Table (StudentName varchar(max))

As
Begin
	If(@FormatString = 'First Name')
		Insert into @StudentName
		Select ISNULL(St_Fname , 'First Name is not found')
		From Student
	else if (@FormatString = 'Last Name')
		Insert into @StudentName
			Select ISNULL(St_Lname , 'Last Name is not found')
			From Student
	else if (@FormatString = 'Full Name')
		Insert into @StudentName
			Select ISNULL(ISNULL(St_Fname , 'First Name is not found') + ' ' + ISNULL(St_Lname , 'Last Name is not found') , 'Full Name is not found')
			From Student

		return

End
Go

-- Run

Select * from GetStudentName('First Name')
Select * from GetStudentName('Last Name')






--------------------------------------------------------------------------------------------------

--7.Create function that takes project number and display
-- all employees in this project (Use MyCompany DB)
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


 

