using BlazorApp2.Data.Dtos;
using Newtonsoft.Json;

namespace BlazorApp2.Services
{
    public class UsersProvider : IUsersProvider
    {
        private readonly HttpClient _httpClient;

        public UsersProvider(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<UserDto> Login(UserLoginDto userLoginDto)
        {
            string data = JsonConvert.SerializeObject(userLoginDto);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Users/login", httpContent);
            var asd = response.Content.ReadAsStringAsync().Result;
            UserDto? user = JsonConvert.DeserializeObject<UserDto>(asd);
            return user;
        }

        public async Task<UserDto?> Register(UserCreationDto userCreationDto)
        {
            string data = JsonConvert.SerializeObject(userCreationDto);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Users", httpContent);
            var result = response.Content.ReadAsStringAsync().Result;
            Console.Out.WriteLine("reg got result: " + result);
            UserDto? user = JsonConvert.DeserializeObject<UserDto>(result);
            return await Task.FromResult(user);
        }

        public async Task<UserDto?> UpdateUser(UserUpdateDto userDto)
        {
            string data = JsonConvert.SerializeObject(userDto);
            StringContent httpContent = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Users", httpContent);
            UserDto? user = JsonConvert.DeserializeObject<UserDto?>(response.Content.ReadAsStringAsync().Result);
            return await Task.FromResult(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var delete = await _httpClient.DeleteAsync($"/api/Users/${id}");
            return await Task.FromResult(delete.IsSuccessStatusCode);
        }
    }
}
