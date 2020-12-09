using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EntityFramework;
using System.Data.Common;
using System.Data.Sql;
using System.Transactions;

namespace Model.DAO
{
    public class ViewsDao
    {
        DocBaoDataContext db = null;
        public ViewsDao()
        {
            db = new DocBaoDataContext();
        }


        public void AddViews(long id)
        {
            //using (var dbContextTransaction = db.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.LUOTXEM ON");
            //        LUOTXEM lx = new LUOTXEM();
            //        lx.IDBaiDang = Convert.ToInt32(id);
            //        lx.NgayThang = DateTime.Now;
            //        db.LUOTXEMs.Add(lx);
            //        db.SaveChanges(); 
            //        dbContextTransaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        dbContextTransaction.Rollback();
            //    }

            //    db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.LUOTXEM OFF");
            //}



            LUOTXEM lx = new LUOTXEM();
            lx.IDBaiDang = Convert.ToInt32(id);
            lx.NgayThang = DateTime.Now;
            db.LUOTXEMs.Add(lx);
            db.SaveChanges(); 

        }
    }
}
