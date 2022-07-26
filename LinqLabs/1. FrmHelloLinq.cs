using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starter
{
    public partial class FrmHelloLinq : Form
    {
        public FrmHelloLinq()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            //System.Collections.Generic.IEnumerator<T> GetEnumerator()
            //System.Collections.Generic.IEnumerable<T> 的成員
            //摘要:
            //傳回逐一查看集合的列舉值。
            //傳回:
            //可用來逐一查看集合的列舉值。
            //foreach = 語法糖

            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach(int m in nums) 
            {
                listBox1.Items.Add(m);
            }
            listBox1.Items.Add("=================");
            // foreach背後使用GetEnumerator寫法(C#轉譯)
            System.Collections.IEnumerator en = nums.GetEnumerator();
            while (en.MoveNext()) 
            {
                listBox1.Items.Add(en.Current); 
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 ,10,11,12,13,14,15};
            foreach (int n in list)
            {
                listBox1.Items.Add(n);
            }
            listBox1.Items.Add("=================");
            // C#轉譯
            List<int>.Enumerator en = list.GetEnumerator();

            while (en.MoveNext())
            {
                listBox1.Items.Add(en.Current);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //1.定義來源物件
            //2.定義query
            //3.執行query
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };//來源物件
            listBox1.Items.Clear();
            IEnumerable<int> q = from n in nums
                                 //where n >=5 && n<=10
                                 where n <3||n>13
                                 select n;//定義
            foreach(int n in q)
            {
                listBox1.Items.Add(n);
                //執行
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };//來源物件
            listBox1.Items.Clear();
            IEnumerable<int> q = from n in nums
                                 where IsEven(n)
                                 select n;
            foreach (int n in q)
                listBox1.Items.Add(n);
        }

        bool IsEven(int n)
        {
            //if (n % 2 == 0)
            //    return true;
            //else
            //    return false;
            return n % 2 == 0;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };//來源物件
            listBox1.Items.Clear();

            //可以使用任意型別，須注意前後是否相同
            IEnumerable<Point> q = from n in nums
                                   where IsEven(n)
                                   select new Point(n , n*n);

            //執行query - foreach(....)
            foreach (Point n in q)
                listBox1.Items.Add(n);

            //執行query - 集合.ToList()
            dataGridView1.DataSource = q.ToList();

            //執行query - 圖表
            chart1.DataSource = q;
            chart1.Series[0].XValueMember = "X";
            chart1.Series[0].YValueMembers = "Y";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] word = { "a", "ab", "abc", "abcd", "abcde" ,"Cdwera"};
            IEnumerable<string> W = from n in word
                                    where n.Contains("c") // contains()-> 模糊搜尋
                                    orderby n descending //排序
                                    select n ;
            foreach (string n in W)
                listBox1.Items.Add(n);

            //var SS = word.Where(delegate-obj).select(....); // where 屬於
        }

        private void button8_Click(object sender, EventArgs e)
        {
            productsTableAdapter1.Fill(dataSet11.Products);

            var q = from p in dataSet11.Products
                    where p.UnitPrice > 20 && p.ProductName.StartsWith("C")
                    select p;
            dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ordersTableAdapter1.Fill(dataSet11.Orders);

            var O = from p in dataSet11.Orders
                    where p.OrderDate.Year == 1997 && p.OrderDate.Month >= 1 && p.OrderDate.Month<=3
                    select p;
            dataGridView1.DataSource = O.ToList();
        }
    }
}
