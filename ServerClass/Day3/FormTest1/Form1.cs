using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormTest1
{
    public partial class Form1 : Form
    {
        private TcpListener _listener;
        private TcpClient _client;
        private BinaryWriter _writer;
        private BinaryReader _reader;
        private NetworkStream _netStream;

        private int _iValue;
        private float _fValue;
        private string _str;

        private object _obj = new object();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listener = new TcpListener(IPAddress.Any, 3000);
            _listener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)   // IP저장된 배열 가져옴
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {           // IP배열(Family)에서 내부IPv4 주소만 구분
                    ServerIP.Text = host.AddressList[i].ToString(); // 텍박1에 서버 ip주소 입력
                    break;  // for문 벗어남
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));  // 대기스레드 생성
            th.IsBackground = true;
            th.Start(); // 대기스레드 시작
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener = null;
            }
        }

        private void AcceptClient() // 클라 연결 요청 계속 대기
        {
            // 대기 스레드
            while (true)
            {
                TcpClient tcpClient = _listener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    this.Invoke(() => {
                        ClientListBox.Items.Add(str);    // 리스트박스에 연결 클라 IP 표시
                    });
                }

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));    // 스레드 안에 스레드 생성
                th.IsBackground = true;
                th.Start();
            }
        }
    }
}