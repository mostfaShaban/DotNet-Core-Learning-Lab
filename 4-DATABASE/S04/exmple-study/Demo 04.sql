----------- Data Manipulation Language --------------
--===================================================
-- 1. Insert 
--===========
-- 1.1 Simple Insert  (Insert Just Only One Row)
--===============================================
use company01

Insert Into Employees
Values('Aliaa' , 'Tarek' , 'F' , '05-22-1990' , Null , 2,2000)

Insert Into Employees(FName , Gender)
Values ('Amr' ,'M' )

/* If a column is not in column_list, the Database Engine must be able to provide a value 
based on the definition of the column; otherwise, the row cannot be loaded. 
The Database Engine automatically provides a value for the column if the column:*/

-- 1. Has an IDENTITY property. The next incremental identity value is used.
-- 2. Has a default. The default value for the column is used.
-- 3. Has a timestamp data type. The current timestamp value is used.
-- 4. Is nullable. A null value is used.
-- 5. Is a computed column. The calculated value is used.

-- 1.2 Row Constructor Insert (More Than One Row)
--===============================================

Insert Into Employees
Values ('Sama' , 'Khaled' , 'F' , '12-10-2000' , null , 1,1500) , 
('Samy' , 'Sabry' , 'M' , '06-07-1999', null , 1,1300) , 
('Manar' , 'Ahmed' , 'F', '04-27-1998' , null , 2,1250),
('Mohamed' , 'Amr' , 'M', '09-20-1995' , null , 2,1600)


Insert Into Employees (Fname , Birthdate)
Values ('Mona' , '06-27-2000'),
('Malak' , '07-25-2000'),
('Ahmed' , '12-01-1995')


-------------------------------------------------------------------------------------------------
-- 2. Update 
--===========

Update Employees
set SuperId =  2
where Id = 7


update Employees
set Gender = 'F' , Lname = 'Amr'
Where Id = 7

 

-------------------------------------------------------------------------------------------------
-- 3. Delete
--===========

Delete from Employees
where Gender = 'M'

-------------------------------------------------------------------------
---------------- Data Query Language Category ----------------------------
---------------------------------------------------------------------------
use [Workshop ITI]

-- Display All Data For All Students
-------------------------------------
select *
from Student

--------------------------------------------------------------
-- Display First Name , Lsat Name And Age For All Students
--------------------------------------------------------------
Select Fname , Lname , Age
From Student

------------------------------------------------------------------
-- Display Id , First Name , Address And Age For Specific Student
-------------------------------------------------------------------
Select Id , Fname  , Age
from Student
where Id = 5

---------------------------------------------------------------------------------
-- Display Id , First Name And Age For Students That Their Age is More Than 23
-----------------------------------------------------------------------------------
Select Id , Fname , Age
from Student
Where Age > 23

-----------------------------------------------------------------------------------
-- Display Id , First Name And Age For Students That Their Age is in Range 23 , 30
-----------------------------------------------------------------------------------
Select St_Id , St_Fname , St_Age
from Student
Where St_Age >= 23 and St_Age <= 30

Select St_Id , St_Fname , St_Age
from Student
Where St_Age Between 23 and 30  ---دي احسن

----------------------------------------------------------------------------------------
-- Display Id , First Name And Age For Students That Their Age is Not in Range 23 , 30
----------------------------------------------------------------------------------------
Select St_Id , St_Fname , St_Age
from Student
Where St_Age Not Between 23 and 30

----------------------------------------------------------------------------------------
-- Display Student Id , Student FName, Student Address Who Lives In Cairo Or Alex
----------------------------------------------------------------------------------------
Select St_Id , St_Fname , St_Address
from Student
Where St_Address = 'Cairo' Or St_Address = 'Alex'

Select St_Id , St_Fname , St_Address
from Student
Where St_Address in ('Cairo' , 'Alex')

----------------------------------------------------------------------------------------
-- Display Student Id , Student FName, Student Address Who Not Lives In Cairo Or Alex
----------------------------------------------------------------------------------------
Select St_Id , St_Fname , St_Address
from Student
Where St_Address != 'Cairo' And St_Address <> 'Alex' --  <> =not equel

Select St_Id , St_Fname , St_Address
from Student
Where St_Address Not in ('Cairo' , 'Alex')

------------------------------------------------------------
--  Display All Data Of All Students Who Hasn't a Supervisor
------------------------------------------------------------
Select *
from Student
where St_super is Null

------------------------------------------------------------
--  Display All Data Of All Students Who Has a Supervisor
------------------------------------------------------------
Select *
from Student
where St_super is Not Null

---------------------------------------------------------------------
-- Display student where second character of Their First name is 'a' 
---------------------------------------------------------------------
Select *
from Student
where Fname Like '_a%'


/*
Wildcard Characters =>
_   : represents one, single character
%   : represents zero, one, or multiple characters
[]  : Matches any single character within the specified range 
[^] : Matches any single character that is not within the range
*/

-- Examples 

-- _a%     => Samy , Manar , Sama , Samar , Yassmin
-- s%      => Shaimaa , Samy , Safaa , Selim 
-- _M%     => Amr , Emad , Amira
-- [sa]%   => Ahmed , Shaimaa , Selim , Amr ,Samy
-- sa%     => Samy , Sama , Samar
-- [^sa]%  => Mohamed , Marwa , Essam 
-- [a-m]%  => Malak , Bola , Eman 
-- [^a-m]% => Omar , Rawan , Salma
-- [463]%  => 6X , 3mr
-- %[%]    => Word% , Laila% 

---------------------------------------------------------------------
-- Display Data Without Duplication
---------------------------------------------------------------------
Select Distinct Fname --Distinct دي الي تلغي التكرار
From Student


