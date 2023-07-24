using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConnectClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            //TcpListener tcpListener = new TcpListener(ip, 13);
            //Console.WriteLine("{0}", tcpListener.LocalEndpoint.ToString());

            //TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7);
            //tcpListener.Start();
            //Console.WriteLine("대기 상태 시작");
            //TcpClient tcpClient = tcpListener.AcceptTcpClient();
            //Console.WriteLine("대기 상태 종료");
            //tcpListener.Stop();

            TcpListener tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7);
            tcpListener.Start();
            Console.WriteLine("대기 상태 시작");
            TcpClient tcpClient = tcpListener.AcceptTcpClient();
            NetworkStream netStream = tcpClient.GetStream();
            byte[] receiveMsg = new byte[1024];
            netStream.Read(receiveMsg, 0, receiveMsg.Length);
            string strMsg = Encoding.ASCII.GetString(receiveMsg);
            Console.WriteLine(strMsg);

            string echoMsg = "Hello World!";
            byte[] sendMsg = Encoding.ASCII.GetBytes(echoMsg);
            netStream.Write(sendMsg, 0, sendMsg.Length);
            netStream.Close();
            tcpClient.Close();
            tcpListener.Stop();
        }
    }
}