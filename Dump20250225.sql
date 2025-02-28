CREATE DATABASE  IF NOT EXISTS `prototype` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `prototype`;
-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: prototype
-- ------------------------------------------------------
-- Server version	8.0.37

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categories`
--

DROP TABLE IF EXISTS `categories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categories` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name_UNIQUE` (`name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categories`
--

LOCK TABLES `categories` WRITE;
/*!40000 ALTER TABLE `categories` DISABLE KEYS */;
INSERT INTO `categories` VALUES (1,'3д модель'),(2,'Анимация'),(4,'Визуальные эффекты'),(3,'Звуковые эффекты'),(7,'Окружение'),(8,'Плагины'),(5,'Пользовательский интерфейс'),(6,'Шаблоны игр');
/*!40000 ALTER TABLE `categories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resources`
--

DROP TABLE IF EXISTS `resources`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resources` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(500) NOT NULL,
  `picture` varchar(200) NOT NULL,
  `price` float DEFAULT NULL,
  `category` int NOT NULL,
  `created_by` int NOT NULL,
  `publication_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `category_idx` (`category`),
  KEY `created_by_idx` (`created_by`),
  CONSTRAINT `category` FOREIGN KEY (`category`) REFERENCES `categories` (`id`),
  CONSTRAINT `created_by` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources`
--

LOCK TABLES `resources` WRITE;
/*!40000 ALTER TABLE `resources` DISABLE KEYS */;
INSERT INTO `resources` VALUES (1,'Blockout Starter Pack','Этот набор ресурсов включает в себя несколько примитивов, модульные ресурсы, реквизит, материалы и декали, которые облегчают блокировку уровня в Unreal Engine.','https://media.fab.com/image_previews/gallery_images/d53680c7-5ef0-4532-9388-2d767cad0779/e6ed8506-fa5c-4121-860c-705b55e7ea5a.jpg',600,1,1,'2025-02-24'),(2,'MC Sample Pack','Это коллекция из более чем 100 реалистичных анимаций, которые придадут жизни и правдоподобия персонажам вашего проекта. Мы получили удовольствие от выступлений в этом наборе! Множество вариаций - от колдовства с помощью Книги заклинаний до шатания в пьяном виде, игры на пианино или даже катания на воображаемой лошади (из классического британского фильма).','https://media.fab.com/image_previews/gallery_images/f367acb5-e4ff-4d0a-abd6-36a8701279d7/b5c54668-a011-4e83-805c-81a089685027.jpg',1099,2,1,'2025-02-24'),(3,'Sound Phenomenon Fantasy Orchestra','Коллекция оркестровой музыки, созданной для создания настроения в играх в жанре фэнтези и мрачного фэнтези. Включено 9 треков.','https://media.fab.com/image_previews/gallery_images/43e75514-7d47-4dd5-95eb-72b41ac02512/12749ac6-9fab-4695-82aa-34ca73a6a070.jpg',499,3,3,'2025-02-19'),(4,'Realistic Starter VFX Pack Vol 2','Этот пакет призван облегчить вам жизнь, когда вы начинаете свой собственный проект, и содержит все эффекты, необходимые для начала разработки и создания прототипов.','https://media.fab.com/image_previews/gallery_images/20cb4247-9a93-41c3-b66a-4e0bdcbe75df/17a2ffc9-a22e-4fc1-aa60-0db69a8e45e4.jpg',899,4,2,'2023-05-18'),(5,'Essential Elements SFX Pack','Essential Elements SFX - это коллекция из 8 типов звуковых материалов и обработанных эффектов для повышения четкости, которая также подходит для экспериментального звукового дизайна. Тип материалов: Воздух -Электричество - Огонь - Лед - Металл - Камни - Вода - Дерево.','https://media.fab.com/image_previews/gallery_images/7b1e705f-d8f1-40ba-9ad9-3777da07097c/6458d1c5-5d65-4317-bbfa-7919206e7be8.jpg',399,3,2,'2023-05-17'),(6,'Fire VDB Pack Loop','Fire VDB Effects Pack - это обширная коллекция высококачественных циклических огненных эффектов.','https://media.fab.com/image_previews/gallery_images/34ac62c3-13df-4546-8dda-b32d842e920a/02ca05e7-ac48-43a1-8bb4-1b535b688d5e.jpg',1199,4,3,'2024-07-21'),(7,'Simple Inventory System','Этот плагин предоставляет простое и эффективное решение для управления предметами в ваших играх. Он позволяет игрокам собирать, хранить и упорядочивать предметы, чтобы вы могли легко взаимодействовать с их инвентарем. Идеально подходящий для проектов, требующих отслеживания предметов, этот плагин упрощает сбор, использование и управление ресурсами в ваших играх, обеспечивая при этом прочную основу для более расширенной функциональности.','https://media.fab.com/image_previews/gallery_images/c32d056a-1401-4376-a508-6b834300b1b4/746460c5-f00f-4e36-b67f-b456e5887fea.jpg',1599,8,2,'2022-12-01'),(8,'Primitive Characters (Pack)','В наборе вы найдете мужчину, женщину, ребенка, дедушку и бабушку. У персонажа немного изменилось выражение лица и немного оружия.','https://media.fab.com/image_previews/gallery_images/d24db3f8-fa19-404b-8548-55a93037b7b7/e80045cd-5a06-4495-adcf-79292806ab78.jpg',1399,1,2,'2025-01-03'),(9,'Essentials Icon Pack - PC','В этом наборе более 1500 значков кнопок для ПК. В настоящее время доступно 3 темы оформления в 6 различных разрешениях.','https://media.fab.com/image_previews/gallery_images/6dfb8418-b014-420c-9a9d-0962dda93fb0/ea113f92-c1fd-4510-9c21-bf572866e1ed.jpg',699,5,1,'2025-01-04'),(10,'TAR-21 Assault Rifle','Высококачественная модель автомата с 4K PBR текстурами для максимальной детализации','https://media.fab.com/image_previews/gallery_images/978640d0-b03a-4877-a7c0-1ad8923858ad/80520f02-3d34-43d2-85e9-42fd14ef6aad.jpg',2099,1,2,'2025-01-08'),(11,'Viking','Игровая 3d-модель персонажа викинга была создана в соответствии с моей концепцией и анимирована для unreal engine. Эта модель идеально подходит для фэнтезийных и RPG игр.','https://media.fab.com/image_previews/gallery_images/9f5c0251-8861-4bc0-a527-0538816f55d7/c9590d31-08a4-426c-b70b-3b8d8cdf7381.jpg',3099,1,2,'2025-01-09'),(12,'Character Interaction Add-On Vol.01','Набор анимаций взаимодействия персонажа с различными объектами','https://media.fab.com/image_previews/gallery_images/be4021cf-622a-410c-ab95-82d50eb3aab7/75eaf6ff-1e69-47ab-add2-8e188708d3c1.jpg',2099,2,3,'2025-04-01'),(13,'Mega Spear Animation Pack','Пакет содержит 219 анимаций в 10 ключевых позах. (зеркальных версий нет) и еще несколько в разработке','https://media.fab.com/image_previews/gallery_images/189c937c-291e-4848-b41a-f09ced3bfea7/1cde8277-85c3-4cad-88bf-be2078b908aa.jpg',2199,2,1,'2025-04-04'),(14,'UEFN Manny Zombie Animation Sample Pack','Манекен UEFN с простым набором анимациий для зомби.','https://media.fab.com/image_previews/gallery_images/9011865a-6343-4226-8431-bfcafdefbb7a/029aab4d-cc70-4b4c-a33a-d4fc216029cf.jpg',1099,2,2,'2024-02-01'),(15,'Various Attitudes animations (Motion Cast)','В этом наборе анимаций мы хотели предложить несколько простых анимаций, в которых персонаж остается на месте и реагирует по-разному. Персонаж не будет двигаться на протяжении всей анимации.','https://media.fab.com/image_previews/gallery_images/957f7ec8-1e48-49e2-955f-dd386f4ce6b2/b7bd21e5-06ec-4073-a17b-5a8ae950425f.jpg',700,2,3,'2024-02-06');
/*!40000 ALTER TABLE `resources` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resources_owners`
--

DROP TABLE IF EXISTS `resources_owners`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resources_owners` (
  `resource_id` int NOT NULL,
  `user_id` int NOT NULL,
  `purchase_date` date NOT NULL,
  PRIMARY KEY (`resource_id`,`user_id`),
  KEY `resource_idx` (`resource_id`),
  KEY `user_idx` (`user_id`),
  CONSTRAINT `resource` FOREIGN KEY (`resource_id`) REFERENCES `resources` (`id`),
  CONSTRAINT `user` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources_owners`
--

LOCK TABLES `resources_owners` WRITE;
/*!40000 ALTER TABLE `resources_owners` DISABLE KEYS */;
/*!40000 ALTER TABLE `resources_owners` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resources_requests`
--

DROP TABLE IF EXISTS `resources_requests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `resources_requests` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `description` varchar(500) NOT NULL,
  `picture` varchar(200) NOT NULL,
  `price` float NOT NULL,
  `category` int NOT NULL,
  `request_date` date NOT NULL,
  PRIMARY KEY (`id`),
  KEY `category_idx` (`category`),
  KEY `category_requests_idx` (`category`),
  CONSTRAINT `category_requests` FOREIGN KEY (`category`) REFERENCES `categories` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resources_requests`
--

LOCK TABLES `resources_requests` WRITE;
/*!40000 ALTER TABLE `resources_requests` DISABLE KEYS */;
/*!40000 ALTER TABLE `resources_requests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'Администратор'),(2,'Менеджер'),(3,'Пользователь');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `login` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `role` int NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `login_UNIQUE` (`login`),
  KEY `role_idx` (`role`),
  CONSTRAINT `role` FOREIGN KEY (`role`) REFERENCES `roles` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918','admin@mail.com',1),(2,'manager','6ee4a469cd4e91053847f5d3fcb61dbcc91e8f0ef10be7748da4c4a1ba382d17','manager@mail.com',2),(3,'user','04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb','user@mail.com',3);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-25 19:12:07
