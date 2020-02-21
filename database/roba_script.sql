CREATE DATABASE  IF NOT EXISTS `roba` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `roba`;
-- MySQL dump 10.13  Distrib 5.7.25, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: roba
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.37-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `roba20191220`
--

DROP TABLE IF EXISTS `roba20191220`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roba20191220` (
  `idRoba` int(11) NOT NULL AUTO_INCREMENT,
  `sifraProizvoda` varchar(100) DEFAULT NULL,
  `status` char(1) DEFAULT NULL,
  `tezina` int(11) DEFAULT NULL,
  `datumIsporuke` date DEFAULT NULL,
  PRIMARY KEY (`idRoba`),
  UNIQUE KEY `sifraProizvoda_UNIQUE` (`sifraProizvoda`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roba20191220`
--

LOCK TABLES `roba20191220` WRITE;
/*!40000 ALTER TABLE `roba20191220` DISABLE KEYS */;
INSERT INTO `roba20191220` VALUES (1,'A00001','A',150,'2019-12-12'),(2,'A00002','B',140,'2019-12-12'),(3,'A00003','C',160,'2019-12-12'),(4,'A00004','A',110,'2019-12-12'),(5,'A00005','B',100,'2019-12-12'),(6,'A00006','C',190,'2019-12-14'),(7,'A00007','A',250,'2019-12-14'),(8,'A00008','A',50,'2019-12-14'),(9,'A00009','B',80,'2019-12-14'),(10,'A00010','B',155,'2019-12-15'),(11,'A00011','A',170,'2019-12-15'),(12,'A00012','C',40,'2019-12-15'),(13,'A00013','A',20,'2019-12-15'),(14,'A00014','B',350,'2019-12-16');
/*!40000 ALTER TABLE `roba20191220` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `robanapomene20191220`
--

DROP TABLE IF EXISTS `robanapomene20191220`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `robanapomene20191220` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idRoba` int(11) NOT NULL,
  `Napomena` varchar(2000) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `robanapomene20191220_ibfk_1` (`idRoba`),
  CONSTRAINT `robanapomene20191220_ibfk_1` FOREIGN KEY (`idRoba`) REFERENCES `roba20191220` (`idRoba`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `robanapomene20191220`
--

LOCK TABLES `robanapomene20191220` WRITE;
/*!40000 ALTER TABLE `robanapomene20191220` DISABLE KEYS */;
INSERT INTO `robanapomene20191220` VALUES (1,1,'Napomena a'),(2,1,'Napomena b'),(3,2,'Napomena c'),(4,3,'Napomena d'),(5,4,'Napomena e'),(6,4,'Napomena f'),(7,5,'Napomena g'),(8,6,'Napomena h'),(9,7,'Napomena i'),(10,7,'Napomena j'),(11,9,'Napomena k'),(12,9,'Napomena l'),(13,11,'Napomena m'),(14,12,'Napomena n'),(15,13,'Napomena o'),(16,14,'Napomena p');
/*!40000 ALTER TABLE `robanapomene20191220` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'roba'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-21 14:33:41
