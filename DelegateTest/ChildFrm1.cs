using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateTest
{
    public delegate void SetText(string text);
    class ChildFrm1 : Form
    {
        private TextBox textBox;
        private Button button;
        public List<ICaremsg> list = new List<ICaremsg>();

        public SetText setText;
        public ChildFrm1()
        {
            InitializeComponent();
            this.button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            //foreach (var item in list)
            //{
            //    item.SetText(textBox.Text);
            //}
            setText(this.textBox.Text);

        }

        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(100, 100);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(100, 25);
            this.textBox.TabIndex = 0;
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(200, 101);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(75, 25);
            this.button.TabIndex = 1;
            this.button.Text = "Send";
            // 
            // ChildFrm1
            // 
            this.ClientSize = new System.Drawing.Size(628, 346);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.button);
            this.Name = "ChildFrm1";
            this.Load += new System.EventHandler(this.ChildFrm1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void ChildFrm1_Load(object sender, EventArgs e)
        {

        }
    }
}
