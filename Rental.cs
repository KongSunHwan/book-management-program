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
using test03.book1;

namespace test03
{
    public partial class Rental : UserControl
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
        bookRespository bookrespository = new bookRespository();
        public Rental()
        {
            InitializeComponent();
        }
        private void SLoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "SELECT bookid as '책번호', bookname as '책이름', author as '저자', publisher as '출판사' \n";
                sql += "FROM books \n";


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
        private void ULoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "select userid as '회원아이디', username as '사용자' from users1;";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView_BookManager.DataSource = table;
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
        private void RLoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "select bookid as '책번호', (select bookname from books" +
                    " where books.bookid = rent.bookid) as 책이름, (select username from users1 where users1.userid = rent.userid) as 사용자, rentdate as 대출일, returndate as 반납일 from rent;";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);
                rentGV.DataSource = table;
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
        private void Rental_Load(object sender, EventArgs e)
        {
            SLoad();
            ULoad();
            RLoad();
        }
        private void GV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GV1.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.GV1.Rows[e.RowIndex];
                txtbookname1.Text = row.Cells["책이름"].Value.ToString();
                txtbookid.Text = row.Cells["책번호"].Value.ToString();

            }
        }

        private void dataGridView_BookManager_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView_BookManager.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_BookManager.Rows[e.RowIndex];
                textBox_id.Text = row.Cells["회원아이디"].Value.ToString();

            }
        }
        private void reArray()
        {
            MySqlConnection connection = bookConnection();
            int cnt = 0;
            try
            {
                string sql = "Update rent set rent.rnum = @cnt:=@cnt+1;";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@cnt", cnt));
                command.ExecuteNonQuery();

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
            bool alreadyExistUser = existUser(txtbookname1.Text);
            if (txtbookid.Text == "")
            {
                MessageBox.Show("도서아이디를 선택해주세요");
            }
            else if(txtbookname1.Text == ""){
                MessageBox.Show("도서이름을 선택해주세요");
            }
            else if(textBox_id.Text == "")
            {
                MessageBox.Show("대여할 사용자를 선택해주세요");
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
                    string sql = "insert into rent(userid,bookid,rentdate,returndate) values('" + textBox_id.Text + "', '" + txtbookid.Text + "', now(), (DATE_ADD(NOW(), INTERVAL 7 DAY)));";


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
                
            }
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = bookConnection();
            try
            {
                string sql = "DELETE FROM rent where bookid = " +
                    "(select bookid from books where bookname = '"+ txtbookname1.Text+ "');";


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
            RLoad();
        }

        private void rentGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rentGV.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.rentGV.Rows[e.RowIndex];
                
                txtbookname1.Text = row.Cells["책이름"].Value.ToString();
                txtbookid.Text = row.Cells["책번호"].Value.ToString();

            }
        }
    }
}
