USE [AlquilerVehiculos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarVehiculos]
@id INT
AS
BEGIN
    DELETE FROM Vehiculos
    WHERE id = @id
END;
GO
