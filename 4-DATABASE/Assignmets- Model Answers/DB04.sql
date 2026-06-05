/*======================Assignment 04======================*/
/*============Part 01============*/

----       Insert at least 2 rows per table ----

use [Workshop ITI]

Insert into Instructor
Values ( 202 , 'Menna' , 'Giza' , null , 10000 , 150 , 100)

Insert into Department
Values (90, 'Web Development' , null , 20)

Insert into Student
Values ( 'Manar' ,'Ali' , 20 , 90)


--Data Manipulation Language:

-- 1.Insert your personal data to the student table as a new Student in department number 30

Insert into Department
Values (30, 'Mobile' , null , 202)

Insert Into Student
Values('Abdelrahman' , 'Magdy' , 30 , 30)

--2.Insert Instructor with personal data of your friend as new Instructor in department number 30, Salary= 4000

Insert Into Instructor
Values ( 300 , 'Radwa' , 'Giza' , null , 4000 , 140 , 30)

--3.Upgrade Instructor salary by 20 % of its last value.

Update Instructor
Set Salary = Salary + Salary* 0.2
Where Id = 300

Update Instructor
Set Salary += Salary* 0.2
Where Id = 300


/*============================================================================================================================*/


/* ==Part 02== */
--Restore MyCompany Database and then:
use myCompany

--1.Display all the employees Data.

Select *
From Employee


--2.Display the employee First name, last name, Salary and Department number.

Select Fname , Lname , Salary , Dno
From Employee


--3.Display all the projects names, locations and the department which is responsible for it.

Select Pname, Plocation , Dname
From Project  join Departments
On Project.Dnum = Departments.Dnum


--4.If you know that the company policy is to pay an annual commission for each employee with specific percent equals 10% of his/her annual salary 
-- .Display each employee full name and his annual commission in an ANNUAL COMM column (alias).

Select CONCAT(Fname , ' ' , Lname) As [Full Name] , (Salary*12)*0.1 As [Annual COMM]
From Employee


--5.Display the employees Id, name who earns more than 1000 LE monthly.

Select SSN , CONCAT(Fname , ' ' , Lname) As [Full Name] , Salary
From Employee
Where Salary > 1000


--6.Display the employees Id, name who earns more than 10000 LE annually.

Select SSN, CONCAT(Fname , ' ' , Lname) As [Full Name] , (Salary*12)
From Employee
Where (Salary*12) > 10000


--7.Display the names and salaries of the female employees 

Select CONCAT(Fname , ' ' , Lname) As [Full Name] , Salary
From Employee
Where Sex = 'F'


--8.Display each department id, name which is managed by a manager with id equals 968574.

Select Dnum , Dname
From Departments
Where MGRSSN = 968574


--9.Display the ids, names and locations of  the projects which are controlled with department 10.

Select Pnumber , Pname , Plocation , Dnum
From Project
Where Dnum =10


/*============================================================================================================================*/
/* ==Part 03== */
--Restore ITI Database and then:
use iti

--1.Get all instructors Names without repetition

Select Distinct Ins_Name
From Instructor


--2.Display instructor Name and Department Name 
--- Note: display all the instructors if they are attached to a department or not.

Select  Ins_Name , Dept_Name
From Instructor Ins left join Department Dept
On  Dept.Dept_Id = Ins.Dept_Id

--3.Display student full name and the name of the course he is taking For only courses which have a grade 

Select CONCAT(Student.St_Fname , ' ' , Student.St_Lname) As [Full Name] , Course.Crs_Name ,  Stud_Course.Grade
From Student join Stud_Course 
On Stud_Course.St_Id = Student.St_Id join Course
On Stud_Course.Crs_Id = Course.Crs_Id
Where Stud_Course.Grade Is not null

--Bouns

--Display results of the following two statements and explain what is the meaning of @@AnyExpression
--select @@VERSION
select @@VERSION --sql server version

--select @@SERVERNAME
select @@SERVERNAME --server name

/*============================================================================================================================*/
/* ==Part 04== */
--Using MyCompany Database and try to  create the following Queries:
use myCompany

--1.Display the Department id, name and id and the name of its manager.

Select Departments.Dnum , Departments.Dname , Employee.SSN , Employee.Fname
From Departments join Employee
On Departments.MGRSSN = Employee.SSN


--2.Display the name of the departments and the name of the projects under its control.

Select Dname , Pname
From Departments join Project
On Departments.Dnum = Project.Dnum

--3.Display the full data about all the dependence associated with the name of the employee they depend on .

Select [Dependent].* ,  CONCAT(Fname , ' ' , Lname) As [Full Name]
From [Dependent] join Employee 
On Employee.SSN = [Dependent].ESSN

--4.Display the Id, name and location of the projects in Cairo or Alex city.

Select Pnumber , Pname , Plocation , City
From Project
Where City In ('Cairo' , 'Alex')

Select Pnumber , Pname , Plocation , City
From Project
Where City = 'Cairo' or City = 'Alex'

--5.Display the Projects full data of the projects with a name starting with "a" letter.

Select *
From Project
Where Pname Like 'a%'

--6.display all the employees in department 30 whose salary from 1000 to 2000 LE monthly

Select *
From Employee
Where Dno = 30 and Salary between 1000 and 2000

Select *
From Employee
Where Dno = 30 and Salary >= 1000 and Salary <= 2000

--7.Retrieve the names of all employees in department 10 who work more than or equal 10 hours per week on the "AL Rabwah" project.


Select CONCAT(Fname , ' ' , Lname) As [Full Name]
From Employee E Join Works_for WF
On E.SSN = WF.ESSn and WF.[Hours] >= 10 join Project
On Project.Pnumber = WF.Pno
Where E.Dno = 10 and Project.Pname = 'AL Rabwah'



--8.Retrieve the names of all employees and the names of the projects they are working on, sorted by the project name.

Select CONCAT(Fname , ' ' , Lname) As [Full Name] , P.Pname
From Employee E join Works_for WF 
On E.SSN = WF.ESSn join Project P
On P.Pnumber = WF.Pno
Order By 2


--9.For each project located in Cairo City , find the project number, the controlling department name ,the department manager last name ,address and birthdate

Select Pnumber , Dname , Manager.Lname , Manager.[Address] , Manager.Bdate , city
From Project join Departments
On Project.Dnum = Departments.Dnum join Employee Manager
On Departments.MGRSSN  = Manager.SSN
Where City = 'Cairo'
