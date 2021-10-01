﻿
namespace myDB
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dbGrid = new System.Windows.Forms.DataGridView();
            this.PopupMenu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.pmnuColumnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pmnuDeleteColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuDeleteRow = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMigration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMigrationImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMigrationExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateTable = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuColumnAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRowAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.sQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExcute = new System.Windows.Forms.ToolStripMenuItem();
            this.tbMemo = new System.Windows.Forms.TextBox();
            this.PopupMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuExecute = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.sbLabel2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextUtf8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTextAnsi = new System.Windows.Forms.ToolStripMenuItem();
            this.pmnuColumnInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.echoOptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEchoText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEchoGrid = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).BeginInit();
            this.PopupMenu1.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.PopupMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dbGrid
            // 
            this.dbGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbGrid.ContextMenuStrip = this.PopupMenu1;
            this.dbGrid.Location = new System.Drawing.Point(0, 3);
            this.dbGrid.Name = "dbGrid";
            this.dbGrid.RowTemplate.Height = 23;
            this.dbGrid.Size = new System.Drawing.Size(745, 238);
            this.dbGrid.TabIndex = 0;
            // 
            // PopupMenu1
            // 
            this.PopupMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuUpdate,
            this.pmnuInsert,
            this.pmnuDelete,
            this.toolStripMenuItem2,
            this.pmnuColumnInfo,
            this.pmnuColumnAdd,
            this.pmnuRowAdd,
            this.toolStripSeparator3,
            this.pmnuDeleteColumn,
            this.pmnuDeleteRow});
            this.PopupMenu1.Name = "PopupMenu1";
            this.PopupMenu1.Size = new System.Drawing.Size(146, 192);
            // 
            // pmnuUpdate
            // 
            this.pmnuUpdate.Name = "pmnuUpdate";
            this.pmnuUpdate.Size = new System.Drawing.Size(145, 22);
            this.pmnuUpdate.Text = "DB update";
            this.pmnuUpdate.Click += new System.EventHandler(this.pmnuUpdate_Click);
            // 
            // pmnuInsert
            // 
            this.pmnuInsert.Name = "pmnuInsert";
            this.pmnuInsert.Size = new System.Drawing.Size(145, 22);
            this.pmnuInsert.Text = "DB insert";
            this.pmnuInsert.Click += new System.EventHandler(this.pmnuInsert_Click);
            // 
            // pmnuDelete
            // 
            this.pmnuDelete.Name = "pmnuDelete";
            this.pmnuDelete.Size = new System.Drawing.Size(145, 22);
            this.pmnuDelete.Text = "레코드 삭제";
            this.pmnuDelete.Click += new System.EventHandler(this.pmnuDelete_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 6);
            // 
            // pmnuColumnAdd
            // 
            this.pmnuColumnAdd.Name = "pmnuColumnAdd";
            this.pmnuColumnAdd.Size = new System.Drawing.Size(145, 22);
            this.pmnuColumnAdd.Text = "Column 추가";
            this.pmnuColumnAdd.Click += new System.EventHandler(this.pmnuColumnAdd_Click);
            // 
            // pmnuRowAdd
            // 
            this.pmnuRowAdd.Name = "pmnuRowAdd";
            this.pmnuRowAdd.Size = new System.Drawing.Size(145, 22);
            this.pmnuRowAdd.Text = "Row 추가";
            this.pmnuRowAdd.Click += new System.EventHandler(this.pmnuRowAdd_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(142, 6);
            // 
            // pmnuDeleteColumn
            // 
            this.pmnuDeleteColumn.Name = "pmnuDeleteColumn";
            this.pmnuDeleteColumn.Size = new System.Drawing.Size(145, 22);
            this.pmnuDeleteColumn.Text = "Column 삭제";
            this.pmnuDeleteColumn.Click += new System.EventHandler(this.pmnuDeleteColumn_Click);
            // 
            // pmnuDeleteRow
            // 
            this.pmnuDeleteRow.Name = "pmnuDeleteRow";
            this.pmnuDeleteRow.Size = new System.Drawing.Size(145, 22);
            this.pmnuDeleteRow.Text = "Row 삭제";
            this.pmnuDeleteRow.Click += new System.EventHandler(this.pmnuDeleteRow_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.editToolStripMenuItem,
            this.sQLToolStripMenuItem,
            this.configToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(745, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNew,
            this.toolStripMenuItem1,
            this.mnuMigration,
            this.toolStripSeparator1,
            this.mnuOpen,
            this.mnuSave,
            this.mnuCreateTable,
            this.toolStripSeparator2,
            this.mnuExit});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.newToolStripMenuItem.Text = "File";
            // 
            // mnuNew
            // 
            this.mnuNew.Name = "mnuNew";
            this.mnuNew.Size = new System.Drawing.Size(180, 22);
            this.mnuNew.Text = "New";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuMigration
            // 
            this.mnuMigration.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMigrationImport,
            this.mnuMigrationExport});
            this.mnuMigration.Name = "mnuMigration";
            this.mnuMigration.Size = new System.Drawing.Size(180, 22);
            this.mnuMigration.Text = "Migration.. (.csv)";
            // 
            // mnuMigrationImport
            // 
            this.mnuMigrationImport.Name = "mnuMigrationImport";
            this.mnuMigrationImport.Size = new System.Drawing.Size(180, 22);
            this.mnuMigrationImport.Text = "Import";
            this.mnuMigrationImport.Click += new System.EventHandler(this.mnuMigrationImport_Click);
            // 
            // mnuMigrationExport
            // 
            this.mnuMigrationExport.Name = "mnuMigrationExport";
            this.mnuMigrationExport.Size = new System.Drawing.Size(180, 22);
            this.mnuMigrationExport.Text = "Export";
            this.mnuMigrationExport.Click += new System.EventHandler(this.mnuMigrationExport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuOpen
            // 
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(180, 22);
            this.mnuOpen.Text = "Open";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(180, 22);
            this.mnuSave.Text = "Update Table";
            // 
            // mnuCreateTable
            // 
            this.mnuCreateTable.Name = "mnuCreateTable";
            this.mnuCreateTable.Size = new System.Drawing.Size(180, 22);
            this.mnuCreateTable.Text = "Create Table";
            this.mnuCreateTable.Click += new System.EventHandler(this.mnuCreateTable_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(180, 22);
            this.mnuExit.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuColumnAdd,
            this.mnuRowAdd});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuColumnAdd
            // 
            this.mnuColumnAdd.Name = "mnuColumnAdd";
            this.mnuColumnAdd.Size = new System.Drawing.Size(180, 22);
            this.mnuColumnAdd.Text = "Column 추가";
            this.mnuColumnAdd.Click += new System.EventHandler(this.mnuColumnAdd_Click);
            // 
            // mnuRowAdd
            // 
            this.mnuRowAdd.Name = "mnuRowAdd";
            this.mnuRowAdd.Size = new System.Drawing.Size(180, 22);
            this.mnuRowAdd.Text = "Row 추가";
            this.mnuRowAdd.Click += new System.EventHandler(this.mnuRowAdd_Click);
            // 
            // sQLToolStripMenuItem
            // 
            this.sQLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExcute});
            this.sQLToolStripMenuItem.Name = "sQLToolStripMenuItem";
            this.sQLToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.sQLToolStripMenuItem.Text = "SQL";
            // 
            // mnuExcute
            // 
            this.mnuExcute.Name = "mnuExcute";
            this.mnuExcute.Size = new System.Drawing.Size(109, 22);
            this.mnuExcute.Text = "Excute";
            this.mnuExcute.Click += new System.EventHandler(this.mnuExcute_Click);
            // 
            // tbMemo
            // 
            this.tbMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMemo.ContextMenuStrip = this.PopupMenu2;
            this.tbMemo.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMemo.Location = new System.Drawing.Point(0, 0);
            this.tbMemo.Multiline = true;
            this.tbMemo.Name = "tbMemo";
            this.tbMemo.Size = new System.Drawing.Size(745, 147);
            this.tbMemo.TabIndex = 2;
            this.tbMemo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbMemo_KeyDown);
            // 
            // PopupMenu2
            // 
            this.PopupMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuExecute});
            this.PopupMenu2.Name = "PopupMenu2";
            this.PopupMenu2.Size = new System.Drawing.Size(116, 26);
            // 
            // pmnuExecute
            // 
            this.pmnuExecute.Name = "pmnuExecute";
            this.pmnuExecute.Size = new System.Drawing.Size(115, 22);
            this.pmnuExecute.Text = "Execute";
            this.pmnuExecute.Click += new System.EventHandler(this.pmnuExecute_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            this.openFileDialog.ValidateNames = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 27);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbMemo);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dbGrid);
            this.splitContainer1.Size = new System.Drawing.Size(745, 395);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 3;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbLabel1,
            this.sbLabel2});
            this.statusStrip.Location = new System.Drawing.Point(0, 425);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(745, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // sbLabel1
            // 
            this.sbLabel1.Name = "sbLabel1";
            this.sbLabel1.Size = new System.Drawing.Size(54, 17);
            this.sbLabel1.Text = "sbLabel1";
            // 
            // sbLabel2
            // 
            this.sbLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbLabel2.Image = ((System.Drawing.Image)(resources.GetObject("sbLabel2.Image")));
            this.sbLabel2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbLabel2.Name = "sbLabel2";
            this.sbLabel2.Size = new System.Drawing.Size(67, 20);
            this.sbLabel2.Text = "sbLabel2";
            this.sbLabel2.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbLabel2_DropDownItemClicked);
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textFileToolStripMenuItem,
            this.echoOptionToolStripMenuItem});
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.configToolStripMenuItem.Text = "Config";
            // 
            // textFileToolStripMenuItem
            // 
            this.textFileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextUtf8,
            this.mnuTextAnsi});
            this.textFileToolStripMenuItem.Name = "textFileToolStripMenuItem";
            this.textFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.textFileToolStripMenuItem.Text = "Text Option";
            // 
            // mnuTextUtf8
            // 
            this.mnuTextUtf8.Checked = true;
            this.mnuTextUtf8.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuTextUtf8.Name = "mnuTextUtf8";
            this.mnuTextUtf8.Size = new System.Drawing.Size(180, 22);
            this.mnuTextUtf8.Text = "UTF-8";
            this.mnuTextUtf8.Click += new System.EventHandler(this.mnuTextUtf8_Click);
            // 
            // mnuTextAnsi
            // 
            this.mnuTextAnsi.Name = "mnuTextAnsi";
            this.mnuTextAnsi.Size = new System.Drawing.Size(180, 22);
            this.mnuTextAnsi.Text = "ANSI";
            this.mnuTextAnsi.Click += new System.EventHandler(this.mnuTextAnsi_Click);
            // 
            // pmnuColumnInfo
            // 
            this.pmnuColumnInfo.Name = "pmnuColumnInfo";
            this.pmnuColumnInfo.Size = new System.Drawing.Size(145, 22);
            this.pmnuColumnInfo.Text = "Column 정보";
            this.pmnuColumnInfo.Click += new System.EventHandler(this.pmnuColumnInfo_Click);
            // 
            // echoOptionToolStripMenuItem
            // 
            this.echoOptionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEchoText,
            this.mnuEchoGrid});
            this.echoOptionToolStripMenuItem.Name = "echoOptionToolStripMenuItem";
            this.echoOptionToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.echoOptionToolStripMenuItem.Text = "Echo Option";
            // 
            // mnuEchoText
            // 
            this.mnuEchoText.CheckOnClick = true;
            this.mnuEchoText.Name = "mnuEchoText";
            this.mnuEchoText.Size = new System.Drawing.Size(180, 22);
            this.mnuEchoText.Text = "Text";
            this.mnuEchoText.Click += new System.EventHandler(this.mnuEchoText_Click);
            // 
            // mnuEchoGrid
            // 
            this.mnuEchoGrid.Checked = true;
            this.mnuEchoGrid.CheckOnClick = true;
            this.mnuEchoGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuEchoGrid.Name = "mnuEchoGrid";
            this.mnuEchoGrid.Size = new System.Drawing.Size(180, 22);
            this.mnuEchoGrid.Text = "Grid";
            this.mnuEchoGrid.Click += new System.EventHandler(this.mnuEchoGrid_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 447);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dbGrid)).EndInit();
            this.PopupMenu1.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.PopupMenu2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dbGrid;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuMigration;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuCreateTable;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.TextBox tbMemo;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuColumnAdd;
        private System.Windows.Forms.ToolStripMenuItem mnuRowAdd;
        private System.Windows.Forms.ContextMenuStrip PopupMenu1;
        private System.Windows.Forms.ToolStripMenuItem pmnuColumnAdd;
        private System.Windows.Forms.ToolStripMenuItem pmnuRowAdd;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.ToolStripDropDownButton sbLabel2;
        private System.Windows.Forms.ToolStripMenuItem sQLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExcute;
        private System.Windows.Forms.ContextMenuStrip PopupMenu2;
        private System.Windows.Forms.ToolStripMenuItem pmnuExecute;
        private System.Windows.Forms.ToolStripMenuItem pmnuUpdate;
        private System.Windows.Forms.ToolStripMenuItem pmnuInsert;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem pmnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem pmnuDeleteColumn;
        private System.Windows.Forms.ToolStripMenuItem pmnuDeleteRow;
        private System.Windows.Forms.ToolStripMenuItem mnuMigrationImport;
        private System.Windows.Forms.ToolStripMenuItem mnuMigrationExport;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem textFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTextUtf8;
        private System.Windows.Forms.ToolStripMenuItem mnuTextAnsi;
        private System.Windows.Forms.ToolStripMenuItem pmnuColumnInfo;
        private System.Windows.Forms.ToolStripMenuItem echoOptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEchoText;
        private System.Windows.Forms.ToolStripMenuItem mnuEchoGrid;
    }
}

