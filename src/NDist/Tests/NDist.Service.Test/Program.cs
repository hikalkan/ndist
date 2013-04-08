using System;
using Hik.NDist.Startup;

namespace NDist.Service.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var service = new NDistRunner())
            {
                service.Start();

                Console.WriteLine("NDist service has stared. Press enter to stop.");
                Console.ReadLine();
            }
        }
    }
}
