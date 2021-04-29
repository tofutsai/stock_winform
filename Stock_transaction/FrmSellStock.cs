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
    public partial class FrmSellStock : Form
    {
        public FrmSellStock()
        {
            InitializeComponent();
        }
        //接收tag
        DataGridViewRow buttonRow = new DataGridViewRow();
        //接收homepage的member
        public members member;

        stockremain stockRemain = new stockremain();

        stocksave stockSave = new stocksave();
        //接收FrmHomePage值
        public FrmHomePage frmHomePage;

        dataModel datamodel = new dataModel();

        //db等於datamodel靜態全域db
        StockEntities db = dataModel.db;



        private void FrmSellStock_Load(object sender, EventArgs e)
        {
            try
            {
                //接收tag
                buttonRow = (DataGridViewRow)this.Tag;
                this.txtAccount.Text = buttonRow.Cells[2].Value.ToString();
                this.txtStocknum.Text = buttonRow.Cells[3].Value.ToString();
                this.txtStockName.Text = buttonRow.Cells[4].Value.ToString();
                this.txtPrice.Text = buttonRow.Cells[8].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtNum.Text))
                {
                    txtMoney.Text = "0";
                    return;
                }
                //常數 代表1000股
                const double number = 1000;
                double price = double.Parse(txtPrice.Text);
                double Num = double.Parse(txtNum.Text.Trim());
                txtMoney.Text = (price * Num * number).ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                members member = this.member;

                if (string.IsNullOrEmpty(this.txtNum.Text) || this.txtNum.Text == "0")
                {
                    MessageBox.Show("請輸入賣出張數!!");
                    this.txtMoney.Text = "0";
                    return;
                }
                else if (int.Parse(this.txtNum.Text) > int.Parse(buttonRow.Cells[6].Value.ToString()))
                {
                    MessageBox.Show("賣出張數超出庫存張數@@，請重新輸入!!");
                    this.txtNum.Text = "";
                    this.txtMoney.Text = "0";
                    return;
                }
                else
                {
                    MessageBox.Show("賣出成功!!");           
                }
                
                //賣出張數，修改資料表
                if (int.Parse(this.txtNum.Text) == int.Parse(buttonRow.Cells[6].Value.ToString()))
                {
                    stocksave save = db.stocksave.AsEnumerable().Where(s => s.證券代號 == buttonRow.Cells[3].Value.ToString() && s.account == member.account).FirstOrDefault();
                    datamodel.Delete(save);
                    stockremain remain = db.stockremain.AsEnumerable().Where(r => r.證券代號 == buttonRow.Cells[3].Value.ToString() && r.account == member.account).FirstOrDefault();
                    datamodel.Delete(remain);
                }
                else if (int.Parse(this.txtNum.Text) < int.Parse(buttonRow.Cells[6].Value.ToString()))
                {
                    stocksave save = db.stocksave.AsEnumerable().Where(s => s.證券代號 == buttonRow.Cells[3].Value.ToString() && s.account == member.account).FirstOrDefault();

                    datamodel.Updatestocksave(save, int.Parse(this.txtNum.Text));

                    stockremain remainsave = db.stockremain.AsEnumerable().Where(r => r.證券代號 == buttonRow.Cells[3].Value.ToString() && r.account == member.account).FirstOrDefault();
                    datamodel.Updatestockremain(remainsave, int.Parse(this.txtNum.Text));
                }
               
                double remainmoney = (double)member.bankmoney + double.Parse(txtMoney.Text);

                member.bankmoney = (int)remainmoney;
                var mem = (from m in db.members
                           where m.account == member.account
                           select m).FirstOrDefault();

                if (mem == null) return;
                mem.bankmoney = member.bankmoney;
                db.SaveChanges();

                //frmHomePage傳值
                FrmHomePage frmHomePage = this.frmHomePage;
                frmHomePage.lblbankmoney.Text = member.bankmoney.ToString();
                frmHomePage.lblmoney.Text = member.bankmoney.ToString();
                frmHomePage.lblbank.Text = member.bankmoney.ToString();

                //frmHomePage.dataGridView3.DataSource = null;
                //frmHomePage.dataGridView4.DataSource = null;
                frmHomePage.dataGridView4.DataSource = db.stockremain.Where(s => s.account == member.account).ToList();
                frmHomePage.dataGridView4.Columns["id"].Visible = false;
                frmHomePage.dataGridView3.DataSource = db.stocksave.Where(s => s.account == member.account).ToList();
                frmHomePage.dataGridView3.Columns["id"].Visible = false;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
