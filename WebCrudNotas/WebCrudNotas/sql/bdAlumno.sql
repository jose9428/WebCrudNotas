use master
go

if db_id('bdAlumno') is not null
   begin
	 use master
	 drop database bdAlumno
   end

create database bdAlumno
go

use bdAlumno
go

create table Alumno(
	codigo int identity primary key,
	nombres varchar(50),
	nota1 integer,
	nota2 integer
)
go

insert into Alumno values('Juan Alberto Caceres' , 12,15)

select * from Alumno

