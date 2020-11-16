using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MassageRepository : IMassageRepository
    {
        private ArvinContext db;

        public MassageRepository(ArvinContext context)
        {
            this.db = context;
        }

        public IEnumerable<Massage> AllMasssages()
        {
            return db.massages;
        }
        
        public Massage massageById(int ID)
        {
            return db.massages.Find(ID);
        }

        public bool CreateMassage(Massage massage)
        {
            try
            {
                massage.Seen = false;
                db.massages.Add(massage);
                Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ConfirmMassage(int ID)
        {
            try
            {
                Massage massage = massageById(ID);
                massage.Seen = true;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveMassage(int ID)
        {
            try
            {
                db.massages.Remove(massageById(ID));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
