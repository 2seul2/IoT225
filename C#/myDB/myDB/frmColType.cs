using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myDB
{
    public partial class frmColType : Form
    {
        string ColName, strDT;
        int MaxSize;
        public frmColType(string cName, string str = "", int size=10)
        {
            InitializeComponent();
            ColName = cName;
            strDT = str;
            MaxSize = size;
        }

        private void frmColType_Load(object sender, EventArgs e)
        {
            this.Text = $"{ColName} - Column Type";
            cbDataType.Items.Add("nvarchar");
            cbDataType.Items.Add("nchar");
            cbDataType.Items.Add("varchar");
            cbDataType.Text = strDT;
            tbMax.Text = $"{MaxSize}";
        }
    }
}
