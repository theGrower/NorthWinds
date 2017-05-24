using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NorthWinds.Models;

namespace NorthWinds.Controllers
{
    public class CustomerDemographicsController : Controller
    {
        private NorthwindsDB db = new NorthwindsDB();

        // GET: CustomerDemographics
        public async Task<ActionResult> Index()
        {
            return View(await db.CustomerDemographics.ToListAsync());
        }

        // GET: CustomerDemographics/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDemographic customerDemographic = await db.CustomerDemographics.FindAsync(id);
            if (customerDemographic == null)
            {
                return HttpNotFound();
            }
            return View(customerDemographic);
        }

        // GET: CustomerDemographics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerDemographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CustomerTypeID,CustomerDesc")] CustomerDemographic customerDemographic)
        {
            if (ModelState.IsValid)
            {
                db.CustomerDemographics.Add(customerDemographic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customerDemographic);
        }

        // GET: CustomerDemographics/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDemographic customerDemographic = await db.CustomerDemographics.FindAsync(id);
            if (customerDemographic == null)
            {
                return HttpNotFound();
            }
            return View(customerDemographic);
        }

        // POST: CustomerDemographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CustomerTypeID,CustomerDesc")] CustomerDemographic customerDemographic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerDemographic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customerDemographic);
        }

        // GET: CustomerDemographics/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerDemographic customerDemographic = await db.CustomerDemographics.FindAsync(id);
            if (customerDemographic == null)
            {
                return HttpNotFound();
            }
            return View(customerDemographic);
        }

        // POST: CustomerDemographics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            CustomerDemographic customerDemographic = await db.CustomerDemographics.FindAsync(id);
            db.CustomerDemographics.Remove(customerDemographic);
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
