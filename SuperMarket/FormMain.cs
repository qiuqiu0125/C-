using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class FormMain : Form
    {
        private string  UserName; //当前登录人员
        public FormMain(string UserName1)
        {
            InitializeComponent();
            this.UserName = UserName1;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UserName == "郑秋")
            {

                FormUserMangment fum = new FormUserMangment();
                fum.MdiParent = this;
                fum.WindowState = FormWindowState.Maximized;
                fum.Show();
                toolStripStatusLabel2.Text = "当前操作：用户管理";
            }
            else
            {
                MessageBox.Show("您不是管理员!");
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "当前用户：" + UserName;
        }

        private void 商品类别管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommodityClassMangmentForm ccmf = new CommodityClassMangmentForm();
            ccmf.MdiParent = this;
            ccmf.WindowState = FormWindowState.Maximized;
            ccmf.Show();
            toolStripStatusLabel2.Text = "当前操作：商品类别管理";
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCommodityMangment fcm = new FormCommodityMangment();
            fcm.MdiParent = this;
            fcm.WindowState = FormWindowState.Maximized;
            fcm.Show();
            toolStripStatusLabel2.Text = "当前操作：商品管理";
        }

        private void 入库操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInstock fi = new FormInstock(UserName);
            fi.MdiParent = this;
            fi.WindowState = FormWindowState.Maximized;
            fi.Show();
            toolStripStatusLabel2.Text = "当前操作：入库操作";
        }

        private void 出库操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOutstock fo = new FormOutstock(UserName);
            fo.MdiParent = this;
            fo.WindowState = FormWindowState.Maximized;
            fo.Show();
            toolStripStatusLabel2.Text = "当前操作：出库操作";
        }

        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FormLogin fl =new FormLogin();

            this.Hide();
            fl.Show();
            
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("软件1173 郑秋 05");
            toolStripStatusLabel2.Text = "当前操作：关于";
        }


       
        
            
        
    }
}
