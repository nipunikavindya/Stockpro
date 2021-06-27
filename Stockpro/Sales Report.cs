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
    public partial class Sales_Report : Form
    {
        public Sales_Report()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Getting the time period 
            DateTime now = DateTime.Now;
            int month = now.Month - 1;
            int year = now.Year;
            int endDate = 0;

            switch (month)
            {
                case 1: endDate = 31; break;
                case 2: endDate = 28; break;
                case 3: endDate = 31; break;
                case 4: endDate = 30; break;
                case 5: endDate = 31; break;
                case 6: endDate = 30; break;
                case 7: endDate = 31; break;
                case 8: endDate = 31; break;
                case 9: endDate = 30; break;
                case 10: endDate = 31; break;
                case 11: endDate = 30; break;
                case 12: endDate = 31; break;
                default: break;

            }

            lblReportPeriod.Text = year.ToString() + " / " + month.ToString("00") + " / 01    -    " + year.ToString() + " / " + month.ToString("00") + " / " + endDate.ToString();

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ovinr\OneDrive\Documents\testdb.mdf;Integrated Security=True;Connect Timeout=30");

            con.Open();

            //Retrieving item sales count
            string qtycount = "";
            int sum = 0;

            SqlCommand qwerty = new SqlCommand(qtycount, con);

            qwerty.CommandText = "SELECT count( * ) FROM Sales";
            Int32 count = (Int32)qwerty.ExecuteScalar();

            for (int pid = 1; pid <= count; pid++)
            {

                string totalQtySold = "SELECT qtySold FROM Sales WHERE ProductId = " + pid;

                SqlCommand cmd = new SqlCommand(totalQtySold, con);

                try
                {

                    SqlDataAdapter Adpt = new SqlDataAdapter(totalQtySold, con);
                    DataSet login = new DataSet(); Adpt.Fill(login);
                    foreach (DataRow dr in login.Tables[0].Rows)
                    {
                        sum += int.Parse(login.Tables[0].Rows[0]["qtySold"].ToString());
                    }

                }

                catch (SqlException SE)
                {
                    MessageBox.Show(SE.ToString());
                }


            }

            lblItemSalesCount.Text = sum.ToString();

            //Calculating Net Income
            int qty = 0;
            int price = 0;
            int tp = 0;

            for (int i = 1; i <= count; i++)
            {
                string addPrice = "SELECT qtySold,unitPrice FROM Sales WHERE ProductId = " + i;

                SqlDataAdapter Adpt = new SqlDataAdapter(addPrice, con);
                DataSet login = new DataSet(); Adpt.Fill(login);
                foreach (DataRow dr in login.Tables[0].Rows)
                {
                    qty = int.Parse(login.Tables[0].Rows[0]["qtySold"].ToString());
                    price = int.Parse(login.Tables[0].Rows[0]["unitPrice"].ToString());
                    tp += qty * price;
                }

            }

            lblNetIncome.Text = tp.ToString();

            //Retrieving most sold item
            int qty1 = 0;
            int maximum = 0;
            int prodid = 0;
            int maxid = 0;

            for (int a = 1; a <= count; a++)
            {
                string max = "SELECT ProductId,qtySold FROM Sales WHERE ProductId = " + a;

                SqlDataAdapter Adpt = new SqlDataAdapter(max, con);
                DataSet login = new DataSet(); Adpt.Fill(login);
                foreach (DataRow dr in login.Tables[0].Rows)
                {
                    qty1 = int.Parse(login.Tables[0].Rows[0]["qtySold"].ToString());
                    prodid = int.Parse(login.Tables[0].Rows[0]["ProductId"].ToString());

                    if (qty1 > maximum)
                    {
                        maximum = qty1;
                        maxid = prodid;

                    }
                }


            }
            lblMostSoldItem.Text = (maxid.ToString());
        }
    }
}
