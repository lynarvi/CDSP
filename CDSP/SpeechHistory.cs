using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace CDSP
{
    public partial class SpeechHistory : Form
    {

        Class.ReusableSyntax reusable = new Class.ReusableSyntax();
        Class.Query query = new Class.Query();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
         (
              int nLeftRect,     // x-coordinate of upper-left corner
              int nTopRect,      // y-coordinate of upper-left corner
              int nRightRect,    // x-coordinate of lower-right corner
              int nBottomRect,   // y-coordinate of lower-right corner
              int nWidthEllipse, // height of ellipse
              int nHeightEllipse // width of ellipse
         );

        public SpeechHistory()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void loadSpeechData()
        {
            try
            {
                dataGridView1.Rows.Clear();
                using (MySqlDataReader reader = query.loadData("SELECT * FROM log"))
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["logid"].ToString(),
                            reader["speechVoice"].ToString(),
                            reader["date_created"].ToString()
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDataFromDate()
        {
            try
            {
                dataGridView1.Rows.Clear();
                using (MySqlDataReader reader = query.loadData("SELECT * FROM log WHERE date_created BETWEEN '"+ FromDate.Value.ToString("yyyy-MM-dd") + "' AND '"+ ToDate.Value.ToString("yyyy-MM-dd") +"'"))
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(
                            reader["logid"].ToString(),
                            reader["speechVoice"].ToString(),
                            reader["date_created"].ToString()
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void SpeechHistory_Load(object sender, EventArgs e)
        {
            loadSpeechData();
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 124, 243);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Padding = new Padding(0, 7, 0, 7);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (reusable.moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - reusable.moveStartX, MousePosition.Y - reusable.moveStartY);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 1;
            reusable.moveStartX = e.X;
            reusable.moveStartY = e.Y;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 0;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();

        }

        //SELECT * FROM log WHERE date_created BETWEEN "2021-01-7" AND "2021-04-7"
        private void Refresh_Click(object sender, EventArgs e)
        {
            loadDataFromDate();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            loadSpeechData();
        }
    }
}
