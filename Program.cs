using System;
using System.Threading;
using System.Net;
namespace CSDis
{
    class Program
    {
        private static Server server;
        private static IPAddress ip;
        private static int port;
        static void Main(string[] args)
        {
            ip = IPAddress.Loopback;
            port = 10001;
            Client client = new Client(ip, port);
            Console.CancelKeyPress += delegate {
                server.Shutdown();
                client.Shutdown();
            };
            Thread sThread = new Thread(() => {
                server = new Server();
                server.Start(ip, port);
            });
            
            sThread.Start();
            client.Connect();
            
            while (true) {
                string key;
                string val;
                string cmd;
                Console.Write("Command: ");
                cmd = Console.ReadLine();
                Console.Write("Key: ");
                key = Console.ReadLine();
                Console.Write("Val: ");
                val = Console.ReadLine();

                CommandType ct;
                cmd = cmd.ToLower();
                if (cmd == "get") {
                    ct = CommandType.GET;
                } else if (cmd == "set") {
                    ct = CommandType.SET;
                } else if (cmd == "delete") {
                    ct = CommandType.DELETE;
                } else if (cmd == "flush") {
                    ct = CommandType.FLUSH;
                } else if (cmd == "mget") {
                    ct = CommandType.MGET;
                } else if (cmd == "mset") {
                    ct = CommandType.MSET;
                } else {
                    ct = CommandType.INVALID;
                }

                if (ct == CommandType.INVALID) {
                    Console.WriteLine("Invalid command type.");
                    continue;
                }

                client.SendData(ct, key, val);
            }
        }
    }
}
