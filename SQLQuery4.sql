-- Crear la base de datos y seleccionarla
CREATE DATABASE cateringMID_db;
USE cateringMID_db;

-- Tablas de cuentas
CREATE TABLE Cuenta_cliente (
    id_cuenta_cliente UNIQUEIDENTIFIER PRIMARY KEY,
    correo NVARCHAR(100) NOT NULL,
    contrasenia NVARCHAR(255) NOT NULL,
    fecha_de_creacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE Cuenta_propietario (
    id_cuenta_propietario UNIQUEIDENTIFIER PRIMARY KEY,
    correo NVARCHAR(100) NOT NULL,
    contrasenia NVARCHAR(255) NOT NULL,
    fecha_de_creacion DATETIME DEFAULT GETDATE()
);

-- Tablas principales de información
CREATE TABLE Propietario_empresa (
    id_propietario UNIQUEIDENTIFIER PRIMARY KEY,
    id_cuenta UNIQUEIDENTIFIER NOT NULL,
    nombre NVARCHAR(250) NOT NULL,
    apellido NVARCHAR(250) NOT NULL,
    telefono NVARCHAR(250) NOT NULL,
    rfc NVARCHAR(250) NOT NULL,
    clave NVARCHAR(250) NOT NULL,
    link_imagen NVARCHAR(MAX) NOT NULL,
    fecha_de_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_cuenta) REFERENCES Cuenta_propietario(id_cuenta_propietario)
);

CREATE TABLE Cliente (
    id_cliente UNIQUEIDENTIFIER PRIMARY KEY,
    id_cuenta UNIQUEIDENTIFIER NOT NULL,
    nombre NVARCHAR(250) NOT NULL,
    apellido NVARCHAR(250) NOT NULL,
    telefono NVARCHAR(250) NOT NULL,
    latitud DECIMAL(9, 6),
    longitud DECIMAL(9, 6),
    rfc NVARCHAR(250) NOT NULL,
    fecha_de_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_cuenta) REFERENCES Cuenta_cliente(id_cuenta_cliente)
);

CREATE TABLE Empresa (
    id_empresa UNIQUEIDENTIFIER PRIMARY KEY,
    id_propietario UNIQUEIDENTIFIER NOT NULL,
    nombre NVARCHAR(250) NOT NULL,
    link_facebook NVARCHAR(250),
    link_instagram NVARCHAR(250),
    link_logo NVARCHAR(250),
    correo NVARCHAR(250) NOT NULL,
    telefono NVARCHAR(250) NOT NULL,
    direccion NVARCHAR(250) NOT NULL,
    latitud DECIMAL(9, 6),
    longitud DECIMAL(9, 6),
    fecha_de_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_propietario) REFERENCES Propietario_empresa(id_propietario)
);

CREATE TABLE Imagenes_empresa (
    id_imagen UNIQUEIDENTIFIER PRIMARY KEY,
    id_empresa UNIQUEIDENTIFIER NOT NULL,
    nombre NVARCHAR(250) NOT NULL,
    link_imagen NVARCHAR(MAX) NOT NULL,
    fecha_de_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa)
);

-- Tablas de platillos y bebidas
CREATE TABLE Platillo (
    id_platillo UNIQUEIDENTIFIER PRIMARY KEY,
    id_empresa UNIQUEIDENTIFIER NOT NULL,
    costo INT NOT NULL,
    descripcion NVARCHAR(250) NOT NULL,
    link_imagen NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa)
);

CREATE TABLE Bebida (
    id_bebida UNIQUEIDENTIFIER PRIMARY KEY,
    id_empresa UNIQUEIDENTIFIER NOT NULL,
    costo INT NOT NULL,
    descripcion NVARCHAR(250) NOT NULL,
    link_imagen NVARCHAR(MAX) NOT NULL,
    FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa)
);

-- Tablas de reservas
CREATE TABLE Reserva_info_cliente (
    id_info UNIQUEIDENTIFIER PRIMARY KEY,
    primer_nombre NVARCHAR(250) NOT NULL,
    segundo_nombre NVARCHAR(250),
    primer_telefono NVARCHAR(250) NOT NULL,
    segundo_telefono NVARCHAR(250)
);

