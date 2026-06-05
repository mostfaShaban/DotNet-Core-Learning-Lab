--------------- Functions ----------------------
------------------------------------------------
Use MyCompany
------------ Aggregate Functions ---------------
-- Count 
Select COUNT(*) , COUNT(SSN) , COUNT(Dno)
From Employee

-- Sum
Select SUM(Salary)
From Employee

-- Avg
Select AVG(Salary)
From Employee

Select SUM(Salary)/COUNT(Salary)
From Employee

-- Max , Min
Select Max(Salary) [Max Salary] , MIN(Salary) [Min Salary]
From Employee

Select Min(Fname) , Max(Fname) -- Ahmed , Noha
From Employee

Select Distinct dno ,  Min(Salary) Over(Partition by dno) [Min Salary]
From Employee


Select dno ,  Min(Salary) [Min Salary] , Max(Salary) [Max Salary] 
From Employee
group by Dno

------------ Null Functions ---------------
-- ISNULL
Select ISNULL(Lname , 'Not Found')
From Employee

Select ISNULL(Lname , Fname)
From Employee

Select ISNULL(Salary , Fname) -- Invalid
From Employee

Select ISNULL(Lname , ISNULL(Address , Fname))
From Employee

Select Fname + ' ' + ISNULL(Lname , ' ')
From Employee

-- Coalesce 
Select COALESCE(Lname , Address , Fname )
From Employee


------------ Date and Time Functions ---------------

Select SysDateTime() -- 2024-11-14 08:30:08.1571479

Select SYSUTCDATETIME() -- 2024-11-14 06:30:42.2019742

Select GetDate() -- 2024-11-14 08:31:07.643

Select GETUTCDATE() -- 2024-11-14 06:31:24.023

Select DATENAME(day, '11-14-2024') -- 14

Select DATEPART(day ,'11-14-2024') -- 14

Select DATENAME(weekday, '11-14-2024') -- Thursday

Select DAY('11-14-2024') -- 14

Select Month('11-14-2024') -- 11

Select YEAR('11-14-2024') -- 2024

Select EOMONTH ('11-14-2024') -- 2024-11-30

Select ISDATE('11-14-2024') -- 1

Select ISDATE('14-11-2024') -- 0

------------ Conversion Functions ---------------
-- Convert 
Select Fname + ' _ ' + ISNULL(Convert(Varchar(20),Salary) , ' ')
From Employee

-- Cast
Select Fname + ' ' + Cast(Salary as Varchar(20))
From Employee


Declare @Today date = GETDATE()	
Select Cast(@Today As varchar(max))
Select CONVERT(varchar(max),@Today)



Declare @Today date = GETDATE()	
Select CONVERT(varchar(max),@Today,101) -- 30/3/2026
Select CONVERT(varchar(max),@Today,102) -- 2026.03.30
Select CONVERT(varchar(max),@Today,103) -- 14/11/2024
Select CONVERT(varchar(max),@Today,104) -- 14.11.2024
Select CONVERT(varchar(max),@Today,105) -- 14-11-2024
Select CONVERT(varchar(max),@Today,106) -- 14 Nov 2024

-- Parse (Use PARSE only for converting from string to date/time and number types)

Select Parse('Thursday, 14 November 2024' as Date USING 'en-US') -- 2024-11-14

SELECT PARSE('$345,98' AS money USING 'en-US')  -- 34598.00

Select PARSE('Route' as date) -- Error

Select Try_Parse('Route' as Date) -- Null  retrun null if it found error


------------ String Functions ---------------
Select Fname + ' ' + Lname
From Employee

Select Concat(SSN ,' ',Fname ,' ' ,  Lname , ' ' , Address)
From Employee

Select Concat_Ws(' ', SSN , Fname , Lname , Address)
From Employee

Select Lower(Fname) , UPPER(Fname)
From Employee

Select Fname , Len(Fname) [Number of Char]
From Employee

Select Fname , SUBSTRING(Fname , 1 , 2) , CONVERT(varchar(2), Fname)
From Employee
--------------------------------------------------------------------------------------
------------------------------ Format ------------------------------------------------
Select FORMAT(Salary , '###,###')
From Employee

Select FORMAT(123456789 , '###,###,###')

Declare @Today datetime = GETDATE()
SELECT FORMAT(@Today, 'd', 'en-US')	-- 11/14/2024	
SELECT FORMAT(@Today, 'd', 'ar-SA') -- 12/05/46
SELECT FORMAT(@Today, 'D', 'en-US')  -- Thursday, November 14, 2024
SELECT FORMAT(@Today, 'D', 'ar-SA') -- 12/جمادى الأولى/1446
Select FORMAT(@Today , 'dd MM yy') -- 14 11 24
Select FORMAT(@Today , 'ddd MMM yyy') -- Thu Nov 2024
Select FORMAT(@Today , 'dddd MMMM yyyy') -- Thursday November 2024
Select FORMAT(@Today , 'dd-MM-yyyy hh:mm:ss tt' , 'en-US') -- 14-11-2024 09:32:36 AM
Select FORMAT(@Today , 'dd-MM-yyyy hh:mm:ss tt' , 'ar-SA') --12-05-1446 09:32:36 ص

