using System.Net;
using System.Net.Sockets;

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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listener = new TcpListener(3000);
            _listener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for (int i = 0; i < host.AddressList.Length; i++)
            {
                if (host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ServerIP.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            _client = _listener.AcceptTcpClient();
            if (_client.Connected)
            {
                ConnectIP.Text = ((IPEndPoint)_client.Client.RemoteEndPoint).Address.ToString();
            }
            _netStream = _client.GetStream();
            _writer = new BinaryWriter(_netStream);
            _reader = new BinaryReader(_netStream);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            while (true)
            {
                if (_client.Connected)
                {
                    if (DataReceive() == -1)
                    {
                        break;
                    }
                    DataSend();
                }
                else
                {
                    AllClose();
                    break;
                }
            }
            AllClose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AllClose();
            _listener.Stop();
        }

        private int DataReceive()
        {
            _iValue = _reader.ReadInt32();
            if(_iValue == -1)
            {
                return _iValue;
            }
            _fValue = _reader.ReadSingle();
            _str = _reader.ReadString();

            string msg = _iValue + "/" + _fValue + "/" + _str;
            MessageBox.Show(msg);
            return 0;
        }

        private void DataSend()
        {
            _writer.Write(_iValue);
            _writer.Write(_fValue);
            _writer.Write(_str);
            MessageBox.Show("Àü¼ÛµÊ");
        }

        private void AllClose()
        {
            if(_writer != null)
            {
                _writer.Close();
                _writer = null;
            }

            if (_reader != null)
            {
                _reader.Close();
                _reader = null;
            }

            if (_netStream != null)
            {
                _netStream.Close();
                _netStream = null;
            }

            if (_client != null)
            {
                _client.Close();
                _client = null;
            }
        }
    }
}