-- Crear la base de datos
CREATE DATABASE VeterinariaDb;
GO
USE VeterinariaDb;
GO

-- Crear tabla Clientes
CREATE TABLE Clientes (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Direccion VARCHAR(255),
    Telefono VARCHAR(20)
);

-- Crear tabla Mascotas
CREATE TABLE Mascotas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Especie VARCHAR(50),
    Raza VARCHAR(50),
    ClienteId INT,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id) ON DELETE CASCADE
);

-- Crear tabla Citas
CREATE TABLE Citas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    Motivo VARCHAR(255),
    MascotaId INT,
    FOREIGN KEY (MascotaId) REFERENCES Mascotas(Id) ON DELETE CASCADE
);

-- Crear tabla Servicios
CREATE TABLE Servicios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Descripcion VARCHAR(255),
    Precio DECIMAL(10, 2) NOT NULL
);

-- Crear tabla Historial
CREATE TABLE Historial (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    Descripcion VARCHAR(255),
    MascotaId INT,
    FOREIGN KEY (MascotaId) REFERENCES Mascotas(Id) ON DELETE CASCADE
);

-- Crear tabla intermedia para relacionar Mascotas con Servicios
CREATE TABLE MascotaServicios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    MascotaId INT,
    ServicioId INT,
    Fecha DATETIME NOT NULL,
    FOREIGN KEY (MascotaId) REFERENCES Mascotas(Id) ON DELETE CASCADE,
    FOREIGN KEY (ServicioId) REFERENCES Servicios(Id) ON DELETE CASCADE
);
