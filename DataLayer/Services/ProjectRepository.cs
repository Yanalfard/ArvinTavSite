using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ProjectRepository : IProjectRepository
    {
        private ArvinContext db;

        public ProjectRepository(ArvinContext context)
        {
            this.db = context;
        }

        public IEnumerable<Project> Allprojects()
        {
            return db.projects;
        }

        public string Create(string Title, string Image, string Link)
        {
            try
            {
                Project project = new Project();
                project.Title = Title;
                project.Image = Image;
                project.Link = Link;
                project.Status = 1;
                db.projects.Add(project);
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string Edit(int ID, string Title, string Image, string Link)
        {
            try
            {
                Project project = ProjectById(ID);
                project.Title = Title;
                if (Image != "")
                {
                    project.Image = Image;
                }
                project.Link = Link;
                Save();
                return "true";
            }
            catch (Exception ex)
            {
                return "Erorr :" + ex.Message;
            }
        }

        public string Remove(int ID)
        {
            db.projects.Remove(ProjectById(ID));
            Save();
            return "true";
        }

        public void ChangeStatus(int ID)
        {
            Project project = ProjectById(ID);
            if (project.Status == 1)
            {
                project.Status = 2;
            }
            else if (project.Status == 2)
            {
                project.Status = 1;
            }
            Save();
        }

        public Project ProjectById(int ID)
        {
            return db.projects.Find(ID);
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
