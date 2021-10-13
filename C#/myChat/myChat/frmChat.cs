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

namespace myChat
{
    public partial class frmChat : Form
    {
        public frmChat()
        {
            InitializeComponent();
        }

        delegate void cbAddText(string str, int i);
        void AddText(string str,int i)
        {
            if(tbServer.InvokeRequired || tbClient.InvokeRequired || statusStrip1.InvokeRequired)
            {
                cbAddText cb = new cbAddText(AddText);
                object[] obj = { str, i };
                Invoke(cb, obj);
            }
            else
            {
                if (i == 1)
                    tbServer.Text += str;
                else if (i == 2)
                    tbClient.Text += str;
                else if (i == 3)
                    sbClientList.DropDownItems.Add(str);
            }
        }

        Socket sock = null;
        TcpClient[] tcp = new TcpClient[10];
        TcpListener listen = null;
        Thread threadServer = null;  // Connect 요구 처리 쓰레드
        Thread threadRead = null;    // 입력 문자열 처리 쓰레드
        int CurrentClientNum = 0;
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            if(listen != null)
            {
                if (MessageBox.Show("서버를 다시 시작하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    listen.Stop();
                    if (threadServer != null) threadServer.Abort();
                    if (threadRead != null) threadRead.Abort();
                }
            }
            listen = new TcpListener(int.Parse(tbServerPort.Text));
            listen.Start();
            AddText($"서버가 [{tbServerPort.Text}] Port에서 시작되었습니다.\r\n", 1);

            threadServer = new Thread(ServerProcess);
            threadServer.Start();
        }

        void ServerProcess()  // Connect 요구 처리 쓰레드
        {
            while(true)
            {
                if(listen.Pending())
                {
                    if (CurrentClientNum == 9) break; // Process over
                    //if (tcp != null)
                    //{
                    //    tcp.Close();
                    //    threadRead.Abort();
                    //}
                    tcp[CurrentClientNum] = listen.AcceptTcpClient(); // 세션 수립
                    string sLabel = tcp[CurrentClientNum].Client.RemoteEndPoint.ToString();  // Client IP Address : Port(Session)
                    AddText($"Client [{sLabel}] 로부터 접속되었습니다\r\n", 1);
                    //sbClientList.DropDownItems.Add(sLabel);
                    AddText(sLabel,3);
                    sbLabel1.Text = sLabel;

                    if(threadRead == null)
                    {
                        threadRead = new Thread(ReadProcess);
                        threadRead.Start();
                    }
                    CurrentClientNum++;
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess() // Multi Client : CurrentClinrNum
        {
            byte[] bArr = new byte[512];
            while(true)
            {
                for(int i=0;i<CurrentClientNum;i++)
                {
                    NetworkStream ns = tcp[i].GetStream();
                    if(ns.DataAvailable)
                    {
                        int n = ns.Read(bArr, 0, 512);
                        AddText(Encoding.Default.GetString(bArr,0,n), 1);
                    }
                }
                Thread.Sleep(100);
            }
        }

        private void frmChat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(threadServer != null) threadServer.Abort();
            if(threadRead != null) threadRead.Abort();
            if(threadClientRead != null) threadClientRead.Abort();
        }

        Thread threadClientRead = null;
        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if(sock != null)
                {
                    if(MessageBox.Show("재연결하시겠습니까?.", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        sock.Close();
                        threadClientRead.Abort();
                    }
                }
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(tbConnectIP.Text, int.Parse(tbConnectPort.Text));  // Connection 수립 요청 - 대기(Blocking Mode)
                AddText($"Server [{tbConnectIP.Text}:{tbConnectPort.Text}] Connected OK.", 2);
                threadClientRead = new Thread(ClientReadProcess);
                threadClientRead.Start();
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        void ClientReadProcess()
        {
            byte[] bArr = new byte[512];
            while(true)
            {
                if(sock.Available > 0)
                {
                    int n = sock.Receive(bArr);
                    AddText($"{Encoding.Default.GetString(bArr, 0, n)}", 2);
                }
                Thread.Sleep(100);
            }
        }

        private void pmnuSendClientText_Click(object sender, EventArgs e)
        {
            string str = (tbClient.SelectedText == "") ? tbClient.Text : tbClient.SelectedText;
            byte[] bArr = Encoding.Default.GetBytes(str);
            sock.Send(bArr);
        }

        int GetTcpIndex() // Tcp List 중 선택되어 있는 리스트 인덱스를 반환
        {
            for (int i = 0; i < CurrentClientNum; i++)
            {
                if (tcp[i].Client.RemoteEndPoint.ToString() == sbClientList.Text)
                    return i;
            }
            return -1;
        }

        private void pmnuSendServerText_Click(object sender, EventArgs e)
        {
            string str = (tbServer.SelectedText == "") ? tbServer.Text : tbServer.SelectedText;
            byte[] bArr = Encoding.Default.GetBytes(str);
            tcp[GetTcpIndex()].Client.Send(bArr);
        }

        private void sbClientList_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbClientList.Text = e.ClickedItem.Text;
        }
    }
}
