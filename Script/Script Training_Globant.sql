Create database Training_Globant

use Training_Globant

CREATE TABLE tbl_Store(
	Id_Store int IDENTITY (1,1) PRIMARY KEY,
	Title varchar(30) NOT NULL,
	Email varchar(60) NOT NULL,
	Phone bigint NOT NULL,
	Store_Address varchar(70) NOT NULL
);

CREATE TABLE tbl_Vendor(
	Id_Vendor int IDENTITY (1,1) PRIMARY KEY,
	Nit bigint NOT NULL,
	Title varchar(30) NOT NULL,
	Vendor_Address varchar(70) NOT NULL,
	Phone bigint NOT NULL,
	Email varchar(80) NULL);

CREATE TABLE tbl_Type_Product(
	Id_Type_Product int IDENTITY (1,1) PRIMARY KEY,
	Type_Product_Name varchar(50) NOT NULL
);

CREATE TABLE tbl_Type_User(
	Id_Type_User int IDENTITY (1,1) PRIMARY KEY,
	Type_User_Name varchar(30) NOT NULL
 )
	

 CREATE TABLE tbl_Consumable
	(
	Id_Consumable int IDENTITY (1,1) PRIMARY KEY,
	Title varchar(30) NOT NULL,
	Color varchar(20) NOT NULL,
	Characteristic varchar(500),
	Stock int
	) 


 CREATE TABLE tbl_Purchase(
	Id_Purchase int IDENTITY (1,1) PRIMARY KEY,
	Id_Vendor int FOREIGN KEY REFERENCES tbl_Vendor (Id_Vendor),
	Number_Invoice bigint NOT NULL,
	Creation_Date date NOT NULL,
	Purchase_Date date NOT NULL
 )

	CREATE TABLE tbl_User
	(
	Document_Number int IDENTITY (1,1) PRIMARY KEY,
	Id_Type_User int FOREIGN KEY REFERENCES tbl_Type_User (Id_Type_User),
	Title varchar(30) NOT NULL,
	Lastname varchar(30) NOT NULL,
	Phone bigint NOT NULL,
	Birthday date NULL,
	User_Address varchar(70) NOT NULL
	)

	CREATE TABLE tbl_Invoice(
	Id_Invoice int IDENTITY (1,1) PRIMARY KEY,
	Document_Number int FOREIGN KEY REFERENCES tbl_User (Document_Number),
	Id_Store int FOREIGN KEY REFERENCES tbl_Store (Id_Store),
	Creation_Date date NOT NULL
)

CREATE TABLE tbl_Product
	(
	Id_Product int IDENTITY (1,1) PRIMARY KEY,
	Id_Type_Product int FOREIGN KEY REFERENCES tbl_Type_Product (Id_Type_Product),
	Title varchar(30) NOT NULL,
	Color varchar(20) NOT NULL,
	Characteristic varchar(500),
	Price bigint NOT NULL,
	) 

	CREATE TABLE tbl_Invoice_Detail(
	Id_Invoice_Details int IDENTITY (1,1) PRIMARY KEY,
	Id_Invoice int FOREIGN KEY REFERENCES tbl_Invoice (Id_Invoice),
	Id_Product int FOREIGN KEY REFERENCES tbl_Product (Id_Product),
	Quantity_Unit int NOT NULL,
	Price_Unit bigint NOT NULL	
)

CREATE TABLE tbl_Detail_Purchase(
	Id_Detail_Purchase int IDENTITY (1,1) PRIMARY KEY,
	Id_Purchase int FOREIGN KEY REFERENCES tbl_Purchase (Id_Purchase),
	Id_Consumable int FOREIGN KEY REFERENCES tbl_Consumable (Id_Consumable),
	Quantity_Consumable int NOT NULL,
	Price int NOT NULL
 )

 CREATE TABLE tbl_Product_Detail(
	Id_Product_Detail int IDENTITY (1,1) PRIMARY KEY,
	Id_Consumable int FOREIGN KEY REFERENCES tbl_Consumable (Id_Consumable),
	Id_Product int FOREIGN KEY REFERENCES tbl_Product (Id_Product))