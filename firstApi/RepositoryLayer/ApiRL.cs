using BCrypt.Net;
using firstApi.CommenLayer.Model;
using firstApi.CommenUtility;
using firstApi.ServiceLayer.jwt;
using Microsoft.VisualBasic;
using MySqlConnector;

namespace firstApi.RepositoryLayer
{
    public class ApiRL : IApiRL
    {
        private readonly IConfiguration _configuration;
        private readonly MySqlConnection _mySqlConnection;
        private readonly IJwtS _jwtService;

        public ApiRL(IConfiguration configuration, IJwtS jwtService)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
            _mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDatabaseString"] ?? throw new ArgumentNullException("Connection string is null"));
        }

        public async Task<AddUserResponse> AddInformation(AddUserRequest request)
        {
            AddUserResponse response = new AddUserResponse
            {
                IsSuccess = true,
                Message = "Added with success"
            };

            try
            {
                // Hash the password before storing it
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

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
                    sqlCommand.Parameters.AddWithValue("@Password", hashedPassword);

                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "An error has occurred";
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

                    using (MySqlDataReader reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            response.IsSuccess = false;
                            response.Message = "Invalid email";
                        }
                        else
                        {
                            await reader.ReadAsync();
                            string storedHashedPassword = reader["Password"].ToString();

                            // Verify the password
                            if (BCrypt.Net.BCrypt.Verify(request.Password, storedHashedPassword))
                            {
                                // Generate JWT token
                                response.Token = _jwtService.GenerateJwtToken(request.Email);
                            }
                            else
                            {
                                response.IsSuccess = false;
                                response.Message = "Invalid email or password";
                            }
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
