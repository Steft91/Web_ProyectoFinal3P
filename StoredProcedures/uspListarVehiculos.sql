USE [AlquilerVehiculos]
GO
/****** Object:  StoredProcedure [dbo].[uspListarVehiculos]    Script Date: 2/3/25 22:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[uspListarVehiculos] --primera vez poner CREATE en vez de ALTER
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Vehiculos;
END;
