using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Module5_Task1.Configs;
using Module5_Task1.Contracts.Requests;
using Module5_Task1.Contracts.Responses;
using Module5_Task1.Services;
using Module5_Task1.Services.Interfaces;

namespace Module5_Task1
{
    public class Starter
    {
        private readonly IRequestService _requestService;
        private readonly ApiConfig _apiConfig;
        private readonly string _baseUrl;

        public Starter()
        {
            _requestService = LocatorService.RequestService;

            var config = LocatorService.ConfigService;
            _apiConfig = config.ApiConfig;
            _baseUrl = _apiConfig.BaseUrl;
        }

        public void Run()
        {
            var list = new List<Task>();

            list.Add(Task.Run(async () => await _requestService.SendAsync<UsersListResponse>(null, $"{_baseUrl}/users?page=2", HttpMethod.Get)));
            list.Add(Task.Run(async () => await _requestService.SendAsync<UserResponse>(null, $"{_baseUrl}/users/2", HttpMethod.Get)));
            list.Add(Task.Run(async () => await _requestService.SendAsync<UserResponse>(null, $"{_baseUrl}/users/23", HttpMethod.Get)));
            list.Add(Task.Run(async () => await _requestService.SendAsync<ResourcesListResponse>(null, $"{_baseUrl}/unknown", HttpMethod.Get)));
            list.Add(Task.Run(async () => await _requestService.SendAsync<ResourceResponse>(null, $"{_baseUrl}/unknown/2", HttpMethod.Get)));
            list.Add(Task.Run(async () => await _requestService.SendAsync<ResourceResponse>(null, $"{_baseUrl}/unknown/23", HttpMethod.Get)));
            list.Add(Task.Run(async () =>
            {
                var createUserPayload = new CreateUpdateUserRequest()
                {
                    Name = "morpheus",
                    Job = "leader"
                };
                await _requestService.SendAsync<CreateUserResponse>(createUserPayload, $"{_baseUrl}/users", HttpMethod.Post);
            }));
            list.Add(Task.Run(async () =>
            {
                var updateUserPayload = new CreateUpdateUserRequest()
                {
                    Name = "morpheus",
                    Job = "zion resident"
                };
                await _requestService.SendAsync<UpdateUserResponse>(updateUserPayload, $"{_baseUrl}/users/2", HttpMethod.Put);
            }));
            list.Add(Task.Run(async () =>
            {
                var updateUserPayload = new CreateUpdateUserRequest()
                {
                    Name = "morpheus",
                    Job = "zion resident"
                };
                await _requestService.SendAsync<UpdateUserResponse>(updateUserPayload, $"{_baseUrl}/users/2", HttpMethod.Patch);
            }));
            list.Add(Task.Run(async () => await _requestService.SendAsync<DeleteUserResponse>(null, $"{_baseUrl}/users/2", HttpMethod.Delete)));
            list.Add(Task.Run(async () => await _requestService.SendAsync<DeleteUserResponse>(null, $"{_baseUrl}/users/2", HttpMethod.Delete)));
            list.Add(Task.Run(async () =>
            {
                var registerPayloadFirst = new AuthRequest()
                {
                    Email = "eve.holt@reqres.in",
                    Password = "pistol"
                };
                await _requestService.SendAsync<RegisterResponse>(registerPayloadFirst, $"{_baseUrl}/register", HttpMethod.Post);
            }));
            list.Add(Task.Run(async () =>
            {
                var registerPayloadSecond = new AuthRequest()
                {
                    Email = "sydney@fife"
                };
                await _requestService.SendAsync<RegisterResponse>(registerPayloadSecond, $"{_baseUrl}/register", HttpMethod.Post);
            }));
            list.Add(Task.Run(async () =>
            {
                var loginPayloadFirst = new AuthRequest()
                {
                    Email = "eve.holt@reqres.in",
                    Password = "cityslicka"
                };
                await _requestService.SendAsync<LoginResponse>(loginPayloadFirst, $"{_baseUrl}/login", HttpMethod.Post);
            }));
            list.Add(Task.Run(async () =>
            {
                var loginPayloadSecond = new AuthRequest()
                {
                    Email = "peter@klaven"
                };
                await _requestService.SendAsync<LoginResponse>(loginPayloadSecond, $"{_baseUrl}/login", HttpMethod.Post);
            }));
            list.Add(Task.Run(async () => await _requestService.SendAsync<UsersListResponse>(null, $"{_baseUrl}/users?delay=3", HttpMethod.Get)));

            Task.WhenAll(list).GetAwaiter().GetResult();

            Console.WriteLine("Requests are done");
        }
    }
}
