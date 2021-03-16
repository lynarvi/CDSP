-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Feb 07, 2021 at 11:52 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cdsp`
--

-- --------------------------------------------------------

--
-- Table structure for table `log`
--

CREATE TABLE `log` (
  `logid` int(11) NOT NULL,
  `speechVoice` varchar(50) NOT NULL,
  `date_created` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `log`
--

INSERT INTO `log` (`logid`, `speechVoice`, `date_created`) VALUES
(1, 'I Want To Drink', '2021-02-07'),
(2, 'I Want To Drink', '2021-03-07'),
(3, 'I Want To Eat', '2021-03-07'),
(4, 'I Want To Pee', '2021-02-07'),
(5, 'I Want To Drink', '2021-02-07'),
(6, 'I Want To Eat', '2021-02-07'),
(7, 'I Want To Pee', '2021-02-07'),
(8, 'I Want To Poop', '2021-02-07'),
(9, 'I Want To Sit', '2021-02-07'),
(10, 'I Want To Sleep', '2021-02-07'),
(11, 'I Love you', '2021-02-07'),
(12, 'Kisses Please', '2021-02-07'),
(13, 'Hugs Please', '2021-02-07'),
(14, 'Thank you So much', '2021-02-07'),
(15, 'Stay Please', '2021-02-07'),
(16, 'I Miss you so Much', '2021-02-07');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `log`
--
ALTER TABLE `log`
  ADD PRIMARY KEY (`logid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `log`
--
ALTER TABLE `log`
  MODIFY `logid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
