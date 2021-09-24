using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace myLibrary
{
    public partial class frmInput : Form
    {
        public frmInput()
        {
            InitializeComponent();
        }
        public frmInput(string str)
        {
            InitializeComponent();
            Prompt.Text = str;
            Prompt.Visible = true;
        }

        public string retStr = "";
        private void tbInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                retStr = tbInput.Text;
                Close();
            }
            if(e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                retStr = "";
                Close();
            }
        }
    }
    public class iniFile
    {
        [DllImport("kernel32.dll")]
        static extern int GetPrivateProfileString(string s, string k, string df, StringBuilder b, int n, string p);

        [DllImport("kernel32.dll")]
        static extern int WritePrivateProfileString(string s, string k, string df, string p);

        public string fPath;
        public iniFile(string str)
        {
            fPath = str;
        }
        public string GetString(string sec, string key, string def = "")
        {
            StringBuilder buf = new StringBuilder(512);
            GetPrivateProfileString(sec, key, def, buf, 512, fPath);
            return buf.ToString();
        }
        public int WriteString(string sec, string key, string val)
        {
            return WritePrivateProfileString(sec, key, val, fPath);
        }
    }
    public static class mylib
    {
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
        public static string GetTokenEx(int n, string str, char d)
        {
            int i, j, k, n1, n2;    // n1 = start,  n2 = end

            for (i = j = k = n1 = n2 = 0; i < str.Length; i++)
            {
                if (str[i] == d) k++;
                if (k == n) n1 = i;
                if (k == n + 1) n2 = i;
            }
            if (n1 == 0) return "";
            if (n2 == 0) n2 = str.Length + 1;
            return str.Substring(n1, (n2 - 1) - n1);
        }
        public static string GetToken(int n, string str, char d)
        {
            string[] sArr = str.Split(d);
            if (n < sArr.Length) return sArr[n];
            return "";
        }
        public static string GetInput(string str)
        {
            frmInput dlg = new frmInput(str);
            dlg.ShowDialog();
            return dlg.retStr;
        }
    }
}
