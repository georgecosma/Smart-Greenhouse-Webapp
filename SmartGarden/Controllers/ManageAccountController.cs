using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SmartGarden.Models;
using Microsoft.AspNet.Identity;
using SmartGarden.Models.DbModels;
using System.Data.Entity;

namespace SmartGarden.Controllers
{
    [Authorize]
    public class ManageAccountController : Controller
    {
        private SmartGardenDbContext _db;
        // GET: ManageAccount
        public ManageAccountController()
        {
            _db = new SmartGardenDbContext();
        }
        public ActionResult Index()
        {
            string currentUserName = User.Identity.GetUserId();
            var user = _db.Users.Single(u => u.Id.ToString() == currentUserName);
            return View(user);
        }

        public ActionResult Edit()
        {
            string currentUserName = User.Identity.GetUserId();
            var user = _db.Users.Single(u => u.Id.ToString() == currentUserName);
            ViewBag.RoleId = new SelectList(_db.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,FirstName,LastName,Password,Email,RoleId")] User user)
        {
            if (ModelState.IsValid)
            {
                if(_db.Users.Any(u => u.UserName == user.UserName && u.Id != user.Id))
                {
                    ModelState.AddModelError("", "Acest nume de utilizator este deja înregistrat!");
                }
                else {
                    _db.Entry(user).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Index");
                    
                }

            }

            return View(user);
        }
    }
}