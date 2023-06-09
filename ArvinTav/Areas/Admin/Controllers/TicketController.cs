﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace ArvinTav.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,PartAdmin")]
    public class TicketController : Controller
    {
        private ArvinContext db = new ArvinContext();
        private ITicketRepository ticketRepository;
        private IUserRepository userRepository;
        public TicketController()
        {
            
            ticketRepository = new TicketRepository(db);
            userRepository = new UserRepository(db);
        }

        // GET: Admin/Ticket
        public ActionResult Index(int PageId = 1, int TicketIDSearch = 0, int StatusSearch = 0, int CategorySearch = 0, int InPageCount = 0)
        {

            if (TicketIDSearch == 0)
            {
                if (StatusSearch == 0)
                {
                    if (CategorySearch == 0)
                    {

                        if (InPageCount == 0)
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = 0;

                            ViewBag.CategorySearch = 0;

                            //Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);
                        }
                        else
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = 0;

                            ViewBag.CategorySearch = CategorySearch;

                            //Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);

                        }

                    }
                    else
                    {
                        if (InPageCount == 0)
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Where(t => t.TicketCategory.ID == CategorySearch).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = 0;

                            ViewBag.CategorySearch = 0;

                            //Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.TicketCategory.ID == CategorySearch).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);
                        }
                        else
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Where(t => t.TicketCategory.ID == CategorySearch).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = 0;

                            ViewBag.CategorySearch = 0;

                            //Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.TicketCategory.ID == CategorySearch).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);
                        }

                    }
                }
                else
                {
                    if (CategorySearch == 0)
                    {
                        if (InPageCount == 0)
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = StatusSearch;

                            ViewBag.CategorySearch = 0;

                            //Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);
                        }
                        else
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = StatusSearch;

                            ViewBag.CategorySearch = 0;

                            //Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);

                        }
                    }
                    else
                    {
                        if (InPageCount == 0)
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch && t.TicketCategory.ID == CategorySearch).Count();

                            var skip = (PageId - 1) * 18;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = StatusSearch;

                            ViewBag.CategorySearch = CategorySearch;

                            //Search

                            ViewBag.PageCount = count / 18;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch && t.TicketCategory.ID == CategorySearch).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);
                        }
                        else
                        {
                            int count = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch && t.TicketCategory.ID == CategorySearch).Count();

                            var skip = (PageId - 1) * InPageCount;

                            ViewBag.pageid = PageId;

                            //Search

                            ViewBag.TicketIDSearch = "";

                            ViewBag.StatusSearch = StatusSearch;

                            ViewBag.CategorySearch = 0;

                            //Search

                            ViewBag.PageCount = count / InPageCount;

                            ViewBag.InPageCount = InPageCount;

                            TicketListViewModel ticketListViewModel = new TicketListViewModel();
                            ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.Status == StatusSearch && t.TicketCategory.ID == CategorySearch).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList();
                            ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                            return View(ticketListViewModel);

                        }
                    }
                }
            }
            else
            {
                if (InPageCount == 0)
                {
                    int count = ticketRepository.AllTicketInView().tickets.Where(t => t.ID == TicketIDSearch).Count();

                    var skip = (PageId - 1) * 18;

                    ViewBag.pageid = PageId;

                    //Search

                    ViewBag.TicketIDSearch = TicketIDSearch;

                    ViewBag.StatusSearch = 0;

                    ViewBag.CategorySearch = 0;

                    //Search

                    ViewBag.PageCount = count / 18;

                    ViewBag.InPageCount = InPageCount;

                    TicketListViewModel ticketListViewModel = new TicketListViewModel();
                    ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.ID == TicketIDSearch).OrderByDescending(v => v.ID).Skip(skip).Take(18).ToList();
                    ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                    return View(ticketListViewModel);
                }
                else
                {
                    int count = ticketRepository.AllTicketInView().tickets.Where(t => t.ID == TicketIDSearch).Count();

                    var skip = (PageId - 1) * InPageCount;

                    ViewBag.pageid = PageId;

                    //Search

                    ViewBag.TicketIDSearch = TicketIDSearch;

                    ViewBag.StatusSearch = 0;

                    ViewBag.CategorySearch = 0;

                    //Search

                    ViewBag.PageCount = count / InPageCount;

                    ViewBag.InPageCount = InPageCount;

                    TicketListViewModel ticketListViewModel = new TicketListViewModel();
                    ticketListViewModel.tickets = ticketRepository.AllTicketInView().tickets.Where(t => t.ID == TicketIDSearch).OrderByDescending(v => v.ID).Skip(skip).Take(InPageCount).ToList();
                    ticketListViewModel.ticketCategories = ticketRepository.AllTicketInView().ticketCategories;
                    return View(ticketListViewModel);

                }
            }

        }

        //InnerTicket
        public ActionResult InnerTicket(int ID)
        {
            if (ticketRepository.GetTicketById(ID).Supporter == null)
            {
                ticketRepository.GetTicketById(ID).Status = 2;
                ticketRepository.GetTicketById(ID).Supporter = userRepository.UserByPhoneNumber(User.Identity.Name);
                ticketRepository.Save();
            }
            return View(ticketRepository.GetInnerTicket(ID));
        }

        public ActionResult P_Info(int ID)
        {
            return PartialView(ticketRepository.GetTicketById(ID));
        }

        public ActionResult EndTicket(int ID)
        {
            ticketRepository.GetTicketById(ID).Status = 3;
            ticketRepository.Save();

            var Text = ticketRepository.GetTicketById(ID);
            Sms.SendSms(Text.User.PhoneNumber, Text.ID.ToString(), "Compticket");

            return Redirect("/Admin/Ticket");
        }

        public string SendMassage(int ID, string TextMassage, string FileMassage)
        {
            if (FileMassage != "")
            {
                return ticketRepository.SendMassage(ID, 2, TextMassage, FileMassage, userRepository.UserByPhoneNumber(User.Identity.Name).UserID);
            }
            else
            {
                return ticketRepository.SendMassage(ID, 2, TextMassage, null, userRepository.UserByPhoneNumber(User.Identity.Name).UserID);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ticketRepository.Dispose();
                userRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}