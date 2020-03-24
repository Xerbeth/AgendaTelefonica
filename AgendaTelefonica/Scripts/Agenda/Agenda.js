/*********************************************************************
* Objeto javascript Agenda que contiene la logica para la vista agendas 
*********************************************************************/

var Agenda = function () {

    return {

        Empleado_Id: null,
        Telefono_Id: null,

        // Funcion de inicio del objeto javascript de la vista 
        init: function () {
            Empleado_Id = 0;
        },

        // Función para visualizar le modal de agregar empleados
        viewAddEmployees: function () {
            Utils.viewModal("addEmployeeModal");
            this.getListTiposDocumentos();
            this.getListCargos();
            this.getListJefes();
            this.getListTiposTelefonos();
        },

        // Función para limpiar la lista de los tipos de documentos en el modal agregar empleados 
        clearFormAddEmployee: function () {
            $('#Tipo_Documento_Id').children('option').remove();
            $('#Cargo_Id').children('option').remove();
            $('#Jefe').children('option').remove();
            $('#Telefono_Id').children('option').remove();
            Utils.closeModal("addEmployeeModal");
        },

        // Función para obtener los tipos de documentos
        getListTiposDocumentos: function () {
            Utils.addOptionToSelect("Tipo_Documento_Id", "Agenda", "GetListTiposDocumentos");
        },

        // Función para obtener la lista de los cargos
        getListCargos: function () {
            Utils.addOptionToSelect("Cargo_Id", "Agenda", "GetListCargos");
        },

        // Función para obtener la lista de los empleados para el combo de Jefes
        getListJefes: function () {
            Utils.addOptionToSelect("Jefe", "Agenda", "GetListJefes");
        },

        // Función para obtener los tipos de telefonos
        getListTiposTelefonos: function () {
            Utils.addOptionToSelect("Telefono_Id", "Agenda", "GetListTiposTelefonos");
        },

        // Función para agregar empleados
        insertEmpleado: function () {
            var formContainer = $('#AddEmployee');
            var formData = JSON.parse(JSON.stringify($('#AddEmployee').serializeArray()));
            if (Utils.validate(formContainer) == true) {
                $.ajax({
                    url: 'Agenda/InsertEmpleado',
                    type: 'POST',
                    dataType: 'json',
                    data: formData,
                    success: function (request) {
                        if (request.Exception == null) {
                            Utils.closeModal("addEmployeeModal");
                            location.reload();
                            //var empleado_Id = request.Result;
                            //var telefono_Id = $("#Telefono_Id").val();
                            //var numeroTelefonico = $("#NumeroTelefonico").val();
                            //Agenda.insertTelefono(empleado_Id, telefono_Id, numeroTelefonico);
                        }
                        else {
                            alert("Existe un regitro con es número de documento.");
                        }
                    },
                    error: function () {
                        alert("Ocurrió un error durante la petición de registro.");
                    }
                });
            }

        },

        // Función para agregar los telefonos del empleado
        insertTelefono: function (empleado_Id, telefono_Id, numeroTelefono) {

            var formData = [
                { "name": "Empleado_Id", "value": empleado_Id },
                { "name": "Tipo_Telefono_Id", "value": telefono_Id },
                { "name": "NumeroTelefonico", "value": "" + numeroTelefono }
            ];

            $.ajax({
                url: 'Agenda/InsertTelefono',
                type: 'POST',
                dataType: 'json',
                data: formData,
                success: function (request) {
                    if (request.Exception == null) {
                        //alert("Empleado registrado correctamente.");
                        Utils.closeModal("addEmployeeModal");
                        location.reload();
                    }
                    else {
                        alert("Existe un regitro con es número de documento.");
                    }
                },
                error: function () {
                    alert("Ocurrió un error durante la petición de registro.");
                }
            });

        },

        // Función para cargar temporalmente el registro del empleado a eliminar
        temporaryRemoved: function (empleado_Id, telefono_Id) {
            Agenda.Empleado_Id = empleado_Id;
            Agenda.Telefono_Id = telefono_Id;
        },

        // Función para elimianr un empleado
        deleteEmpleado: function () {
            if (Agenda.Empleado_Id != null && Agenda.Empleado_Id > 0) {
                $.ajax({
                    url: 'Agenda/DeleteEmpleado',
                    type: 'DELETE',
                    dataType: 'json',
                    data: { Empleado_Id: Agenda.Empleado_Id, Telefono_Id: Agenda.Telefono_Id },
                    success: function (request) {
                        if (request.Exception == null) {
                            //alert("Empleado eliminado correctamente.");
                            Utils.closeModal("deleteEmployeeModal");
                            location.reload();
                        }
                    },
                    error: function () {
                        alert("Ocurrió un error durante la petición de registro.");
                    }
                });
            } else {
                alert("No existen registros para eliminar.");
            }

        },

        // Función para remover temporalmente la lista de jefes si no existen empleados registrados
        temporaryRemoveJefe: function () {
            if ($("#Jefe").val() === null) {
                //style = "display: none"
                $("#form-group-jefe").attr("style", "display: none");
                return;
            }
            $("#form-group-jefe").attr("style", "display: block");
        },




    }

}();