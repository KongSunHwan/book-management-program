using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using test03.book1;

namespace test03
{
    public partial class User1 : UserControl
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
        private void ULoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "select username as '회원 이름', userage as '회원 나이', userpn as '회원 전화번호', userrd as '회원 등록일' from users1;";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_Users.DataSource = table;
                
            }
            catch (Exception j)
            {
                MessageBox.Show(j.Message);

            }
            finally
            {
                connection.Close();
            }
        }
        private void SLoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "select duserid as '삭제요청회원', dtxt as '탈퇴사유', " +
                    "ddate as '탈퇴요청일', dcheck as '요청마감기한'  from userdelete;";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;

            }
            catch (Exception j)
            {
                MessageBox.Show(j.Message);

            }
            finally
            {
                connection.Close();
            }
        }
        public User1()
        {
            InitializeComponent();
        }

        private void textBox_ID_TextChanged(object sender, EventArgs e)
        {

        }

        private void User1_Load(object sender, EventArgs e)
        {
            ULoad();
            SLoad();
        }

        private void DataClick()
        {

            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "select userid, userpw from users1 where username = '" + txt_name.Text + "';";


                MySqlCommand command = new MySqlCommand(sql, connection);
                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    txt_id.Text = table.GetString("userid").ToString();
                    txt_pw.Text = table.GetString("userpw").ToString();
                }
            }
            catch (Exception j)
            {
                MessageBox.Show(j.Message);

            }
            finally
            {
                connection.Close();
            }
        }

        private void dataGridView_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_Users.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Users.Rows[e.RowIndex];
                txt_name.Text = row.Cells["회원 이름"].Value.ToString();
                txt_age.Text = row.Cells["회원 나이"].Value.ToString();
                txt_pn.Text = row.Cells["회원 전화번호"].Value.ToString();
                
            }
            DataClick();

        }
        
        private void button_Modify_Click(object sender, EventArgs e)
        {
            string id = txt_id.Text.Trim();
            string name = txt_name.Text.Trim();
            string age = txt_age.Text.Trim();
            string pn = txt_pn.Text.Trim();
            if(name == "")
            {
                showErrorMessage("변경할 이름을 입력해주세요.", "오류", txt_name);
            }
            else if(age == "")
            {
                showErrorMessage("변경할 나이를 입력해주세요.", "오류", txt_age);
            }
            else if (isNumber(age) == false)
            {
                showErrorMessage("나이는 숫자만 입력해주세요.", "오류", txt_age);
            }
            else if(pn == "")
            {
                showErrorMessage("변경할 전화번호를 입력해주세요.", "오류", txt_pn);
            }
            else if (isPhone(pn) == false)
            {
                showErrorMessage("전화번호 형식은 '000-0000-0000'입니다.", "오류", txt_pn);
            }
            else
            {
                
                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "update users1 set username = '" + txt_name.Text + "', userage = " + txt_age.Text + ", userpn = '" + txt_pn.Text + "' " +
                        "where userid = '" + txt_id.Text + "';";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    
                    command.ExecuteNonQuery();

                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);

                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("유저 정보가 변경되었습니다.", "회원 정보 수정", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
                    
                }
                ULoad();
            }
        }

        private bool isPhone(string phone)
        {
            Regex rex = new Regex(@"[0-9]{3}-[0-9]{4}-[0-9]{4}");
            return rex.IsMatch(phone);
        }

        private bool isNumber(string number)
        {
            try
            {
                Convert.ToInt32(number);
                return true;
            }
            catch (FormatException e)
            {
                return false;
            }
        }
        private void showErrorMessage(String message, String title, TextBox target)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            target.Focus();
        }
        private void deletedateU()
        {

        }
        private void deletedateS()
        {

        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show("탈퇴할 회원이 선택되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "delete from users1 where userid = '" + txt_id.Text + "';";


                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();


                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);

                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("회원, " + txt_name.Text + "이 탈퇴되었습니다.");
                }
                SLoad();
                ULoad();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_id.Text == "")
            {
                MessageBox.Show("삭제 요청을 보낸 회원이 확인되지 않았습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "delete from userdelete where duserid = '" + txt_id.Text + "';";


                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();


                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);

                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("회원, " + txt_name.Text + "의 탈퇴요청이 수락되었습니다.");
                }
                SLoad();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txt_id.Text = row.Cells["삭제요청회원"].Value.ToString();
            }
            
        }
    }
}
