using System.IO;

namespace consoleTest
{
    class DecodeLocal : IDecode
    {
        private readonly ILogger logger;
        private readonly ITaskHandler taskHandler;
        private readonly IRequest request;
        private StreamReader reader;

        public DecodeLocal(){
        }

        public DecodeLocal(ILogger logger, ITaskHandler taskHandler, IRequest request)
        {
            this.logger = logger;
            this.taskHandler = taskHandler;
            this.request = request;
        }

        public void DecodeVideo(string uri)
        {
            logger.Log("Decoding...");
            reader = new StreamReader(taskHandler.HandleTask(request.RequestByteTask(uri)));
            logger.Log(reader.ReadToEnd());
        }

        public void DecodeVideo(string uri, string path)
        {
            logger.Log("Decoding...");
            reader = new StreamReader(taskHandler.HandleTask(request.RequestByteTask(uri)));
            logger.Log(reader.ReadToEnd(), path);
        }
    }
}
