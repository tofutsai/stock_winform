using Stock_transaction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;

namespace Stock_transaction
{
    public partial class FrmSignup : Form
    {
        public FrmSignup()
        {
            InitializeComponent();
            this.picBox.AllowDrop = true;
            this.picBox.DragEnter += PicBox_DragEnter;
            //this.picBox.DragEnter += (s, e) => { e.Effect = DragDropEffects.All };
            this.picBox.DragDrop += PicBox_DragDrop;

        }

        private void PicBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.picBox.Image = Image.FromFile(files[0]);
        }

        private void PicBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        memberModel memberModel = new memberModel();

        private void FrmAddmember_Load(object sender, EventArgs e)
        {
            txtAccount.Text = "請輸入身分證字號";
            txtAccount.ForeColor = Color.Gray;
            txtPassword.Text = "請輸入8~16位英數混合";
            txtPassword.ForeColor = Color.Gray;
            txtPasswordCheck.Text = "請再次輸入密碼";
            txtPasswordCheck.ForeColor = Color.Gray;

        }
        bool txtAccounthastext = false;
        private void txtAccount_Enter(object sender, EventArgs e)
        {
            if (txtAccounthastext == false)
            {
                txtAccount.Text = "";
                txtAccount.ForeColor = Color.Black;
            }

        }

        private void txtAccount_Leave(object sender, EventArgs e)
        {
            if (txtAccount.Text == "")
            {
                txtAccount.Text = "請輸入身分證字號";
                txtAccount.ForeColor = Color.Gray;
                txtAccounthastext = false;
            }
            else
            {
                txtAccounthastext = true;
            }
        }
        bool txtPasswordhastext = false;
        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPasswordhastext == false)
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.ForeColor = Color.Black;
            }

        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                //passwordchar還原為預設
                txtPassword.PasswordChar = default(char);
                txtPassword.Text = "請輸入8~12位英數混合";
                txtPasswordhastext = false;
                txtPassword.ForeColor = Color.Gray;
            }
            else
            {
                txtPasswordhastext = true;
            }
        }
        bool txtPasswordcheckhastext = false;
        private void txtPasswordCheck_Enter(object sender, EventArgs e)
        {
            if (txtPasswordcheckhastext == false)
            {
                txtPasswordCheck.Text = "";
                txtPasswordCheck.PasswordChar = '*';
                txtPasswordCheck.ForeColor = Color.Black;
            }
        }

        private void txtPasswordCheck_Leave(object sender, EventArgs e)
        {
            if (txtPasswordCheck.Text == "")
            {
                //passwordchar還原為預設
                txtPasswordCheck.PasswordChar = default(char);
                txtPasswordCheck.Text = "請再次輸入密碼";
                txtPasswordcheckhastext = false;
                txtPasswordCheck.ForeColor = Color.Gray;
            }
            else
            {
                txtPasswordcheckhastext = true;
            }
        }

        private void btnphoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (new string[]{".jpg",".png", ".gif", ".bmp", "jpeg" }.Contains(Path.GetExtension(openFileDialog.FileName.ToLower())))
                {
                    this.picBox.Image = Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("請選擇圖片檔!!");
                }
                
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {

                members newmember = new members();

                string account = txtAccount.Text.Trim();
                string password = txtPassword.Text.Trim();
                string passwordcheck = txtPasswordCheck.Text.Trim();
                string name = txtName.Text.Trim();

                bool Account = Accountcheck(account);
                bool Password = Passwordcheck(password);

                

                const int money = 1000000;

                //組鍵參考system.web
                password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(password, "SHA1");
                passwordcheck = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(passwordcheck, "SHA1");

                if (Account && Password && password == passwordcheck)
                {
                    
                    byte[] bytes = null;
                    if(bytes != null)
                    {
                        System.IO.MemoryStream ms = new System.IO.MemoryStream();
                        this.picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        bytes = ms.GetBuffer();
                    }
                   
                    newmember.account = account;
                    newmember.password = password;
                    newmember.name = name;
                    newmember.bankmoney = money;
                    newmember.photo = bytes;

                    if (memberModel.create(newmember) > 0)
                    {
                        MessageBox.Show("註冊成功", "註冊", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("此身份證字號已註冊", "註冊", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    
                }
                else
                {
                    MessageBox.Show("格式不符，請重新輸入帳號或密碼", "註冊", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private bool Accountcheck(string account)
        {
            bool result = Regex.IsMatch(account, @"^[A-Z]{1}[1-2]{1}[0-9]{8}$");
            return result;
        }

        private bool Passwordcheck(string password)
        {
            bool result = Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z]).{8,12}$");
            return result;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
