using System.Net.Sockets;
using System.Text;

namespace TcpClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 7);
            if(client.Connected)
            {
                NetworkStream netStream = client.GetStream();
                while(true)
                {
                    try
                    {
                        string msg = Console.ReadLine();
                        byte[] buffer = Encoding.ASCII.GetBytes(msg);
                        netStream.Write(buffer, 0, buffer.Length);

                        byte[] readBytes = new byte[1024];
                        int read = netStream.Read(readBytes, 0, readBytes.Length);
                        if(read <= 0)
                        {
                            break;
                        }
                        Console.WriteLine("받음 : " + Encoding.ASCII.GetString(readBytes));
                    }
                    catch
                    {
                        break;
                    }
                }
                netStream.Close();
                client.Close();
            }
        }
    }
}