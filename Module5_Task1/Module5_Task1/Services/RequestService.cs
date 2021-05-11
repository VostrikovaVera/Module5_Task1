using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Module5_Task1.Contracts.Responses;
using Module5_Task1.Services.Interfaces;
using Newtonsoft.Json;

namespace Module5_Task1.Services
{
    public class RequestService : IRequestService
    {
        private readonly ILoggerService _loggerService;

        public RequestService()
        {
            _loggerService = LocatorService.LoggerService;
        }

        public async Task<TResponse> SendAsync<TResponse>(object payload, string requestUri, HttpMethod httpMethod)
            where TResponse : class
        {
            using (var httpClient = new HttpClient())
            {
                var httpContent = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                var httpMessage = new HttpRequestMessage();
                httpMessage.Content = httpContent;
                httpMessage.RequestUri = new Uri(requestUri);
                httpMessage.Method = httpMethod;

                var result = await httpClient.SendAsync(httpMessage);

                if (result.IsSuccessStatusCode)
                {
                    var content = await result.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<TResponse>(content);

                    return response;
                }
                else
                {
                    _loggerService.LogToConsole($"Response has status code '{result.StatusCode}'");

                    return null;
                }
            }
        }
    }
}
