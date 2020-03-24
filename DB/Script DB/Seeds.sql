
/* Seeds para llenar la tabla de tipos de documentos */
INSERT INTO developer.tiposdocumentos (Tipo_Documento, Descripcion)
VALUES ('CC','Cédula de ciudadanía');
INSERT INTO developer.tiposdocumentos (Tipo_Documento, Descripcion)
VALUES ('RC','Registro Civil');
INSERT INTO developer.tiposdocumentos (Tipo_Documento, Descripcion)
VALUES ('TI','Tarjeta de identidad');
INSERT INTO developer.tiposdocumentos (Tipo_Documento, Descripcion)
VALUES ('CE','Cédula de extranjería');
INSERT INTO developer.tiposdocumentos (Tipo_Documento, Descripcion)
VALUES ('PA','Pasaporte');
INSERT INTO developer.tiposdocumentos (Tipo_Documento, Descripcion)
VALUES ('PEP','Permiso especial de permanencia');

/* Seeds para llenar la tabla de cargos */
INSERT INTO developer.cargos (cargo)
VALUES ('CEO - Director Ejecutivo');
INSERT INTO developer.cargos (cargo)
VALUES ('Responsable operativo - COO - Director de Operaciones');
INSERT INTO developer.cargos (cargo)
VALUES ('Responsable de ventas - Director Comercial - CSO');
INSERT INTO developer.cargos (cargo)
VALUES ('Responsable de marketing - CMO - Director de Marketing');
INSERT INTO developer.cargos (cargo)
VALUES ('Responsable de las Personas - CHRO -  Director de Recursos Humanos');
INSERT INTO developer.cargos (cargo)
VALUES ('Éxito del cliente - Customer Success (CS)');
INSERT INTO developer.cargos (cargo)
VALUES ('Responsable Financiero - CFO - Director Financiero');

/* Seeds para llenar la tabla de tipos de telefonos */
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Movil');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Casa');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Trabajo');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Principal');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Fax de trabajo');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Fax privado');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Localizador');
INSERT INTO developer.tipostelefonos (Tipo_Telefono)
VALUES ('Otro');

/* Seeds para cargar la tabla de empleados */
INSERT INTO developer.empleados (Cargo_Id, Tipo_Documento_Id, NumeroDocumento, Primer_Nombre, Primer_Apellido, Fecha_Nacimiento)
VALUES ((SELECT Cargo_Id FROM developer.cargos WHERE Cargo = 'CEO - Director Ejecutivo' ),
		(SELECT tipo_documento_id FROM developer.TiposDocumentos WHERE tipo_Documento = 'CC'),
		'11211452639',
		'Auron',
		'Jimenez',
		'05/11/1988');

INSERT INTO developer.empleados (Cargo_Id, Tipo_Documento_Id, NumeroDocumento, Primer_Nombre, Primer_Apellido, Fecha_Nacimiento)
VALUES ((SELECT Cargo_Id FROM developer.cargos WHERE Cargo = 'Éxito del cliente - Customer Success (CS)' ),
		(SELECT tipo_documento_id FROM developer.TiposDocumentos WHERE tipo_Documento = 'CC'),
		'401524789',
		'Camila',
		'Ortiz',
		'07/05/1991');

INSERT INTO developer.empleados (Cargo_Id, Tipo_Documento_Id, NumeroDocumento, Primer_Nombre, Primer_Apellido, Jefe, Fecha_Nacimiento)
VALUES ((SELECT Cargo_Id FROM developer.cargos WHERE Cargo = 'Responsable Financiero - CFO - Director Financiero' ),
		(SELECT tipo_documento_id FROM developer.TiposDocumentos WHERE tipo_Documento = 'CC'),
		'11214586324',
		'Joaquin',
		'Bermudez',
		(SELECT empleado_Id FROM developer.empleados e INNER JOIN developer.tiposDocumentos td ON td.tipo_documento_id = e.Tipo_Documento_Id WHERE td.tipo_Documento = 'CC' AND NumeroDocumento = '11211452639'),
		'07/05/1991');

/* Seeds para cargar la tabla de telefonos */        
INSERT INTO developer.telefonos (Tipo_Telefono_Id, NumeroTelefonico, Empleado_Id)
VALUES ((SELECT Tipo_Telefono_Id FROM developer.TiposTelefonos WHERE Tipo_Telefono = 'Móvil'),
		'3136251044',
		(SELECT empleado_Id FROM developer.empleados e INNER JOIN developer.tiposDocumentos td ON td.tipo_documento_id = e.Tipo_Documento_Id WHERE td.tipo_Documento = 'CC' AND NumeroDocumento = '11211452639'));

INSERT INTO developer.telefonos (Tipo_Telefono_Id, NumeroTelefonico, Empleado_Id)
VALUES ((SELECT Tipo_Telefono_Id FROM developer.TiposTelefonos WHERE Tipo_Telefono = 'Móvil'),
		'3201478523',
		(SELECT empleado_Id FROM developer.empleados e INNER JOIN developer.tiposDocumentos td ON td.tipo_documento_id = e.Tipo_Documento_Id WHERE td.tipo_Documento = 'CC' AND NumeroDocumento = '11214586324'));