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
    public partial class requsetDelete : Form
    {
        private const string host = "localhost";
        private const string port = "3306";
        private const string db = "book";
        private const string dbUsername = "root";
        private const string dbPassword = "1234";
        private string dbURL = String.Format("Server={0};Port={1};Database={2};Uid={3};Pwd={4}", host, port, db, dbUsername, dbPassword);

        protected MySqlConnection getConnection()
        {
            MySqlConnection connection = new MySqlConnection(dbURL);
            connection.Open();
            return connection;
        }
        
        //아이디
        private void Myid()
        {
            string id = Form1.we;
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "SELECT userid FROM users1 WHERE UserId = @UserId";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@UserId", id));

                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    txtmyid.Text = table.GetString("userid").ToString();
                    
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
        public requsetDelete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool existMydata(string id)
        {
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "SELECT duserid from userdelete where duserid like '%" + txtmyid.Text + "%'";

                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader table = command.ExecuteReader();

                return table.HasRows;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("정말 탈퇴 요청을 보내시겠습니까?", "탈퇴 요청", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            bool alreadyMydata = existMydata(txtmyid.Text);
            if (result == DialogResult.No)
            {
                MessageBox.Show("취소되었습니다.");
                txtsu.Clear();
            }
            else if (alreadyMydata == true)
            {
                MessageBox.Show("이미 " + txtmyid.Text + "님은 탈퇴요청을 보내셨습니다.");
                return;
            }
            else
            {
                MySqlConnection connection = getConnection();
                try
                {
                    string sql = "insert into userdelete(duserid, dtxt, ddate, dcheck) values('" + txtmyid.Text + "', '" + txtsu.Text + "', now(), (DATE_ADD(NOW(), INTERVAL 3 DAY)));";


                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);

                }
                finally
                {
                    MessageBox.Show("\"" + txtmyid.Text + "\" 님의 탈퇴 요청이 보내졌습니다!");
                    connection.Close();
                }
            }
            this.Close();
        }
        private void CurrentDate()
        {
            // lbdate.Text += System.DateTime.Now.ToString("yyyy");
            //lbdate.Text += DateTime.Now.ToString("yyyyMMdd");
            //lbdate.Text = DateTime.Now.ToString("HH:mm:ss");
            //this.lbdate.Text = DateTime.Now.ToString("yyyyMMdd");
            lbdate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
        private void requsetDelete_Load(object sender, EventArgs e)
        {
            //string ndate = DateTime.Now.ToString("yyyy.mm.dd");
            Myid();
            CurrentDate();
        }

    }
}
