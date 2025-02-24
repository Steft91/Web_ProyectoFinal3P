window.onload = function () {
    listarTipoMedicamento();
};

function filtarTipoMedicamento() {
    let nombre = get("txtTipoMedicamento");
    if (nombre == "") {
        listarTipoMedicamento();
    } else {
        objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombre;
        pintar(objTipoMedicamento);
    }

}

let objTipoMedicamento;

async function listarTipoMedicamento() {
    objTipoMedicamento = {
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["id Tipo Medicamento", "Nombre", "Descripcion"],
        propiedades: ["idTipoMedicamento", "nombre", "descripcion"],
        editar : true,
        eliminar: true,
        propiedadId: "idTipoMedicamento"
    }

    pintar(objTipoMedicamento);

}

function Buscar() {
    let nombreTipoMedicamento = get("txtTipoMedicamento");
    objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombreTipoMedicamento;
    pintar(objTipoMedicamento);
}
function Limpiar() {
    listarTipoMedicamento();
    set("txtTipoMedicamento", "");
}


function GuardarTipoMedicamento() {
    let forma = document.getElementById("frmGuardarTipoMedicamento");

    let frm = new FormData(forma);

    fetchPost("TipoMedicamento/GuardarTipoMedicamento", "text", frm, function (data) {
        listarTipoMedicamento();
        LimpiarDatos("frmGuardarTipoMedicamento");
    })
}

function LimpiarTipoMedicamento() {
    LimpiarDatos("frmGuardarTipoMedicamento");
}

function Editar(id) {
    recuperarGenerico("TipoMedicamento/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento")
    //fetchGet("TipoMedicamento/recuperarTipoMedicamento/?idTipoMedicamento=" + id, "json", function (data) {
    //    setN("idTipoMedicamento", data.idTipoMedicamento)
    //    setN("nombre", data.nombre)
    //    setN("descripcion", data.descripcion)

    //});
}