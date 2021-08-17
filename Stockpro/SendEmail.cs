using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Stockpro
{
    public partial class SendEmail : Form
    {
        public SendEmail()
        {
            InitializeComponent();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            string con = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30");
            int ID = int.Parse(txtID.Text);

            string qry = "SELECT Email FROM CustomerDetails WHERE ID=" + ID + "";
            SqlDataAdapter Adpt = new SqlDataAdapter(qry, con);
            DataSet login = new DataSet();
            Adpt.Fill(login);

            txtTo.Text = login.Tables[0].Rows[0]["Email"].ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            NewOrder fm = new NewOrder();
            fm.Show();
            this.Hide();
        }

        private void txtOID_TextChanged(object sender, EventArgs e)
        {
            string con = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30");
            int OrderID = int.Parse(txtOID.Text);

            string qry = "SELECT OrderID,CustomerID,OrderDate,OrderTime,SubTotal,DeliveryCharges,NetAmount FROM NewOrderDetails WHERE OrderID=" + OrderID + "";
            SqlDataAdapter Adpt = new SqlDataAdapter(qry, con);
            DataSet login = new DataSet();
            Adpt.Fill(login);

            txtOrderID.Text = login.Tables[0].Rows[0]["OrderID"].ToString();
            txtCusID.Text = login.Tables[0].Rows[0]["CustomerID"].ToString();
            txtODate.Text = login.Tables[0].Rows[0]["OrderDate"].ToString();
            txtOTime.Text = login.Tables[0].Rows[0]["OrderTime"].ToString();
            txtSub.Text = login.Tables[0].Rows[0]["SubTotal"].ToString();
            txtDelivery.Text = login.Tables[0].Rows[0]["DeliveryCharges"].ToString();
            txtNetAmount.Text = login.Tables[0].Rows[0]["NetAmount"].ToString();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage email = new MailMessage();
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                email.From = new MailAddress(txtFrom.Text);
                email.To.Add(txtTo.Text);
                email.Subject = txtTitle.Text;
                email.Body = txtBody.Text;

                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential(txtFrom.Text, txtPwd.Text);
                smtp.EnableSsl = true;
                smtp.Send(email);
                MessageBox.Show("Mail has been successfully Sent", "Email sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }

            NewOrder fm = new NewOrder();
            fm.Show();
            this.Hide();
        }
    }
}
