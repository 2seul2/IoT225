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
    public partial class frmDBManager : Form
    {
        public frmDBManager()
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
            dbGrid.Columns.Add(tbMemo.Text, tbMemo.Text);
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
            Encoding ec = (mnuTextUtf8.Checked == true) ? Encoding.UTF8 : Encoding.Default;
            StreamReader sr = new StreamReader(openFileDialog.FileName, ec ,true);
            string buf = sr.ReadLine();
            ////byte[] bb1 = Encoding.Convert(Encoding.ASCII, Encoding.Default, Encoding.Default.GetBytes(buf));
            ////string bb2 = Encoding.Default.GetString(bb1);
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
            sr.Close();
        }

        SqlConnection sqlConn = new SqlConnection();
        SqlCommand sqlCmd = new SqlCommand();
        string ConnString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Source\Repos\IoT225\C#\myDatabase.mdf;Integrated Security=True;Connect Timeout=30";
        string CurrentTable = "";
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
                sbLabel2.Text = "dbTables";
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
            finally
            {
                openFileDialog.ValidateNames = vn;
            }
        }

        private void sbLabel2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            sbLabel2.Text = e.ClickedItem.Text;
            RunSql($"select * from {e.ClickedItem.Text}");
        }

        char[] ca = { ' ', '\t', '\r', '\n' };  // white space array
        public int RunSql(string sql)  // 모든 SQL 명령어를 처리
        {  // ex)  select * from          student where code < 4 / SELECT  /Select  / selEct
            sqlCmd.CommandText = sql;

            try
            {
                string sCmd = sql.Trim().Substring(0, 6); //mylib.GetToken(0, sql.Trim(), ' ');
                if (sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();    //student  where code < 4 
                    CurrentTable = s1.Split(ca)[0];
                    sbLabel2.Text = CurrentTable;
                    //CurrentTable = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];

                    SqlDataReader sdr = sqlCmd.ExecuteReader();

                    dbGrid.Rows.Clear();
                    dbGrid.Columns.Clear();
                    for (int i = 0; i < sdr.FieldCount; i++)
                    {
                        string s = sdr.GetName(i);
                        dbGrid.Columns.Add(s, s);
                    }
                    for (int i = 0; sdr.Read(); i++)
                    {
                        int rIdx = dbGrid.Rows.Add();
                        for (int j = 0; j < sdr.FieldCount; j++)
                        {
                            object obj = sdr.GetValue(j);
                            dbGrid.Rows[rIdx].Cells[j].Value = obj;
                        }
                    }
                    sdr.Close();
                    return 0;
                }
                else
                {
                    return sqlCmd.ExecuteNonQuery();
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message); return -1;
            }
        }

        public string RunSql_noEcho(string sql)  // 모든 SQL 명령어를 처리  -  조회 결과를 문자열로 반환
        {  // ex)  select * from          student where code < 4 / SELECT  /Select  / selEct
            sqlCmd.CommandText = sql;

            try
            {
                string sCmd = sql.Trim().Substring(0, 6); //mylib.GetToken(0, sql.Trim(), ' ');
                if (sCmd.ToLower() == "select")
                {
                    int n1 = sql.ToLower().IndexOf("from");
                    string s1 = sql.Substring(n1 + 4).Trim();    //student  where code < 4 
                    CurrentTable = s1.Split(ca)[0];
                    //CurrentTable = sql.Substring(sql.ToLower().IndexOf("from") + 4).Trim().Split(ca)[0];
                    //sbLabel2.Text = CurrentTable;

                    SqlDataReader sdr = sqlCmd.ExecuteReader();

                    string sRet = sdr.GetName(0);
                    for (int i = 1; i < sdr.FieldCount; i++)
                    {
                        sRet += $",{sdr.GetName(i)}";
                    }
                    sRet += "\r\n";

                    for (int i = 0; sdr.Read(); i++)
                    {
                        sRet += sdr.GetValue(0);
                        for (int j = 1; j < sdr.FieldCount; j++)
                        {
                            sRet += $",{sdr.GetValue(j)}";
                        }
                        sRet += "\r\n";
                    }
                    sdr.Close();
                    return sRet;
                }
                else
                {
                    return $"{sqlCmd.ExecuteNonQuery()}";
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message); return e1.Message;
            }
        }

        private void mnuExcute_Click(object sender, EventArgs e)
        {
            if (mnuEchoGrid.Checked) RunSql(tbMemo.Text);
            else RunSql_noEcho(tbMemo.Text);
        }

        private void tbMemo_KeyDown(object sender, KeyEventArgs e)
        {  // SHIFT + [Enter]
            if(e.Shift == true && e.KeyCode == Keys.Enter)
            {
                if (mnuEchoGrid.Checked) RunSql(tbMemo.Text);
                else RunSql_noEcho(tbMemo.Text);
            }
        }

        private void pmnuExecute_Click(object sender, EventArgs e)
        {
            if (mnuEchoGrid.Checked) RunSql(tbMemo.SelectedText);
            else RunSql_noEcho(tbMemo.SelectedText);
        }

        private void pmnuUpdate_Click(object sender, EventArgs e)
        {   // update [Table] set [Column=value,,,] where <code=rowVal>
            int x = dbGrid.SelectedCells[0].ColumnIndex;
            int y = dbGrid.SelectedCells[0].RowIndex;
            string s1 = dbGrid.Columns[x].HeaderText;
            object s2 = dbGrid.SelectedCells[0].Value;
            string o1 = dbGrid.Columns[0].HeaderText;
            object o2 = dbGrid.Rows[y].Cells[0].Value;
            string sql = $"update {CurrentTable} set {s1}=N'{s2}' where {o1}=N'{o2}'";
            RunSql(sql);
        }

        public  void Insert_Proc(int nRow)
        {   // 1 : insert into [Table] values (value,,,)
            // 2 : insert into [Table] (field1, field2,,,) values (val1,val2,,)
            try
            {
                string s1 = "(";
                string s2 = "(";
                for (int i = 0; i < dbGrid.ColumnCount; i++)
                {
                    if (i != 0)
                    {
                        s1 += ","; s2 += ",";
                    }
                    s1 += $"{dbGrid.Columns[i].HeaderText}";
                    s2 += $"N'{dbGrid.Rows[nRow].Cells[i].Value}'";
                }
                s1 += ")"; s2 += ")";

                string sql = $"insert into {CurrentTable} {s1} values {s2}";

                ////string sql = $"insert into {CurrentTable} (";
                ////for(int i=0;i<dbGrid.ColumnCount;i++)
                ////{
                ////    if (i != 0) sql += ",";
                ////    sql += $"{dbGrid.Columns[i].HeaderText}";
                ////}
                ////sql += ") values (";
                ////for(int i=0;i<dbGrid.ColumnCount;i++)
                ////{
                ////    if (i != 0) sql += ",";
                ////    sql += $"'{dbGrid.SelectedRows[0].Cells[i].Value}'";
                ////}
                ////sql += ")";
                RunSql(sql);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void pmnuInsert_Click(object sender, EventArgs e)
        {
            Insert_Proc(dbGrid.SelectedRows[0].Index);
        }

        private void pmnuDelete_Click(object sender, EventArgs e)
        {   // DELETE student WHERE code=4 AND name=‘사번’ AND kor=50
            string sql = $"DELETE {CurrentTable} WHERE ";
            try
            {
                for(int i = 0; i < dbGrid.ColumnCount; i++)
                {
                    if (dbGrid.SelectedRows[0].Cells[i].Value == null ||
                       dbGrid.SelectedRows[0].Cells[i].Value.ToString() == "") continue;
                    if (i != 0) sql += " AND ";
                    sql += $"{dbGrid.Columns[i].HeaderText}='{dbGrid.SelectedRows[0].Cells[i].Value}'";
                }
                RunSql(sql);
                dbGrid.Rows.Remove(dbGrid.SelectedRows[0]);
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void pmnuDeleteColumn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ret = MessageBox.Show("정말요?", "컬럼 삭제", MessageBoxButtons.OKCancel);
                if(ret == DialogResult.OK)
                    dbGrid.Columns.RemoveAt(dbGrid.SelectedCells[0].ColumnIndex);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void pmnuDeleteRow_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult ret = MessageBox.Show("정말요?", "레코드 삭제", MessageBoxButtons.OKCancel);
                if(ret == DialogResult.OK)
                    dbGrid.Rows.Remove(dbGrid.SelectedRows[0]);
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }

        private void mnuMigrationImport_Click(object sender, EventArgs e)
        {
            //mnuMigration_Click(sender, e);
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding enc;
                if (mnuTextUtf8.Checked == true) enc = Encoding.UTF8;
                else enc = Encoding.Default; // ANSI

                byte[] bArrOrg = File.ReadAllBytes(openFileDialog.FileName);  // Raw data : Low level data
                byte[] bArr = Encoding.Convert(enc, Encoding.Default, bArrOrg);
                string str = Encoding.Default.GetString(bArr); // All Text
                tbMemo.Text += str;
                string[] sArr = str.Split('\n');
                string[] sa1 = sArr[0].Trim().Split(',');
                for(int i=0;i<sa1.Length;i++)
                {
                    dbGrid.Columns.Add(sa1[i], sa1[i]);
                }
                for(int k=1;k<sArr.Length;k++)
                {
                    sa1 = sArr[k].Trim().Split(',');
                    dbGrid.Rows.Add(sa1);
                    //int n = dbGrid.Rows.Add();
                    //for (int i = 0; i < sa1.Length; i++)
                    //{
                    //    dbGrid.Rows[n].Cells[i].Value = sa1[i];
                    //}
                }
            }
        }

        private void mnuMigrationExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sd = new SaveFileDialog();
            if(sd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sd.FileName);
                string sbuf = "";
                for(int i = 0 ; i < dbGrid.ColumnCount ; i++)
                {
                    if (i != 0) sbuf += ",";
                    sbuf += dbGrid.Columns[i].HeaderText;
                }
                sw.WriteLine(sbuf);
                for(int k = 0 ; k < dbGrid.RowCount-1 ; k++)
                {
                    sbuf = "";
                    for(int i = 0 ; i < dbGrid.ColumnCount ; i++)
                    {
                        if (i != 0) sbuf += ",";
                        string s1 = "";
                        if(dbGrid.Rows[k].Cells[i].Value != null)
                            s1 = dbGrid.Rows[k].Cells[i].Value.ToString().Trim();
                        sbuf += s1;
                    }
                    sw.WriteLine(sbuf);
                }
                sw.Close();
            }
        }

        private void mnuCreateTable_Click(object sender, EventArgs e)
        {   // create table [Table] ( [field] [type] [not null] ,,, )
            // create table Test_table (Code varchar(10) not null, Name varchar(10),,, ) 
            string s1 = mylib.GetInput("Field Name");
            if (s1 == "") return;

            string sql = $"CREATE TABLE {s1} (";
            for(int i=0; i<dbGrid.ColumnCount; i++)
            {
                if (i != 0) sql += ",";
                sql += dbGrid.Columns[i].HeaderText;
                sql += " varchar(10) ";
                if (i == 0) sql += " not null ";
            }
            sql += ")";
            RunSql(sql);
            CurrentTable = s1;

            for(int i=0; i<dbGrid.RowCount; i++)
            {
                Insert_Proc(i);
            }
        }

        private void mnuTextUtf8_Click(object sender, EventArgs e)
        {
            mnuTextUtf8.Checked = true;
            mnuTextAnsi.Checked = false;
        }

        private void mnuTextAnsi_Click(object sender, EventArgs e)
        {
            mnuTextAnsi.Checked = true;
            mnuTextUtf8.Checked = false;
        }
        private void mnuEchoGrid_Click(object sender, EventArgs e)
        {
            mnuEchoText.Checked = false;
        }

        private void mnuEchoText_Click(object sender, EventArgs e)
        {
            mnuEchoGrid.Checked = false;
        }

        private void pmnuColumnInfo_Click(object sender, EventArgs e)
        {
            int nCol = dbGrid.SelectedCells[0].ColumnIndex;
            string sCol = dbGrid.Columns[nCol].HeaderText;

            string str = RunSql_noEcho("select Table_name,column_name,data_type,character_maximum_length,is_nullable "+
                          " from information_schema.columns "+
                          $" where column_name = '{sCol}' and table_name='{CurrentTable}'");
            tbMemo.Text += str;
        }

        private void pmnuAlterColumn_Click(object sender, EventArgs e)
        {   // ALTER TABLE [Table] ALTER COLUMN [column] [nvarchar(10)] [nullable]
            // Form을 신규 생성 : 컬럼 type, Max Length, nullable 선택

            int nCol = dbGrid.SelectedCells[0].ColumnIndex;
            string sCol = dbGrid.Columns[nCol].HeaderText;
            try
            {
                string str = RunSql_noEcho("select Table_name,column_name,data_type,character_maximum_length,is_nullable "+
                              " from information_schema.columns "+
                              $" where column_name = '{sCol}' and table_name='{CurrentTable}'");
                string[] sInfo = str.Split('\n')[1].Trim().Split(',');
                frmColType dlg = new frmColType(sInfo[1], sInfo[2], int.Parse(sInfo[3]));
                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    string sql = $"ALTER TABLE {sInfo[0]} ALTER COLUMN {sInfo[1]} {dlg.cbDataType.Text}({dlg.tbMax.Text}) {dlg.cbNullable.Text}";
                    RunSql(sql);
                }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
    }
}
