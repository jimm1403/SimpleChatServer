using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;


namespace ChatServer
{
    class ClientHandler
    {
        Thread clientThread;
        TcpClient newClient;

        NetworkStream netStream;
        StreamReader sr;
        StreamWriter sw;

        public ClientHandler(TcpClient newClient)
        {
            this.newClient = newClient;
            netStream = newClient.GetStream();
            sr = new StreamReader(netStream);
            sw = new StreamWriter(netStream);
            StartClient();
        }

        public void StartClient()
        {
            clientThread = new Thread(HandelClient);
            clientThread.Start();
        }
        
        public void HandelClient()
        {
            string text;
            while (true)
            {
                text = sr.ReadLine();
                Console.WriteLine(text);
                Broadcast.BroadcastToClients(text);
            }
        }
        public void SendToClient(string messageToClient)
        {
            sw.WriteLine(messageToClient);
            sw.Flush();
         
        }
    }
}
