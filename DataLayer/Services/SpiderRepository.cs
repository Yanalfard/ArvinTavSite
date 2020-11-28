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
        private IServiceCategoryRepository ServiceCategoryRepository;

        public SpiderRepository(ArvinContext context)
        {
            this.db = context;
            ServiceCategoryRepository = new ServiceCategoryRepository(db);
        }

        public IEnumerable<Spider> AllSpider()
        {
            return db.spiders;
        }

        public Spider SpiderById(int ID)
        {
            return db.spiders.Find(ID);
        }

        public string AddSpider(int Category, string Title, string Description, string Image, List<string> SeoTags)
        {
            try
            {
                Spider spider = new Spider();
                spider.SpiderCategory = db.spiderCategories.Find(Category);
                spider.Title = Title;
                spider.Description = Description;
                spider.Image = Image;
                spider.DateTime = DateTime.Now;
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

        public string SpiderEdit(int ID, int Category, string Title, string Description, string Image, List<string> SeoTages)
        {
            Spider spider = SpiderById(ID);
            if (string.IsNullOrEmpty(Image))
            {
                IEnumerable<SeoTage> seoTages = db.seoTages.Where(s => s.Spider.ID == spider.ID);

                if (seoTages.Count() != 0)
                {
                    db.seoTages.RemoveRange(seoTages);
                }
                
                spider.SpiderCategory = spiderCategoryById(Category);
                spider.Title = Title;
                spider.Description = Description;
                spider.Image = spider.Image;
                Save();
                if (SeoTages.Count() == 0) { }
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
                if (seoTages.Count() != 0)
                {
                    db.seoTages.RemoveRange(seoTages);
                }
                Save();
                spider.Title = Title;
                spider.Description = Description;
                spider.Image = Image;
                Save();
                if (SeoTages.Count() == 0)
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

        public IEnumerable<SpiderCategory> AllspiderCategories()
        {
            return db.spiderCategories;
        }

        public string AddSpiderCategory(string Title)
        {
            try
            {
                SpiderCategory spiderCategory = new SpiderCategory();

                spiderCategory.Title = Title;

                db.spiderCategories.Add(spiderCategory);
                Save();

                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string EditSpiderCategory(int ID, string Title)
        {
            try
            {
                SpiderCategory spiderCategory = db.spiderCategories.Find(ID);
                spiderCategory.Title = Title;
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string RemoveSpiderCategory(int ID)
        {
            db.spiderCategories.Remove(db.spiderCategories.Find(ID));
            Save();
            return "true";
        }

        public SpiderCategory spiderCategoryById(int ID)
        {
            return db.spiderCategories.Find(ID);
        }
    }
}
