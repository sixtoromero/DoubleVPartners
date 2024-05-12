using DoubleVPartners.Domain.Entity;

namespace DoubleVPartners.Domain.Interface
{
    public interface IUsuariosDomain : IDomain<Usuario>
    {
        Task<Usuario?> Autenticar(string NombreUsuario, string Clave);
    }
}
