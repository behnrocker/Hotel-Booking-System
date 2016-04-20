DROP USER IF EXISTS 'admin'@'localhost';

CREATE USER 'admin'@'localhost' IDENTIFIED BY 'admin';

GRANT ALL PRIVILEGES ON * . * TO 'admin'@'localhost';

FLUSH PRIVILEGES;

DROP DATABASE IF EXISTS SleepEasyDB;

CREATE DATABASE SleepEasyDB;

use SleepEasyDB;

DROP TABLE IF EXISTS Employee;

DROP TABLE IF EXISTS Customer;

DROP TABLE IF EXISTS Reservation;

DROP TABLE IF EXISTS Room;

DROP TABLE IF EXISTS RoomType;

DROP TABLE IF EXISTS Bill;

DROP TABLE IF EXISTS RoomService;

DROP TABLE IF EXISTS CreditCard;

CREATE TABLE Employee (employeeID INT(10) PRIMARY KEY, firstName VARCHAR(40), lastName VARCHAR(40), streetAddress VARCHAR(60), city VARCHAR(30), province VARCHAR(50), postalCode VARCHAR(10), title VARCHAR(60));

CREATE TABLE Customer (customerID INT(10) PRIMARY KEY, firstName VARCHAR(40), lastName VARCHAR(40), streetAddress VARCHAR(60), city VARCHAR(30), province VARCHAR(50), postalCode VARCHAR(10));

CREATE TABLE Reservation (reservationID INT(10) PRIMARY KEY, customerID INT(10), checkInDate DATETIME, checkOutDate DATETIME, roomNumber INT(10));

CREATE TABLE Room (roomNumber INT(10) PRIMARY KEY, roomTypeID INT(10), roomFloor INT(3));

CREATE TABLE RoomType (roomTypeID INT(10) PRIMARY KEY, bedSize VARCHAR(6), numberOfBeds INT(3), availability VARCHAR(1), specialItems VARCHAR(255), billAmount INT(20), maxCapacity INT(3), type VARCHAR(60));

CREATE TABLE Bill (billID INT(10) PRIMARY KEY, customerID INT(10), roomTypeID INT(10), isPaid VARCHAR(1), totalPrice VARCHAR(10), reservationID INT(10), roomServiceID INT(10));

CREATE TABLE RoomService (roomServiceID INT(10) PRIMARY KEY, itemOrdered VARCHAR(255), customerID INT(10), roomNumber INT(10), specialInstructions VARCHAR(255), totalPrice INT(20), timeOrderedFor DATETIME);

CREATE TABLE CreditCard (cardNumber INT(20) PRIMARY KEY, customerID INT(10), csvNumber INT(10), expiryDate DATETIME, nameOnCard VARCHAR(80), cardType VARCHAR(80));