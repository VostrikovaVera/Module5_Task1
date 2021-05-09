﻿using Newtonsoft.Json;

namespace Module5_Task1.Contracts.Dto
{
    public class ListDto
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }

        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
    }
}
