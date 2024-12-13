

CREATE TABLE Categorias (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(MAX) NULL
);

CREATE TABLE Almacen (
    IdAlmacen INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(MAX) NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
	Stock INT NOT NULL DEFAULT 0,
    UnidadMedida VARCHAR(50) NOT NULL
);

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(100) NOT NULL,
    Contrasenia VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('Empleado', 'Administrador'))
);

CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    IdCategoria INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Descripcion VARCHAR(MAX) NULL,
    Stock INT NULL,
	CONSTRAINT FK_IdCategoria FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);

CREATE TABLE Entradas (
    IdEntrada INT PRIMARY KEY IDENTITY(1,1), -- Identificador único para cada entrada
    IdAlmacen INT NOT NULL,              -- Llave foránea que vincula con Almacen
    FechaEntrada DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha y hora de la entrada
    Cantidad INT NOT NULL,                   -- Cantidad ingresada
    CostoTotal DECIMAL(10, 2) NOT NULL,      -- Costo total de la entrada (opcional, para gestión financiera)
    IdUsuario INT NOT NULL,                  -- Llave foránea que identifica al usuario que realizó la entrada
    Observaciones VARCHAR(MAX) NULL,         -- Observaciones adicionales sobre la entrada            
	CONSTRAINT FK_IdAlmacen FOREIGN KEY (IdAlmacen) REFERENCES Almacen(IdAlmacen), -- Relación con Almacen
	CONSTRAINT FK_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) -- Relación con Usuarios
);

CREATE TABLE Salidas (
    IdSalida INT PRIMARY KEY IDENTITY(1,1),           -- Identificador único para cada salida
    IdAlmacen INT NOT NULL,                             -- Llave foránea que vincula con Almacen
    FechaSalida DATETIME NOT NULL DEFAULT GETDATE(),   -- Fecha y hora de la salida
    Cantidad INT NOT NULL,                              -- Cantidad retirada (disminución de stock)
    IdUsuario INT NOT NULL,                             -- Llave foránea que identifica al usuario que realizó la salida
    Observaciones VARCHAR(MAX) NULL,                    -- Observaciones adicionales sobre la salida
    CONSTRAINT FK_IdAlmacen_Salidas FOREIGN KEY (IdAlmacen) REFERENCES Almacen(IdAlmacen),  -- Relación con Almacen
    CONSTRAINT FK_IdUsuario_Salidas FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) -- Relación con Usuarios
);

CREATE TABLE Pedidos (
    IdPedido INT PRIMARY KEY IDENTITY(1,1), -- Identificador único para el pedido
    Fecha DATETIME NOT NULL DEFAULT GETDATE(), -- Fecha y hora del pedido
    TipoPedido VARCHAR(50) NOT NULL CHECK (TipoPedido IN ('Mesa', 'Para Llevar', 'Domicilio')), -- Tipo de pedido
    NumeroMesa INT NULL, -- Número de mesa
    FormaPago VARCHAR(50) NOT NULL CHECK (FormaPago IN ('Efectivo', 'Tarjeta', 'Transferencia')),
    IdUsuario INT NOT NULL, -- Usuario que realiza el pedido
    Total DECIMAL(10,2) NOT NULL, -- Total del pedido
    CONSTRAINT FK_IdUsuario_Pedidos FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario) -- Relación con la tabla Usuarios
);


CREATE TABLE DetallePedidos (
    IdDetallePedido INT PRIMARY KEY IDENTITY(1,1), -- Identificador único del detalle del pedido
    IdPedido INT NOT NULL,                         -- Relación con el pedido principal
    IdProducto INT NOT NULL,                       -- Relación con el producto
    Cantidad INT NOT NULL,                         -- Cantidad de este producto en el pedido
    PrecioUnitario DECIMAL(10,2) NOT NULL,         -- Precio unitario del producto al momento del pedido
    Subtotal DECIMAL(10,2) NOT NULL,               -- Cantidad * PrecioUnitario
    FOREIGN KEY (IdPedido) REFERENCES Pedidos(IdPedido), -- Relación con la tabla Pedidos
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto) -- Relación con la tabla Productos
);





SELECT * FROM Almacen
DROP TABLE Almacen;

INSERT INTO Usuarios (Usuario, Contrasenia, Rol) VALUES ('admin', 'admin', 'Administrador');
ALTER TABLE Usuarios
ALTER COLUMN Usuario VARCHAR(100) COLLATE Latin1_General_BIN;
SELECT * FROM Usuarios WHERE Usuario = 'Jorge'

DROP TABLE IF EXISTS Pedidos;
ALTER TABLE DetallePedidos DROP CONSTRAINT FK__DetallePe__IdPed__06CD04F7;

SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='Salidas';

EXEC sp_fkeys 'Entradas';

ALTER TABLE Entradas DROP CONSTRAINT FK_IdIngrediente;

DROP TABLE Ingredientes;

DROP TABLE Entradas;

select * from Entradas;
select * from Almacen;

SELECT e.IdEntrada, a.Nombre AS Producto, e.FechaEntrada, CONCAT(CAST (e.Cantidad AS NVARCHAR), ' ', a.UnidadMedida) AS CantidadMedida, e.CostoTotal, u.Usuario AS Usuario, e.Observaciones FROM Entradas e INNER JOIN Almacen a ON e.IdAlmacen = a.IdAlmacen INNER JOIN Usuarios u ON e.IdUsuario = u.IdUsuario

UPDATE Entradas
SET 
    IdAlmacen = 1,
    FechaEntrada = '2024-12-05 10:01:00.000',
    Cantidad = 20,
    CostoTotal = 1000.00,
    IdUsuario = 1,
    Observaciones = 'Actualización de prueba'
WHERE 
    IdEntrada = 1;

UPDATE Entradas
SET Observaciones = 'Nueva observación de prueba'
WHERE IdEntrada = 1;


truncate table Entradas
truncate table Salidas

SELECT * FROM Entradas WHERE IdEntrada = 1;

SELECT Nombre FROM Almacen WHERE Nombre LIKE '%vaso%'

SELECT * FROM Pedidos
SELECT * FROM DetallePedidos

truncate table Pedidos

SELECT p.IdPedido, p.Fecha, p.Total, u.Usuario AS Usuario, p.TipoPedido, p.FormaPago FROM Pedidos p INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario 

SELECT d.IdDetallePedido, p.Nombre AS Nombre, d.PrecioUnitario, d.Cantidad, d.Subtotal FROM DetallePedidos d INNER JOIN Productos p ON d.IdProducto = p.IdProducto WHERE d.IdPedido = 9

SELECT 
            d.IdDetallePedido, 
            p.Nombre AS Nombre, 
            d.PrecioUnitario, 
            d.Cantidad, 
            d.Subtotal
        FROM 
            DetallePedidos d
        INNER JOIN 
            Productos p ON d.IdProducto = p.IdProducto
        WHERE d.IdPedido = @IdPedido

SELECT p.IdPedido, p.Fecha, p.Total, u.Usuario AS Usuario, p.TipoPedido, p.FormaPago FROM Pedidos p INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario WHERE CAST(p.Fecha AS DATE) = CAST(GETDATE() AS DATE)

SELECT p.IdPedido, p.Fecha, p.Total, u.Usuario AS Usuario, p.TipoPedido, p.FormaPago FROM Pedidos p INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario

SELECT p.IdPedido, p.Fecha, p.Total, u.Usuario AS Usuario, p.TipoPedido, p.FormaPago FROM Pedidos p INNER JOIN Usuarios u ON p.IdUsuario = u.IdUsuario WHERE p.IdUsuario = @IdUsuario