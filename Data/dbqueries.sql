create TABLE Owners (
	Id int not null primary KEY AUTO_INCREMENT,
    Names varchar(50) not null, 
    LastNames varchar(50) not null,
    Email varchar(100) not null UNIQUE,
    Address varchar(50) not null,
    Phone varchar(25) not null
);


create table Vets ( Id int not null primary KEY AUTO_INCREMENT, Name varchar(120) not null, Email varchar(100) not null UNIQUE, Address varchar(30) not null, Phone varchar(25) not null ); 


create table Pets (
	Id int not null primary key  AUTO_INCREMENT,
    Name varchar(25) not null,
    Specie ENUM("Ave","Felino","Ratones") not null,
    Race ENUM("Desconcido","Criollo","Raza") not null,
    DateBirth DATE not null,
    Photo Text ,
    OwnerId int
    
   
); 

ALTER TABLE `Pets` ADD CONSTRAINT `Pets_Owner` FOREIGN KEY (`OwnerId`) REFERENCES `Owners`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 

CReate table Quotes (
	Id int not null primary key AUTO_INCREMENT,
    Date DateTime not null,
    Description text not null, 
    PetId int, 
    VetId int
);

ALTER TABLE `Quotes` ADD CONSTRAINT `Quotes_Pet` FOREIGN KEY (`PetId`) REFERENCES `Pets`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; ALTER TABLE `Quotes` ADD CONSTRAINT `Quotes_Vet` FOREIGN KEY (`VetId`) REFERENCES `Vets`(`Id`) ON DELETE RESTRICT ON UPDATE RESTRICT; 