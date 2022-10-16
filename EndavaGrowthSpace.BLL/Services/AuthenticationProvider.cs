using EndavaGrowthSpace.BLL.Interfaces;

namespace EndavaGrowthSpace.BLL.Services;

public class AuthenticationProvider : IAuthenticationProvider
{
    public int GetUserId()
    {
        return 1;
    }
}