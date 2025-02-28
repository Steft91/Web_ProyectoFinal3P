window.onload = function () {
    listarVehiculos();
};

function filtarVehiculos() {
    let nombre = get("txtVehiculos");
    if (nombre == "") {
        listarVehiculos();
    } else {
        objVehiculos.url = "Vehiculos/filtrarVehiculos/?marca=" + marca;
        pintar(objVehiculos);
    }

}

let objVehiculos;

async function listarVehiculos() {
    objVehiculos = {
        url: "Vehiculos/listarVehiculos",
        cabeceras: ["Id Vehiculo", "Marca", "Modelo", "Año", "Precio", "Estado"],
        propiedades: ["idVehiculo", "marca", "modelo", "anio", "precio", "estado"],
        editar : true,
        eliminar: true,
        propiedadId: "idVehiculos"
    }

    pintar(objVehiculos);

}

function Buscar() {
    let nombreVehiculos = get("txtVehiculos");
    objVehiculos.url = "Vehiculos/filtrarVehiculos/?nombre=" + nombreVehiculos;
    pintar(objVehiculos);
}
//function Limpiar() {
//    listarTipoMedicamento();
//    set("txtTipoMedicamento", "");
//}

const idVehiculosInput = document.getElementById("idVehiculos");
const guardarBtn = document.getElementById("buttonGuardar");

function GuardarVehiculos() {
    const frm = new FormData(document.getElementById("frmGuardarVehiculos"));
    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarVehiculos();
            LimpiarDatos("frmGuardarVehiculos");
        }
    }

    if (idVehiculosInput.value != "") {
        fetchPut("Vehiculos/GuardarVehiculos", "text", frm, callback);
    } else {
        fetchPost("Vehiculos/GuardarVehiculos", "text", frm, callback);
    }
}

function LimpiarVehiculos() {
    LimpiarDatos("frmGuardarVehiculos");
    guardarBtn.innerText = "Guardar";

}

function Editar(id) {
    guardarBtn.innerText = "Actualizar";
    //recuperarGenerico("TipoMedicamento/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    fetchGet("Vehiculos/recuperarVehiculos/?idVehiculos=" + id, "json", function (data) {
        setN("idVehiculos", data.idVehiculo)
        setN("marca", data.marca)
        setN("modelo", data.modelo)
        setN("anio", data.anio)
        setN("precio", data.precio)
        setN("estado", data.estado)

    });
}

function Eliminar(id) {
    const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    if (!deleteAns) return;

    fetchDelete("Vehiculos/recuperarVehiculos/?idVehiculos=" + id, "text", (res) => {
        if (parseInt(res) == 1) {
            listarVehiculos();
        }
    });
}