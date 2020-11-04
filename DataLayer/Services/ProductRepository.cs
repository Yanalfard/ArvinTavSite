using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProductRepository : IProductRepository
    {
        private ArvinContext db;
        private IServiceCategoryRepository ServiceCategoryRepository;

        public ProductRepository(ArvinContext context)
        {
            this.db = context;
            ServiceCategoryRepository = new ServiceCategoryRepository(db);
        }
        public ProductRepository()
        {

        }
        public IEnumerable<Product> AllProduct()
        {
            return db.products;
        }

        public IEnumerable<Product> AllProductByCategory(int ID)
        {
            return db.products.Where(p => p.ServiceCategory == ServiceCategoryRepository.ServiceCategoryById(ID));
        }

        public Product productById(int ID)
        {
            return db.products.Find(ID);
        }
    }
}
