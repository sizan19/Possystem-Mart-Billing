using System;
using System.Collections;
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
    public partial class Formbilling : Form
    {
        function fn = new function();
        string query;
        public Formbilling()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            {
                listBox1.Items.Clear();
                query = "select item_name from items where item_name like'" + textBox1.Text + "%'";
                DataSet ds = fn.GetData(query);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());     //putting the search result that starts with letter 
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                numericUpDown1.ResetText();
                textBox5.Clear();
                string text = listBox1.GetItemText(listBox1.SelectedItem);
                textBox2.Text = text;
                query = "select item_price from items where item_name = '" + text + "'";
                DataSet ds = fn.GetData(query);
                textBox4.Text = ds.Tables[0].Rows[0][0].ToString();  //adding selected items to the quantity changing grid
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            {
                if (decimal.TryParse(textBox4.Text, out decimal price))
                {
                    decimal qty = numericUpDown1.Value;
                    textBox5.Text = (qty * price).ToString("0.##");    //calculation quantity * unitprice
                }
                else
                {
                    MessageBox.Show("Invalid item price.");
                }
            }
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private decimal total = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            {
                // Add a new row to the DataGridView
                int n = dataGridView1.Rows.Add();

                // Add Bill row with item details
                dataGridView1.Rows[n].Cells[0].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox4.Text;
                dataGridView1.Rows[n].Cells[2].Value = numericUpDown1.Text;
                dataGridView1.Rows[n].Cells[3].Value = textBox5.Text;

                // For decimal conversion
                string totalText = textBox5.Text;

                // Try parsing the textBoxTotal.Text as a decimal
                if (decimal.TryParse(totalText, out decimal currentItemTotal))
                {
                    // Add the current item total to the overall total
                    total = total + currentItemTotal;

                    // Update the label with the formatted total amount
                    label8.Text = "Rs. " + total.ToString("0.00");
                }
                else
                {
                    // Show an error message if the total value is invalid
                    MessageBox.Show("Invalid total value. Please enter a valid decimal number.");
                }
            }

        }
    }
}
