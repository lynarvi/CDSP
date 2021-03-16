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

namespace CDSP
{
    public partial class Form1 : Form
    {


        Class.ReusableSyntax reusable = new Class.ReusableSyntax();
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

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void background_MouseUp(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 0;
        }

        private void background_MouseDown(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 1;
            reusable.moveStartX = e.X;
            reusable.moveStartY = e.Y;
        }

        private void background_MouseMove(object sender, MouseEventArgs e)
        {
            if (reusable.moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - reusable.moveStartX, MousePosition.Y - reusable.moveStartY);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PersonalNeeds_Click(object sender, EventArgs e)
        {
            BasicNeeds personalNeeds = new BasicNeeds();
            this.Hide();
            personalNeeds.Show();
        }

        private void PersonalWords_Click(object sender, EventArgs e)
        {
            PersonalWords personalWords = new PersonalWords();
            this.Hide();
            personalWords.Show();
        }

        private void background_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            SpeechHistory history = new SpeechHistory();
            history.Show();
            this.Hide();
        }

    }
}
