drop database LogicalDataDB
--- ==================================================
--- Autor: Jordi Segura Madrigal
--- Fecha: 3/06/2024
--- Descripción: Script encargado de crear la Base de 
--- Datos y los Esquemas de prueba técnica de Logical 
--- Data.
--- ==================================================
CREATE DATABASE LogicalDataDB;
GO

USE LogicalDataDB;
GO

CREATE SCHEMA Usuarios;
GO

CREATE SCHEMA Inventarios;
GO

CREATE SCHEMA Ventas;
GO

--- ==================================================
--- Autor: Jordi Segura Madrigal
--- Fecha: 3/06/2024
--- Descripción: Script encargado de crear la tabla de 
--- usuario del sistema.
--- ==================================================
CREATE TABLE Usuarios.Usuario (
	Id INT IDENTITY(1, 1),
	Nombre NVARCHAR(25) NOT NULL,
	Apellido NVARCHAR(25) NOT NULL,
	Username NVARCHAR(25) NOT NULL,
	Contrasenia VARBINARY(64) NOT NULL,
	CONSTRAINT PkUsuarioId PRIMARY KEY(Id),
	CONSTRAINT UqNombre UNIQUE(Nombre)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los usuarios del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Usuarios',
	@level1type = N'TABLE',
	@level1name = N'Usuario'
;
GO

--- ==================================================
--- Autor: Jordi Segura Madrigal
--- Fecha: 3/06/2024
--- Descripción: Script encargado de crear la tabla 
--- de los productos.
--- ==================================================
CREATE TABLE Inventarios.Producto (
	Id INT IDENTITY(1, 1),
	Nombre NVARCHAR(25) NOT NULL,
	Descripcion NVARCHAR(100) NOT NULL,
	Codigo NVARCHAR(25) NOT NULL,
	Precio decimal NOT NULL,
	IVA BIT NOT NULL,
	CONSTRAINT PkProductoId PRIMARY KEY(Id),
	CONSTRAINT UqProductoCodigo UNIQUE(Codigo)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los productos del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Inventarios',
	@level1type = N'TABLE',
	@level1name = N'Producto'
;
GO

--- ==================================================
--- Autor: Jordi Segura Madrigal
--- Fecha: 3/06/2024
--- Descripción: Script encargado de crear la tabla de 
--- ordenes.
--- ==================================================
CREATE TABLE Ventas.Orden (
	Id INT IDENTITY(1, 1),
	UsuarioId INT NOT NULL,
	Fecha date NOT NULL,
	Total decimal NOT NULL,
	CONSTRAINT PkOrdenId PRIMARY KEY(Id),
	CONSTRAINT FkOrdenUsuarioId FOREIGN KEY(UsuarioId) REFERENCES Usuarios.Usuario(Id)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena las ordenes del sistema', 
	@level0type = N'SCHEMA',
	@level0name = N'Ventas',
	@level1type = N'TABLE',
	@level1name = N'Orden'
;
GO

--- ==================================================
--- Autor: Jordi Segura Madrigal
--- Fecha: 3/06/2024
--- Descripción: Script encargado de crear la tabla de 
--- items de las ordenes.
--- ==================================================
CREATE TABLE Ventas.Item (
	Id INT IDENTITY(1, 1),
	OrdenId INT NOT NULL,
	ProductoId INT NOT NULL,
	Cantidad int NOT NULL,
	Precio decimal NOT NULL,
	Total decimal NOT NULL,
	CONSTRAINT PkItem PRIMARY KEY(Id),
	CONSTRAINT FkItemOrdenId FOREIGN KEY(OrdenId) REFERENCES Ventas.Orden(Id),
	CONSTRAINT FkItemProductoId FOREIGN KEY(ProductoId) REFERENCES Inventarios.Producto(Id)
);
GO
EXEC sp_addextendedproperty
	@name = N'MS_Description', 
	@value = N'Almacena los items de las ordenes del sistema.', 
	@level0type = N'SCHEMA',
	@level0name = N'Ventas',
	@level1type = N'TABLE',
	@level1name = N'Item'
;
GO