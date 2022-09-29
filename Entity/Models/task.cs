using System;
using System.Collections.Generic;


namespace Entity.Models
{
    public class task
    {
        public int Id { get; set; }
        public int FkprofileId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime StartTime { get; set; }
        public int Status { get; set; }

        public virtual Profile Fkprofile { get; set; }
    }
}
