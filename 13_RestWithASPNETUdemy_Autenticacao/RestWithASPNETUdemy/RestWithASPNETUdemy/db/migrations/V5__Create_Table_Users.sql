CREATE TABLE IF NOT EXISTS `users` ( 
  `id` INT(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `user_name` varchar(50) NOT NULL DEFAULT '0',
  `password` varchar(130) NOT NULL DEFAULT '0',
  `full_name` VARCHAR(120) NOT NULL,
	`refresh_token` VARCHAR(500) NULL DEFAULT '0',
	`refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
	UNIQUE `user_name` (`user_name`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
