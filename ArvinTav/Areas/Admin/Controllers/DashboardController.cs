using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IStatisticRepository statisticRepository;

        public DashboardController()
        {
            statisticRepository = new StatisticRepository(db);
        }

        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            return View(statisticRepository.Allstatistic());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                statisticRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}