using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqLabs
{
    public partial class Frm作業 : Form
    {
        public Frm作業()
        {
            InitializeComponent();
        }
        int front, num,back;
        private void Frm作業_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'northwindDataSet.Order_Details' 資料表。您可以視需要進行移動或移除。
            num = int.Parse(textBox1.Text);
            ordersTableAdapter1.Fill(DsOrder.Orders);
            var O_show = from o in DsOrder.Orders
                         group o by o.OrderDate.Year into g
                         select g;
            dataGridView1.DataSource = O_show.ToList();
            foreach (DataGridViewRow R in dataGridView1.Rows)
            {
                Cb_year.Items.Add(R.Cells[0].Value.ToString());
            }
            CClean();



        }
        void CClean()
        {
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            //num = int.Parse(textBox1.Text);
            //front = 0;
            //將已寫入資料清除
        }
        private void btn_DataShow(object sender, EventArgs e)
        {
            CClean();

            ordersTableAdapter1.Fill(DsOrder.Orders);
            order_DetailsTableAdapter1.Fill(DsOrder.Order_Details);

            var O_show = from o in DsOrder.Orders
                         select o;

            var Od_show = from od in DsOrder.Order_Details
                          select od;

            dataGridView1.DataSource = O_show.Take(num).ToList();
            dataGridView2.DataSource = Od_show.Take(num).ToList();
            //讀取兩個資料表的資料

        }

        private void button6_Click(object sender, EventArgs e)
        {
            CClean();
            ordersTableAdapter1.Fill(DsOrder.Orders);
            order_DetailsTableAdapter1.Fill(DsOrder.Order_Details);

            var O_show = from o in DsOrder.Orders
                         where o.OrderDate.Year.ToString() == Cb_year.Text
                         select o;

            var Od_show = from od in DsOrder.Order_Details
                          join o in DsOrder.Orders
                          on od.OrderID equals o.OrderID
                          where o.OrderDate.Year.ToString() == Cb_year.Text
                          select od;

            dataGridView1.DataSource = O_show.Take(num).ToList();
            dataGridView2.DataSource = Od_show.Take(num).ToList();
            //選取特定條件的資料
        }
        private void button7_Click(object sender, EventArgs e)
        {
            page(0);
            //上一頁
        }
        private void button8_Click(object sender, EventArgs e)
        {
            page(1);
            //下一頁
        }

        private void button9_Click(object sender, EventArgs e)
        {
            num = int.Parse(textBox1.Text);
        }

        void page(int N) 
        {
            CClean();
            ordersTableAdapter1.Fill(DsOrder.Orders);
            order_DetailsTableAdapter1.Fill(DsOrder.Order_Details);
            back = num;
            if (N == 1 )
            {
                front += num;
                if (DsOrder.Orders.Rows.Count <= front)
                {
                    front -= num;
                    back = DsOrder.Orders.Rows.Count - front;
                    MessageBox.Show("資料已顯示到底");
                }
            }
            else if (N == 0 && front >= num )
            {
                front -= num;
            }
            else 
                MessageBox.Show("資料已顯示到頂"); 
            //判定是上/下頁及輸入值及是否到達資料極限(頂及尾)




            var O_show = from o in DsOrder.Orders
                         select o;

            var Od_show = from od in DsOrder.Order_Details
                          select od;

            dataGridView1.DataSource = O_show.Skip(front).Take(num).ToList();
            dataGridView2.DataSource = Od_show.Skip(front).Take(num).ToList();
        }

        

       
    }
}
