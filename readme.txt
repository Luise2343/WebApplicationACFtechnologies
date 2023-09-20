Scritp de creacion de base de datos:
CREATE DATABASE DBClientes ;

USE DBClientes;

CREATE TABLE Clientes (
    Identificacion INT PRIMARY KEY,
    PrimerNombre NVARCHAR(50),
    PrimerApellido NVARCHAR(50),
    Edad INT,
    FechaCreacion DATETIME
);



*------------------------Procedimiento de almacenamieto*----------------------------------
ALTER PROCEDURE [dbo].[EditarCliente]
    @Identificacion INT,
    @NuevoPrimerNombre VARCHAR(50),
    @NuevoPrimerApellido VARCHAR(50),
    @NuevaEdad INT,
    @NuevaFechaDeCreacion DATE
AS
BEGIN
    UPDATE Cliente
    SET primerNombre = @NuevoPrimerNombre,
        primerApellido = @NuevoPrimerApellido,
        edad = @NuevaEdad,
        fechaDeCreacion = @NuevaFechaDeCreacion
    WHERE identificacion = @Identificacion
END
ALTER PROCEDURE [dbo].[EliminarCliente]
    @Identificacion INT
AS
BEGIN
    DELETE FROM Cliente
    WHERE identificacion = @Identificacion
END
ALTER PROCEDURE [dbo].[InsertarCliente]
    
    @PrimerNombre VARCHAR(50),
    @PrimerApellido VARCHAR(50),
    @Edad INT,
    @FechaDeCreacion DATE
AS
BEGIN
    INSERT INTO Cliente ( primerNombre, primerApellido, edad, fechaDeCreacion)
    VALUES ( @PrimerNombre, @PrimerApellido, @Edad, @FechaDeCreacion)
ENDALTER PROCEDURE [dbo].[ListarClientes]
AS
BEGIN
    SELECT * FROM Cliente
END
