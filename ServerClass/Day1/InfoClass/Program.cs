using System.Net;

namespace InfoClass
{
    class Program
    {
        static void Main(string[] args)
        {
            string address = Console.ReadLine();
            IPAddress ip = IPAddress.Parse(address);
            Console.WriteLine("ip: {0}", ip.ToString());

            Console.Clear();

            IPAddress[] ips = Dns.GetHostAddresses("naver.com");
            foreach(IPAddress iP in ips)
            {
                Console.WriteLine("{0}", iP);
            }

            Console.Clear();

            IPHostEntry hostInfo = Dns.GetHostEntry("naver.com");
        }
    }
}