using Alta_Flight.Model;

namespace Alta_Flight.Services
{
    public interface IJwtService
    {
        string GenerateToken(Accounts account);
    }
}
