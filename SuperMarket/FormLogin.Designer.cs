namespace SuperMarket
{
    partial class FormLogin
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.passWord = new System.Windows.Forms.TextBox();
            this.userName = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "用户名:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "密码:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.passWord);
            this.groupBox1.Controls.Add(this.userName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(92, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(371, 242);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "登录信息";
            // 
            // passWord
            // 
            this.passWord.Location = new System.Drawing.Point(141, 153);
            this.passWord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.passWord.Name = "passWord";
            this.passWord.Size = new System.Drawing.Size(134, 25);
            this.passWord.TabIndex = 3;
            this.passWord.UseSystemPasswordChar = true;
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(141, 62);
            this.userName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(134, 25);
            this.userName.TabIndex = 2;
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(92, 395);
            this.Login.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 30);
            this.Login.TabIndex = 3;
            this.Login.Text = "登录";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(388, 395);
            this.Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 30);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 471);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "超市库存管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormLogin_FormClosing);
            this.Load += new System.EventHandler(this.FormLogin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox passWord;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button Cancel;
    }
}

