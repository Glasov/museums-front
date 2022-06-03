using BlazorApp2.Data.Dtos;
using BlazorApp2.Managers;

namespace BlazorApp2.Services;

public interface IAuthService
{
    Task<bool> Login(AuthManager authManager, string email, string password);
    Task<bool> Register(AuthManager authManager, string name, string email, string password);
    Task<bool> DeleteUser(AuthManager authManager);
    Task<bool> UpdateUser(AuthManager authManager, string name, string email, string password);
}
