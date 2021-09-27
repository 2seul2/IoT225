using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                byte[] bAr1 = Encoding.Default.GetBytes(strOrg.ToCharArray());
                
                for (int i = 0; i < bArr.GetLength(0); i++)
                {
                    //s1 = string.Format(" {0:X2}", bArr[i]);   // printf(" %x ", n);
                    s1 = $" {bArr[i]:X2}";
                    if (i % 16 == 15) s1 += "\r\n";
                    tbMemo.Text += s1;
                }
                ////tbMemo.Text += "\r\n===========================================\r\n";
                ////int count = 0;
                ////foreach (byte c in bArr)
                ////{
                ////    s1 = $" {c:X2}";              //   string.Format(" {0:d} ", chr[i]);   // printf(" %x ", n);
                ////    if (count++ % 16 == 15) s1 += "\r\n";
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

        string filePath = "";
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                tbMemo.Text = sr.ReadToEnd();
                sr.Close();
            }
        }

        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = Path.GetFileName(filePath);
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(tbMemo.Text);
                sw.Close();
            }
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = filePath;
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName);
                sw.Write(tbMemo.Text);
                sw.Close();
            }
        }

        // prototype : string GetToken(int n, string str, char d);
        // Argument :
        //       n  : n 번째 Item 
        //      str : 문자열
        //       d  : 구분자
        //  설명 : 문자열 str에 있는 데이터를 구분자 d를 통해
        //         필드를 구분하여, 그 중 n번째 데이터를 반환
        //  ex)  GetToken(4, " a,b,c,d", ',') ===> "d"
        //  
        //  GetToken 함수를 이용하여 GetFileName 함수를 구현하세요.
        string GetTokenEx(int n, string str, char d)
        {
            int i, j, k, n1, n2;    // n1 = start,  n2 = end

            for(i=j=k=n1=n2=0;i<str.Length;i++)
            {
                if (str[i] == d) k++;
                if (k == n) n1 = i;
                if (k == n + 1) n2 = i;
            }
            if (n1 == 0) return "";
            if (n2 == 0) n2 = str.Length+1;
            return str.Substring(n1,(n2-1)-n1);
        }
        string GetToken(int n, string str, char d)
        {
            string[] sArr = str.Split(d);
            if(n < sArr.Length) return sArr[n];
            return "";
        }
            int num = 0;
        private void mnuEditTest_Click(object sender, EventArgs e)
        {
            tbMemo.Text += $"{GetToken(num++, " a,b,c,d", ',')}\r\n";
        }
    }
}
