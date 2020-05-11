using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateTest
{
    public partial class LotteryForm : Form
    {
        List<Label> list = new List<Label>();
        public LotteryForm()
        {
            InitializeComponent();
            //Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void LotteryForm_Load(object sender, EventArgs e)
        {
            //创建6个Label显示数字滚动
            for (int i = 0; i < 6; i++)
            {
                Label label = new Label();
                label.Text = "0";
                label.Visible = true;
                label.AutoSize = true;
                label.Location = new Point(50 + i * 50, 100);
                list.Add(label);
                this.Controls.Add(label);
            }

            Button b = new Button();
            b.Visible = true;
            b.Location = new Point(50, 200);
            b.Text = "Start";
            b.Click += B_Click;
            this.Controls.Add(b);


            Button c = new Button();
            c.Visible = true;
            c.Location = new Point(200, 200);
            c.Text = "Stop";
            c.Click += C_Click;
            this.Controls.Add(c);
        }
        bool IsStop = true;
        private void C_Click(object sender, EventArgs e)
        {
            IsStop = true;
        }

        private void B_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(()=>
            {
                var random = new Random();
                while (!IsStop)
                {
                    foreach (var item in list)
                    {
                        if (item.InvokeRequired)//当在非创建控件线程获取为true
                        {
                            item.Invoke(new Action<Label, string>(SetLabelText), item, random.Next(1, 10).ToString());
                        }
                        else
                        {
                            item.Text = random.Next(1, 10).ToString();
                        }                       
                    }
                    Thread.Sleep(50);
                }
            });

            thread.IsBackground = true;
            IsStop = false;
            thread.Start();
        }

        private void SetLabelText(Label label, string text)
        {
            label.Text = text;
        }
    }
}
