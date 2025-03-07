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
const modalTitle = document.getElementById("modalEmpleadoLabel");


document.getElementById("btnNuevoEmpleado").addEventListener("click", function () {
    LimpiarEmpleado();
    guardarBtn.innerText = "Crear";
    modalTitle.innerText = "Nuevo Empleado";
    idEmpleadoInput.value = "";

    $("#modalEmpleado").modal("show");
});

function GuardarEmpleado() {
    const frmGuardar = new FormData(document.getElementById("frmEmpleado"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarEmpleado();
            LimpiarDatos("frmEmpleado");
            $("#modalEmpleado").modal("hide");

            ExitoToast("Registro guardado con éxito");
        } else {
            ErrorToast();
        }
    };


    if (idEmpleadoInput.value != "") {
        Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
            fetchPut("Empleado/GuardarEmpleado", "text", frmGuardar, callback);
        });
    } else {
        fetchPost("Empleado/GuardarEmpleado", "text", frmGuardar, callback);
    }
}

function nuevoEmpleado() {
    LimpiarEmpleado();
    modalEmpleado.show();
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

function LimpiarEmpleado() {
    LimpiarDatos("frmEmpleado");
}

async function Editar(id) {
    LimpiarEmpleado();

    recuperarGenerico("Empleado/recuperarEmpleado/?idEmpleado=" + id, "frmEmpleado");

    guardarBtn.innerText = "Actualizar";
    modalTitle.innerText = "Actualizar Empleado";
    $("#modalEmpleado").modal("show");
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este Empleado?", function () {
        fetchDelete("Empleado/EliminarEmpleado/?idEmpleado=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarEmpleado();
                LimpiarDatos();

                if ($("#modalEmpleado").length > 0) {
                    $("#modalEmpleado").modal("hide");
                }

                Swal.fire("Eliminado", "El Empleado se eliminó correctamente", "success");
            } else {
                Swal.fire("Error", "No se pudo eliminar el Empleado", "error");
            }
        });
    });
}



