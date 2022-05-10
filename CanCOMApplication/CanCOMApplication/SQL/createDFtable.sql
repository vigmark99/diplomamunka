CREATE TABLE IF NOT EXISTS CanDataFrames (
id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY UNIQUE,
framename VARCHAR(30) NOT NULL,
alloweddatasize INT(1) UNSIGNED
CHECK(allowdatasize>=0 AND allowdatasize<=8),
reg_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
PRIMARY KEY (id)
);