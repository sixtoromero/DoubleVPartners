using Dapper;
using DoubleVPartners.Domain.Entity;
using DoubleVPartners.InfraStructure.Interface;
using DoubleVPartners.Transversal.Common;
using System.Data;


namespace DoubleVPartners.InfraStructure.Repository
{
    public class PersonasRepository : IPersonasRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PersonasRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Persona model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspPersonasInsert";
                var parameters = new DynamicParameters();

                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("TipoIdentificacion", model.TipoIdentificacion);
                parameters.Add("NumeroIdentificacion", model.NumeroIdentificacion);
                parameters.Add("Email", model.Email);                

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Persona model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspPersonasUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Identificador", model.Identificador);
                parameters.Add("Nombres", model.Nombres);
                parameters.Add("Apellidos", model.Apellidos);
                parameters.Add("TipoIdentificacion", model.TipoIdentificacion);
                parameters.Add("NumeroIdentificacion", model.NumeroIdentificacion);
                parameters.Add("Email", model.Email);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelPersonas";
                var parameters = new DynamicParameters();

                parameters.Add("@Identificador", id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<Persona> GetAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetPersonasByID";
                var parameters = new DynamicParameters();
                parameters.Add("@Identificador", id);

                var result = await connection.QuerySingleAsync<Persona>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Persona>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetPersonas";

                var result = await connection.QueryAsync<Persona>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
