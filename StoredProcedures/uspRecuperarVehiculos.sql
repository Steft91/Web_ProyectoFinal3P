USE [AlquilerVehiculos]
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarVehiculos]    Script Date: 2/3/25 22:17:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[uspRecuperarVehiculos]
@idVehiculo INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
    FROM Vehiculos
    WHERE id = @idVehiculo

END;
