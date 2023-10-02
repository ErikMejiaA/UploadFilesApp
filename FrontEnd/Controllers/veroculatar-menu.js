export { verOculatarSeleccion };

function verOculatarSeleccion(data) {
    data[0].forEach(element => {
        let ver = document.querySelector(element);
        ver.style.display = "block";       
    });
    data[1].forEach(element2 => {
        let ocultar = document.querySelector(element2);
        ocultar.style.display = "none";
    });
}