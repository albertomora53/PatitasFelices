# 

Patitas Felices es un sistema web integral diseñado para la gestión y seguimiento de procesos de adopción de mascotas. Conecta a refugios/albergues con potenciales adoptantes a través de un catálogo centralizado y un flujo automatizado de solicitudes. El proyecto está desarrollado bajo una Arquitectura orientada a servicios (SOA) en Capas, garantizando escalabilidad, seguridad e integridad en la gestión de datos

Estructura del proyecto

├── Adopcion (Frontend ASP.NET Web Forms)

├── AdopcionWS (Servicios Web SOAP ASMX)

├── Adopcion_Data (Librería de Clases / DAL / Encriptación AES / Validaciones)

└── Database/ (Scripts y Modelo Relacional SQL)


Requisitos Previos
Visual Studio community 21 o Visual Studio (2019 o posterior) con soporte para ASP.NET y desarrollo web.Microsoft 
SQL Server (2021 o superior / Nivel de compatibilidad 160).   
.NET Framework 4.x


- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

## Modelo de Base de Datos

El sistema utiliza una base de datos relacional en **SQL Server Management Studio 21** 

### Entidades Principales
* **`User`**: Gestión de cuentas y control de acceso basado en roles (`1: Admin`, `2: Refugio`, `3: Adoptante`).
* **`Refugio`**: Registro de albergues y organizaciones asociadas.
* **`Animales`**: Catálogo de mascotas disponibles asociadas a un refugio (`1:N` con `Refugio`).
* **`Solicitud_Adopcion`**: Registro transaccional de trámites de adopción enlazando adoptantes con mascotas (`N:M` mediante FKs).

---

###  Despliegue Rápido de la Base de Datos

Para replicar el esquema en tu servidor local, ejecuta el siguiente script en **SQL Server Management Studio (SSMS)**:

```sql
CREATE DATABASE Adopcion;
GO
USE Adopcion;
GO

-- 1. Tabla de Usuarios
CREATE TABLE [User] (
    Id_Usuario INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(15) NOT NULL UNIQUE,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido_Pat NVARCHAR(50),
    Apellido_Mat NVARCHAR(50),
    Telefono NVARCHAR(15),
    Correo NVARCHAR(50) NOT NULL,
    RFC NVARCHAR(13),
    [password] NVARCHAR(128) NOT NULL, -- Almacenada con cifrado AES
    tipo INT NOT NULL,                -- 1: Admin, 2: Refugio, 3: Adoptante
    Fecha DATETIME DEFAULT GETDATE(),
    Ref NVARCHAR(50)
);

-- 2. Tabla de Refugios
CREATE TABLE Refugio (
    Id_Refugio INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Direccion NVARCHAR(150) NOT NULL,
    Estado NVARCHAR(50) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Ref NVARCHAR(50)
);

-- 3. Tabla de Animales (Mascotas)
CREATE TABLE Animales (
    Id_Animal INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL,
    Especie NVARCHAR(50) NOT NULL,
    Id_Refugio INT NOT NULL FOREIGN KEY REFERENCES Refugio(Id_Refugio),
    Descripcion NVARCHAR(200) NOT NULL,
    Fecha DATETIME DEFAULT GETDATE(),
    Genero NVARCHAR(50) NOT NULL,
    Edad NVARCHAR(50) NOT NULL,
    Imagen NVARCHAR(50) NOT NULL,
    Tamano NVARCHAR(50),
    Personalidad NVARCHAR(50)
);

-- 4. Tabla Transaccional de Solicitudes
CREATE TABLE Solicitud_Adopcion (
    Id_Solicitud INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL FOREIGN KEY REFERENCES [User](Id_Usuario),
    Id_Animal INT NOT NULL FOREIGN KEY REFERENCES Animales(Id_Animal),
    Situacion NVARCHAR(50) NOT NULL, -- Pendiente, Aprobada, Rechazada
    Fecha DATETIME DEFAULT GETDATE(),
    Folio NVARCHAR(50)
);
GO
