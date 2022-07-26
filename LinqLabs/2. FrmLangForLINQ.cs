using LinqLabs;
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
    public partial class FrmLangForLINQ : Form
    {
        public FrmLangForLINQ()
        {
            InitializeComponent();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int N1 = 100, N2 = 200;
            string S1 = "AAA", S2 = "BBB";
            MessageBox.Show(N1 + "," + N2 + "\n" + S1 + "," + S2);
            Cls_try.Swap(ref N1,ref N2);//ref 傳址
            Cls_try.Swap(ref S1,ref S2);//ref 傳址
            MessageBox.Show(N1 + "," + N2+"\n"+ S1 + "," + S2);
            MessageBox.Show(SystemInformation.ComputerName);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int N1 = 100, N2 = 200;
            string S1 = "AAA", S2 = "BBB";
            MessageBox.Show(N1 + "," + N2 + "\n" + S1 + "," + S2);
            Cls_try.AnyTypeSwap(ref N1, ref N2);//ref 傳址
            Cls_try.AnyTypeSwap<string>(ref S1, ref S2);//ref 傳址 <>可以不用寫
            MessageBox.Show(N1 + "," + N2 + "\n" + S1 + "," + S2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //具名
            buttonX.Click += ButtonX_Click;
            //buttonX.Click += aaa;
            //錯誤  CS0123  'aaa' 沒有任何多載符合委派 'EventHandler'
            //=====================

            //匿名
            buttonX.Click += delegate (object sender1, EventArgs e1)
                             {
                                 MessageBox.Show("匿名方法");
                             };
        }
        private void ButtonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ButtonX_Click");
        }
        //private void aaa(缺少簽名'EventHandler')
        //{
        //    MessageBox.Show("aaa");
        //} //錯誤1

    }
}
