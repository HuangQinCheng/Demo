using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelegateTest
{
    public partial class MainFrm : Form
    {
        internal ChildFrm1 childFrm1 { get; set; }
        internal ChildFrm2 childFrm2 { get; set; }
       
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            childFrm1 = new ChildFrm1();
            childFrm1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            childFrm2 = new ChildFrm2();
            childFrm1.list.Add(childFrm2);
            childFrm1.setText += childFrm2.SetText;
            childFrm2.Show();
        }
    }
}
