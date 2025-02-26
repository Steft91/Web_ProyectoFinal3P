USE [AlquilerVehiculos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarVehiculos]
@marca NVARCHAR(50)
AS
BEGIN
    IF @marca = ''
    BEGIN
        SELECT Id, 
               Marca, 
               Modelo, 
               Año, 
               Precio, 
               Estado
        FROM Vehiculos
    END
    ELSE
    BEGIN
        SELECT Id, 
               Marca, 
               Modelo, 
               Año, 
               Precio, 
               Estado
        FROM Vehiculos
        WHERE Marca LIKE '%' + @marca + '%'  -- Filtra solo por la marca
    END
END;
GO
