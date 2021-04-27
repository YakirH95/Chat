using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;



namespace Client
{
    class Client
    {
        public void Start()
        {
            Socket serverConnection = ConnectToServer();
            Console.WriteLine("Socket connected to {0}",serverConnection.RemoteEndPoint.ToString());
            
            Thread recieveThread = new Thread(() => CommunicationReciever(serverConnection));
            recieveThread.Start();

            CommunicationSender(serverConnection);

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

        void CommunicationSender(Socket serverConnection)
        {
            Console.WriteLine("Enter your message");

            while (true)
            {
                // Encode the data string into a byte array. 
                byte[] msg = Encoding.ASCII.GetBytes(Console.ReadLine());

                // Send the data through the socket.    
                int bytesSent = serverConnection.Send(msg);
            }
        }

        void CommunicationReciever(Socket serverConnection)
        {
            byte[] bytes = null;
            while (true)
            {
                // Incoming data from the server.    
                string data = null;
                bytes = new byte[1024];

                int bytesRec = serverConnection.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                Console.WriteLine("Text received from server : {0}", data);
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
    }
}