using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Server
    {
        public void Start()
        {
            Socket clientConnection = ListenForConnection();

            byte[] message = Encoding.ASCII.GetBytes("Connected");
            clientConnection.Send(message);
            clientConnection.Shutdown(SocketShutdown.Both);
            clientConnection.Close();
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
            listener.Listen(10);

            Console.WriteLine("Waiting for a connection...");
            Socket clientConnection = listener.Accept();
            Console.WriteLine("Client connected");
            // Incoming data from the client.    
            string data = null;
            byte[] bytes = null;

            while (true)
            {
                bytes = new byte[1024];
                int bytesRec = clientConnection.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Text received : {0}", data);

                if (data.IndexOf("<EOF>") > -1)
                {
                    break;
                }
            }


            byte[] msg = Encoding.ASCII.GetBytes(data);
            clientConnection.Send(msg);

            return clientConnection;
        }

        void Communication()
        {

        }
    }
}