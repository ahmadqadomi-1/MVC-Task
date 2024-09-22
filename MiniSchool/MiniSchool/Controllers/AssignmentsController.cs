using MiniSchool.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MiniSchool.Controllers
{
    public class AssignmentsController : Controller
    {
        // GET: Assignments
        private readonly MyDb Db = new MyDb();
        public ActionResult Index(int? classId)
        {
            var assignments = Db.Assignments.Include(a => a.Class);

            if (classId.HasValue)
            {
                assignments = assignments.Where(a => a.ClassId == classId.Value);
            }

            return View(assignments.ToList());
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = Db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create
        public ActionResult Create(int? classId)
        {
            ViewBag.ClassId = new SelectList(Db.Classes, "ClassId", "ClassName", classId);
            return View();
        }

        // POST: Assignments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,DueDate,ClassId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                Db.Assignments.Add(assignment);
                Db.SaveChanges();
                return RedirectToAction("Index", new { classId = assignment.ClassId });
            }

            ViewBag.ClassId = new SelectList(Db.Classes, "ClassId", "ClassName", assignment.ClassId);
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = Db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(Db.Classes, "ClassId", "ClassName", assignment.ClassId);
            return View(assignment);
        }

        // POST: Assignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,DueDate,ClassId")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(assignment).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(Db.Classes, "ClassId", "ClassName", assignment.ClassId);
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = Db.Assignments.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = Db.Assignments.Find(id);
            Db.Assignments.Remove(assignment);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}