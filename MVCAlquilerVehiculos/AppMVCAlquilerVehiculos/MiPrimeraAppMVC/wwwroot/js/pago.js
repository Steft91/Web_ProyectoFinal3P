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
        cabeceras: ["Id Pago", "Id Pago", "Monto", "Metodo de Pago", "Fecha de Pago"],
        propiedades: ["idPago", "idPago", "monto", "metodoPago", "fechaPago"],
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

function GuardarPago() {
    const frmGuardar = new FormData(document.getElementById("frmGuardarPago"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarPago();
            LimpiarDatos("frmGuardarPago");

            // Cerrar el modal después de actualizar
            let modalActualizar = bootstrap.Modal.getInstance(document.getElementById("modalActualizar"));
            modalActualizar.hide();
        }
    };

    Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
        if (idPagoInput.value != "") {
            fetchPut("Pago/GuardarPago", "text", frmGuardar, callback);
        } else {
            fetchPost("Pago/GuardarPago", "text", frmGuardar, callback);
        }
    });
    //const frm = new FormData(document.getElementById("frmGuardarPago"));
    //const callback = (res) => {
    //    const resInt = parseInt(res);
    //    if (resInt == 1) {
    //        listarPago();
    //        LimpiarDatos("frmGuardarPago");
    //        guardarBtn.innerText = "Guardar"; 
    //    }
    //}

    //if (idPagoInput.value != " " /*&& parseInt(idPagoInput.value) > 0*/) {
    //    fetchPut("Pago/GuardarReserva", "text", frm, callback);
    //} else {
    //    fetchPost("Pago/GuardarReserva", "text", frm, callback);
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

function LimpiarPago() {
    LimpiarDatos("frmGuardarPago");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    fetchGet("Pago/recuperarPago/?idPago=" + id, "json", function (data) {
        if (data) {
            console.log("Datos recuperados:", data);

            document.getElementById("idPago").value = data.idPago || "";
            document.getElementById("idReserva").value = data.idReserva || "";
            document.getElementById("monto").value = data.monto || "";
            document.getElementById("metodoPago").value = data.metodoPago || "";
            document.getElementById("fechaPago").value = data.fechaPago || "";

            document.querySelector("#modalActualizar #idPago").value = data.idPago || "";
            document.querySelector("#modalActualizar #idReserva").value = data.idReserva || "";
            document.querySelector("#modalActualizar #monto").value = data.monto || "";
            document.querySelector("#modalActualizar #metodoPago").value = data.metodoPago || "";
            document.querySelector("#modalActualizar #fechaPago").value = data.fechaPago || "";

            document.getElementById("idReserva").dispatchEvent(new Event('input'));
            document.getElementById("monto").dispatchEvent(new Event('input'));
            document.getElementById("metodoPago").dispatchEvent(new Event('input'));
            document.getElementById("fechaPago").dispatchEvent(new Event('input'));

            document.querySelector("#modalActualizar #idReserva").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #monto").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #metodoPago").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #fechaPago").dispatchEvent(new Event('input'));

            guardarBtn.innerText = "Actualizar";

            let modalActualizar = new bootstrap.Modal(document.getElementById("modalActualizar"));
            modalActualizar.show();
        } else {
            alert("No se pudo recuperar la información del pago.");
        }
    });
    //guardarBtn.innerText = "Actualizar";
    ////recuperarGenerico("Pago/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    //fetchGet("Pago/recuperarPago/?idPago=" + id, "json", function (data) {
    //    setN("idPago", data.idPago)
    //    setN("idPago", data.idPago)
    //    setN("idVehiculo", data.idVehiculo)
    //    setN("metodoPago", data.metodoPago)
    //    setN("fechaPago", data.fechaPago)
    //});
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este Pago?", function () {
        fetchDelete("Pago/EliminarPago/?idPago=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarPago();
                LimpiarDatos();

                let modalActualizar = bootstrap.Modal.getInstance(document.getElementById("modalActualizar"));
                if (modalActualizar) {
                    modalActualizar.hide();
                }

                Swal.fire("Eliminado", "El pago se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el pago", "error");
            }
        });
    });
    //const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    //if (!deleteAns) return;

    //fetchDelete("Pago/EliminarPago/?idPago=" + id, "text", (res) => {
    //    if (parseInt(res) == 1) {
    //        listarPago();
    //    }
    //});
}