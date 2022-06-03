using BlazorApp2.Data.Dtos;

namespace BlazorApp2.Managers;

public class AuthManager
{
    private UserDto? _user;

    public AuthManager()
    {
        _user = null;
    }
    
    public void Logout()
    {
        _user = null;
    }
    
    public bool IsAuthorized()
    {
        return _user != null;
    }

    public bool IsAdmin()
    {
        return IsAuthorized() && _user.IsAdmin;
    }
    
    public UserDto? GetUser()
    {
        return _user;
    }

    public AuthManager Login(UserDto? userDto)
    {
        _user = userDto;
        return this;
    }
}