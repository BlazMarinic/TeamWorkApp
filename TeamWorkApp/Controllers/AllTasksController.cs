using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TeamWorkApp.Data;
using TeamWorkApp.Models;

namespace TeamWorkApp.Controllers
{
    public class AllTasksController : ApiController
    {
        private TeamWorkAppContext db = new TeamWorkAppContext();

        // GET: api/AllTasks
        public List<TaskDto> GetTasks()
        {
            var tasks = new List<TaskDto>();

            foreach (var task in db.Tasks)
            {
                var teamMembers = new List<TeamMemberDto>();

                foreach (var tm in task.TeamMembers)
                {
                    teamMembers.Add(new TeamMemberDto { TeamMemberID = tm.TeamMemberID, Name = tm.Name });
                }

                tasks.Add(new TaskDto
                {
                    TaskID = task.TaskID,
                    TaskDescription = task.TaskDescription,
                    TaskDueDate = task.TaskDueDate,
                    TaskStatus = task.TaskStatus,
                    TeamMembers = teamMembers
                });
            }

            return tasks;
        }

        // GET: api/AllTasks/5
        [ResponseType(typeof(TaskDto))]
        public IHttpActionResult GetTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            var teamMembers = new List<TeamMemberDto>();
            foreach (var tm in task.TeamMembers)
            {
                teamMembers.Add(new TeamMemberDto { TeamMemberID = tm.TeamMemberID, Name = tm.Name });
            }

            return Ok(new TaskDto
            {
                TaskID = task.TaskID,
                TaskDescription = task.TaskDescription,
                TaskDueDate = task.TaskDueDate,
                TaskStatus = task.TaskStatus,
                TeamMembers = teamMembers
            });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.TaskID == id) > 0;
        }
    }
}