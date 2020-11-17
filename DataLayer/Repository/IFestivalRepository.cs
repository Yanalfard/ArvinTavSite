using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IFestivalRepository:IDisposable
    {
        IEnumerable<Discount> AllDiscounts();

        Discount DiscountById(int ID);

        Discount DiscountByCode(string Code);

        string Create(string Code, int Percentage);

        string Edit(int ID, string Code, int Percentage);

        string Remove(int ID);

        void Save();
    }
}
