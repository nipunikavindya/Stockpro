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
    public partial class customer : Form
    {
        public customer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Clear
            fname.Text = "";
            lname.Text = "";
            email.Text = "";
            mobile.Text = "";
            address.Text = "";
            street.Text = "";
            city.Text = "";
            code.Text = "";

            //Date and Time
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //New & auto id increment
            fname.Text = "";
            lname.Text = "";
            email.Text = "";
            mobile.Text = "";
            address.Text = "";
            street.Text = "";
            city.Text = "";
            code.Text = "";

            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\database.mdf;Integrated Security=True;Connect Timeout=30";

            SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(id as int )),0)+1 from details", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            id.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = fname;


            //Date and Time
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Database
            int UserID = int.Parse(id.Text);
            string FirstName = fname.Text;
            string LastName = lname.Text;
            string Email = email.Text;
            string Mobile = mobile.Text;
            string Address = address.Text;
            string Street = street.Text;
            string City = city.Text;
            int PostalCode = int.Parse(code.Text);
            string Date = date.Text;
            string Time = time.Text;

            SqlConnection conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\database.mdf;Integrated Security=True;Connect Timeout=30");
            string querry = "INSERT INTO details Values(" + UserID + ",'" + FirstName + "','" + LastName + "','" + Email + "','" + Mobile + "','" + Address + "','" + Street + "','" + City + "'," + PostalCode + ",'" + Date + "','" + Time + "')";
            SqlCommand cmd = new SqlCommand(querry, conect);

            try
            {
                conect.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully");

            }
            catch (SqlException Se)
            {
                MessageBox.Show(Se.ToString());
            }

            finally
            {
                conect.Close();
            }
        }

        private void customer_Load(object sender, EventArgs e)
        {
            //Auto id increment
            string con = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\database.mdf;Integrated Security=True;Connect Timeout=30";

            SqlDataAdapter sda = new SqlDataAdapter("Select isnull(max(cast(id as int )),0)+1 from details", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            id.Text = dt.Rows[0][0].ToString();
            this.ActiveControl = fname;

            //Date and Time
            date.Text = DateTime.Now.ToLongDateString();
            time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
