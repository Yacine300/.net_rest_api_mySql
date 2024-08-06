using firstApi.CommenLayer.Model;

namespace firstApi.RepositoryLayer
{
    public interface IApiRL
    {
        public Task<AddUserResponse> AddInformation(AddUserRequest request);
        public Task<LoginResponse> Login(LoginRequest request);
    }
}
