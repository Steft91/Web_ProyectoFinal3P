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

const idClienteInput = document.getElementById("idCliente");
const guardarBtn = document.getElementById("buttonGuardar");
const modalTitle = document.getElementById("modalClienteLabel");


document.getElementById("btnNuevoCliente").addEventListener("click", function () {
    LimpiarCliente();
    guardarBtn.innerText = "Crear";
    modalTitle.innerText = "Nuevo Cliente";
    idClienteInput.value = "";

    $("#modalCliente").modal("show");
});

function GuardarCliente() {
    const frmGuardar = new FormData(document.getElementById("frmCliente"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarCliente();
            LimpiarDatos("frmCliente");
            $("#modalCliente").modal("hide");

            ExitoToast("Registro guardado con éxito");
        } else {
            ErrorToast();
        }
    };


    if (idClienteInput.value != "") {
        Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
            fetchPut("Cliente/GuardarCliente", "text", frmGuardar, callback);
        });
    } else {
        fetchPost("Cliente/GuardarCliente", "text", frmGuardar, callback);
    }
}

function nuevoCliente() {
    LimpiarCliente();
    modalCliente.show();
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

function LimpiarCliente() {
    LimpiarDatos("frmCliente");
}

async function Editar(id) {
    LimpiarCliente();

    recuperarGenerico("Cliente/recuperarCliente/?idCliente=" + id, "frmCliente");

    guardarBtn.innerText = "Actualizar";
    modalTitle.innerText = "Actualizar Cliente";
    $("#modalCliente").modal("show");
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este Cliente?", function () {
        fetchDelete("Cliente/EliminarCliente/?idCliente=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarCliente();
                LimpiarDatos();

                if ($("#modalCliente").length > 0) {
                    $("#modalCliente").modal("hide");
                }

                Swal.fire("Eliminado", "El Cliente se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el Cliente", "error");
            }
        });
    });

}