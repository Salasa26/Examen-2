
CREATE DATABASE TALLERUH
GO

USE TALLERUH
GO

CREATE TABLE Usuarios --1
(
	UsuarioID int identity (10,1) PRIMARY KEY,
	Nombre varchar (50) NOT NULL,
	CorreoElectronico varchar (50) NOT NULL,
	Telefono varchar (50) NOT NULL

)
GO

CREATE TABLE Tecnicos --2
(
	TecnicoID int identity (20,1) PRIMARY KEY,
	Nombre varchar (50) NOT NULL,
	Especialidad varchar (50) NOT NULL,

)
GO

CREATE TABLE Asignaciones --5
(
	AsignacionID int identity (50,1),
	TecnicoID int,
	ReparacionID int,
	
	CONSTRAINT fk_ReparacionID1 FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID), -- Segundaria
	CONSTRAINT fk_TecnicoID FOREIGN KEY (TecnicoID) REFERENCES Tecnicos(TecnicoID), -- Segundaria
	FechaAsignacion datetime NOT NULL CONSTRAINT df_fechaAsig DEFAULT GETDATE(), -- Primaria
	CONSTRAINT fk_AsignacionID PRIMARY KEY (AsignacionID) -- Primaria
)
GO

CREATE TABLE Reparaciones --4
(
	ReparacionID int identity (40,1),
	EquipoID int,
	
	Estado varchar (15) NOT NULL, -- Primaria
	FechaSolicitud datetime NOT NULL CONSTRAINT df_fecha DEFAULT GETDATE(), -- Primaria
	CONSTRAINT fk_CodEquipoID FOREIGN KEY (EquipoID) REFERENCES Equipos(EquipoID), -- Segundaria
	CONSTRAINT fk_ReparacionID PRIMARY KEY (ReparacionID) -- Primaria

)
GO

CREATE TABLE DetallesReparacion --6
(
	DetalleID int identity (60,1),
	ReparacionID int ,

	
	CONSTRAINT fk_CodReparacionID2 FOREIGN KEY (ReparacionID) REFERENCES Reparaciones(ReparacionID), -- Segundaria
	Descripcion varchar (50) NOT NULL, -- Primaria
	FechaIncio datetime NOT NULL CONSTRAINT df_fechaInicio DEFAULT GETDATE(), -- Primaria
	FechaFin datetime NOT NULL CONSTRAINT df_fechaFin DEFAULT GETDATE(), -- Primaria
	CONSTRAINT fk_DetalleID PRIMARY KEY (DetalleID) -- Primaria


)
GO

CREATE TABLE Equipos --3
(
	EquipoID int identity (30,1),
	UsuarioID int ,

	TipoEquipo varchar (15) NOT NULL, -- Primaria
	Modelo varchar (15) NOT NULL, -- Primaria
	CONSTRAINT fk_UsuarioID FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID), -- Segundaria
	CONSTRAINT fk_EquipoID PRIMARY KEY (EquipoID) -- Primaria

)
GO


-- PROCEDEMIENTOS ALMACENADOS Usuario
CREATE PROCEDURE AGREGARUSUARIO

	@Nombre VARCHAR(50),
	@Correo VARCHAR(50),
	@Telefono VARCHAR(50)
AS
	BEGIN 
		INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono)
		VALUES (@Nombre, @Correo, @Telefono)
	END


CREATE PROCEDURE BORRARUSUARIO

	@CODIGO INT 
	AS
		BEGIN 
			DELETE Usuarios WHERE UsuarioID = @CODIGO
		END

CREATE PROCEDURE ACTUALIZARUSUARIO
	@CODIGO INT,
	@Nombre VARCHAR(50),
	@Correo VARCHAR(50),
	@Telefono VARCHAR(50)
	AS
		BEGIN
			UPDATE Usuarios SET Nombre = @Nombre WHERE UsuarioID = @CODIGO
			UPDATE Usuarios SET CorreoElectronico = @Correo WHERE UsuarioID = @CODIGO
			UPDATE Usuarios SET Telefono = @Telefono WHERE UsuarioID = @CODIGO
		END

