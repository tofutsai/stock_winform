//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Stock_transaction.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class datasave
    {
        public int id { get; set; }
        public string account { get; set; }
        public string 證券代號 { get; set; }
        public string 證券名稱 { get; set; }
        public string 成交股數 { get; set; }
        public string 成交筆數 { get; set; }
        public string 成交金額 { get; set; }
        public string 開盤價 { get; set; }
        public string 最高價 { get; set; }
        public string 最低價 { get; set; }
        public string 收盤價 { get; set; }
        public string 漲跌正or負 { get; set; }
        public string 漲跌價差 { get; set; }
    }
}
