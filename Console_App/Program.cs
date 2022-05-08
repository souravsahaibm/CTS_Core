using System;
using Newtonsoft.Json;
namespace CORE_CTS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(JsonConvert.SerializeObject(args));
        }
    }
}
