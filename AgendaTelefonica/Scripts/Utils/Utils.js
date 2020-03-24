var Utils = function () {

    return {

        // Funcion de inicio del objeto javascript de la vista 
        init: function () {

        },

        // Función para validar el formulario de registro de empleado
        validate: function (formContainer) {
            var flag = true;
            formContainer.find(':input').each(function () {
                var elemento = this;
                if (elemento.id.length != 0 && elemento.required) {
                    if (elemento.value.length == 0) {
                        console.log("elemento.id=" + elemento.id + ", elemento.value=" + elemento.value)
                        flag = false;
                    }
                }
            });

            return flag;
        },

        // Función para visualizar el modal recibido
        viewModal: function (modal) {
            $("#" + modal).modal("show");
        },

        // Función para cerrar modal recibido 
        closeModal: function (modal) {
            $("#" + modal).modal("hide");
        },

        // Función para agregar las opciones a una lista desplegable
        addOptionToSelect(selectId, controller, method, onSuccess) {
            $.ajax({
                url: controller+'/'+method,
                type: 'GET',
                cache: true,
                success: function (request) {
                    var listTiposDocumentos = $('#'+selectId)
                    $.each(JSON.parse(request.Result), function (index, elemento) {
                        listTiposDocumentos.append($('<option/>', {
                            value: elemento.Value,
                            text: elemento.Text
                        }));
                    });
                    if (method === "GetListJefes") {
                        Agenda.temporaryRemoveJefe();
                    }
                },
                error: function () {
                    console.log("No se ha podido obtener la información");
                }
            });
        },

    }

}();