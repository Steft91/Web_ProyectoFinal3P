window.onload = function () {
    listarReserva();
};

function filtrarReserva() {
    let nombre = get("txtLaboratorio");
    if (nombre == "") {
        listarReserva();
    } else {
        objReserva.url = "Reserva/filtrarReserva/?idReserva=" + nombre;
        pintar(objReserva);
    }

}

let objReserva;

async function listarReserva() {
    objReserva = {
        url: "Reserva/listarReserva",
        cabeceras: ["id Reserva", "Id Cliente", "Id Vehiculo", "Fecha de Inicio", "Fecha de Fin", "Estado"],
        propiedades: ["idReserva", "idCliente", "idVehiculo", "fechaInicio", "fechaFin", "estado"],
        editar: true,
        eliminar: true,
        propiedadId: "idReserva"
    }

    pintar(objReserva);

}

function Buscar() {
    let nombreReserva = get("txtReserva");
    objReserva.url = "Reserva/filtrarReserva/?idReserva=" + nombreReserva;
    pintar(objReserva);
}

const idReservaInput = document.getElementById("idReserva");
const guardarBtn = document.getElementById("buttonGuardar");
function GuardarReserva() {
    const frm = new FormData(document.getElementById("frmGuardarReserva"));
    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarReserva();
            LimpiarDatos("frmGuardarReserva");
        }
    }

    if (idReservaInput.value != "") {
        fetchPut("Reserva/GuardarReserva", "text", frm, callback);
    } else {
        fetchPost("Reserva/GuardarReserva", "text", frm, callback);
    }

}

function LimpiarReserva() {
    LimpiarDatos("frmGuardarReserva");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    guardarBtn.innerText = "Actualizar";
    //recuperarGenerico("Reserva/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    fetchGet("Reserva/recuperarReserva/?idReserva=" + id, "json", function (data) {
        setN("idReserva", data.idReserva)
        setN("idCliente", data.idCliente)
        setN("idVehiculo", data.idVehiculo)
        setN("fechaInicio", data.fechaInicio)
        setN("fechaFin", data.fechaFin)
        setN("estado", data.estado)

    });
}

function Eliminar(id) {
    const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    if (!deleteAns) return;

    fetchDelete("Reserva/EliminarReserva/?idReserva=" + id, "text", (res) => {
        if (parseInt(res) == 1) {
            listarReserva();
        }
    });
}