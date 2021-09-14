using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming.DAL
{
    public class calisanDAL:BaseDAL
    {

       

        public IEnumerable<calisanlar> GetAllCalisanlar()
        {
            return db.calisanlar;
        }

        public calisanlar GetCalisanlarId(int id)
        {
            return db.calisanlar.Find(id);
        }

        public calisanlar CreateCalisanlar(calisanlar calisan)
        {
            db.calisanlar.Add(calisan);
            db.SaveChanges();
            return calisan;
        }

        public calisanlar UpdateCalisanlar(int id, calisanlar calisan)
        {
            db.Entry(calisan).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return calisan;

        }

        public void DeleteCalisan(int id)
        {
            db.calisanlar.Remove(db.calisanlar.Find(id));
            db.SaveChanges();
        }

        public bool IsThereAnyCalisan(int id)
        {
            return db.calisanlar.Any(x => x.ID == id );
        }
    }
}
