namespace firstApi.ServiceLayer.jwt
{
    public interface IJwtS
    {
        string GenerateJwtToken(string email);
    }
}
