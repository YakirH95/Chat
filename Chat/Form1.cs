using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Chat
{
    public partial class Form1 : Form
    {
        Client client = new Client();
        bool clientConnected;

        public delegate void AddTextDelegate(String text);

        public Form1()
        {
            InitializeComponent();
            clientConnected = false;
        }

        private void chatBox_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void connectToServer_Click(object sender, EventArgs e)
        {
            client.Connect(new AddTextDelegate(AddText));
            clientConnected = true;
        }

        private void typeBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            if (!clientConnected)
            {
                MessageBox.Show("Must connect first");
                return;
            }

            String message_to_send = typeBox.Text;
            client.SendMessage(message_to_send);

            AddText("Me: " + message_to_send + Environment.NewLine);
        }

        public void AddText(String text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddText), new object[] { text });
                return;
            }

            chatBox.AppendText(text);
        }

    }
}