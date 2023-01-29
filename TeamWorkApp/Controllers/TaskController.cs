using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TeamWorkApp.Data;
using TeamWorkApp.Models;

namespace TeamWorkApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly TeamWorkAppContext _db = new TeamWorkAppContext();
        
        //Helper function to retrieve team members from DB
        private void PopulateAssignedTeamMembers(Task task = null)
        {
            if (task != null)
            {
                var alreadyAssigned = new List<string>();
                foreach (var x in task.TeamMembers)
                {
                    alreadyAssigned.Add(x.TeamMemberID.ToString());
                }
                ViewBag.AlreadyAssignedteamMembers = alreadyAssigned.ToArray();   
            }
            
            var viewModel = new List<AssignedTeamMembers>();
            var allTeamMembers = _db.TeamMembers;
            
            foreach (var t in allTeamMembers)
            {
                viewModel.Add(new AssignedTeamMembers
                {
                    TeamMemberId = t.TeamMemberID,
                    TeamMemberName = t.Name
                });
            }

            ViewBag.TeamMembers = viewModel;
        }

        // GET: Task
        public ActionResult Index()
        {
            var tasks = _db.Tasks.Include(x => x.TeamMembers);
            return View(tasks.ToList());
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            PopulateAssignedTeamMembers();
            return View();
        }

        // POST: Task/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TaskID,TaskName,TaskDescription,TaskDueDate,TaskStatus")] Task task, string[] selectedTeamMembers)
        {
            if (!ModelState.IsValid)
                return View(task);

            //Check for selected team members on created task
            if (selectedTeamMembers != null)
            {
                task.TeamMembers = new List<TeamMember>();
                foreach (var tm in selectedTeamMembers)
                {
                    var teamMemberToAdd = _db.TeamMembers.Find(int.Parse(tm));
                    task.TeamMembers.Add(teamMemberToAdd);
                }
            }

            _db.Tasks.Add(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            Task task = _db.Tasks.Find(id);

            PopulateAssignedTeamMembers(task);
            
            if (task == null)
                return HttpNotFound();

            return View(task);
        }

        // POST: Task/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,TaskName,TaskDescription,TaskDueDate,TaskStatus")] Task task, string[] selectedTeamMembers)
        {
            if (!ModelState.IsValid)
                return View(task);
            
            _db.Tasks.Attach(task);
            _db.Entry(task).Collection(a => a.TeamMembers).Load();
            
            //Check for selected team members on created task
            if (selectedTeamMembers != null)
            {
                task.TeamMembers = new List<TeamMember>();
                foreach (var tm in selectedTeamMembers)
                {
                    var teamMemberToAdd = _db.TeamMembers.Find(int.Parse(tm));
                    task.TeamMembers.Add(teamMemberToAdd);
                }
            }

            _db.Entry(task).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = _db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = _db.Tasks.Find(id);
            _db.Tasks.Remove(task);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
