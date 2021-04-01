CREATE TABLE IF NOT EXISTS `books` (
  `id` INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `author` LONGTEXT,
  `launch_date` datetime(6) NOT NULL,
  `price` decimal(65,2) NOT NULL,
  `title` LONGTEXT
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
