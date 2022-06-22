
namespace test03.user
{
    partial class UserCtrol
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgv_SearchU = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPublisherU = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtAuthorU = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtbooknameU = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtbookidU = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.btnselect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SearchU)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_SearchU);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(433, 46);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(467, 273);
            this.groupBox3.TabIndex = 55;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "도서 현황";
            // 
            // dgv_SearchU
            // 
            this.dgv_SearchU.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_SearchU.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_SearchU.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SearchU.Location = new System.Drawing.Point(7, 18);
            this.dgv_SearchU.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgv_SearchU.Name = "dgv_SearchU";
            this.dgv_SearchU.RowHeadersWidth = 51;
            this.dgv_SearchU.RowTemplate.Height = 27;
            this.dgv_SearchU.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_SearchU.Size = new System.Drawing.Size(454, 231);
            this.dgv_SearchU.TabIndex = 0;
            this.dgv_SearchU.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SearchU_CellClick);
            this.dgv_SearchU.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SearchU_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.txtPublisherU);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txtAuthorU);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtbooknameU);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtbookidU);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(53, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 173);
            this.groupBox1.TabIndex = 48;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "도서정보";
            // 
            // txtPublisherU
            // 
            this.txtPublisherU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPublisherU.Location = new System.Drawing.Point(104, 129);
            this.txtPublisherU.Name = "txtPublisherU";
            this.txtPublisherU.ReadOnly = true;
            this.txtPublisherU.Size = new System.Drawing.Size(201, 27);
            this.txtPublisherU.TabIndex = 37;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(36, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 20);
            this.label13.TabIndex = 36;
            this.label13.Text = "출판사 :";
            // 
            // txtAuthorU
            // 
            this.txtAuthorU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAuthorU.Location = new System.Drawing.Point(104, 96);
            this.txtAuthorU.Name = "txtAuthorU";
            this.txtAuthorU.ReadOnly = true;
            this.txtAuthorU.Size = new System.Drawing.Size(201, 27);
            this.txtAuthorU.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(51, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 20);
            this.label12.TabIndex = 34;
            this.label12.Text = "저자 :";
            // 
            // txtbooknameU
            // 
            this.txtbooknameU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbooknameU.Location = new System.Drawing.Point(104, 60);
            this.txtbooknameU.Name = "txtbooknameU";
            this.txtbooknameU.ReadOnly = true;
            this.txtbooknameU.Size = new System.Drawing.Size(201, 27);
            this.txtbooknameU.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(36, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(62, 20);
            this.label11.TabIndex = 32;
            this.label11.Text = "책이름 :";
            // 
            // txtbookidU
            // 
            this.txtbookidU.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtbookidU.Location = new System.Drawing.Point(104, 29);
            this.txtbookidU.Name = "txtbookidU";
            this.txtbookidU.ReadOnly = true;
            this.txtbookidU.Size = new System.Drawing.Size(201, 27);
            this.txtbookidU.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "책고유번호 :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(53, 338);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(847, 183);
            this.dataGridView1.TabIndex = 58;
            // 
            // txtTest
            // 
            this.txtTest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTest.Location = new System.Drawing.Point(53, 294);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(180, 27);
            this.txtTest.TabIndex = 57;
            this.txtTest.Text = "검색할 책이름, 저자, 출판사를 입력해주세요.";
            // 
            // btnselect
            // 
            this.btnselect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnselect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnselect.Location = new System.Drawing.Point(283, 285);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(62, 34);
            this.btnselect.TabIndex = 56;
            this.btnselect.Text = "조회";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "도서검색";
            // 
            // UserCtrol
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.txtTest);
            this.Controls.Add(this.btnselect);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserCtrol";
            this.Size = new System.Drawing.Size(985, 598);
            this.Load += new System.EventHandler(this.UserCtrol_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SearchU)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgv_SearchU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPublisherU;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtAuthorU;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtbooknameU;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtbookidU;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.Label label1;
    }
}
