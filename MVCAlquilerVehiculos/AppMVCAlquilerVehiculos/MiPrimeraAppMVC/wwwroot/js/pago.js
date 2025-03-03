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

//function GuardarPago() {
//    const frm = new FormData(document.getElementById("frmGuardarPago"));
//    const callback = (res) => {
//        const resInt = parseInt(res);
//        if (resInt == 1) {
//            listarPago();
//            LimpiarDatos("frmGuardarPago");
//            guardarBtn.innerText = "Guardar"; // Agg
//        }
//    }

//    if (idPagoInput.value && parseInt(idPagoInput.value) > 0) {
//        fetchPut("Pago/GuardarPago", "text", frm, callback);
//    } else {
//        fetchPost("Pago/GuardarPago", "text", frm, callback);
//    }

//}

function GuardarPago() {
    const frm = new FormData(document.getElementById("frmGuardarPago"));

    let fechaPago = get("fechaPago"); 
    let fecha = new Date(fechaPago);  
    let fechaFormateada = fecha.toISOString().split('T')[0]; // 'YYYY-MM-DD'

    frm.set("FechaPago", fechaFormateada);  

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarPago();
            LimpiarDatos("frmGuardarPago");
            guardarBtn.innerText = "Guardar"; 
        }
    }

    if (idPagoInput.value && parseInt(idPagoInput.value) > 0) {
        fetchPut("Pago/GuardarPago", "text", frm, callback);
    } else {
        fetchPost("Pago/GuardarPago", "text", frm, callback);
    }
}


function LimpiarPago() {
    LimpiarDatos("frmGuardarPago");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    guardarBtn.innerText = "Actualizar";
    //recuperarGenerico("Pago/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    fetchGet("Pago/recuperarPago/?idPago=" + id, "json", function (data) {
        console.log("Datos recibidos para edición:", data); // <-- Agregar depuración
        setN("idPago", data.idPago)
        setN("idReserva", data.idReserva)
        setN("monto", data.monto)
        setN("metodoPago", data.metodoPago)
        setN("fechaPago", data.fechaPago)
    });
}

function Eliminar(id) {
    const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    if (!deleteAns) return;

    fetchDelete("Pago/EliminarPago/?idPago=" + id, "text", (res) => {
        if (parseInt(res) == 1) {
            listarPago();
        }
    });
}