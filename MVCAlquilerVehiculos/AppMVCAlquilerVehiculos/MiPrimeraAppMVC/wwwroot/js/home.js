const carCarousel = document.querySelector(".carousel-car");
const carLoadingSpinner = document.querySelector(".cars-loading-spinner");
const formReserva = document.getElementById("form-reserva");

function generarCarruselVehiculos() {
    carLoadingSpinner.style.display = "block";
    fetchGet("Vehiculo/listarVehiculo", "json", (data) => {
        let content = ``;
        data.forEach((vehiculo) => {
            content += `
            <div class="item">
                <div class="car-wrap rounded">
                    <div class="img rounded d-flex align-items-end" style="background-image: url(data:image/png;base64,${vehiculo.imagen});">
                    </div>
                    <div class="text">
                        <h2 class="mb-0"><a href="#">${vehiculo.modelo}</a></h2>
                        <div class="d-flex mb-3">
                            <span class="cat">${vehiculo.marca}</span>
                            <p class="price ml-auto">$${vehiculo.precio} <span>/día</span></p>
                        </div>
                        <p class="d-flex mb-0 d-block">
							<a onclick="${isUserSignedIn ? "reservarVehiculo(" + vehiculo.idVehiculo + ")" : ""}" href="${isUserSignedIn ? "javascript:void" : "/Identity/Account/Login"}" class="btn ${isUserSignedIn ? "btn-secondary" : "btn-primary"} py-2">
								${isUserSignedIn ? "Solicitar ahora" : "Iniciar sesión para rentar"}
							</a>
						</p>
                    </div>
                </div>
            </div>`;
        });
        content += ``;

        carCarousel.innerHTML = content;

		var carousel = function () {
			$('.carousel-car').owlCarousel({
				center: true,
				loop: true,
				autoplay: true,
				items: 1,
				margin: 30,
				stagePadding: 0,
				nav: false,
				navText: ['<span class="ion-ios-arrow-back">', '<span class="ion-ios-arrow-forward">'],
				responsive: {
					0: {
						items: 1
					},
					600: {
						items: 2
					},
					1000: {
						items: 3
					}
				}
			});
			$('.carousel-testimony').owlCarousel({
				center: true,
				loop: true,
				items: 1,
				margin: 30,
				stagePadding: 0,
				nav: false,
				navText: ['<span class="ion-ios-arrow-back">', '<span class="ion-ios-arrow-forward">'],
				responsive: {
					0: {
						items: 1
					},
					600: {
						items: 2
					},
					1000: {
						items: 3
					}
				}
			});

		};
		carousel();

        carLoadingSpinner.style.display = "none";
    });
}


function validarFormReserva() {
    let isValid = true;
    if (!formReserva.checkValidity()) {
		isValid = false;

		//https://codepen.io/resource/pen/qBNLKXR
		setTimeout(() => {
			var tmpSubmit = document.createElement('button');
			formReserva.appendChild(tmpSubmit);
			tmpSubmit.click();
			formReserva.removeChild(tmpSubmit);
		}, 500);
	}

    return isValid;
}

function reservarVehiculo(idVehiculo) {
	if (validarFormReserva()) {
		const datosCliente = {
			nombre: formReserva.nombre.value,
			apellido: formReserva.apellido.value,
			telefono: formReserva.telefono.value,
			email: formReserva.email.value,
		}
		const reserva = {
			idVehiculo: idVehiculo,
			fechaInicio: formReserva.fechaInicio.value,
			fechaFin: formReserva.fechaFin.value,
		};
		const reqBody = {
			datosCliente,
			reserva
		}
		fetchPost("Reserva/crearReservaUsuario", "text", JSON.stringify(reqBody), (data) => {
			if (data == 1) {
                ExitoMsg("Reserva realizada con éxito");
				formReserva.reset();
			} else {
				ErrorToast();
			}
		}, "application/json");
	} else {
		formReserva.scrollIntoView({
			behavior: 'smooth',
		});
		ErrorToast("Por favor, complete el formulario de registro correctamente");
	}
}

if (formReserva) {

}

document.addEventListener("DOMContentLoaded", () => {
    generarCarruselVehiculos();
});
