using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace programmingsample
{
    public partial class Formdashboard : Form
    {
        public Formdashboard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //to make the manage button open formadditems
            Form f3 = new Formadditems();
            f3.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f4 = new Formbilling();
            f4.Show();
        }
    }
}
