-- Crear la base de datos
CREATE DATABASE SistemaReservaciones;
GO

-- Usar la base de datos
USE SistemaReservaciones;
GO

-- Crear la tabla Clientes
CREATE TABLE Clientes (
    IdCliente INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellidos NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(15),
    CorreoElectronico NVARCHAR(100)
);
GO

-- Crear la tabla Menu
CREATE TABLE Menu (
    IdMenu INT IDENTITY(1,1) PRIMARY KEY,
    Descripcion NVARCHAR(200) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL
);
GO

-- Crear la tabla Mesas
CREATE TABLE Mesas (
    IdMesa INT IDENTITY(1,1) PRIMARY KEY,
    NumeroMesa INT NOT NULL,
    DescripcionMesa NVARCHAR(200)
);
GO

-- Crear la tabla Reservaciones
CREATE TABLE Reservaciones (
    NumeroReservacion INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL,
    IdMesa INT NOT NULL,
    IdMenu INT NOT NULL,
    Cantidad INT NOT NULL,
    FechaReservacion DATETIME NOT NULL,
    FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente) ON DELETE CASCADE,
    FOREIGN KEY (IdMesa) REFERENCES Mesas(IdMesa) ON DELETE CASCADE,
    FOREIGN KEY (IdMenu) REFERENCES Menu(IdMenu) ON DELETE CASCADE
);
GO

-- Procedimientos para Clientes
CREATE PROCEDURE recClientes
AS
BEGIN
    SELECT IdCliente, Nombre, Apellidos, Telefono, CorreoElectronico
    FROM Clientes;
END;
GO

CREATE PROCEDURE recClientesXId
    @IdCliente INT
AS
BEGIN
    SELECT IdCliente, Nombre, Apellidos, Telefono, CorreoElectronico
    FROM Clientes
    WHERE IdCliente = @IdCliente;
END;
GO

CREATE PROCEDURE insCliente
    @Nombre NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @Telefono NVARCHAR(15),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    INSERT INTO Clientes (Nombre, Apellidos, Telefono, CorreoElectronico)
    VALUES (@Nombre, @Apellidos, @Telefono, @CorreoElectronico);
END;
GO

CREATE PROCEDURE updCliente
    @IdCliente INT,
    @Nombre NVARCHAR(100),
    @Apellidos NVARCHAR(100),
    @Telefono NVARCHAR(15),
    @CorreoElectronico NVARCHAR(100)
AS
BEGIN
    UPDATE Clientes
    SET Nombre = @Nombre,
        Apellidos = @Apellidos,
        Telefono = @Telefono,
        CorreoElectronico = @CorreoElectronico
    WHERE IdCliente = @IdCliente;
END;
GO

CREATE PROCEDURE delCliente
    @IdCliente INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Reservaciones WHERE IdCliente = @IdCliente)
    BEGIN
        PRINT 'No se puede eliminar. El cliente tiene reservaciones asociadas.';
        RETURN;
    END
    DELETE FROM Clientes
    WHERE IdCliente = @IdCliente;
END;
GO

-- Procedimientos para Menu
CREATE PROCEDURE recMenu
AS
BEGIN
    SELECT IdMenu, Descripcion, Precio
    FROM Menu;
END;
GO

CREATE PROCEDURE recMenuXId
    @IdMenu INT
AS
BEGIN
    SELECT IdMenu, Descripcion, Precio
    FROM Menu
    WHERE IdMenu = @IdMenu;
END;
GO

CREATE PROCEDURE insMenu
    @Descripcion NVARCHAR(200),
    @Precio DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Menu (Descripcion, Precio)
    VALUES (@Descripcion, @Precio);
END;
GO

CREATE PROCEDURE updMenu
    @IdMenu INT,
    @Descripcion NVARCHAR(200),
    @Precio DECIMAL(10,2)
AS
BEGIN
    UPDATE Menu
    SET Descripcion = @Descripcion,
        Precio = @Precio
    WHERE IdMenu = @IdMenu;
END;
GO

CREATE PROCEDURE delMenu
    @IdMenu INT
