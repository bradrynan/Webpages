using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HelloWorld.DAL;
using HelloWorld.Models;

namespace HelloWorld.Controllers
{
    public class LearningPlansController : Controller
    {
        private WebpageDbContext db = new WebpageDbContext();

        // GET: LearningPlans
        public ActionResult Index(int? id)
        {
            /*
             * from store in database.Stores
        where store.CompanyID == curCompany.ID
        select
             * */

            int? LearningPlanParentID = (from lp in db.LearningPlans
                                         where (lp.LearningPlanParentID.ID == id && lp.LearningPlanParentID.ID != null)
                               select lp.LearningPlanParentID.ID ).FirstOrDefault();

            ViewBag.HelloName = "BRAD";

            int? bb = LearningPlanParentID;

            ViewBag.ParentId = LearningPlanParentID == 0 ? null : LearningPlanParentID;

            var masterLearningPlans = from lp in db.LearningPlans
                                      where (lp.LearningPlanParentID.ID == id)
                                      select lp;
            // return View(db.LearningPlans.ToList());

            return View(masterLearningPlans.ToList());
        }

        // GET: LearningPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LearningPlan learningPlan = db.LearningPlans.Find(id);
            if (learningPlan == null)
            {
                return HttpNotFound();
            }
            return View(learningPlan);
        }

        // GET: LearningPlans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LearningPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,LearningType,Description")] LearningPlan learningPlan)
        {
            if (ModelState.IsValid)
            {
                db.LearningPlans.Add(learningPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(learningPlan);
        }

        // GET: LearningPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LearningPlan learningPlan = db.LearningPlans.Find(id);
            if (learningPlan == null)
            {
                return HttpNotFound();
            }
            return View(learningPlan);
        }

        // POST: LearningPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LearningType,Description")] LearningPlan learningPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(learningPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(learningPlan);
        }

        // GET: LearningPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LearningPlan learningPlan = db.LearningPlans.Find(id);
            if (learningPlan == null)
            {
                return HttpNotFound();
            }
            return View(learningPlan);
        }

        // POST: LearningPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LearningPlan learningPlan = db.LearningPlans.Find(id);
            db.LearningPlans.Remove(learningPlan);
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
