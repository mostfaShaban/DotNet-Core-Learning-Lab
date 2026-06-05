-- DDL
--1. create
--to crate Database
create Database company01
-- select this Data base
use company01

-- create Table

create table employees
(
ID int primary key identity(1,1),-- identity(start,rate of increase)
Fname varchar(16) Not Null, -- required
Lname varchar(14),
Gender char(1),-- F or  M
Birthdate Date,
Dnum int,-- fk to coulmn in other next table (Alter)
SuperId int references employees(ID) --self relationship

)
create table Department
(
Dnum int primary Key identity(1,1),
Dname varchar(15) Not Null,
MangerID int Not Null unique references employees(ID), -- Ukey
HiringDate Date Not null ,

)
create table DepartmentLocation
(
Dnum int references Department(Dnum),
Location varchar(30), -- if you put d value --> default 'cairo' 
primary Key (Dnum,location) -- composite pk
)
create table Projects
(
Pnum int primary key identity(1,1),--  (10,10) ممكمن
Pname varchar(20) Not Null,
Location varchar(30) default 'cairo',
City varchar(20) ,
Dnum int references Department(Dnum)

)
create table Dependents
(
Name varchar(30),
Gender char(1),-- F or  M
Birthdate Date,
EmployeeID int references employees(ID),
primary Key(EmployeeID,Name)
)
create table Employee_Projects
(
EmployeeID int references employees(ID),
Pnum int references Projects(pnum),
NumOfHours int,
primary Key(EmployeeID,Pnum)
)
-- 2. Alter (Update Structure)
--======================
-- Alter Database Name 
Alter Database test
modify name  = CompanyG06

-- Alter Database Object 
--==========================
-- Alter Add [Column - Constraint]
--====================================
-- Add New Column 
Alter table Employees
add Test int 
--------------------------------------------------
-- Add Constraint 
alter table Employees 
add constraint UQ_Test unique (Test)
--------------------- or ----------------------------------
alter table Employees 
add  unique (Test)
------------------------------------------
-- Alter datatype of an existing Column
Alter Table Employees
Alter column test bigint
------------------------------------------------------
-- Add (foreign key) references to column 
Alter Table Employees
add constraint FK_Work foreign key (Dnum) references Departments(Dnum)
 
Alter Table Employees
add foreign key (Dnum) references Departments(Dnum)
------------------------------------------------------------------------
-- Drop Column 
Alter Table Employees 
Drop column Test

-- Drop Constraint 
Alter Table Employees 
Drop Constraint UQ_Test

-- Drop (foreign key) references to column 
Alter Table Employees
drop constraint FK_Work 


-- 3. Drop
--=========

-- Drop Table 
Drop Table Employees

-- Drop Database
Drop Database company01 

