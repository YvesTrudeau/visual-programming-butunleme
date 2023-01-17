-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Anamakine: 127.0.0.1:3306
-- Üretim Zamanı: 17 Oca 2023, 14:03:07
-- Sunucu sürümü: 8.0.31
-- PHP Sürümü: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Veritabanı: `emlaks`
--

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ilanlar`
--

DROP TABLE IF EXISTS `ilanlar`;
CREATE TABLE IF NOT EXISTS `ilanlar` (
  `sehir` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `ilce` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `adres` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `oda` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `durum` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `konut` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `metrekare` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `ısınma` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `kat` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `yapı` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `takas` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `yakıt` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `fiyat` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `ilanlar`
--

INSERT INTO `ilanlar` (`sehir`, `ilce`, `adres`, `oda`, `durum`, `konut`, `metrekare`, `ısınma`, `kat`, `yapı`, `takas`, `yakıt`, `fiyat`) VALUES
('bursa', 'gürsu', 'istiklal mh. fatih cd. no.189', '3+1', 'kiralık', 'müstakil ev', '500', 'kalorifer', '4', 'ikinci el', 'yok', 'doğalgaz', '5.000.000');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `musteri`
--

DROP TABLE IF EXISTS `musteri`;
CREATE TABLE IF NOT EXISTS `musteri` (
  `ad` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `soyad` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `ka` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `sf` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `posta` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `telefon` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `tc` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `musteri`
--

INSERT INTO `musteri` (`ad`, `soyad`, `ka`, `sf`, `posta`, `telefon`, `tc`) VALUES
('amet', 'ışık', '16bursa', '16', 'saatadam06@hotmail.com', '0537', '22966508918');

-- --------------------------------------------------------

--
-- Tablo için tablo yapısı `ygiris`
--

DROP TABLE IF EXISTS `ygiris`;
CREATE TABLE IF NOT EXISTS `ygiris` (
  `ad` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `soyad` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `ka` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `sf` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `posta` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `telefon` text COLLATE utf8mb4_unicode_ci NOT NULL,
  `tc` text COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Tablo döküm verisi `ygiris`
--

INSERT INTO `ygiris` (`ad`, `soyad`, `ka`, `sf`, `posta`, `telefon`, `tc`) VALUES
('Berat', 'Doğancı', '1', '1', 'mamaklı', '6874656', '22966508919');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
