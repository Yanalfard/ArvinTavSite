﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HostingRepository : IHostingRepository
    {
        private ArvinContext db;
        private IServiceCategoryRepository ServiceCategoryRepository;


        public HostingRepository(ArvinContext arvinContext)
        {
            this.db = arvinContext;
            ServiceCategoryRepository = new ServiceCategoryRepository(db);
        }

        public IEnumerable<HostingService> AllhostingServices()
        {
            return db.HostingServices;
        }

        public IEnumerable<HostingServiceDetails> AllHostingDetails(int ID)
        {
            return db.HostingServiceDetails.Where(hd => hd.HostingService.ID == ID);
        }

        public HostingEditViewModel hostingEditViewModel(int ID)
        {
            HostingEditViewModel hostingEditViewModel = new HostingEditViewModel();
            hostingEditViewModel.AllMainServiceCatgory = ServiceCategoryRepository.AllMainServiceCategory(true);
            hostingEditViewModel.HostingService = HostingServiceById(ID);
            return hostingEditViewModel;
        }

        public int Create(int Category, string Title, int FreeSSL, int Support, string Space, string MonthlyTraffic, string SitesBeHosted, string threeMonthsCost, string SixMonthsCost, string AnnuallyCost)
        {
            HostingService hostingService = new HostingService();
            hostingService.ServiceCategory = ServiceCategoryRepository.ServiceCategoryById(Category);
            hostingService.Title = Title;
            if (FreeSSL == 1)
            {
                hostingService.FreeSSL = true;
            }
            if (FreeSSL == 0)
            {
                hostingService.FreeSSL = false;
            }
            if (Support == 1)
            {
                hostingService.Support = true;
            }
            if (Support == 0)
            {
                hostingService.Support = false;
            }
            hostingService.Space = Space;
            hostingService.Monthly_Traffic = MonthlyTraffic;
            hostingService.Sites_Be_Hosted = SitesBeHosted;
            hostingService.threeMonthsCost = threeMonthsCost;
            hostingService.SixMonthsCost = SixMonthsCost;
            hostingService.AnnuallyCost = AnnuallyCost;
            db.HostingServices.Add(hostingService);
            Save();
            return hostingService.ID;
        }

        public string CreateHostingServiceDetails(List<HostingServiceDetailsViewModel> Details)
        {
            
            if (AllHostingDetails(Details.FirstOrDefault().HostingID).Count() > 0)
            {
                db.HostingServiceDetails.RemoveRange(AllHostingDetails(Details.FirstOrDefault().HostingID));
                Save();
            }
            foreach (var item in Details)
            {
                HostingServiceDetails hostingServiceDetails = new HostingServiceDetails();
                hostingServiceDetails.Title = item.Title;
                hostingServiceDetails.Response = item.Response;
                hostingServiceDetails.Kind = item.Kind;
                hostingServiceDetails.HostingService = HostingServiceById(item.HostingID);
                db.HostingServiceDetails.Add(hostingServiceDetails);
            }
            Save();
            return "true";

        }

        public HostingService HostingServiceById(int ID)
        {
            return db.HostingServices.Find(ID);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public string Remove(int ID)
        {
            try
            {
                HostingService hostingService = HostingServiceById(ID);
                IEnumerable<HostingServiceDetails> hostingServiceDetails = db.HostingServiceDetails.Where(hd => hd.HostingService.ID == ID);
                db.HostingServiceDetails.RemoveRange(hostingServiceDetails);
                db.HostingServices.Remove(hostingService);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public int Edit(int ID, int Category, string Title, int FreeSSL, int Support, string Space, string MonthlyTraffic, string SitesBeHosted, string threeMonthsCost, string SixMonthsCost, string AnnuallyCost)
        {
            HostingService hostingService = HostingServiceById(ID);
            hostingService.ServiceCategory = ServiceCategoryRepository.ServiceCategoryById(Category);
            hostingService.Title = Title;
            if (FreeSSL == 1)
            {
                hostingService.FreeSSL = true;
            }
            else if (FreeSSL == 0)
            {
                hostingService.FreeSSL = false;
            }
            if (Support == 1)
            {
                hostingService.Support = true;
            }
            else if (Support == 0)
            {
                hostingService.Support = false;
            }
            hostingService.Space = Space;
            hostingService.Monthly_Traffic = MonthlyTraffic;
            hostingService.Sites_Be_Hosted = SitesBeHosted;
            hostingService.threeMonthsCost = threeMonthsCost;
            hostingService.SixMonthsCost = SixMonthsCost;
            hostingService.AnnuallyCost = AnnuallyCost;
            Save();
            return ID;
        }
    }
}