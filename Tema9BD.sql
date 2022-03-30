-- creaccion de BD
Create Database Mant_product;

-- Creación de tabla
Create Table Categoria(
IDcategoria int identity(1,1)primary key not null,
Codigo AS ('CT'+RIGHT('00' + CONVERT(VARCHAR, IDcategoria), (2))),
Nombre Nvarchar(30) not null,
Descripcion Nvarchar(256) null

);

-- Insert
Insert Into Categoria VALUES('Herramientas electricas','Cuenta con las mejores herremientas electrica, para cualquier trabajo');
Insert Into Categoria VALUES('Herramientas manuales','Cuenta con las mejores herremientas, desde las más básica');

-- select
Select * from Categoria;

--Store Procedure
--1- Buscar
Create PROC SP_BuscarCaterogria
@Buscar Nvarchar(25)
AS
Select * From Categoria
Where Nombre Like @Buscar + '%'

go

--Insertar
Create PROC SP_InsertarCategoria
@Nombre Nvarchar(35),
@Descripcion Nvarchar(256)
AS
Insert Into Categoria Values (@Nombre, @Descripcion)
 
 go

--Editar
Create PROC SP_editarCategoria
@IDcategoria INT,
@Nombre Nvarchar(35),
@Descripcion Nvarchar(256)
AS
Update Categoria Set Nombre = @Nombre, Descripcion = @Descripcion
WHERE IDcategoria = @IDcategoria


--DROP PROCEDURE SP_editarCategoria2;  

go

--SP Eliminar
Create PROC SP_eliminarCategoria
@IDcategoria INT
AS
Delete Categoria
WHERE IDcategoria = @IDcategoria


