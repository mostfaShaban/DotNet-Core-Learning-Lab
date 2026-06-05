/*========================Assignment 03========================*/
-- ItI DataBase
Create dataBase [Workshop ITI]
use [Workshop ITI]

create table Student
(
ID int primary key identity(1,1),
FName varchar(30) not null,
lName varchar(20),
Age int,
Dept_Id int -----
)
create table Course
(
ID int primary key identity(1,1),
[Name] varchar(30) not null,
[Duration] int,
[Description]varchar(60),
Top_Id int ---
)
Create Table Topic
(
Id int primary key identity(1,1),
[Name] varchar(20) not null
)

Create Table Department
(
Id int primary key identity(10, 1),
[Name] varchar(20) not null,
[Hiring Date] Date,
[Manager Id] int unique not null --
)

Create Table Instructor(
Id int primary key identity(1,1),
[Name] varchar(20) not null,
[Address] varchar(30),
Bonus decimal,
Salary decimal ,
[Hour Rate] decimal,
Dept_ID int references Department(Id)
)
 
create table Student_Course
(
[Stud ID] int references Student(Id),
[crs ID] int references Course(Id),
Grade decimal,
Primary key ([Stud ID], [crs ID])
)

create table Course_Instructor
(
[Ins ID] int references Instructor(Id),
[crs ID] int references Course(Id),
Evaluation varchar(50),
Primary Key ([Ins ID], [crs ID])
)
--Alter
Alter table Student
add constraint fk_depart foreign key(Dept_Id) references Department(ID)

Alter Table Department 
Add Foreign key ([Manager Id]) references Instructor(Id)

Alter Table Course 
Add Foreign key (Top_ID) references Topic(Id)

Alter Table Course
Alter column Top_Id int not null

Alter Table Course
Add Constraint UQ_Topic Unique(Top_Id)
