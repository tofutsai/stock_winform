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
    public partial class FrmPasswordChange : Form
    {
        public FrmPasswordChange()
        {
            InitializeComponent();
            this.txtoldpassword.PasswordChar = '*';
            this.txtnewpassword.PasswordChar = '*';
            this.txtnewpasswoedcheck.PasswordChar = '*';
        }

        StockEntities db = new StockEntities();
        members member = new members();
        memberModel memberModel = new memberModel();

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                member = (members)this.Tag;
                string oldpassword = txtoldpassword.Text.Trim();
                oldpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldpassword, "SHA1");
                string newpassword = txtnewpassword.Text.Trim();
                
                string newpasswordcheck = txtnewpasswoedcheck.Text.Trim();
                


                if (oldpassword == member.password)
                {
                    if(newpassword != "" && newpasswordcheck != "")
                    {
                        newpassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpassword, "SHA1");
                        newpasswordcheck = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(newpasswordcheck, "SHA1");
                        if (newpassword == newpasswordcheck)
                        {
                            members Loginmember = db.members.Where(m => m.account == member.account).FirstOrDefault();
                            Loginmember.password = newpassword;

                            db.SaveChanges();
                            MessageBox.Show("密碼變更成功!!", "密碼變更", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("新密碼與新密碼確認不一致!!", "密碼變更", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("請輸入新密碼", "密碼變更", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("舊密碼輸入錯誤!!", "密碼變更", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
