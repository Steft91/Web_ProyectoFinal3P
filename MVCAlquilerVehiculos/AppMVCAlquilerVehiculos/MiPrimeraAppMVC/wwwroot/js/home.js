const carCarousel = document.querySelector(".carousel-car");

function generarCarruselVehiculos() {
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
							<a href="#" class="btn btn-primary py-2 mr-1">Solicitar ahora</a>
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
    });
}

document.addEventListener("DOMContentLoaded", () => {
    generarCarruselVehiculos();
});