CREATE TABLE Reserva_direccion (
    id_direccion UNIQUEIDENTIFIER PRIMARY KEY,
    id_cliente UNIQUEIDENTIFIER NOT NULL,
    latitud DECIMAL(9, 6),           
    longitud DECIMAL(9, 6),         
    calle NVARCHAR(250) NOT NULL,   
    nombre_lugar NVARCHAR(250) NOT NULL, 
    num_casa NVARCHAR(250) NOT NULL,      
    referencias NVARCHAR(250) NOT NULL, 
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)
);

CREATE TABLE Platillo_reserva (
    id_menu_platillo UNIQUEIDENTIFIER PRIMARY KEY,
    id_platillo UNIQUEIDENTIFIER NOT NULL,
    cantidad INT NOT NULL,
    FOREIGN KEY (id_platillo) REFERENCES Platillo(id_platillo)
);

CREATE TABLE Bebida_reserva (
    id_menu_bebida UNIQUEIDENTIFIER PRIMARY KEY,
    id_bebida UNIQUEIDENTIFIER NOT NULL,
    cantidad INT NOT NULL,
    FOREIGN KEY (id_bebida) REFERENCES Bebida(id_bebida)
);

CREATE TABLE Menu_reserva (
    id_menu UNIQUEIDENTIFIER PRIMARY KEY,
    id_cliente UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)
);

CREATE TABLE Menu_platillo_reserva (
    id_menu UNIQUEIDENTIFIER NOT NULL,
    id_menu_platillo UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (id_menu) REFERENCES Menu_reserva(id_menu),
    FOREIGN KEY (id_menu_platillo) REFERENCES Platillo_reserva(id_menu_platillo),
    PRIMARY KEY (id_menu, id_menu_platillo)
);

CREATE TABLE Menu_bebida_reserva (
    id_menu UNIQUEIDENTIFIER NOT NULL,
    id_menu_bebida UNIQUEIDENTIFIER NOT NULL,
    FOREIGN KEY (id_menu) REFERENCES Menu_reserva(id_menu),
    FOREIGN KEY (id_menu_bebida) REFERENCES Bebida_reserva(id_menu_bebida),
    PRIMARY KEY (id_menu, id_menu_bebida)
);

CREATE TABLE Reserva (
    id_reserva UNIQUEIDENTIFIER PRIMARY KEY,
    id_menu UNIQUEIDENTIFIER NOT NULL,
    id_direccion UNIQUEIDENTIFIER NOT NULL,
    id_cliente UNIQUEIDENTIFIER NOT NULL,
    id_empresa UNIQUEIDENTIFIER NOT NULL,
    id_info UNIQUEIDENTIFIER NOT NULL,
    fecha DATE NOT NULL,
    hora TIME NOT NULL,
    costo DECIMAL(10, 2),
    anticipo DECIMAL(10, 2),
    completado BIT,
    fecha_de_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
    FOREIGN KEY (id_menu) REFERENCES Menu_reserva(id_menu),
    FOREIGN KEY (id_info) REFERENCES Reserva_info_cliente(id_info),
    FOREIGN KEY (id_direccion) REFERENCES Reserva_direccion(id_direccion)
);

-- Tablas de descuentos
CREATE TABLE Descuentos (
    id_descuento UNIQUEIDENTIFIER PRIMARY KEY,
    id_empresa UNIQUEIDENTIFIER NOT NULL,
    descripcion NVARCHAR(250) NOT NULL,
    link_imagen NVARCHAR(MAX) NOT NULL,
    cantidad INT NOT NULL,
    porcentaje INT NOT NULL,
    fecha_inicio DATE NOT NULL,
    hora_inicio TIME NOT NULL,
    fecha_fin DATE NOT NULL,
    hora_fin TIME NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa)
);

-- Tablas de calificación
CREATE TABLE Calificacion (
    id_calificacion UNIQUEIDENTIFIER PRIMARY KEY,
    id_empresa UNIQUEIDENTIFIER NOT NULL,
    id_cliente UNIQUEIDENTIFIER NOT NULL,
    comentario NVARCHAR(250) NOT NULL,
    estrellas INT NOT NULL,
    link_imagen NVARCHAR(MAX) NOT NULL,
    fecha_creacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (id_empresa) REFERENCES Empresa(id_empresa),
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente)
);
