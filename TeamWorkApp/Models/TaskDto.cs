using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeamWorkApp.Models
{
    public class TaskDto
    {
        public int TaskID { get; set; }
        public string TaskDescription { get; set; }

        public DateTime TaskDueDate { get; set; }

        public TaskStatus TaskStatus { get; set; }
        public List<TeamMemberDto> TeamMembers { get; set; }
    }
}