using Newtonsoft.Json;

namespace Module5_Task1.Contracts.Dto
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        public string Avatar { get; set; }
    }
}
