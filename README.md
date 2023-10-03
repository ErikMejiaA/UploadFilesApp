# UPLOAD FILES

para más información acerca de cómo funciona la carga de archivos y como implementar medidas de seguridad y los tiempos de almacenamientos más comunes para la carga del archivo, además de cuando un archivo es pequeño o grande consulte el siguiente link:

## Upload Files

 - [Carga de archivos en ASP.NET Core](https://learn.microsoft.com/es-es/aspnet/core/mvc/models/file-uploads?view=aspnetcore-7.0#match-name-attribute-value-to-parameter-name-of-post-method)

 ## Creación del método para la carga de archivos en una WebApi con .Net Core

El siguiente paso puede ser o no obligatorio ya que en algunos casos lo realizan y en otros no, a modo personal lo desarrolle para poder ver a la salida el nombre del archivo original y el nombre del archivo con el que se guarda al subir dicho archivo. 

1. En la carpeta **Dominio** dentro de la carpeta **Entities**, cree una clase o entidad llamada **UploadResult**, dicha clase lo que va hacer es permitirme ver el nombre original y el nombre con el que se guarda el archivo que se va a subir. ver imagen:

![Imagen Uno](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/Foto1.PNG?raw=true)

la clase a la que hereda es BaseEntityB esta solo contiene la llave primaria de la entidad. ver imagen

![Imagen Dos](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto2.PNG?raw=true)

luego le cree un archivo de configuración, el cual se aloja en la carpeta de **Persistencia** luego en la carpeta **Data** y finalmente en la carpeta de **Configuration** y después la agregue al **DbSet<>**, la cual está en en el archivo **Context** que está dentro de la carpeta de **Persistencia**. esto con el fin de poder ver la entidad creada en la base de datos. A continuación se muestra el archivo de configuración junto al **DbSet<>** creado:

![Imagen Tres](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto3.PNG?raw=true)

![Imagen Cuatro](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto4.PNG?raw=true)

finalmente se ejecutaron las migraciones, con el fin de guardar los nuevos cambios. 

**dotnet ef migrations add InitialMigrationCreate --project ./Persistencia/ --startup-project ./API/ --output-dir ./Data/Migrations**

2. Luego dentro de la carpeta de **API** en la carpeta de los **Dtos**, cree un nuevo **Dto** con los mismos parámetros de la entidad creada anteriormente. esto con el fin de utilizarlo en el archivo de la petición que permite subir archivos. ver Dto creado:

![Imagen Cinco](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto5.PNG?raw=true)


## Creación del controlador que va a permitir subir archivos (UploadFiles)

para la creación del controlador y de su EndPoint no se necesito de ningún paquete de instalación fuera de los que ya se tienen instalados. 

1. Antes de comenzar dentro de la carpeta **API**, creamos una carpeta la cual va a contener los archivos que se van a subir, al implementar el controlador de **UploadFilesController**. Dicha carpeta puede tener cualquier nombre, para este caso el nombre que se le dio fue de **Uploads** y dentro de ella una nueva carpeta **files** la cual contiene los archivos. ver caretas:

![Imagen Seis](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto6.PNG?raw=true)

2. Dentro de la carpeta de Controllers que es en la carpeta **API**, se creó el archivo **UploadFilesControlles**Este archivo va a contener la petición que va a permitir hacer la carga de archivos a la carpeta creada anteriormente.

3. El código implementando para la creación de la petición es el siguiente:

![Imagen Siete](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto7.PNG?raw=true)

![Imagen Ocho](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto8.PNG?raw=true)

![Imagen Nueve](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto9.PNG?raw=true)

A continuación se explica el código y que es lo que se está haciendo:


- Primero que todo se realiza la Herencia hacia el controlador **BaseApiController:**

![Imagen Dies](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto10.PNG?raw=true)

- después se creó el constructor el cual tiene como parámetro el **IwebHostEnvironment**, el cual proporciona información sobre el entorno web en el que se ejecuta la aplicación y además de eso nos permite obtener la ruta raíz del contenido de la carpeta **API**. Y el **IMapper** para mapear el contenido. Además se inicializan las variables de dichos parámetros para ser utilizadas dentro del archivo. 

![Imagen Once](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto11.PNG?raw=true)

- Después creamos un método **HttPost**, el cual tiene como salida un una lista con el **Dto** creado anteriormente **(List<UploadRestoreDto>)**. los parámetro de entrada son una lista que contiene un archivo **HttRequest** el cual es un objeto **(List<IFromFile>)**

![Imagen Dose](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto12.PNG?raw=true)

- Luego se crea un directorio Carpeta para alojar los archivos que se van a cargar para ello se utiliza **Directory.GetCurrentDirectory()** para obtener la ruta del directorio actual del trabajo y se la añade el nombre de la carpeta **“Uploads\\files”** y utilizando **Path.combine** para crear la ruta. luego en la sentencia del **if** va a preguntar si la ruta que se creó existe o no, y si no existe se crea  nuevo directorio.

![Imagen Trese](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto13.PNG?raw=true)

- Después creamos una lista objeto del **Dto** creado con el fin de almacenar la inflamación a retornar al realizar la carga del archivo.

![Imagen Catorce](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto14.PNG?raw=true)

- Ahora como la entrada es una lista de archivos a cargar, mediante un **foreach** recorremos el array de archivos que se van a cargar o el archivo y para cada uno se realiza lo siguiente: pero antes se verifica que el archivo contenga contenido y no esté vacío.

![Imagen Quince](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto15.PNG?raw=true)

- Creamos una nueva instancia del **Dto** para almacenar su nombre original y su nuevo nombre:

![Imagen Dieciseis](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto16.PNG?raw=true)

- luego creamos una nueva variable tipo **string** para guardar el nuevo nombre del archivo a cargar:

![Imagen Diecisiete](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto17.PNG?raw=true)

- Después obtenemos el nombre del archivo original y lo guardamos dentro del objeto creado:

![Imagen Dieciocho](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto18.PNG?raw=true)

- Luego utilizando el método **Path.GetRandomFileName()**, cuya función es generar un nombre aleatorio para los archivos subidos, y esto permite que no se sobreescriban dichos archivos al subir el mismo archivo además de colocar algo de seguridad. este nombre generado se le agrega a la variable **fileNameAleatorio**.

![Imagen Diecinueve](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto19.PNG?raw=true)

- luego se crea la ruta raíz en donde se van a guardar los archivos cargados:

![Imagen Veinte](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto20.PNG?raw=true)

- luego se crea el archivo y se guarda dentro de la ruta creada anteriormente. FileStream proporciona al archivo creado permisos de lectura y escritura y el **fileMode.Create** crea el archivo. Luego se toma el archivo actual y se sobrescribe dentro de otra secuencia o archivo esto se hace mediante el **file.CopyToAsync()**.

![Imagen Veintiuno](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto21.PNG?raw=true)

- Después se guarda dentro del objeto creado el nuevo nombre del archivo creado y se agrega a la lista creada. 

![Imagen Veintidos](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto22.PNG?raw=true)

- Finalmente retornamos la lista creada dentro del **Dto** creado. 

![Imagen Veintitres](https://github.com/ErikMejiaA/UploadFilesApp/blob/main/Imagenes/foto23.PNG?raw=true)

y de esta forma se concluye la construcción del EndPoint que permite subir archivos dentro de la misma aplicación.

