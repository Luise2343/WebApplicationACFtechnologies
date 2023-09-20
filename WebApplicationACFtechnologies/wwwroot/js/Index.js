const _modeloCliente = {
    identificacion: 0,
    primerNombre: "",
    primerApellido: "",
    edad: 0,
    fechaDeCreacion: ""
}

function MostrarClientes() {
    fetch("/Home/listaClientes")
        .then(response => {
            return response.ok ? response.json() : Promise.reject(response);
        })
        .then(responseJson => {
            if (responseJson.length > 0) {
                $("#tablaClientes tbody").html("");
                responseJson.forEach(cliente => {
                    $("#tablaClientes tbody").append(
                        $("<tr>").append(
                            $("<td>").text(cliente.primerNombre),
                            $("<td>").text(cliente.primerApellido),
                            $("<td>").text(cliente.edad),
                            $("<td>").text(cliente.fechaDeCreacion),
                            $("<td>").append(
                                $("<button>").addClass("btn btn-primary btn-sm boton-editar-cliente").text("Editar").data("dataCliente", cliente),
                                $("<button>").addClass("btn btn-danger btn-sm ms-2 boton-eliminar-cliente").text("Eliminar").data("dataCliente", cliente)
                            )
                        )
                    )
                })
            }
        });
}

document.addEventListener("DOMContentLoaded", function () {
    MostrarClientes();
    $("#txtFechaCreacion").datepicker({
        format: "dd/mm/yyyy",
        autoclose: true,
        todayHighlight: true
    });
}, false);

function MostrarModal() {
    $("#txtPrimerNombre").val(_modeloCliente.primerNombre);
    $("#txtPrimerApellido").val(_modeloCliente.primerApellido);
    $("#txtEdad").val(_modeloCliente.edad);
    $("#txtFechaCreacion").val(_modeloCliente.fechaDeCreacion);
    $("#modalCliente").modal("show");
}

$(document).on("click", ".boton-nuevo-cliente", function () {
    _modeloCliente.identificacion = 0;
    _modeloCliente.primerNombre = "";
    _modeloCliente.primerApellido = "";
    _modeloCliente.edad = 0;
    _modeloCliente.fechaDeCreacion = "";
    MostrarModal();
});

$(document).on("click", ".boton-editar-cliente", function () {
    const _cliente = $(this).data("dataCliente");
    _modeloCliente.identificacion = _cliente.identificacion;
    _modeloCliente.primerNombre = _cliente.primerNombre;
    _modeloCliente.primerApellido = _cliente.primerApellido; 
    _modeloCliente.edad = _cliente.edad;
    _modeloCliente.fechaDeCreacion = _cliente.fechaDeCreacion;
    MostrarModal();
});

$(document).on("click", ".boton-guardar-cambios-clientes", function () {

    const modelo = {
        identificacion: _modeloCliente.identificacion,
        primerNombre: $("#txtPrimerNombre").val(),
        primerApellido: $("#txtPrimerApellido").val(),  
        edad: $("#txtedad").val(),
        fechaDeCreacion: $("#txtFechaCreacion").val()
    }


    if (_modeloCliente.identificacion == 0) {

        fetch("/Home/guardarCliente", {
            method: "POST",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {

                if (responseJson.valor) {
                    $("#modalCliente").modal("hide");
                    Swal.fire("Listo!", "Cliente fue creado", "success");
                    MostrarCliente();
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo crear", "error");
            })

    } else {

        fetch("/Home/editarCliente", {
            method: "PUT",
            headers: { "Content-Type": "application/json; charset=utf-8" },
            body: JSON.stringify(modelo)
        })
            .then(response => {
                return response.ok ? response.json() : Promise.reject(response)
            })
            .then(responseJson => {

                if (responseJson.valor) {
                    $("#modalCliente").modal("hide");
                    Swal.fire("Listo!", "Cliente fue actualizado", "success");
                    MostrarEmpleados();
                }
                else
                    Swal.fire("Lo sentimos", "No se puedo actualizar", "error");
            })

    }


})


$(document).on("click", ".boton-eliminar-cliente", function () {

    const _cliente = $(this).data("dataCliente");

    Swal.fire({
        title: "Esta seguro?",
        text: `Eliminar cliente "${_cliente.primerNombre}"`,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Si, eliminar",
        cancelButtonText: "No, volver"
    }).then((result) => {

        if (result.isConfirmed) {

            fetch(`/Home/eliminarCliente?identificacion=${_cliente.identificacion}`, {
                method: "DELETE"
            })
                .then(response => {
                    return response.ok ? response.json() : Promise.reject(response)
                })
                .then(responseJson => {

                    if (responseJson.valor) {
                        Swal.fire("Listo!", "Cliente fue elminado", "success");
                        MostrarEmpleados();
                    }
                    else
                        Swal.fire("Lo sentimos", "No se puedo eliminar", "error");
                })

        }



    })

})