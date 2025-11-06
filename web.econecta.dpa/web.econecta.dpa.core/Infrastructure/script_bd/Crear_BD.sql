/* ==========================================================
   BASE DE DATOS Y OPCIONES
   ========================================================== */
IF DB_ID('EcoConectaDB') IS NULL
BEGIN
  CREATE DATABASE EcoConectaDB;
END
GO
USE EcoConectaDB;
GO

/* ==========================================================
   0) Tablas de soporte
   ========================================================== */

CREATE TABLE Roles (
  IdRol          INT IDENTITY PRIMARY KEY,
  Nombre         VARCHAR(30) NOT NULL UNIQUE  -- 'ciudadano', 'admin'
);

CREATE TABLE Distritos (
  IdDistrito     INT IDENTITY PRIMARY KEY,
  Nombre         VARCHAR(80) NOT NULL UNIQUE
);

CREATE TABLE Categorias (
  IdCategoria    INT IDENTITY PRIMARY KEY,
  Nombre         VARCHAR(80) NOT NULL UNIQUE,
  IdPadre        INT NULL
);
ALTER TABLE Categorias
  ADD CONSTRAINT FK_Categorias_Padre
  FOREIGN KEY (IdPadre) REFERENCES Categorias(IdCategoria);

CREATE TABLE VerificacionesCorreo (
  IdVerificacion   BIGINT IDENTITY PRIMARY KEY,
  IdUsuario        BIGINT NOT NULL,
  Token            CHAR(64) NOT NULL UNIQUE,
  EnviadoEn        DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ConfirmadoEn     DATETIME2 NULL
);

CREATE TABLE RestablecimientosContrasena (
  IdRestablecimiento BIGINT IDENTITY PRIMARY KEY,
  IdUsuario          BIGINT NOT NULL,
  Token              CHAR(64) NOT NULL UNIQUE,
  ExpiraEn           DATETIME2 NOT NULL,
  UsadoEn            DATETIME2 NULL,
  CreadoEn           DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);

/* ==========================================================
   1) Seguridad y usuarios
   ========================================================== */

CREATE TABLE Usuarios (
  IdUsuario        BIGINT IDENTITY PRIMARY KEY,
  NombreCompleto   NVARCHAR(120) NOT NULL,
  Correo           VARCHAR(120)  NOT NULL UNIQUE,
  HashContrasena   VARBINARY(200) NOT NULL,
  IdDistrito       INT NULL,
  CorreoConfirmado BIT NOT NULL DEFAULT 0,
  Estado           VARCHAR(20) NOT NULL DEFAULT 'activo'
                    CHECK (Estado IN ('activo','bloqueado','de_baja')),
  PuntajePromedio  DECIMAL(4,2) NOT NULL DEFAULT 0.00,
  ConteoPuntajes   INT NOT NULL DEFAULT 0,
  CreadoEn         DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  UltimoIngresoEn  DATETIME2 NULL
);
ALTER TABLE Usuarios
  ADD CONSTRAINT FK_Usuarios_Distritos
  FOREIGN KEY (IdDistrito) REFERENCES Distritos(IdDistrito);

CREATE TABLE UsuariosRoles (
  IdUsuario    BIGINT NOT NULL,
  IdRol        INT NOT NULL,
  PRIMARY KEY (IdUsuario, IdRol),
  CONSTRAINT FK_UsuariosRoles_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario),
  CONSTRAINT FK_UsuariosRoles_Rol     FOREIGN KEY (IdRol)     REFERENCES Roles(IdRol)
);

CREATE TABLE AccionesAdministrativasUsuario (
  IdAccion       BIGINT IDENTITY PRIMARY KEY,
  IdUsuarioObjetivo BIGINT NOT NULL,
  IdUsuarioAdmin BIGINT NOT NULL,
  Accion         VARCHAR(20) NOT NULL CHECK (Accion IN ('bloqueo','baja','desbloqueo')),
  Motivo         NVARCHAR(300) NULL,
  CreadoEn       DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  TerminaEn      DATETIME2 NULL
);
ALTER TABLE AccionesAdministrativasUsuario
  ADD CONSTRAINT FK_AAU_Objetivo FOREIGN KEY (IdUsuarioObjetivo) REFERENCES Usuarios(IdUsuario),
      CONSTRAINT FK_AAU_Admin    FOREIGN KEY (IdUsuarioAdmin)    REFERENCES Usuarios(IdUsuario);

/* Vincular tokens a usuarios */
ALTER TABLE VerificacionesCorreo
  ADD CONSTRAINT FK_VerifCorreo_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario);

ALTER TABLE RestablecimientosContrasena
  ADD CONSTRAINT FK_Restablecer_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario);

/* ==========================================================
   2) Publicaciones / Productos
   ========================================================== */

