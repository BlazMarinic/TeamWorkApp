using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamWorkApp.Models
{
    public class Task
    {
        public int TaskID { get; set; }
        [Required] public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        [Required] public DateTime TaskDueDate { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
    }
}