CREATE PROCEDURE CONSULTAUSUARIO_FILTRO
	@CODIGO INT
	AS
		BEGIN
			SELECT * FROM Usuarios WHERE UsuarioID = @CODIGO
		END


EXEC AGREGARUSUARIO 'Adrian', 'AdrianSalas@gmail.com', '2290-5110'
EXEC BORRARUSUARIO 10
EXEC ACTUALIZARUSUARIO 12, 'Andres', 'AndresSalas@gmail.com', '2290-2060'
EXEC CONSULTAUSUARIO_FILTRO 12

-- PROCEDEMIENTOS ALMACENADOS Tecnicos

CREATE PROCEDURE AGREGARTECNICO

	@Nombre VARCHAR(50),
	@Especialidad VARCHAR(50)
	
AS
	BEGIN 
		INSERT INTO Tecnicos (Nombre, Especialidad)
		VALUES (@Nombre, @Especialidad)
	END

CREATE PROCEDURE BORRARTECNICO

	@CODIGO INT 
	AS
		BEGIN 
			DELETE Tecnicos WHERE TecnicoID = @CODIGO
		END

CREATE PROCEDURE ACTUALIZARTECNICO
	@CODIGO INT,
	@Nombre VARCHAR(50),
	@Especialidad VARCHAR(50)

	AS
		BEGIN
			UPDATE Tecnicos SET Nombre = @Nombre WHERE TecnicoID = @CODIGO
			UPDATE Tecnicos SET Especialidad = @Especialidad WHERE TecnicoID = @CODIGO
			
		END


CREATE PROCEDURE CONSULTATECNICO_FILTRO
	@CODIGO INT
	AS
		BEGIN
			SELECT * FROM Tecnicos WHERE TecnicoID = @CODIGO
		END


EXEC AGREGARTECNICO 'Fabian', 'Electricista'
EXEC BORRARTECNICO 20
EXEC ACTUALIZARTECNICO 20, 'Fabian', 'Mecanico'
EXEC CONSULTATECNICO_FILTRO 20

-- PROCEDEMIENTOS ALMACENADOS Equipos

CREATE PROCEDURE AGREGAREQUIPO

	@UsuarioID int,
	@TipoEquipo VARCHAR(50),
	@Modelo VARCHAR(50)

	
AS
	BEGIN 
		INSERT INTO Equipos (UsuarioID, TipoEquipo, Modelo)
		VALUES (@UsuarioID, @TipoEquipo, @Modelo)
	END

CREATE PROCEDURE BORRAREQUIPO

	@CODIGO INT 
	AS
		BEGIN 
			DELETE Equipos WHERE EquipoID = @CODIGO
		END

CREATE PROCEDURE ACTUALIZAREQUIPO
	@CODIGO INT,
	@UsuarioID int,
	@TipoEquipo VARCHAR(50),
	@Modelo VARCHAR(50)

	AS
		BEGIN
			UPDATE Equipos SET UsuarioID = @UsuarioID WHERE EquipoID = @CODIGO
			UPDATE Equipos SET TipoEquipo = @TipoEquipo WHERE EquipoID = @CODIGO
			UPDATE Equipos SET Modelo = @Modelo WHERE EquipoID = @CODIGO
		END

CREATE PROCEDURE CONSULTAEQUIPO_FILTRO
	@CODIGO INT
	AS
		BEGIN
			SELECT * FROM Equipos  WHERE EquipoID  = @CODIGO
		END


EXEC AGREGAREQUIPO 11, 'Regla', 'Metalica'
EXEC BORRAREQUIPO 30
EXEC ACTUALIZAREQUIPO 30, 11, 'Regla', 'Madera'
EXEC CONSULTAEQUIPO_FILTRO 30