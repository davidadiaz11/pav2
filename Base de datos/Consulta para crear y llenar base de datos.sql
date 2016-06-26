create table Pais(
  id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  descripcion varchar(255));

insert into Pais values ( 'Argentina');
insert into Pais values ( 'Siria');
insert into Pais values ( 'Dinamarca');
insert into Pais values ( 'Australia');
insert into Pais values ( 'Singapur');

create table Destino(
 id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  descripcion varchar(255),
  pais int FOREIGN KEY REFERENCES Pais(id)
);
insert into Destino values ( 'Córdoba', 1);
insert into Destino values ( 'Salta', 1);
insert into Destino values ( 'Capital Siria', 2);
insert into Destino values ( 'Capital Dinamarca', 3);
insert into Destino values ('Capital Singapur',5);

create TABLE Hotel(
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(255),
capacidad int,
destino int FOREIGN KEY REFERENCES Destino(id),
cuit bigint NOT NULL UNIQUE,
aceptaMascota bit,
inicioActividad date,
eliminado bit);

insert into Hotel values ('Hotel trejo', 5, 3,100,1,getdate(),NULL);
insert into Hotel values ('Hotel La linda', 5, 3,200,0,getdate(),NULL);
insert into Hotel values ('Hotel Singapur', 5, 5,300,1,getdate(),NULL);
insert into Hotel values ('Hotel Siria', 5, 3,400,1,getdate(),NULL);
insert into Hotel values ('Hotel Dinamarca', 4, 2,500,1,getdate(),NULL);

create Table TipoTransporte (
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(255));

insert into TipoTransporte values ('Colectivo');
insert into TipoTransporte values ('Avión');

create Table Transporte (
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(255),
tipo int FOREIGN KEY REFERENCES TipoTransporte(id));

insert into Transporte values ('Colectivo1',1);
insert into Transporte values ('Colectivo2',1);
insert into Transporte values ('Avion1',2);
insert into Transporte values ('Avion2',2);
insert into Transporte values ('Avion3',2);

create table Promocion(
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
fechaDesde date,
fechaHasta date,
descuento int);

insert into Promocion values (getdate(), getdate(), 10);
insert into Promocion values (getdate(), getdate(), 20);
insert into Promocion values (getdate(), getdate(), 30);
insert into Promocion values (getdate(), getdate(), 40);
insert into Promocion values (getdate(), getdate(), 50);

create TABLE Paquete (
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(255),
promocion int FOREIGN KEY REFERENCES Promocion(id),
precio int,
fechaSalida date,
fechaLlegada date);

insert into Paquete values ('desc1',1,1000, getdate(),getdate());
insert into Paquete values ('desc2',2,2000, getdate(),getdate());
insert into Paquete values ('desc3',3,3000, getdate(),getdate());
insert into Paquete values ('desc4',4,4000, getdate(),getdate());
insert into Paquete values ('desc5',5,5000, getdate(),getdate());

create TABLE Viaje (
id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
descripcion varchar(255),
imagen varchar(255) NOT NULL UNIQUE,
hotel int FOREIGN KEY REFERENCES Hotel(id),
precio int,
fechaSalida date,
fechaLlegada date,
destino int FOREIGN KEY REFERENCES Destino(id),
cupo int,
transporte int FOREIGN KEY REFERENCES Transporte(id),
disponible bit NOT NULL,
eliminado bit);

--insert into Viaje values ('Viaje 1','viaje_01', 1,1000,getdate(),getdate(),1,10,1,1,1,NULL);
--insert into Viaje values ('Viaje 2','viaje_02',2,2000,getdate(),getdate(),2,20,2,2,1, NULL);
--insert into Viaje values ('Viaje 3','viaje_03',3,3000, getdate(),getdate(),3,30,3,3,1,NULL);
--insert into Viaje values ('Viaje 4','viaje_04',4,4000, getdate(),getdate(),4,40,4,4,1,NULL);
--insert into Viaje values ('Viaje 5','viaje_05',5,5000, getdate(),getdate(),5,50,5,5,1,NULL);

create table ViajeXPaquete (
idViaje int NOT NULL PRIMARY KEY,
idPaquete int NOT NULL PRIMARY KEY);


create table Usuario (
id string not null primary key,
contraseña string not null);

insert into Usuario (id,contraserña) values ('pasajero','asd');
insert into Usuario (id,contraserña) values ('admin','asd');
insert into Usuario (id,contraserña) values ('Nico','asd');
insert into Usuario (id,contraserña) values ('David','asd');

create table PaquetexUsuario (
idPaquete int NOT NULL PRIMARY KEY,
idUsuario string NOT NULL PRIMARY KEY);