using System;

namespace consoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = "https://jsonplaceholder.typicode.com/users";
            // var path = @"C:\Users\Denaldi\Documents\jon\other\log-output";
            var path = @"C:\Users\Public\Desktop";
            var decode = new DecodeLocal(new DecodeLogger(), new ByteTaskHandler(), new Request());
            decode.DecodeVideo(uri, path);   
        }
    }
}
