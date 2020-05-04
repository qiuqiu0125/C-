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
    public partial class FormUserMangment : Form
    {
        public FormUserMangment()
        {
            InitializeComponent();
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            dataGridView1.DataSource = db.SIMS_user;
        }

        private void FormUserMangment_Load(object sender, EventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            SIMS_user user = new SIMS_user();
            user.userName = userName.Text;
            user.userPwd = passWord.Text;
            if (radioButton1.Checked)

                user.userSex = "男";
            else if (radioButton2.Checked)

                user.userSex = "女";
            user.userPhone = phone.Text;
            user.note = remarks.Text;
            db.SIMS_user.InsertOnSubmit(user);
            try
            {
                db.SubmitChanges();
                MessageBox.Show("添加成功！");
                dataGridView1.DataSource = db.SIMS_user;


            }
            catch (Exception ex)
            {

            }

        }

        private void revise_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            var q = (from m in db.SIMS_user
                     where m.userName == userName.Text
                     select m);
            foreach (var c in q)
            {
                c.userName = userName.Text;
                c.userPwd = passWord.Text;
                if (radioButton1.Checked)

                    c.userSex = "男";
                else if (radioButton2.Checked)

                    c.userSex = "女";
                c.userPhone = phone.Text;
                c.note = remarks.Text;
                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("更新成功！");
                    dataGridView1.DataSource = db.SIMS_user;

                }
                catch (Exception ex)
                {

                }
            }
        }

        private void delete_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            var q = (from m in db.SIMS_user
                     where m.userName == userName.Text
                     select m);
            foreach (var user in q)
            {

                db.SIMS_user.DeleteOnSubmit(user);
            }
            try
            {
                db.SubmitChanges();
                MessageBox.Show("删除成功！");
                dataGridView1.DataSource = db.SIMS_user;


            }
            catch (Exception ex)
            {
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            var q = (from m in db.SIMS_user
                     where m.userName == userName.Text
                     select m);
            foreach (var c in q) {
                userName.Text = c.userName;
                passWord.Text = c.userPwd;
                phone.Text = c.userPhone;
                remarks.Text = c.note;
                if (c.userSex == "男")
                    radioButton1.Checked = true;
                if(c.userSex == "女")
                    radioButton2.Checked = true;
            }
        }
    }
}
