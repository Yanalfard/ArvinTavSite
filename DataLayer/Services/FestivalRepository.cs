using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public class FestivalRepository : IFestivalRepository
    {
        ArvinContext db;


        public FestivalRepository(ArvinContext context)
        {
            this.db = context;
        }

        public IEnumerable<Discount> AllDiscounts()
        {
            return db.discounts;
        }

        public string Create(string Code, int Percentage)
        {
            try
            {
                Discount discount = new Discount();

                discount.Code = Code;
                discount.Percentage = Percentage;
                db.discounts.Add(discount);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }

        }

        public Discount DiscountById(int ID)
        {
            return db.discounts.Find(ID);
        }

        public Discount DiscountByCode(string Code)
        {
            return db.discounts.Where(d => d.Code == Code).SingleOrDefault();
        }
        
        public void Dispose()
        {
            db.Dispose();
        }

        public string Edit(int ID, string Code, int Percentage)
        {
            try
            {
                Discount discount = DiscountById(ID);
                discount.Code = Code;
                discount.Percentage = Percentage;
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
                throw;
            }
        }

        public string Remove(int ID)
        {

            try
            {
                Discount discount = DiscountById(ID);
                db.discounts.Remove(discount);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
