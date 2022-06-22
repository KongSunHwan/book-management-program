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
    public partial class Books2 : UserControl
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

        public Books2()
        {
            InitializeComponent();
        }
        private string TABLE_NAME = "books";
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
                string sql = "select * from books where bookname like '%" 
                    + valueTosearch + "%' or publisher like '%" + valueTosearch + "%' or author like " +
                    "'%" + valueTosearch + "%';";


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
            
        

        private void Books2_Load(object sender, EventArgs e)
        {
            SLoad();
            txtTest.Text = "검색할 책 제목/저자/출판사 를 입력해주세요";
        }

        private void lbtest1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd1_Click(object sender, EventArgs e)
        {
            string id = txtbookid.Text.Trim();
            string name = txtbookname.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string publisher = txtPublisher.Text.Trim();
            bool bookExist = bookrespository.existBook(id);
            if (id == "")
            {
                showErrorMessage("등록할 책번호를 입력해주세요.", "오류", txtbookid);
            }
            else if (name == "")
            {
                showErrorMessage("등록할 책이름를 입력해주세요.", "오류", txtbookname);
            }
            else if (author == "")
            {
                showErrorMessage("등록할 저자를 입력해주세요.", "오류", txtAuthor);
            }
            else if (publisher == "")
            {
                showErrorMessage("등록할 출판사를 입력해주세요.", "오류", txtbookname);
            }
            else if (bookExist)
            {        
                showErrorMessage("이미 등록된 번호입니다.", "오류", txtbookid);
                return;
            }
            else
            {
                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "INSERT INTO " + TABLE_NAME + " VALUES (@id, @name, @author, @publisher);";


                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    command.Parameters.Add(new MySqlParameter("@name", name));
                    command.Parameters.Add(new MySqlParameter("@author", author));
                    command.Parameters.Add(new MySqlParameter("@publisher", publisher));

                    command.ExecuteNonQuery();
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("책이 등록되었습니다.");
                    txtbookid.Clear();
                    txtbookname.Clear();
                    txtAuthor.Clear();
                    txtPublisher.Clear();
                }
                SLoad();
            }
        }
        private void showErrorMessage(String message, String title, TextBox target)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            target.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtbookid.Text.Trim();
            string name = txtbookname.Text.Trim();
            if (id == "")
            {
                MessageBox.Show("삭제할 도서를 선택해 주세요.");
            }
            else
            {
                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "DELETE FROM " + TABLE_NAME + " where bookid = @id;";

                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add(new MySqlParameter("@id", id));

                    command.ExecuteNonQuery();
                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);
                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("책이 삭제되었습니다.");
                    txtbookid.Clear();
                    txtbookname.Clear();
                    txtAuthor.Clear();
                    txtPublisher.Clear();
                }
            }
            SLoad();
        }

        private void btnUpdate1_Click(object sender, EventArgs e)
        {
            string id = txtbookid.Text.Trim();
            string name = txtbookname.Text.Trim();
            string author = txtAuthor.Text.Trim();
            string publisher = txtPublisher.Text.Trim();
            bool bookExist = bookrespository.existBook(id);
            if (id == "")
            {
                showErrorMessage("책번호를 입력해주세요.", "오류", txtbookid);
            }
            else if (name == "")
            {
                showErrorMessage("책이름를 입력해주세요.", "오류", txtbookname);
            }
            else if (author == "")
            {
                showErrorMessage("저자를 입력해주세요.", "오류", txtAuthor);
            }
            else if (publisher == "")
            {
                showErrorMessage("출판사를 입력해주세요.", "오류", txtPublisher);
            }
            else
            {

                MySqlConnection connection = bookConnection();
                try
                {
                    string sql = "update " + TABLE_NAME + " set bookname = @name, author = @author, publisher = @publisher where bookid = @id;";
                    
                    MySqlCommand command = new MySqlCommand(sql, connection);
                    command.Parameters.Add(new MySqlParameter("@id", id));
                    command.Parameters.Add(new MySqlParameter("@name", name));
                    command.Parameters.Add(new MySqlParameter("@author", author));
                    command.Parameters.Add(new MySqlParameter("@publisher", publisher));
                    command.ExecuteNonQuery();

                }
                catch (Exception j)
                {
                    MessageBox.Show(j.Message);

                }
                finally
                {
                    connection.Close();
                    MessageBox.Show("책이 수정되었습니다.");
                    txtbookid.Clear();
                    txtbookname.Clear();
                    txtAuthor.Clear();
                    txtPublisher.Clear();
                }
                SLoad();
            }
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
                dgv_Search.DataSource = dsSearch;
                dgv_Search.DataMember = "dgv_Search";
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
        private void btnLoad_Click(object sender, EventArgs e)
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
                dgv_Search.DataSource = dsSearch;
                dgv_Search.DataMember = "dgv_Search";
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

        private void dgv_Search_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_Search.SelectedRows.Count >= 0)
                {
                    txtbookid.Text = dgv_Search.SelectedRows[0].Cells[0].Value.ToString();
                    txtbookname.Text = dgv_Search.SelectedRows[0].Cells[1].Value.ToString();
                    txtAuthor.Text = dgv_Search.SelectedRows[0].Cells[2].Value.ToString();
                    txtPublisher.Text = dgv_Search.SelectedRows[0].Cells[3].Value.ToString();
                }
                else
                    MessageBox.Show("누르신 곳은 빈칸입니다!");
            }
            catch (Exception)
            {
                //MessageBox.Show("열을 클릭해 주세요!");
            }
            dgv_Search.ReadOnly = true;

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Search.Rows[e.RowIndex];
                txtbookid.Text = row.Cells["bookid"].Value.ToString();
                txtbookname.Text = row.Cells["bookname"].Value.ToString();
                txtAuthor.Text = row.Cells["author"].Value.ToString();
                txtPublisher.Text = row.Cells["publisher"].Value.ToString();

            }
        }

    }
}
