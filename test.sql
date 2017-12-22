-- phpMyAdmin SQL Dump
-- version 2.10.3
-- http://www.phpmyadmin.net
-- 
-- Host: localhost
-- Generation Time: Nov 09, 2017 at 04:26 AM
-- Server version: 5.0.51
-- PHP Version: 5.2.6

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";

-- 
-- Database: `test`
-- 

-- --------------------------------------------------------

-- 
-- Table structure for table `laporan`
-- 

CREATE TABLE `laporan` (
  `tanggal` date NOT NULL,
  `paket` varchar(10) NOT NULL,
  `durasi` int(5) NOT NULL,
  `harga` int(10) NOT NULL,
  `total_mkn` int(10) NOT NULL,
  `total_mnm` int(10) NOT NULL,
  `total_semua` int(20) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table `laporan`
-- 

INSERT INTO `laporan` VALUES ('2017-03-08', 'Small', 1, 50000, 0, 0, 50000);
INSERT INTO `laporan` VALUES ('2017-03-08', 'Small', 1, 85000, 30000, 20000, 135000);
INSERT INTO `laporan` VALUES ('2017-03-12', 'Small', 2, 150000, 0, 0, 150000);

-- --------------------------------------------------------

-- 
-- Table structure for table `pengguna`
-- 

CREATE TABLE `pengguna` (
  `kode` varchar(10) NOT NULL,
  `nama` varchar(20) NOT NULL,
  `alamat` varchar(20) NOT NULL,
  `hp` int(12) NOT NULL,
  `foto` varchar(200) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table `pengguna`
-- 

INSERT INTO `pengguna` VALUES ('B001', 'Aspin', 'Trika', 2147483647, 'C:\\Users\\NDIAPPINK\\Documents\\Visual Studio 2010\\Projects\\Disco\\Disco\\bin\\Debug\\member\\aspin.jpg');
INSERT INTO `pengguna` VALUES ('B002', 'Ikbal', 'BTP', 987654321, 'C:\\Users\\NDIAPPINK\\Documents\\Visual Studio 2010\\Projects\\Disco\\Disco\\bin\\Debug\\member\\ikbal.jpg');
