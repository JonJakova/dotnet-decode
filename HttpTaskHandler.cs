using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace consoleTest
{
    class HttpTaskHandler : ITaskHandler
    {
        private Task<HttpResponseMessage> httpResponseMessageTask;
        private Stream streamAsTask;
        private HttpResponseMessage httpResponseMessage;

        public Stream HandleTask(Task responseTask)
        {
            httpResponseMessageTask = (Task<HttpResponseMessage>) responseTask; 
            ConvertTaskToResponse(httpResponseMessageTask);
            return streamAsTask;
        }

        private void ConvertTaskToResponse(Task<HttpResponseMessage> httpResponseTask)
        {
            this.httpResponseMessage = httpResponseTask.Result;
            ConvertResponseToStream(this.httpResponseMessage);
        }

        private async void ConvertResponseToStream(HttpResponseMessage responseMessage){
             this.streamAsTask = await responseMessage.Content.ReadAsStreamAsync();
        }
    }
}
