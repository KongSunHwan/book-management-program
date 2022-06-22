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
using test03.user;
using MySql.Data.MySqlClient;
using test03;

namespace test03
{
    public partial class Form4 : Form
    {
        private const string host = "localhost";
        private const string port = "3306";
        private const string db = "book";
        private const string dbUsername = "root";
        private const string dbPassword = "1234";
        private string dbURL = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", host, port, db, dbUsername, dbPassword);

        protected MySqlConnection bookConnection()
        {
            MySqlConnection connection = new MySqlConnection(dbURL);
            connection.Open();
            return connection;
        }
        public Form4()
        {
            InitializeComponent();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBookU_Click(object sender, EventArgs e)
        {
            panelSU.Visible = true;
            moveSidePanel(btnBookU);
            UserCtrol bu = new UserCtrol();
            AddControlsToPanel(bu);
        }
        private void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panel_ControlU.Controls.Clear();
            panel_ControlU.Controls.Add(c);

        }

        private void moveSidePanel(Control btn)
        {
            panelSU.Top = btn.Top;
            panelSU.Height = btn.Height;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            UserCheck();
            button13.PerformClick();
        }

        private void UserCheck()
        {
            string axe = Form1.we;
            //lbUser.Text = Form1.we + " 님 환영합니다.";
            MySqlConnection connection = bookConnection();
            try
            {
                string sql = "select username as 사용자 from users1 where userid like '%" + axe + "%';";

                MySqlCommand command = new MySqlCommand(sql, connection);
                

                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    lbUser.Text = table.GetString("사용자").ToString();
                    
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panelSU.Visible = true;
            moveSidePanel(button9);
            Userinfo uinfo = new Userinfo();
            AddControlsToPanel(uinfo);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panelSU.Visible = true;
            moveSidePanel(button12);
            UserRent ur1 = new UserRent();
            AddControlsToPanel(ur1);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panelSU.Visible = true;
            moveSidePanel(button13);
            HomeH ur2 = new HomeH();
            AddControlsToPanel(ur2);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
