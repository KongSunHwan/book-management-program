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

namespace test03
{
    public partial class Userinfo : UserControl
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
        private void InfoOut()
        {
            string id = Form1.we;
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "SELECT * FROM users1 WHERE UserId = @UserId";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@UserId", id));

                MySqlDataReader table = command.ExecuteReader();
                while (table.Read())
                {
                    txtuserid.Text = table.GetString("userid").ToString();
                    txtage.Text = table.GetString("userage").ToString();
                    txtPn.Text = table.GetString("userpn").ToString();
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
        public Userinfo()
        {
            InitializeComponent();
        }

        private void Userinfo_Load(object sender, EventArgs e)
        {
            InfoOut();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InfoOut();
        }

        private void btnpwUpdate_Click(object sender, EventArgs e)
        {
            string cpw = txtCpw.Text.Trim();
            string uid = txtuserid.Text.Trim();
            
            

            //MessageBox.Show("비밀번호를 수정하시겠습니까?");
            var result = MessageBox.Show("비밀번호를 수정하시겠습니까?", "비밀번호 수정", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(cpw == "")
            {
                MessageBox.Show("먼저, 변경할 비밀번호와 확인 비밀번호를 입력해주세요.");
            }
            else if (txtCpw.Text != txtcpw1.Text)
            {
                MessageBox.Show("변경할 비밀번호가 다릅니다. 다시 확인해 주세요.");
            }
            else if(result == DialogResult.No)
            {
                MessageBox.Show("취소되었습니다.");
                txtCpw.Clear();
                txtCpw.Focus();
            }
            else
            {
                MySqlConnection connection = getConnection();

                try
                {
                    string sql = "update users1 set userpw = @cpw where userid = @uid;";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add(new MySqlParameter("@cpw", cpw));
                    command.Parameters.Add(new MySqlParameter("@uid", uid));
                    command.ExecuteNonQuery();
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("비밀번호가 변경되었습니다.", "비밀번호 변경", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpw.Clear();
                    txtcpw1.Clear();
                }
            }
        }

       

        private void btnUageUpdate_Click(object sender, EventArgs e)
        {
            string uage = txtUage.Text.Trim();
            string uid = txtuserid.Text.Trim();
            //MessageBox.Show("비밀번호를 수정하시겠습니까?");
            var result = MessageBox.Show("나이를 수정하시겠습니까?", "나이 수정", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (uage == "")
            {
                MessageBox.Show("먼저, 변경할 나이를 입력해주세요.");
            }
            else if (isNumber(uage) != true)
            {
                MessageBox.Show("나이는 숫자만 입력해주세요");
                txtUage.Clear();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("취소되었습니다.");
                txtUage.Clear();
                txtUage.Focus();
            }
            else
            {
                MySqlConnection connection = getConnection();

                try
                {
                    string sql = "update users1 set userage = @uage where userid = @uid;";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add(new MySqlParameter("@uage", uage));
                    command.Parameters.Add(new MySqlParameter("@uid", uid));
                    command.ExecuteNonQuery();
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("나이가 변경되었습니다.", "나이 변경", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUage.Clear();
                }
            }
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
        private bool isPhone(string phone)
        {
            Regex rex = new Regex(@"[0-9]{3}-[0-9]{4}-[0-9]{4}");
            return rex.IsMatch(phone);
        }
        //취소 확인
        public bool existMydata(string id)
        {
            string awe = Form1.we;
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "SELECT duserid from userdelete where duserid like '%" + awe + "%'";

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
        private void btnUpnUpdate_Click(object sender, EventArgs e)
        {
            string upn = txtUpn.Text.Trim();
            string uid = txtuserid.Text.Trim();

            var result = MessageBox.Show("전화번호를 수정하시겠습니까?", "전화번호 수정", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (upn == "")
            {
                MessageBox.Show("먼저, 변경할 전화번호는 [000-0000-0000] 으로 입력해주세요.");
            }
            else if (isPhone(upn) != true)
            {
                MessageBox.Show("전화번호 형식은 [000-0000-0000] 으로 입력해주세요.");
                txtUpn.Clear();
            }
            else if (result == DialogResult.No)
            {
                MessageBox.Show("취소되었습니다.");
                txtUpn.Clear();
                txtUpn.Focus();
            }
            else
            {
                MySqlConnection connection = getConnection();

                try
                {
                    string sql = "update users1 set userpn = @upn where userid = @uid;";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add(new MySqlParameter("@upn", upn));
                    command.Parameters.Add(new MySqlParameter("@uid", uid));
                    command.ExecuteNonQuery();
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("전화번호가 변경되었습니다.", "전화번호 변경", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUpn.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            requsetDelete requestd = new requsetDelete();
            
            requestd.Show();
        }

        private void btnRcancel_Click(object sender, EventArgs e)
        {
            string awe = Form1.we;
            bool alreadyMydata = existMydata(awe);
            if (alreadyMydata == false)
            {
                MessageBox.Show("확인된 탈퇴요청이 없습니다.", "탈퇴 요청 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MySqlConnection connection = getConnection();

                try
                {
                    string sql = "delete from userdelete where duserid like '%"+awe+"%';";

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
                    MessageBox.Show("탈퇴요청이 취소되었습니다.", "탈퇴 요청 취소", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
        }
    }
}