CREATE TABLE Productos (
  IdProducto        BIGINT IDENTITY PRIMARY KEY,
  IdVendedor        BIGINT NOT NULL,
  Titulo            NVARCHAR(150) NOT NULL,
  Descripcion       NVARCHAR(1500) NOT NULL,
  IdCategoria       INT NOT NULL,
  TipoPublicacion   VARCHAR(15) NOT NULL CHECK (TipoPublicacion IN ('venta','donacion')),
  Condicion         VARCHAR(20) NOT NULL DEFAULT 'reciclado'
                     CHECK (Condicion IN ('nuevo','usado','reciclado','reparado')),
  Precio            DECIMAL(12,2) NULL,  -- NULL si donación
  Cantidad          INT NOT NULL DEFAULT 1,
  IdDistrito        INT NULL,
  EstadoModeracion  VARCHAR(15) NOT NULL DEFAULT 'pendiente'
                     CHECK (EstadoModeracion IN ('pendiente','aprobado','rechazado')),
  MotivoModeracion  NVARCHAR(300) NULL,
  IdModerador       BIGINT NULL,
  ModeradoEn        DATETIME2 NULL,
  Activo            BIT NOT NULL DEFAULT 1,
  CreadoEn          DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ActualizadoEn     DATETIME2 NULL
);
ALTER TABLE Productos
  ADD CONSTRAINT FK_Productos_Vendedor   FOREIGN KEY (IdVendedor)    REFERENCES Usuarios(IdUsuario),
      CONSTRAINT FK_Productos_Categoria  FOREIGN KEY (IdCategoria)   REFERENCES Categorias(IdCategoria),
      CONSTRAINT FK_Productos_Distrito   FOREIGN KEY (IdDistrito)    REFERENCES Distritos(IdDistrito),
      CONSTRAINT FK_Productos_Moderador  FOREIGN KEY (IdModerador)   REFERENCES Usuarios(IdUsuario);

CREATE INDEX IX_Productos_Busqueda
  ON Productos (IdCategoria, IdDistrito, TipoPublicacion, EstadoModeracion)
  INCLUDE (Titulo, Precio);

CREATE INDEX IX_Productos_Titulo ON Productos(Titulo);

CREATE TABLE ImagenesProducto (
  IdImagen        BIGINT IDENTITY PRIMARY KEY,
  IdProducto      BIGINT NOT NULL,
  RutaAlmacenamiento NVARCHAR(400) NOT NULL,
  Orden           TINYINT NOT NULL DEFAULT 1,
  CreadoEn        DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
ALTER TABLE ImagenesProducto
  ADD CONSTRAINT FK_ImagenesProducto_Producto FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto);
CREATE UNIQUE INDEX UX_ImagenesProducto_Limite
  ON ImagenesProducto (IdProducto, Orden);

CREATE TABLE InteresesProducto (
  IdInteres     BIGINT IDENTITY PRIMARY KEY,
  IdProducto    BIGINT NOT NULL,
  IdComprador   BIGINT NOT NULL,
  Mensaje       NVARCHAR(300) NULL,
  CreadoEn      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  CONSTRAINT UQ_Interes_Usuario_Producto UNIQUE (IdProducto, IdComprador)
);
ALTER TABLE InteresesProducto
  ADD CONSTRAINT FK_Interes_Producto FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto),
      CONSTRAINT FK_Interes_Comprador FOREIGN KEY (IdComprador) REFERENCES Usuarios(IdUsuario);

CREATE TABLE Comentarios (
  IdComentario   BIGINT IDENTITY PRIMARY KEY,
  IdProducto     BIGINT NOT NULL,
  IdAutor        BIGINT NOT NULL,
  Cuerpo         NVARCHAR(200) NOT NULL,
  CreadoEn       DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ActualizadoEn  DATETIME2 NULL,
  Eliminado      BIT NOT NULL DEFAULT 0
);
ALTER TABLE Comentarios
  ADD CONSTRAINT FK_Comentarios_Producto FOREIGN KEY (IdProducto) REFERENCES Productos(IdProducto),
      CONSTRAINT FK_Comentarios_Autor    FOREIGN KEY (IdAutor)    REFERENCES Usuarios(IdUsuario);

/* ==========================================================
   3) Transacciones y calificaciones
   ========================================================== */

CREATE TABLE Transacciones (
  IdTransaccion   BIGINT IDENTITY PRIMARY KEY,
  Tipo            VARCHAR(15) NOT NULL CHECK (Tipo IN ('compra','donacion')),
  IdProducto      BIGINT NOT NULL,
  IdVendedor      BIGINT NOT NULL,
  IdComprador     BIGINT NOT NULL,
  Cantidad        INT NOT NULL DEFAULT 1,
  PrecioUnitario  DECIMAL(12,2) NULL, -- NULL para donación
  MontoTotal      AS (Cantidad * ISNULL(PrecioUnitario,0.00)) PERSISTED,
  Estado          VARCHAR(15) NOT NULL DEFAULT 'iniciada'
                    CHECK (Estado IN ('iniciada','completada','cancelada')),
  CreadoEn        DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  CompletadoEn    DATETIME2 NULL
);
ALTER TABLE Transacciones
  ADD CONSTRAINT FK_Trx_Producto FOREIGN KEY (IdProducto)  REFERENCES Productos(IdProducto),
      CONSTRAINT FK_Trx_Vendedor FOREIGN KEY (IdVendedor)  REFERENCES Usuarios(IdUsuario),
      CONSTRAINT FK_Trx_Comprador FOREIGN KEY (IdComprador) REFERENCES Usuarios(IdUsuario);

