using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.EntityFramework;
using PagedList;

namespace Model.DAO
{
    public class TypeDao
    {
        DocBaoDataContext db = null;
        public TypeDao()
        {
            db = new DocBaoDataContext();
        }

        public IEnumerable<THELOAI> ListAll(int page, int pageSize)
        {
            return db.THELOAIs.OrderByDescending(i => i.IDTheLoai).ToPagedList(page, pageSize);
        }

        public List<THELOAI> ListTypeForCreatePost()
        {
            return db.THELOAIs.ToList();
        }


        public long addType(THELOAI tk)
        {
            db.THELOAIs.Add(tk);
            db.SaveChanges();
            return tk.IDTheLoai;
        }

        public THELOAI GetByID(string userName)
        {
            return db.THELOAIs.SingleOrDefault(u => u.TenTheLoai == userName);
        }


        public THELOAI ViewDetail(int id)
        {
            return db.THELOAIs.Find(id);
        }


        public bool updateType(THELOAI tk)
        {
            try
            {
                var tk1 = db.THELOAIs.SingleOrDefault(x => x.IDTheLoai == tk.IDTheLoai);
                tk1.TenTheLoai = tk.TenTheLoai;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool Delete(int ID)
        {
            try
            {
                var acc = db.THELOAIs.SingleOrDefault(x => x.IDTheLoai == ID);


                List<BAIDANG> lb = db.BAIDANGs.Where(x => x.IDTheLoai == ID).ToList();
                PostDao pd = new PostDao();
                foreach(BAIDANG bd in lb)
                {
                    pd.Delete(bd.IDBaiDang);
                }

                db.THELOAIs.Remove(acc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
