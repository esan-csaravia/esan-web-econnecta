USE EcoConectaDB;
GO

DECLARE @sql NVARCHAR(MAX) = N'';

SELECT @sql = @sql + N'SELECT * FROM ' 
  + QUOTENAME(s.name) + N'.' + QUOTENAME(t.name) 
  + N' ORDER BY 1;'
  + CHAR(13) + 'GO' + CHAR(13)
FROM sys.tables t
JOIN sys.schemas s ON s.schema_id = t.schema_id
-- Si usas solo dbo (sin esquemas personalizados), puedes filtrar:
WHERE s.name = 'dbo'
ORDER BY t.name;

PRINT @sql; -- Para revisar
-- EXEC sp_executesql @sql; -- Descomenta para ejecutar todo



SELECT * FROM [dbo].[AccionesAdministrativasUsuario] ORDER BY 1;
GO
SELECT * FROM [dbo].[Calificaciones] ORDER BY 1;
GO
SELECT * FROM [dbo].[Campanas] ORDER BY 1;
GO
SELECT * FROM [dbo].[Categorias] ORDER BY 1;
GO
SELECT * FROM [dbo].[Comentarios] ORDER BY 1;
GO
SELECT * FROM [dbo].[Distritos] ORDER BY 1;
GO
SELECT * FROM [dbo].[EjecucionesReporte] ORDER BY 1;
GO
SELECT * FROM [dbo].[ImagenesProducto] ORDER BY 1;
GO
SELECT * FROM [dbo].[InteresesProducto] ORDER BY 1;
GO
SELECT * FROM [dbo].[Notificaciones] ORDER BY 1;
GO
SELECT * FROM [dbo].[Productos] ORDER BY 1;
GO
SELECT * FROM [dbo].[RestablecimientosContrasena] ORDER BY 1;
GO
SELECT * FROM [dbo].[Roles] ORDER BY 1;
GO
SELECT * FROM [dbo].[sysdiagrams] ORDER BY 1;
GO
SELECT * FROM [dbo].[Transacciones] ORDER BY 1;
GO
SELECT * FROM [dbo].[Usuarios] ORDER BY 1;
GO
SELECT * FROM [dbo].[UsuariosRoles] ORDER BY 1;
GO
SELECT * FROM [dbo].[VerificacionesCorreo] ORDER BY 1;
GO
