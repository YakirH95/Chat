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

            Socket serverConnection = ConnectToServer();
            Console.WriteLine("Socket connected to {0}",serverConnection.RemoteEndPoint.ToString());

            Communication(serverConnection);


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

        void Communication(Socket serverConnection)
        {

            while (true)
            {
                byte[] bytes = new byte[1024];

                // Encode the data string into a byte array. 
                Console.WriteLine("Enter your message");
                byte[] msg = Encoding.ASCII.GetBytes(Console.ReadLine());

                // Send the data through the socket.    
                int bytesSent = serverConnection.Send(msg);

                // Receive the response from the remote device.    
                //int bytesRec = serverConnection.Receive(bytes);
               // Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, bytesRec));
            }
        }
    }
}