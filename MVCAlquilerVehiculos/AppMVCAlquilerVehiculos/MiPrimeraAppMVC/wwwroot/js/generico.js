

function LimpiarDatos(idFormulario) {
    let elementosName = document.querySelectorAll('#' + idFormulario + " [name]");
    let elementoActual;
    let elementoName;
    for (let i = 0; i < elementosName.length; i++) {
        elementoActual = elementosName[i];
        elementoName = elementoActual.name;
        setN(elementoName, "");
    }
}

async function fetchGet(url, tipoRespuesta, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url;

        let res = await fetch(urlCompleta);
        if (tipoRespuesta === "json") {
            res = await res.json();
        } else if (tipoRespuesta === "text") {
            res = await res.text();
        }

        callback(res);
    } catch (e) {
        alert("Ocurrió un problema: " + e.message);
    }
}

async function fetchPost(url, tipoRespuesta, frm, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;
        let urlCompleta = window.location.protocol+"//"+window.location.host+"/"+raiz+url;

        let res = await fetch(urlCompleta, {
            method: "POST",
            body: frm
        });

        if (tipoRespuesta === "json") {
            res = await res.json();
        } else if (tipoRespuesta === "text") {
            res = await res.text();
        }

        callback(res);
    } catch (e) {
        console.error(e.message, e)

        alert("Ocurrio un problema en POST")
    }
}

async function fetchPut(url, tipoRespuesta, frm, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;
        //http://localhost
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url;

        let res = await fetch(urlCompleta, {
            method: "PUT",
            body: frm,
        })
        if (tipoRespuesta == "json") {
            res = await res.json();
        }
        else if (tipoRespuesta == "text") {
            res = await res.text();
        }
        //JSON (object)
        console.log("Datos recibidos del backend:", res);
        callback(res);
    } catch (e) {
        console.error(e)
        alert("Ocurrió un problema en PUT");
    }
}

async function fetchDelete(url, tipoRespuesta, callback) {
    try {
        let raiz = document.getElementById("hdfOculto").value;
        //http://localhost
        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + raiz + url;

        let res = await fetch(urlCompleta, {
            method: "DELETE",
        })
        if (tipoRespuesta == "json") {
            res = await res.json();
        }
        else if (tipoRespuesta == "text") {
            res = await res.text();
        }
        //JSON (object)
        callback(res);
    } catch (e) {
        console.error(e)
        alert("Ocurrió un problema en DELETE");
    }
}

let objConfiguracionGlobal;

//{url: "", cebeceras[], propiedades: []}
function pintar(objConfiguracion) {
    objConfiguracionGlobal = objConfiguracion;

    if (objConfiguracionGlobal.divContenedorTabla == undefined) {
        objConfiguracionGlobal.divContenedorTabla = "divContenedorTabla";
    }

    if (objConfiguracionGlobal.editar == undefined) {
        objConfiguracionGlobal.editar = false;
    }

    if (objConfiguracionGlobal.eliminar == undefined) {
        objConfiguracionGlobal.eliminar = false;
    }
    if (objConfiguracionGlobal.propiedadId == undefined) {
        objConfiguracionGlobal.propiedadId = "";
    }

    fetchGet(objConfiguracion.url, "json", function (res) {
        let contenido = "";

        contenido = "<div id='divContenedorTabla'>"
        contenido += generarTabla(res);
        contenido += "</div>"
        document.getElementById("divTable").innerHTML = contenido;
        //let table = new DataTable("#dataTable");
    })
}
function generarTabla(res) {
    let contenido = "";
    let cabeceras = objConfiguracionGlobal.cabeceras;
    let propiedades = objConfiguracionGlobal.propiedades;
    contenido = '<table class="table table-striped table-success"  id="dataTable" >';
    contenido += "<thead>";
    contenido += "<tr>";

    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<th>" + cabeceras[i] + "</th>"
    }

    if (objConfiguracionGlobal.editar == true || objConfiguracionGlobal.eliminar == true) {
        contenido += "<th>Operaciones</th>"
    }

    contenido += "</tr>";
    contenido += "</thead>";

    let numRegistros = res.length;
    let obj;
    let propiedadActual;
    contenido += "<tbody>";

    for (let i = 0; i < numRegistros; i++) {
        obj = res[i];
        contenido += "<tr>";
        for (let j = 0; j < propiedades.length; j++) {
            propiedadActual = propiedades[j];
            contenido += "<td>" + obj[propiedadActual] + "</td>";
        }
        if (objConfiguracionGlobal.editar == true || objConfiguracionGlobal.eliminar == true) {
            let propiedadId = objConfiguracionGlobal.propiedadId
            contenido += "<td>";
            if (objConfiguracionGlobal.editar == true) {
                contenido += `<i onclick="Editar(${obj[propiedadId]})" class="btn btn-primary"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z"/>
                <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5z"/>
                </svg> </i>`
            }

            if (objConfiguracionGlobal.eliminar == true) {
                contenido += `<i onclick="Eliminar(${obj[propiedadId]})" class="btn btn-danger"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash3" viewBox="0 0 16 16">
                <path d="M6.5 1h3a.5.5 0 0 1 .5.5v1H6v-1a.5.5 0 0 1 .5-.5M11 2.5v-1A1.5 1.5 0 0 0 9.5 0h-3A1.5 1.5 0 0 0 5 1.5v1H1.5a.5.5 0 0 0 0 1h.538l.853 10.66A2 2 0 0 0 4.885 16h6.23a2 2 0 0 0 1.994-1.84l.853-10.66h.538a.5.5 0 0 0 0-1zm1.958 1-.846 10.58a1 1 0 0 1-.997.92h-6.23a1 1 0 0 1-.997-.92L3.042 3.5zm-7.487 1a.5.5 0 0 1 .528.47l.5 8.5a.5.5 0 0 1-.998.06L5 5.03a.5.5 0 0 1 .47-.53Zm5.058 0a.5.5 0 0 1 .47.53l-.5 8.5a.5.5 0 1 1-.998-.06l.5-8.5a.5.5 0 0 1 .528-.47M8 4.5a.5.5 0 0 1 .5.5v8.5a.5.5 0 0 1-1 0V5a.5.5 0 0 1 .5-.5"/>
                </svg> </i>`
            }
            contenido += "</td>";
        }

        contenido += "</tr>";
    }

    contenido += "</tbody>";
    contenido += "</table>";
    return contenido;
}

function recuperarGenerico(url, idFormulario) {
    let elementosName = document.querySelectorAll("#" + idFormulario + "[name]");
    let nombreName;

    fetchGet(url, "json", function (data) {
        for (let i = 0; i < elementosName.length; i++) {
            nombreName = elementosName[i].name;
            setN(nombreName, data[nombreName]);
        }
    });
 
}

function get(idControl) {
    return document.getElementById(idControl).value;
}

function set(idControl, valor) {
    document.getElementById(idControl).value = valor;
}

function setN(namecontrol, valor) {
    document.getElementsByName(namecontrol)[0].value = valor;
}

function Confirmacion(titulo = "Confirmación", texto = "¿Desea guardar los cambios?", callback = null) {
    Swal.fire({
        title: titulo,
        text: texto,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sí",
        cancelButtonText: "No",
    }).then((result) => {
        if (result.isConfirmed && typeof callback === "function") {
            callback(); // Se ejecuta solo si es una función válida
        }
    });
}