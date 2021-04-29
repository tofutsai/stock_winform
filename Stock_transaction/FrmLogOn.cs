using Stock_transaction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock_transaction
{
    public partial class FrmLogOn : Form
    {
        

        public FrmLogOn()
        {
            InitializeComponent();
            this.txtPassword.PasswordChar = '*';
            this.txtAccount.Text = "A123456789";
            this.txtPassword.Text = "123qweasd";

        }

        StockEntities db = new StockEntities();

        public members member = new members();

        memberModel memberModel = new memberModel();

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            FrmSignup signup = new FrmSignup();
            signup.ShowDialog();
        }

        private void btnLogOn_Click(object sender, EventArgs e)
        {

            string account = txtAccount.Text.Trim();
            string password = txtPassword.Text.Trim();
            password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");

            member = memberModel.LogOncheck(account, password);

            if(member != null)
            {
                this.txtAccount.Text = "";
                this.txtPassword.Text = "";
                FrmHomePage frm = new FrmHomePage();
                frm.Tag = member;
               
                if (this.cbox.Checked)
                {
                    this.txtAccount.Text = member.account;
                }
                else
                {
                    this.txtAccount.Text = "";
                }
                frm.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("請重新輸入帳號或密碼", "登入訊息", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
  
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnabout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("此為非同步測試證券，所有交易均未列入手續費及證交稅之計算!" +
                "\n測試帳戶金額均為新台幣100萬。\nUI介面十分簡陋請多多包涵XD\n" +
                "使用上如有bug敬請見諒QQ", "關於", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
