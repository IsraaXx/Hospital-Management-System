CREATE TABLE admin (
	adminId int primary key identity(1,1),
	username varchar(250) NOT NULL,
	[password] varchar(100) NOT NULL
);
CREATE TABLE doctor (
	docId int primary key,
	docName varchar(150) NOT NULL,
	docExp int NOT NULL,
	docSpec varchar(200) NOT NULL,
);
CREATE TABLE patient (
	patId int primary key,
	patName varchar(150) NOT NULL,
	patAddress varchar(100) NOT NULL,
	patPhone varchar(50) NOT NULL,
	patAge int NOT NULL,
	patGender varchar(50) NOT NULL,
	patBlood varchar(50) NOT NULL,
	patDisease varchar(100) NOT NULL 
);
CREATE TABLE diagnosis (
	diagId int primary key,
	patId int NOT NULL,
	patName varchar(150) NOT NULL,
	symptoms varchar(100) NOT NULL,
	diagnosis varchar(100) NOT NULL,
	medicines varchar(100) NOT NULL
);
