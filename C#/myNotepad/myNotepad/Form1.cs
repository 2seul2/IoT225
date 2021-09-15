using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strOrg = "";
        int viewState = 0;  // 0:Normal    1:Lower    2:Upper    3:Hexa 
        private void mnuViewLower_Click(object sender, EventArgs e)
        {
            if (viewState != 1)
            {
                if (strOrg == "") strOrg = tbMemo.Text;
                tbMemo.Text = strOrg.ToLower();
                tbMemo.ReadOnly = true;
                viewState = 1;
            }
        }

        private void mnuViewUpper_Click(object sender, EventArgs e)
        {
            if (viewState != 2)
            {
                if (strOrg == "") strOrg = tbMemo.Text;
                tbMemo.Text = strOrg.ToUpper();
                tbMemo.ReadOnly = true;
                viewState = 2;
            }
        }

        private void mnuViewHexa_Click(object sender, EventArgs e)
        {
            if (viewState != 3)
            {
                if (strOrg == "") strOrg = tbMemo.Text;
                tbMemo.Text = "";

                string s1;
                char[] chr  = strOrg.ToCharArray();
                byte[] bArr = Encoding.Default.GetBytes(chr);
                
                for (int i = 0,count = 0; i < bArr.GetLength(0); i++,count++)
                {
                    //s1 = string.Format(" {0:X2}", bArr[i]);   // printf(" %x ", n);
                    s1 = $" {bArr[i]:X2}";
                    if (count % 16 == 15) s1 += "\r\n";
                    tbMemo.Text += s1;
                }

                //               for (int i = 0; i < strOrg.Length; i++)
                ////foreach(byte c in bArr)
                ////{
                ////    s1 = $" {c:X2} ";              //   string.Format(" {0:d} ", chr[i]);   // printf(" %x ", n);
                ////    tbMemo.Text += s1;
                ////}

                tbMemo.ReadOnly = true;
                viewState = 3;
            }
        }

        private void mnuViewRefresh_Click(object sender, EventArgs e)
        {
            if(strOrg != "")
            {
                tbMemo.Text = strOrg;
                strOrg = "";
                tbMemo.ReadOnly = false;
                viewState = 0;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void tbMemo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                mnuViewRefresh_Click(sender, e);
            }
        }
    }
}
