USE [AlquilerVehiculos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspListarVehiculos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id AS idVehiculo,  
           Marca, 
           Modelo, 
           Año, 
           Precio, 
           Estado
    FROM Vehiculos;
END;
GO
