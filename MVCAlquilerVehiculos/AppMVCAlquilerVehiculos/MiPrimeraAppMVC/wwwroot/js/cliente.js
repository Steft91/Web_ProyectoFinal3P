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
//function Limpiar() {
//    listarTipoMedicamento();
//    set("txtTipoMedicamento", "");
//}

const idClienteInput = document.getElementById("idCliente");
const guardarBtn = document.getElementById("buttonGuardar");
function GuardarCliente() {
    const frm = new FormData(document.getElementById("frmGuardarCliente"));
    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarCliente();
            LimpiarDatos("frmGuardarCliente");
        }
    }

    if (idClienteInput.value != "") {
        fetchPut("Cliente/GuardarCliente", "text", frm, callback);
    } else {
        fetchPost("Cliente/GuardarCliente", "text", frm, callback);
    }

}

function LimpiarCliente() {
    LimpiarDatos("frmGuardarCliente");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    guardarBtn.innerText = "Actualizar";
    //recuperarGenerico("Cliente/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    fetchGet("Cliente/recuperarCliente/?idCliente=" + id, "json", function (data) {
        setN("idCliente", data.idCliente)
        setN("nombre", data.nombre)
        setN("apellido", data.apellido)
        setN("telefono", data.telefono)
        setN("email", data.email)

    });
}

function Eliminar(id) {
    const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    if (!deleteAns) return;

    fetchDelete("Cliente/EliminarCliente/?idCliente=" + id, "text", (res) => {
        if (parseInt(res) == 1) {
            listarCliente();
        }
    });
}