
CREATE DATABASE DB_NPS

GO

USE DB_NPS

GO
CREATE TABLE SEGURIDAD
(
  IdSeguridad INT IDENTITY(1,1)
 ,Usuario VARCHAR(200)
 ,Contrasena VARCHAR(200)
 ,NombreUsuario VARCHAR(250)
 ,IdUsuarioRegistro INT
 ,IdUsuarioModificacion INT
 ,IndActivo bit
 ,FechaRegistro DATETIME
 ,FechaModificacion DATETIME
 ,CONSTRAINT PK_SEGURIDAD PRIMARY KEY (IdSeguridad)
)

CREATE TABLE USUARIO
(
  IdUsuario INT IDENTITY(1,1)
 ,Nombres VARCHAR(250)
 ,Apellidos VARCHAR(250)
 ,Cuenta VARCHAR(250)
 ,Contrasena VARCHAR(200)
 ,Correo VARCHAR(50)
 ,I001Perfil INT
 ,IdUsuarioRegistro INT
 ,IdUsuarioModificacion INT
 ,IndActivo bit
 ,FechaRegistro DATETIME
 ,FechaModificacion DATETIME
 ,CONSTRAINT PK_USUARIO PRIMARY KEY (IdUsuario)
)

CREATE TABLE USUARIO_CALIFICION_NPS
(
  IdUsuarioCalificacionNPS INT IDENTITY(1,1)
 ,IdUsuario INT
 ,CalificacionPuntuacion INT
 ,CalificacionDescripcion VARCHAR(250)
 ,IdUsuarioRegistro INT
 ,IdUsuarioModificacion INT
 ,IndActivo bit
 ,FechaRegistro DATETIME
 ,FechaModificacion DATETIME
 ,CONSTRAINT PK_USUARIO_CALIFICION_NPS PRIMARY KEY (IdUsuarioCalificacionNPS)
 --,CONSTRAINT FK_USUARIO_CALIFICION_NPS_IdUsuario FOREIGN KEY (IdUsuario) REFERENCES USUARIO (IdUsuario)
)




CREATE TABLE PARAMETRO
(
  IdParametro INT
 ,IdTipo INT
 ,CampoValor DECIMAL(17,2)
 ,CampoDescripcion VARCHAR(250)
 ,IdUsuarioRegistro INT
 ,IdUsuarioModificacion INT
 ,IndActivo bit
 ,FechaRegistro DATETIME
 ,FechaModificacion DATETIME
  ,CONSTRAINT PK_PARAMETRO PRIMARY KEY (IdParametro)
)

--SET IDENTITY_INSERT USUARIO_CALIFICION_NPS ON

--SET IDENTITY_INSERT SEGURIDAD ON
--SET IDENTITY_INSERT USUARIO ON


INSERT INTO SEGURIDAD(Usuario,Contrasena,NombreUsuario,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('wastucuri','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','William Astucuri',1,1,1,GETDATE(),GETDATE())



INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('WILLIAM','ASTUCURI','wastucuri','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',1,1,1,1,GETDATE(),GETDATE())

INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('Maria','Sanchez','msanchez','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',2,1,1,1,GETDATE(),GETDATE())

INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('Jose','Espinoza','jespinoza','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',2,1,1,1,GETDATE(),GETDATE())

INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('Ana','Pinilla','apinilla','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',2,1,1,1,GETDATE(),GETDATE())


INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('Raul','torres de cruz','rdelacruz','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',2,1,1,1,GETDATE(),GETDATE())

INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('Daniel','Correa Martinez','dcorrea','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',2,1,1,1,GETDATE(),GETDATE())

INSERT INTO USUARIO(Nombres,Apellidos,Cuenta,Contrasena,Correo,I001Perfil,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES('Gloria','Reyes','greyes','10000.aYGH916cBvgLX69s/xZSPwtf.UmX5XrghAXxat1xyl1z+qV7fyf0Socn7t994HqcEt+w=','william310391@gmail.com',2,1,1,1,GETDATE(),GETDATE())






INSERT INTO PARAMETRO(IdParametro,IdTipo,CampoValor,CampoDescripcion,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES(1,1,NULL,'ADMINISTRADOR',1,1,1,GETDATE(),GETDATE())

INSERT INTO PARAMETRO(IdParametro,IdTipo,CampoValor,CampoDescripcion,IdUsuarioRegistro,IdUsuarioModificacion,IndActivo,FechaRegistro,FechaModificacion)
VALUES(2,1,NULL,'VOTANTE',1,1,1,GETDATE(),GETDATE())

