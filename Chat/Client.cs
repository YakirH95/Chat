using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Chat
{
    class Client
    {
        Socket serverConnection;

        public void Connect(Delegate addTextMethod)
        {
            serverConnection = ConnectToServer();

            Thread recieveThread = new Thread(() => CommunicationReciever(addTextMethod));
            recieveThread.Start();
        }

        public void Close()
        {
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

        public void SendMessage(String message)
        {
            // Encode the data string into a byte array. 
            byte[] msg = Encoding.ASCII.GetBytes(message);

            // Send the data through the socket.    
            int bytesSent = serverConnection.Send(msg);
        }

        void CommunicationReciever(Delegate addTextMethod)
        {
            byte[] bytes = null;
            while (true)
            {
                // Incoming data from the server.    
                bytes = new byte[1024];

                int bytesRec = serverConnection.Receive(bytes);
                String data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                addTextMethod.DynamicInvoke(data + Environment.NewLine);
            }
        }
    }
}
