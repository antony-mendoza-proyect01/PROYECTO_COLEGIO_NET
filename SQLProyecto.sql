create database DBPROYECTO

use DBPROYECTO


create table USUARIO(
IdUsuario int primary key identity (1,1),
Correo varchar(100),
Clave varchar(500)
)

create table FORO(
IdForo int primary key identity(1,1),
Titulo  varchar(100),
Comentario nvarchar(MAX)
)

create procedure sp_RegistrarForo(
@Titulo varchar(100),
@Comentario nvarchar(MAX)
)
as begin 
insert into FORO (Titulo,Comentario) values (@Titulo, @Comentario) end

create procedure sp_EditarForo(
@IdForo int,
@Titulo varchar(100),
@Comentario nvarchar(MAX)
) as begin 
update FORO set Titulo = @Titulo, Comentario = @Comentario where IdForo =@IdForo end

create procedure sp_Eliminar (
@IdForo int
)as begin
delete from FORO where IdForo = @IdForo end


create proc sp_RegistrarUsuario(
@Correo varchar (100),
@Clave varchar (500),
@Registrado bit output,
@Mensaje varchar(100) output
)
as begin 
	--- Validamos sino existe 
	if(not exists(select * from USUARIO where Correo = @Correo))
	begin 
	insert into USUARIO(Correo,Clave) values(@Correo, @Clave)
	set @Registrado = 1
	set @Mensaje = 'Usuario Registrado'
end 
else 
begin 
		set @Registrado = 0
		set @Mensaje = 'Correo ya existe'
end
end

create proc sp_ValidarUsuario(
@Correo varchar(100),
@Clave varchar (500)
)
as begin 
if(exists(select * from USUARIO where Correo = @Correo and Clave = @Clave))
	select IdUsuario from USUARIO where Correo  = @Correo and Clave = @Clave
	else 
		select '0'

end

select * from usuario 
select * from FORO 

insert into FORO (Titulo,Comentario) values ('Maltrato de Genero','El maltrato de genero puede ser producido por un hombre o una mujer')