window.onload = function () {
    listarSeguro();
};

function filtrarSeguro() {
    let nombre = get("txtSeguro");
    if (nombre == "") {
        listarSeguro();
    } else {
        objSeguro.url = "Seguro/filtrarSeguro/?tipoSeguro=" + nombre;
        pintar(objSeguro);
    }

}

let objSeguro;

async function listarSeguro() {
    objSeguro = {
        url: "Seguro/listarSeguro",
        cabeceras: ["id Seguro", "Id Reserva", "Tipo de Seguro", "Costo"],
        propiedades: ["idSeguro", "idReserva", "tipoSeguro", "costo"],
        editar: true,
        eliminar: true,
        propiedadId: "idSeguro"
    }

    pintar(objSeguro);

}

function Buscar() {
    let nombreSeguro = get("txtSeguro");
    objSeguro.url = "Seguro/filtrarSeguro/?idSeguro=" + nombreSeguro;
    pintar(objSeguro);
}

const idSeguroInput = document.getElementById("idSeguro");
const guardarBtn = document.getElementById("buttonGuardar");
function GuardarSeguro() {
    const frm = new FormData(document.getElementById("frmGuardarSeguro"));
    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarSeguro();
            LimpiarDatos("frmGuardarSeguro");
            guardarBtn.innerText = "Guardar";
        }
    }

    if (idSeguroInput.value != "") {
        fetchPut("Seguro/GuardarSeguro", "text", frm, callback);
    } else {
        fetchPost("Seguro/GuardarSeguro", "text", frm, callback);
    }

}

function LimpiarSeguro() {
    LimpiarDatos("frmGuardarSeguro");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    guardarBtn.innerText = "Actualizar";
    //recuperarGenerico("Seguro/recuperarSeguro/?idSeguro=" + id,"frmGuardarSeguro");
    fetchGet("Seguro/recuperarSeguro/?idSeguro=" + id, "json", function (data) {
        setN("idSeguro", data.idSeguro)
        setN("idReserva", data.idReserva)
        setN("tipoSeguro", data.tipoSeguro)
        setN("costo", data.costo)

    });
}

function Eliminar(id) {
    const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    if (!deleteAns) return;

    fetchDelete("Seguro/eliminarSeguro/?idSeguro=" + id, "text", (res) => {
        if (parseInt(res) == 1) {
            listarSeguro();
        }
    });
}