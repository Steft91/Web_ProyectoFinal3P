USE [AlquilerVehiculos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGuardarVehiculos]
@iidvehiculo INT,
@marca NVARCHAR(50),
@modelo NVARCHAR(50),
@año INT,
@precio DECIMAL(10,2),
@estado NVARCHAR(20)
AS
BEGIN

    IF @iidvehiculo = 0
    -- Insertar
    BEGIN
        INSERT INTO Vehiculos (Marca, Modelo, Año, Precio, Estado)
        VALUES (@marca, @modelo, @año, @precio, @estado)
    END
    ELSE
    -- Actualizar
    BEGIN
        UPDATE Vehiculos
        SET Marca = @marca,
            Modelo = @modelo,
            Año = @año,
            Precio = @precio,
            Estado = @estado
        WHERE Id = @iidvehiculo
    END

END;
GO
