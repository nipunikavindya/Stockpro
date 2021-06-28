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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*database and code should be come here*/
            SqlConnection connector = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ASUS\Documents\UserLogin.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from LoginData where UserName='" + txtusername.Text + "' and password= '" + txtpassword.Text + "'", connector);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                OnlineDeliverySystem main = new OnlineDeliverySystem();
                main.Show();
            }
            else
            {
                MessageBox.Show("please check Username and password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtusername.Text = "";
            txtpassword.Clear();
            txtusername.Focus();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Register rw = new Register();
            rw.Show();
        }
    }
}
