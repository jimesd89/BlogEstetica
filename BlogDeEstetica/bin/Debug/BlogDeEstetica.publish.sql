/*
Script de implementación para EsteticIntDatabase

Una herramienta generó este código.
Los cambios realizados en este archivo podrían generar un comportamiento incorrecto y se perderán si
se vuelve a generar el código.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "EsteticIntDatabase"
:setvar DefaultFilePrefix "EsteticIntDatabase"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.PRUEBAS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.PRUEBAS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detectar el modo SQLCMD y deshabilitar la ejecución del script si no se admite el modo SQLCMD.
Para volver a habilitar el script después de habilitar el modo SQLCMD, ejecute lo siguiente:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'El modo SQLCMD debe estar habilitado para ejecutar correctamente este script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
Se está quitando la columna [dbo].[Publicacion].[Creador]; puede que se pierdan datos.

Se está quitando la columna [dbo].[Publicacion].[Imagen]; puede que se pierdan datos.
*/

IF EXISTS (select top 1 1 from [dbo].[Publicacion])
    RAISERROR (N'Se detectaron filas. La actualización del esquema va a terminar debido a una posible pérdida de datos.', 16, 127) WITH NOWAIT

GO
PRINT N'Modificando Tabla [dbo].[Publicacion]...';


GO
ALTER TABLE [dbo].[Publicacion] DROP COLUMN [Creador], COLUMN [Imagen];


GO
ALTER TABLE [dbo].[Publicacion] ALTER COLUMN [Creacion] DATE NULL;


GO
ALTER TABLE [dbo].[Publicacion]
    ADD [Imagen1] VARCHAR (200) NULL,
        [Imagen2] VARCHAR (200) NULL,
        [Imagen3] VARCHAR (200) NULL,
        [Imagen4] VARCHAR (200) NULL,
        [Imagen5] VARCHAR (200) NULL;


GO
PRINT N'Actualización completada.';


GO
