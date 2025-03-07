window.onload = function () {
    listarPago();
};

function filtrarPago() {
    let nombre = get("txtPago");
    if (nombre == "") {
        listarPago();
    } else {
        objPago.url = "Pago/filtrarPago/?metodoPago=" + nombre;
        pintar(objPago);
    }

}

let objPago;

async function listarPago() {
    objPago = {
        url: "Pago/listarPago",
        cabeceras: ["Id Pago", "Id Reserva", "Monto", "Metodo de Pago", "Fecha de Pago"],
        propiedades: ["idPago", "idReserva", "monto", "metodoPago", "fechaPago"],
        editar: true,
        eliminar: true,
        propiedadId: "idPago"
    }

    pintar(objPago);

}

function Buscar() {
    let nombrePago = get("txtPago");
    objPago.url = "Pago/filtrarPago/?metodoPago=" + nombrePago;
    pintar(objPago);
}

const idPagoInput = document.getElementById("idPago");
const guardarBtn = document.getElementById("buttonGuardar");
const modalTitle = document.getElementById("modalPagoLabel");


document.getElementById("btnNuevoPago").addEventListener("click", function () {
    LimpiarPago();
    guardarBtn.innerText = "Crear";
    modalTitle.innerText = "Nuevo Pago";
    idPagoInput.value = "";

    $("#modalPago").modal("show");
});

function GuardarPago() {
    const frmGuardar = new FormData(document.getElementById("frmPago"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarPago();
            LimpiarDatos("frmPago");
            $("#modalPago").modal("hide");

            ExitoToast("Registro guardado con éxito");
        } else {
            ErrorToast();
        }
    };


    if (idPagoInput.value != "") {
        Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
            fetchPut("Pago/GuardarPago", "text", frmGuardar, callback);
        });
    } else {
        fetchPost("Pago/GuardarPago", "text", frmGuardar, callback);
    }
}

function nuevoPago() {
    LimpiarPago();
    modalPago.show();
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

function LimpiarPago() {
    LimpiarDatos("frmPago");
}

async function Editar(id) {
    LimpiarPago();

    recuperarGenerico("Pago/recuperarPago/?idPago=" + id, "frmPago");

    guardarBtn.innerText = "Actualizar";
    modalTitle.innerText = "Actualizar Pago";
    $("#modalPago").modal("show");
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este Pago?", function () {
        fetchDelete("Pago/EliminarPago/?idPago=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarPago();
                LimpiarDatos();

                if ($("#modalPago").length > 0) {
                    $("#modalPago").modal("hide");
                }

                Swal.fire("Eliminado", "El Pago se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el Pago", "error");
            }
        });
    });
}