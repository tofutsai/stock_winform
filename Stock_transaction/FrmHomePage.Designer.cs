namespace Stock_transaction
{
    partial class FrmHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAPI = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.我的自選 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblbankmoney = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnselect = new System.Windows.Forms.Button();
            this.txtnum = new System.Windows.Forms.TextBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnupdate = new System.Windows.Forms.Button();
            this.lblname = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblbank = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnmyselect = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.刪除 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.交易 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.連接網頁 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnphoto = new System.Windows.Forms.Button();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStocksave = new System.Windows.Forms.Button();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.lblmoney = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblname1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnStockRemain = new System.Windows.Forms.Button();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.賣出 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAPI
            // 
            this.btnAPI.Location = new System.Drawing.Point(10, 24);
            this.btnAPI.Name = "btnAPI";
            this.btnAPI.Size = new System.Drawing.Size(150, 34);
            this.btnAPI.TabIndex = 0;
            this.btnAPI.Text = "查詢當日資訊";
            this.btnAPI.UseVisualStyleBackColor = true;
            this.btnAPI.Click += new System.EventHandler(this.btnAPI_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.我的自選});
            this.dataGridView1.Location = new System.Drawing.Point(30, 98);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(1035, 468);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // 我的自選
            // 
            this.我的自選.FalseValue = "F";
            this.我的自選.HeaderText = "加入自選";
            this.我的自選.Name = "我的自選";
            this.我的自選.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.我的自選.TrueValue = "T";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1108, 615);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblbankmoney);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.btnselect);
            this.tabPage1.Controls.Add(this.txtnum);
            this.tabPage1.Controls.Add(this.btnLogout);
            this.tabPage1.Controls.Add(this.btnupdate);
            this.tabPage1.Controls.Add(this.lblname);
            this.tabPage1.Controls.Add(this.lbl);
            this.tabPage1.Controls.Add(this.btnAPI);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1100, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "證券清單";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(27, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 10;
            // 
            // lblbankmoney
            // 
            this.lblbankmoney.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblbankmoney.Location = new System.Drawing.Point(784, 54);
            this.lblbankmoney.Name = "lblbankmoney";
            this.lblbankmoney.Size = new System.Drawing.Size(100, 22);
            this.lblbankmoney.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(694, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "帳戶餘額 :";
            // 
            // btnselect
            // 
            this.btnselect.Location = new System.Drawing.Point(274, 24);
            this.btnselect.Name = "btnselect";
            this.btnselect.Size = new System.Drawing.Size(190, 34);
            this.btnselect.TabIndex = 7;
            this.btnselect.Text = "查詢證券代號/名稱";
            this.btnselect.UseVisualStyleBackColor = true;
            this.btnselect.Click += new System.EventHandler(this.btnselect_Click);
            // 
            // txtnum
            // 
            this.txtnum.Location = new System.Drawing.Point(166, 24);
            this.txtnum.MaxLength = 6;
            this.txtnum.Name = "txtnum";
            this.txtnum.Size = new System.Drawing.Size(100, 31);
            this.txtnum.TabIndex = 6;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(942, 54);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(123, 36);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "登出";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(942, 12);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(123, 36);
            this.btnupdate.TabIndex = 4;
            this.btnupdate.Text = "修改密碼";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btnupdate_Click);
            // 
            // lblname
            // 
            this.lblname.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblname.Location = new System.Drawing.Point(784, 12);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(100, 22);
            this.lblname.TabIndex = 3;
            // 
            // lbl
            // 
            this.lbl.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lbl.Location = new System.Drawing.Point(694, 12);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(100, 22);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "帳戶姓名 :";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblbank);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.btnmyselect);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1100, 581);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "我的自選清單";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblbank
            // 
            this.lblbank.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblbank.Location = new System.Drawing.Point(284, 26);
            this.lblbank.Name = "lblbank";
            this.lblbank.Size = new System.Drawing.Size(100, 22);
            this.lblbank.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(194, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "帳戶餘額 :";
            // 
            // btnmyselect
            // 
            this.btnmyselect.Location = new System.Drawing.Point(30, 18);
            this.btnmyselect.Margin = new System.Windows.Forms.Padding(4);
            this.btnmyselect.Name = "btnmyselect";
            this.btnmyselect.Size = new System.Drawing.Size(112, 34);
            this.btnmyselect.TabIndex = 12;
            this.btnmyselect.Text = "自選清單";
            this.btnmyselect.UseVisualStyleBackColor = true;
            this.btnmyselect.Click += new System.EventHandler(this.btnmyselect_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.刪除,
            this.交易,
            this.連接網頁});
            this.dataGridView2.Location = new System.Drawing.Point(30, 60);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 31;
            this.dataGridView2.Size = new System.Drawing.Size(1035, 492);
            this.dataGridView2.TabIndex = 11;
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // 刪除
            // 
            this.刪除.HeaderText = "刪除";
            this.刪除.Name = "刪除";
            this.刪除.Text = "刪除";
            // 
            // 交易
            // 
            this.交易.HeaderText = "交易";
            this.交易.Name = "交易";
            this.交易.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.交易.Text = "買進";
            // 
            // 連接網頁
            // 
            this.連接網頁.HeaderText = "連接網頁";
            this.連接網頁.Name = "連接網頁";
            this.連接網頁.Text = "鉅亨網";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnUp);
            this.tabPage3.Controls.Add(this.btnphoto);
            this.tabPage3.Controls.Add(this.picBox);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.btnStocksave);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.lblmoney);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.lblname1);
            this.tabPage3.Controls.Add(this.lbl2);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1100, 581);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "我的庫存";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(630, 93);
            this.btnUp.Margin = new System.Windows.Forms.Padding(4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(112, 34);
            this.btnUp.TabIndex = 15;
            this.btnUp.Text = "上傳修改";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnphoto
            // 
            this.btnphoto.Location = new System.Drawing.Point(630, 26);
            this.btnphoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnphoto.Name = "btnphoto";
            this.btnphoto.Size = new System.Drawing.Size(112, 34);
            this.btnphoto.TabIndex = 14;
            this.btnphoto.Text = "修改照片";
            this.btnphoto.UseVisualStyleBackColor = true;
            this.btnphoto.Click += new System.EventHandler(this.btnphoto_Click);
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(411, 14);
            this.picBox.Margin = new System.Windows.Forms.Padding(4);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(196, 178);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox.TabIndex = 13;
            this.picBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(306, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 22);
            this.label4.TabIndex = 12;
            this.label4.Text = "帳戶照片 :";
            // 
            // btnStocksave
            // 
            this.btnStocksave.Location = new System.Drawing.Point(28, 93);
            this.btnStocksave.Margin = new System.Windows.Forms.Padding(4);
            this.btnStocksave.Name = "btnStocksave";
            this.btnStocksave.Size = new System.Drawing.Size(112, 34);
            this.btnStocksave.TabIndex = 11;
            this.btnStocksave.Text = "庫存清單";
            this.btnStocksave.UseVisualStyleBackColor = true;
            this.btnStocksave.Click += new System.EventHandler(this.btnStocksave_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(28, 198);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 31;
            this.dataGridView3.Size = new System.Drawing.Size(1018, 368);
            this.dataGridView3.TabIndex = 10;
            // 
            // lblmoney
            // 
            this.lblmoney.Location = new System.Drawing.Point(112, 66);
            this.lblmoney.Name = "lblmoney";
            this.lblmoney.Size = new System.Drawing.Size(100, 22);
            this.lblmoney.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "帳戶餘額 :";
            // 
            // lblname1
            // 
            this.lblname1.Location = new System.Drawing.Point(112, 33);
            this.lblname1.Name = "lblname1";
            this.lblname1.Size = new System.Drawing.Size(100, 22);
            this.lblname1.TabIndex = 5;
            // 
            // lbl2
            // 
            this.lbl2.Location = new System.Drawing.Point(26, 33);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(98, 22);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "帳戶姓名 :";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnStockRemain);
            this.tabPage4.Controls.Add(this.dataGridView4);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1100, 581);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "未實現損益試算";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnStockRemain
            // 
            this.btnStockRemain.Location = new System.Drawing.Point(40, 20);
            this.btnStockRemain.Margin = new System.Windows.Forms.Padding(4);
            this.btnStockRemain.Name = "btnStockRemain";
            this.btnStockRemain.Size = new System.Drawing.Size(122, 34);
            this.btnStockRemain.TabIndex = 1;
            this.btnStockRemain.Text = "未實現損益";
            this.btnStockRemain.UseVisualStyleBackColor = true;
            this.btnStockRemain.Click += new System.EventHandler(this.btnStockRemain_Click);
            // 
            // dataGridView4
            // 
            this.dataGridView4.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.賣出});
            this.dataGridView4.Location = new System.Drawing.Point(40, 78);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowTemplate.Height = 31;
            this.dataGridView4.Size = new System.Drawing.Size(1006, 471);
            this.dataGridView4.TabIndex = 0;
            this.dataGridView4.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView4_CellClick);
            // 
            // 賣出
            // 
            this.賣出.HeaderText = "交易";
            this.賣出.Name = "賣出";
            this.賣出.Text = "賣出";
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 30);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage5.Size = new System.Drawing.Size(1100, 581);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "已實現損益";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // FrmHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 615);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmHomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHomePage";
            this.Load += new System.EventHandler(this.FrmHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAPI;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblname1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btnselect;
        private System.Windows.Forms.TextBox txtnum;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnmyselect;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 我的自選;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewButtonColumn 刪除;
        private System.Windows.Forms.DataGridViewButtonColumn 交易;
        private System.Windows.Forms.DataGridViewLinkColumn 連接網頁;
        private System.Windows.Forms.DataGridViewButtonColumn 賣出;
        private System.Windows.Forms.Button btnStocksave;
        internal System.Windows.Forms.Label lblmoney;
        internal System.Windows.Forms.Label lblbankmoney;
        private System.Windows.Forms.Button btnStockRemain;
        internal System.Windows.Forms.DataGridView dataGridView3;
        internal System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Button btnphoto;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.TabPage tabPage5;
        internal System.Windows.Forms.Label lblbank;
        private System.Windows.Forms.Label label6;
    }
}