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
    public partial class Product_Manager : Form
    {
        public Product_Manager()
        {
            InitializeComponent();
        }

        private void Product_Manager_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtAddId.Text);
            string name = " " + txtAddName.Text;
            int price = int.Parse(" " + txtAddPrice.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\malin\Documents\Newdb.mdf;Integrated Security=True;Connect Timeout=30");

            string addQry = "INSERT INTO Products (Id, Name, Price) VALUES (" + id + ",'" + name + "'," + price + ")";

            SqlCommand cmd = new SqlCommand(addQry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data added successfully!");
            }
            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSearchId.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\malin\Documents\Newdb.mdf;Integrated Security=True;Connect Timeout=30");

            string searchQry = "SELECT Name,Price FROM Products WHERE Id = " + id;

            //Code for retrieving data starts here
            SqlDataAdapter Adpt = new SqlDataAdapter(searchQry, con);

            DataSet login = new DataSet(); Adpt.Fill(login);

            try
            {
                con.Open();
                lblSearchName.Text = login.Tables[0].Rows[0]["Name"].ToString();
                lblSearchPrice.Text = login.Tables[0].Rows[0]["Price"].ToString();
                //Code for retrieving data ends here
                lblUpdateId.Text = txtSearchId.Text;
            }
            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSearchId.Text);
            string name = txtUpdateName.Text;
            int price = int.Parse(txtUpdatePrice.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\malin\Documents\Newdb.mdf;Integrated Security=True;Connect Timeout=30");

            string upQry = "UPDATE Products SET Name = '" + name + "', Price = " + price + "WHERE Id = " + id;

            SqlCommand cmd = new SqlCommand(upQry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data updated successfully!");
            }
            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void btnAddClear_Click(object sender, EventArgs e)
        {
            txtAddId.Text = "";
            txtAddName.Text = "";
            txtAddPrice.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtSearchId.Text);

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\malin\Documents\Newdb.mdf;Integrated Security=True;Connect Timeout=30");

            string delQry = "DELETE FROM Products WHERE Id = " + id;

            SqlCommand cmd = new SqlCommand(delQry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data deleted successfully!");
            }
            catch (SqlException SE)
            {
                MessageBox.Show(SE.ToString());
            }
            finally
            {
                txtSearchId.Text = "";
                lblSearchName.Text = "";
                lblSearchPrice.Text = "";
                con.Close();
            }
        }

        private void btnUpdateClear_Click(object sender, EventArgs e)
        {
            txtUpdateName.Text = "";
            txtUpdatePrice.Text = "";
        }

        private void btnSearchClear_Click(object sender, EventArgs e)
        {
            txtSearchId.Text = "";
            lblSearchName.Text = "";
            lblSearchPrice.Text = "";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
