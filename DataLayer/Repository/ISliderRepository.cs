using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
   public interface ISliderRepository:IDisposable
    {
        IEnumerable<Slider> AllSliders();

        Slider SliderById(int ID);

        string SliderCreate(string Title, string Link, string Image);

        string SliderEdit(int ID, string Title, string Link, string Image);

        string SliderRemove(int ID);

        void Save();
    }
}
