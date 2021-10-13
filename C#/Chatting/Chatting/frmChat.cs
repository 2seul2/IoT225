using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chatting
{
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }
        /// <summary>
        /// delegate와 Invoke 대리호출 함수 방식을 대체하여
        /// Timer를 이용하는 방법 예시
        /// 전역변수 strText를 이용하여 쓰레드 함수에서 기록한 내용을
        /// Timer 가 TextBox에 출력
        /// </summary>
        //string strText = "";
        //void AddText(string str)      //  
        //{
        //    strText += str;
        //}

        //private void timer1_Tick(object sender, EventArgs e)  // 일정시간 간격으로 TextBox에 출력
        //{
        //    tbChat.Text += strText;
        //    strText = "";
        //}

        delegate void CB1(string s);
        void AddText(string str)     
        {
            if(tbChat.InvokeRequired)
            {
                CB1 cb = new CB1(AddText);
                object[] obj = { str };
                Invoke(cb, obj);
            }
            else
            {
                tbChat.Text += str;
            }
        }

        class TcpEx
        {
            public TcpClient tp;
            public string id;
            public TcpEx(TcpClient t, string s)
            {
                tp = t;
                id = s; 
            }
        };

        Socket sock = null;
        TcpListener listen = null;
        List<TcpEx> tcp = new List<TcpEx>();  // TcpClient type의 제네릭 List Object 선언
        // TcpClient[] tcp = new TcpClient[10];

        Thread threadServer = null;
        Thread threadread = null;

        int OperationMode = 0;  // 0 : Server Mode,   1 : Client Mode
        string ConnectIP = "127.0.0.1";
        int ConnectPort = 9000;
        int serverPort = 9000;
        iniFile ini = new iniFile(@".\chat.ini");
        private void frmChat_Load(object sender, EventArgs e)
        {
            string test = "\u0003abcdefgh\u0002";
            byte[] bTest = Encoding.Default.GetBytes(test);
            int X = int.Parse(ini.GetString("Location", "X", "0"));
            int Y = int.Parse(ini.GetString("Location", "Y", "0"));
            Location = new Point(X, Y);
            int SX = int.Parse(ini.GetString("Size", "X", "300"));
            int SY = int.Parse(ini.GetString("Size", "Y", "500"));
            int DIST =  int.Parse(ini.GetString("Size", "DIST", "350"));
            Size = new Size(SX, SY);
            splitContainer1.SplitterDistance = DIST;
        }

        /// <summary>
        /// InitServer() : 프로그램의 시작과 동시에 서버 포트를 오픈하고 리스너를 시작
        /// Session Thread와 Read thread를 시작
        /// </summary>
        void InitServer()
        {
            if (listen != null) listen.Stop();  // 기존에 수행되고 있는 리스너를 중지
            listen = new TcpListener(serverPort);
            listen.Start();

            if (threadServer != null) threadServer.Abort();
            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            if (threadread != null) threadread.Abort();
            threadread = new Thread(ReadProcess);
            threadread.Start();

            //timer1.Start();
        }

        void CloseServer()
        {
            //timer1.Stop();
            if (listen != null) listen.Stop();  // 기존에 수행되고 있는 리스너를 중지
            if (threadServer != null) threadServer.Abort();
            if (threadread != null) threadread.Abort();
        }

        void ServerProcess()
        {
            byte[] buf = new byte[100];
            while(true)
            { 
                if(listen.Pending())    // Client로부터 접속요청이 있는가?
                {
                    TcpClient tp = listen.AcceptTcpClient();   //AcceptTcpClient() : Blocking 함수
                    tp.Client.Send(Encoding.Default.GetBytes($"REQ:{tp.Client.RemoteEndPoint.ToString()}"));
                    int n = tp.Client.Receive(buf);
                    string sId = Encoding.Default.GetString(buf,0,n).Split(':')[1];   // NAM:name
                    tcp.Add(new TcpEx(tp,sId));     //     Add : List object의 method
                    AddText($"{sId}({tp.Client.RemoteEndPoint.ToString()})로부터 접속되었습니다.\r\n");
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            byte[] buf = new byte[1024];  // 1K byte
            while(true)
            {
                for(int i=0;i<tcp.Count;i++)  // List object의 크기
                {
                    if(tcp[i].tp.Available > 0)  // List object의 [] operator를 이용하여 배열처럼 관리
                    {
                        tcp[i].tp.Client.Receive(buf);
                        AddText(Encoding.Default.GetString(buf));
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServer();
            if (threadClient != null) threadClient.Abort();

            ini.WriteString("Location", "X", $"{Location.X}");
            ini.WriteString("Location", "Y", $"{Location.Y}");
            ini.WriteString("Size", "X", $"{Size.Width}");
            ini.WriteString("Size", "Y", $"{Size.Height}");
            ini.WriteString("Size", "DIST",$"{splitContainer1.SplitterDistance}" );
        }

        private void pmnuConnect_Click(object sender, EventArgs e)
        {
            if (sock != null)
            {
                if (MessageBox.Show("연결을 다시 수립하시겠습니까?", "", MessageBoxButtons.YesNo) == DialogResult.No) return;
                if (threadClient != null) threadClient.Abort();
                sock.Close();
            }
            byte[] buf = new byte[100];
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sock.Connect(ConnectIP, ConnectPort);
            int n = sock.Receive(buf);
            string myIP = Encoding.Default.GetString(buf, 0, n).Split(':')[1];
            sock.Send(Encoding.Default.GetBytes($"NAM:{tbTalk.Text}"));
            threadClient = new Thread(ClientProcess);
            tbTalk.Text = "";
        }

        Thread threadClient = null;
        void ClientProcess()
        {
            byte[] buf = new byte[1024];
            while(true)
            {
                if(sock.Available > 0)
                {
                    sock.Receive(buf);
                    AddText(Encoding.Default.GetString(buf));
                }
                Thread.Sleep(100);
            }
        }

        private void tbTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                sock.Send(Encoding.Default.GetBytes(tbTalk.Text));
                tbTalk.Text = "";
            }
        }

        private void pmnuServerStart_Click(object sender, EventArgs e)
        {
            InitServer();
            AddText($"Server가 [{serverPort}] port에서 시작되었습니다.\r\n");
        }
    }
}
