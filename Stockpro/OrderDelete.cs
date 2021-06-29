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
    public partial class OrderDelete : Form
    {
        public OrderDelete()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int OrderID = int.Parse(txtID.Text);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30");
            string delete = "DELETE FROM NewItem WHERE OrderID =" + OrderID + "";
            SqlCommand cmd = new SqlCommand(delete, con);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Item Data Deleted Successfully");

            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }

            finally
            {
                con.Close();
            }


            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30");
            string del = "DELETE FROM NewOrderDetails WHERE OrderID =" + OrderID + "";
            SqlCommand comd = new SqlCommand(del, conn);

            try
            {
                conn.Open();
                comd.ExecuteNonQuery();
                MessageBox.Show("New Order Details Data Deleted Successfully");

            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }

            finally
            {
                conn.Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            NewOrder fm = new NewOrder();
            fm.Show();
            this.Hide();
        }
    }
}
