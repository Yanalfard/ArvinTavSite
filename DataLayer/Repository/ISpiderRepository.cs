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

        string AddSpider(string Title, string Description, string Image, List<string> SeoTages);

        string SpiderEdit(int ID,string Title, string Description, string Image, List<string> SeoTages);

        string SpiderRemove(int ID);

        void Save();
    }
}
