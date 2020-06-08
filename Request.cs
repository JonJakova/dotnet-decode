using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace consoleTest
{
     class Request : IRequest
    {
        protected readonly HttpClient client;

        public Request()
        {
            client = new HttpClient();
        }

        public Task<HttpResponseMessage> RequestHttpResponseMessageTask(string uri)
        {
            return client.GetAsync(uri);
        }

        public async Task<byte[]> RequestByteTask(string uri)
        {
            return await client.GetByteArrayAsync(uri);
        }
        
    }
}
