use contactmanagerdb;
SHOW TABLES;

CREATE TABLE `address_book` (
  `dob` date DEFAULT NULL,
  `door_number` int DEFAULT NULL,
  `gender` varchar(1) DEFAULT NULL,
  `is_active` int DEFAULT NULL,
  `contact_id` bigint NOT NULL AUTO_INCREMENT,
  `created_at` datetime(6) DEFAULT NULL,
  `contact_name` varchar(50) NOT NULL,
  `address_line1` varchar(255) DEFAULT NULL,
  `address_line2` varchar(255) DEFAULT NULL,
  `building` varchar(255) DEFAULT NULL,
  `city` varchar(255) DEFAULT NULL,
  `email_id` varchar(255) DEFAULT NULL,
  `state` varchar(255) DEFAULT NULL,
  `zipcode` varchar(255) DEFAULT NULL,
  `profile_picture` longblob,
  PRIMARY KEY (`contact_id`),
  CONSTRAINT `address_book_chk_1` CHECK ((`gender` in (_utf8mb4'F',_utf8mb4'M'))),
  CONSTRAINT `address_book_chk_2` CHECK ((`is_active` in (0,1)))
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

CREATE TABLE `phone_number` (
  `number` int DEFAULT NULL,
  `phone_type` tinyint DEFAULT NULL,
  `contact_id` bigint DEFAULT NULL,
  `id` bigint NOT NULL AUTO_INCREMENT,
  `country_code` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `FKjk7lk1yg6tsyowsf9newp5dgy` (`contact_id`),
  CONSTRAINT `FKjk7lk1yg6tsyowsf9newp5dgy` FOREIGN KEY (`contact_id`) REFERENCES `address_book` (`contact_id`),
  CONSTRAINT `phone_number_chk_1` CHECK ((`phone_type` between 0 and 1))
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tag` (
  `id` bigint NOT NULL AUTO_INCREMENT,
  `tag_name` varchar(20) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `user` (
  `is_active` bit(1) DEFAULT NULL,
  `role` tinyint DEFAULT NULL,
  `created_at` datetime(6) DEFAULT NULL,
  `id` bigint NOT NULL AUTO_INCREMENT,
  `modified_at` datetime(6) DEFAULT NULL,
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `UKsb8bbouer5wak8vyiiy4pf2bx` (`username`),
  CONSTRAINT `user_chk_1` CHECK ((`role` between 0 and 1))
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `address_book_tags` (
  `contacts_contact_id` bigint NOT NULL,
  `tags_id` bigint NOT NULL,
  KEY `FKs6fr75dcd3m5eh602hu93tc81` (`tags_id`),
  KEY `FKyvtxlmjt16dhy0363cljsfuk` (`contacts_contact_id`),
  CONSTRAINT `FKs6fr75dcd3m5eh602hu93tc81` FOREIGN KEY (`tags_id`) REFERENCES `tag` (`id`),
  CONSTRAINT `FKyvtxlmjt16dhy0363cljsfuk` FOREIGN KEY (`contacts_contact_id`) REFERENCES `address_book` (`contact_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;