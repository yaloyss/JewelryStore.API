using JewelryStore.BLL.DTOs.Authentication;
using JewelryStore.BLL.Services.Interfaces;
using JewelryStore.DAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;

namespace JewelryStore.BLL.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JewelryStoreDbContext _context;
        private readonly IJwtService _jwtService;

        public AuthService(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            JewelryStoreDbContext context,
            IJwtService jwtService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthenticationResponseDTO> RegisterAsync(RegisterDTO registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Користувач з таким email вже існує");
            }

            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Помилка створення користувача: {errors}");
            }

            return await GenerateAuthResponseAsync(user);
        }

        public async Task<AuthenticationResponseDTO> LoginAsync(LoginDTO loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                throw new UnauthorizedAccessException("Невірний email або пароль");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                throw new UnauthorizedAccessException("Невірний email або пароль");
            }

            return await GenerateAuthResponseAsync(user);
        }

        public async Task<AuthenticationResponseDTO> RefreshTokenAsync(string refreshToken)
        {
            var user = await GetUserByRefreshTokenAsync(refreshToken);
            var oldRefreshToken = user.RefreshTokens.Single(rt => rt.Token == refreshToken);

            if (!oldRefreshToken.IsActive)
            {
                throw new UnauthorizedAccessException("Недійсний refresh token");
            }

            _context.RefreshTokens.Remove(oldRefreshToken);

            return await GenerateAuthResponseAsync(user);
        }

        public async Task<bool> RevokeTokenAsync(string refreshToken)
        {
            var user = await GetUserByRefreshTokenAsync(refreshToken);
            var token = user.RefreshTokens.Single(rt => rt.Token == refreshToken);

            if (!token.IsActive)
            {
                return false;
            }

            _context.RefreshTokens.Remove(token);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UserInfoDTO> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new KeyNotFoundException("Користувача не знайдено");
            }

            var roles = await _userManager.GetRolesAsync(user);

            return new UserInfoDTO
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = roles
            };
        }

        public async Task<bool> RevokeAllUserTokensAsync(string userId)
        {
            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return false;
            }

            var activeTokens = user.RefreshTokens.Where(rt => rt.IsActive).ToList();
            _context.RefreshTokens.RemoveRange(activeTokens);

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<AuthenticationResponseDTO> GenerateAuthResponseAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var accessToken = await _jwtService.GenerateAccessTokenAsync(user);
            var refreshToken = await GenerateRefreshTokenAsync(user);

            return new AuthenticationResponseDTO
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = roles,
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
                AccessTokenExpires = _jwtService.GetAccessTokenExpiration(),
                RefreshTokenExpires = refreshToken.Expires
            };
        }

        private async Task<RefreshToken> GenerateRefreshTokenAsync(User user)
        {
            var refreshToken = new RefreshToken
            {
                Token = _jwtService.GenerateRefreshToken(),
                Expires = _jwtService.GetRefreshTokenExpiration(),
                UserId = user.Id
            };

            await RemoveExpiredRefreshTokensAsync(user);

            user.RefreshTokens.Add(refreshToken);
            await _context.SaveChangesAsync();

            return refreshToken;
        }

        private async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            var user = await _context.Users
                .Include(u => u.RefreshTokens)
                .FirstOrDefaultAsync(u => u.RefreshTokens.Any(rt => rt.Token == refreshToken));

            if (user == null)
            {
                throw new UnauthorizedAccessException("Недійсний refresh token");
            }

            return user;
        }

        private async Task RemoveExpiredRefreshTokensAsync(User user)
        {
            var expiredTokens = user.RefreshTokens
                .Where(rt => rt.IsExpired)
                .ToList();

            if (expiredTokens.Any())
            {
                _context.RefreshTokens.RemoveRange(expiredTokens);
            }
        }
    }
}