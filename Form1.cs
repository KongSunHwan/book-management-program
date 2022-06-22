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


namespace test03
{
    public partial class Form1 : Form
    {
        UserRepository userRepository = new UserRepository();

        public static string we;

        public Form1()
        {
            InitializeComponent();
            txt_Pw.PasswordChar = '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            //공백체크
            string id = txt_Id.Text.Trim();
            string pw = txt_Pw.Text.Trim();

            if (id == "")
            {
                showErrorMessage("아이디를 입력해주세요.", "오류", txt_Id);
            }
            else if(pw == "")
            {
                showErrorMessage("비밀번호를 입력해주세요.", "오류", txt_Pw);
            }
            else
            {
                UserDTO userDTO = userRepository.login(id, pw);
                if(userDTO == null)
                {
                    // 로그인 못합
                    showErrorMessage("아이디 혹은 비밀번호가 일치하지 않습니다.", "오류", txt_Pw);
                }
                else
                {
                    // 로그인
                    MessageBox.Show("환영합니다, " + txt_Id.Text + " 님","환영합니다!",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    we = id;
                    Form4 frn4 = new Form4();
                    Form1 frn1 = new Form1();
                    this.Hide();
                    frn4.Show();
                    
                }
            }
        }

        public string UnameReturn(string x)
        {
            x = we;
            return x;
        }
        private void btn_register_Click(object sender, EventArgs e)
        {
            Form2 frn2 = new Form2();
            frn2.Show();
        }

        private void showErrorMessage(String message, String title, TextBox target)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            target.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            if (txt_Id.Text == "1" && txt_Pw.Text == "2")
            {
                Form3 frm3 = new Form3();
                MessageBox.Show("관리자님 환영합니다!", "관리자 모드", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm3.Show();
                this.Hide();
            }
            else
                MessageBox.Show("관리자번호가 아닙니다");
        }
    }
}
