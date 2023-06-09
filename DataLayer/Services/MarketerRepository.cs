﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class MarketerRepository : IMarketerRepository
    {
        private ArvinContext db;
        private UserRepository userRepository;

        public MarketerRepository(ArvinContext context)
        {
            this.db = context;
            userRepository = new UserRepository(db);
        }

        public IEnumerable<MarketerReport> AllMarketerReports()
        {
            return db.marketerReports;
        }

        public IEnumerable<MarketerReport> AllMarketerReportByMarketer(int UserID)
        {
            return db.marketerReports.Where(mr => mr.User.UserID == UserID);
        }

        public string CraateReport(string Title, string Description, int MarketerID)
        {
            MarketerReport report = new MarketerReport();
            report.Title = Title;
            report.Description = Description;
            report.Status = false;
            report.DateTime = DateTime.Now;
            report.User = userRepository.UserById(MarketerID);
            db.marketerReports.Add(report);
            Save();
            return "true";
        }

        public string ChangeStatus(int ID)
        {
            try
            {
                MarketerReport marketerReport = MarketerReportById(ID);
                if (marketerReport.Status == true)
                {
                    marketerReport.Status = false;
                }
                else
                {
                    marketerReport.Status = true;
                }
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public MarketerReport MarketerReportById(int ID)
        {
            return db.marketerReports.Find(ID);
        }

        public string RemoveReport(int ID)
        {
            try
            {
                db.marketerReports.Remove(MarketerReportById(ID));
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
