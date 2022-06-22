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
    public partial class UserRent : UserControl
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
        public UserRent()
        {
            InitializeComponent();
        }
        //도서목록조회
        private void SLoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "SELECT bookid as '책고유번호', bookname as '책이름', author as '저자', publisher as '출판사' \n";
                sql += "FROM books where not bookid in (select bookid from rent);";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter daSearch = new MySqlDataAdapter(command);
                DataSet dsSearch = new DataSet();
                daSearch.Fill(dsSearch, "dgv_Search");
                GV1.DataSource = dsSearch;
                GV1.DataMember = "dgv_Search";
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
        //자신의 대출목록
        private void RLoad()
        {
            string wea = Form1.we;
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "select bookid as 책고유번호, (select bookname from books" +
                    " where books.bookid = rent.bookid) as 책이름, (select username from users1 where users1.userid = rent.userid) as 사용자, rentdate as 대출일, returndate as 반납일 from rent where userid like '%"+ wea +"%';";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvRent.DataSource = table;
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
        private void UserRent_Load(object sender, EventArgs e)
        {
            RLoad();
            SLoad();
        }
       
        private void GV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GV1.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.GV1.Rows[e.RowIndex];
                txtbookname1.Text = row.Cells["책이름"].Value.ToString();
                txtbookid.Text = row.Cells["책고유번호"].Value.ToString();

            }
        }

        private void dgvRent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvRent.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvRent.Rows[e.RowIndex];
                txtbookname1.Text = row.Cells["책이름"].Value.ToString();
                txtbookid.Text = row.Cells["책고유번호"].Value.ToString();
            }
        }
        public bool existUser(string id)
        {
            MySqlConnection connection = bookConnection();
            try
            {
                string sql = "SELECT bookid from rent where bookid = (select bookid from books where bookname = '" + txtbookname1.Text + "')";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@UserId", id));

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
        private void showErrorMessage(String message, String title, TextBox target)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            target.Focus();
        }
        private void button_Borrow_Click(object sender, EventArgs e)
        {
            string awe = Form1.we.ToString();
            bool alreadyExistUser = existUser(txtbookname1.Text);
            if (txtbookid.Text == "")
            {
                MessageBox.Show("책번호를 선택해주세요");
            }
            else if (txtbookname1.Text == "")
            {
                MessageBox.Show("책이름을 선택해주세요");
            }
            else if (alreadyExistUser == true)
            {
                showErrorMessage("이미 대출된 책입니다.", "오류", txtbookname1);
                return;
            }
            else
            {
                MySqlConnection connection = bookConnection();

                try
                {
                    string sql = "insert into rent(userid,bookid,rentdate,returndate) values('" + awe + "', '" + txtbookid.Text + "', now(), (DATE_ADD(NOW(), INTERVAL 7 DAY)));";


                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);

                }
                finally
                {
                    MessageBox.Show("\"" + txtbookname1.Text + "\" 책이 대여되었습니다.");
                    connection.Close();
                }
                RLoad();
                SLoad();
                txtbookname1.Clear();
                txtbookid.Clear();
            }
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            if (txtbookid.Text == "")
            {
                MessageBox.Show("책번호를 선택해주세요");
            }
            else if (txtbookname1.Text == "")
            {
                MessageBox.Show("책이름을 선택해주세요");
            }
            else
            {
                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "DELETE FROM rent where bookid = " +
                        "(select bookid from books where bookname = '" + txtbookname1.Text + "');";


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
                    MessageBox.Show("\"" + txtbookname1.Text + "\" 책이 반납되었습니다.");

                }
            }
            RLoad();
            SLoad();
            txtbookid.Clear();
            txtbookname1.Clear();
        }
    }
}
