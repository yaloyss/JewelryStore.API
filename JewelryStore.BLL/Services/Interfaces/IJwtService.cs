using JewelryStore.DAL.Data.Models;
using System.Security.Claims;

namespace JewelryStore.BLL.Services.Interfaces
{
	public interface IJwtService
	{
        Task<string> GenerateAccessTokenAsync(User user);
        string GenerateAccessToken(User user);
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        DateTime GetAccessTokenExpiration();
        DateTime GetRefreshTokenExpiration();
    }
}

