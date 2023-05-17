using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }
        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName, CommandType commandType = CommandType.Text)
        {
            string connectionString = _config.GetConnectionString(connectionStringName) ?? string.Empty;

            using IDbConnection connection = new SqlConnection(connectionString);
            var rows = await connection.QueryAsync<T>(storedProcedure,
                                                      parameters,
                                                      commandType: commandType);

            return rows.ToList();
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
