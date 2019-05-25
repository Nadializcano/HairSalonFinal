-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 25, 2019 at 05:54 PM
-- Server version: 5.7.25
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `Nadia_lizcano`
--
CREATE DATABASE IF NOT EXISTS `Nadia_lizcano` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `Nadia_lizcano`;

-- --------------------------------------------------------

--
-- Table structure for table `Clients`
--

CREATE TABLE `Clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `stylist_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Clients`
--

INSERT INTO `Clients` (`id`, `name`, `stylist_id`) VALUES
(125, 'Pris', 17),
(126, 'Pris', 17);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `description`) VALUES
(3, 'haircut'),
(6, 'Balayage'),
(7, 'Hair Design'),
(8, 'Makeup'),
(9, 'Highlights'),
(10, 'haircut');

-- --------------------------------------------------------

--
-- Table structure for table `specialties_stylist`
--

CREATE TABLE `specialties_stylist` (
  `id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties_stylist`
--

INSERT INTO `specialties_stylist` (`id`, `specialty_id`, `stylist_id`) VALUES
(1, 1, 14),
(2, 1, 13),
(3, 2, 13),
(4, 3, 14),
(5, 3, 13),
(6, 2, 14),
(7, 3, 15),
(8, 4, 13),
(9, 2, 15),
(10, 4, 15),
(11, 4, 14),
(12, 6, 14),
(13, 6, 13),
(14, 6, 15),
(15, 7, 13),
(16, 3, 13),
(17, 7, 13),
(18, 0, 0),
(19, 7, 15),
(20, 9, 14),
(21, 8, 14),
(22, 3, 16),
(23, 6, 16),
(24, 8, 16),
(25, 3, 17);

-- --------------------------------------------------------

--
-- Table structure for table `Stylist`
--

CREATE TABLE `Stylist` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `client_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `Stylist`
--

INSERT INTO `Stylist` (`id`, `name`, `client_id`) VALUES
(17, 'Jon', NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `Clients`
--
ALTER TABLE `Clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties_stylist`
--
ALTER TABLE `specialties_stylist`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `Stylist`
--
ALTER TABLE `Stylist`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `Clients`
--
ALTER TABLE `Clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=127;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `specialties_stylist`
--
ALTER TABLE `specialties_stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=26;

--
-- AUTO_INCREMENT for table `Stylist`
--
ALTER TABLE `Stylist`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
