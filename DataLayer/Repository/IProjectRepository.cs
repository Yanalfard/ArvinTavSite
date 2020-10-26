using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IProjectRepository : IDisposable
    {
        IEnumerable<Project> Allprojects();

        Project ProjectById(int ID);

        string Create(string Title, string Image, string Link);

        string Edit(int ID, string Title, string Image, string Link);

        string Remove(int ID);

        void ChangeStatus(int ID);

        void Save();
    }
}
