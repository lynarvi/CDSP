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
    public partial class Loading : Form
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
        public Loading()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 10;

            if (panel1.Width >= 599)
            {
                timer1.Stop();
                Form1 form = new Form1();
                form.Show();
                this.Hide();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 0;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (reusable.moveStart == 1)
            {
                this.SetDesktopLocation(MousePosition.X - reusable.moveStartX, MousePosition.Y - reusable.moveStartY);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 1;
            reusable.moveStartX = e.X;
            reusable.moveStartY = e.Y;
        }
    }
}
