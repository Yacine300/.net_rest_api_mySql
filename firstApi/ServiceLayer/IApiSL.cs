using firstApi.CommenLayer.Model;

namespace firstApi.ServiceLayer
{
    public interface IApiSL
    {
        public Task<AddUserResponse> AddInformation(AddUserRequest request);
        public Task<LoginResponse> Login(LoginRequest request);
    }
}
