using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Task_28_7.Models;

namespace Task_28_7.Controllers
{
    public class MemInfoesController : Controller
    {
        private MemberInfoEntities db = new MemberInfoEntities();

        // GET: MemInfoes
        public ActionResult Index()
        {
            return View(db.MemInfoes.ToList());
        }

        // GET: MemInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemInfo memInfo = db.MemInfoes.Find(id);
            if (memInfo == null)
            {
                return HttpNotFound();
            }
            return View(memInfo);
        }

        // GET: MemInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Member_ID,Member_Name,Member_Age,Member_Img")] MemInfo memInfo)
        {
            if (ModelState.IsValid)
            {
                db.MemInfoes.Add(memInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(memInfo);
        }

        // GET: MemInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemInfo memInfo = db.MemInfoes.Find(id);
            if (memInfo == null)
            {
                return HttpNotFound();
            }
            return View(memInfo);
        }

        // POST: MemInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Member_ID,Member_Name,Member_Age,Member_Img")] MemInfo memInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(memInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(memInfo);
        }

        // GET: MemInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MemInfo memInfo = db.MemInfoes.Find(id);
            if (memInfo == null)
            {
                return HttpNotFound();
            }
            return View(memInfo);
        }

        // POST: MemInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MemInfo memInfo = db.MemInfoes.Find(id);
            db.MemInfoes.Remove(memInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
