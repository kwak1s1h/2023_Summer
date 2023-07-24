using System.Net.Sockets;
using System.Text;

namespace TcpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            TcpClient tcpClient = new TcpClient("localhost", 7);
            if (tcpClient.Connected)
            {
                Console.WriteLine("연결 성공");
                NetworkStream netStream = tcpClient.GetStream();
                string msg = "Hello Server!";
                byte[] sendMsg = Encoding.ASCII.GetBytes(msg);
                netStream.Write(sendMsg, 0, sendMsg.Length);

                byte[] receiveByte = new byte[1024];
                netStream.Read(receiveByte, 0, receiveByte.Length);
                string receiveMsg = Encoding.ASCII.GetString(receiveByte);
                Console.WriteLine(receiveMsg);
                netStream.Close();
            }
        }
    }
}
