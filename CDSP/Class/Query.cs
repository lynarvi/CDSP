using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace CDSP.Class
{
    class Query : SqlConnection
    {
        MySqlConnection conn;
        MySqlCommand command;
        MySqlDataReader reader;

        public MySqlDataReader loadData(String query)
        {
            conn = new MySqlConnection(this.connection());
            conn.Open();
            command = new MySqlCommand(query, conn);
            reader = command.ExecuteReader();

            return reader;
            
        }

        public void insert(String speech, String dateNow)
        {
            try
            {
                conn = new MySqlConnection(this.connection());
                conn.Open();
                command = new MySqlCommand("INSERT INTO log (speechVoice, date_created) VALUES (@speechVoice, @date_created)", conn);
                command.Parameters.AddWithValue("@speechVoice", speech);
                command.Parameters.AddWithValue("@date_created", dateNow);

                bool result = (int)command.ExecuteNonQuery() > 0;

                if (result == true)
                {
                    //MessageBox.Show("Success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                conn.Close();
                command.Dispose();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
