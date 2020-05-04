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
    public partial class FormCommodityMangment : Form
    {
        public string sPicture;
        public FormCommodityMangment()
        {
            InitializeComponent();
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            dataGridView1.DataSource = db.SIMS_commodity;
            var q = (from m in db.SISM_commodityclass
                     select m
                       );
            foreach (var c in q) {

                comboBox1.Items.Add(c.SName);
            }
        }

        private void FormCommodityMangment_Load(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            sPicture = @"..\..\image\薯片.jpg";
            pictureBox1.Image = Image.FromFile(sPicture);
           

          
        }

        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            if (radioButton1.Checked)
            {

                var q = (from m in db.SIMS_commodity
                         where m.CId == int.Parse(textBox6.Text)
                         select m);
                foreach (var c in q)
                {

                    textBox7.Text = c.CId.ToString();
                    textBox1.Text = c.CName;
                    textBox2.Text = c.CBuyPrice;
                    textBox3.Text = c.CSalePrice;
                    textBox4.Text = c.CQty;
                    textBox5.Text = c.CNote;
                    comboBox1.Text = c.CType;
                    sPicture = c.CPicture;
                }

            }
            else if (radioButton2.Checked)
            {

                var q = (from m in db.SIMS_commodity
                         where m.CName == textBox6.Text
                         select m);
                foreach (var c in q)
                {

                    textBox7.Text = c.CId.ToString();
                    textBox1.Text = c.CName;
                    textBox2.Text = c.CBuyPrice;
                    textBox3.Text = c.CSalePrice;
                    textBox4.Text = c.CQty;
                    textBox5.Text = c.CNote;
                    comboBox1.Text = c.CType;
                    sPicture = c.CPicture;
                }
            }
            else MessageBox.Show("请选择查询条件！");
            pictureBox1.Image.Dispose();
            pictureBox1.Image =Image.FromFile(sPicture);
        }

        //添加
        private void button1_Click(object sender, EventArgs e) 
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            SIMS_commodity sc = new SIMS_commodity();
            if (textBox7.Text != "")
            {
                sc.CId = int.Parse(textBox7.Text);
                sc.CName = textBox1.Text;
                sc.CBuyPrice = textBox2.Text;
                sc.CSalePrice = textBox3.Text;
                sc.CQty = textBox4.Text;
                sc.CNote = textBox5.Text;
                sc.CPicture = sPicture;
                sc.CType = comboBox1.Text;

                db.SIMS_commodity.InsertOnSubmit(sc);
                try
                {
                    db.SubmitChanges();
                    dataGridView1.DataSource = db.SIMS_commodity;
                    MessageBox.Show("添加成功！");
                    clear();
                }
                catch (Exception ex)
                {

                }
            }
            else MessageBox.Show("请输入添加信息！");
            

        }

        //图片选择
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                sPicture = ofd.FileName;
                pictureBox1.Image = Image.FromFile(sPicture);
            }
        }

      
        //删除
        private void button4_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
                 //根据id删除
            if (textBox7.Text != "") {

                var q = (from m in db.SIMS_commodity
                         where m.CId == int.Parse(textBox7.Text)
                         select m);
                foreach (var id in q)
                {
                    db.SIMS_commodity.DeleteOnSubmit(id);
                }
                var num = (from m in db.SIMS_commodity
                         where m.CId == int.Parse(textBox7.Text)
                         select m).Count();
                if (num > 0)
                {
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("删除成功！");
                        dataGridView1.DataSource = db.SIMS_commodity;
                        clear();


                    }
                    catch (Exception ex)
                    {

                    }
                }
                else MessageBox.Show("没有此编号的商品！");
                
            }
            else if (textBox1.Text != "")
            {

                //根据名称删除
                var p = (from m in db.SIMS_commodity
                         where m.CName == textBox1.Text
                         select m);
                foreach (var name in p)
                {
                    db.SIMS_commodity.DeleteOnSubmit(name);
                }
                var num = (from m in db.SIMS_commodity
                           where m.CName == textBox1.Text
                           select m).Count();
                if (num > 0)
                {
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("删除成功！");
                        dataGridView1.DataSource = db.SIMS_commodity;
                        clear();


                    }
                    catch (Exception ex)
                    {

                    }
                }
                else MessageBox.Show("没有此名字的商品！");
            }

            else
            {
                MessageBox.Show("请输入删除条件！");
            }
             
        }

        //清除文本框内信息
        public void clear() {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox7.Focus();
        }

        //更新
        private void button2_Click(object sender, EventArgs e)
        {
            SuperMarketDataClassesDataContext db = new SuperMarketDataClassesDataContext();
            if (textBox7.Text != "")
            {
                var q = (from m in db.SIMS_commodity
                         where m.CId == int.Parse(textBox7.Text)
                         select m);
                foreach (var c in q)
                {

                    c.CId = int.Parse(textBox7.Text);
                    c.CName = textBox1.Text;
                    c.CBuyPrice = textBox2.Text;
                    c.CSalePrice = textBox3.Text;
                    c.CQty = textBox4.Text;
                    c.CNote = textBox5.Text;
                    c.CPicture = sPicture;
                    c.CType = comboBox1.Text;
                }
                var num = (from m in db.SIMS_commodity
                           where m.CId == int.Parse(textBox7.Text)
                           select m).Count();
                if (num > 0)
                {
                    try
                    {
                        db.SubmitChanges();
                        MessageBox.Show("更新成功！");
                        dataGridView1.DataSource = db.SIMS_commodity;

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            else MessageBox.Show("请输入需更新的商品编号！");
            
            
        }

     

    }
}
