using Newtonsoft.Json;

namespace Module5_Task1.Contracts.Dto
{
    public class ResourceDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public string Color { get; set; }

        [JsonProperty("pantone_value")]
        public string PantoneValue { get; set; }
    }
}