AS
BEGIN
    DELETE FROM Menu
    WHERE IdMenu = @IdMenu;
END;
GO

-- Procedimientos para Mesas
CREATE PROCEDURE recMesas
AS
BEGIN
    SELECT IdMesa, NumeroMesa, DescripcionMesa
    FROM Mesas;
END;
GO

CREATE PROCEDURE recMesasXId
    @IdMesa INT
AS
BEGIN
    SELECT IdMesa, NumeroMesa, DescripcionMesa
    FROM Mesas
    WHERE IdMesa = @IdMesa;
END;
GO

CREATE PROCEDURE insMesa
    @NumeroMesa INT,
    @DescripcionMesa NVARCHAR(200)
AS
BEGIN
    INSERT INTO Mesas (NumeroMesa, DescripcionMesa)
    VALUES (@NumeroMesa, @DescripcionMesa);
END;
GO

CREATE PROCEDURE updMesa
    @IdMesa INT,
    @NumeroMesa INT,
    @DescripcionMesa NVARCHAR(200)
AS
BEGIN
    UPDATE Mesas
    SET NumeroMesa = @NumeroMesa,
        DescripcionMesa = @DescripcionMesa
    WHERE IdMesa = @IdMesa;
END;
GO

CREATE PROCEDURE delMesa
    @IdMesa INT
AS
BEGIN
    DELETE FROM Mesas
    WHERE IdMesa = @IdMesa;
END;
GO

-- Procedimientos para Reservaciones
CREATE PROCEDURE recReservaciones
AS 
BEGIN   
    SELECT R.NumeroReservacion,  
           R.IdCliente,  
           C.Nombre + ' ' + C.Apellidos AS Cliente,
           R.IdMesa,
           R.IdMenu,
           Me.Descripcion AS Menu,
           R.Cantidad,        
           R.FechaReservacion   
    FROM Reservaciones R    
    JOIN Clientes C ON R.IdCliente = C.IdCliente  
    JOIN Mesas M ON R.IdMesa = M.IdMesa   
    JOIN Menu Me ON R.IdMenu = Me.IdMenu;
END;
GO

CREATE PROCEDURE recReservacionesXId
    @NumeroReservacion INT
AS
BEGIN
    SELECT R.NumeroReservacion, 
           R.IdCliente,  
           C.Nombre + ' ' + C.Apellidos AS Cliente,
           R.IdMesa,
           R.IdMenu,
           Me.Descripcion AS Menu,
           R.Cantidad, 
           R.FechaReservacion
    FROM Reservaciones R
    JOIN Clientes C ON R.IdCliente = C.IdCliente
    JOIN Mesas M ON R.IdMesa = M.IdMesa
    JOIN Menu Me ON R.IdMenu = Me.IdMenu
    WHERE R.NumeroReservacion = @NumeroReservacion;
END;
GO

CREATE PROCEDURE insReservacion
    @IdCliente INT,
    @IdMesa INT,
    @IdMenu INT,
    @Cantidad INT,
    @FechaReservacion DATETIME
AS
BEGIN
    INSERT INTO Reservaciones (IdCliente, IdMesa, IdMenu, Cantidad, FechaReservacion)
    VALUES (@IdCliente, @IdMesa, @IdMenu, @Cantidad, @FechaReservacion);
END;
GO

CREATE PROCEDURE updReservacion
    @NumeroReservacion INT,
    @IdCliente INT,
    @IdMesa INT,
    @IdMenu INT,
    @Cantidad INT,
    @FechaReservacion DATETIME
AS
BEGIN
    UPDATE Reservaciones
    SET IdCliente = @IdCliente,
        IdMesa = @IdMesa,
        IdMenu = @IdMenu,
        Cantidad = @Cantidad,
        FechaReservacion = @FechaReservacion
    WHERE NumeroReservacion = @NumeroReservacion;
END;
GO

CREATE PROCEDURE delReservacion
    @NumeroReservacion INT
AS
BEGIN
    DELETE FROM Reservaciones
    WHERE NumeroReservacion = @NumeroReservacion;
END;
GO
