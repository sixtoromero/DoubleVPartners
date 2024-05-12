using Dapper;
using DoubleVPartners.Domain.Entity;
using DoubleVPartners.InfraStructure.Interface;
using DoubleVPartners.Transversal.Common;
using System.Data;

namespace DoubleVPartners.InfraStructure.Repository
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UsuariosRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> InsertAsync(Usuario model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosInsert";
                var parameters = new DynamicParameters();

                parameters.Add("NombreUsuario", model.NombreUsuario);
                parameters.Add("Password", model.Password);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> UpdateAsync(Usuario model)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspUsuariosUpdate";
                var parameters = new DynamicParameters();

                parameters.Add("Identificador", model.Identificador);                
                parameters.Add("Password", model.Password);

                //Persistir la info en la bd
                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspDelUsuarios";
                var parameters = new DynamicParameters();

                parameters.Add("@Identificador", id);

                var result = await connection.QuerySingleAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result == "success" ? true : false;
            }
        }

        public async Task<Usuario> GetAsync(int id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuariosByID";
                var parameters = new DynamicParameters();
                parameters.Add("@Identificador", id);

                var result = await connection.QuerySingleAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "UspgetUsuarios";

                var result = await connection.QueryAsync<Usuario>(query, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
