using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class FormLogin : Form
    {
       
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string connStr = "Data Source=localhost;Initial Catalog=SuperMarketDB;Integrated Security=True";
           //创建连接对象将连接字符串作为构造方法的参数
           SqlConnection connection = new SqlConnection(connStr);
           string sql = string.Format("select count(*) from SIMS_user where userName='{0}' and userPwd='{1}'", userName.Text, passWord.Text);
           SqlCommand command = new SqlCommand(sql, connection);
           try
           {
               connection.Open();

               
                int i = (int)command.ExecuteScalar();
                if (i > 0)
                {
                    MessageBox.Show("登录成功！");
                    string UserName1 = userName.Text; //当前登录人员通过构造函数传值给FormMain和出入库页面
                    FormMain formMain = new FormMain(UserName1);
                    FormInstock fis = new FormInstock(UserName1);
                    FormOutstock fos = new FormOutstock(UserName1);
                    formMain.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或者密码错误，请重新输入");
                    userName.Focus();
                }
               
           }
           catch (SqlException ex)
           {

               MessageBox.Show(ex.Message);
           }
           finally
           {
               connection.Close();
              
           }
           
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            userName.Clear();
            passWord.Text = "";
            userName.Focus();

        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
       

      
    }
}
