--===================================================================================
----------------------------------- Triggers ----------------------------------------
--===================================================================================
---------------------------------- DML Triggers -------------------------------------
-------------------------------------------------------------------------------------
-- Triggers Fire When event Occurred On Table | View 
-- Event (Not Select Or Truncate - NOT LOGGED In LDF)
-- 1. Insert 
-- 2. Update 
-- 3. Delete 
-------------------------------------------------------------------------------------
-- Welcome Trigger In Table Student 
-------------------------------------------------------------------------------------
Create Or Alter Trigger SayWelcome
On Student 
With Encryption 
After Insert
As
    Print 'Welcome To Route Academy'
Go 
Insert into Student(St_Id , St_Fname , St_Address , St_Age)
Values(24 , 'Aliaa' , 'Cairo' , 30)

-------------------------------------------------------------------------------------
-- Transfer Table To Another Schema
-------------------------------------------------------------------------------------
Alter Schema HR 
Transfer Student
Go

Alter Trigger SayWelcome -- There is already an object named 'SayWelcome' in the database.
On HR.Student 
With Encryption 
After Insert
As
    Print 'Welcome To Route Academy' 
Go
Alter Trigger HR.SayWelcome 
On HR.Student 
With Encryption 
After Insert
As
    Print 'Welcome To Route Academy' 
Go

-------------------------------------------------------------------------------------
-- When An Update On Table Student Occurred Return Time Of Modification And User 
-------------------------------------------------------------------------------------

Create Trigger NotifyOnUpdateStudent
On Student 
With Encryption 
After Update 
As 
   Select SUSER_NAME() [Updatedby] , GETDATE() [UpdatedOn]

   
Update Student
Set St_Fname = 'Shaimaa'
Where St_Id = 20

Go 

-------------------------------------------------------------------------------------
-- Prevent Delete From Table Student  
-------------------------------------------------------------------------------------
Create Trigger DisableDeleteOnStudent
On Student 
With Encryption 
Instead Of Delete 
As
   Print 'You Can''t Delete From This Table' 

Delete From Student
Where St_Id = 20
Go 

Create Or Alter Trigger DisableDeleteOnStudent
On Student 
With Encryption 
For Delete 
As
  Rollback Transaction  -- يحذف ثم يعيدة ثانية
  Print 'You Can''t Delete From This Table' 

Go
Create Or Alter Trigger DisableDeleteOnStudent
On Student 
With Encryption 
Instead Of Delete 
As
   RaisError( 'You Can''t Delete From This Table' , 19 , 1 ) -- RaisError تظهر الايرور كانه خطير حسب حالة

Delete From Student
Where St_Id = 20

-------------------------------------------------------------------------------------
-- Prevent Insert , Update , Delete From Department   
-------------------------------------------------------------------------------------
Go 
Create Trigger DisableDMLOnDepartmentTable
On Department 
With Encryption 
Instead Of Delete , Insert , Update 
As
   Print 'You Can''t Do Any DML Commands In Department Table'


 Delete From Department
 Where Dept_Id = 10
 
 Update Department
 Set Dept_Name = 'HR'
 Where Dept_Id = 10


-------------------------------------------------------------------------------------
-- Drop Or Disable Trigger 
-------------------------------------------------------------------------------------
 DROP TRIGGER DisableDMLOnDepartmentTable

IF OBJECT_ID ('DisableDMLOnDepartmentTable') IS NOT NULL  
   DROP TRIGGER DisableDMLOnDepartmentTable 

Alter Table Department
Disable Trigger DisableDMLOnDepartmentTable

DISABLE TRIGGER DisableDMLOnDepartmentTable 
ON Department 

Alter Table Department
Enable Trigger DisableDMLOnDepartmentTable

-------------------------------------------------------------------------------------
------------------------ Inserted And Deleted Tables  -------------------------------
-------------------------------------------------------------------------------------
-- Inserted And Deleted Tables ->  الاساسيtable نفس (trigger)تنشأ لحظياعندانشاءال
-- Insert
---> Inserted -> New Data
---> Deleted  -> Nothing

-- Delete
---> Inserted -> Nothing
---> Deleted  -> Delated Values

-- Update
---> Inserted -> New Data
---> Deleted  -> Old Data

