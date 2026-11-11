using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Hotel_Managment_System
{
    internal class function
    {
        protected SqlConnection getConnection()
        {
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["HotelDb"];

            if (settings == null)
            {
                throw new ConfigurationErrorsException(
                    "Connection string 'HotelDb' was not found in App.config.");
            }

            SqlConnection con = new SqlConnection();
            con.ConnectionString = settings.ConnectionString;
            return con;
        }

        public DataSet getData(string query)// get data from database 
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public void setData(string query, string message)// set insertion deletion updation
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("'"+message+"'","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(string query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query,con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }

}
