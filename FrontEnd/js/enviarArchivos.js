import { postUploadFiles } from "../Services/uploadFiles-service.js";

document.querySelector('#enviar').addEventListener('click', (e) => {

    //const enviarArchivos = document.querySelector('#enviarArchivos');
    //const data = Object.fromEntries(new FormData(enviarArchivos).entries());
    let formData = new FormData();
    let file = document.querySelector('#formFiles').files[0]
    console.log(file);
    formData.append('formFiles', file, file.name)
    
    console.log(formData);
    postUploadFiles(formData);
    
})