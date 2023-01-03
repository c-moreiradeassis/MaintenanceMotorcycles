CREATE DATABASE MAINTENANCE_MOTOCYCLES 

CREATE TABLE MAINTENANCE (
ID INT IDENTITY(1, 1),
ITEM VARCHAR(100),
OPERATION VARCHAR(500),
EVERY INT,
LAST_MAINTENANCE DATETIME

PRIMARY KEY (ID))

CREATE TABLE CLIENT (
ID INT IDENTITY(1, 1),
EMAIL VARCHAR(200)

PRIMARY KEY (ID))


CREATE TABLE CLIENT_MAINTENANCE (
ID INT IDENTITY(1, 1),
ID_MAINTENANCE INT, 
ID_CLIENT INT,
LAST_MAINTENANCE DATETIME

PRIMARY KEY(ID),
FOREIGN KEY (ID_MAINTENANCE) REFERENCES MAINTENANCE (ID),
FOREIGN KEY (ID_CLIENT) REFERENCES CLIENT (ID))