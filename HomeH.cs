using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace test03
{
    public partial class HomeH : UserControl
    {
        private const string host = "localhost";
        private const string port = "3306";
        private const string db = "book";
        private const string dbUsername = "root";
        private const string dbPassword = "1234";
        private string dbURL = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", host, port, db, dbUsername, dbPassword);

        protected MySqlConnection UserConnection()
        {
            MySqlConnection connection = new MySqlConnection(dbURL);
            connection.Open();
            return connection;
        }
        //전체 도서수
        private void BookCountLoad()
        {
            MySqlConnection connection = UserConnection();
            try
            {
                string sql = "select count(bookid) from books;";

                MySqlCommand command = new MySqlCommand(sql, connection);
                

                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    lbABcount.Text = table.GetString("count(bookid)").ToString();
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
        //전체 회원수
        private void UserCountLoad()
        {
            MySqlConnection connection = UserConnection();
            try
            {
                string sql = "select count(userid) from users1;";

                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    lbUserctr.Text = table.GetString("count(userid)").ToString();
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
        //대여 도서 수
        private void RentCountLoad()
        {
            MySqlConnection connection = UserConnection();
            try
            {
                string sql = "select count(userid) from rent;";

                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    lbbroow.Text = table.GetString("count(userid)").ToString();
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
        public HomeH()
        {
            InitializeComponent();

            groupBox1.BackColor = Color.Transparent;
            groupBox1.Parent = pictureBox1;
            //rtb1.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label4.Parent = pictureBox1;
            label5.BackColor = Color.Transparent;
            label5.Parent = pictureBox1;
            label6.BackColor = Color.Transparent;
            label6.Parent = pictureBox1;
            label7.BackColor = Color.Transparent;
            label7.Parent = pictureBox1;
            label8.BackColor = Color.Transparent;
            label8.Parent = pictureBox1;



        }

        private void dataGridView_UserManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HomeH_Load(object sender, EventArgs e)
        {
            BookCountLoad();
            UserCountLoad();
            RentCountLoad();
        }

        
    }
}