CREATE INDEX IX_Trx_Usuarios_Tiempo
  ON Transacciones (IdComprador, IdVendedor, CreadoEn DESC);

CREATE TABLE Calificaciones (
  IdCalificacion   BIGINT IDENTITY PRIMARY KEY,
  IdTransaccion    BIGINT NOT NULL UNIQUE,
  IdCalificador    BIGINT NOT NULL,
  IdCalificado     BIGINT NOT NULL,
  Estrellas        TINYINT NOT NULL CHECK (Estrellas BETWEEN 1 AND 5),
  Comentario       NVARCHAR(300) NULL,
  CreadoEn         DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
ALTER TABLE Calificaciones
  ADD CONSTRAINT FK_Calif_Trx       FOREIGN KEY (IdTransaccion) REFERENCES Transacciones(IdTransaccion),
      CONSTRAINT FK_Calif_Calificador FOREIGN KEY (IdCalificador) REFERENCES Usuarios(IdUsuario),
      CONSTRAINT FK_Calif_Calificado  FOREIGN KEY (IdCalificado)  REFERENCES Usuarios(IdUsuario);

/* ==========================================================
   4) Notificaciones
   ========================================================== */

CREATE TABLE Notificaciones (
  IdNotificacion     BIGINT IDENTITY PRIMARY KEY,
  IdDestinatario     BIGINT NOT NULL,
  Tipo               VARCHAR(40) NOT NULL, -- 'interes_producto','compra_iniciada','publicacion_aprobada', etc.
  Titulo             NVARCHAR(120) NOT NULL,
  Cuerpo             NVARCHAR(500) NULL,
  Canal              VARCHAR(15) NOT NULL DEFAULT 'in_app' CHECK (Canal IN ('in_app','email')),
  IdProductoRelacionado     BIGINT NULL,
  IdTransaccionRelacionada  BIGINT NULL,
  LeidoEn            DATETIME2 NULL,
  CreadoEn           DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);
ALTER TABLE Notificaciones
  ADD CONSTRAINT FK_Notif_Destinatario FOREIGN KEY (IdDestinatario) REFERENCES Usuarios(IdUsuario),
      CONSTRAINT FK_Notif_Producto     FOREIGN KEY (IdProductoRelacionado) REFERENCES Productos(IdProducto),
      CONSTRAINT FK_Notif_Trx          FOREIGN KEY (IdTransaccionRelacionada) REFERENCES Transacciones(IdTransaccion);

CREATE INDEX IX_Notif_Bandeja ON Notificaciones (IdDestinatario, LeidoEn) INCLUDE (CreadoEn, Titulo);

/* ==========================================================
   5) Historial / reportes
   ========================================================== */

CREATE TABLE EjecucionesReporte (
  IdEjecucion   BIGINT IDENTITY PRIMARY KEY,
  IdUsuario     BIGINT NOT NULL,
  TipoReporte   VARCHAR(20) NOT NULL CHECK (TipoReporte IN ('vendedores','compradores','comentarios')),
  DesdeFecha    DATE NULL,
  HastaFecha    DATE NULL,
  EjecutadoEn   DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  FilasAfectadas INT NULL
);
ALTER TABLE EjecucionesReporte
  ADD CONSTRAINT FK_EjecucionesReporte_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario);

/* ==========================================================
   6) Campañas (administrador)
   ========================================================== */

CREATE TABLE Campanas (
  IdCampana     BIGINT IDENTITY PRIMARY KEY,
  Titulo        NVARCHAR(150) NOT NULL,
  Descripcion   NVARCHAR(1500) NOT NULL,
  RutaImagen    NVARCHAR(400) NULL,
  FechaInicio   DATE NOT NULL,
  FechaFin      DATE NOT NULL,
  Activa        BIT NOT NULL DEFAULT 1,
  IdCreador     BIGINT NOT NULL,
  CreadoEn      DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
  ActualizadoEn DATETIME2 NULL
);
ALTER TABLE Campanas
  ADD CONSTRAINT FK_Campanas_Admin FOREIGN KEY (IdCreador) REFERENCES Usuarios(IdUsuario);

/* ==========================================================
   7) Semillas mínimas de catálogos (opcionales)
   ========================================================== */

INSERT INTO Roles (Nombre) VALUES ('ciudadano'), ('admin');
