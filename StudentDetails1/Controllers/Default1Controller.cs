using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentDetails1.Models;

namespace StudentDetails1.Controllers
{
    public class Default1Controller : Controller
    {
        private StudentDetailsEntities db = new StudentDetailsEntities();

        // GET: /Default1/
        public async Task<ActionResult> Index()
        {
            return View(await db.tblStudentInfoes.ToListAsync());
        }

        // GET: /Default1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblstudentinfo = await db.tblStudentInfoes.FindAsync(id);
            if (tblstudentinfo == null)
            {
                return HttpNotFound();
            }
            return View(tblstudentinfo);
        }

        // GET: /Default1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Default1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Student_Id,Student_Name,Student_Mobile,Student_Address,Student_Dept")] tblStudentInfo tblstudentinfo)
        {
            if (ModelState.IsValid)
            {
                db.tblStudentInfoes.Add(tblstudentinfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblstudentinfo);
        }

        // GET: /Default1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblstudentinfo = await db.tblStudentInfoes.FindAsync(id);
            if (tblstudentinfo == null)
            {
                return HttpNotFound();
            }
            return View(tblstudentinfo);
        }

        // POST: /Default1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Student_Id,Student_Name,Student_Mobile,Student_Address,Student_Dept")] tblStudentInfo tblstudentinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblstudentinfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblstudentinfo);
        }

        // GET: /Default1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudentInfo tblstudentinfo = await db.tblStudentInfoes.FindAsync(id);
            if (tblstudentinfo == null)
            {
                return HttpNotFound();
            }
            return View(tblstudentinfo);
        }

        // POST: /Default1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblStudentInfo tblstudentinfo = await db.tblStudentInfoes.FindAsync(id);
            db.tblStudentInfoes.Remove(tblstudentinfo);
            await db.SaveChangesAsync();
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
