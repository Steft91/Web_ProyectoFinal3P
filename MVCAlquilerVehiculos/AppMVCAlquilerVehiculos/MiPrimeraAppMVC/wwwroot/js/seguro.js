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
    const frmGuardar = new FormData(document.getElementById("frmGuardarSeguro"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarSeguro();
            LimpiarDatos("frmGuardarSeguro");

            // Cerrar el modal después de actualizar
            $("#modalActualizar").modal("hide");
        }
    };

    Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
        if (idSeguroInput.value != "") {
            fetchPut("Seguro/GuardarSeguro", "text", frmGuardar, callback);
        } else {
            fetchPost("Seguro/GuardarSeguro", "text", frmGuardar, callback);
        }
    });
    //const frm = new FormData(document.getElementById("frmGuardarSeguro"));
    //const callback = (res) => {
    //    const resInt = parseInt(res);
    //    if (resInt == 1) {
    //        listarSeguro();
    //        LimpiarDatos("frmGuardarSeguro");
    //        guardarBtn.innerText = "Guardar";
    //    }
    //}

    //if (idSeguroInput.value != "") {
    //    fetchPut("Seguro/GuardarSeguro", "text", frm, callback);
    //} else {
    //    fetchPost("Seguro/GuardarSeguro", "text", frm, callback);
    //}

}

function nuevoPago() {
    LimpiarPago();
    modalActualizar.show();
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
    LimpiarDatos("frmGuardarSeguro");
    guardarBtn.innerText = "Guardar";
}

function Editar(id) {
    fetchGet("Seguro/recuperarSeguro/?idSeguro=" + id, "json", function (data) {
        if (data) {
            console.log("Datos recuperados:", data);

            document.getElementById("idSeguro").value = data.idSeguro || "";
            document.getElementById("idReserva").value = data.idReserva || "";
            document.getElementById("tipoSeguro").value = data.tipoSeguro || "";
            document.getElementById("costo").value = data.costo || "";

            document.querySelector("#modalActualizar #idSeguro").value = data.idSeguro || "";
            document.querySelector("#modalActualizar #idReserva").value = data.idReserva || "";
            document.querySelector("#modalActualizar #tipoSeguro").value = data.tipoSeguro || "";
            document.querySelector("#modalActualizar #costo").value = data.costo || "";

            document.getElementById("idReserva").dispatchEvent(new Event('input'));
            document.getElementById("tipoSeguro").dispatchEvent(new Event('input'));
            document.getElementById("costo").dispatchEvent(new Event('input'));

            document.querySelector("#modalActualizar #idReserva").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #tipoSeguro").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #costo").dispatchEvent(new Event('input'));

            guardarBtn.innerText = "Actualizar";

            $("#modalActualizar").modal("show");
        } else {
            alert("No se pudo recuperar la información del seguro.");
        }
    });

    //guardarBtn.innerText = "Actualizar";
    ////recuperarGenerico("Seguro/recuperarSeguro/?idSeguro=" + id,"frmGuardarSeguro");
    //fetchGet("Seguro/recuperarSeguro/?idSeguro=" + id, "json", function (data) {
    //    setN("idSeguro", data.idSeguro)
    //    setN("idReserva", data.idReserva)
    //    setN("tipoSeguro", data.tipoSeguro)
    //    setN("costo", data.costo)

    //});
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este seguro?", function () {
        fetchDelete("Seguro/eliminarSeguro/?idSeguro=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarSeguro();
                LimpiarDatos();

                if ($("#modalActualizar").length > 0) {
                    $("#modalActualizar").modal("hide");
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