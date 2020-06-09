using System;
using System.IO;

namespace consoleTest
{
    class DecodeLogger : ILogger
    {
        private StreamWriter writer;
        private StreamReader reader;
        private DateTime currentTime;
        private string fileName;

        public void Log(string log)
        {
            System.Console.WriteLine(log);
        }

        public void Log(string log, string path)
        {
            fileName = FileName(path);
            if (!File.Exists(fileName))
            {
                WriteLogToNewFile(log, fileName);
            }
            else
            {
                OverrideLogFile(log, FileName(path));
            }
        }

        private async void WriteLogToNewFile(string log, string path)
        {
            using (writer = new StreamWriter(path))
            {
                await writer.WriteAsync(log);
            }
        }

        private void OverrideLogFile(string log, string path)
        {
            using (reader = File.OpenText(path))
            {
                string s;
                while ((s = reader.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
        }

        public string FileName(string path)
        {
            currentTime = DateTime.Now;
            // System.Console.WriteLine(path+@"\log-"+currentTime.ToString().Replace(@"/", "-").Replace(" ","-")+".txt");
            return path+@"\log-"+currentTime.ToString().Replace(@"/", "-").Replace(" ","-").Replace(":","-")+".txt";
        }
    }
}
