using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test03.repository;
using test03.user;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace test03
{
    // 회원 관련된 db저장소를 userRepository로 정의할께
    //repository는 저장소라는 뜻
    class UserRepository : CommonRepository
    {
        private string TABLE_NAME = "users1";
        

        public bool existUser(string id)
        {
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "SELECT * FROM " + TABLE_NAME + " WHERE UserId = @UserId";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@UserId", id));

                MySqlDataReader table = command.ExecuteReader();

                return table.HasRows;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        // 로그인
        public UserDTO login(string id, string pw)
        {
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "SELECT UserId, userPw, username, userage, userpn \n";
                sql += "FROM "+ TABLE_NAME + " \n";
                sql += "WHERE UserId = @UserId AND UserPw = @UserPw \n";

                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@UserId", id));
                command.Parameters.Add(new MySqlParameter("@UserPw", pw));

                MySqlDataReader table = command.ExecuteReader();

                if (table.Read())
                {
                    return new UserDTO(
                              table.GetString(0),
                              table.GetString(1),
                              table.GetString(2),
                              table.GetString(3),
                              table.GetString(4)
                    );
                }
                return null;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                connection.Close();
            }
        }
        
        // 회원가입
        public bool signUp(UserDTO userDTO)
        {
            MySqlConnection connection = getConnection();
            try
            {
                string sql = "INSERT INTO " + TABLE_NAME + " VALUES (@id, @pw, @name, @age, @phone, now());";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.Add(new MySqlParameter("@id", userDTO.Id));
                command.Parameters.Add(new MySqlParameter("@pw", userDTO.Pw));
                command.Parameters.Add(new MySqlParameter("@name", userDTO.Name));
                command.Parameters.Add(new MySqlParameter("@age", userDTO.Age));
                command.Parameters.Add(new MySqlParameter("@phone", userDTO.Phone));

                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            finally
            {
                connection.Close();
            }
            return true;
        }
    }
}
