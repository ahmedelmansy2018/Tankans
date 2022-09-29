using DAL;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLLProfile
    {
        public static IList<Profile> List()
        {
            return DataService.Profiles.List();
        }
        public static Profile Get(int Id)
        {
            return DataService.Profiles.GET(Id);
        }

        public static bool Add(Profile Profile)
        {
            return DataService.Profiles.Create(Profile);
        }

        public static bool Edit(Profile Profile)
        {
            return DataService.Profiles.Update(Profile);
        }

        public static string Delete(int Id)
        {
            return DataService.Profiles.Delete(Id);
        }
    }
}
