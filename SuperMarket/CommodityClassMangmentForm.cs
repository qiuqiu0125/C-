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
    public partial class CommodityClassMangmentForm : Form
    {
        public CommodityClassMangmentForm()
        {
            InitializeComponent();
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            dataGridView1.DataSource = db.SISM_commodityclass;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CommodityClassMangmentForm_Load(object sender, EventArgs e)
        {

        }

        //添加
        private void button1_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            SISM_commodityclass scc = new SISM_commodityclass();
            if (textBox4.Text != "")
            {
                scc.SId = int.Parse(textBox4.Text);
                scc.SName = textBox2.Text;
                scc.SNote = textBox3.Text;
                db.SISM_commodityclass.InsertOnSubmit(scc);
                try
                {
                    db.SubmitChanges();
                    dataGridView1.DataSource = db.SISM_commodityclass;
                    MessageBox.Show("添加成功！");
                    clear();
                }
                catch (Exception ex)
                {

                }
            }
            else MessageBox.Show("请输入添加信息！");
            

        }

        //清除文本框内容
        public void clear()
        {

            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
        }

        //删除
        private void button4_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            //id删除
            if (textBox4.Text != "") {

                var q = (from m in db.SISM_commodityclass
                         where m.SId == int.Parse(textBox4.Text)
                         select m);
                foreach (var id in q)
                {
                    db.SISM_commodityclass.DeleteOnSubmit(id);
                }
                var num = (from m in db.SISM_commodityclass
                           where m.SId == int.Parse(textBox4.Text)
                           select m).Count();
                if (num > 0)
                {
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("删除成功！");
                        dataGridView1.DataSource = db.SISM_commodityclass;
                        clear();


                    }
                    catch (Exception ex)
                    {

                    }
                }
                else MessageBox.Show("没有此类别号的商品！");
            }
            else if (textBox2.Text != "")
            { //根据名称删除
                var p = (from m in db.SISM_commodityclass
                         where m.SName == textBox2.Text
                         select m);
                foreach (var name in p)
                {
                    db.SISM_commodityclass.DeleteOnSubmit(name);
                }
                var num = (from m in db.SISM_commodityclass
                           where m.SName == textBox2.Text
                           select m).Count();
                if (num > 0)
                {
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("删除成功！");
                        dataGridView1.DataSource = db.SISM_commodityclass;
                        clear();


                    }
                    catch (Exception ex)
                    {

                    }
                }
                else MessageBox.Show("没有此类别的商品！");
            }
            else MessageBox.Show("请输入删除条件");

        }

        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            if (radioButton1.Checked)
            {
                var q = (from m in db.SISM_commodityclass
                         where m.SId == int.Parse(textBox1.Text)
                         select m);
                foreach (var c in q)
                {

                    textBox4.Text = c.SId.ToString();
                    textBox2.Text = c.SName;
                    textBox3.Text = c.SNote;
                }
            }
            else if (radioButton2.Checked)
            {
                var q = (from m in db.SISM_commodityclass
                         where m.SName == textBox1.Text
                         select m);
                foreach (var name in q)
                {

                    textBox4.Text = name.SId.ToString();
                    textBox2.Text = name.SName;
                    textBox3.Text = name.SNote;
                }
            }
            else MessageBox.Show("请输入查询条件！");
        }

        //更新
        private void button2_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            if (textBox4.Text != "")
            {
                var q = (from m in db.SISM_commodityclass
                         where m.SId == int.Parse(textBox4.Text)
                         select m);
                foreach (var c in q)
                {

                    c.SId = int.Parse(textBox4.Text);
                    c.SName = textBox2.Text;
                    c.SNote = textBox3.Text;
                    
                }
                var num = (from m in db.SISM_commodityclass
                           where m.SId == int.Parse(textBox4.Text)
                           select m).Count();
                if (num > 0)
                {
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("更新成功！");
                        dataGridView1.DataSource = db.SISM_commodityclass;

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            else MessageBox.Show("请输入需更新的类别编号！");
        }
    }
}