Select Distinct Dept_Id
From Student
Where Dept_Id is not null

--------------------------------------------
-- Display First Name Of Student In Order 
--------------------------------------------

Select fname
from Student 
-- Retrieved According To Their Defualt Order In Table [Ordered According PK] 


Select Fname
From Student
Order by Fname Asc -- Defualt


Select Fname
From Student
Order by Fname Desc 

Select Fname , Lname
From Student
Order by Fname , Lname desc  -- St_Lname هي الي desc 


Select Fname , Lname
From Student
Order by 1 , 2 desc  -- select اول وتاني حسب 
-- ملحوظة order by تنفذ بعد select

-----------------------------------------------------------
-------------------------- Joins --------------------------
-----------------------------------------------------------
-- Cross Join (Cartisian product)
----------------------------------
-- Old Syntax
Select Fname , [Name]
From Student , Department

-- New Syntax
Select Fname , Name
From Student Cross Join Department
-----------------------------------------------------------
-- Inner Join (Equi Join)
----------------------------------
-- Old Syntax 
Select Fname , [Name]
From Student S , Department D
Where D.Id = S.Dept_Id  

-- New Syntax 
Select Fname , [Name]
from Student S inner join Department D
On D.Id = S.Dept_Id

Select Fname , [Name]
from Student S join Department D
On D.Id = S.Dept_Id

-----------------------------------------------------------
-- Outer Joins 
---------------
-- 1. Left Outer Join 
-----------------------
select S.Fname, D.[Name]
from  Student S left outer join Department D 
on D.id = S. dept_id 


select *
from  Student S left outer join Department D 
on D.id = S. dept_id and D.Id=10

select S.Fname, D.Name
from  Department D left join  Student S
on D.id = S.dept_id 

select *
from  Department D left join  Student S
on D.id = S.dept_id and s.Age=20
 ----------------------------------------------------------------------
-- 2. Right Outer Join 
-----------------------
select S.St_Fname, D.Dept_Name
from  Student S Right outer join Department D 
on D.dept_id = S. dept_id


select S.St_Fname, D.Dept_Name
from  Department D Right join  Student S
on D.dept_id = S.dept_id

---------------------------------------------------------------------------------
-- 3. Full Outer Join 
-----------------------
Select S.St_Fname , D.Dept_Name
from Student S Full outer Join Department D
on D.Dept_Id = S.Dept_Id


Select S.St_Fname , D.Dept_Name
from Student S Full Join Department D
on D.Dept_Id = S.Dept_Id

--------------------------------------------------------------------------------------------------
-- Self Join
---------------
-- Get Id and Name Of Students That Have a Supervisor And Get Supervisor Name 
-------------------------------------------------------------------------------
Select Stud.St_Id As StudentId, Stud.St_Fname As StudentName , Supervisors.St_Fname As SupervisorName
from Student Stud , Student Supervisors
where Supervisors.St_Id = Stud.St_super -- 

Select Stud.St_Id [Student Id], Stud.St_Fname 'Student Name'  , Supervisors.St_Fname [Supervisor Name]
from Student Stud Inner join Student Supervisors
on Supervisors.St_Id = Stud.St_super

Select Stud.St_Id [Student Id], Stud.St_Fname 'Student Name'  , Supervisors.St_Fname [Supervisor Name]
from Student Stud  join Student Supervisors
on Supervisors.St_Id = Stud.St_super



-- Get All Data Of Students That Have a Supervisor Or Not 
-- And If He Has a Supervisor Get Supervisor Name 
------------------------------------------------------------
Select Stud.* , Supervisors.St_Fname [Supervisor Name]
from Student Stud Left join Student Supervisors
on Supervisors.St_Id = Stud.St_super


Select Stud.* , Supervisors.St_Fname [Supervisor Name]
from Student Stud Right join Student Supervisors
on Supervisors.St_Id = Stud.St_super


-----------------------------------------------------------
-- Multiple-Table Joins 
------------------------
Select St_Fname , Crs_Name , Grade
from Student Std , Course Crs , Stud_Course StdCrs
Where Std.St_Id = StdCrs.St_Id And Crs.Crs_Id = StdCrs.Crs_Id And StdCrs.Grade > 100


Select St_Fname , Crs_Name , Grade
from Student Std 
inner join Stud_Course StdCrs
On Std.St_Id = StdCrs.St_Id
inner join Course Crs
on Crs.Crs_Id = StdCrs.Crs_Id
Where StdCrs.Grade > 100

-----------------------------------------------------------
-- DML With Joins 
-------------------
-- Update 
------------
--get student in live cairo and increase  this grade by 10

Update StdCrs
Set Grade += 10 --Grade = Grade + 10
from Student Std join Stud_Course StdCrs
on Std.St_Id = StdCrs.St_Id
Where Std.St_Address = 'Cairo'

------------------------------------------------------------
-- Delete 
--delete the student this your age equal 28 and this enroll course


Select Distinct Std.St_Id , St_Fname
from Student Std join Stud_Course StdCrs
on Std.St_Id = StdCrs.St_Id
Where Std.St_Age = 28


Delete Std
from Student Std join Stud_Course StdCrs
on Std.St_Id = StdCrs.St_Id
Where Std.St_Age = 28


--delete the student this your address live in cairo and this enroll course

Select  Std.St_Id , St_Fname 
from Student Std join Stud_Course StdCrs
on Std.St_Id = StdCrs.St_Id
Where Std.St_Address = 'Cairo'


Delete StdCrs
from Student Std join Stud_Course StdCrs
on Std.St_Id = StdCrs.St_Id
Where Std.St_Address = 'Cairo'


