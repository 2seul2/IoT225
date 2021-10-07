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

namespace NetTest
{
    public partial class frmNetTest : Form
    {
        public frmNetTest()
        {
            InitializeComponent(); 
        }

        delegate void CallBackAddText(string str);
        void AddText(string str)  // 문자열 str 을 tbServer TextBox에 출력하는 함수
        {
            if(tbServer.InvokeRequired)  // 대리호출이 필요한가?
            {
                CallBackAddText cb = new CallBackAddText(AddText);
                object[] obj = { str };
                Invoke(cb, obj);
            }
            else
            {
                tbServer.Text += str;
            }
        }

        Socket sock = null;
        TcpClient tcp = null;
        TcpListener listen = null;
        Thread threadServer = null;
        Thread threadRead = null;
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            if(listen != null)
            {
                DialogResult ret = MessageBox.Show("현재의 연결이 끊어집니다.\r\n계속 하시겠습니까?","",MessageBoxButtons.YesNo);
                if (ret == DialogResult.No) return;
                listen.Stop();  // 현재 오픈되어 있는 리스너를 중지
                threadServer.Abort();
                if (threadRead != null && threadRead.IsAlive) threadRead.Abort();
                if (tcp != null) tcp.Close();
            }
            listen = new TcpListener(int.Parse(tbServerPort.Text));
            listen.Start();

            threadServer = new Thread(ServerProcess);
            threadServer.Start();

            threadRead = new Thread(ReadProcess);

            //tbServer.Text += $"Server port [{tbServerPort.Text}] started.\r\n";
            AddText($"Server port [{tbServerPort.Text}] started.\r\n");
            //timer1.Enabled = true;
        }
        void ServerProcess()
        {
            while (true)
            {
                if (listen.Pending()) // 현재 보류중인 요청이 있는가?
                {
                    tcp = listen.AcceptTcpClient();  // Blocking Mode : 세션 수립
                    threadRead.Start();
                    break;
                }
                Thread.Sleep(100);
            }
        }

        void ReadProcess()
        {
            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while (true)
            {
                if (ns.DataAvailable)
                {
                    int n = ns.Read(bArr, 0, 512);  // n : Read byte
                    AddText(Encoding.Default.GetString(bArr,0,n));
                }
                Thread.Sleep(100);
            }
        }

        private void frmNetTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadServer != null) threadServer.Abort();
        }

        private void timer1_Tick(object sender, EventArgs e)   // Read Process
        {
            if (tcp == null) return;
            timer1.Enabled = false;

            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while (true)
            {
                if (ns.DataAvailable)
                {
                    ns.Read(bArr, 0, 512);
                    tbServer.Text += Encoding.Default.GetString(bArr);
                    break;
                }
            }
            timer1.Enabled = true;
        }
    }
}
