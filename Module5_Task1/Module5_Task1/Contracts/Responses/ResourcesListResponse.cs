using System.Collections.Generic;
using Module5_Task1.Contracts.Dto;

namespace Module5_Task1.Contracts.Responses
{
    public class ResourcesListResponse : ListDto
    {
        public List<ResourceDto> Data { get; set; }

        public SupportDto Support { get; set; }
    }
}
