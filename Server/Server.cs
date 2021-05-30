using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        List<Socket> clients;

        public Server()
        {
            clients = new List<Socket>();
        }

        public void Start()
        {
            Socket listener = ListenForConnection();

            while (true)
            {
                Socket newClient = listener.Accept();
                Console.WriteLine("connected");
                clients.Add(newClient);

                Thread BtoA = new Thread(() => bytesSender(newClient));
                BtoA.Start();
            }
        }

        Socket ListenForConnection()
        {
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5678);

            // Create a Socket that will use Tcp protocol      
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // A Socket must be associated with an endpoint using the Bind method  
            listener.Bind(localEndPoint);
            // Specify how many requests a Socket can listen before it gives Server busy response.  
            // We will listen 10 requests at a time  
            listener.Listen(1);
            return listener;
        }

        void bytesSender(Socket sender)
        {
            byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRecieved = sender.Receive(bytes);

                Array.Resize(ref bytes, bytesRecieved);

                foreach (Socket client in clients)
                {
                    if (sender != client)
                    {
                        client.Send(bytes);
                    }
                }
            }
        }
    }
}