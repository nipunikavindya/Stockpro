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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLblLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login lw = new Login();
            lw.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string UserName = textBoxUserName.Text;
            string Email = textBoxEmail.Text;
            string Password = textBoxPassword.Text;
            string RePassword = textBox4.Text;

            if (RePassword == Password)
            {
                SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30");
                string Qry = "INSERT INTO LoginData Values('" + UserName + "','" + Email + "','" + Password + "')";
                SqlCommand cmd = new SqlCommand(Qry, connect);

                try
                {
                    connect.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You are registered succefully!");
                }

                catch (SqlException SE)
                {
                    MessageBox.Show(SE.ToString());
                }
                finally
                {
                    connect.Close();
                }
            }
            else
            {
                MessageBox.Show("Re Check Password");

            }
        }

        private void textBoxRePassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}