using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SendClass
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine(IPAddress.Any);
            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7);
            tcpListener.Start();
            
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream netStream = tcpClient.GetStream();
            
            while(true)
            {
                try
                {
                    byte[] buffer = new byte[1024];
                    netStream.Read(buffer);
                    string msg = Encoding.ASCII.GetString(buffer);
                    Console.WriteLine(msg);
                    netStream.Write(buffer, 0, buffer.Length);
                }
                catch
                {
                    break;
                }
            }
            
            netStream.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}