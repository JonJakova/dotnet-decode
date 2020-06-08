namespace consoleTest
{
    interface ILogger
    {
        void Log(string log);

        void Log(string log, string path);

        string FileName(string path);
    }
}