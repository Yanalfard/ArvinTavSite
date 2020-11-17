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
        public ActionResult Blog(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == "")
            {
                if (InPageCount == 0)
                {
                    int count = spiderRepository.AllSpider().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = spiderRepository.AllSpider().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View(spiderRepository.AllSpider().Where(s => s.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                }
            }
        }

        [Route("Post/{ID}/{Title}")]
        public ActionResult Post(int ID, string Title)
        {
            return View(spiderRepository.SpiderById(ID));
        }

        [Route("tage={Tage}")]
        public ActionResult ByTage(string Tage)
        {
            return View();
        }

        [Route("cat={ID}")]
        public ActionResult ByCategory(int ID)
        {
            return View(spiderRepository.AllSpider().Where(s=>s.SpiderCategory.ID==ID));
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