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
using System.Media;

namespace CDSP
{
    public partial class BasicNeeds : Form
    {
        Class.ReusableSyntax reusable = new Class.ReusableSyntax();
        Class.Query query = new Class.Query();
        private SoundPlayer _soundPlayer;
        
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

        public BasicNeeds()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void PersonalNeeds_Load(object sender, EventArgs e)
        {
    
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

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            reusable.moveStart = 0;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {

            reusable.moveStart = 1;
            reusable.moveStartX = e.X;
            reusable.moveStartY = e.Y;
        }


        private void isSound(String filePath)
        {
            _soundPlayer = new SoundPlayer(filePath);
            _soundPlayer.PlayLooping();
        }

        private void isOption(String filePath)
        {
            isSound(filePath);
            DialogResult dialogResultt = MessageBox.Show("Do you want to Stop this voice speech?", "Information", MessageBoxButtons.YesNo);
            if (dialogResultt == DialogResult.Yes)
            {
                _soundPlayer.Stop();
            }
            else
            {
                isSound(filePath);
            }
        }

 
        private void ovalPicture1_Click(object sender, EventArgs e)
        {
            isOption("Audio\\IWantToDrink.wav");
            query.insert("I Want To Drink", toDate.Value.ToString("yyyy-MM-dd"));
        }

        private void ovalPicture2_Click(object sender, EventArgs e)
        {
            isOption("Audio\\IWantToEat.wav");
            query.insert("I Want To Eat", toDate.Value.ToString("yyyy-MM-dd"));
        }

        private void ovalPicture3_Click(object sender, EventArgs e)
        {
            isOption("Audio\\IWantToPee.wav");
            query.insert("I Want To Pee", toDate.Value.ToString("yyyy-MM-dd"));
        }

        private void ovalPicture4_Click(object sender, EventArgs e)
        {
            isOption("Audio\\IWantToPoop.wav");
            query.insert("I Want To Poop", toDate.Value.ToString("yyyy-MM-dd"));
        }

        private void ovalPicture5_Click(object sender, EventArgs e)
        {
            isOption("Audio\\IWantToSit.wav");
            query.insert("I Want To Sit", toDate.Value.ToString("yyyy-MM-dd"));
        }

        private void ovalPicture6_Click(object sender, EventArgs e)
        {
            isOption("Audio\\IWantToSleep.wav");
            query.insert("I Want To Sleep", toDate.Value.ToString("yyyy-MM-dd"));
        }

        private void isHover(PictureBox picture, Label label)
        {
            picture.BackColor = Color.FromArgb(65, 140, 150);
            label.BackColor = Color.FromArgb(65, 140, 150);
        }

        private void isLeave(PictureBox picture, Label label)
        {
            picture.BackColor = Color.FromArgb(0, 124, 243);
            label.BackColor = Color.FromArgb(0, 124, 243);
        }

        private void ovalPicture1_MouseHover(object sender, EventArgs e)
        {
            isHover(ovalPicture1, label3);
        }

        private void ovalPicture1_MouseLeave(object sender, EventArgs e)
        {
            isLeave(ovalPicture1, label3);
        }

        private void ovalPicture2_MouseHover(object sender, EventArgs e)
        {
            isHover(ovalPicture2, label4);
        }

        private void ovalPicture2_MouseLeave(object sender, EventArgs e)
        {
            isLeave(ovalPicture2, label4);
        }

        private void ovalPicture3_MouseHover(object sender, EventArgs e)
        {
            isHover(ovalPicture3, label5);
        }

        private void ovalPicture3_MouseLeave(object sender, EventArgs e)
        {
            isLeave(ovalPicture3, label5);
        }

        private void ovalPicture4_MouseHover(object sender, EventArgs e)
        {
            isHover(ovalPicture4, label6);
        }

        private void ovalPicture4_MouseLeave(object sender, EventArgs e)
        {
            isLeave(ovalPicture4, label6);
        }

        private void ovalPicture5_MouseHover(object sender, EventArgs e)
        {
            isHover(ovalPicture5, label7);
        }

        private void ovalPicture5_MouseLeave(object sender, EventArgs e)
        {
            isLeave(ovalPicture5, label7);
        }

        private void ovalPicture6_MouseHover(object sender, EventArgs e)
        {
            isHover(ovalPicture6, label8);
        }

        private void ovalPicture6_MouseLeave(object sender, EventArgs e)
        {
            isLeave(ovalPicture6, label8);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Hide();
            form.Show();
        }
    }
}
