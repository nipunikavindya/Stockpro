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
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Stock home = new Stock();
            home.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ProductCode = int.Parse(txtdelete.Text);

            string qry = "DELETE  FROM StockDetails Where ProductCode ='" + ProductCode + "'";
            DatabaseConnection OBjDB = new DatabaseConnection();

            string feedaback = OBjDB.DataConnection(qry);
            MessageBox.Show(feedaback);

        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtdelete.Text = "";
        }
    }
}
