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

        private void button2_Click(object sender, EventArgs e)
        {
            Delete dl = new Delete();
            dl.StartPosition = FormStartPosition.CenterScreen;
            dl.Show();
            this.Hide(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Reset rs = new Reset();
            rs.StartPosition = FormStartPosition.CenterScreen;
            rs.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ProductCode = int.Parse(txtproductcode.Text);
            string ProductName = txtproductname.Text;
            string ProductCategory = txtproductcategory.Text;
            string ProductType = txtproducttype.Text;
            string Supplier = txtsupplier.Text;
            int Quantity = int.Parse(txtquantity.Text);
            DateTime Date = DateTime.Parse(txtdate.Text);


            if (txtproductcode.Text == "" | ProductName == "" | ProductCategory == "" | ProductType == "" | Supplier == "" | txtquantity.Text == "" | txtdate.Text == "")
            {
                MessageBox.Show("Please Fill the Fields");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(txtproductcode.Text, "[^0-9]"))
            {
                MessageBox.Show("Product Code should only be Numbers");
            }

            else if (System.Text.RegularExpressions.Regex.IsMatch(txtquantity.Text, "[^0-9]"))
            {
                MessageBox.Show("Quantity should only be Numbers");
            }

            /*else if (System.Text.RegularExpressions.Regex.IsMatch(txtdate.Text, "[^0-9]"))
            {
                MessageBox.Show("Date should only be Numbers");
            }*/

            else
            {
                /*int ProductCode = int.Parse(txtproductcode.Text);
                int Quantity = int.Parse(txtquantity.Text);
                int Date = int.Parse(txtdate.Text);*/

                string qry = "INSERT INTO StockDetails Values(" + ProductCode + ",'" + ProductName + "','" + ProductCategory + "','" + Supplier + "'," + Quantity + "," + Date + ") ";
                DatabaseConnection OBjDB = new DatabaseConnection();

                string feedaback = OBjDB.DataConnection(qry);
                MessageBox.Show(feedaback);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtproductcode.Text = "";
            txtproductname.Text = "";
            txtproductcategory.Text = "";
            txtproducttype.Text = "";
            txtsupplier.Text = "";
            txtquantity.Text = "";
            txtdate.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string Con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\lec13.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT  * FROM StockDetails";

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(qry, Con);
                DataSet dt = new DataSet();

                sda.Fill(dt, "StockDetails");
                DGV1.DataSource = dt.Tables["StockDetails"];

                /*foreach (DataRow item in dt.Rows)
                 {
                     int n = DGV1.Rows.Add();
                     DGV1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                     DGV1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                     if ((bool)item["ProductStatus"])
                     {
                         DGV1.Rows[n].Cells[2].Value = "Active";
                     }
                     else
                     {
                         DGV1.Rows[n].Cells[2].Value = "Deactive";
                     }
                 }*/
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtsearch.Text = "";
        }
    }
    }

