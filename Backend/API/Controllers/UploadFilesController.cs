using System.Net;
using API.Dtos;
using AutoMapper;
using iText.Html2pdf.Attach.Impl.Tags;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class UploadFilesController : BaseApiController
{
    //Definmos el constructor, e inicializamos la variable IWebHostEnvironment la cual 
    //Proporciona información sobre el entorno de hospedaje web en el que se ejecuta una aplicación.
    //con el fin de obtener la ruta raiz del contenido
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly IMapper mapper;

    public UploadFilesController(IWebHostEnvironment webHostEnvironment, IMapper mapper)
    {
        _webHostEnvironment = webHostEnvironment;
        this.mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<List<UploadRestoreDto>>> PostUploadFile(List<IFormFile> formFiles)
    {
        
        //Crear un directory para el alojamaiento de los archivos a cargar, sino existe crea uno nuevo, Obtiene el directorio de trabajo actual de la aplicación.
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads\\files");

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        //creamos una instancia de Lista
        List<UploadRestoreDto> uploadRestoreDtos = new();
        //Recorremos la lista de archivos o achivo cargados 
        foreach (var file in formFiles)
        {
            if (file.Length > 0)
            {
                //creamos una nueva instacia del oojeto UploadResult
                UploadRestoreDto uploadRestoreDto = new();
                string fileNameAleatorio; //definimos un nombre para guardar el nuevo nombre del archivo cargado
                var fileNameOriginal = file.FileName; //nombre original del archivo
                uploadRestoreDto.FileName = fileNameOriginal; //lo guardamos en el objeto 
                var fileNameMostarOriginal = WebUtility.HtmlEncode(fileNameOriginal); //mostramos el nombre del archivo original cargado

                fileNameAleatorio = Path.GetRandomFileName(); //se agrega un nombre randomico al archivo cargado si ruta de acceso. evita que se sobreescriban los archivos que se cargan 
                var ruta = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads\\files", fileNameAleatorio); //cracion de la ruta raiz del contenido donde va a estar los archivos 

                //acontinuacion se crea el achivo y se guarda en la ruta escrita anteriormente 
                using (var crearArchivo = new FileStream(ruta, FileMode.Create))
                {
                    await file.CopyToAsync(crearArchivo); //copia los bytes de la secuancia actual y la escribe en otra secuencia. 
                }

                //agragamos el nuevo nombre de archivo creado al objeto y luego lo guardamos en la lista
                uploadRestoreDto.StoredFileName = fileNameAleatorio;
                uploadRestoreDtos.Add(uploadRestoreDto);
            }

        }

        //return Ok(uploadRestoreDtos);
        return this.mapper.Map<List<UploadRestoreDto>>(uploadRestoreDtos);

    }
        
}
