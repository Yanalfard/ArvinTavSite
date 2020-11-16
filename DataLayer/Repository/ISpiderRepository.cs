using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ISpiderRepository : IDisposable
    {
        IEnumerable<Spider> AllSpider();

        Spider SpiderById(int ID);

        IEnumerable<SpiderCategory> AllspiderCategories();

        SpiderCategory spiderCategoryById(int ID);

        string AddSpiderCategory(string Title);

        string EditSpiderCategory(int ID, string Title);

        string RemoveSpiderCategory(int ID);

        string AddSpider(int Category, string Title, string Description, string Image, List<string> SeoTages);

        string SpiderEdit(int ID,int Category, string Title, string Description, string Image, List<string> SeoTages);

        string SpiderRemove(int ID);

        void Save();
    }
}
