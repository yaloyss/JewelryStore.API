using JewelryStore.BLL.DTOs.Authentication;

namespace JewelryStore.BLL.Services.Interfaces
{
	public interface IAuthService
	{
        Task<AuthenticationResponseDTO> RegisterAsync(RegisterDTO registerDto);
        Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDto);
        Task<AuthenticationResponseDTO> RefreshTokenAsync(string refreshToken);
        Task<bool> RevokeTokenAsync(string refreshToken);
        Task<UserInfoDTO> GetUserByIdAsync(string userId);
        Task<bool> RevokeAllUserTokensAsync(string userId);
        //Task<bool> AssignRoleAsync(string userId, string roleName);
        //Task<bool> RemoveRoleAsync(string userId, string roleName);
    }
}

