
CREATE DATABASE  IF NOT EXISTS `ex2` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ex2`;
-- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
--
-- Host: 127.0.0.1    Database: ex2
-- ------------------------------------------------------
-- Server version	8.0.16

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
-- Table structure for table `Actors`
--

DROP TABLE IF EXISTS `Actors`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Actors` (
  `series-name` varchar(50) DEFAULT NULL,
  `actor-name` varchar(50) NOT NULL,
  PRIMARY KEY (`actor-name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Actors`
--

LOCK TABLES `Actors` WRITE;
/*!40000 ALTER TABLE `Actors` DISABLE KEYS */;
INSERT INTO `Actors` VALUES ('3%','Camparato'),('Money Heist','Corbero'),('Breaking Bad','Cranston'),('Fauda','Eido'),('Fauda','Garty'),('Fauda','Halevi'),('How I Met Your Mother','Hannigan'),('Money Heist','Ituno'),('13 Reasons Why','Langford'),('13 Reasons Why','Minnette'),('Money Heist','Morte'),('How I Met Your Mother','Patrick-Harris'),('Fauda','Raz'),('Chambers','Rose'),('Stranger Things','Ryder'),('How I Met Your Mother','Segel'),('Chambers','Thurman');
/*!40000 ALTER TABLE `Actors` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Genres`
--

DROP TABLE IF EXISTS `Genres`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Genres` (
  `series-name` varchar(50) NOT NULL,
  `genre` text,
  `language` text,
  PRIMARY KEY (`series-name`),
  UNIQUE KEY `series-name_UNIQUE` (`series-name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Genres`
--

LOCK TABLES `Genres` WRITE;
/*!40000 ALTER TABLE `Genres` DISABLE KEYS */;
INSERT INTO `Genres` VALUES ('13 Reasons Why','Drama','EN'),('3%','Sci-Fi','PT'),('Breaking Bad','Crime','EN'),('Chambers','Horror','EN'),('Dogs Of Berlin','Crime','DE'),('Fauda','Action','HE'),('How I Met Your Mother','Comedy','EN'),('Money Heist','Action','ES'),('Rick & Morty','Animation','EN'),('Stranger Things','Sci-Fi','EN');
/*!40000 ALTER TABLE `Genres` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Salaries`
--

DROP TABLE IF EXISTS `Salaries`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Salaries` (
  `actor-name` varchar(50) NOT NULL,
  `age` int(11) DEFAULT NULL,
  `salary` double DEFAULT NULL,
  PRIMARY KEY (`actor-name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Salaries`
--

LOCK TABLES `Salaries` WRITE;
/*!40000 ALTER TABLE `Salaries` DISABLE KEYS */;
INSERT INTO `Salaries` VALUES ('Camparato',34,0.8),('Corbero',30,1),('Cranston',63,3),('Garty',39,0.7),('Hannigan',45,5),('Langford',23,3),('Minnette',23,2.6),('Morte',44,1.2),('Patrick-Harris',46,5),('Raz',48,1),('Roiland',39,2),('Rose',20,2.8),('Ryder',48,3.5),('Segel',39,5);
/*!40000 ALTER TABLE `Salaries` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Seasons`
--

DROP TABLE IF EXISTS `Seasons`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Seasons` (
  `series-name` varchar(50) NOT NULL,
  `release-year` int(11) DEFAULT NULL,
  `num-of-seasons` int(11) DEFAULT NULL,
  PRIMARY KEY (`series-name`),
  UNIQUE KEY `series-name_UNIQUE` (`series-name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Seasons`
--

LOCK TABLES `Seasons` WRITE;
/*!40000 ALTER TABLE `Seasons` DISABLE KEYS */;
INSERT INTO `Seasons` VALUES ('13 Reasons Why',2017,3),('3%',2016,3),('Breaking Bad',2008,5),('Chambers',2019,1),('Dogs Of Berlin',2018,1),('Fauda',2015,3),('How I Met Your Mother',2005,9),('Money Heist',2017,3),('Rick & Morty',2013,4),('Stranger Things',2016,3);
/*!40000 ALTER TABLE `Seasons` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-05-22 15:42:40
GO

--Syntax Error: Incorrect syntax near `.
--CREATE DATABASE  IF NOT EXISTS `ex2` /*!40100 DEFAULT CHARACTER SET utf8 */ /*!80016 DEFAULT ENCRYPTION='N' */;
--USE `ex2`;
---- MySQL dump 10.13  Distrib 5.7.17, for macos10.12 (x86_64)
----
---- Host: 127.0.0.1    Database: ex2
---- ------------------------------------------------------
---- Server version	8.0.16
--
--/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
--/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
--/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
--/*!40101 SET NAMES utf8 */;
--/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
--/*!40103 SET TIME_ZONE='+00:00' */;
--/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
--/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
--/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
--/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
--
----
---- Table structure for table `Actors`
----
--
--DROP TABLE IF EXISTS `Actors`;
--/*!40101 SET @saved_cs_client     = @@character_set_client */;
--/*!40101 SET character_set_client = utf8 */;
--CREATE TABLE `Actors` (
--  `series-name` varchar(50) DEFAULT NULL,
--  `actor-name` varchar(50) NOT NULL,
--  PRIMARY KEY (`actor-name`)
--) ENGINE=InnoDB DEFAULT CHARSET=utf8;
--/*!40101 SET character_set_client = @saved_cs_client */;
--
----
---- Dumping data for table `Actors`
----
--
--LOCK TABLES `Actors` WRITE;
--/*!40000 ALTER TABLE `Actors` DISABLE KEYS */;
--INSERT INTO `Actors` VALUES ('3%','Camparato'),('Money Heist','Corbero'),('Breaking Bad','Cranston'),('Fauda','Eido'),('Fauda','Garty'),('Fauda','Halevi'),('How I Met Your Mother','Hannigan'),('Money Heist','Ituno'),('13 Reasons Why','Langford'),('13 Reasons Why','Minnette'),('Money Heist','Morte'),('How I Met Your Mother','Patrick-Harris'),('Fauda','Raz'),('Chambers','Rose'),('Stranger Things','Ryder'),('How I Met Your Mother','Segel'),('Chambers','Thurman');
--/*!40000 ALTER TABLE `Actors` ENABLE KEYS */;
--UNLOCK TABLES;
--
----
---- Table structure for table `Genres`
----
--
--DROP TABLE IF EXISTS `Genres`;
--/*!40101 SET @saved_cs_client     = @@character_set_client */;
--/*!40101 SET character_set_client = utf8 */;
--CREATE TABLE `Genres` (
--  `series-name` varchar(50) NOT NULL,
--  `genre` text,
--  `language` text,
--  PRIMARY KEY (`series-name`),
--  UNIQUE KEY `series-name_UNIQUE` (`series-name`)
--) ENGINE=InnoDB DEFAULT CHARSET=utf8;
--/*!40101 SET character_set_client = @saved_cs_client */;
--
----
---- Dumping data for table `Genres`
----
--
--LOCK TABLES `Genres` WRITE;
--/*!40000 ALTER TABLE `Genres` DISABLE KEYS */;
--INSERT INTO `Genres` VALUES ('13 Reasons Why','Drama','EN'),('3%','Sci-Fi','PT'),('Breaking Bad','Crime','EN'),('Chambers','Horror','EN'),('Dogs Of Berlin','Crime','DE'),('Fauda','Action','HE'),('How I Met Your Mother','Comedy','EN'),('Money Heist','Action','ES'),('Rick & Morty','Animation','EN'),('Stranger Things','Sci-Fi','EN');
--/*!40000 ALTER TABLE `Genres` ENABLE KEYS */;
--UNLOCK TABLES;
--
----
---- Table structure for table `Salaries`
----
--
--DROP TABLE IF EXISTS `Salaries`;
--/*!40101 SET @saved_cs_client     = @@character_set_client */;
--/*!40101 SET character_set_client = utf8 */;
--CREATE TABLE `Salaries` (
--  `actor-name` varchar(50) NOT NULL,
--  `age` int(11) DEFAULT NULL,
--  `salary` double DEFAULT NULL,
--  PRIMARY KEY (`actor-name`)
--) ENGINE=InnoDB DEFAULT CHARSET=utf8;
--/*!40101 SET character_set_client = @saved_cs_client */;
--
----
---- Dumping data for table `Salaries`
----
--
--LOCK TABLES `Salaries` WRITE;
--/*!40000 ALTER TABLE `Salaries` DISABLE KEYS */;
--INSERT INTO `Salaries` VALUES ('Camparato',34,0.8),('Corbero',30,1),('Cranston',63,3),('Garty',39,0.7),('Hannigan',45,5),('Langford',23,3),('Minnette',23,2.6),('Morte',44,1.2),('Patrick-Harris',46,5),('Raz',48,1),('Roiland',39,2),('Rose',20,2.8),('Ryder',48,3.5),('Segel',39,5);
--/*!40000 ALTER TABLE `Salaries` ENABLE KEYS */;
--UNLOCK TABLES;
--
----
---- Table structure for table `Seasons`
----
--
--DROP TABLE IF EXISTS `Seasons`;
--/*!40101 SET @saved_cs_client     = @@character_set_client */;
--/*!40101 SET character_set_client = utf8 */;
--CREATE TABLE `Seasons` (
--  `series-name` varchar(50) NOT NULL,
--  `release-year` int(11) DEFAULT NULL,
--  `num-of-seasons` int(11) DEFAULT NULL,
--  PRIMARY KEY (`series-name`),
--  UNIQUE KEY `series-name_UNIQUE` (`series-name`)
--) ENGINE=InnoDB DEFAULT CHARSET=utf8;
--/*!40101 SET character_set_client = @saved_cs_client */;
--
----
---- Dumping data for table `Seasons`
----
--
--LOCK TABLES `Seasons` WRITE;
--/*!40000 ALTER TABLE `Seasons` DISABLE KEYS */;
--INSERT INTO `Seasons` VALUES ('13 Reasons Why',2017,3),('3%',2016,3),('Breaking Bad',2008,5),('Chambers',2019,1),('Dogs Of Berlin',2018,1),('Fauda',2015,3),('How I Met Your Mother',2005,9),('Money Heist',2017,3),('Rick & Morty',2013,4),('Stranger Things',2016,3);
--/*!40000 ALTER TABLE `Seasons` ENABLE KEYS */;
--UNLOCK TABLES;
--/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
--
--/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
--/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
--/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
--/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
--/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
--/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
--/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
--
---- Dump completed on 2019-05-22 15:42:40



GO
