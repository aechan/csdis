using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NetCoreServer;

namespace CSDis
{
    class DBSession : TcpSession
    {
        private ProtocolHandler _protocol;
        public DBSession(TcpServer server) : base(server) {
            _protocol = new ProtocolHandler();
        }

        protected override void OnConnected()
        {
            Console.WriteLine($"[INFO] Session with Id {Id} connected");
        }
        protected override void OnDisconnected()
        {
            Console.WriteLine($"[INFO] Session with Id {Id} disconnected");
        }

        protected override void OnReceived(byte[] buffer, long offset, long size)
        {
            _protocol.ParseMessage(buffer);
        }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP session caught an error with code {error}");
        }
    }
    class Server : TcpServer
    {
        public Server(IPAddress address, int port) : base(address, port) {}

        protected override TcpSession CreateSession() { return new DBSession(this); }

        protected override void OnError(SocketError error)
        {
            Console.WriteLine($"Chat TCP server caught an error with code {error}");
        }
    }
}
