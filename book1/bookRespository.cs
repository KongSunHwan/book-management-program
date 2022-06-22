using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test03.book1;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace test03.book1
{
    class bookRespository : bookconnection
    {
        private string TABLE_NAME = "books";

        //책이 존재하는가
        public bool existBook(string id)
        {
            MySqlConnection connection = bookConnection();
            try
            {
                string sql = "SELECT * FROM " + TABLE_NAME + " WHERE bookid = @UserId";

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


        public bookconnection search(string id, string bname)
        {
            MySqlConnection connection = bookConnection();
            try
            {
                string sql = "SELECT bookid, bookname \n";
                sql += "FROM " + TABLE_NAME + " \n";
                
               
                MySqlCommand command = new MySqlCommand(sql, connection);
                
                MySqlDataReader table = command.ExecuteReader();

                while (table.Read())
                {
                    
                }

                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
