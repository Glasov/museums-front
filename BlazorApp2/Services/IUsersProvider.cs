using BlazorApp2.Data.Dtos;

namespace BlazorApp2.Services;

public interface IUsersProvider
{
    Task<UserDto?> Register(UserCreationDto userCreationDto);
    Task<UserDto?> Login(UserLoginDto userLoginDto);
    Task<UserDto?> UpdateUser(UserUpdateDto userUpdateDto);
    Task<bool> DeleteUser(int id);
}
