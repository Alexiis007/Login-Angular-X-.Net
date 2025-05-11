CREATE DATABASE Pruebas

USE Pruebas
GO

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(150) NOT NULL UNIQUE,
    Contrase�aHash NVARCHAR(256) NOT NULL,
    Rol NVARCHAR(50) NOT NULL DEFAULT 'usuario',
    FechaRegistro DATETIME DEFAULT GETDATE(),
    Activo BIT DEFAULT 1
);

INSERT INTO Usuarios (Nombre, Apellido, Correo, Contrase�aHash, Rol,  Activo)
VALUES 
('Juan', 'P�rez', 'juan.perez@example.com', 'hashedpassword123', 'admin',  1)
INSERT INTO Usuarios (Nombre, Apellido, Correo, Contrase�aHash, Rol,  Activo)
VALUES 
('Mar�a', 'L�pez', 'maria.lopez@example.com', 'hashedpassword456', 'usuario', 1)
INSERT INTO Usuarios (Nombre, Apellido, Correo, Contrase�aHash, Rol,  Activo)
VALUES 
('Carlos', 'Ram�rez', 'carlos.ramirez@example.com', 'hashedpassword789', 'usuario', 1)
INSERT INTO Usuarios (Nombre, Apellido, Correo, Contrase�aHash, Rol,  Activo)
VALUES 
('Ana', 'Torres', 'ana.torres@example.com', 'hashedpassword321', 'moderador', 0)
INSERT INTO Usuarios (Nombre, Apellido, Correo, Contrase�aHash, Rol,  Activo)
VALUES 
('Christian', 'Juarez', 'cjuarez@exsoinf.com', 'A03pI5', 'admin', 1)



SELECT * FROM Usuarios