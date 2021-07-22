-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 22 Jul 2021 pada 11.01
-- Versi server: 10.4.19-MariaDB
-- Versi PHP: 8.0.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbquiz_rizki_ali_akbar_pasaribu`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tobat`
--

CREATE TABLE `tobat` (
  `NIS` char(15) NOT NULL,
  `Nama` varchar(50) NOT NULL,
  `Alamat` varchar(100) NOT NULL,
  `Tempat_Lahir` varchar(50) NOT NULL,
  `Tgl_Lahir` varchar(50) NOT NULL,
  `Jenis_Kelamin` varchar(20) NOT NULL,
  `Agama` varchar(20) NOT NULL,
  `No_Telepon` char(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `tobat`
--

INSERT INTO `tobat` (`NIS`, `Nama`, `Alamat`, `Tempat_Lahir`, `Tgl_Lahir`, `Jenis_Kelamin`, `Agama`, `No_Telepon`) VALUES
('0102801', 'Rizki Ali Akbar Pasaribu', 'Sidikalang Asrama Polisi asdasd', 'Sidikalang', '7/1/2021', 'Laki-Laki', 'Islam', '082276568510'),
('0102802', 'Lutfhi Fahrul Rozy', 'Sidikalang', 'Sidikalang', '7/22/2021', 'Laki-Laki', 'Islam', '082272993622'),
('0102803', 'Wahyu Mahyudi Pratama', 'Madina', 'Medan', '6/15/2004', 'Laki-Laki', 'Khatolik', '09822321231');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `tobat`
--
ALTER TABLE `tobat`
  ADD PRIMARY KEY (`NIS`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
