---ass #4 part 1----------
--From The Previous Assignment insert at least 2 rows per table. 
insert into Course
values ('ForntEnd','32','null','6')

insert into Course (Name,Duration,Top_Id)
values ('database','25','7')

insert into Student(FName,lName,Age,Dept_Id)
values ('ali','said',19,10),
       ('soha','said',17,10),
       ('bassma','mahmoud',20,10),
       ('akram','amir',21,11),
       ('rana','yassen',18,12)
--Insert your personal data to the student table as a new Student 
--in department number 22
insert into student 
values ('mostfa','soudy',23,22)
 
--Insert Instructor with personal data of your friend as new Instructor 
--in department number 30, Salary= 4000, but don’t enter any value for bonus
insert into Instructor 
values ('Hassan','Atfih',null,4500,30,11)

--Upgrade Instructor salary by 20 % of its last value.
update Instructor
set Salary+=salary*0.2
where Address='Atfih'

-- * part 2 *
--	Restore MyCompany Database and then:Try to create the following Queries:

use MyCompany

--Display all the employees Data.
select *
from Employee

--Display the employee First name, last name, Salary and Department number.
select Fname,Lname,Salary,Dno
from Employee

--Display all the projects names, locations and the department which 
--   is responsible for it.
select Pname,Plocation,Dnum
from Project

select pro.Pname,pro.Plocation,Dep.Dnum,Dep.Dname
from Project pro join Departments Dep
on Dep.Dnum=pro.Dnum

--If you know that the company policy is to pay an annual commission الزيادة السنوية
-- for each employee with specific percent equals 10% of his/her annual salary 
--Display each employee full name and his annual commission in an ANNUAL COMM column (alias).

select  concat (Fname,' ',Lname) as [fullname], (Salary*12)*0.1 as [annual comm]
from Employee

--Display the employees Id, name who earns more than 1000 LE monthly.

select SSN,concat (Fname,' ',Lname) as [fullname]
from Employee
where Salary >1000

--Display the employees Id, name who earns more than 10000 LE annually.

select SSN,concat (Fname,' ',Lname) as [fullname], Salary*12 as [salary annually]
from Employee
where (Salary*12) >10000

--Display the names and salaries of the female employees 
select concat (Fname,' ',Lname) as [fullname],Salary
from Employee
where Sex='F'

/* Display each department id, name which is managed
by a manager with id equals 968574  */

select Dnum,Dname
from Departments
where MGRSSN=968574

/* Display the ids, names and locations of  the projects which are controlled 
with department 10 */

select Pnumber,Pname,Plocation,Dnum
from Project
where Dnum =10

---  *********************** Part #3  ********************************
--⮚	Restore ITI Database and then
use ITI

--Get all instructors Names without repetition

select distinct  Ins_Name
from Instructor

/* Display instructor Name and Department Name 
      Note: display all the instructors if they are attached to a department or not */
select INs.Ins_Name,dep.Dept_Name
from Instructor INs  left join Department Dep
on Dep.Dept_Id=Ins.Dept_Id

insert into Instructor (Ins_Id,Ins_Name)
values (17,'ahmed')

/* Display student full name and the name of the course he is taking
For only courses which have a grade */ 

select CONCAT(St_Fname,' ',St_Lname) as[full Name],crs.Crs_Name,stdcrs.Grade
from Student std ,Course crs ,Stud_Course stdcrs
where std.St_Id=stdcrs.St_Id and crs.Crs_Id=stdcrs.Crs_Id and stdcrs.Grade is not null


select CONCAT(St_Fname,' ',St_Lname) as[full Name],crs.Crs_Name,stdcrs.Grade
from Student std  join Stud_Course stdcrs
on std.St_Id=stdcrs.St_Id join Course crs
on crs.Crs_Id=stdcrs.Crs_Id
where stdcrs.Grade is not null

/* Bouns
Display results of the following two statements and explain
what is the meaning of @@AnyExpression */
select @@VERSION    -- sql Version
select @@SERVERNAME  --serverName

---  *********************** Part # 4  ********************************
--	Using MyCompany Database and try to  create the following Queries:
use MyCompany

-- Display the Department id, name and id and the name of its manager.
select Dep.Dnum,Dep.Dname,CONCAT(Fname,' ',Lname) as[manger name] 
from Departments Dep join Employee Emp
on  Emp.SSN=Dep.MGRSSN

--Display the name of the departments and the name of the projects under its control.

select Dep.Dname,pro.Pname
from Departments Dep join Project pro
on  Dep.Dnum=pro.Dnum

--Display the full data about all the dependence associated with the name of the employee they depend on .

select *
from Dependent

select Dpt.*,CONCAT(fname,' ',Lname) as [employee name depend ]
from [Dependent] Dpt join Employee Emp
on Dpt.ESSN=Emp.SSN

--Display the Id, name and location of the projects in Cairo or Alex city

select Pnumber,Pname,Plocation, City
from Project
where City in ('cairo','Alex')

--Display the Projects full data of the projects with a name starting with "a" letter.

select *
from Project
where Pname like 'a%'

--display all the employees in department 30 whose salary from 1000 to 2000 LE monthly

Select *
From Employee
Where Dno = 30 and Salary between 1000 and 2000

--Retrieve the names of all employees in department 10 who work more than or equal 10 hours per week on the "AL Rabwah" project.

Select CONCAT(Fname , ' ' , Lname) As [Emp name]
From Employee E Join Works_for WF
On E.SSN = WF.ESSn and WF.[Hours] >= 10 join Project
On Project.Pnumber = WF.Pno
Where E.Dno = 10 and Project.Pname = 'AL Rabwah'
----------or------------------------------------------------
Select CONCAT(Fname , ' ' , Lname) As [Emp name]
From Employee E Join Works_for WF
On E.SSN = WF.ESSn  join Project
On Project.Pnumber = WF.Pno
Where E.Dno = 10 and Project.Pname = 'AL Rabwah' and WF.[Hours] >= 10

--Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name

Select CONCAT(Fname , ' ' , Lname) As [Empy Name] , P.Pname
From Employee E join Works_for WF 
On E.SSN = WF.ESSn join Project P
On P.Pnumber = WF.Pno
order by p.Pname  -- order by 2 -->colum 2

/*For each project located in Cairo City , find the project number,
the controlling department name ,the department manager last name ,address and birthdate */

Select Pnumber , Dname , Manager.Lname , Manager.[Address] , Manager.Bdate , city
From Project pro join Departments Dep
On pro.Dnum = Dep.Dnum join Employee Manager
On Dep.MGRSSN  = Manager.SSN
Where City = 'Cairo'


-----------Doneeeee--------------------------