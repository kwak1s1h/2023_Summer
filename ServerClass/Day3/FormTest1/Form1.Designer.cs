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
            Connect = new Button();
            label2 = new Label();
            ClientListBox = new ListBox();
            SuspendLayout();
            // 
            // ServerIP
            // 
            ServerIP.Location = new Point(76, 7);
            ServerIP.Name = "ServerIP";
            ServerIP.Size = new Size(351, 23);
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
            // Connect
            // 
            Connect.Location = new Point(433, 7);
            Connect.Name = "Connect";
            Connect.Size = new Size(72, 23);
            Connect.TabIndex = 5;
            Connect.Text = "서버 시작";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 59);
            label2.Name = "label2";
            label2.Size = new Size(90, 21);
            label2.TabIndex = 6;
            label2.Text = "클라이언트";
            // 
            // ClientListBox
            // 
            ClientListBox.FormattingEnabled = true;
            ClientListBox.ItemHeight = 15;
            ClientListBox.Location = new Point(9, 83);
            ClientListBox.Name = "ClientListBox";
            ClientListBox.Size = new Size(496, 394);
            ClientListBox.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 486);
            Controls.Add(ClientListBox);
            Controls.Add(label2);
            Controls.Add(Connect);
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
        private Button Connect;
        private Label label2;
        private ListBox ClientListBox;
    }
}