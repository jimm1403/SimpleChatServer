using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace ChatServer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.Run();
        }
        public void Run()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 11000);
            listener.Start();
            TcpClient tempClient;
            ClientHandler clienthandler;
            while (true)
            {
                tempClient = listener.AcceptTcpClient();
                Console.WriteLine("Client Connected");
                clienthandler = new ClientHandler(tempClient);
                Broadcast.addClientToList(clienthandler);
            }
        }
    }
}
