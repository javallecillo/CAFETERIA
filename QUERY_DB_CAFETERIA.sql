use db_cafeteria

CREATE TABLE Categorias (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(MAX) NULL
);

CREATE TABLE Ingredientes (
    IdIngrediente INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    CantidadDisponible INT NOT NULL DEFAULT 0,
    UnidadMedida VARCHAR(50) NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Usuarios (
    IdUsuario INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Contraseña VARCHAR(255) NOT NULL,
    Rol VARCHAR(20) NOT NULL CHECK (Rol IN ('Empleado', 'Administrador'))
);

CREATE TABLE Productos (
    IdProducto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    IdCategoria INT NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL,
    Descripcion VARCHAR(MAX) NULL,
    Stock INT NOT NULL DEFAULT 0,
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);

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
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    IdProducto INT NOT NULL,
    Cantidad INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Estado VARCHAR(20) NOT NULL CHECK (Estado IN ('Pendiente', 'Completado', 'Cancelado')),
    FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto)
);

CREATE TABLE Reportes (
    IdReporte INT PRIMARY KEY IDENTITY(1,1),
    TipoReporte VARCHAR(20) NOT NULL CHECK (TipoReporte IN ('Entradas', 'Salidas', 'Ventas')),
    Fecha DATETIME NOT NULL,
    Contenido VARCHAR(MAX) NOT NULL
);
