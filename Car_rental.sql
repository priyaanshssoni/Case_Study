Use Car_rental

Create Database Car_rental

Create Table Vehicle
(
    vehicleID int not null IDENTITY(1,1) primary key,
    make varchar(50) not null,
    model varchar(50) not null,
    [year] int  not null ,
    dailyRate varchar(50),
    [status] varchar(50) not null CHECK ([status] IN ('available', 'not available')),
    passengerCapacity int not null ,
    engineCapacity int not null ,
)
--
Create Table Customer(
    customerID int not null IDENTITY(1,1) PRIMARY key,
    firstName varchar(50) not null,
    lastName varchar(50) not null,
    email varchar(50) not null,
    phoneNumber bigint not null,
)

---

Create Table Lease(
    leaseID int not null PRIMARY KEY IDENTITY(1,1),
    vehicleID int not null CONSTRAINT FK_Lease_vehicleID FOREIGN KEY (vehicleID) REFERENCES Vehicle(vehicleID) on delete cascade on update cascade,
    customerID int not null CONSTRAINT FK_Lease_customerID FOREIGN KEY (customerID) REFERENCES Customer(customerID) on delete cascade on update cascade,
    startdate varchar(50) not null,
    endDate varchar(50) not null,
    [type] varchar(50) not null CHECK ([type] IN ('DailyLease', 'MonthlyLease'))
)



---

Create Table Payment (
    paymentID int not null IDENTITY(1,1) primary key,
    leaseID int not null CONSTRAINT FK_Payment_leaseID FOREIGN KEY (leaseID) REFERENCES Lease(leaseID) on delete cascade on update cascade,
    paymentDate varchar(50) not null,
    amount int not null
)


-- sample records
INSERT INTO vehicle VALUES 
('Ford','Vista',2020,1000,'Available',4,1500),
('Maruti','Swift',2024,1500,'Not Available',4,1800),
('Maruti','Ertiga',2024,1800,'Available',7,2300)

INSERT INTO customer VALUES 
('Mr. Rajesh','Agrawal','rajesh12@example.com',9485827456),
('Mr. Suresh','Dalotia','suresh2@example.com',9283745678),
('Mr. Pranjal','Kamra','pk2@example.com',9854385967)


INSERT INTO Lease VALUES 
(1,2,'2024-01-03','2024-01-09','DailyLease'),
(2,1,'2024-01-15','2024-02-16','MonthlyLease'),
(3,3,'2024-03-19','2024-03-20','DailyLease')

Insert into Payment values
(1,'2024-01-09',5000 ),
(2,'2024-02-16',54000 ),
(3,'2024-03-20',2300 )