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
        Socket sock;
        TcpClient tcp;
        TcpListener listen;
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            listen = new TcpListener(int.Parse(tbServerPort.Text));
            listen.Start();
            tbServer.Text += $"Server port [{tbServer.Text}] started.\r\n";
            while (true)
            {
                if (listen.Pending()) // 현재 보류중인 요청이 있는가?
                {
                    tcp = listen.AcceptTcpClient();  // Blocking Mode : 세션 수립
                    break;
                }
                Thread.Sleep(100);
            }
            tbServer.Text += $"Client connected...\r\n";

            NetworkStream ns = tcp.GetStream();
            byte[] bArr = new byte[512];
            while(true)
            {
                if(ns.DataAvailable)
                {
                    ns.Read(bArr, 0, 512);
                    tbServer.Text += Encoding.Default.GetString(bArr);
                    break;
                }
            }
        }
    }
}
