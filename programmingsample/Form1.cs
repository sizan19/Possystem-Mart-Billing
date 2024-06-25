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
    public partial class Form1 : Form

    {
        function fn = new function();
        string query;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            query = "SELECT * FROM Login WHERE username = '"+textBox1.Text+ "' AND password = '"+textBox2.Text+ "'";
            DataSet ds = fn.GetData(query);
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //show ur homepage screen
                    Form f2 = new Formdashboard();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("You are not granted access.");
                }
            }

        }
    }
}
