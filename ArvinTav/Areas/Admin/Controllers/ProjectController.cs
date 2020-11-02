using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin")]
    public class ProjectController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private IProjectRepository projectRepository;

        public ProjectController()
        {
            projectRepository = new ProjectRepository(db);
        }

        // GET: Admin/Project
        public ActionResult Index(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == "")
            {
                if (InPageCount == 0)
                {
                    int count = projectRepository.Allprojects().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = projectRepository.Allprojects().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = projectRepository.Allprojects().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
                else
                {

                    int count = projectRepository.Allprojects().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return View();
                }
            }
        }

        public ActionResult P_List(int PageId = 1, string Result = "", int InPageCount = 0)
        {
            if (Result == "")
            {
                if (InPageCount == 0)
                {
                    int count = projectRepository.Allprojects().Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(projectRepository.Allprojects().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = projectRepository.Allprojects().Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = "";

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(projectRepository.Allprojects().OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = projectRepository.Allprojects().Where(p => p.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(projectRepository.Allprojects().Where(p => p.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
                else
                {

                    int count = projectRepository.Allprojects().Where(p => p.Title.Contains(Result)).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    ViewBag.Result = Result;

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    return PartialView(projectRepository.Allprojects().Where(p => p.Title.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                }
            }
        }

        public ActionResult P_Create()
        {
            return PartialView();
        }

        [HttpPost]
        public string Create(string Title, string Image, string Link)
        {
            return projectRepository.Create(Title, Image, Link);
        }

        public ActionResult P_Edit(int ID)
        {
            return PartialView(projectRepository.ProjectById(ID));
        }

        [HttpPost]
        public string Edit(int ID, string Title, string Image, string Link)
        {
            if (Image != "")
            {
                string fullPathImage = Request.MapPath("/Document/img/Project/" + projectRepository.ProjectById(ID).Image);

                if (System.IO.File.Exists(fullPathImage))
                {
                    System.IO.File.Delete(fullPathImage);
                }
            }
            return projectRepository.Edit(ID, Title, Image, Link);
        }

        public ActionResult P_Remove(int ID)
        {
            return PartialView(projectRepository.ProjectById(ID));
        }

        public string Remove(int ID)
        {
            string fullPathImage = Request.MapPath("/Document/img/Project/" + projectRepository.ProjectById(ID).Image);

            if (System.IO.File.Exists(fullPathImage))
            {
                System.IO.File.Delete(fullPathImage);
            }
            return projectRepository.Remove(ID);
        }


        public void ChangeStatus(int ID)
        {
            projectRepository.ChangeStatus(ID);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                projectRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}