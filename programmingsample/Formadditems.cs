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
    public partial class Formadditems : Form
    {
        function fn = new function();
        string query;
        public Formadditems()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adding items to the database

            query = "insert into items (item_name,item_price) values ('" + textBox1.Text + "','" + textBox2.Text + "')";
            fn.SetData(query);

        }
    }
}
