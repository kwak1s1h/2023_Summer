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
            for (int i = 0; i < host.AddressList.Length; i++)   // IP����� �迭 ������
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {           // IP�迭(Family)���� ����IPv4 �ּҸ� ����
                    ServerIP.Text = host.AddressList[i].ToString(); // �ع�1�� ���� ip�ּ� �Է�
                    break;  // for�� ���
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));  // ��⽺���� ����
            th.IsBackground = true;
            th.Start(); // ��⽺���� ����
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_listener != null)
            {
                _listener.Stop();
                _listener = null;
            }
        }

        private void AcceptClient() // Ŭ�� ���� ��û ��� ���
        {
            // ��� ������
            while (true)
            {
                TcpClient tcpClient = _listener.AcceptTcpClient();

                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    this.Invoke(() => {
                        ClientListBox.Items.Add(str);    // ����Ʈ�ڽ��� ���� Ŭ�� IP ǥ��
                    });
                }

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));    // ������ �ȿ� ������ ����
                th.IsBackground = true;
                th.Start();
            }
        }
    }
}