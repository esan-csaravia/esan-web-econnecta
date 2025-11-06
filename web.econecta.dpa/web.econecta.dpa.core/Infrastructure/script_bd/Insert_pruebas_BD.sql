USE EcoConectaDB;
GO
SET NOCOUNT ON;

/* -----------------------------
   Catálogos básicos
   ----------------------------- */
-- Distritos
INSERT INTO Distritos (Nombre) VALUES
('Lima'), ('Miraflores'), ('San Isidro'), ('Barranco');

-- Categorías
INSERT INTO Categorias (Nombre, IdPadre) VALUES
('Electrónica', NULL),
('Hogar', NULL),
('Muebles', 2),
('Pequeños electrodomésticos', 2),
('Computadoras', 1),
('Teléfonos', 1);

/* -----------------------------
   Usuarios (2 ciudadanos + 1 admin)
   Nota: HashContrasena = 0x01... solo para pruebas
   ----------------------------- */
DECLARE @hash VARBINARY(200) = 0x0102030405;

INSERT INTO Usuarios (NombreCompleto, Correo, HashContrasena, IdDistrito, CorreoConfirmado, Estado, CreadoEn)
VALUES
(N'Laura Pérez',  'laura@example.com',  @hash, 2, 1, 'activo', SYSUTCDATETIME()),
(N'Carlos Ruiz',  'carlos@example.com', @hash, 3, 1, 'activo', SYSUTCDATETIME()),
(N'Admin Eco',    'admin@example.com',  @hash, 1, 1, 'activo', SYSUTCDATETIME());

DECLARE @idLaura BIGINT = (SELECT IdUsuario FROM Usuarios WHERE Correo='laura@example.com');
DECLARE @idCarlos BIGINT = (SELECT IdUsuario FROM Usuarios WHERE Correo='carlos@example.com');
DECLARE @idAdmin BIGINT  = (SELECT IdUsuario FROM Usuarios WHERE Correo='admin@example.com');

-- Roles a usuarios
INSERT INTO UsuariosRoles (IdUsuario, IdRol)
SELECT @idLaura, (SELECT IdRol FROM Roles WHERE Nombre='ciudadano') UNION ALL
SELECT @idCarlos, (SELECT IdRol FROM Roles WHERE Nombre='ciudadano') UNION ALL
SELECT @idAdmin,  (SELECT IdRol FROM Roles WHERE Nombre='admin');

-- Verificación de correo y restablecimientos (dummy)
INSERT INTO VerificacionesCorreo (IdUsuario, Token, EnviadoEn, ConfirmadoEn)
VALUES (@idLaura,  REPLICATE('A',64), DATEADD(DAY,-5,SYSUTCDATETIME()), DATEADD(DAY,-4,SYSUTCDATETIME())),
       (@idCarlos, REPLICATE('B',64), DATEADD(DAY,-3,SYSUTCDATETIME()), DATEADD(DAY,-2,SYSUTCDATETIME()));

INSERT INTO RestablecimientosContrasena (IdUsuario, Token, ExpiraEn, UsadoEn, CreadoEn)
VALUES (@idLaura,  REPLICATE('C',64), DATEADD(DAY,7,SYSUTCDATETIME()), NULL, SYSUTCDATETIME());

/* -----------------------------
   Productos (Laura vende; Carlos compra)
   ----------------------------- */
INSERT INTO Productos
  (IdVendedor, Titulo, Descripcion, IdCategoria, TipoPublicacion, Condicion, Precio, Cantidad, IdDistrito,
   EstadoModeracion, MotivoModeracion, IdModerador, ModeradoEn, Activo, CreadoEn)
VALUES
(@idLaura, N'Laptop reciclada', N'Equipo reacondicionado con SSD de 256GB', 
 (SELECT IdCategoria FROM Categorias WHERE Nombre='Computadoras'), 'venta', 'reciclado', 1200.00, 1, 2,
 'aprobado', NULL, @idAdmin, SYSUTCDATETIME(), 1, DATEADD(DAY,-2,SYSUTCDATETIME())),
(@idLaura, N'Licuadora usada', N'Funciona correctamente, jarra de vidrio',
 (SELECT IdCategoria FROM Categorias WHERE Nombre='Pequeños electrodomésticos'), 'donacion', 'usado', NULL, 1, 2,
 'aprobado', NULL, @idAdmin, SYSUTCDATETIME(), 1, DATEADD(DAY,-1,SYSUTCDATETIME()));

DECLARE @idProdLaptop BIGINT = SCOPE_IDENTITY(); -- OJO: devuelve el último IDENTITY insertado (licuadora). Ajustamos:
-- Mejor obtenerlos por título:
SET @idProdLaptop = (SELECT IdProducto FROM Productos WHERE Titulo=N'Laptop reciclada');
DECLARE @idProdLicuadora BIGINT = (SELECT IdProducto FROM Productos WHERE Titulo=N'Licuadora usada');

