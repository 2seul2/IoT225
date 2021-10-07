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
            if(tbServer.InvokeRequired || tbClient.InvokeRequired)
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
            }
        }

        Socket sock = null;
        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;  // Connect 요구 처리 쓰레드
        Thread threadRead = null;    // 입력 문자열 처리 쓰레드
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            listen = new TcpListener(int.Parse(tbServerPort.Text));
            listen.Start();

            threadServer = new Thread(ServerProcess);
            threadServer.Start();
            threadRead = new Thread(ReadProcess);
        }

        void ServerProcess()  // Connect 요구 처리 쓰레드
        {
            while(true)
            {
                if(listen.Pending())
                {
                    tcp = listen.AcceptTcpClient(); // 세션 수립
                    AddText("Client [...] 로부터 접속되었습니다\r\n", 1);
                    threadRead.Start();
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while(true)
            {
                if(ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);
                    AddText(Encoding.Default.GetString(bArr,0,n), 1);
                }
                Thread.Sleep(100);
            }
        }
    }
}
