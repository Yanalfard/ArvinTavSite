using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    public class DomainController : Controller
    {
        private IServiceCategoryRepository serviceCategoryRepository;
        private IDomainRepository domainRepository;
        private ArvinContext db = new ArvinContext();

        public DomainController()
        {
            serviceCategoryRepository = new ServiceCategoryRepository(db);
            domainRepository = new DomainRepository(db);
        }

        // GET: Admin/Domain
        public ActionResult Index(int PageId = 1, string Result = "", int IsActive = 2, int InPageCount = 0)
        {
            if (Result == null)
            {
                if (IsActive == 2)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }

                }
                else if (IsActive == 1)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }

                }
                else if (IsActive == 0)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }


                }

            }
            else
            {
                if (IsActive == 2)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = Result;

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }

                }
                else if (IsActive == 1)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }

                }
                else if (IsActive == 0)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return View();
                    }


                }

            }
            return View();
        }

        public ActionResult P_List(int PageId = 1, string Result = "", int IsActive = 2, int InPageCount = 0)
        {
            if (Result == null)
            {
                if (IsActive == 2)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }

                }
                else if (IsActive == 1)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == true).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == true).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }

                }
                else if (IsActive == 0)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == false).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == false).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }


                }

            }
            else
            {
                if (IsActive == 2)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.Suffix.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.Suffix.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }

                }
                else if (IsActive == 1)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == true && d.Suffix.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == true && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == true && d.Suffix.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }

                }
                else if (IsActive == 0)
                {

                    if (InPageCount == 0)
                    {
                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * 18;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / 18;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == false && d.Suffix.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(18).ToList());
                    }
                    else
                    {

                        int count = domainRepository.AllDomain(false).Where(d => d.IsActive == false && d.Suffix.Contains(Result)).Count();

                        var skip = (PageId - 1) * InPageCount;

                        ViewBag.pageid = PageId;

                        ViewBag.Result = "";

                        ViewBag.PageCount = count / InPageCount;

                        ViewBag.InPageCount = InPageCount;

                        ViewBag.IsActive = IsActive;

                        return PartialView(domainRepository.AllDomain(false).Where(d => d.IsActive == false && d.Suffix.Contains(Result)).OrderBy(v => v.ID).Skip(skip).Take(InPageCount).ToList());
                    }


                }

            }
            return PartialView();
        }

        public ActionResult P_Create()
        {
            return PartialView(serviceCategoryRepository.AllMainServiceCategory(true));
        }

        public ActionResult P_ChildCategoryInCreate(int ParentID)
        {
            return PartialView(serviceCategoryRepository.AllChildCategory(ParentID, true));
        }

        [HttpPost]
        public string Create(int Category, string Suffix, int IsActive,string Price)
        {
            return domainRepository.AddDomianService(Category, Suffix, IsActive, Price);
        }

        public ActionResult P_Edit(int ID)
        {
            DomainEditViewModel domainEditViewModel = new DomainEditViewModel()
            {
                DomainService = domainRepository.DomainByID(ID),
                serviceCategories = serviceCategoryRepository.AllMainServiceCategory(true)
            };
            return PartialView(domainEditViewModel);
        }

        [HttpPost]
        public string Edit(int ID, int Category, string Suffix, int IsActive, string Price)
        {
            return domainRepository.EditDomainService(ID, Category, Suffix, IsActive, Price);
        }

        public string StatusDomain(int ID)
        {
            return domainRepository.StatusDomain(ID);
        }

        public ActionResult P_Remove(int ID)
        {
            return PartialView(domainRepository.DomainByID(ID));
        }

        public string Remove(int ID)
        {
            return domainRepository.RemoveDomain(ID);
        }
    }
}