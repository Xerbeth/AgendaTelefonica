CREATE SCHEMA developer;
GO
/*****************************************************
Script:     TiposDocumentos
Abstract:   Entidad para almacenar los datos 
			maestros de los tipos de documentos 
Date:       15 de Marzo de 2020            
*****************************************************/
CREATE TABLE developer.tiposdocumentos (
    Tipo_Documento_Id INT PRIMARY KEY IDENTITY (1, 1),
    Tipo_Documento VARCHAR (5) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
    Fecha_Registro DATETIME default CURRENT_TIMESTAMP, 
    CONSTRAINT check_Tipo_Documento
    CHECK (Tipo_Documento IN ('CI','CC','TI','TP','RC','CE','CI','DNI','DUI','PEP','PA'))
);

/*****************************************************
Script:     Cargos
Abstract:   Entidad para almacenar los datos 
			maestros de los cargos de la empresa 
Date:       15 de Marzo de 2020            
*****************************************************/
CREATE TABLE developer.cargos (
    Cargo_Id INT PRIMARY KEY IDENTITY (1, 1),
    Cargo VARCHAR(150) NOT NULL,
    Fecha_Registro DATETIME default CURRENT_TIMESTAMP
);

/*****************************************************
Script:     TiposTelefonos
Abstract:   Entidad para almacenar los datos 
			maestros de los tipos de telefonos
Date:       15 de Marzo de 2020            
*****************************************************/
CREATE TABLE developer.tipostelefonos (
	Tipo_Telefono_Id INT PRIMARY KEY IDENTITY (1, 1),
    Tipo_Telefono VARCHAR(50) NOT NULL,
    Fecha_Registro DATETIME default CURRENT_TIMESTAMP
);

/*****************************************************
Script:     Empleados
Abstract:   Entidad para almacenar los datos 
			maestros de los tipos de telefonos
Date:       15 de Marzo de 2020            
*****************************************************/
CREATE TABLE developer.empleados (
	Empleado_Id INT PRIMARY KEY IDENTITY (1, 1),
	Cargo_Id INT NOT NULL,
	Tipo_Documento_Id INT NOT NULL,
	NumeroDocumento VARCHAR(15) NOT NULL,
	Primer_Nombre VARCHAR(20) NOT NULL,
	Segundo_Nombre VARCHAR(20),
	Primer_Apellido VARCHAR(20) NOT NULL,
	Segundo_Apellido VARCHAR(20),
	Fecha_Nacimiento DATETIME NOT NULL,
	Salario INT,
	Jefe INT, 
    Fecha_Registro DATETIME default CURRENT_TIMESTAMP,
	FOREIGN KEY (Cargo_Id) REFERENCES developer.cargos(Cargo_Id),
	FOREIGN KEY (Tipo_Documento_Id) REFERENCES developer.tiposdocumentos(Tipo_Documento_Id),
	FOREIGN KEY (Jefe) REFERENCES developer.empleados(Empleado_Id),
	CONSTRAINT TipoNumeroDocumento UNIQUE(NumeroDocumento,Tipo_Documento_Id),
);

/*****************************************************
Script:     Telefonos
Abstract:   Entidad para almacenar los datos de
			los números telefonicos de los empleados
Date:       15 de Marzo de 2020            
*****************************************************/
CREATE TABLE developer.telefonos (
	Telefono_Id INT PRIMARY KEY IDENTITY (1, 1),
	Tipo_Telefono_Id INT NOT NULL,
	NumeroTelefonico VARCHAR(15),
	Empleado_Id INT NOT NULL,
    Fecha_Registro DATETIME default CURRENT_TIMESTAMP,
	FOREIGN KEY (Tipo_Telefono_Id) REFERENCES developer.TiposTelefonos(Tipo_Telefono_Id),
	FOREIGN KEY (Empleado_Id) REFERENCES developer.empleados(Empleado_Id)
);

