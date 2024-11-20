
use db_cafeteria

CREATE TABLE Categorias (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(MAX) NULL
);

CREATE TABLE Ingredientes (
    IdIngrediente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    UnidadMedida VARCHAR(50) NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Usuario VARCHAR(100) NOT NULL,
    Contrasenia VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('Empleado', 'Administrador'))
);

INSERT INTO Usuarios (Usuario, Contrasenia, Rol) VALUES ('admin', 'admin', 'Administrador');


CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    IdCategoria INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Descripcion VARCHAR(MAX) NULL,
    Stock INT NULL,
	CONSTRAINT FK_IdCategoria FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);

INSERT INTO Productos (Nombre, IdCategoria, Precio, Descripcion, Stock) VALUES ('Café Americano', 1, 15.50, 'Café negro tradicional', 0);
INSERT INTO Productos (Nombre, IdCategoria, Precio, Descripcion, Stock) VALUES ('Cafyyé ', 1, 15.50, 'Café negro', 10);

CREATE TABLE Stock (
    IdStock INT PRIMARY KEY IDENTITY(1,1),
    IdIngrediente INT NOT NULL,
    CantidadRestante INT NOT NULL,
    FechaActualizacion DATETIME NOT NULL,
    FOREIGN KEY (IdIngrediente) REFERENCES Ingredientes(IdIngrediente)
);

CREATE TABLE Entradas (
    IdEntrada INT PRIMARY KEY IDENTITY(1,1),
    IdIngrediente INT NOT NULL,
    Cantidad INT NOT NULL,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (IdIngrediente) REFERENCES Ingredientes(IdIngrediente)
);

CREATE TABLE Salidas (
    IdSalida INT PRIMARY KEY IDENTITY(1,1),
    IdIngrediente INT NOT NULL,
    Cantidad INT NOT NULL,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (IdIngrediente) REFERENCES Ingredientes(IdIngrediente)
);

CREATE TABLE Pedidos (
    IdPedido INT PRIMARY KEY IDENTITY(1,1), -- Identificador único del pedido
    Fecha DATETIME NOT NULL,                -- Fecha y hora en que se realizó el pedido
    TipoPedido VARCHAR(20) NOT NULL CHECK (TipoPedido IN ('Mesa', 'Para Llevar', 'Domicilio')), -- Tipo de pedido
    NumeroMesa INT NULL,                    -- Número de mesa (NULL si es para llevar o domicilio)
	TipoPago VARCHAR(20) NOT NULL CHECK (TipoPago IN ('Efectivo', 'Tarjeta', 'Mixto')),
    Subtotal DECIMAL(10,2) NOT NULL,        -- Subtotal del pedido antes de impuestos
    Total DECIMAL(10,2) NOT NULL,           -- Total del pedido después de impuestos
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



CREATE TABLE Reportes (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    TipoReporte VARCHAR(20) NOT NULL CHECK (TipoReporte IN ('Entradas', 'Salidas', 'Ventas')),
    Fecha DATETIME NOT NULL,
    Contenido VARCHAR(MAX) NOT NULL
);

DROP TABLE IF EXISTS Pedidos;
ALTER TABLE DetallePedidos DROP CONSTRAINT FK__DetallePe__IdPed__06CD04F7;

SELECT CONSTRAINT_NAME, CONSTRAINT_TYPE
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME='DetallePedidos';
