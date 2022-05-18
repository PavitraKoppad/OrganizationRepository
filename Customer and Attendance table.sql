/*Create table employee (
emp_id INT PRIMARY KEY,
employee_name VARCHAR(40),
salary INT,
gendar VARCHAR(1),
) */

INSERT INTO EMPLOYEE VALUES(100,'John Mcaleff',250000,'M'),
(101,'Marry cuff',500000,'F'),
(102,'Dara Hickey',1000000,'M'),
(104,'Noirin',1000000,'F')

select * from employee

Create Table Attendance (
id INT PRIMARY KEY,
emp_id INT, 
date DATE,
attendance VARCHAR(1),  
FOREIGN KEY(emp_id) REFERENCES Employee(emp_id) ON DELETE SET NULL
)

INSERT INTO Attendance VALUES(1,100,'2022-05-12','P'),
(2,100,'2022-05-13','P'),
(3,101,'2022-05-12','A'),
(4,101,'2022-05-13','P'),
(5,102,'2022-05-12','P'),
(6,102,'2022-05-13','P'),
(7,104,'2022-05-12','A'),
(8,104,'2022-05-13','A')


select * from Attendance 

DROP tABLE Attendance


Create Table Leave (
id INT PRIMARY KEY,
emp_id INT,
date DATE,
manager_id INT,
LeaveType VARCHAR(30),  
FOREIGN KEY(emp_id) REFERENCES Employee(emp_id) ON DELETE SET NULL,
FOREIGN KEY(manager_id) REFERENCES Employee(emp_id)
)

INSERT INTO Leave VALUES(1,100,'2022-05-12',104,'Sick Leave'),
(2,101,'2022-05-12',104,'Casual Leave')
