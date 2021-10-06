
namespace NetClientTest
{
    partial class frmNetClientTest
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
            this.tbClient = new System.Windows.Forms.TextBox();
            this.tbConnectIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbConnectPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.Popup1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pmnuSendText = new System.Windows.Forms.ToolStripMenuItem();
            this.Popup1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbClient
            // 
            this.tbClient.ContextMenuStrip = this.Popup1;
            this.tbClient.Location = new System.Drawing.Point(7, 5);
            this.tbClient.Multiline = true;
            this.tbClient.Name = "tbClient";
            this.tbClient.Size = new System.Drawing.Size(189, 235);
            this.tbClient.TabIndex = 0;
            // 
            // tbConnectIP
            // 
            this.tbConnectIP.Location = new System.Drawing.Point(293, 12);
            this.tbConnectIP.Name = "tbConnectIP";
            this.tbConnectIP.Size = new System.Drawing.Size(106, 21);
            this.tbConnectIP.TabIndex = 0;
            this.tbConnectIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connect IP";
            // 
            // tbConnectPort
            // 
            this.tbConnectPort.Location = new System.Drawing.Point(293, 39);
            this.tbConnectPort.Name = "tbConnectPort";
            this.tbConnectPort.Size = new System.Drawing.Size(106, 21);
            this.tbConnectPort.TabIndex = 0;
            this.tbConnectPort.Text = "9000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(293, 82);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(106, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(293, 111);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(106, 23);
            this.btnDisconnect.TabIndex = 2;
            this.btnDisconnect.Text = "DisConnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisConnect_Click);
            // 
            // Popup1
            // 
            this.Popup1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pmnuSendText});
            this.Popup1.Name = "Popup1";
            this.Popup1.Size = new System.Drawing.Size(181, 48);
            // 
            // pmnuSendText
            // 
            this.pmnuSendText.Name = "pmnuSendText";
            this.pmnuSendText.Size = new System.Drawing.Size(180, 22);
            this.pmnuSendText.Text = "SendText";
            this.pmnuSendText.Click += new System.EventHandler(this.pmnuSendText_Click);
            // 
            // frmNetClientTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 243);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbConnectPort);
            this.Controls.Add(this.tbConnectIP);
            this.Controls.Add(this.tbClient);
            this.Name = "frmNetClientTest";
            this.Text = "Form1";
            this.Popup1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbClient;
        private System.Windows.Forms.TextBox tbConnectIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbConnectPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.ContextMenuStrip Popup1;
        private System.Windows.Forms.ToolStripMenuItem pmnuSendText;
    }
}

