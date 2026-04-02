using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void Lab1B_Click(object sender, EventArgs e)
        {
            LAB1 form = new LAB1();
            form.ShowDialog();
        }

        private void Lab2B_Click(object sender, EventArgs e)
        {
            LAB2 form = new LAB2();
            form.ShowDialog();
        }
    }
}
