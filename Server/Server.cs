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
        public void Start()
        {
            Socket clientConnection = ListenForConnection();


            Thread sendThread = new Thread(() => CommunicationSender(clientConnection));
            sendThread.Start();
            CommunicationReciever(clientConnection);


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

            return clientConnection;
        }

        void CommunicationReciever(Socket clientConnection)
        {
            // Incoming data from the client.    
            byte[] bytes = null;

            while (true)
            {
                string data = null;
                bytes = new byte[1024];

                int bytesRec = clientConnection.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Text received from client : {0}", data);

                if (data != null)
                {
                    Console.WriteLine("Enter your message");
                }
                if (data.IndexOf("exit") > -1)
                {
                    break;
                }
            }
        }

        void CommunicationSender(Socket clientConnection)
        {
            Console.WriteLine("Enter your message");

            while (true)
            {
                // Encode the data string into a byte array. 
                byte[] msg = Encoding.ASCII.GetBytes(Console.ReadLine());

                // Send the data through the socket.    
                int bytesSent = clientConnection.Send(msg);
            }
        }
    }
}