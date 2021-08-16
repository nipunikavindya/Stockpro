using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Stockpro
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }


        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtdate;
            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset rs = new Reset();
            rs.StartPosition = FormStartPosition.CenterScreen;
            rs.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Delete dl = new Delete();
            dl.StartPosition = FormStartPosition.CenterScreen;
            dl.Show();
            this.Hide();
        }

        private void txtdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtproductcode.Focus();
            }
        }

        private void txtproductcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtproductcode.Text.Length > 0)
                {
                    txtproductname.Focus();
                }
                else
                {
                    txtproductcode.Focus();
                }
            }
        }

        private void txtproductname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtproductname.Text.Length > 0)
                {
                    txtproductcategory.Focus();
                }
                else
                {
                    txtproductname.Focus();
                }
            }
        }

        private void txtproductcategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtproductcategory.Text.Length > 0)
                {
                    txtproducttype.Focus();
                }
                else
                {
                    txtproductcategory.Focus();
                }
            }
        }

        private void txtproducttype_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtproducttype.Text.Length > 0)
                {
                    txtsupplier.Focus();
                }
                else
                {
                    txtproducttype.Focus();
                }
            }
        }

        private void txtsupplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtsupplier.Text.Length > 0)
                {
                    txtquantity.Focus();
                }
                else
                {
                    txtsupplier.Focus();
                }
            }
        }

        private void txtquantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtquantity.Text.Length > 0)
                {
                    comboBox1.Focus();
                }
                else
                {
                    txtquantity.Focus();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (comboBox1.Text.Length > 0)
                {
                    txtdate.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
        }

        private void txtproductcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void txtquantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ProductCode = int.Parse(txtproductcode.Text);
            string ProductName = txtproductname.Text;
            string ProductCategory = txtproductcategory.Text;
            string ProductType = txtproducttype.Text;
            string Supplier = txtsupplier.Text;
            int Quantity = int.Parse(txtquantity.Text);
            string Date = DateTime.Now.ToString();
            string Status = comboBox1.Text;

             if (txtdate.Text == "")
             {
                 MessageBox.Show("Date Required |", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
             }
            else if (txtproductcode.Text == "")
            {
                MessageBox.Show("Product Code Required|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtproductname.Text == "")
            {
                MessageBox.Show("Product Name Required|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtproductcategory.Text == "")
            {
                MessageBox.Show("Product Category Required|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtproducttype.Text == "")
            {
                MessageBox.Show("Product Type Required|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtsupplier.Text == "")
            {
                MessageBox.Show("Product Supplier Required|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtquantity.Text == "")
            {
                MessageBox.Show("Product Quantity Required|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Select Status|", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                string qry = "INSERT INTO StockDetails Values(" + ProductCode + ",'" + ProductName + "','" + ProductCategory + "','" + ProductType + "','" + Supplier + "'," + Quantity + ",'" + Date + "','" + Status + "') ";
                DatabaseConnection OBjDB = new DatabaseConnection();

                string feedaback = OBjDB.DataConnection(qry);
                MessageBox.Show(feedaback);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtsearch.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT  * FROM StockDetails";

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(qry, Con);
                DataTable ds = new DataTable();

                sda.Fill(ds);
                // DGV1.DataSource = dt.Tables["StockDetails"];
                DGV2.Rows.Clear();

                foreach (DataRow item in ds.Rows)
                {
                    int n = DGV2.Rows.Add();
                    DGV2.Rows[n].Cells["col1"].Value = item["ProductName"].ToString();
                    DGV2.Rows[n].Cells["col2"].Value = int.Parse(item["Quantity"].ToString());
                }
               
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
           string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT  * FROM StockDetails";

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(qry, Con);
                DataTable ds = new DataTable();

                sda.Fill(ds);
                // DGV1.DataSource = dt.Tables["StockDetails"];
                DGV1.Rows.Clear();

                foreach (DataRow item in ds.Rows)
                {
                    int n = DGV1.Rows.Add();
                    DGV1.Rows[n].Cells["Column1"].Value = n + 1;
                    DGV1.Rows[n].Cells["Column2"].Value = item["ProductCode"].ToString();
                    DGV1.Rows[n].Cells["Column3"].Value = item["ProductName"].ToString();
                    DGV1.Rows[n].Cells["Column4"].Value = item["ProductCategory"].ToString();
                    DGV1.Rows[n].Cells["Column5"].Value = item["ProductType"].ToString();
                    DGV1.Rows[n].Cells["col6"].Value = item["Supplier"].ToString();
                    DGV1.Rows[n].Cells["Column7"].Value = int.Parse(item["Quantity"].ToString());
                    DGV1.Rows[n].Cells["Column8"].Value = Convert.ToDateTime(item["Date"].ToString()).ToString("dd/MM/yyyy");
                    DGV1.Rows[n].Cells["Column9"].Value = item["Status"].ToString();
                    /* if ((bool)item["Status"])
                     {
                         DGV1.Rows[n].Cells["Column9"].Value = "Active";
                     }
                     else
                     {
                         DGV1.Rows[n].Cells["Column9"].Value = "Deactive";
                     }*/
                }
                

            }           
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
            
        }

        private void ResetRecords()
        {
            txtdate.Value = DateTime.Now;
            txtproductcode.Clear();
            txtproductname.Clear();
            txtproductcategory.Clear();
            txtproducttype.Clear();
            txtsupplier.Clear();
            txtquantity.Clear();
            comboBox1.SelectedIndex = -1;
            button3.Text = "Add";
            txtdate.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ResetRecords();
        }

        //error provider//
        /* private bool Validation()
         {
             bool result = false;
             if(string.IsNullOrEmpty(txtproductcode.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(txtproductcode, "Product Code Required");
             }
             else if (string.IsNullOrEmpty(txtproductname.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(txtproductname, "Product Name Required");
             }
             else if (string.IsNullOrEmpty(txtproductcategory.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(txtproductcategory, "Product Category Required");
             }
             else if (string.IsNullOrEmpty(txtproducttype.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(txtproducttype, "Product Type Required");
             }
             else if (string.IsNullOrEmpty(txtsupplier.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(txtsupplier, "Product Supplier Required");
             }
             else if (string.IsNullOrEmpty(txtquantity.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(txtquantity, "Product Quantity Required");
             }
             else if (string.IsNullOrEmpty(comboBox1.Text))
             {
                 ErrorProvider.Clear();
                 ErrorProvider.SetError(comboBox1, "Select Status");
             }
             else
             {
                 ErrorProvider.Clear();
                 result = true;
             }
             return result;
         }*/

        
        
    }
}


    

