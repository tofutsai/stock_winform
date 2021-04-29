using Stock_transaction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Stock_transaction
{
    public partial class FrmHomePage : Form
    {
        public FrmHomePage()
        {
            InitializeComponent();
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;

            this.picBox.AllowDrop = true;
            this.picBox.DragEnter += PicBox_DragEnter;
            this.picBox.DragDrop += PicBox_DragDrop;
        }

        private void PicBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            this.picBox.Image = Image.FromFile(files[0]);
        }

        private void PicBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        //使用全域db
        StockEntities db = dataModel.db;

        members member = new members();

        dataModel dataModel = new dataModel();

        datasave datasave = new datasave();

        //stockremain stockremain = new stockremain();


        private async void btnAPI_Click(object sender, EventArgs e)
        {
            DateTime currentTime = System.DateTime.Now.AddDays(0);
            string strYMD = currentTime.ToString("yyyy-MM-dd");
            string str = strYMD.Replace("-", "");

            dataModel dataModel = new dataModel();
            //計算執行時間 Stopwatch
            System.Diagnostics.Stopwatch watcher = new System.Diagnostics.Stopwatch();

            watcher.Start();

            Modelview.dataModelview.stockData res = await dataModel.Read(str);

            StockEntities stock = new StockEntities();

            this.dataGridView1.DataSource = stock.data.ToList();

            watcher.Stop();

            this.label3.Text = $"非同步共耗時 {watcher.Elapsed.TotalSeconds} 秒，共{stock.data.Count()}筆資料";
            
            this.dataGridView1.Columns.Remove("id");
     
            
            //取得更新收盤價
            if (db.stockremain.Count() != 0)
            {

                var price = (from d in db.data
                             join s in db.stockremain
                             on d.證券代號 equals s.證券代號
                             select d.收盤價).ToList();

                dataModel.Update(price);
                

            }

            //更新自選清單
            if (db.datasave.Count() != 0)
            {
                var save = (from d in db.data
                            join ds in db.datasave
                            on d.證券代號 equals ds.證券代號
                            select d).ToList();
                dataModel.Updatedatasave(save);

            }

        }

        private void FrmHomePage_Load(object sender, EventArgs e)
        {
            //tag傳值
            member = (members)this.Tag;

            this.lblname.Text = member.name;
            this.lblname1.Text = member.name;
            this.lblbankmoney.Text = string.Format("{0:N2}", member.bankmoney);
            this.lblmoney.Text = string.Format("{0:N2}", member.bankmoney);
            this.lblbank.Text = string.Format("{0:N2}", member.bankmoney);
            //顯示超連結text及button text
            ((DataGridViewLinkColumn)dataGridView2.Columns["連接網頁"]).UseColumnTextForLinkValue = true;
            ((DataGridViewButtonColumn)dataGridView2.Columns["交易"]).UseColumnTextForButtonValue = true;
            ((DataGridViewButtonColumn)dataGridView2.Columns["刪除"]).UseColumnTextForButtonValue = true;
            ((DataGridViewButtonColumn)dataGridView4.Columns["賣出"]).UseColumnTextForButtonValue = true;
            //載入圖片
            byte[] bytes = member.photo;
            if (bytes == null)
            {
                this.picBox.Image = this.picBox.ErrorImage;
            }
            else
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes);
                this.picBox.Image = Image.FromStream(ms);
            }
            

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            FrmPasswordChange frmPasswordChange = new FrmPasswordChange();
            frmPasswordChange.Tag = member;
            frmPasswordChange.ShowDialog();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //確認欄位型態
                if (this.dataGridView2.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
                {
                    //確認欄位名稱
                    switch (dataGridView2.Columns[e.ColumnIndex].Name)
                    {
                        case "連接網頁": //觸發事件
                                     //string keyword = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["連接網頁"].Value);
                                     //string encKeyword = encKeyword = System.Web.HttpUtility.UrlEncode(keyword);

                            string url = "https://stock.cnyes.com/market/TWS:TSE01:INDEX";
                            System.Diagnostics.Process.Start(url);
                            break;
                    }
                }
                if (this.dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {

                    switch (dataGridView2.Columns[e.ColumnIndex].Name)
                    {
                        case "交易": //觸發事件
                            FrmBuyStock frmBuyStock = new FrmBuyStock();
                            //Tag傳資料
                            frmBuyStock.Tag = dataGridView2.Rows[e.RowIndex];

                            //傳member資料過去
                            frmBuyStock.member = this.member;
                            //傳frmhomepage資料過去
                            frmBuyStock.frmHomePage = this;

                            frmBuyStock.ShowDialog();

                            break;
                        case "刪除": //觸發事件  //先轉譯成可列舉
                            datasave result = db.datasave.AsEnumerable().Where(d => d.證券代號 == this.dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString() && d.account == member.account).FirstOrDefault();
                            dataModel.Delete(result);

                            this.dataGridView2.DataSource = db.datasave.Where(m => m.account == member.account).ToList();
                            this.dataGridView2.Columns.Remove("id");
                            this.dataGridView2.Columns["account"].Visible = false;
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dataGridView4.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {

                    switch (dataGridView4.Columns[e.ColumnIndex].Name)
                    {
                        case "賣出": //觸發事件
                            FrmSellStock frmSellStock = new FrmSellStock();
                            
                            //Tag傳資料
                            frmSellStock.Tag = dataGridView4.Rows[e.RowIndex];
                            //傳member資料過去
                            frmSellStock.member = this.member;
                            //傳frmhomepage資料過去
                            frmSellStock.frmHomePage = this;

                            frmSellStock.ShowDialog();
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnmyselect_Click(object sender, EventArgs e)
        {
            this.dataGridView2.DataSource = db.datasave.Where(m => m.account == member.account).ToList();
            
            this.dataGridView2.Columns.Remove("id");
            this.dataGridView2.Columns["account"].Visible = false;
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var cbxCell = (DataGridViewCheckBoxCell)this.dataGridView1.Rows[e.RowIndex].Cells[0];

                //取得cbxCell EditingCellFormattedValue屬性值
                if (cbxCell != null && ((bool)cbxCell.EditingCellFormattedValue == false || (bool)cbxCell.FormattedValue == false))
                {
                    DataGridViewRow s = this.dataGridView1.Rows[e.RowIndex];
                    //取出headertext
                    //string h = s.Cells[1].OwningColumn.HeaderText;
                    //取出value
                    //string v = s.Cells[1].Value.ToString();
                    datasave.account = member.account;
                    datasave.證券代號 = s.Cells[1].Value.ToString();
                    datasave.證券名稱 = s.Cells[2].Value.ToString();
                    datasave.成交股數 = s.Cells[3].Value.ToString();
                    datasave.成交筆數 = s.Cells[4].Value.ToString();
                    datasave.成交金額 = s.Cells[5].Value.ToString();
                    datasave.開盤價 = s.Cells[6].Value.ToString();
                    datasave.最高價 = s.Cells[7].Value.ToString();
                    datasave.最低價 = s.Cells[8].Value.ToString();
                    datasave.收盤價 = s.Cells[9].Value.ToString();
                    datasave.漲跌正or負 = s.Cells[10].Value.ToString();
                    datasave.漲跌價差 = s.Cells[11].Value.ToString();

                    db.datasave.Add(datasave);
                    db.SaveChanges();
               
                }
                //else
                //{
                //    dataModel.Delete(datasave);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
            
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            string num = txtnum.Text.Trim();
            //關鍵字模糊查詢
            var result = db.data.AsEnumerable().Where(d => d.證券代號.Contains(num) || d.證券名稱.Contains(num)).ToList();
                      
            this.dataGridView1.DataSource = result;
            this.dataGridView1.Columns.Remove("id");
        }

        StockEntities dbcontext = dataModel.db;

        private void btnStocksave_Click(object sender, EventArgs e)
        {
            this.dataGridView3.DataSource = dbcontext.stocksave.Where(m => m.account == member.account).ToList();
            this.dataGridView3.Columns["id"].Visible = false;

        }

        private void btnStockRemain_Click(object sender, EventArgs e)
        {
            this.dataGridView4.DataSource = dbcontext.stockremain.Where(m => m.account == member.account).ToList();
            this.dataGridView4.Columns["id"].Visible = false;
        }

        private void btnphoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (new string[] { ".jpg", ".png", ".gif", ".bmp", "jpeg" }.Contains(Path.GetExtension(openFileDialog.FileName.ToLower())))
                {
                    this.picBox.Image = Image.FromFile(openFileDialog.FileName);
                }
                else
                {
                    MessageBox.Show("請選擇圖片檔!!");
                }

            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
     
                if(this.picBox.Image == picBox.ErrorImage)
                {
                    MessageBox.Show("請選擇照片上傳!", "照片修改", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    byte[] bytes;
                    MemoryStream ms = new MemoryStream();
                    this.picBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    bytes = ms.GetBuffer();
                    var mem = db.members.Where(m => m.account == member.account).FirstOrDefault();
                    mem.photo = bytes;

                    MessageBox.Show("照片修改成功: )", "照片修改", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    db.SaveChanges();                   
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
