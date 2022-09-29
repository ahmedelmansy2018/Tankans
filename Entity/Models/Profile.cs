using System;
using System.Collections.Generic;


namespace Entity.Models
{
    public class Profile
    {
        public Profile()
        {
            Tasks = new HashSet<task>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<task> Tasks { get; set; }
    }
}
