namespace FormClient1
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
            Connect = new Button();
            Send = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ServerIP = new TextBox();
            IntValue = new TextBox();
            FloatValue = new TextBox();
            StringValue = new TextBox();
            SuspendLayout();
            // 
            // Connect
            // 
            Connect.Location = new Point(197, 9);
            Connect.Name = "Connect";
            Connect.Size = new Size(75, 23);
            Connect.TabIndex = 0;
            Connect.Text = "접속";
            Connect.UseVisualStyleBackColor = true;
            Connect.Click += Connect_Click;
            // 
            // Send
            // 
            Send.Location = new Point(197, 107);
            Send.Name = "Send";
            Send.Size = new Size(75, 23);
            Send.TabIndex = 1;
            Send.Text = "전송";
            Send.UseVisualStyleBackColor = true;
            Send.Click += Send_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(61, 21);
            label1.TabIndex = 2;
            label1.Text = "서버 IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(12, 49);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 3;
            label2.Text = "Int32 값";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 79);
            label3.Name = "label3";
            label3.Size = new Size(65, 21);
            label3.TabIndex = 4;
            label3.Text = "float 값";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 109);
            label4.Name = "label4";
            label4.Size = new Size(80, 21);
            label4.TabIndex = 5;
            label4.Text = "문자열 값";
            // 
            // ServerIP
            // 
            ServerIP.Location = new Point(93, 9);
            ServerIP.Name = "ServerIP";
            ServerIP.Size = new Size(100, 23);
            ServerIP.TabIndex = 6;
            // 
            // IntValue
            // 
            IntValue.Location = new Point(93, 47);
            IntValue.Name = "IntValue";
            IntValue.Size = new Size(100, 23);
            IntValue.TabIndex = 7;
            // 
            // FloatValue
            // 
            FloatValue.Location = new Point(93, 76);
            FloatValue.Name = "FloatValue";
            FloatValue.Size = new Size(100, 23);
            FloatValue.TabIndex = 8;
            // 
            // StringValue
            // 
            StringValue.Location = new Point(93, 107);
            StringValue.Name = "StringValue";
            StringValue.Size = new Size(100, 23);
            StringValue.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 139);
            Controls.Add(StringValue);
            Controls.Add(FloatValue);
            Controls.Add(IntValue);
            Controls.Add(ServerIP);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Send);
            Controls.Add(Connect);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Connect;
        private Button Send;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox ServerIP;
        private TextBox IntValue;
        private TextBox FloatValue;
        private TextBox StringValue;
    }
}