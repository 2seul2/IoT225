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

        void AddList(string str)
        {
            if(statusStrip1.InvokeRequired)
            {
                CB1 cb = new CB1(AddList);
                Invoke(cb, new object[] { str });
            }
            else
            {
                sbConnectList.DropDownItems.Add(str);
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

        bool OperationMode = false;  // false : Server Mode,        true : Client Mode
        string sUID = "Noname";
        string sPWD = "";
        string ConnectIP = "127.0.0.1";
        int ConnectPort = 9000;
        int ServerPort = 9000;
        iniFile ini = new iniFile(@".\chat.ini");
        private void frmChat_Load(object sender, EventArgs e)
        {
            //string test = "\u0003abcdefgh\u0002";
            //byte[] bTest = Encoding.Default.GetBytes(test);
            int X = int.Parse(ini.GetString("Location", "X", "0"));
            int Y = int.Parse(ini.GetString("Location", "Y", "0"));
            Location = new Point(X, Y);
            int SX = int.Parse(ini.GetString("Size", "X", "300"));
            int SY = int.Parse(ini.GetString("Size", "Y", "500"));
            int DIST =  int.Parse(ini.GetString("Size", "DIST", "350"));
            Size = new Size(SX, SY);
            splitContainer1.SplitterDistance = DIST;

            ServerPort = int.Parse(ini.GetString("Operation","ServerPort","9000"));
            ConnectPort = int.Parse(ini.GetString("Operation","ConnectPort","9000"));
            ConnectIP = ini.GetString("Operation", "ConnectIP", "127.0.0.1");
            sUID = ini.GetString("Operation", "UID", "Noname");
            sPWD = ini.GetString("Operation", "PWD", ""); // 실제 적용시에는 암호화 처리 후 저장
        }

        /// <summary>
        /// InitServer() : 프로그램의 시작과 동시에 서버 포트를 오픈하고 리스너를 시작
        /// Session Thread와 Read thread를 시작
        /// </summary>
        void InitServer()
        {
            if (listen != null) listen.Stop();  // 기존에 수행되고 있는 리스너를 중지
            listen = new TcpListener(ServerPort);
            listen.Start();

            if (threadServer != null) threadServer.Abort();
            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            if (threadread != null) threadread.Abort();
            threadread = new Thread(ReadProcess);
            threadread.Start();

            sbConnectList.DropDownItems.Add("모두에게");
            //timer1.Start();
        }

        void CloseServer()
        {
            //timer1.Stop();
            if (listen != null) listen.Stop();  // 기존에 수행되고 있는 리스너를 중지
            if (threadServer != null) threadServer.Abort();
            if (threadread != null) threadread.Abort();
        }

        bool IsAlive(Socket sck)
        {
            if (sck == null) return false;
            if (sck.Connected == false) return false;

            bool b1 = sck.Poll(1000, SelectMode.SelectRead);  // 정상적이면 0 : false  문제있으면 1 : true;
//            bool b2 = sck.Available == 0;    // 정상적이면 true     아니면  false
            if (b1) return false;

            try
            {
                sck.Send(new byte[1], 0, SocketFlags.OutOfBand);
                return true;
            }
            catch
            {
                return false;
            }
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
                    if(sId == "Noname")
                    {
                        tp.Client.Send(Encoding.Default.GetBytes($"REJECT:올바른 사용자가 아닙니다\r\n"));
                        tp.Close();
                    }
                    else
                    {
                        tp.Client.Send(Encoding.Default.GetBytes($"ACCEPT:접속이 허가되었습니다\r\n"));
                        tcp.Add(new TcpEx(tp, sId));     //     Add : List object의 method
                        AddText($"{sId}({tp.Client.RemoteEndPoint.ToString()})로부터 접속되었습니다.\r\n");
                        //sbConnectList.DropDownItems.Add(sId);
                        //AddList(sId);
                        //=================================================
                        // delegate void CB1(string str);
                        //if(statusStrip1.InvokeRequired)
                        //{
                        //    CB1 cb = new CB1(AddList);
                        //    Invoke(cb, new object[] { str });
                        //}
                        //else
                        //{
                        //    sbConnectList.DropDownItems.Add(str);
                        //}
                        if (InvokeRequired)
                        {
                            Invoke(new MethodInvoker(delegate () { sbConnectList.DropDownItems.Add(sId); }));
                        }
                    }
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
                        int n = tcp[i].tp.Client.Receive(buf);
                        AddText(Encoding.Default.GetString(buf, 0, n));
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseServer();
            if (threadClient != null) threadClient.Abort();

            ini.GetString("Operation", "ServerPort", $"{ServerPort}");
            ini.GetString("Operation", "ConnectPort",$"{ConnectPort}");
            ini.GetString("Operation", "ConnectIP", ConnectIP);
            ini.GetString("Operation", "UID", sUID);
            ini.GetString("Operation", "PWD", sPWD); // 실제 적용시에는 암호화 처리 후 저장

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

            int n = sock.Receive(buf);      //  REQ : 연결수립통보 / myIP 수신
            string myIP = Encoding.Default.GetString(buf, 0, n).Split(':')[1];
            AddText($"Return Message : {myIP}\r\n");
            sock.Send(Encoding.Default.GetBytes($"NAM:{sUID}"));    // my ID 통보

            n = sock.Receive(buf);      //  최종 수락/거부 통보
            string sRet = Encoding.Default.GetString(buf, 0, n).Split(':')[0];
            if(sRet == "REJECT") 
            {
                AddText("서버로부터 접속이 거부되었습니다.\r\n");
                return;
            }
            AddText("서버와 접속되었습니다.\r\n");
            threadClient = new Thread(ClientProcess);
            threadClient.Start();
            tbTalk.Text = "";
        }

        Thread threadClient = null;
        void ClientProcess()
        {
            byte[] buf = new byte[1024];
            while(true)
            {
               // if(IsAlive(sock))
                {
                    if(sock.Available > 0)
                    {
                        int n = sock.Receive(buf);
                        AddText(Encoding.Default.GetString(buf, 0, n));
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void tbTalk_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(OperationMode == false)  // Server Mode
                {
                    for(int i=0; i<tcp.Count;i++)   // tcp : List <TcpEx>   --> List : 일종의 배열 오브젝트
                    {
                        if(sbConnectList.Text == "모두에게" || tcp[i].id == sbConnectList.Text)
                        {
                            TcpClient tp = tcp[i].tp;
                            if(IsAlive(tp.Client))
                                tp.Client.Send(Encoding.Default.GetBytes(tbTalk.Text));
                        }
                    }
                    tbTalk.Text = "";
                }
                else   //  Client Mode
                {
                    if(sock != null)
                    {
                        if(IsAlive(sock))
                        {
                            sock.Send(Encoding.Default.GetBytes(tbTalk.Text));
                            tbTalk.Text = "";
                        }
                        else
                        {
                            AddText("서버와의 연결이 끊어졌습니다.\r\n");
                            sock.Close();
                            sock = null;
                        }
                    }
                }
            }
        }

        private void pmnuServerStart_Click(object sender, EventArgs e)
        {
            InitServer();
            AddText($"Server가 [{ServerPort}] port에서 시작되었습니다.\r\n");
        }

        private void pmnuNetworkConfig_Click(object sender, EventArgs e)
        {
            frmNetConfig dlg = new frmNetConfig(ServerPort, ConnectPort, ConnectIP, sUID, sPWD, OperationMode);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                ServerPort = int.Parse(dlg.tbServerPort.Text);
                ConnectPort = int.Parse(dlg.tbConnectPort.Text);
                ConnectIP = dlg.tbConnectIP.Text;
                sUID = dlg.tbUID.Text;
                sPWD = dlg.tbPWD.Text;
                OperationMode = dlg.rbClient.Checked;
            }
        }

        private void sbConnectList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbConnectList.Text = e.ClickedItem.Text;
        }
    }
}