-- Audit Update On Table Course
-------------------------------------------------------------------------------------
Go
Create Or Alter Trigger AuditOnCourses
On Course 
With Encryption 
After Update
As
   Select * From deleted
   Select * From inserted


Update Course
Set Crs_Name = 'C#'
Where Crs_Id = 100

-------------------------------------------------------------------------------------
-- Prevent Delete On Table Topic 
-- And Display Message For User That He/She Can Not Delete This Topic
-- Message =>  'You Can''t Delete Topic With Id = {} And Name = {}'
-------------------------------------------------------------------------------------
Go
Create OR Alter Trigger DisableDeleteTopic
On Topic 
With encryption 
Instead Of Delete 
As
    Select CONCAT_WS (' ' , 'You Can''t Delete Topic With Id ='
	                  ,(Select Top_Id From deleted) , 
	                  'And Name =' , (Select Top_Name From deleted)) 
Delete From Topic 
Where Top_Id = 1


-------------------------------------------------------------------------------------
-- Prevent Delete From Table Course if Day is Sunday
-------------------------------------------------------------------------------------
Go
Create Or Alter Trigger DisableDeleteOnCourse
On Course 
With Encryption 
Instead Of Delete 
As
   If ( DATENAME(WEEKDAY , GETDATE()) != 'MonDay')  
       Delete From Course
	   Where Crs_Id in (Select Crs_Id From deleted)
  Else
    Select 'You Can''t Delete Course on Sunday'


Delete From Course
Where Crs_Id = 1200

-------------------------------------------------------------------------------------
---------------------------------- DDL Triggers -------------------------------------
-------------------------------------------------------------------------------------
-- Database -- Server Scope
-- Events [Create - Alter - Drop]

-------------------------------------------------------------------------------------
-- Database Created Successfully After Creation
-------------------------------------------------------------------------------------
Go
Create Trigger NotifyOnDatabaseCreation
On ALL SERVER 
With Encryption 
For CREATE_DATABASE 
As 
  Print 'Database Created Successfully'

Create Database Testt

Go 
-------------------------------------------------------------------------------------
-- Prevent Database Creation For All Members Except db_Owner
-------------------------------------------------------------------------------------

Create OR Alter Trigger DisableDatabaseCreation 
On ALL Server 
With Encryption 
For CREATE_DATABASE 
AS
    IF IS_MEMBER('db_Owner') = 1
	   BEGIN 
	      Print 'You are''t The Owner , Go Out'
	      ROLLBACK Transaction
	   END

Create Database Test03

----------------------------------------------------------------------------------
-- Database Object (Table , Function , View ...) -- Database Scope
-- Events [Create - Alter - Drop]
----------------------------------------------------------------------------------
-- Table Created Successfully After Creation
-------------------------------------------------------------------------------------
Go 
Create Or Alter Trigger NotifyOnTableCreation 
On Database 
With Encryption 
For CREATE_TABLE 
AS
   Print 'Table Is Created Successfully'


   Create Table NewTable
   (id int Primary key ,
   Test varchar(20))

   Go
----------------------------------------------------------------------------------
-- Modified Successfully After Any Modification On Table
-------------------------------------------------------------------------------------
Create Or Alter Trigger NotifyOnTable
On Database 
With Encryption 
For DDL_Table_EVENTS 
AS
   Print 'Modified Successfully'

   Alter Table NewTable 
   Drop Column Test


----------------------------------------------------------------------------------
-- EventData After Any Modification On Table
-------------------------------------------------------------------------------------
Go
Create Or Alter Trigger NotifyOnTable
On Database 
With Encryption 
For DDL_Table_EVENTS 
AS
   Select EVENTDATA()



   Create Table NewTable02
   (id int )

----------------------------------------------------------------------------------
-- Disable Alter On Tables
-------------------------------------------------------------------------------------
Go
Create Or Alter Trigger DisableAlter 
On Database 
With Encryption 
For ALTER_TABLE
As
   Begin 
    Print 'You Can''t Do This Modification' 
	Rollback
   End

Alter Table NewTable
Drop Constraint [PK__NewTable__3213E83F2D05D276]


