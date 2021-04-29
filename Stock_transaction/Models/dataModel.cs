using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Stock_transaction.Modelview.dataModelview;

namespace Stock_transaction.Models
{
    class dataModel
    {

        internal async Task<stockData> Read(string date)
        {
            try
            {
                string jsonString = await stockAPI(date);

                stockData stockData = new stockData();

                //JSON反序列化裝入刻好的物件，傳入controller
                stockData = JsonConvert.DeserializeObject<stockData>(jsonString);


                data data = new data();
                //清除data舊的日期資料
                Delete();


                for (int i = 0; i < stockData.data9.Count(); i++)
                {
                    data.證券代號 = stockData.data9[i][0];
                    data.證券名稱 = stockData.data9[i][1];
                    data.成交股數 = stockData.data9[i][2];
                    data.成交筆數 = stockData.data9[i][3];
                    data.成交金額 = stockData.data9[i][4];
                    data.開盤價 = stockData.data9[i][5];
                    data.最高價 = stockData.data9[i][6];
                    data.最低價 = stockData.data9[i][7];
                    data.收盤價 = stockData.data9[i][8];
                    if (stockData.data9[i][9].Contains("+"))
                    {
                        stockData.data9[i][9] = stockData.data9[i][9].Replace("<p style= color:red>+</p>", "+");
                    }
                    else if (stockData.data9[i][9].Contains("-"))
                    {
                        stockData.data9[i][9] = stockData.data9[i][9].Replace("<p style= color:green>-</p>", "-");
                    }
                    else
                    {
                        stockData.data9[i][9] = stockData.data9[i][9].Replace("<p> </p>", "0");
                    }
                    data.漲跌正or負 = stockData.data9[i][9];
                    data.漲跌價差 = stockData.data9[i][10];
                    //寫入DB
                    create(data);
                }

                //清除datasave舊的資料
                //datasave datasave = new datasave();
                //Delete(datasave);

                return stockData;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            
        }

        internal async Task<string> stockAPI(string date)
        {
            try
            {
                //WebClient API 設定寫法 
                string url = "https://www.twse.com.tw/exchangeReport/MI_INDEX?response=json&date=" + date + "&type=ALLBUT0999&_=1602315728894";
                string response = "";
                WebClient client = new WebClient();
                // 指定 WebClient 的 Content-Type header
                client.Headers.Add("Content-Type", "application/json;charset=utf-8");

                //連證交所取得股價資料(JSON方式回傳)
                response = await client.DownloadStringTaskAsync(url);

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        //宣告全域 db
        public static StockEntities db = new StockEntities();        

        internal int create(data formData)
        {
            db.data.Add(formData);
            return db.SaveChanges();
        }

        internal int Delete()
        {
            db.Database.ExecuteSqlCommand("delete from data");
            return db.SaveChanges();
        }

        internal int Delete(datasave formdata)
        {            
            datasave result = db.datasave.Where(m => m.證券代號 == formdata.證券代號 && m.account == formdata.account).FirstOrDefault();
            db.datasave.Remove(result);
            
            return db.SaveChanges();
        }

        internal int Delete(stocksave formdata)
        {
            stocksave result = db.stocksave.Where(m => m.證券代號 == formdata.證券代號 && m.account == formdata.account).FirstOrDefault();
            db.stocksave.Remove(result);

            return db.SaveChanges();
        }

        internal int Delete(stockremain formdata)
        {
            stockremain result = db.stockremain.Where(m => m.證券代號 == formdata.證券代號 && m.account == formdata.account).FirstOrDefault();
            db.stockremain.Remove(result);

            return db.SaveChanges();
        }

        //設定股數
        const int number = 1000;

        internal int Update(List<string> formdata)
        {
            var p = (from s in db.stockremain
                     join d in db.data
                     on s.證券代號 equals d.證券代號
                     select s).ToList();
            for (int i = 0; i < formdata.Count(); i++)
            {
                p[i].現價 = formdata[i];
                p[i].現值 = (double.Parse(formdata[i]) * double.Parse(p[i].張數.ToString()) * number).ToString();
                p[i].預估收入 = (double.Parse(formdata[i]) * double.Parse(p[i].張數.ToString()) * number).ToString();
                p[i].預估損益 = (double.Parse(p[i].預估收入) - double.Parse(p[i].持有成本)).ToString();
                p[i].預估獲利率 = ((double.Parse(p[i].預估損益) / double.Parse(p[i].持有成本)) * 100).ToString("f2") + "%";
                db.SaveChanges();
            }

            return 0;
        }

        internal int Updatestocksave(stocksave formdata, int Number)
        {
            var stocksave = db.stocksave.Where(s => s.證券代號 == formdata.證券代號 && s.account == formdata.account).FirstOrDefault();
            stocksave.張數 = (int.Parse(stocksave.張數) - Number).ToString();
            stocksave.總金額 = (int.Parse(stocksave.張數) * double.Parse(stocksave.買進價格) * number).ToString();
            db.SaveChanges();
            return db.SaveChanges();
        }

        internal int Updatestockremain(stockremain formdata, int Number)
        {
            var stockremain = db.stockremain.Where(s => s.證券代號 == formdata.證券代號 && s.account == formdata.account).FirstOrDefault();
            stockremain.張數 = (int.Parse(stockremain.張數) - Number).ToString();
            stockremain.持有成本 = ((int.Parse(stockremain.張數) * double.Parse(stockremain.成交均價)) * number).ToString();
            stockremain.現值 = (double.Parse(formdata.現價) * double.Parse(stockremain.張數.ToString()) * number).ToString();
            stockremain.預估收入 = ((int.Parse(stockremain.張數) * double.Parse(stockremain.現價)) * number).ToString();
            stockremain.預估損益 = (double.Parse(stockremain.預估收入) - double.Parse(stockremain.持有成本)).ToString();
            stockremain.預估獲利率 = ((double.Parse(stockremain.預估損益) / double.Parse(stockremain.持有成本)) * 100).ToString("f2") + "%";
            db.SaveChanges();
            return db.SaveChanges();
        }

        internal int Updatedatasave(List<data> formdata)
        {
            var save = (from d in db.data
                        join ds in db.datasave
                        on d.證券代號 equals ds.證券代號
                        select ds).ToList();

            for (int i = 0; i < formdata.Count(); i++)
            {
                save[i].成交股數 = formdata[i].成交股數;
                save[i].成交筆數 = formdata[i].成交筆數;
                save[i].成交金額 = formdata[i].成交金額;
                save[i].開盤價 = formdata[i].開盤價;
                save[i].最高價 = formdata[i].最高價;
                save[i].最低價 = formdata[i].最低價;
                save[i].收盤價 = formdata[i].收盤價;
                save[i].漲跌正or負 = formdata[i].漲跌正or負;
                save[i].漲跌價差 = formdata[i].漲跌價差;
                db.SaveChanges();
            }

            return 0;
        }
    }
}
