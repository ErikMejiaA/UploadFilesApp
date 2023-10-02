using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork;
public class UnitOfWork : IUnitOfWorkInterface, IDisposable
{
    private readonly WebDbAppiContext _context;
    private UsuarioRepository ? _usuarios;
    private RolRepository ? _roles;
    private UsuariosRolesRepository ? _usuariosRoles;
    public UnitOfWork(WebDbAppiContext context)
    {
        _context = context;
    }

    //VAN LOS DEMAS METODOS
    public IRolInterface Roles
    {
        get
        {
            if (_roles == null) {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUsuarioInterface Usuarios
    {
        get
        {
            if (_usuarios == null) {
                _usuarios = new UsuarioRepository(_context);
            }
            return _usuarios;
        }
    }

    public IUsuariosRolesInterface UsuariosRoles
    {
        get
        {
            if (_usuariosRoles == null) {
                _usuariosRoles = new UsuariosRolesRepository(_context);
            }
            return _usuariosRoles;
        }
    }


    public void Dispose()
    {
        _context.Dispose(); //liberar menoria 
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync(); //guardar las actualizaciones en la Db
    }
}
