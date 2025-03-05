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

function GuardarVehiculo() {
    const frmGuardar = new FormData(document.getElementById("frmGuardarVehiculo"));

    const callback = (res) => {
        const resInt = parseInt(res);
        if (resInt == 1) {
            listarVehiculo();
            LimpiarDatos("frmGuardarVehiculo");

            // Cerrar el modal después de actualizar
            let modalActualizar = bootstrap.Modal.getInstance(document.getElementById("modalActualizar"));
            modalActualizar.hide();
        }
    };

    Confirmacion("Confirmación", "¿Desea guardar los cambios?", function () {
        if (idVehiculoInput.value != "") {
            fetchPut("Vehiculo/GuardarVehiculo", "text", frmGuardar, callback);
        } else {
            fetchPost("Vehiculo/GuardarVehiculo", "text", frmGuardar, callback);
        }
    });
    //const frm = new FormData(document.getElementById("frmGuardarVehiculo"));
    //const callback = (res) => {
    //    const resInt = parseInt(res);
    //    if (resInt == 1) {
    //        listarVehiculo();
    //        LimpiarDatos("frmGuardarVehiculo");
    //    }
    //}

    //if (idVehiculoInput.value != "") {
    //    fetchPut("Vehiculo/GuardarVehiculo", "text", frm, callback);
    //} else {
    //    fetchPost("Vehiculo/GuardarVehiculo", "text", frm, callback);
    //}
}

function nuevoVehiculo() {
    LimpiarVehiculo();
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

function LimpiarVehiculo() {
    LimpiarDatos("frmGuardarVehiculo");
    guardarBtn.innerText = "Guardar";

}

function Editar(id) {
    fetchGet("Vehiculo/recuperarVehiculo/?idVehiculo=" + id, "json", function (data) {
        if (data) {
            console.log("Datos recuperados:", data);

            document.getElementById("idVehiculo").value = data.idVehiculo || "";
            document.getElementById("marca").value = data.marca || "";
            document.getElementById("modelo").value = data.modelo || "";
            document.getElementById("anio").value = data.anio || "";
            document.getElementById("precio").value = data.precio || "";
            document.getElementById("estado").value = data.estado || "";

            document.querySelector("#modalActualizar #idVehiculo").value = data.idVehiculo || "";
            document.querySelector("#modalActualizar #marca").value = data.marca || "";
            document.querySelector("#modalActualizar #modelo").value = data.modelo || "";
            document.querySelector("#modalActualizar #anio").value = data.anio || "";
            document.querySelector("#modalActualizar #precio").value = data.precio || "";
            document.querySelector("#modalActualizar #estado").value = data.estado || "";

            document.getElementById("marca").dispatchEvent(new Event('input'));
            document.getElementById("modelo").dispatchEvent(new Event('input'));
            document.getElementById("anio").dispatchEvent(new Event('input'));
            document.getElementById("precio").dispatchEvent(new Event('input'));
            document.getElementById("estado").dispatchEvent(new Event('input'));

            document.querySelector("#modalActualizar #marca").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #modelo").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #anio").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #precio").dispatchEvent(new Event('input'));
            document.querySelector("#modalActualizar #estado").dispatchEvent(new Event('input'));

            guardarBtn.innerText = "Actualizar";

            let modalActualizar = new bootstrap.Modal(document.getElementById("modalActualizar"));
            modalActualizar.show();
        } else {
            alert("No se pudo recuperar la información del vehiculo.");
        }
    });

    //guardarBtn.innerText = "Actualizar";
    ////recuperarGenerico("TipoMedicamento/recuperarTipoMedicamento/?idTipoMedicamento=" + id,"frmGuardarTipoMedicamento");
    //fetchGet("Vehiculo/recuperarVehiculo/?idVehiculo=" + id, "json", function (data) {
    //    setN("idVehiculo", data.idVehiculo)
    //    setN("marca", data.marca)
    //    setN("modelo", data.modelo)
    //    setN("anio", data.anio)
    //    setN("precio", data.precio)
    //    setN("estado", data.estado)

    //});
}

function Eliminar(id) {
    Confirmacion("Confirmación", "¿Está seguro de que desea eliminar este Vehiculo?", function () {
        fetchDelete("Vehiculo/EliminarVehiculo/?idVehiculo=" + id, "text", function (res) {
            const resInt = parseInt(res);
            if (resInt === 1) {
                listarVehiculo();
                LimpiarDatos();

                let modalActualizar = bootstrap.Modal.getInstance(document.getElementById("modalActualizar"));
                if (modalActualizar) {
                    modalActualizar.hide();
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