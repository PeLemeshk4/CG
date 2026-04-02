using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace КГ.Forms
{
    public partial class EnterNumber : Form
    {
        public int Value
        {
            get
            {
                return (int)EnterValueNUP.Value;
            }
        }

        public EnterNumber(string nameValue, int min, int max)
        {
            InitializeComponent();

            EnterValueL.Text = nameValue + ":";
            EnterValueNUP.Minimum = min;
            EnterValueNUP.Maximum = max;
        }

        private void OkB_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void CancelB_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
