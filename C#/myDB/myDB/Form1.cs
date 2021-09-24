using myLibrary;
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
            string[] sArr = buf.Split(',');
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
        }
    }
}
