using myLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        iniFile ini = new iniFile(".\\myDB.ini");
        private void Form1_Load(object sender, EventArgs e)
        {
            int x = int.Parse(ini.GetString("Position", "LocationX", "0"));
            int y = int.Parse(ini.GetString("Position", "LocationY", "0"));
            Location = new Point(x, y);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.WriteString("Position", "LocationX", $"{Location.X}");
            ini.WriteString("Position", "LocationY", $"{Location.Y}");
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            dbGrid.Columns.Add(tbInput.Text, tbInput.Text);
        }

        private void mnuColumnAdd_Click(object sender, EventArgs e)
        {
            string str = mylib.GetInput("컬럼명");
            dbGrid.Columns.Add(str, str);
        }

        private void pmnuColumnAdd_Click(object sender, EventArgs e)
        {
            mnuColumnAdd_Click(sender, e);
            //string str = mylib.GetInput("컬럼명");
            //dbGrid.Columns.Add(str, str);
        }

        private void mnuRowAdd_Click(object sender, EventArgs e)
        {
            if(dbGrid.ColumnCount > 0)
                dbGrid.Rows.Add();  // 1 Line 추가
            dbGrid.Rows[1].Cells[5].Value = "";
        }

        private void pmnuRowAdd_Click(object sender, EventArgs e)
        {
            mnuRowAdd_Click(sender, e);
        }

        private void mnuMigration_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;

            dbGrid.Rows.Clear();
            dbGrid.Columns.Clear();
            StreamReader sr = new StreamReader(openFileDialog.FileName);
            string buf = sr.ReadLine();
            byte[] bb1 = Encoding.Convert(Encoding.ASCII, Encoding.Default, Encoding.Default.GetBytes(buf));
            string bb2 = Encoding.Default.GetString(bb1);
            string[] sArr = bb2.Split(',');
            for(int i=0; i<sArr.Length;i++)
            {
                dbGrid.Columns.Add(sArr[i], sArr[i]);
            }
            while(true)
            {
                buf = sr.ReadLine();
                if (buf == null) break;
                sArr = buf.Split(',');
                dbGrid.Rows.Add(sArr);
                //int rIdx = dbGrid.Rows.Add();
                //for (int i = 0; i < sArr.Length; i++)
                //{
                //    dbGrid.Rows[rIdx].Cells[i].Value = sArr[i];
                //}
            }
            sr.Close();
        }

        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Source\Repos\IoT225\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        private void mnuOpen_Click(object sender, EventArgs e)
        {
            bool vn = openFileDialog.ValidateNames;
            try
            {
                openFileDialog.ValidateNames = false;
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;

                string[] sArr = ConnString.Split(';');
                ConnString = $"{sArr[0]};{sArr[1].Replace(sArr[1].Split('=')[1], openFileDialog.FileName)};{sArr[2]};{sArr[3]}";

                sqlConn.ConnectionString = ConnString;
                sqlConn.Open();
                sqlCmd.Connection = sqlConn;

                sbLabel1.Text = openFileDialog.SafeFileName; // file name only
                sbLabel1.BackColor = Color.Green;

                DataTable dt = sqlConn.GetSchema("Tables");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sbLabel2.DropDownItems.Add(dt.Rows[i].ItemArray[2].ToString());
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
                //sqlCmd.CommandText = "select * from student";
                //SqlDataReader sdr = sqlCmd.ExecuteReader();

                //dbGrid.Rows.Clear();
                //dbGrid.Columns.Clear();
                //for(int i = 0; i<sdr.FieldCount; i++)
                //{
                //    string s = sdr.GetName(i);
                //    dbGrid.Columns.Add(s, s);
                //}
                //for(int i = 0;sdr.Read();i++)
                //{
                //    int rIdx = dbGrid.Rows.Add();
                //    for (int j = 0; j < sdr.FieldCount; j++)
                //    {
                //        object obj = sdr.GetValue(j);
                //        dbGrid.Rows[rIdx].Cells[j].Value = obj;
                //    }
                //}
                //sdr.Close();
            finally
            {
                openFileDialog.ValidateNames = vn;
            }
        }

        private void sbLabel2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbLabel2.Text = e.ClickedItem.Text;
        }
    }
}
