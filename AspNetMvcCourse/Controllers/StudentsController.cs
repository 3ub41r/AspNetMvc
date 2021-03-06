﻿using System;
using AspNetMvcCourse.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMvcCourse.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AspNetMvcDbContext _db = new AspNetMvcDbContext();

        // GET: Students
        public ActionResult Index(string search)
        {
            using (var db = new AspNetMvcDbContext())
            {
                var students = from s in db.Students
                               select s;

                // Filter by the keyword 'search'
                if (!string.IsNullOrEmpty(search)) students = students.Where(n => n.Name.Contains(search));

                return View(students.ToList());
            }
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IcNumber,MatricNumber,DateOfBirth")] Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Students.Add(student);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var student = _db.Students.Find(id);

            if (student == null) return HttpNotFound();

            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            using (var db = new AspNetMvcDbContext())
            {
                var student = db.Students.Find(id);
                
                // Use TryUpdateModel to update fields from user input in the posted form data
                // Bind resets fields
                if (!TryUpdateModel(student, "", new[] {"MatricNumber", "Name", "IcNumber", "DateOfBirth"}))
                    return View(student);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = _db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //var student = _db.Students.Find(id);
            //_db.Students.Remove(student);

            using (var db = new AspNetMvcDbContext())
            {
                // Reduce call to DB
                var student = new Student { Id = id };
                db.Entry(student).State = EntityState.Deleted;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
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
