
using Dominio.Entities;

namespace Dominio.Interfaces;
public interface IUsuarioInterface : IGenericInterfaceB<Usuario>
{
    Task<Usuario> GetByUsernameAsync(string username);
        
}
