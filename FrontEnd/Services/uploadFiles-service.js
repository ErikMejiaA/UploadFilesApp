export { postUploadFiles };

let config={
    headers:new Headers({
        "Content-Type": "multipart/form-data"
        
    })
};

const postUploadFiles = async(data)=>{
    config.method = "POST";
    config.body = data;
    let res= await ( await fetch("http://localhost:5000/api/UploadFiles",config)).json();
    console.log(res);
}