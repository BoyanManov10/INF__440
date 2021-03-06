﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using INF__440.Models;
using Microsoft.AspNet.Identity;

namespace INF__440.Controllers
{
    public class QuacksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Quacks
        public ActionResult Index()
        {
            return View(db.Quacks.ToList());
        }

        // Action method for listing the three newest quacks ordered by date 
        public ActionResult Home()
        {
            QuackViewModel quacks = new QuackViewModel();

            quacks.randomQuacks = db.Quacks.ToList().OrderByDescending(r => r.Date_Created).Take(3).ToList();
            quacks.quackLinks = db.Quacks.ToList().OrderBy(r => Guid.NewGuid()).Take(5).ToList();

            return View(quacks);
        }

        // GET: Quacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quack quack = db.Quacks.Find(id);
            if (quack == null)
            {
                return HttpNotFound();
            }
            return View(quack);
        }

        // GET: Quacks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Quacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Quack_Id,Quack_Title,Date_Created,Quack_Text")] Quack quack)
        {
            var userId = User.Identity.GetUserId();

            quack.UserId = userId;

            if (ModelState.IsValid)
            {
                db.Quacks.Add(quack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quack);
        }

        // GET: Quacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quack quack = db.Quacks.Find(id);
            if (quack == null)
            {
                return HttpNotFound();
            }
            return View(quack);
        }

        // POST: Quacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Quack_Id,Quack_Title,Date_Created,Quack_Text")] Quack quack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quack);
        }

        public ActionResult QuackList()
        {
            return View(db.Quacks.ToList());

           
        }

        // Action method for listing all the quacks created by the logged it user
        [Authorize]
        public ActionResult QuackListId()
        {
            var current_user_id = User.Identity.GetUserId();

            var all_quacks = db.Quacks.Where(x => x.UserId == current_user_id).ToList();
            return View(all_quacks);
        }

        // GET: Quacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Quack quack = db.Quacks.Find(id);
            if (quack == null)
            {
                return HttpNotFound();
            }
            return View(quack);
        }

        // POST: Quacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Quack quack = db.Quacks.Find(id);
            db.Quacks.Remove(quack);
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
