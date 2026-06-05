/*======================Assignment 05======================*/
/*== Part 01 ==*/
-- Use ITI DB
use iti
--1.Retrieve a number of students who have a value in their age. 

Select Count(*) As [# of Students]
From Student
Where St_Age is not null

Select Count(St_Age) As [# of Students]
From Student

--2.Display number of courses for each topic name 

Select Top_Name , COUNT(Crs_Id) As [# of Courses]
From Course join Topic
On Course.Top_Id = Topic.Top_Id
Group By Top_Name

--3.Display student with the following Format (use isNull function)
--Student ID	Student Full Name	Department name

Select St_Id As [Student ID] , CONCAT(ISNULL(St_Fname , 'No FName') , ' ' , ISNULL(St_Lname , 'No LName')) As [Full Name] , ISNULL(Dept_Name , 'No Name') As [Dept Name]
From Student join Department
On Department.Dept_Id = Student.Dept_Id

--4.Select instructor name and his salary but if there is no salary display value ‘0000’ . “use one of Null Function” 


Select Ins_Name , ISNULL(Convert(varchar(10) , Salary) , '0000') As [Salary]
From Instructor

--5.Select Supervisor first name and the count of students who supervises on them

Select Supervisor.St_Fname , Count(Student.St_Id) As [Count Of Studets]
From Student join Student Supervisor
On Supervisor.St_Id = Student.St_super
Group by Supervisor.St_Fname

--6.Display max and min salary for instructors

Select MAX(Salary) As [Max Salary] , Min(Salary) As [Min Salary]
From Instructor

--7.Select Average Salary for instructors

Select AVG(Salary)
From Instructor

/*=========================================================================================================================*/
/*== Part 02 ==*/
--Use MyCompany DB
use MyCompany

--1.For each project, list the project name and the total hours per week (for all employees) spent on that project.

Select Project.Pname , SUM(WF.[Hours]) As [Project Hours]
From Project join Works_for WF
On Project.Pnumber = WF.Pno
Group by Project.Pname


--2.For each department, retrieve the department name and the maximum, minimum and average salary of its employees.

Select Dname , Max(Salary) As [Max Salary] , Min(Salary) As [Min Salary] , Avg(Salary) As [Avg Salary]
From Departments join Employee
On Departments.Dnum = Employee.Dno
Group By Dname