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
    public partial class FormInstock : Form
    {
        private string UserName;//当前用户
        public FormInstock(string UserName1)
        {
            InitializeComponent();
            this.UserName = UserName1;
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            dataGridView1.DataSource = db.SISM_console;
        }

        private void FormInstock_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            SISM_console sc = new SISM_console();
            //查询是否存在该编号商品
            var num =(from m in db.SIMS_commodity
                        where m.CId==int.Parse(textBox1.Text)
                        select m).Count();
            //存在
            if (num > 0) { 
            //查询
                var q = (from m in db.SIMS_commodity
                         where m.CId == int.Parse(textBox1.Text)
                         select m);
                foreach (var c in q)
                {
                        sc.Number = textBox2.Text;
                        int number;//存放当前库存数目
                        number = int.Parse(c.CQty) + int.Parse(sc.Number);
                        c.CQty = number.ToString();
                        db.SubmitChanges();
                        label5.Text = "商品编号：" + c.CId + "\n" + "剩余库存：" + number + "\n" + "操作人：" + UserName;

                        //添加开始
                        sc.CId = int.Parse(textBox1.Text);
                        sc.Number = textBox2.Text;
                        sc.Price = textBox3.Text;
                        sc.Choose = "入库";
                        sc.UserName = UserName;
                        db.SISM_console.InsertOnSubmit(sc);
                        try
                        {
                            db.SubmitChanges();
                            dataGridView1.DataSource = db.SISM_console;
                            MessageBox.Show("入库成功！");

                        }
                        catch (Exception ex)
                        {

                        }
                        //添加结束

                        clean();
                    }
                }
            else MessageBox.Show("没有此编号商品！");
        }
        //清除文本框
        private void clean()
        {


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

    }
}
