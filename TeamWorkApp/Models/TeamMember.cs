using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWorkApp.Models
{
    public class TeamMember
    {
        public int TeamMemberID { get; set; }
        [Required]
        public string Name { get; set; }    
        public virtual ICollection<Task> Tasks { get; set; }
    }
}