-- Imágenes
INSERT INTO ImagenesProducto (IdProducto, RutaAlmacenamiento, Orden)
VALUES
(@idProdLaptop,    N'/uploads/prod/laptop1.jpg', 1),
(@idProdLaptop,    N'/uploads/prod/laptop2.jpg', 2),
(@idProdLicuadora, N'/uploads/prod/licuadora1.jpg', 1);

/* Intereses (Carlos se interesa por la laptop) */
INSERT INTO InteresesProducto (IdProducto, IdComprador, Mensaje)
VALUES (@idProdLaptop, @idCarlos, N'¿Sigue disponible? Me interesa.');

/* Comentarios */
INSERT INTO Comentarios (IdProducto, IdAutor, Cuerpo, CreadoEn)
VALUES
(@idProdLaptop, @idCarlos, N'¿Incluye cargador original?',  DATEADD(HOUR,-36,SYSUTCDATETIME())),
(@idProdLaptop, @idLaura,  N'Sí, incluye cargador original.', DATEADD(HOUR,-35,SYSUTCDATETIME()));

/* -----------------------------
   Transacciones y calificaciones
   ----------------------------- */
-- Transacción: Carlos compra la laptop a Laura
INSERT INTO Transacciones
  (Tipo, IdProducto, IdVendedor, IdComprador, Cantidad, PrecioUnitario, Estado, CreadoEn, CompletadoEn)
VALUES
('compra', @idProdLaptop, @idLaura, @idCarlos, 1, 1200.00, 'completada',
 DATEADD(HOUR,-30,SYSUTCDATETIME()), DATEADD(HOUR,-6,SYSUTCDATETIME()));

DECLARE @idTrxLaptop BIGINT = SCOPE_IDENTITY();

-- Calificación (Carlos califica a Laura)
INSERT INTO Calificaciones (IdTransaccion, IdCalificador, IdCalificado, Estrellas, Comentario)
VALUES (@idTrxLaptop, @idCarlos, @idLaura, 5, N'Excelente atención y producto.');

-- Simular actualización de puntaje en Usuarios (denormalización simple)
UPDATE u
SET u.PuntajePromedio = x.Prom,
    u.ConteoPuntajes = x.Cnt
FROM Usuarios u
JOIN (
  SELECT IdCalificado AS IdUsuario, CAST(AVG(CAST(Estrellas AS DECIMAL(4,2))) AS DECIMAL(4,2)) AS Prom, COUNT(*) AS Cnt
  FROM Calificaciones
  GROUP BY IdCalificado
) x ON x.IdUsuario = u.IdUsuario;

/* -----------------------------
   Notificaciones
   ----------------------------- */
INSERT INTO Notificaciones
  (IdDestinatario, Tipo, Titulo, Cuerpo, Canal, IdProductoRelacionado, IdTransaccionRelacionada, CreadoEn)
VALUES
(@idLaura, 'interes_producto', N'Nuevo interés en tu publicación', N'Carlos mostró interés en tu Laptop reciclada', 'in_app', @idProdLaptop, NULL, DATEADD(HOUR,-34,SYSUTCDATETIME())),
(@idCarlos, 'compra_iniciada', N'Compra iniciada', N'Has iniciado una compra de Laptop reciclada', 'in_app', @idProdLaptop, @idTrxLaptop, DATEADD(HOUR,-30,SYSUTCDATETIME())),
(@idLaura, 'compra_completada', N'¡Venta completada!', N'Has vendido tu Laptop reciclada', 'email', @idProdLaptop, @idTrxLaptop, DATEADD(HOUR,-6,SYSUTCDATETIME()));

/* -----------------------------
   Acciones administrativas y reportes
   ----------------------------- */
-- Acción (ejemplo informativo; no afecta estado)
INSERT INTO AccionesAdministrativasUsuario (IdUsuarioObjetivo, IdUsuarioAdmin, Accion, Motivo)
VALUES (@idCarlos, @idAdmin, 'desbloqueo', N'Revisión completada, sin infracción.');

-- Ejecución de reporte
INSERT INTO EjecucionesReporte (IdUsuario, TipoReporte, DesdeFecha, HastaFecha, EjecutadoEn, FilasAfectadas)
VALUES (@idAdmin, 'vendedores', DATEADD(DAY,-30,CAST(SYSUTCDATETIME() AS DATE)), CAST(SYSUTCDATETIME() AS DATE), SYSUTCDATETIME(), 10);

/* -----------------------------
   Campañas
   ----------------------------- */
INSERT INTO Campanas (Titulo, Descripcion, RutaImagen, FechaInicio, FechaFin, Activa, IdCreador)
VALUES
(N'Recicla y Gana', N'Campaña para incentivar publicaciones de electrónicos reciclados.',
 N'/uploads/camp/recicla_gana.jpg', CAST(DATEADD(DAY,-10,GETUTCDATE()) AS DATE), CAST(DATEADD(DAY,20,GETUTCDATE()) AS DATE), 1, @idAdmin);

SET NOCOUNT OFF;
