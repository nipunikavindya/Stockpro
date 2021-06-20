using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stockpro
{
    public partial class Reset : Form
    {
        public Reset()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stock home = new Stock();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int code = int.Parse(txtcode.Text);
            int quantity = int.Parse(txtquan.Text);

            string qry = "UPDATE StockDetails SET Quantity=" + quantity + " WHERE ProductCode =" + code + "";
            DatabaseConnection OBjDB = new DatabaseConnection();

            string feedaback = OBjDB.DataConnection(qry);
            MessageBox.Show(feedaback);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtcode.Text = "";
            txtquan.Text = "";
        }
    }
}
