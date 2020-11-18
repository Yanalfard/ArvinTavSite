using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Controllers
{
    public class BlogController : Controller
    {
        private IDatabase database;
        private ISpiderRepository spiderRepository;

        public BlogController()
        {
            database = new Database();
            spiderRepository = new SpiderRepository(database._db());
        }

        // GET: Blog


        [Route("Blog")]
        public ActionResult Blog(int PageId = 1, string Result = "")
        {
            if (Result == "")
            {
                int skip = (PageId - 1) * 10;

                int Count = spiderRepository.AllSpider().Count();
                ViewBag.PageID = PageId;
                ViewBag.PageCount = Count / 10;

                var list = spiderRepository.AllSpider().OrderByDescending(p => p.ID).Skip(skip).Take(10).ToList();

                return View(list);
            }
            else
            {
                int skip = (PageId - 1) * 10;

                int Count = spiderRepository.AllSpider().Count();
                ViewBag.PageID = PageId;
                ViewBag.PageCount = Count / 10;

                var list = spiderRepository.AllSpider().Where(p => p.Title.Contains(Result)).OrderByDescending(p => p.ID).Skip(skip).Take(10).ToList();

                return View(list);
            }
        }

        [Route("Post/{ID}/{Title}")]
        public ActionResult Post(int ID, string Title)
        {
            return View(spiderRepository.SpiderById(ID));
        }

        [Route("tage={PageId}/{Tage}")]
        public ActionResult ByTage(int PageId, string Tage)
        {

            int skip = (PageId - 1) * 10;

            int Count = spiderRepository.AllSpider().Count();
            ViewBag.PageID = PageId;
            ViewBag.PageCount = Count / 10;

            var list = database._db().seoTages.Where(s => s.Tage.Contains(Tage)).Select(p => p.Spider).OrderByDescending(p => p.ID).Skip(skip).Take(10);


            return View(list);

        }

        [Route("cat={PageId}/{ID}")]
        public ActionResult ByCategory(int PageId, int ID)
        {
            int skip = (PageId - 1) * 10;

            int Count = spiderRepository.AllSpider().Count();
            ViewBag.PageID = PageId;
            ViewBag.PageCount = Count / 10;

            var list = spiderRepository.AllSpider().Where(p => p.SpiderCategory.ID == ID).OrderByDescending(p => p.ID).Skip(skip).Take(10);

            return View(list);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                spiderRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}