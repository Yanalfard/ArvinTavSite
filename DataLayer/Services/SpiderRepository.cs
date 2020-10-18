using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SpiderRepository : ISpiderRepository
    {
        private ArvinContext db;

        public SpiderRepository(ArvinContext context)
        {
            this.db = context;
        }

        public IEnumerable<Spider> AllSpider()
        {
            return db.spiders;
        }

        public Spider SpiderById(int ID)
        {
            return db.spiders.Find(ID);
        }

        public string AddSpider(string Title, string Description, string Image, List<string> SeoTags)
        {
            try
            {
                Spider spider = new Spider();
                spider.Title = Title;
                spider.Description = Description;
                spider.Image = Image;
                db.spiders.Add(spider);
                Save();
                foreach (var item in SeoTags)
                {
                    SeoTage seoTage = new SeoTage();
                    seoTage.Tage = item;
                    seoTage.Spider = SpiderById(spider.ID);
                    seoTage.ServiceCategory = null;
                    seoTage.SideID = 1;
                    db.seoTages.Add(seoTage);
                }
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string SpiderEdit(int ID, string Title, string Description, string Image, List<string> SeoTages)
        {
            Spider spider = SpiderById(ID);
            if (string.IsNullOrEmpty(Image))
            {
                IEnumerable<SeoTage> seoTages = db.seoTages.Where(s => s.Spider.ID == spider.ID);
                db.seoTages.RemoveRange(seoTages);
                spider.Title = Title;
                spider.Description = Description;
                Save();
                if (seoTages.Count() == 0) { }
                else
                {
                    foreach (var item in SeoTages)
                    {
                        SeoTage seoTage = new SeoTage();
                        seoTage.Tage = item;
                        seoTage.Spider = spider;
                        seoTage.ServiceCategory = null;
                        seoTage.SideID = 1;
                        db.seoTages.Add(seoTage);
                    }
                }
                Save();
                return "true";
            }
            else
            {

                IEnumerable<SeoTage> seoTages = db.seoTages.Where(s => s.Spider.ID == spider.ID);
                db.seoTages.RemoveRange(seoTages);
                Save();
                spider.Title = Title;
                spider.Description = Description;
                spider.Image = Image;
                Save();
                if (seoTages.Count() == 0)
                { }
                else
                {
                    foreach (var item in SeoTages)
                    {
                        SeoTage seoTage = new SeoTage();
                        seoTage.Tage = item;
                        seoTage.Spider = spider;
                        seoTage.ServiceCategory = null;
                        seoTage.SideID = 1;
                        db.seoTages.Add(seoTage);
                    }
                }
                Save();
                return "true";
            }



        }

        public void Dispose()
        {
            db.Dispose();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public string SpiderRemove(int ID)
        {
            try
            {
                db.seoTages.RemoveRange(db.seoTages.Where(s => s.Spider.ID == ID));
                db.spiders.Remove(SpiderById(ID));
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
