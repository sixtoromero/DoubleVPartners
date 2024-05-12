using DoubleVPartners.Application.DTO;
using DoubleVPartners.Transversal.Common;

namespace DoubleVPartners.Application.Interface
{
    public interface IUsuariosApplication : IApplication<UsuarioDTO>
    {
        Task<Response<UsuarioDTO?>> Autenticar(string NombreUsuario, string Clave);
    }
}
