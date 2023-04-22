using CRUD_Products.Models.DataAccess;
using CRUD_Products.Models.Login.Models;
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

        public async Task<User> LoginAsync(
            LoginRequest loginRequest)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        username = loginRequest.Username,
                        password = loginRequest.Password
                    };

                    var sql = @"SELECT USERNAME As Username,
                                   KEYWORD As Password,
                                   USER_TYPE As Profile,
                                   ID As UserId
                            FROM USERS
                            WHERE USERNAME = @username AND
                                  KEYWORD = @password";

                    return await connection.QueryFirstOrDefaultAsync<User>(
                        sql,
                        parameters);
                }
            }
            catch (Exception ex)
            {

                throw;
            }     
                       
        }

        public async Task<int> LoginRegisterAsync(
            LoginRequest loginRequest, 
            string profile)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        username = loginRequest.Username,
                        password = loginRequest.Password,
                        profile = profile
                    };

                    var sql = @"INSERT INTO USERS
                                        (USERNAME
                                        ,KEYWORD
                                        ,USER_TYPE)
                                    VALUES
                                        (@username,
                                        @password,
                                        @profile)";

                    return await connection.ExecuteAsync(
                        sql,
                        parameters);
                }
            }
            catch (Exception ex)
            {

                throw;
            }   
        }

        public async Task<User> ValidateUserAsync(
            LoginRequest loginRequest)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        username = loginRequest.Username
                    };

                    var sql = @"SELECT USERNAME As Username
                            FROM USERS
                            WHERE USERNAME = @username";

                    return await connection.QueryFirstOrDefaultAsync<User>(
                        sql,
                        parameters);
                }
            }
            catch (Exception ex)
            {

                throw;
            }      
        }

        public async Task<int> UpdateUserAsync(
            LoginRequest loginRequest)
        {
            var connectionString = _connection.GetConnectionStringAppSettings();

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var parameters = new
                    {
                        username = loginRequest.Username,
                        newUsername = loginRequest.NewUsername,
                        newEmail = loginRequest.NewEmail,
                        userId = loginRequest.UserId
                    };

                    var sql = @"UPDATE USERS
                                SET USERNAME = @newUsername
                                    EMAIL = @newEmail
                                WHERE USERNAME = @username AND ID = @userId";

                    return await connection.ExecuteAsync(
                        sql,
                        parameters);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
