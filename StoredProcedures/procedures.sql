USE [AlquilerVehiculos]
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarClientes]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarClientes]
	@idCliente INT
AS
BEGIN
    DELETE FROM Clientes
    WHERE Id = @idCliente
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarEmpleado]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarEmpleado]
    @idEmpleado INT
AS
BEGIN
    DELETE FROM Empleados WHERE Id = @idEmpleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarPago]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspEliminarPago]
    @idPago INT
AS
BEGIN
    DELETE FROM Pagos WHERE Id = @idPago;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarReservas]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarReservas]
    @idReserva INT
AS
BEGIN
    DELETE FROM Reservas WHERE Id = @idReserva;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarSeguro]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarSeguro]
    @idSeguro INT
AS
BEGIN
    DELETE FROM Seguros WHERE Id = @idSeguro;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarVehiculos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarVehiculos]
	@idVehiculo INT
AS
BEGIN
    DELETE FROM Vehiculos
    WHERE Id = @idVehiculo
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarClientes]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarClientes]
	@nombre NVARCHAR(100)
AS
BEGIN
    IF @nombre = ''
        SELECT * FROM Clientes
    ELSE
        SELECT * FROM Clientes WHERE Nombre LIKE '%' + @nombre + '%'
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarEmpleados]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarEmpleados]
    @nombreEmpleado NVARCHAR(50)
AS
BEGIN
    IF @nombreEmpleado = ''
        SELECT * FROM Empleados;
    ELSE
        SELECT * FROM Empleados WHERE Nombre LIKE '%' + @nombreEmpleado + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarPagos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarPagos]
    @metodoPago NVARCHAR(50)
AS
BEGIN
    IF @metodoPago = ''
        SELECT * FROM Pagos;
    ELSE
        SELECT * FROM Pagos WHERE MetodoPago LIKE '%' + @metodoPago + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarReservas]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarReservas]
    @estado NVARCHAR(50)
AS
BEGIN
    IF @estado = ''
        SELECT * FROM Reservas;
    ELSE
        SELECT * FROM Reservas
        WHERE Estado LIKE '%' + @estado + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarSeguros]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarSeguros]
    @tipoSeguro NVARCHAR(50)
AS
BEGIN
    IF @tipoSeguro = ''
        SELECT * FROM Seguros;
    ELSE
        SELECT * FROM Seguros WHERE TipoSeguro LIKE '%' + @tipoSeguro + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarVehiculos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspFiltrarVehiculos]
    @marca NVARCHAR(50)
AS
BEGIN
    IF @marca = ''
        SELECT * FROM Vehiculos;
    ELSE
        SELECT * FROM Vehiculos
        WHERE Marca LIKE '%' + @marca + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarClientes]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGuardarClientes]
	@idCliente INT,
	@nombre NVARCHAR(100),
	@apellido NVARCHAR(100),
	@telefono NVARCHAR(15),
	@email NVARCHAR(100)
AS
BEGIN
    IF @idCliente = 0
    BEGIN
        -- Insertar nuevo cliente
        INSERT INTO Clientes (Nombre, Apellido, Telefono, Email)
        VALUES (@nombre, @apellido, @telefono, @email)
    END
    ELSE
    BEGIN
        -- Actualizar cliente existente
        UPDATE Clientes
        SET Nombre = @nombre,
            Apellido = @apellido,
            Telefono = @telefono,
            Email = @email
        WHERE id = @idCliente
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarEmpleado]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGuardarEmpleado]
    @idEmpleado INT,
    @nombreEmpleado NVARCHAR(50),
    @apellidoEmpleado NVARCHAR(50),
    @cargo NVARCHAR(50),
    @telefonoEmpleado NVARCHAR(15),
	@emailEmpleado NVARCHAR(50)
AS
BEGIN
    IF @idEmpleado = 0
    BEGIN
        -- Insertar nuevo empleado
        INSERT INTO Empleados(Nombre, Apellido, Cargo, Telefono, Email)
        VALUES (@nombreEmpleado, @apellidoEmpleado, @cargo, @telefonoEmpleado, @emailEmpleado);
    END
    ELSE
    BEGIN
        -- Actualizar empleado existente
        UPDATE Empleados
        SET Nombre = @nombreEmpleado, Apellido = @apellidoEmpleado, Cargo = @cargo, Telefono = @telefonoEmpleado, Email = @emailEmpleado
        WHERE Id = @idEmpleado;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarPago]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspGuardarPago]
    @idPago INT,
    @idReserva INT,
    @monto DECIMAL(10,2),
    @metodoPago NVARCHAR(50),
    @fechaPago DATE
