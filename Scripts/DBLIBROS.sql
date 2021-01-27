USE master 
GO

--DROP DATABASE LIBROS
--go

CREATE DATABASE LIBROS
GO

USE LIBROS
GO

CREATE TABLE [dbo].[Categoria](
	IdCategoria  INT IDENTITY NOT NULL,
	Descripcion  VARCHAR(30)  NOT NULL 

	CONSTRAINT PK_Categoria_IdCategoria PRIMARY KEY (IdCategoria)
)


CREATE TABLE [dbo].[Autor](
	IdAutor   INT IDENTITY NOT NULL,
	Nombre    VARCHAR (100) NOT NULL,
	Apellidos VARCHAR (100) NOT NULL,
	FechaNac  DATE NOT NULL,
	Edad      INT NOT NULL,

	Activo BIT NOT NULL

	CONSTRAINT PK_Autor_IdAutor PRIMARY KEY (IdAutor)
)

CREATE TABLE [dbo].[Libro](
	IdLibro     INT IDENTITY  NOT NULL,
	IdAutor     INT           NOT NULL,
	IdCategoria INT           NOT NULL,
	Titulo      VARCHAR (100) NOT NULL,
	Descripcion VARCHAR (100) NOT NULL,
	Portada     VARCHAR (MAX) NULL,

	Activo BIT NOT NULL

	CONSTRAINT PK_Libro_IEdLibro PRIMARY KEY (IdLibro),
	CONSTRAINT FK_Libro_IdAutor FOREIGN KEY (IdAutor) REFERENCES [Autor] (IdAutor),
	CONSTRAINT FK_Libro_IdCategoria FOREIGN KEY (IdCategoria) REFERENCES [Categoria] (IdCategoria)
)

INSERT INTO Categoria
VALUES ('Terror'),
	   ('Fantasia'),
	   ('Thriller')

INSERT INTO Autor 
VALUES('Carlos', 'Rodriguez', '09/19/1994', '26', 1 )

INSERT INTO Libro (IdAutor, IdCategoria, Titulo, Descripcion, Portada, Activo)
VALUES(1, 1, 'Nuevo Libro', 'Este libro fue escrito para probar una api', '', 1)