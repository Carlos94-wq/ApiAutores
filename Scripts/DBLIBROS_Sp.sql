IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spLibro')
BEGIN
	DROP PROCEDURE [dbo].[spLibro]
END
GO
CREATE PROCEDURE [dbo].[spLibro](
	@Accion		 INT           = NULL,
	@IdLibro     INT           = NULL,
	@IdAutor     INT           = NULL,
	@IdCategoria INT           = NULL,
	@Titulo      VARCHAR (100) = NULL,
	@Descripcion VARCHAR (100)  = NULL,
	@Portada     VARCHAR (MAX) = NULL,

	@Activo BIT = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN 
		SELECT L.IdLibro, L.Portada, L.Titulo, L.Descripcion, A.Nombre, A.Apellidos, C.Descripcion
		FROM Libro L
		INNER JOIN Categoria C ON L.IdCategoria = C.IdCategoria
		INNER JOIN Autor A ON L.IdAutor = A.IdAutor
		WHERE (L.IdCategoria = @IdCategoria OR @IdCategoria IS NULL) AND
			  (L.IdAutor = @IdAutor OR @IdAutor IS NULL) AND
			  (L.Activo = @Activo OR @Activo IS NULL)
	END

	IF @Accion = 2
	BEGIN 
		SELECT *
		FROM Libro L
		INNER JOIN Categoria C ON L.IdCategoria = C.IdCategoria
		WHERE IdLibro = @IdLibro
	END

	IF @Accion = 3
	BEGIN 
		INSERT INTO Libro
		VALUES(@IdAutor, @IdCategoria, @Titulo, @Descripcion, @Portada, 1)
	END

	IF @Accion = 4
	BEGIN 
		SELECT *
		FROM Libro
		WHERE IdAutor = @IdAutor
	END
END

IF EXISTS (SELECT 1 FROM SYSOBJECTS WHERE NAME = 'spAutor')
BEGIN
	DROP PROCEDURE [dbo].[spAutor]
END
GO
CREATE PROCEDURE [dbo].[spAutor](
	@Accion INT = NULL,
	@IdAutor   INT  = NULL,
	@Nombre    VARCHAR (100) = NULL,
	@Apellidos VARCHAR (100) = NULL,
	@FechaNac  DATE = NULL,
	@Edad      INT = NULL,

	@Activo BIT = NULL
)
AS
BEGIN
	IF @Accion = 1
	BEGIN 
		SELECT IdAutor, Nombre, Apellidos, FechaNac, Edad, Activo
		FROM Autor
		WHERE (Nombre LIKE '%' + @Nombre + '%' OR @Nombre IS NULL) AND
			  (Apellidos LIKE '%' + @Apellidos + '%' OR @Apellidos IS NULL) AND
			  (Activo = @Activo OR @Activo IS NULL)
	END

	IF @Accion = 2
	BEGIN
		SELECT * 
		FROM Autor
		WHERE IdAutor = @IdAutor
	END

	IF @Accion = 3
	BEGIN
		UPDATE Autor
		SET Nombre = @Nombre,
			Apellidos = @Apellidos,
			FechaNac = @FechaNac,
			Edad = @Edad
		WHERE IdAutor = @IdAutor
	END

	IF @Accion = 4
	BEGIN
		UPDATE Autor
		SET Activo = 0 --falso jeje
		WHERE IdAutor = @IdAutor
	END

	IF @Accion = 5
	BEGIN
		INSERT INTO Autor 
		VALUES( @Nombre, @Apellidos, @FechaNac, @Edad, 1 )
	END

	IF @Accion = 6
	BEGIN 
		SELECT L.IdLibro, L.Titulo, L.Portada, C.IdCategoria, C.Descripcion
		FROM Libro L
		INNER JOIN Categoria C ON L.IdCategoria = C.IdCategoria
		WHERE IdAutor = @IdAutor
	END
END