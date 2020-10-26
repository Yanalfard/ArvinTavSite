using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SliderRepository : ISliderRepository
    {
        private ArvinContext db;

        public SliderRepository(ArvinContext context)
        {
            this.db = context;
        }
        public IEnumerable<Slider> AllSliders()
        {
            return db.sliders;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Slider SliderById(int ID)
        {
            return db.sliders.Find(ID);
        }

        public string SliderCreate(string Title, string Link, string Image)
        {
            try
            {
                if (AllSliders().Count() > 5)
                {
                    return "شما فقط میتوانید پنج اسلایدر اضافه کنید";
                }
                else
                {
                    Slider slider = new Slider();
                    slider.Title = Title;
                    slider.Link = Link;
                    slider.Image = Image;
                    db.sliders.Add(slider);
                    Save();
                    return "true";
                }
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string SliderRemove(int ID)
        {
            try
            {
                db.sliders.Remove(SliderById(ID));
                Save();
                return "true";
            }
            catch (Exception ex)
            {

                return "Erorr :" + ex.Message;
            }
        }
    }
}
