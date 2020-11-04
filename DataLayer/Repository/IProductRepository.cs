using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface IProductRepository
    {
        IEnumerable<Product> AllProduct();

        IEnumerable<Product> AllProductByCategory(int ID);

        Product productById(int ID);
    }
}
