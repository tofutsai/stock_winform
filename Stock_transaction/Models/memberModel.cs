using Stock_transaction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_transaction
{

    class memberModel
    {
        StockEntities db = new StockEntities();

        internal int create(members formData)
        {
            members result = db.members.Where(m => m.account == formData.account).FirstOrDefault();
            if (result == null)
            {
                db.members.Add(formData);
                return db.SaveChanges();
            }
            else
            {
                return 0;
            }
           
        }

        internal members LogOncheck(string account, string password)
        {
            members member = db.members.Where(m => m.account.ToUpper() == account && m.password == password).FirstOrDefault();

            return member;
        }

    }
}
