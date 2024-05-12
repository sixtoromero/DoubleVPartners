using DoubleVPartners.Domain.Entity;
using DoubleVPartners.Domain.Interface;
using DoubleVPartners.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;

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
    }
}
