using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PartnerRepository : IPartnerRepository
    {
        private ArvinContext db;
        public PartnerRepository(ArvinContext context)
        {
            this.db = context;
        }

        public IEnumerable<Partner> Allpartners()
        {
            return db.partners;
        }

        public string CreatePartner(string Title, string PhoneNumber, string Logo)
        {
            try
            {
                Partner partner = new Partner();
                partner.Title = Title;
                partner.PhoneNumber = PhoneNumber;
                partner.Logo = Logo;
                db.partners.Add(partner);
                Save();
                return "true";
            }
            catch (Exception ex)
            {

                return "Erorr :" + ex.Message;
            }
        }

        public string EditPartner(int ID, string Title, string PhoneNumber, string Logo)
        {
            try
            {
                Partner partner = partnerById(ID);
                if (Logo == "")
                {
                    partner.Title = Title;
                    partner.PhoneNumber = PhoneNumber;
                    Save();
                    return "true";
                }
                else
                {
                    partner.Title = Title;
                    partner.PhoneNumber = PhoneNumber;
                    partner.Logo = Logo;
                    Save();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public Partner partnerById(int ID)
        {
            return db.partners.Find(ID);
        }

        public string RemovePartner(int ID)
        {
            db.partners.Remove(partnerById(ID));
            Save();
            return "true";
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