-------------------------------------------------------------------------------------
---------------------------------- LOGON Triggers -------------------------------------
-------------------------------------------------------------------------------------
Go
CREATE OR Alter TRIGGER connection_limit_trigger ON ALL SERVER
WITH EXECUTE AS N'Salma'
FOR LOGON AS 
BEGIN
    IF  ORIGINAL_LOGIN() = N'Salma'
    AND (
        SELECT COUNT(*)
        FROM sys.dm_exec_sessions
        WHERE is_user_process = 1
            AND original_login_name = N'Salma') > 2
    ROLLBACK
END


-------------------------------------------Assignment 09-------------------------------------------
-------Part 01
Use [ITI]

--•	Create a trigger to prevent anyone from inserting a new record in the Department table 
--  ( Display a message for user to tell him that he can’t insert a new record in that table )

Go
Create  Trigger preventInsertDept
On Department 
With Encryption 
After  Insert
As
    Print 'you can’t insert a new record in that table'
    rollback transaction
Go 
Insert into Department(Dept_Id , Dept_name , Dept_Desc , Dept_Location,Dept_Manager)
Values(80, 'SS','AI','Giza',12)

--2.Create a table named “StudentAudit”. Its Columns are (Server User Name , Date, Note) 

--Server User Name   --	Date 	Note

Create Table StudentAudit 
(
[Server User Name] Varchar(max),
[Date] Date,
Note varchar(max)
)

--Create a trigger on student table after insert to add Row in StudentAudit table 
		--•	 The Name of User Has Inserted the New Student  
		--•	Date
		--•	Note that will be like ([username] Insert New Row with Key = [Student Id] in table [table name]

Go
Create Trigger T_InsertedStudentAudit
On student
After Insert 
AS
   Declare @Note varchar(max) , @Stu_Id int

	Select @Stu_Id = St_Id From inserted

	Select @Note = CONCAT_Ws( ' ' , suser_name() , 'Insert New Row with Key = ' , @Stu_Id ,'in table student')
	

	Insert into StudentAudit
	Values (SUSER_NAME() , GETDATE() , @Note)
Go

--Test	
Insert into Student (St_Id , St_Fname)
Values(25 , 'Ahmed')		
 
 select *
 from StudentAudit

 --4. Create a trigger on student table instead of delete to add Row in StudentAudit table 
		--○	 The Name of User Has Inserted the New Student
		--○	Date
		--○	Note that will be like “try to delete Row with id = [Student Id]” 

Go
Create Trigger T_DeletedStudentAudit
On student
Instead of  Delete 
AS
   Declare @Note varchar(max) , @Stu_Id int

	Select @Stu_Id = St_Id From deleted

	Select @Note = CONCAT_Ws( ' ' , suser_name() , 'try to delete Row with id = ' , @Stu_Id ,'in table student')
	

	Insert into StudentAudit
	Values (SUSER_NAME() , GETDATE() , @Note)
Go

--Test

Delete From Student
Where St_Id = 1

Select *
From StudentAudit


--------Part 02
use MyCompany

--•	Create a trigger that prevents the insertion Process for Employee table in March.

Go
Create  Trigger T_preventInsertEmpMarch
On Employee 
With Encryption 
Instead of  Insert
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


--Use IKEA_Company:
use [IKEA_Company]

--2.	Create an Audit table with the following structure 

--ProjectNo		UserName 	ModifiedDate 	Budget_Old 		Budget_New 
--p2			Dbo			2008-01-31			95000		200000

--This table will be used to audit the update trials on the Budget column (Project table, Company DB)
--If a user updated the budget column then the project number, username that made that update, 
--the date of the modification and the value of the old and the new budget will be inserted into the Audit table
--(Note: This process will take place only if the user updated the budget column)

Create Table [Audit] 
(
ProjectNo int,
UserName varchar(50),
ModifiedDate Date,
Budget_Old int,
Budget_New int )

select * from HR.Project

    
Go
Create Trigger HR.UpdateBudget
On HR.Project
After Update
As

	If Update(Budget)
		Begin
			Declare @PNum int , @OldBudget int , @NewBudget int
			select @PNum= ProjectNo from deleted
			select @OldBudget= Budget from deleted
	        select @NewBudget= Budget from inserted

			Insert into [Audit]
	        Values (@PNum,SUSER_NAME() , GETDATE() , @OldBudget,@NewBudget)
		End
Go

--Test

Update HR.Project
Set Budget = 1000
Where ProjectNo = 1

select * from [Audit]

Update HR.Project
Set ProjectName = 'Test'
Where ProjectNo = 1

select * from [Audit]

