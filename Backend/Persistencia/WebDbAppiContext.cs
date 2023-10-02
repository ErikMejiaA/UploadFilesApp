
using System.Reflection;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistencia;
public class WebDbAppiContext : DbContext
{
    public WebDbAppiContext(DbContextOptions<WebDbAppiContext> options) : base(options)
    {

    }
    //aqui van los DbSet<> de las entidades de la base de datos
    public DbSet<Rol> ? Roles { get; set; }
    public DbSet<Usuario> ? Usuarios { get; set; }
    public DbSet<UsuariosRoles> ? UsuariosRoles { get; set; }
    public DbSet<UploadResult> ? UploadResults { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //definimos las llaves primarias campuestas de la entida ProductoPersona. de una relacion de muchos a muchos
        //modelBuilder.Entity<TrainerSalon>().HasKey(p => new {p.IdPerTrainerFk, p.IdSalonFk});

        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    internal void SaveAsync()
    {
        throw new NotImplementedException();
    }
}
