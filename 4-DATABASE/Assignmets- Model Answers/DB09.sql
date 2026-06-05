--Use ITI DB
use ITI
--1.	Create a trigger to prevent anyone from inserting a new record in the Department table 
-- ( Display a message for user to tell him that he can’t insert a new record in that table )

Go
Create Trigger T_PreventInsertInDepartment
On Department
Instead Of Insert 
AS
	Print 'You can’t insert a new record in that table now '
Go


--Test	

Insert into Department (Dept_Id , Dept_Name , Dept_Desc)
Values (2 , 'Accounting' , '11') 

----------------------------------------------------------------------------------------------------------------------------------------



--2.	Create a table named “StudentAudit”. Its Columns are (Server User Name , Date, Note) 

--Server User Name   --	Date 	Note

Create Table StudentAudit 
(
[Server User Name] Varchar(max),
[Date] Date,
Note varchar(max)
)
		




----------------------------------------------------------------------------------------------------------------------------------------

--3.	Create a trigger on student table after insert to add Row in StudentAudit table 
		--•	 The Name of User Has Inserted the New Student  
		--•	Date
		--•	Note that will be like ([username] Insert New Row with Key = [Student Id] in table [table name]

Go
Create Trigger T_AfterInsert
On Student
After Insert
As
	Declare @Note varchar(max) , @Stu_Id int

	Select @Stu_Id = St_Id From inserted

	Select @Note = CONCAT_Ws( ' ' ,suser_name() , 'Insert New Row with Key = ' , @Stu_Id ,'in table student')
	

	Insert into StudentAudit
	Values (SUSER_NAME() , GETDATE() , @Note)
Go



--Test

Insert into Student (St_Id , St_Fname)
Values(2024 , 'Ahmed')

Select *
From StudentAudit

----------------------------------------------------------------------------------------------------------------------------------------



--4.	Create a trigger on student table instead of delete to add Row in StudentAudit table 
		--○	 The Name of User Has Inserted the New Student
		--○	Date
		--○	Note that will be like “try to delete Row with id = [Student Id]” 

Go
Create or Alter Trigger T_PreventStudentDeletion
On Student
Instead of delete
As
	
	Declare @Note varchar(max) , @St_Id int

	Select @St_Id = St_Id from deleted

	Select @Note = CONCAT_WS(' ' , SUSER_NAME() , 'try to delete Row with id = ' , @St_Id)


	Insert into StudentAudit
	Values (SUSER_NAME() , GETDATE() , @Note)

Go


--Test

Delete From Student
Where St_Id = 1

Select *
From StudentAudit


----------------------------------------------------------------------------------------------------------------------------------------


/*============================================= Part 02 ===========================================================*/

--Use MyCompany DB:
use MyCompany
--1.	Create a trigger that prevents the insertion Process for Employee table in March.

Go
Create Trigger T_PreventInsertEmployee
On Employee
Instead of Insert
As
	Begin
		IF Format(GetDate() , 'MMMM') = 'March'
			Print 'You can''t insert a record in march'
		Else
			Insert into Employee
			Select * From Inserted

	End
Go

--Test

Insert Into Employee (SSN , Lname)
Values (100 , 'Ali')

----------------------------------------------------------------------------------------------------------------------------------------


--Use IKEA_Company:
use [IKEA_Company]

--2.	Create an Audit table with the following structure 

--ProjectNo		UserName 	ModifiedDate 	Budget_Old 		Budget_New 
--p2			Dbo			2008-01-31			95000		200000

--This table will be used to audit the update trials on the Budget column (Project table, Company DB)
--If a user updated the budget column then the project number, username that made that update,  the date of the modification and the value of the old and the new budget will be inserted into the Audit table
--(Note: This process will take place only if the user updated the budget column)

Create Table [Audit] (
ProjectNo int,
UserName varchar(50),
ModifiedDate Date,
Budget_Old int,
Budget_New int
)



--Test

Go
Create Trigger HR.UpdateBudget
On HR.Project
After Update
As

	If Update(Budget)
		Begin
			Declare @PNum int , @OldBudget int , @NewBudget int

			Select @OldBudget = Budget from deleted
			Select @NewBudget = Budget From inserted
			Select @PNum = ProjectNo From inserted

			Insert Into [Audit]
			Values (@PNum , USER_NAME() , GetDate() , @OldBudget , @NewBudget)
		End
Go

--Test

Update HR.Project
Set Budget = 1000
Where ProjectNo = 1

Update HR.Project
Set ProjectName = 'Test'
Where ProjectNo = 1


Select *
From [Audit]