
# Database boilerplate code so that it can be reused within the whole program


class function
{
    protected SqlConnection GetConnection()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = "your_database_connection_here";
        return conn;
    }
    public DataSet GetData(string query)
    {
        SqlConnection conn = GetConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = query;
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds);
        return ds;
    }

    public void SetData(string query)
    {
        SqlConnection conn = GetConnection();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        conn.Open();
        cmd.CommandText = query;
        cmd.ExecuteNonQuery();
        conn.Close();
        MessageBox.Show("data processed sucessfully.", "sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}



# for login page

<!-- Function declaration -->

    function fn = new function();
    string query;

<!-- when button clicked check login credential from database-->

    query = "SELECT * FROM "table" WHERE username = '"++"' AND password = '"++"'";
    DataSet ds = fn.GetData(query);
    {
        if (ds.Tables[0].Rows.Count > 0)
        {
            //show ur homepage screen
            Form f2 = new FormHomePage();
            f2.Show();
        }
        else
        {
            MessageBox.Show("You are not granted access.");
        }
    }

# Adding items to the database Snippets

<!-- Function declaration -->

    function fn = new function();
    string query;

<!-- Query to add item_name and item_price to database -->

    //adding items to the database

    query = "insert into items (item_name,item_price) values ('" + textItemName.Text + "','" + textItemPrice.Text + "')";
    fn.SetData(query);


# Creating Bills and processing for the total amount (textchanged)

<!-- creating listbox and check for the "textchanged" to search the items --> 

    {
        listBox1.Items.Clear();
        query = "select item_name from items where item_name like'" + txtSearchBox.Text + "%'";
        DataSet ds = fn.GetData(query);

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());     //putting the search result that starts with letter 
        }
    }

#   add items details to above grid inorder to provide qty by the user to be added for the bill (SelectedIndexChanged)

    {
        textboxItemQuantity.ResetText();
        textBoxTotal.Clear();
        string text = listBox1.GetItemText(listBox1.SelectedItem);
        textboxItemName.Text = text;
        query = "select item_price from items where item_name = '" + text + "'";
        DataSet ds = fn.GetData(query);
        textboxItemPrice.Text = ds.Tables[0].Rows[0][0].ToString();  //adding selected items to the quantity changing grid
    }


# Change the total price above if the quantity is changed  (valueChanged)


    {
        if (decimal.TryParse(textboxItemPrice.Text, out decimal price))
        {
            decimal qty = textboxItemQuantity.Value;
            textBoxTotal.Text = (qty * price).ToString("0.##");    //calculation quantity * unitprice
        }
        else
        {
            MessageBox.Show("Invalid item price.");
        }
    }


# Add to cart Button clicked then push to the billing datagrid

    {
        // Add a new row to the DataGridView
        int n = dataGridView1.Rows.Add();

        // Add Bill row with item details
        dataGridView1.Rows[n].Cells[0].Value = textboxItemName.Text;
        dataGridView1.Rows[n].Cells[1].Value = textboxItemPrice.Text;
        dataGridView1.Rows[n].Cells[2].Value = textboxItemQuantity.Text;
        dataGridView1.Rows[n].Cells[3].Value = textBoxTotal.Text;

        // For decimal conversion
        string totalText = textBoxTotal.Text;

        // Try parsing the textBoxTotal.Text as a decimal
        if (decimal.TryParse(totalText, out decimal currentItemTotal))
        {
            // Add the current item total to the overall total
            total = total + currentItemTotal;

            // Update the label with the formatted total amount
            labelTotalAmount.Text = "Rs. " + total.ToString("0.00");
        }
        else
        {
            // Show an error message if the total value is invalid
            MessageBox.Show("Invalid total value. Please enter a valid decimal number.");
        }
    }

