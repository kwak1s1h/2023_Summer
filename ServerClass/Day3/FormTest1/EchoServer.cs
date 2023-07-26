using System.Net.Sockets;

namespace FormTest1
{
    public class EchoServer
    {
        TcpClient RefClient;
        private BinaryWriter bw = null;
        private BinaryReader br = null;
        int intValue;
        float floatValue;
        string strValue;

        public EchoServer(TcpClient Client) // 생성자에 클라이언트 객체
        {
            RefClient = Client;
        }
        public void Process()   // 데이터를 받는 스레드에 사용
        {
            NetworkStream ns = RefClient.GetStream();
            try
            {
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);

                while (true)
                {
                    intValue = br.ReadInt32();
                    floatValue = br.ReadSingle();
                    strValue = br.ReadString();

                    bw.Write(intValue);
                    bw.Write(floatValue);
                    bw.Write(strValue);
                }
            }
            catch (SocketException se)   // 인터럽트 예외처리
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                MessageBox.Show(se.Message);
                Thread.CurrentThread.Interrupt();
            }
            catch (IOException ex)  // 연결 끊어짐 예외 처리
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                RefClient.Close();
                Thread.CurrentThread.Interrupt();
            }
        }
    }
}