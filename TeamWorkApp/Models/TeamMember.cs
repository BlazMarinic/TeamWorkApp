using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWorkApp.Models
{
    public class TeamMember
    {
        public int TeamMemberID { get; set; }
        [Required(ErrorMessage = "Ime in priimek je obvezen podatek!")]
        [DisplayName("Ime in priimek")]
        public string Name { get; set; }    
        public virtual ICollection<Task> Tasks { get; set; }
    }
}