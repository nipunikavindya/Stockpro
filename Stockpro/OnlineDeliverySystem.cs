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
    public partial class OnlineDeliverySystem : Form
    {

        public OnlineDeliverySystem()
        {
            InitializeComponent();
        }

        private void customerDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer cs = new customer();
            cs.MdiParent = this;
            cs.StartPosition = FormStartPosition.CenterScreen;
            cs.Show();
        }

        private void productDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_Manager pr = new Product_Manager();
            pr.MdiParent = this;
            pr.StartPosition = FormStartPosition.CenterScreen;
            pr.Show();
        }

        private void orderDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewOrder no = new NewOrder();
            no.MdiParent = this;
            no.StartPosition = FormStartPosition.CenterScreen;
            no.Show();
        }

        private void orderDeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrderDelete od = new OrderDelete();
            od.MdiParent = this;
            od.StartPosition = FormStartPosition.CenterScreen;
            od.Show();
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendEmail sm = new SendEmail();
            sm.MdiParent = this;
            sm.StartPosition = FormStartPosition.CenterScreen;
            sm.Show();
        }

        private void stockManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock stk = new Stock();
            stk.MdiParent = this;
            stk.StartPosition = FormStartPosition.CenterScreen;
            stk.Show();
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reset rsk = new Reset();
            rsk.MdiParent = this;
            rsk.StartPosition = FormStartPosition.CenterScreen;
            rsk.Show();
        }

        private void deleteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete dlt = new Delete();
            dlt.MdiParent = this;
            dlt.StartPosition = FormStartPosition.CenterScreen;
            dlt.Show();
        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sales_Report sr = new Sales_Report();
            sr.MdiParent = this;
            sr.StartPosition = FormStartPosition.CenterScreen;
            sr.Show();
        }

        private void OnlineDeliverySystem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }



    }
}

