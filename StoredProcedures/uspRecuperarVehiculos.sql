USE [AlquilerVehiculos]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRecuperarVehiculos]
@id INT
AS
BEGIN

    SELECT *
    FROM Vehiculos
    WHERE id = @id

END;
GO
