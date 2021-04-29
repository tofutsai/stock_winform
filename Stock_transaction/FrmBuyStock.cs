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
    public partial class FrmBuyStock : Form
    {
        public FrmBuyStock()
        {
            InitializeComponent();
        }

        DataGridViewRow buttonRow = new DataGridViewRow();

        StockEntities db = new StockEntities();

        stocksave stock = new stocksave();

        stockremain stockRemain = new stockremain();

        data Data = new data();

        public FrmHomePage frmHomePage;

        //member傳值
        public members member;

        private void FrmBuyStock_Load(object sender, EventArgs e)
        {
            try
            {
                //接收tag
                buttonRow = (DataGridViewRow)this.Tag;
                this.txtAccount.Text = buttonRow.Cells[3].Value.ToString();
                this.txtStocknum.Text = buttonRow.Cells[4].Value.ToString();
                this.txtStockName.Text = buttonRow.Cells[5].Value.ToString();
                this.txtPrice.Text = buttonRow.Cells[12].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        const double number = 1000;

        private void txtNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtNum.Text))
                {
                    txtMoney.Text = "0";
                    return;
                }
                
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
                //member傳值
                members member = this.member;

                if (string.IsNullOrEmpty(this.txtNum.Text) || this.txtNum.Text == "0")
                {
                    MessageBox.Show("請輸入購買張數!!");
                    this.txtMoney.Text = "0";
                    return;
                }
                else if (double.Parse(txtMoney.Text) > member.bankmoney)
                {
                    MessageBox.Show("買進總金額超過帳戶金額QQ，請重新輸入!!");
                    this.txtNum.Text = "";
                    this.txtMoney.Text = "0";
                    return;
                }
                else
                {
                    MessageBox.Show("買入成功!!");
                }

                double remainmoney = (double)member.bankmoney - double.Parse(txtMoney.Text);

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

                //存入我的庫存 stocksave
                stock.account = this.txtAccount.Text;
                stock.證券代號 = this.txtStocknum.Text;
                stock.證券名稱 = this.txtStockName.Text;
                stock.買進價格 = this.txtPrice.Text;
                stock.張數 = this.txtNum.Text;
                stock.總金額 = this.txtMoney.Text;

                db.stocksave.Add(stock);

                db.SaveChanges();
                

                //取得收盤價，存入未實現損益
                var price = (from d in db.data
                             join s in db.stocksave.Where(s => s.account == member.account)
                             on d.證券代號 equals s.證券代號
                             select d.收盤價).ToList();

                stockRemain.account = member.account;
                stockRemain.證券代號 = stock.證券代號;
                stockRemain.證券名稱 = stock.證券名稱;
                stockRemain.成交均價 = stock.買進價格;
                stockRemain.張數 = stock.張數;
                stockRemain.持有成本 = stock.總金額;
                for (int i = 0; i < price.Count(); i++)
                {
                    var code = (from d in db.data
                                join s in db.stocksave.Where(s => s.account == member.account)
                                on d.證券代號 equals s.證券代號
                                select d.證券代號).ToList();
                    if (stockRemain.證券代號 == code[i])
                    {
                        stockRemain.現價 = price[i].ToString();
                    }

                }
                
                stockRemain.現值 = (double.Parse(stockRemain.現價) * double.Parse(stock.張數.ToString()) * number).ToString();
                stockRemain.預估收入 = (double.Parse(stockRemain.現價) * double.Parse(stock.張數.ToString())*number).ToString();
                stockRemain.預估損益 = (double.Parse(stockRemain.預估收入) - double.Parse(stockRemain.持有成本)).ToString();
                stockRemain.預估獲利率 = ((double.Parse(stockRemain.預估損益) / double.Parse(stockRemain.持有成本)) * 100).ToString("f2") + "%";

                db.stockremain.Add(stockRemain);
                db.SaveChanges();

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
