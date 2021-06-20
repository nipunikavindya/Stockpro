using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Stockpro
{
    class DatabaseConnection
    {

        public string DataConnection(string QRY)
        {

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Stockpro.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand(QRY, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Operation Succefully Performed";

            }
            catch (SqlException se)
            {
                return "Operation is not Succefully Performed" + se;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
