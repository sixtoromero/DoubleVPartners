using DoubleVPartners.Domain.Entity;

namespace DoubleVPartners.InfraStructure.Interface
{
    public interface IUsuariosRepository : IRepository<Usuario>
    {
        Task<Usuario> Autenticar(string NombreUsuario);
    }
}
