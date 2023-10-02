//export { activarDesactivarBoton, listarIdTeamSelect };

const activarDesactivarBoton = () => {
    document.querySelectorAll(".botonn").forEach((boton) => {
        boton.addEventListener('click', (e) => {
            let botondatos = JSON.parse(e.target.dataset.habilitardesabilitar);
            botondatos[0].forEach(item1 => {
                let botonHabilitar = document.querySelector(item1);
                botonHabilitar.disabled = false;
            });
            botondatos[1].forEach(item2 => {
                let botonDesabilitar = document.querySelector(item2);
                botonDesabilitar.disabled = true;
            });

            e.preventDefault();
            e.stopImmediatePropagation();
        });
    });
}

//------------------------------------------------------------------------