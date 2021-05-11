﻿using System.Collections.Generic;
using Module5_Task1.Contracts.Dto;
using Newtonsoft.Json;

namespace Module5_Task1.Contracts.Responses
{
    public class UsersListResponse : ListDto
    {
        public List<UserDto> Data { get; set; }

        public SupportDto Support { get; set; }
    }
}
