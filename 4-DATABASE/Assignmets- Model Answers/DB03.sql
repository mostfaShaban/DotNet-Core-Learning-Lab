/*========================Assignment 03========================*/

-- Choose 2 Database Schema From The Previous Assignment and Create One using code and another using wizard 
Create dataBase [Workshop ITI]
use [Workshop ITI]
--------------------------------------------------------------------------
-- 1. Create Table Student
Create Table Student (
Id int primary key identity(1,1),
FName varchar(20) not null,
LName varchar(20),
Age int,
Dept_Id int
)

-- 2. Create Table Department

Create Table Department
(
Id int primary key identity(100, 1),
[Name] varchar(20) not null,
[Hiring Date] Date,
[Manager Id] int unique not null
)
-- 3. Create Table Instructor
Create Table Instructor(
Id int primary key identity(1,1),
[Name] varchar(20) not null,
[Address] varchar(30),
Bonus decimal,
Salary decimal ,
[Hour Rate] decimal,
Dept_ID int references Department(Id)
)


-- 4. Create Table Course

-- Topic unique and not null

Create Table Course
(
Id int primary key identity(1,1),
[Name] varchar(30) not null,
[Duration] int,
[Description] varchar(50),
Top_ID int
)

-- 5. Create Table Topic
Create Table Topic
(
Id int primary key identity(1,1),
[Name] varchar(20) not null
)
-- 6. Create Table Student_Course
Create Table Student_Course
(
Stud_Id int references Student(Id),
Course_Id int references Course(Id),
Grade decimal
Primary key (Stud_Id, Course_Id)
)
-- 7. Create Table  Course_instructor

Create Table Course_Instructor
(
Course_Id int references Course(Id),
Inst_Id int references Instructor(Id),
Evaluation varchar(50),
Primary Key (Course_Id, Inst_Id)
)


---------------------------------------------------------------------

-- Add Foreign key --

Alter Table Student
Add Foreign key (Dept_Id) references Department(Id)

Alter Table Department 
Add Foreign key ([Manager Id]) references Instructor(Id)

Alter Table Course 
Add Foreign key (Top_ID) references Topic(Id)

Alter Table Course
Alter column Top_Id int not null

Alter Table Course
Add Constraint UQ_Topic Unique(Top_Id)



