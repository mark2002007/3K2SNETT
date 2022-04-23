using System;
using System.IO;
namespace _5
{
    public interface ICustomLogger
    {
        void Log(string message);
    }
    
    public class CustomFileLogger : ICustomLogger
    {
        string path = "log.txt";

        public void Log(string message)
        {
            if(!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(message);
            }
        }
    }
}