AS
BEGIN
    IF @idPago = 0
        -- Insertar nuevo pago
        INSERT INTO Pagos (ReservaId, Monto, MetodoPago, FechaPago)
        VALUES (@idReserva, @monto, @metodoPago, @fechaPago);
    ELSE
	BEGIN
        -- Actualizar pago existente
        UPDATE Pagos
        SET ReservaId = @idReserva, Monto = @monto, MetodoPago = @metodoPago, FechaPago = @fechaPago
        WHERE Id = @idPago;
	END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarReservas]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGuardarReservas]
    @idReserva INT,
    @idCliente INT,
    @idVehiculo INT,
    @fechaInicio DATE,
    @fechaFin DATE,
    @estado NVARCHAR(20)
AS
BEGIN
    IF @idReserva = 0
    BEGIN
        -- Insertar nueva reserva
        INSERT INTO Reservas (ClienteId, VehiculoId, FechaInicio, FechaFin, Estado)
        VALUES (@idCliente, @idVehiculo, @fechaInicio, @fechaFin, @estado);
    END
    ELSE
    BEGIN
        -- Actualizar reserva existente
        UPDATE Reservas
        SET ClienteId = @idCliente,
            VehiculoId = @idVehiculo,
            FechaInicio = @fechaInicio,
            FechaFin = @fechaFin,
            Estado = @estado
        WHERE Id = @idReserva;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarSeguro]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGuardarSeguro]
    @idSeguro INT,
    @idReserva INT,
    @tipoSeguro NVARCHAR(50),
    @costo DECIMAL(10, 2)
AS
BEGIN
    IF @idSeguro = 0
    BEGIN
        -- Insertar nuevo pago
        INSERT INTO Seguros(ReservaId, TipoSeguro, Costo)
        VALUES (@idReserva, @tipoSeguro, @costo);
    END
    ELSE
    BEGIN
        -- Actualizar pago existente
        UPDATE Seguros
        SET ReservaId = @idReserva,
			TipoSeguro = @tipoSeguro, 
			Costo = @costo
        WHERE Id = @idSeguro;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspGuardarVehiculos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGuardarVehiculos]
    @idVehiculo INT,
    @marca NVARCHAR(50),
    @modelo NVARCHAR(50),
    @anio INT,
    @precio DECIMAL(10,2),
    @estado NVARCHAR(20)
AS
BEGIN
    IF @idVehiculo = 0
    BEGIN
        -- Insertar un nuevo vehículo
        INSERT INTO Vehiculos (Marca, Modelo, Anio, Precio, Estado)
        VALUES (@marca, @modelo, @anio, @precio, @estado);
    END
    ELSE
    BEGIN
        -- Actualizar un vehículo existente
        UPDATE Vehiculos
        SET Marca = @marca,
            Modelo = @modelo,
            Anio = @anio,
            Precio = @precio,
            Estado = @estado
        WHERE Id = @idVehiculo;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarClientes]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspListarClientes]
AS
BEGIN
    SELECT * FROM Clientes
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarEmpleados]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspListarEmpleados]
AS
BEGIN
    SELECT * FROM Empleados;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarPagos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspListarPagos]
AS
BEGIN
    SELECT * FROM Pagos;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarReservas]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspListarReservas]
AS
BEGIN
    SELECT * FROM Reservas;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarSeguros]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspListarSeguros]
AS
BEGIN
    SELECT * FROM Seguros;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarVehiculos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspListarVehiculos]
AS
BEGIN
    SELECT * FROM Vehiculos;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarClientes]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRecuperarClientes]
	@idCliente INT
AS
BEGIN
    SELECT * FROM Clientes
    WHERE Id = @idCliente
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarEmpleado]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRecuperarEmpleado]
    @idEmpleado INT
AS
BEGIN
    SELECT * FROM Empleados WHERE Id = @idEmpleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarPago]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspRecuperarPago]
    @idPago INT
AS
BEGIN
    SELECT * FROM Pagos 
    WHERE Id = @idPago;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarReservas]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRecuperarReservas]
    @idReserva INT
AS
BEGIN
    SELECT * FROM Reservas
    WHERE Id = @idReserva;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarSeguro]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRecuperarSeguro]
    @idSeguro INT
AS
BEGIN
    SELECT * FROM Seguros WHERE Id = @idSeguro;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarVehiculos]    Script Date: 5/3/25 1:39:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspRecuperarVehiculos]
@idVehiculo INT
AS
BEGIN
    SELECT *
    FROM Vehiculos
    WHERE Id = @idVehiculo

END;
GO
