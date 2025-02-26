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
        propiedadId: "idVehiculo"
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


function GuardarVehiculos() {
    let forma = document.getElementById("frmGuardarVehiculos");

    let frm = new FormData(forma);

    fetchPost("Vehiculos/GuardarVehiculos", "text", frm, function (data) {
        listarTipoMedicamento();
        LimpiarDatos("frmGuardarVehiculos");
    })
}

function LimpiarVehiculos() {
    LimpiarDatos("frmGuardarVehiculos");
}

function Editar(id) {
    recuperarGenerico("Vehiculos/recuperarVehiculos/?idVehiculo=" + id,"frmGuardarVehiculos")
    //fetchGet("Vehiculos/recuperarTipoMedicamento/?idTipoMedicamento=" + id, "json", function (data) {
    //    setN("idTipoMedicamento", data.idTipoMedicamento)
    //    setN("nombre", data.nombre)
    //    setN("descripcion", data.descripcion)

    //});
}