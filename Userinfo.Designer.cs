
namespace test03
{
    partial class Userinfo
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtcpw1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnpwUpdate = new System.Windows.Forms.Button();
            this.txtCpw = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPn = new System.Windows.Forms.TextBox();
            this.txtage = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtuserid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUageUpdate = new System.Windows.Forms.Button();
            this.txtUage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnUpnUpdate = new System.Windows.Forms.Button();
            this.txtUpn = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnRcancel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtcpw1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnpwUpdate);
            this.groupBox2.Controls.Add(this.txtCpw);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(477, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(423, 103);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "비밀번호 수정";
            // 
            // txtcpw1
            // 
            this.txtcpw1.Location = new System.Drawing.Point(147, 70);
            this.txtcpw1.Name = "txtcpw1";
            this.txtcpw1.Size = new System.Drawing.Size(148, 27);
            this.txtcpw1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "비밀번호 재입력 :";
            // 
            // btnpwUpdate
            // 
            this.btnpwUpdate.Location = new System.Drawing.Point(321, 56);
            this.btnpwUpdate.Name = "btnpwUpdate";
            this.btnpwUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnpwUpdate.TabIndex = 5;
            this.btnpwUpdate.Text = "수정";
            this.btnpwUpdate.UseVisualStyleBackColor = true;
            this.btnpwUpdate.Click += new System.EventHandler(this.btnpwUpdate_Click);
            // 
            // txtCpw
            // 
            this.txtCpw.Location = new System.Drawing.Point(147, 31);
            this.txtCpw.Name = "txtCpw";
            this.txtCpw.Size = new System.Drawing.Size(148, 27);
            this.txtCpw.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "수정할 비밀번호 :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtPn);
            this.groupBox1.Controls.Add(this.txtage);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtuserid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(26, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(423, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "사용자 정보";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(303, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "새로고침";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtPn
            // 
            this.txtPn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPn.Location = new System.Drawing.Point(106, 130);
            this.txtPn.Name = "txtPn";
            this.txtPn.ReadOnly = true;
            this.txtPn.Size = new System.Drawing.Size(148, 27);
            this.txtPn.TabIndex = 8;
            // 
            // txtage
            // 
            this.txtage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtage.Location = new System.Drawing.Point(106, 86);
            this.txtage.Name = "txtage";
            this.txtage.ReadOnly = true;
            this.txtage.Size = new System.Drawing.Size(148, 27);
            this.txtage.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "나이 :";
            // 
            // txtuserid
            // 
            this.txtuserid.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtuserid.Location = new System.Drawing.Point(106, 45);
            this.txtuserid.Name = "txtuserid";
            this.txtuserid.ReadOnly = true;
            this.txtuserid.Size = new System.Drawing.Size(148, 27);
            this.txtuserid.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "전화번호 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(44, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "이름 :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnUageUpdate);
            this.groupBox3.Controls.Add(this.txtUage);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(477, 187);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(423, 103);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "나이 수정";
            // 
            // btnUageUpdate
            // 
            this.btnUageUpdate.Location = new System.Drawing.Point(321, 38);
            this.btnUageUpdate.Name = "btnUageUpdate";
            this.btnUageUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUageUpdate.TabIndex = 5;
            this.btnUageUpdate.Text = "수정";
            this.btnUageUpdate.UseVisualStyleBackColor = true;
            this.btnUageUpdate.Click += new System.EventHandler(this.btnUageUpdate_Click);
            // 
            // txtUage
            // 
            this.txtUage.Location = new System.Drawing.Point(147, 38);
            this.txtUage.Name = "txtUage";
            this.txtUage.Size = new System.Drawing.Size(148, 27);
            this.txtUage.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "수정할 나이 :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnUpnUpdate);
            this.groupBox4.Controls.Add(this.txtUpn);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(477, 337);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(423, 103);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "전화번호 수정";
            // 
            // btnUpnUpdate
            // 
            this.btnUpnUpdate.Location = new System.Drawing.Point(321, 38);
            this.btnUpnUpdate.Name = "btnUpnUpdate";
            this.btnUpnUpdate.Size = new System.Drawing.Size(75, 32);
            this.btnUpnUpdate.TabIndex = 5;
            this.btnUpnUpdate.Text = "수정";
            this.btnUpnUpdate.UseVisualStyleBackColor = true;
            this.btnUpnUpdate.Click += new System.EventHandler(this.btnUpnUpdate_Click);
            // 
            // txtUpn
            // 
            this.txtUpn.Location = new System.Drawing.Point(147, 38);
            this.txtUpn.Name = "txtUpn";
            this.txtUpn.Size = new System.Drawing.Size(148, 27);
            this.txtUpn.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "수정할 전화번호 :";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnRcancel);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(26, 260);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(423, 193);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "회원 탈퇴 요청";
            // 
            // btnRcancel
            // 
            this.btnRcancel.Location = new System.Drawing.Point(196, 138);
            this.btnRcancel.Name = "btnRcancel";
            this.btnRcancel.Size = new System.Drawing.Size(125, 30);
            this.btnRcancel.TabIndex = 3;
            this.btnRcancel.Text = "탈퇴 요청 취소";
            this.btnRcancel.UseVisualStyleBackColor = true;
            this.btnRcancel.Click += new System.EventHandler(this.btnRcancel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(38, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "탈퇴 요청";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "탈퇴 요청을 보내시겠습니까?";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(258, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "주의! 회원 탈퇴시 3일 뒤 삭제됩니다!";
            // 
            // Userinfo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Userinfo";
            this.Size = new System.Drawing.Size(985, 598);
            this.Load += new System.EventHandler(this.Userinfo_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnpwUpdate;
        private System.Windows.Forms.TextBox txtCpw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPn;
        private System.Windows.Forms.TextBox txtage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtuserid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUageUpdate;
        private System.Windows.Forms.TextBox txtUage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnUpnUpdate;
        private System.Windows.Forms.TextBox txtUpn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtcpw1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRcancel;
    }
}
