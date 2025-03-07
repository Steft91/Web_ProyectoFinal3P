window.onload = function () {
    listarReserva();
    //establecerMinFechas(); 

};

/////////////////////7
//function establecerMinFechas() {
//    let today = new Date().toISOString().split("T")[0]; // Obtener la fecha actual en formato YYYY-MM-DD
//    document.getElementById("fechaInicio").setAttribute("min", today);
//    document.getElementById("fechaFin").setAttribute("min", today);
//}

//document.getElementById("fechaInicio").addEventListener("change", function () {
//    let fechaInicio = this.value;
//    document.getElementById("fechaFin").setAttribute("min", fechaInicio);
//});

//////////////////////

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
        propiedades: ["idReserva", "idCliente", "idVehiculo", "fechaInicio", "fechaFin", "estado"],
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
const modalTitle = document.getElementById("modalReservaLabel");


document.getElementById("btnNuevaReserva").addEventListener("click", function () {
    LimpiarReserva();
    guardarBtn.innerText = "Crear";
    modalTitle.innerText = "Nueva Reserva";
    idReservaInput.value = "";

    $("#modalReserva").modal("show");
});

function GuardarReserva() {

    const frmGuardar = new FormData(document.getElementById("frmReserva"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarReserva();
            LimpiarDatos("frmReserva");
            $("#modalReserva").modal("hide");

            ExitoToast("Registro guardado con éxito");
        } else {
            ErrorToast();
        }
    };


    if (idReservaInput.value != "") {
        Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
            fetchPut("Reserva/GuardarReserva", "text", frmGuardar, callback);
        });
    } else {
        fetchPost("Reserva/GuardarReserva", "text", frmGuardar, callback);
    }
}

function nuevaReserva() {
    LimpiarReserva();
    modalReserva.show();
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
    LimpiarDatos("frmReserva");
}

async function Editar(id) {
    LimpiarReserva();

    let datos = await recuperarGenerico("Reserva/recuperarReserva/?idReserva=" + id);

    if (datos) {
        // Formatear fecha para que solo muestre "YYYY-MM-DD"
        document.getElementById("fechaInicio").value = convertirFechaSinHora(datos.fechaInicio);
        document.getElementById("fechaFin").value = convertirFechaSinHora(datos.fechaFin);
    }

    guardarBtn.innerText = "Actualizar";
    modalTitle.innerText = "Actualizar Reserva";
    $("#modalReserva").modal("show");
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar esta Reserva?", function () {
        fetchDelete("Reserva/EliminarReserva/?idReserva=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarReserva();
                LimpiarDatos();

                if ($("#modalReserva").length > 0) {
                    $("#modalReserva").modal("hide");
                }

                Swal.fire("Eliminado", "La reserva se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar la reserva", "error");
            }
        });
    });

}