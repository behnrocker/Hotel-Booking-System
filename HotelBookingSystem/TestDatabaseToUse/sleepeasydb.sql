-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Apr 22, 2016 at 09:01 PM
-- Server version: 10.1.10-MariaDB
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `sleepeasydb`
--

-- --------------------------------------------------------

--
-- Table structure for table `bill`
--

CREATE TABLE `bill` (
  `billID` int(10) NOT NULL,
  `customerID` int(10) DEFAULT NULL,
  `roomTypeID` int(10) DEFAULT NULL,
  `isPaid` varchar(1) DEFAULT NULL,
  `totalPrice` varchar(10) DEFAULT NULL,
  `reservationID` int(10) DEFAULT NULL,
  `roomServiceID` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bill`
--

INSERT INTO `bill` (`billID`, `customerID`, `roomTypeID`, `isPaid`, `totalPrice`, `reservationID`, `roomServiceID`) VALUES
(1, 1, 1, '0', '100.00', 1, 1),
(2, 2, 2, '1', '200.00', 2, 2),
(3, 3, 3, '0', '300.00', 3, 3);

-- --------------------------------------------------------

--
-- Table structure for table `creditcard`
--

CREATE TABLE `creditcard` (
  `cardNumber` int(20) NOT NULL,
  `customerID` int(10) DEFAULT NULL,
  `csvNumber` int(10) DEFAULT NULL,
  `expiryDate` datetime DEFAULT NULL,
  `nameOnCard` varchar(80) DEFAULT NULL,
  `cardType` varchar(80) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `customerID` int(10) NOT NULL,
  `firstName` varchar(40) DEFAULT NULL,
  `lastName` varchar(40) DEFAULT NULL,
  `streetAddress` varchar(60) DEFAULT NULL,
  `city` varchar(30) DEFAULT NULL,
  `province` varchar(50) DEFAULT NULL,
  `postalCode` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`customerID`, `firstName`, `lastName`, `streetAddress`, `city`, `province`, `postalCode`) VALUES
(1, 'Hope T.', 'Hisworks', '36 Test St.', 'Charlottetown', 'PEI', 'c1a 5z3'),
(2, 'Behn', 'McIlwaine', '36 Beasley Ave.', 'Charlottetown', 'PEI', 'c1a 5z3'),
(3, 'Ric', 'Flair', '360 Woo St.', 'Woooooo', 'WOO', 'W0O 0O0'),
(4, 'Pleasework', 'Pleaseplease', '28 Test Ave.', 'Testville', 'ON', '8d0w7f');

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `employeeID` int(10) NOT NULL,
  `firstName` varchar(40) DEFAULT NULL,
  `lastName` varchar(40) DEFAULT NULL,
  `streetAddress` varchar(60) DEFAULT NULL,
  `city` varchar(30) DEFAULT NULL,
  `province` varchar(50) DEFAULT NULL,
  `postalCode` varchar(10) DEFAULT NULL,
  `title` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`employeeID`, `firstName`, `lastName`, `streetAddress`, `city`, `province`, `postalCode`, `title`) VALUES
(1, 'Adminny', 'Adminnerson', '36 Beasley Ave.', 'Charlottetown', 'PEI', 'C1A 5Z3', 'Admin'),
(2, 'John', 'Smith', '369 Beasley Ave.', 'Charlottetown', 'PEI', 'C1A 5Z5', 'User'),
(3, 'Greyson', 'Nootenboom', '255 Test Ave.', 'Cornwall', 'PEI', 'C1A 2J4', 'User');

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `reservationID` int(10) NOT NULL,
  `customerID` int(10) DEFAULT NULL,
  `checkInDate` datetime DEFAULT NULL,
  `checkOutDate` datetime DEFAULT NULL,
  `roomNumber` int(10) DEFAULT NULL,
  `checkedIn` varchar(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`reservationID`, `customerID`, `checkInDate`, `checkOutDate`, `roomNumber`, `checkedIn`) VALUES
(1, 1, '2016-05-20 12:00:00', '2016-05-22 12:00:00', 262, '0'),
(2, 2, '2016-04-20 12:00:00', '2016-04-22 12:00:00', 307, '0'),
(3, 1, '2016-06-20 12:00:00', '2016-06-22 12:00:00', 552, '0'),
(4, 3, '2016-07-20 12:00:00', '2016-07-22 12:00:00', 307, '1'),
(5, 2, '2016-07-20 12:00:00', '2016-07-22 12:00:00', 305, '1'),
(6, 2, '2016-04-22 14:33:30', '2016-04-24 14:33:30', 157, '0');

-- --------------------------------------------------------

--
-- Table structure for table `room`
--

CREATE TABLE `room` (
  `roomNumber` int(10) NOT NULL,
  `roomTypeID` int(10) DEFAULT NULL,
  `roomFloor` int(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `room`
--

INSERT INTO `room` (`roomNumber`, `roomTypeID`, `roomFloor`) VALUES
(157, 0, 1),
(166, 0, 1),
(262, 0, 2),
(377, 1, 3),
(616, 1, 6),
(716, 2, 7),
(733, 1, 7),
(826, 2, 8),
(828, 1, 9),
(829, 2, 9);

-- --------------------------------------------------------

--
-- Table structure for table `roomservice`
--

CREATE TABLE `roomservice` (
  `roomServiceID` int(10) NOT NULL,
  `itemOrdered` varchar(255) DEFAULT NULL,
  `customerID` int(10) DEFAULT NULL,
  `roomNumber` int(10) DEFAULT NULL,
  `specialInstructions` varchar(255) DEFAULT NULL,
  `totalPrice` int(20) DEFAULT NULL,
  `timeOrderedFor` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `roomservice`
--

INSERT INTO `roomservice` (`roomServiceID`, `itemOrdered`, `customerID`, `roomNumber`, `specialInstructions`, `totalPrice`, `timeOrderedFor`) VALUES
(1, 'French Fries', 1, 322, 'Extra salty', 6, '2016-05-20 16:44:25'),
(2, 'Hamburger', 2, 527, 'Only lettuce, onion, mayo', 9, '2016-06-20 12:44:25'),
(3, 'Massage', 3, 422, 'Extra salty', 60, '2016-04-20 20:44:25'),
(4, 'Cheeseburger', 3, 0, 'Extra cheese', 999, '0001-01-01 00:00:00'),
(5, 'Cheeseburger', 3, 0, 'ljbljb', 333, '0001-01-01 00:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `roomtype`
--

CREATE TABLE `roomtype` (
  `roomTypeID` int(10) NOT NULL,
  `bedSize` varchar(6) DEFAULT NULL,
  `numberOfBeds` int(3) DEFAULT NULL,
  `availability` varchar(1) DEFAULT NULL,
  `specialItems` varchar(255) DEFAULT NULL,
  `billAmount` int(20) DEFAULT NULL,
  `maxCapacity` int(3) DEFAULT NULL,
  `type` varchar(60) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bill`
--
ALTER TABLE `bill`
  ADD PRIMARY KEY (`billID`);

--
-- Indexes for table `creditcard`
--
ALTER TABLE `creditcard`
  ADD PRIMARY KEY (`cardNumber`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`customerID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`employeeID`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`reservationID`);

--
-- Indexes for table `room`
--
ALTER TABLE `room`
  ADD PRIMARY KEY (`roomNumber`);

--
-- Indexes for table `roomservice`
--
ALTER TABLE `roomservice`
  ADD PRIMARY KEY (`roomServiceID`);

--
-- Indexes for table `roomtype`
--
ALTER TABLE `roomtype`
  ADD PRIMARY KEY (`roomTypeID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
