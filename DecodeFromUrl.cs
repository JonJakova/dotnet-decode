using System.IO;
using System.Threading.Tasks;

namespace consoleTest
{
    class DecodeFromUrl : IDecode
    {
        private readonly ILogger logger;
        private readonly ITaskHandler handler;
        private readonly IRequest request;
        private StreamReader reader;

        public DecodeFromUrl(ILogger logger)
        {
            this.logger = logger;
        }

        public DecodeFromUrl(ILogger logger, ITaskHandler handler, IRequest request)
        {
            this.logger = logger;
            this.handler = handler;
            this.request = request;
        }

        public void DecodeVideo(string uri="")
        {
            logger.Log("Decoding...");
            reader = new StreamReader(handler.HandleTask(request.RequestHttpResponseMessageTask(uri)));
            logger.Log(reader.ReadToEnd());
        }

        public void DecodeVideo(string uri, string path)
        {
           
        }
    }
}
