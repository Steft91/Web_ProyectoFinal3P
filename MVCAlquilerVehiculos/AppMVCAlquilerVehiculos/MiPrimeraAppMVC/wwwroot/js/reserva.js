window.onload = function () {
    listarReserva();
};

function filtrarReserva() {
    let nombre = get("txtReserva");
    if (nombre == "") {
        listarReserva();
    } else {
        objReserva.url = "Reserva/filtrarReserva/?estado=" + nombre;
        pintar(objReserva);
    }

}

let objReserva;

async function listarReserva() {
    objReserva = {
        url: "Reserva/listarReserva",
        cabeceras: ["id Reserva", "Id Cliente", "Id Vehiculo", "Fecha de Inicio", "Fecha de Fin", "Estado"],
        propiedades: ["idReserva", "idReserva", "idVehiculo", "fechaInicio", "fechaFin", "estado"],
        editar: true,
        eliminar: true,
        propiedadId: "idReserva"
    }

    pintar(objReserva);

}

function Buscar() {
    let nombreReserva = get("txtReserva");
    objReserva.url = "Reserva/filtrarReserva/?estado=" + nombreReserva;
    pintar(objReserva);
}

const idReservaInput = document.getElementById("idReserva");
const guardarBtn = document.getElementById("buttonGuardar");
function GuardarReserva() {
    const frmGuardar = new FormData(document.getElementById("frmGuardarReserva"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarReserva();
            LimpiarDatos("frmGuardarReserva");

            // Cerrar el modal después de actualizar
            let modalActualizar = bootstrap.Modal.getInstance(document.getElementById("modalActualizar"));
            modalActualizar.hide();
        }
    };

    Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
        if (idReservaInput.value != "") {
            fetchPut("Reserva/GuardarReserva", "text", frmGuardar, callback);
        } else {
            fetchPost("Reserva/GuardarReserva", "text", frmGuardar, callback);
        }
    });
    //const frm = new FormData(document.getElementById("frmGuardarReserva"));
    //const callback = (res) => {
    //    const resInt = parseInt(res);
    //    if (resInt == 1) {
    //        listarReserva();
    //        LimpiarDatos("frmGuardarReserva");
    //        guardarBtn.innerText = "Guardar";

    //    }
    //}

    //if (idReservaInput.value != "") {
    //    fetchPut("Reserva/GuardarReserva", "text", frm, callback);
    //} else {
    //    fetchPost("Reserva/GuardarReserva", "text", frm, callback);
    //}

}

function nuevoPago() {
    LimpiarReserva();
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

function LimpiarReserva() {
    LimpiarDatos("frmGuardarReserva");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    fetchGet("Reserva/recuperarReserva/?idReserva=" + id, "json", function (data) {
        if (data) {
            console.log("Datos recuperados:", data);

            document.getElementById("idReserva").value = data.idReserva || "";
            document.getElementById("idCliente").value = data.idCliente || "";
            document.getElementById("idVehiculo").value = data.idVehiculo || "";
            document.getElementById("fechaInicio").value = data.fechaInicio || "";
            document.getElementById("fechaFin").value = data.fechaFin || "";
            document.getElementById("estado").value = data.estado || "";

            document.querySelector("#modalActualizar #idReserva").value = data.idReserva || "";
            document.querySelector("#modalActualizar #idCliente").value = data.idCliente || "";
            document.querySelector("#modalActualizar #idVehiculo").value = data.idVehiculo || "";
            document.querySelector("#modalActualizar #fechaInicio").value = data.fechaInicio || "";
            document.querySelector("#modalActualizar #fechaFin").value = data.fechaFin || "";
            document.querySelector("#modalActualizar #estado").value = data.estado || "";

            document.getElementById("idCliente").dispatchEvent(new Event('input'));
            document.getElementById("idVehiculo").dispatchEvent(new Event('input'));
            document.getElementById("fechaInicio").dispatchEvent(new Event('input'));
            document.getElementById("fechaFin").dispatchEvent(new Event('input'));
            document.getElementById("estado").dispatchEvent(new Event('input'));

            document.querySelector("#modalActualizar #idCliente").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #idVehiculo").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #fechaInicio").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #fechaFin").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #estado").dispatchEvent(new Event('input'));

            guardarBtn.innerText = "Actualizar";

            let modalActualizar = new bootstrap.Modal(document.getElementById("modalActualizar"));
            modalActualizar.show();
        } else {
            alert("No se pudo recuperar la información de la reserva.");
        }
    });

    //guardarBtn.innerText = "Actualizar";
    ////recuperarGenerico("Reserva/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    //fetchGet("Reserva/recuperarReserva/?idReserva=" + id, "json", function (data) {
    //    setN("idReserva", data.idReserva)
    //    setN("idReserva", data.idReserva)
    //    setN("idVehiculo", data.idVehiculo)
    //    setN("fechaInicio", data.fechaInicio)
    //    setN("fechaFin", data.fechaFin)
    //    setN("estado", data.estado)

    //});
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar esta reserva?", function () {
        fetchDelete("Reserva/EliminarReserva/?idReserva=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarReserva();
                LimpiarDatos();

                let modalActualizar = bootstrap.Modal.getInstance(document.getElementById("modalActualizar"));
                if (modalActualizar) {
                    modalActualizar.hide();
                }

                Swal.fire("Eliminado", "La reserva se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar la reserva", "error");
            }
        });
    });
    //const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    //if (!deleteAns) return;

    //fetchDelete("Reserva/EliminarReserva/?idReserva=" + id, "text", (res) => {
    //    if (parseInt(res) == 1) {
    //        listarReserva();
    //    }
    //});
}