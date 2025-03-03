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
    const frm = new FormData(document.getElementById("frmGuardarEmpleado"));
    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarEmpleado();
            LimpiarDatos("frmGuardarEmpleado");
            guardarBtn.innerText = "Guardar";
        }
    }

    if (idEmpleadoInput.value != "") {
        fetchPut("Empleado/GuardarEmpleado", "text", frm, callback);
    } else {
        fetchPost("Empleado/GuardarEmpleado", "text", frm, callback);
    }

}

function LimpiarEmpleado() {
    LimpiarDatos("frmGuardarEmpleado");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    guardarBtn.innerText = "Actualizar";
    //recuperarGenerico("Empleado/recuperarTipoMedicamento/?idEmpleado=" + id,"frmGuardarEmpleado");
    fetchGet("Empleado/recuperarEmpleado/?idEmpleado=" + id, "json", function (data) {
        setN("idEmpleado", data.idEmpleado)
        setN("nombreEmpleado", data.nombreEmpleado)
        setN("apellidoEmpleado", data.apellidoEmpleado)
        setN("cargo", data.cargo)
        setN("telefonoEmpleado", data.telefonoEmpleado)
        setN("emailEmpleado", data.emailEmpleado)

    });
}

function Eliminar(id) {
    const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    if (!deleteAns) return;

    fetchDelete("Empleado/EliminarEmpleado/?idEmpleado=" + id, "text", (res) => {
        if (parseInt(res) == 1) {
            listarEmpleado();
        }
    });
}