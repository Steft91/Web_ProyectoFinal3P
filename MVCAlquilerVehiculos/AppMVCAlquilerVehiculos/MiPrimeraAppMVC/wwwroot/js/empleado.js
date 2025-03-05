window.onload = function () {
    listarEmpleado();
};

function filtrarEmpleado() {
    let nombre = get("txtEmpleado");
    if (nombre == "") {
        listarEmpleado();
    } else {
        objEmpleado.url = "Empleado/filtrarEmpleado/?nombreEmpleado=" + nombre;
        pintar(objEmpleado);
    }

}

let objEmpleado;

async function listarEmpleado() {
    objEmpleado = {
        url: "Empleado/listarEmpleado",
        cabeceras: ["id Empleado", "Nombre", "Apellido", "Cargo", "Teléfono", "Email" ],
        propiedades: ["idEmpleado", "nombreEmpleado", "apellidoEmpleado", "cargo", "telefonoEmpleado", "emailEmpleado"],
        editar: true,
        eliminar: true,
        propiedadId: "idEmpleado"
    }

    pintar(objEmpleado);

}

function Buscar() {
    let nombreEmpleado = get("txtEmpleado");
    objEmpleado.url = "Empleado/filtrarEmpleado/?nombreEmpleado=" + nombreEmpleado;
    pintar(objEmpleado);
}

const idEmpleadoInput = document.getElementById("idEmpleado");
const guardarBtn = document.getElementById("buttonGuardar");
function GuardarEmpleado() {
    const frmGuardar = new FormData(document.getElementById("frmGuardarEmpleado"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarEmpleado();
            LimpiarDatos("frmGuardarEmpleado");

            // Cerrar el modal después de actualizar
            $("#modalActualizar").modal("hide");
        }
    };

    Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
        if (idEmpleadoInput.value != "") {
            fetchPut("Empleado/GuardarEmpleado", "text", frmGuardar, callback);
        } else {
            fetchPost("Empleado/GuardarEmpleado", "text", frmGuardar, callback);
        }
    });
    //const frm = new FormData(document.getElementById("frmGuardarEmpleado"));
    //const callback = (res) => {
    //    const resInt = parseInt(res);
    //    if (resInt == 1) {
    //        listarEmpleado();
    //        LimpiarDatos("frmGuardarEmpleado");
    //        guardarBtn.innerText = "Guardar";
    //    }
    //}

    //if (idEmpleadoInput.value != "") {
    //    fetchPut("Empleado/GuardarEmpleado", "text", frm, callback);
    //} else {
    //    fetchPost("Empleado/GuardarEmpleado", "text", frm, callback);
    //}

}

function nuevoPago() {
    LimpiarPago();
    modalActualizar.show();
}

function Exito() {
    toastr.options = {
        "closeButton": true,
        "positionClas": "toast-top-full-width",
        "timeOut": "3000",
        "extendedTimeOut": "2000",
        "hideMethod": "slideUp"
    }
}

function LimpiarEmpleado() {
    LimpiarDatos("frmGuardarEmpleado");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    fetchGet("Empleado/recuperarEmpleado/?idEmpleado=" + id, "json", function (data) {
        if (data) {
            console.log("Datos recuperados:", data);

            document.getElementById("idEmpleado").value = data.idEmpleado || "";
            document.getElementById("nombreEmpleado").value = data.nombreEmpleado || "";
            document.getElementById("apellidoEmpleado").value = data.apellidoEmpleado || "";
            document.getElementById("cargo").value = data.cargo || "";
            document.getElementById("telefonoEmpleado").value = data.telefonoEmpleado || "";
            document.getElementById("emailEmpleado").value = data.emailEmpleado || "";

            document.querySelector("#modalActualizar #idEmpleado").value = data.idEmpleado || "";
            document.querySelector("#modalActualizar #nombreEmpleado").value = data.nombreEmpleado || "";
            document.querySelector("#modalActualizar #apellidoEmpleado").value = data.apellidoEmpleado || "";
            document.querySelector("#modalActualizar #cargo").value = data.cargo || "";
            document.querySelector("#modalActualizar #telefonoEmpleado").value = data.telefonoEmpleado || "";
            document.querySelector("#modalActualizar #emailEmpleado").value = data.emailEmpleado || "";

            document.getElementById("nombreEmpleado").dispatchEvent(new Event('input'));
            document.getElementById("apellidoEmpleado").dispatchEvent(new Event('input'));
            document.getElementById("cargo").dispatchEvent(new Event('input'));
            document.getElementById("telefonoEmpleado").dispatchEvent(new Event('input'));
            document.getElementById("emailEmpleado").dispatchEvent(new Event('input'));

            document.querySelector("#modalActualizar #nombreEmpleado").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #apellidoEmpleado").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #cargo").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #telefonoEmpleado").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #emailEmpleado").dispatchEvent(new Event('input'));

            guardarBtn.innerText = "Actualizar";

            $("#modalActualizar").modal("show");
        } else {
            alert("No se pudo recuperar la información del empleado.");
        }
    });


    //guardarBtn.innerText = "Actualizar";
    ////recuperarGenerico("Empleado/recuperarTipoMedicamento/?idEmpleado=" + id,"frmGuardarEmpleado");
    //fetchGet("Empleado/recuperarEmpleado/?idEmpleado=" + id, "json", function (data) {
    //    setN("idEmpleado", data.idEmpleado)
    //    setN("nombreEmpleado", data.nombreEmpleado)
    //    setN("apellidoEmpleado", data.apellidoEmpleado)
    //    setN("cargo", data.cargo)
    //    setN("telefonoEmpleado", data.telefonoEmpleado)
    //    setN("emailEmpleado", data.emailEmpleado)

    //});
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este empleado?", function () {
        fetchDelete("Empleado/EliminarEmpleado/?idEmpleado=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarEmpleado();
                LimpiarDatos();

                if ($("#modalActualizar").length > 0) {
                    $("#modalActualizar").modal("hide");
                }

                Swal.fire("Eliminado", "El empleado se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el empleado", "error");
            }
        });
    });
    //const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    //if (!deleteAns) return;

    //fetchDelete("Empleado/EliminarEmpleado/?idEmpleado=" + id, "text", (res) => {
    //    if (parseInt(res) == 1) {
    //        listarEmpleado();
    //    }
    //});
}