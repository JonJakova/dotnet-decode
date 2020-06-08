using System.Net.Http;
using System.Threading.Tasks;

namespace consoleTest
{
    interface IRequest
    {
       Task<HttpResponseMessage> RequestHttpResponseMessageTask(string uri);
       Task<byte[]> RequestByteTask(string uri);
    }
}