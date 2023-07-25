namespace FormTest1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ServerIP = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ConnectIP = new TextBox();
            Start = new Button();
            Connect = new Button();
            SuspendLayout();
            // 
            // ServerIP
            // 
            ServerIP.Location = new Point(76, 7);
            ServerIP.Name = "ServerIP";
            ServerIP.Size = new Size(100, 23);
            ServerIP.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 1;
            label1.Text = "서버 IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 38);
            label2.Name = "label2";
            label2.Size = new Size(61, 21);
            label2.TabIndex = 2;
            label2.Text = "접속 IP";
            // 
            // ConnectIP
            // 
            ConnectIP.Location = new Point(76, 40);
            ConnectIP.Name = "ConnectIP";
            ConnectIP.Size = new Size(100, 23);
            ConnectIP.TabIndex = 3;
            // 
            // Start
            // 
            Start.Location = new Point(76, 69);
            Start.Name = "Start";
            Start.Size = new Size(100, 23);
            Start.TabIndex = 4;
            Start.Text = "통신 시작";
            Start.UseVisualStyleBackColor = true;
            Start.Click += Start_Click;
            // 
            // Connect
            // 
            Connect.Location = new Point(182, 7);
            Connect.Name = "Connect";
            Connect.Size = new Size(75, 23);
            Connect.TabIndex = 5;
            Connect.Text = "접속";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(275, 108);
            Controls.Add(Connect);
            Controls.Add(Start);
            Controls.Add(ConnectIP);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ServerIP);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ServerIP;
        private Label label1;
        private Label label2;
        private TextBox ConnectIP;
        private Button Start;
        private Button Connect;
    }
}