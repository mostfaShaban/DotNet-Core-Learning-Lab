create database [Library]

CREATE TABLE [floor] (
    Floor_num INT PRIMARY KEY,
    NumOfBlocks INT,
    Manger_ID INT,
    Hiring_Date DATE
);

CREATE TABLE Employees (
    Emp_ID INT PRIMARY KEY,
    Email VARCHAR(30),
    F_Name VARCHAR(30),
    L_Name VARCHAR(30),
    Bouns DECIMAL(10, 2),
    [Address] VARCHAR(30),
    phone_num VARCHAR(20),
    Salary DECIMAL(10, 2),
    DateOfBirth DATE,
    Floor_Num INT,
    Super_ID INT,
    FOREIGN KEY (Floor_Num) REFERENCES [floor](Floor_num),
    FOREIGN KEY (Super_ID) REFERENCES employees(Emp_ID) -- Self-referencing relationship
);


ALTER TABLE [floor]
ADD CONSTRAINT fk_floor_manager 
FOREIGN KEY (Manger_ID) REFERENCES employees(Emp_ID);

--  Create 'User' table
CREATE TABLE User (
    SSN VARCHAR(50) PRIMARY KEY,
    Name VARCHAR(255),
    Email VARCHAR(255),
    Emp_ID INT,
    FOREIGN KEY (Emp_ID) REFERENCES employees(Emp_ID)
);

-------------------------------Part02-----------------------------------------
-- 1.Write a query that displays Full name of an employee who has more than 
--   3letters in his/her First Name. 

select CONCAT_WS(' ',Fname,Lname) AS [fullName]
from Employee
where LEN(Fname)>3

-- 2.Write a query to display the total number of Programming books 
--  available in the library with alias name ‘NO OF PROGRAMMING BOOKS’   

select COUNT(Cat_id) As 'NO OF PROGRAMMING BOOKS'
from Book
where Cat_id = (select Id from Category where id=1)

--3. Write a query to display the number of books published by(HarperCollins) 
--   with the alias name 'NO_OF_BOOKS'. 

select COUNT(Publisher_id) As 'NO_OF_BOOKS'
from Book
where Publisher_id = (select Id from Publisher where id=1)


-- 4. Write a query to display the User SSN and name, date of borrowing and due date of 
--  the User whose due date is before July 2022. {1 Point} 

SELECT SSN , [USER_NAME] , Borrow_date , Due_date
FROM Borrowing INNER JOIN Users
ON Users.SSN = Borrowing.User_ssn
WHERE Due_date < '07-01-2022'


-- 5.Write a query to display book title, author name and display in the 
--   following format, ' [Book Title] is written by [Author Name].

SELECT CONCAT_WS(' ' , BOOK.Title , 'Is Written By' , A.[Name]) As [Books with their author]
FROM Book JOIN Book_Author BA
ON BOOK.Id = BA.Book_id JOIN Author A
ON BA.Author_id = A.Id

-- 6. Write a query to display the name of users who have letter 'A' in their names.

select [User_Name]
from Users
where [User_Name]LIKE '%A%'

--  7. Write a query that display user SSN who makes the most borrowing 

Select User_ssn ,COUNT(User_ssn)
From Borrowing
Group by User_ssn
Order by COUNT(User_ssn) Desc

