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
const modalTitle = document.getElementById("modalSeguroLabel");

document.getElementById("btnNuevoSeguro").addEventListener("click", function () {
    LimpiarSeguro();
    guardarBtn.innerText = "Crear";
    modalTitle.innerText = "Nuevo Seguro";
    idSeguroInput.value = "";

    $("#modalSeguro").modal("show");
});
function GuardarSeguro() {
    const frmGuardar = new FormData(document.getElementById("frmSeguro"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarSeguro();
            LimpiarDatos("frmSeguro");
            $("#modalSeguro").modal("hide");

            ExitoToast("Registro guardado con éxito");
        } else {
            ErrorToast();
        }
    };

    if (idSeguroInput.value != "") {
        Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
            fetchPut("Seguro/GuardarSeguro", "text", frmGuardar, callback);
        });
    } else {
        fetchPost("Seguro/GuardarSeguro", "text", frmGuardar, callback);
    }

}

function nuevoSeguro() {
    LimpiarSeguro();
    modalSeguro.show();
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
function LimpiarSeguro() {
    LimpiarDatos("frmSeguro");
}

async function Editar(id) {
    LimpiarSeguro();

    recuperarGenerico("Seguro/recuperarSeguro/?idSeguro=" + id, "frmSeguro");

    guardarBtn.innerText = "Actualizar";
    modalTitle.innerText = "Actualizar Seguro";
    $("#modalSeguro").modal("show");
}
function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este seguro?", function () {
        fetchDelete("Seguro/eliminarSeguro/?idSeguro=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarSeguro();
                LimpiarDatos();

                if ($("#modalSeguro").length > 0) {
                    $("#modalSeguro").modal("hide");
                }

                Swal.fire("Eliminado", "El seguro se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el seguro", "error");
            }
        });
    });
    //const deleteAns = confirm("¿Está seguro de eliminar este dato?");
    //if (!deleteAns) return;

    //fetchDelete("Seguro/eliminarSeguro/?idSeguro=" + id, "text", (res) => {
    //    if (parseInt(res) == 1) {
    //        listarSeguro();
    //    }
    //});
}