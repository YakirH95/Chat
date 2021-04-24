using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;



namespace Client
{
    class Client
    {
        public void Start()
        {
            byte[] bytes = new byte[1024];

            Socket serverConnection = ConnectToServer();
            int bytesRec = serverConnection.Receive(bytes);
            Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));

            serverConnection.Shutdown(SocketShutdown.Both);
            serverConnection.Close();
        }

        Socket ConnectToServer()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5678);

            Socket serverConnection = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverConnection.Connect(localEndPoint);

            return serverConnection;
        }

    }
}
