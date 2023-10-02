namespace Dominio.Interfaces;
public interface IUnitOfWorkInterface
{
    //cargamos cada una de las interfaces creadas 
    //IAreaIncidenciaInterface AreaIncidencias {get; }
    //IArlInterface Arl { get; }
    //ICategoriaInterface Categorias { get; }
    //ICiudadInterface Ciudades { get; }
    IRolInterface Roles { get; }
    IUsuarioInterface Usuarios { get; }
    IUsuariosRolesInterface UsuariosRoles { get; }


    Task<int> SaveAsync();
        
}
