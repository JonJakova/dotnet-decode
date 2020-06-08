using System.IO;
using System.Threading.Tasks;

namespace consoleTest
{
    class ByteTaskHandler : ITaskHandler
    {
        private Task<byte[]> byteArrayTask;
        protected Stream byteStream;

        public Stream HandleTask(Task responseTask)
        {
            byteArrayTask = (Task<byte[]>) responseTask;
            return ConvertTaskToByteArray(byteArrayTask);
        }

        private Stream ConvertTaskToByteArray(Task<byte[]> task){
            var result = task.Result;
            byteStream = new MemoryStream(result);
            return byteStream;
        }

    }
}
