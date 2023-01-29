using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Description;

namespace TeamWorkApp.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        [DisplayName("Opis")] public string TaskDescription { get; set; }

        [DisplayName("Datum zaključka opravila")]
        [Required(ErrorMessage = "Za nadaljevanje je potrebno vnesti datum zaključka")]
        public DateTime TaskDueDate { get; set; }

        [DisplayName("Stanje opravila")] public TaskStatus TaskStatus { get; set; }
        [DisplayName("Dodeljeni člani ekipe")] public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}