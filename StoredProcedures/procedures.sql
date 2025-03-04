CREATE PROCEDURE [dbo].[uspEliminarCliente]
@id INT
AS
BEGIN
    DELETE FROM Clientes
    WHERE id = @id
END;

CREATE PROCEDURE uspEliminarEmpleado
    @idEmpleado INT
AS
BEGIN
    DELETE FROM Empleados WHERE Id = @idEmpleado;
END;

CREATE PROCEDURE uspEliminarPago
    @IdPago INT
AS
BEGIN
    DELETE FROM Pagos WHERE Id = @IdPago;
END;

CREATE PROCEDURE [dbo].[uspEliminarReservas]
    @Id INT
AS
BEGIN

    DELETE FROM Reservas WHERE Id = @Id;
END;

CREATE PROCEDURE uspEliminarSeguro
    @idSeguro INT
AS
BEGIN
    DELETE FROM Seguros WHERE Id = @idSeguro;
END;

CREATE PROCEDURE [dbo].[uspEliminarVehiculos]
@id INT
AS
BEGIN
    DELETE FROM Vehiculos
    WHERE id = @id
END;

CREATE PROCEDURE [dbo].[uspFiltrarClientes]
@nombre NVARCHAR(100)
AS
BEGIN
    IF @nombre = ''
        SELECT * FROM Clientes
    ELSE
        SELECT * FROM Clientes WHERE Nombre LIKE '%' + @nombre + '%'
END;

CREATE PROCEDURE uspFiltrarEmpleados
     @nombreEmpleado NVARCHAR(50)
AS
BEGIN

    IF @nombreEmpleado = ''
        SELECT * FROM Empleados;
    ELSE
        SELECT * FROM Empleados WHERE Nombre LIKE '%' + @nombreEmpleado + '%';
END;

CREATE PROCEDURE uspFiltrarPagos
    @MetodoPago NVARCHAR(50)
AS
BEGIN
    IF @MetodoPago = ''
        SELECT * FROM Pagos;
    ELSE
        SELECT * FROM Pagos WHERE MetodoPago LIKE '%' + @MetodoPago + '%';
END;

CREATE PROCEDURE [dbo].[uspFiltrarReservas]
    @ClienteId INT
AS
BEGIN
    IF @ClienteId = 0
        SELECT Id, ClienteId, VehiculoId, FechaInicio, FechaFin, Estado
        FROM Reservas;
    ELSE
        SELECT Id, ClienteId, VehiculoId, FechaInicio, FechaFin, Estado
        FROM Reservas
        WHERE ClienteId = @ClienteId;
END;

CREATE PROCEDURE uspFiltrarSeguros
    @tipoSeguro NVARCHAR(50)
AS
BEGIN

    IF @tipoSeguro = ''
        SELECT * FROM Seguros;
    ELSE
        SELECT * FROM Seguros WHERE TipoSeguro LIKE '%' + @tipoSeguro + '%';
END;

CREATE PROCEDURE [dbo].[uspFiltrarVehiculos]
@marca NVARCHAR(50)
AS
BEGIN
    IF @marca = ''
    BEGIN
        SELECT Id, 
               Marca, 
               Modelo, 
               Anio, 
               Precio, 
               Estado
        FROM Vehiculos
    END
    ELSE
    BEGIN
        SELECT Id, 
               Marca, 
               Modelo, 
               Anio, 
               Precio, 
               Estado
        FROM Vehiculos
        WHERE Marca LIKE '%' + @marca + '%'  -- Filtra solo por la marca
    END
END;

CREATE PROCEDURE [dbo].[uspGuardarCliente]
@id INT,
@nombre NVARCHAR(100),
@apellido NVARCHAR(100),
@telefono NVARCHAR(15),
@email NVARCHAR(100)
AS
BEGIN
    IF @id = 0
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
        WHERE id = @id
    END
END;

CREATE PROCEDURE uspGuardarEmpleado
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

CREATE PROCEDURE uspGuardarPago
    @IdPago INT,
    @ReservaId INT,
    @Monto DECIMAL(10,2),
    @MetodoPago NVARCHAR(50),
    @FechaPago DATE
