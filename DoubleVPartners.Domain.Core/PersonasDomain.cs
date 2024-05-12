using DoubleVPartners.Domain.Entity;
using DoubleVPartners.Domain.Interface;
using DoubleVPartners.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;

namespace DoubleVPartners.Domain.Core
{
    public class PersonasDomain : IPersonasDomain
    {
        private readonly IPersonasRepository _Repository;
        public IConfiguration Configuration { get; }

        public PersonasDomain(IPersonasRepository repository, IConfiguration configuration)
        {
            _Repository = repository;
            Configuration = configuration;
        }

        public async Task<bool> InsertAsync(Persona model)
        {
            return await _Repository.InsertAsync(model);
        }

        public async Task<bool> UpdateAsync(Persona model)
        {
            return await _Repository.UpdateAsync(model);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _Repository.DeleteAsync(id);
        }

        public async Task<Persona> GetAsync(int id)
        {
            return await _Repository.GetAsync(id);
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _Repository.GetAllAsync();
        }

    }
}
