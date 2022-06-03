using BlazorApp2.Data.Dtos;
using BlazorApp2.Managers;

namespace BlazorApp2.Services
{
    public class AuthService : IAuthService
    {
        private IUsersProvider _usersProvider;
        private UserDto? User { set; get; }

        public AuthService(IUsersProvider usersProvider)
        {
            this._usersProvider = usersProvider;
            User = null;
        }

        public async Task<bool> Login(AuthManager authManager, string email, string password)
        {
            Console.Out.WriteLine("got request");
            Console.Out.WriteLine(email + " " + password);
            UserLoginDto userLoginDto = new UserLoginDto {Email = email, Password = password};
            UserDto? result = await _usersProvider.Login(userLoginDto);
            return authManager.Login(result).IsAuthorized();
        }

        public async Task<bool> Register(AuthManager authManager, string name, string email, string password)
        {
            UserCreationDto userCreationDto = new UserCreationDto { Name = name, Email = email, Password = password };
            Console.Out.WriteLine("register request with dto: " + userCreationDto.Email + " " + userCreationDto.Name + " " + userCreationDto.Password);
            UserDto? user = await _usersProvider.Register(userCreationDto);
            return authManager.Login(user).IsAuthorized();
        }

        public async Task<bool> DeleteUser(AuthManager authManager)
        {
            if (!authManager.IsAuthorized())
            {
                return false;
            }
            bool result = await _usersProvider.DeleteUser(authManager.GetUser().Id);

            if (result)
            {
                authManager.Logout();
            }

            return result;
        }

        public async Task<bool> UpdateUser(AuthManager authManager, string name, string email, string password)
        {
            if (!authManager.IsAuthorized())
            {
                return false;
            }
            UserUpdateDto userUpdateDto = new UserUpdateDto{Id = authManager.GetUser().Id, Email = email, Name = name, Password = password};
            UserDto? result = await _usersProvider.UpdateUser(userUpdateDto);
            return authManager.Login(result).IsAuthorized();
        }
    }
}
