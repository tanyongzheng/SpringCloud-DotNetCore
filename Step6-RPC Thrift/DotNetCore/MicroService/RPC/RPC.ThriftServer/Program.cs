using System;

namespace RPC.ThriftServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.StartMultiplexed();
            Console.ReadKey();
        }
    }
}
