using DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLLTask
    {
        public static IList<task> List()
        {
            return DataService.Tasks.List();
        }
        public static task Get(int Id)
        {
            return DataService.Tasks.GET(Id);
        }

        public static bool Add(task task)
        {
            return DataService.Tasks.Create(task);
        }

        public static bool Edit(task task)
        {
            return DataService.Tasks.Update(task);
        }

        public static bool Delete(int Id)
        {
            return DataService.Tasks.Delete(Id);
        }
    }
}
