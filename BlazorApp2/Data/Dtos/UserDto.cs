using Newtonsoft.Json;

namespace BlazorApp2.Data.Dtos
{
    public class UserDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("registrationTimestamp")]
        public long RegistrationTimestamp { get; set; }
        [JsonProperty("orderIds")]
        public int[] OrderIds { get; set; }
        [JsonProperty("isAdmin")]
        public bool IsAdmin { get; set; }
    }
}
