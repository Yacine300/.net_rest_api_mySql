using firstApi.CommenLayer.Model;
using firstApi.CommenUtility;
using firstApi.ServiceLayer.jwt;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace firstApi.RepositoryLayer
{
    public class ApiRL : IApiRL
    {
        public readonly  IConfiguration _configuration;
        public readonly  MySqlConnection _mySqlConnection;
        private readonly IJwtS _jwtService;



        public ApiRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDatabaseString"]);

        }
        public async Task<AddUserResponse> AddInformation(AddUserRequest request)
        {


            AddUserResponse response = new AddUserResponse();
            response.IsSuccess = true;
            response.Message = "added with success";

            try
            {
                await _mySqlConnection.OpenAsync();
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQeuries.AddInformation, _mySqlConnection))


                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName", request.UserName);
                    sqlCommand.Parameters.AddWithValue("@Email", request.Email);
                    sqlCommand.Parameters.AddWithValue("@PhoneNumber", request.PhoneNumber);
                    sqlCommand.Parameters.AddWithValue("@Gender", request.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", request.Salary);
                    sqlCommand.Parameters.AddWithValue("@Password", request.Password);
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "An Error has occured";
                        return response;
                    }
                    /*if(Status == 1)
                     {
                         response.isSuccess = true;
                         response.message = "Added with success";
                     }*/

                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            LoginResponse response = new LoginResponse
            {
                IsSuccess = true,
                Message = "Login successful"
            };

            try
            {
                await _mySqlConnection.OpenAsync();
                using (MySqlCommand sqlCommand = new MySqlCommand(SqlQeuries.Login, _mySqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@Email", request.Email);
                    sqlCommand.Parameters.AddWithValue("@Password", request.Password);

                    using (MySqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            response.IsSuccess = false;
                            response.Message = "Invalid email or password";
                        }
                        else
                        {
                            response.Token = _jwtService.GenerateJwtToken("herrouelnour@gmail.com");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                await _mySqlConnection.CloseAsync();
                await _mySqlConnection.DisposeAsync();
            }

            return response;
        }
    }
}

