DROP TABLE can_test_cases;
DROP TABLE frames;
DROP TABLE can_traffic;
DROP TABLE can_devices;
CREATE TABLE can_devices(
device_id INT UNSIGNED UNIQUE PRIMARY KEY auto_increment,
device_name varchar(40),
device_description varchar(100)
);
INSERT INTO can_devices(
device_name,
device_description
) values ("test device", "this is the main test device");
CREATE TABLE frames (
frame_id INT UNSIGNED UNIQUE PRIMARY KEY,
frame_name VARCHAR(30) NOT NULL,
frame_description VARCHAR(200)
);
INSERT INTO frames(frame_id,frame_name,frame_description) VALUES(100, "TEST", "NOTE_TEST");
INSERT INTO frames(frame_id,frame_name,frame_description) VALUES(800, "TEST2", "NOTE_TEST2");
INSERT INTO frames(frame_id,frame_name,frame_description) VALUES(102, "TEST3", "NOTE_TEST3");
CREATE TABLE can_test_cases (
test_id INT UNSIGNED UNIQUE PRIMARY KEY auto_increment,
frame_id_to_send INT UNSIGNED NOT NULL,
frame_data_len int unsigned not null,
frame_data_to_send BIGINT UNSIGNED NOT NULL,
frame_id_to_receive INT UNSIGNED NOT NULL,
frame_timeout INT UNSIGNED NOT NULL,
test_name VARCHAR(50) NOT NULL,
test_description VARCHAR(200),
test_enabled boolean NOT NULL,
related_device_id INT UNSIGNED,
/*FOREIGN KEY(frame_id_to_send)
	REFERENCES frames(frame_id),
FOREIGN KEY(frame_id_to_receive)
	REFERENCES frames(frame_id),*/
FOREIGN KEY(related_device_id)
	REFERENCES can_devices(device_id)
);
INSERT INTO frames(frame_id,frame_name,frame_description) VALUES(101, "TEST2", "NOTE_TEST2");
INSERT INTO can_test_cases(frame_id_to_send,frame_data_to_send,frame_data_len,frame_id_to_receive,frame_timeout,test_name,test_description,test_enabled,related_device_id) VALUES (800,3,1,102,1000,"testname2","testdescription2",1,1);
INSERT INTO can_test_cases(frame_id_to_send,frame_data_to_send,frame_data_len,frame_id_to_receive,frame_timeout,test_name,test_description,test_enabled,related_device_id) VALUES (100,0,1,101,1000,"testname","testdescription",1,1);
CREATE TABLE can_traffic (
frame_id INT UNSIGNED NOT NULL,
frame_data_len int unsigned not null,
frame_data BIGINT UNSIGNED NOT NULL,
frame_Time varchar(40),
direction boolean NOT NULL
);
