namespace API.Helpers;
public class Autorizacion
{
    public enum Roles
    {
        Administrador,
        Gerente,
        Empleado,
        Persona


    }

    public const Roles rol_predeterminado = Roles.Persona;
        
}
