using CRUD_Products.Models.DataAccess;
using CRUD_Products.Models.Login.Models.Request;
using CRUD_Products.Models.Login.Models.Response;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CRUD_Products.Models.Login.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IConnection _connection;

        public LoginRepository(IConnection connection) 
        {
            _connection = connection;
        }    

        public async Task<LoginResponse> LoginAsync(
            LoginRequest loginRequest)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            using(var connection = new SqlConnection(connectionString))
            {
                var parameters = new 
                { 
                    username = loginRequest.Username,
                    password = loginRequest.Password
                };

                var sql = @"SELECT USERNAME As Username,
                                   KEYWORD As Password
                            FROM USERS
                            WHERE USERNAME = @username AND
                                  KEYWORD = @password";

                return await connection.QueryFirstOrDefaultAsync<LoginResponse>(
                    sql,
                    parameters);
            }

            
        }

        public async Task<int> LoginRegisterAsync(
            LoginRequest loginRequest)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            using (var connection = new SqlConnection(connectionString))
            {
                var parameters = new
                {
                    username = loginRequest.Username,
                    password = loginRequest.Password
                };

                var sql = @"INSERT INTO USERS
                                        (USERNAME
                                        ,KEYWORD)
                                    VALUES
                                        (@username,
                                        @password)";

                return await connection.ExecuteAsync(
                    sql, 
                    parameters);
            }
        }
    }
}