---------------------------------------------------------------------------------------
--===================================================================
-------------------------    Group By    ----------------------------
--===================================================================
Use ITI

Select Dept_Id , Min(Salary) [Min Salary Per Department]
From Instructor
group by Dept_Id

Select Dept_Id , Min(Salary) [Min Salary Per Department]
From Instructor -- Invalid 

Select Distinct Dept_Id , Min(Salary) Over (Partition By Dept_Id) [Min Salary Per Department]
From Instructor

Select Dept_Id , Salary , Min(Salary) Over (Partition By Dept_Id) [Min Salary Of Department]
From Instructor


Select Count(*) [Count Of Students]
From Student


Select Dept_Id , COUNT(*) [Count Of Student Per Department]
From Student
Where Dept_Id Is not Null
Group by Dept_Id
----------------------------------------------------------------------------------------------
-------------------------------- Group By With Multiple Columns ------------------------------

Select Dept_Id , St_Address ,COUNT(*) [Count Of Student Per Department]
From Student
Where Dept_Id Is not Null
Group by Dept_Id , St_Address

Select Dept_Id , St_Address ,COUNT(*) [Count Of Student Per Department]
From Student
Where Dept_Id Is not Null 
Group by  St_Address , Dept_Id

----------------------------------------------------------------------------------------------
------------------------------------ Group By With Having ------------------------------------


Select Dept_Id  ,COUNT(*) [Count Of Student Per Department]
From Student
Where Dept_Id Is not Null And Count(*) > 2 -- Not Valid 
Group by Dept_Id


Select Dept_Id  ,COUNT(*) [Count Of Student Per Department]
From Student
Where Dept_Id Is not Null 
Group by Dept_Id
Having Count(*) > 2


Select Avg(Salary) [Average Salary]
From Instructor
Where Count(*) > 10 -- Invalid


Select Avg(Salary) [Average Salary]
From Instructor
Having Count(*) > 15 -- Using Having Without Group By If Condition Contain Aggregate Function


----------------------------------------------------------------------------------------------
------------------------------------- Group By With Join -------------------------------------

Select Dept_Id , Sum(Salary) [Total Salary Per Department]
From Instructor
Where Dept_Id Is not Null
Group By Dept_Id


Select I.Dept_Id , Sum(Salary) [Total Salary Per Department]
From Instructor I , Department D
Where D.Dept_Id = I.Dept_Id
Group By I.Dept_Id


Select I.Dept_Id , D.Dept_Name , Sum(Salary) [Total Salary Per Department]
From Instructor I , Department D
Where D.Dept_Id = I.Dept_Id
Group By I.Dept_Id , D.Dept_Name


Select Supervisor.St_Fname [Supervisor Name], Count(*)
From Student Std , Student Supervisor
Where Supervisor.St_Id = Std.St_super
Group by  Supervisor.St_Fname ,Supervisor.St_Id ---    self join لو بتستخدم  pkب groub by اعمل 

-----------------------------------------------------------------------------------------
---------------------------------ASS#5---------------------------------------------
------------------------part#1
use ITI

select count(*)[ # of student ]
from Student
where St_Age is not null


select Top_Name,count(Crs_Id) [ num of courses ]
from Course join Topic
on Course.Top_Id= Topic.Top_Id
group by Top_Name


select St_Id,CONCAT(isnull(St_Fname,'notfound'),' ',isnull(St_Fname,'notfound')) [full Name] , ISNULL(Dept_Name , 'No Name') As [Dept Name]
from Student join Department
on Student.Dept_Id=Department.Dept_Id


select Ins_Name, isnull(convert(varchar(10),salary),'...') [salary]
from Instructor

--5.Select Supervisor first name and the count of students who supervises on them
select super.St_Fname , count(student.St_Id)[Count Of Studets]
from  Student join Student super
on Student.St_super=super.St_super
group by super.St_Fname

Select MAX(Salary) As [Max Salary] , Min(Salary) As [Min Salary]
From Instructor

Select AVG(Salary) [ Salary ]
From Instructor

------------------------part#2
use MyCompany

ALTER AUTHORIZATION ON DATABASE::MyCompany TO sa; -- دة عالج ايرور data base digram

select Project.Pname , sum(Works_for.Hours)[Project Hours]
from Project join Works_for
on Project.Pnumber=Works_for.Pno
group by Project.Pname


select Departments.Dname , max(Employee.Salary)[max salary] ,min(Employee.Salary)[min salary] , avg(Employee.Salary)[Avgerage salary]
from Departments join Employee
on Departments.Dnum=Employee.Dno
group by Departments.Dname
