using System;
using Microsoft.Owin.Hosting;

namespace Glimpse.Owin.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(1337))
            {
                Console.WriteLine("Started at http://localhost:1337/");
                Console.ReadLine();
                Console.WriteLine("Stopping");
            }
        }
    }
}