using DoubleVPartners.Domain.Entity;
using DoubleVPartners.Domain.Interface;
using DoubleVPartners.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace DoubleVPartners.Domain.Core
{
    public class UsuariosDomain : IUsuariosDomain
    {
        private readonly IUsuariosRepository _Repository;
        public IConfiguration Configuration { get; }

        public UsuariosDomain(IUsuariosRepository repository, IConfiguration configuration)
        {
            _Repository = repository;
            Configuration = configuration;
        }

        public async Task<bool> InsertAsync(Usuario model)
        {
            model.Password = CreateMD5(model.Password);
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Usuario model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _Repository.DeleteAsync(id);
        }

        public async Task<Usuario> GetAsync(int id)
        {
            return await _Repository.GetAsync(id);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

        public async Task<Usuario?> Autenticar(string NombreUsuario, string Clave)
        {
            var resp = await _Repository.Autenticar(NombreUsuario);
            
            if (resp == null)
            {
                return null;
            }
            
            string? password = resp.Password;
            resp.Password = null;

            Clave = CreateMD5(Clave);
            return password == Clave ? resp : null;
        }

        private string CreateMD5(string? input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }


    }
}
