
using firstApi.CommenLayer.Model;
using firstApi.RepositoryLayer;
using System.Text.RegularExpressions;

namespace firstApi.ServiceLayer
{
    public class ApiSL : IApiSL
    {
        public readonly IApiRL _apiRL;
        public ApiSL(IApiRL apiRL)
    {
            _apiRL = apiRL;

    }

        public async Task<AddUserResponse> AddInformation(AddUserRequest request)
        {
          
            return await _apiRL.AddInformation(request);
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            return await _apiRL.Login(request);
        }
    }
}