AS
BEGIN
    IF @IdPago = 0
        -- Insertar nuevo pago
        INSERT INTO Pagos (ReservaId, Monto, MetodoPago, FechaPago)
        VALUES (@ReservaId, @Monto, @MetodoPago, @FechaPago);
    ELSE
        -- Actualizar pago existente
        UPDATE Pagos
        SET ReservaId = @ReservaId, Monto = @Monto, MetodoPago = @MetodoPago, FechaPago = @FechaPago
        WHERE Id = @IdPago;
END;

CREATE PROCEDURE [dbo].[uspGuardarReservas]
    @Id INT,
    @ClienteId INT,
    @VehiculoId INT,
    @FechaInicio DATE,
    @FechaFin DATE,
    @Estado NVARCHAR(20)
AS
BEGIN


    IF @Id = 0
    BEGIN
        -- Insertar nueva reserva
        INSERT INTO Reservas (ClienteId, VehiculoId, FechaInicio, FechaFin, Estado)
        VALUES (@ClienteId, @VehiculoId, @FechaInicio, @FechaFin, @Estado);
    END
    ELSE
    BEGIN
        -- Actualizar reserva existente
        UPDATE Reservas
        SET ClienteId = @ClienteId,
            VehiculoId = @VehiculoId,
            FechaInicio = @FechaInicio,
            FechaFin = @FechaFin,
            Estado = @Estado
        WHERE Id = @Id;
    END
END;

CREATE PROCEDURE uspGuardarSeguro
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

CREATE PROCEDURE [dbo].[uspGuardarVehiculos]
@iidvehiculo INT,
@marca NVARCHAR(50),
@modelo NVARCHAR(50),
@anio INT,
@precio DECIMAL(10,2),
@estado NVARCHAR(20)
AS
BEGIN

    IF @iidvehiculo = 0
    -- Insertar
    BEGIN
        INSERT INTO Vehiculos (Marca, Modelo, Anio, Precio, Estado)
        VALUES (@marca, @modelo, @anio, @precio, @estado)
    END
    ELSE
    -- Actualizar
    BEGIN
        UPDATE Vehiculos
        SET Marca = @marca,
            Modelo = @modelo,
            Anio = @anio,
            Precio = @precio,
            Estado = @estado
        WHERE Id = @iidvehiculo
    END

END;

CREATE PROCEDURE [dbo].[uspListarClientes]
AS
BEGIN
    SELECT * FROM Clientes
END;

CREATE PROCEDURE uspListarEmpleados
AS
BEGIN
    SELECT * FROM Empleados;
END;

CREATE PROCEDURE uspListarPagos
AS
BEGIN
    SELECT * FROM Pagos;
END;

CREATE PROCEDURE [dbo].[uspListarReservas]
AS
BEGIN

    SELECT Id, ClienteId, VehiculoId, FechaInicio, FechaFin, Estado
    FROM Reservas;
END;

CREATE PROCEDURE uspListarSeguros
AS
BEGIN
    SET NOCOUNT ON;
    SELECT * FROM Seguros;
END;

CREATE PROCEDURE [dbo].[uspListarVehiculos]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id AS idVehiculo,  
           Marca, 
           Modelo, 
           Anio, 
           Precio, 
           Estado
    FROM Vehiculos;
END;

CREATE PROCEDURE [dbo].[uspRecuperarCliente]
@id INT
AS
BEGIN
    SELECT * FROM Clientes
    WHERE id = @id
END;

CREATE PROCEDURE uspRecuperarEmpleado
    @idEmpleado INT
AS
BEGIN
    SELECT * FROM Empleados WHERE Id = @idEmpleado;
END;

CREATE PROCEDURE uspRecuperarPago
    @IdPago INT
AS
BEGIN
    SELECT * FROM Pagos WHERE Id = @IdPago;
END;

CREATE PROCEDURE [dbo].[uspRecuperarReservas]
    @Id INT
AS
BEGIN
    SELECT Id, ClienteId, VehiculoId, FechaInicio, FechaFin, Estado
    FROM Reservas
    WHERE Id = @Id;
END;

CREATE PROCEDURE uspRecuperarSeguro
    @idSeguro INT
AS
BEGIN
    SELECT * FROM Seguros WHERE Id = @idSeguro;
END;

CREATE PROCEDURE [dbo].[uspRecuperarVehiculos]
@id INT
AS
BEGIN

    SELECT *
    FROM Vehiculos
    WHERE id = @id

END;