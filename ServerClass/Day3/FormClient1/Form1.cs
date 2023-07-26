using System.Net.Sockets;

namespace FormClient1
{
    public partial class Form1 : Form
    {
        private TcpClient _client;
        private NetworkStream _netStream;
        private BinaryReader _reader;
        private BinaryWriter _writer;

        private int _iValue;
        private float _fValue;
        private string _str;

        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            _client = new TcpClient(ServerIP.Text, 3000);
            if (_client.Connected)
            {
                _netStream = _client.GetStream();
                _reader = new BinaryReader(_netStream);
                _writer = new BinaryWriter(_netStream);
                MessageBox.Show("立加 己傍");
            }
            else
            {
                MessageBox.Show("立加 角菩");
            }
        }

        private void Send_Click(object sender, EventArgs e)
        {
            _writer.Write(int.Parse(IntValue.Text));
            _writer.Write(float.Parse(FloatValue.Text));
            _writer.Write(StringValue.Text);

            _iValue = _reader.ReadInt32();
            _fValue = _reader.ReadSingle();
            _str = _reader.ReadString();

            string msg = _iValue + "/" + _fValue + "/" + _str;
            MessageBox.Show(msg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _writer.Write(-1);
            _writer.Close();
            _reader.Close();
            _netStream.Close();
            _client.Close();
        }
    }
}