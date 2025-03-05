window.onload = function () {
    listarCliente();
};
function filtrarCliente() {
    let nombre = get("txtCliente");
    if (nombre == "") {
        listarCliente();
    } else {
        objCliente.url = "Cliente/filtrarCliente/?nombre=" + nombre;
        pintar(objCliente);
    }

}

let objCliente;

async function listarCliente() {
    objCliente = {
        url: "Cliente/listarCliente",
        cabeceras: ["id Cliente", "Nombre", "Apellido", "Telefono", "Email"],
        propiedades: ["idCliente", "nombre", "apellido", "telefono", "email"],
        editar: true,
        eliminar: true,
        propiedadId: "idCliente"

    }
    pintar(objCliente);
}


function Buscar() {
    let nombreCliente = get("txtCliente");
    objCliente.url = "Cliente/filtrarCliente/?nombre=" + nombreCliente;
    pintar(objCliente);
}

const idClienteInput = document.getElementById("idCliente");
const guardarBtn = document.getElementById("buttonGuardar");
function GuardarCliente() {
    const frmGuardar = new FormData(document.getElementById("frmGuardarCliente"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarCliente();
            LimpiarDatos("frmGuardarCliente");

            // Cerrar el modal después de actualizar
            $("#modalActualizar").modal("hide");
        }
    };

    Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
        if (idClienteInput.value != "") {
            fetchPut("Cliente/GuardarCliente", "text", frmGuardar, callback);
        } else {
            fetchPost("Cliente/GuardarCliente", "text", frmGuardar, callback);
        }
    });
    //const frm = new FormData(document.getElementById("frmGuardarCliente"));
    //const callback = (res) => {
    //    const resInt = parseInt(res);
    //    if (resInt == 1) {
    //        listarCliente();
    //        LimpiarDatos("frmGuardarCliente");
    //        guardarBtn.innerText = "Guardar";

    //    }
    //}

    //if (idClienteInput.value != "") {
    //    fetchPut("Cliente/GuardarCliente", "text", frm, callback);
    //} else {
    //    fetchPost("Cliente/GuardarCliente", "text", frm, callback);
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

function LimpiarCliente() {
    LimpiarDatos("frmGuardarCliente");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    fetchGet("Cliente/recuperarCliente/?idCliente=" + id, "json", function (data) {
        if (data) {
            console.log("Datos recuperados:", data);

            document.getElementById("idCliente").value = data.idCliente || "";
            document.getElementById("nombre").value = data.nombre || "";
            document.getElementById("apellido").value = data.apellido || "";
            document.getElementById("telefono").value = data.telefono || "";
            document.getElementById("email").value = data.email || "";

            document.querySelector("#modalActualizar #idCliente").value = data.idCliente || "";
            document.querySelector("#modalActualizar #nombre").value = data.nombre || "";
            document.querySelector("#modalActualizar #apellido").value = data.apellido || "";
            document.querySelector("#modalActualizar #telefono").value = data.telefono || "";
            document.querySelector("#modalActualizar #email").value = data.email || "";

            document.getElementById("nombre").dispatchEvent(new Event('input'));
            document.getElementById("apellido").dispatchEvent(new Event('input'));
            document.getElementById("telefono").dispatchEvent(new Event('input'));
            document.getElementById("email").dispatchEvent(new Event('input'));

            document.querySelector("#modalActualizar #nombre").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #apellido").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #telefono").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #email").dispatchEvent(new Event('input'));

            guardarBtn.innerText = "Actualizar";

            $("#modalActualizar").modal("show");
        } else {
            alert("No se pudo recuperar la información del cliente.");
        }
    });


    //guardarBtn.innerText = "Actualizar";
    ////recuperarGenerico("Cliente/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    //fetchGet("Cliente/recuperarCliente/?idCliente=" + id, "json", function (data) {
    //    setN("idCliente", data.idCliente)
    //    setN("nombre", data.nombre)
    //    setN("apellido", data.apellido)
    //    setN("telefono", data.telefono)
    //    setN("email", data.email)

    //});
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este cliente?", function () {
        fetchDelete("Cliente/EliminarCliente/?idCliente=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarCliente();
                LimpiarDatos();

                if ($("#modalActualizar").length > 0) {
                    $("#modalActualizar").modal("hide");
                }

                Swal.fire("Eliminado", "El Cliente se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el cliente", "error");
            }
        });
    });
    //const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    //if (!deleteAns) return;

    //fetchDelete("Cliente/EliminarCliente/?idCliente=" + id, "text", (res) => {
    //    if (parseInt(res) == 1) {
    //        listarCliente();
    //    }
    //});
}