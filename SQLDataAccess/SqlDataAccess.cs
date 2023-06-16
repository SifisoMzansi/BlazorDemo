using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlDataAccess : ISqlDataAccess
    {
        const string ConnectionName = "Default";
        string ConnectionString { set; get; }
        public SqlDataAccess(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString(ConnectionName)!;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            using (IDbConnection MyConnection = new SqlConnection(ConnectionString))
            {
                var Results = await MyConnection.QueryAsync<T>(sql, parameters);
                return Results.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection MyConnection = new SqlConnection(ConnectionString))
            {
                await MyConnection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
