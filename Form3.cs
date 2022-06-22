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

namespace test03
{
    public partial class Form3 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CrateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
        int nLeftRect,
        int nToptRect,
        int nRightRect,
        int nButtomRect,
        int nWidthEllipse,
        int nHeightEllipse
        );
        
        public Form3()
        {
            InitializeComponent();
            //Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();
            this.Hide();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            btn_Home.PerformClick();
        }


    

        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel_Control.Controls.Clear();
            panel_Control.Controls.Add(c);

        }

        private void moveSidePanel(Control btn)
        {
            panel_Slide.Top = btn.Top;
            panel_Slide.Height = btn.Height;
        }
        private void btn_Home_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;
            moveSidePanel(btn_Home);

            HomeH h = new HomeH();
            AddControlsToPanel(h);
        }


        private void panel_Control_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Slide_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Rental_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;
            moveSidePanel(btn_Rental);
            Rental r = new Rental();
            AddControlsToPanel(r);
        }

        private void btn_Book_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;
            moveSidePanel(btn_Book);
            Books2 b = new Books2();
            AddControlsToPanel(b);
        }

        private void btn_User_Click(object sender, EventArgs e)
        {
            panel_Slide.Visible = true;
            moveSidePanel(btn_User);
            User1 u = new User1();
            AddControlsToPanel(u);
        }

        

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
