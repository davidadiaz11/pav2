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

create TABLE Hotel(
 id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  descripcion varchar(255),
  capacidad int,
   destino int FOREIGN KEY REFERENCES Destino(id),
   cuit int,
   aceptaMascota bit,
   inicioActividad date,
   eliminado bit);

insert into Hotel values ('Hotel trejo', 5, 3,200,1,getdate(),);
insert into Hotel values ('Hotel La linda', 5, 3,200,0,getdate(),);
insert into Hotel values ('Hotel Prueba', 5, 2,200,1,getdate(),);