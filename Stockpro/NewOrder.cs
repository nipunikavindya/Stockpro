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
    public partial class NewOrder : Form
    {
        public NewOrder()
        {
            InitializeComponent();
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;

            timer1.Start();
            txtODate.Text = iDate.ToString("dd/MM/yyyy");
            txtOTime.Text = iDate.ToString("HH:mm:ss");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Brown Sugar - 1kg ")
            {
                txtUPrice.Text = "160";
            }
            else if (comboBox1.SelectedItem.ToString() == "White Sugar - 1kg")
            {
                txtUPrice.Text = "120";
            }
            else if (comboBox1.SelectedItem.ToString() == "Munchee Chocolate Buscuits")
            {
                txtUPrice.Text = "120";
            }
            else if (comboBox1.SelectedItem.ToString() == "Banana - 1kg")
            {
                txtUPrice.Text = "180";
            }
            else if (comboBox1.SelectedItem.ToString() == "Rice (Samba)- 1kg")
            {
                txtUPrice.Text = "105";
            }
            else if (comboBox1.SelectedItem.ToString() == "Potato - 1kg")
            {
                txtUPrice.Text = "130";
            }
            else if (comboBox1.SelectedItem.ToString() == "Flour - 1kg")
            {
                txtUPrice.Text = "105";
            }
            else if (comboBox1.SelectedItem.ToString() == "Nestomalt Super Pack (400g)")
            {
                txtUPrice.Text = "360";
            }
            else if (comboBox1.SelectedItem.ToString() == "Coca Cola Zero (2l)")
            {
                txtUPrice.Text = "370";
            }
            else if (comboBox1.SelectedItem.ToString() == "Sunquick Mix (370ml)")
            {
                txtUPrice.Text = "180";
            }
            else if (comboBox1.SelectedItem.ToString() == "Highland F/C Milk Powder (400g)")
            {
                txtUPrice.Text = "380";
            }
            else if (comboBox1.SelectedItem.ToString() == "Sunlight Soap Care (120g)")
            {
                txtUPrice.Text = "55";
            }
            else if (comboBox1.SelectedItem.ToString() == "Surf Excel Detergent Powder (500g)")
            {
                txtUPrice.Text = "180";
            }
            else if (comboBox1.SelectedItem.ToString() == "Clogard")
            {
                txtUPrice.Text = "120";
            }
            else if (comboBox1.SelectedItem.ToString() == "Vim Floor Cleaner Liquid (200ml)")
            {
                txtUPrice.Text = "150";
            }
            else if (comboBox1.SelectedItem.ToString() == "Vim Dish Wash Bar (400g)")
            {
                txtUPrice.Text = "115";
            }
            else if (comboBox1.SelectedItem.ToString() == "Kumarika Shampoo (180ml)")
            {
                txtUPrice.Text = "260";
            }
            else if (comboBox1.SelectedItem.ToString() == "Kumarika Conditioner (80ml)")
            {
                txtUPrice.Text = "150";
            }
            else if (comboBox1.SelectedItem.ToString() == "Kumarika Hair Oil (200ml)")
            {
                txtUPrice.Text = "250";
            }
            else if (comboBox1.SelectedItem.ToString() == "Good Night Cordless Liquidator (1pc)")
            {
                txtUPrice.Text = "365";
            }
            else if (comboBox1.SelectedItem.ToString() == "Maggi Special Family Noodles (325g)")
            {
                txtUPrice.Text = "170";
            }
            else if (comboBox1.SelectedItem.ToString() == "Raigam Devilled Chicken Flavour Soya Meat (100g)")
            {
                txtUPrice.Text = "110";
            }
            else if (comboBox1.SelectedItem.ToString() == "Edinborough Barbecue Sauce (350ml)")
            {
                txtUPrice.Text = "330";
            }
            else if (comboBox1.SelectedItem.ToString() == "Gherkin Chips (500g)")
            {
                txtUPrice.Text = "565";
            }
            else if (comboBox1.SelectedItem.ToString() == "MD Tomato Paste (250g)")
            {
                txtUPrice.Text = "290";
            }
            else if (comboBox1.SelectedItem.ToString() == "Kist Strawberry Jam (890g)")
            {
                txtUPrice.Text = "570";
            }
            else if (comboBox1.SelectedItem.ToString() == "Samaposha (500g)")
            {
                txtUPrice.Text = "195";
            }
            else if (comboBox1.SelectedItem.ToString() == "Edinborough Tomato Ketchup (405g)")
            {
                txtUPrice.Text = "280";
            }
            else if (comboBox1.SelectedItem.ToString() == "Lanka Soy Curry Flavour (90g)")
            {
                txtUPrice.Text = "63";
            }
            else if (comboBox1.SelectedItem.ToString() == "Lanka Soy Chicken Flavour (90g)")
            {
                txtUPrice.Text = "85";
            }
            else if (comboBox1.SelectedItem.ToString() == "Maggi Chicken Stock Powder (500g)")
            {
                txtUPrice.Text = "480";
            }
            else if (comboBox1.SelectedItem.ToString() == "Astra (500g)")
            {
                txtUPrice.Text = "550";
            }
            else if (comboBox1.SelectedItem.ToString() == "Headless Sprats (200g)")
            {
                txtUPrice.Text = "388";
            }
            else if (comboBox1.SelectedItem.ToString() == "Dhal (500g)")
            {
                txtUPrice.Text = "110";
            }
            else if (comboBox1.SelectedItem.ToString() == "Kottu Mee (78g)")
            {
                txtUPrice.Text = "60";
            }
            else
            {
                txtUPrice.Text = "0";
            }
        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {
            if (txtQty.Text.Length > 0)
            {
                txtTotal.Text = (Convert.ToInt32(txtUPrice.Text) * Convert.ToInt32(txtQty.Text)).ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int OrderID = int.Parse(txtOrderID.Text);
            int CusID = int.Parse(txtCusID.Text);
            string item = (comboBox1.Text);
            int qty = int.Parse(txtQty.Text);
            string total = (txtTotal.Text);


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C# SQL\CusOrder.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "INSERT INTO NewItem Values(" + OrderID + "," + CusID + ",'" + item + "'," + qty + ",'" + total + "')";
            SqlCommand cmd = new SqlCommand(qry, con);


            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully");

            }
            catch (SqlException Se)
            {
                MessageBox.Show(Se.ToString());
            }
            finally
            {
                con.Close();
            }

            string[] arr = new string[7];

            arr[0] = txtOrderID.Text;
            arr[1] = comboBox1.SelectedItem.ToString();
            arr[2] = txtUPrice.Text;
            arr[3] = txtQty.Text;
            arr[4] = txtTotal.Text;
            arr[5] = txtODate.Text;
            arr[6] = txtOTime.Text;


            ListViewItem lv = new ListViewItem(arr);
            listView1.Items.Add(lv);


            txtSub.Text = (Convert.ToInt32(txtSub.Text) + Convert.ToInt32(txtTotal.Text)).ToString();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            txtUPrice.Text = "";
            txtQty.Text = "";
            txtTotal.Text = "";
        }

        private void txtDelCharges_TextChanged(object sender, EventArgs e)
        {
            if (txtDelCharges.Text.Length > 0)
            {
                txtNetAmount.Text = (Convert.ToInt32(txtSub.Text) + Convert.ToInt32(txtDelCharges.Text)).ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime iDate = DateTime.Now;
            timer1.Start();
            txtOTime.Text = iDate.ToString("HH:mm:ss");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OrderDelete dl = new OrderDelete();
            dl.Show();
            this.Hide();
        }

        private void btnAddDB_Click(object sender, EventArgs e)
        {
            int OrderID = int.Parse(txtOrderID.Text);
            int CustomerID = int.Parse(txtCusID.Text);
            string OrderDate = txtODate.Text;
            string OrderTime = txtOTime.Text;
            string SubTotal = txtSub.Text;
            string DiliveryCharges = txtDelCharges.Text;
            string NetAmount = txtNetAmount.Text;


            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\C# SQL\CusOrder.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "INSERT INTO NewOrderDetails Values(" + OrderID + "," + CustomerID + ",'" + OrderDate + "','" + OrderTime + "','" + SubTotal + "','" + DiliveryCharges + "','" + NetAmount + "')";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully");

            }
            catch (SqlException Se)
            {
                MessageBox.Show(Se.ToString());
            }
            finally
            {
                con.Close();
            }
            listView1.Items.Clear();

            txtCusID.Text = "";
            txtOrderID.Text = "";
            comboBox1.Text = "";
            txtUPrice.Text = "";
            txtQty.Text = "";
            txtTotal.Text = "";
            txtSub.Text = "";
            txtDelCharges.Text = "";
            txtNetAmount.Text = "";

            SendEmail send = new SendEmail();
            send.Show();
            this.Hide();
        }

        private void btnConfirmEmail_Click(object sender, EventArgs e)
        {
            SendEmail send = new SendEmail();
            send.Show();
            this.Hide();
        }
    }
}
