using System.Net.Http;
using System.Threading.Tasks;

namespace Module5_Task1.Services.Interfaces
{
    public interface IRequestService
    {
        public Task<TResponse> SendAsync<TResponse>(object payload, string requestUri, HttpMethod httpMethod)
            where TResponse : class;
    }
}
