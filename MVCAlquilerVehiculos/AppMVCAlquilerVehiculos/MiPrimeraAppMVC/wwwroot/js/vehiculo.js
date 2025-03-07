window.onload = function () {
    listarVehiculo();
};

function filtrarVehiculo() {
    let nombre = get("txtVehiculo");
    if (nombre == "") {
        listarVehiculo();
    } else {
        objVehiculo.url = "Vehiculo/filtrarVehiculo/?marca=" + marca;
        pintar(objVehiculo);
    }

}

let objVehiculo;

async function listarVehiculo() {
    objVehiculo = {
        url: "Vehiculo/listarVehiculo",
        cabeceras: ["Id Vehiculo", "Marca", "Modelo", "Año", "Precio", "Estado"],
        propiedades: ["idVehiculo", "marca", "modelo", "anio", "precio", "estado"],
        editar : true,
        eliminar: true,
        propiedadId: "idVehiculo"
    }

    pintar(objVehiculo);

}

function Buscar() {
    let nombreVehiculo = get("txtVehiculo");
    objVehiculo.url = "Vehiculo/filtrarVehiculo/?marca=" + nombreVehiculo;
    pintar(objVehiculo);
}

const idVehiculoInput = document.getElementById("idVehiculo");
const guardarBtn = document.getElementById("buttonGuardar");
const modalTitle = document.getElementById("modalVehiculoLabel");


document.getElementById("btnNuevoVehiculo").addEventListener("click", function () {
    LimpiarVehiculo();
    guardarBtn.innerText = "Crear";
    modalTitle.innerText = "Nuevo Vehículo";
    idVehiculoInput.value = "";

    $("#modalVehiculo").modal("show");
});

function GuardarVehiculo() {
    const frmGuardar = new FormData(document.getElementById("frmVehiculo"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarVehiculo();
            LimpiarDatos("frmVehiculo");
            $("#modalVehiculo").modal("hide");

            ExitoToast("Registro guardado con éxito");
        } else {
            ErrorToast();
        }
    };

    
    if (idVehiculoInput.value != "") {
        Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
            fetchPut("Vehiculo/GuardarVehiculo", "text", frmGuardar, callback);
        });
    } else {
        fetchPost("Vehiculo/GuardarVehiculo", "text", frmGuardar, callback);
    }
}

function nuevoVehiculo() {
    LimpiarVehiculo();
    modalVehiculo.show();
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

function LimpiarVehiculo() {
    LimpiarDatos("frmVehiculo");
}

async function Editar(id) {
    LimpiarVehiculo();

    recuperarGenerico("Vehiculo/recuperarVehiculo/?idVehiculo=" + id, "frmVehiculo");

    guardarBtn.innerText = "Actualizar";
    modalTitle.innerText = "Actualizar Vehículo";
    $("#modalVehiculo").modal("show");
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este Vehiculo?", function () {
        fetchDelete("Vehiculo/EliminarVehiculo/?idVehiculo=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarVehiculo();
                LimpiarDatos();

                if ($("#modalVehiculo").length > 0) {
                    $("#modalVehiculo").modal("hide");
                }

                Swal.fire("Eliminado", "El vehiculo se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el vehiculo", "error");
            }
        });
    });
    //const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    //if (!deleteAns) return;

    //fetchDelete("Vehiculo/recuperarVehiculo/?idVehiculo=" + id, "text", (res) => {
    //    if (parseInt(res) == 1) {
    //        listarVehiculo();
    //    }
    //});
}