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

namespace test03.user
{
    public partial class UserCtrol : UserControl
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
        public UserCtrol()
        {
            InitializeComponent();
        }

        private void dgv_SearchU_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_SearchU.Rows[e.RowIndex];
                txtbookidU.Text = row.Cells["bookid"].Value.ToString();
                txtbooknameU.Text = row.Cells["bookname"].Value.ToString();
                txtAuthorU.Text = row.Cells["author"].Value.ToString();
                txtPublisherU.Text = row.Cells["publisher"].Value.ToString();
            }
        }
        private string TABLE_NAME = "books";

        private void btnLoadU_Click(object sender, EventArgs e)
        {
          

        }
        private void showErrorMessage(String message, String title, TextBox target)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            target.Focus();
        }
        private void SLoad()
        {
            MySqlConnection connection = bookConnection();

            try
            {
                string sql = "SELECT bookid, bookname, author, publisher\n";
                sql += "FROM " + TABLE_NAME + " \n";


                MySqlCommand command = new MySqlCommand(sql, connection);


                MySqlDataAdapter daSearch = new MySqlDataAdapter(command);
                DataSet dsSearch = new DataSet();
                daSearch.Fill(dsSearch, "dgv_Search");
                dgv_SearchU.DataSource = dsSearch;
                dgv_SearchU.DataMember = "dgv_Search";
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

        private void dgv_SearchU_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_SearchU.SelectedRows.Count >= 0)
                {
                    txtbookidU.Text = dgv_SearchU.SelectedRows[0].Cells[0].Value.ToString();
                    txtbooknameU.Text = dgv_SearchU.SelectedRows[0].Cells[1].Value.ToString();
                    txtAuthorU.Text = dgv_SearchU.SelectedRows[0].Cells[2].Value.ToString();
                    txtPublisherU.Text = dgv_SearchU.SelectedRows[0].Cells[3].Value.ToString();
                }
                else
                    MessageBox.Show("누르신 곳은 빈칸입니다!");
            }
            catch (Exception)
            {
                //MessageBox.Show("열을 클릭해 주세요!");
            }
            dgv_SearchU.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_SearchU.Rows[e.RowIndex];
                txtbookidU.Text = row.Cells["bookid"].Value.ToString();
                txtbooknameU.Text = row.Cells["bookname"].Value.ToString();
                txtAuthorU.Text = row.Cells["author"].Value.ToString();
                txtPublisherU.Text = row.Cells["publisher"].Value.ToString();

            }
        }

        private void UserCtrol_Load(object sender, EventArgs e)
        {
                SLoad();
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            if (txtTest.Text == "")
            {
                showErrorMessage("검색할 도서를 입력해 주세요!", "오류", txtTest);
            }
            else
            {
                string valueToSearch = txtTest.Text.ToString();
                searchData(valueToSearch);
                txtTest.Text = "";
            }
        }
        private void searchData(String valueTosearch)
        {
            MySqlConnection connection = bookConnection();
            try
            {
                string sql = "select bookid as '고유번호', bookname as '책이름', author as '저자', publisher as '출판사' from books where bookname like '%" + valueTosearch + "%' or publisher like '%" + valueTosearch + "%' or author like '%" + valueTosearch + "%';";


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
    }
}
