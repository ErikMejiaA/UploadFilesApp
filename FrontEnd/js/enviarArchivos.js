import { postUploadFiles } from "../Services/uploadFiles-service.js";

document.querySelector('#enviar').addEventListener('click', (e) => {

    //const enviarArchivos = document.querySelector('#enviarArchivos');
    //const data = Object.fromEntries(new FormData(enviarArchivos).entries());
    let archivo = new FormData()
    archivo.append("formFiles", document.querySelector('#formFiles').files[0])
    
    console.log(archivo.formFiles);
    /*postUploadFiles(archivo)
        .then((dato) => {
            console.log(dato);
        })*/
    
})