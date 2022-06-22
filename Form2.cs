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
using test03.user;
using System.Text.RegularExpressions;

namespace test03
{
    public partial class Form2 : Form
    {
        UserRepository userRepository = new UserRepository();

        public Form2()
        {
            InitializeComponent();
            txt_Pw01.PasswordChar = '*';
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btn_register01_Click(object sender, EventArgs e)
        {
            string id = txt_Id01.Text.Trim();
            string pw = txt_Pw01.Text.Trim();
            string name = txt_Name.Text.Trim();
            string age = txt_Age.Text.Trim();
            string phone = txt_PN.Text.Trim();

            if (id == "")
            {
                showErrorMessage("아이디를 입력해주세요.", "오류", txt_Id01);
            }else if (idValidation(id))
            {
                showErrorMessage("아이디는 5자 이상 50자 이하로 입력해주세요.", "오류", txt_Id01);
            }
            else if (pw == "")
            {
                showErrorMessage("사용할 비밀번호를 입력해주세요.", "오류", txt_Pw01);
            } else if (name == "")
            {
                showErrorMessage("이름을 입력해주세요.", "오류", txt_Name);
            } else if (age == "")
            {
                showErrorMessage("나이를 입력해주세요.", "오류", txt_Age);
            } else if (!isNumber(age)) {
                showErrorMessage("나이는 숫자만 입력해주세요.", "오류", txt_Age);
            }
            else if (phone == "")
            {
                showErrorMessage("전화번호를 입력해주세요.", "오류", txt_PN);
            }else if (!isPhone(phone))
            {
                showErrorMessage("전화번호 형식은 [000-0000-0000] 으로 입력해주세요.", "오류", txt_PN);
            }
            else
            {
                bool alreadyExistUser = userRepository.existUser(id);

                if (alreadyExistUser)
                {
                    showErrorMessage("중복된 아이디가 존재합니다.", "오류", txt_Id01);
                    return;
                }

                // 회원가입
                UserDTO userDTO = new UserDTO(id, pw, name, age, phone);
                bool success = userRepository.signUp(userDTO);
                if (success)
                {
                    MessageBox.Show("회원가입 완료", "회원가입", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
        }
        
        private bool idValidation(string id)
        {
            return id.Length > 50 || id.Length < 5;
        }

        private bool pwValidation(string pw)
        {
            return false;
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
            }catch(FormatException e)
            {
                return false;
            }
        }

        private void showErrorMessage(String message, String title, TextBox target)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            target.Focus();
        }

        private void txt_Id01_KeyUp_1(object sender, KeyEventArgs e)
        {
            string id = txt_Id01.Text.Trim();
            bool alreadyExistUser = userRepository.existUser(id);
            if(id == "")
            {
                lb_existUser.Text = "아이디를 입력해주세요.";
            }else if (!idValidation(id))
            {
                if (alreadyExistUser)
                {
                    lb_existUser.Text = "중복된 아이디가 존재합니다.";
                }
                else
                {
                    lb_existUser.Text = "사용 가능한 아이디입니다.";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
