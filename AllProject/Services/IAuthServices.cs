using JwtTest.Dto;
using JwtTest.Models;

namespace JwtTest.Services
{
    public interface IAuthServices

    {
        Task<AuthModel> RegisterAsync(RegisterModel model);
        Task<AuthModel> GetTokenAsync(TokenRequestModel model);
        Task<string> AddRoleAsync(AddRoleModel model);


    }
}
