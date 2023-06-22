using API.Models;

namespace API.Services.IServices
{
    public interface IJWTService
    {
        string CreateJWT(User user);
    }
}