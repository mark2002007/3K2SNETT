using System;
using static System.Console;

namespace _5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomWeatherApi api = new CustomWeatherApi(new CustomFileLogger());
            api.GetData(); 
            Thread.Sleep(3000);
            api.GetData(); 
            Thread.Sleep(2000);
            api.GetData(); 
            Thread.Sleep(1000);
        }   
    }
}