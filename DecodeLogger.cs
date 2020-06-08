using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace consoleTest
{
    class DecodeLogger : ILogger
    {

        private StreamWriter writer;
        private StreamReader reader;
        private DateTime currentTime;

        public void Log(string log)
        {
            System.Console.WriteLine(log);
        }

        public void Log(string log, string path)
        {
            if (!File.Exists(FileName(path)))
            {
                WriteLogToNewFile(log, path);
            }
            else
            {
                OverrideLogFile(log, FileName(path));
            }
        }

        private void WriteLogToNewFile(string log, string path)
        {
            using (Process configTool = new Process())
            {
                configTool.StartInfo.FileName = "consoleTest.exe";
                configTool.StartInfo.Arguments = "--bar";
                configTool.StartInfo.Verb = "runas";
                configTool.Start();
                configTool.WaitForExit();
            using (writer = new StreamWriter(path))
            {
                writer.WriteAsync(log);
            }
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
            return path+currentTime.ToString();
        }
    }
}
