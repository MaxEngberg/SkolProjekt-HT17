using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Models;

namespace AMPDejtingsajt.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            string personid = (string)(Session["PersonID"]);

            if (personid == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            
        }

        [HttpPost]
        public ActionResult Register(Person person, HttpPostedFileBase upload)
        {
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    person.FileName = upload.FileName;
                    person.ContentType = upload.ContentType;

                    using (var reader = new BinaryReader(upload.InputStream))
                    {
                        person.File = reader.ReadBytes(upload.ContentLength);
                    }
                }

                if (ModelState.IsValid)
                {
                    using (DataContext db = new DataContext())
                    {
                        db.User.Add(person);
                        db.SaveChanges();
                    }
                    ModelState.Clear();
                    ViewBag.Message = person.UserName + " successfully registered.";
                }
                return View();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        //Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Person person)
        {
            using (DataContext db = new DataContext())
            {
                var validation = db.User.Where(p => p.UserName == person.UserName && p.Password == person.Password).FirstOrDefault();

                if (validation != null)
                {
                    Session["PersonID"] = validation.PersonID.ToString();
                    string id = (string)(Session["PersonID"]);
                    Session["Username"] = validation.UserName.ToString();
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError("", "Username or Password is wrong.");
                }
            }

            return View();

        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Remove("PersonID");
            return RedirectToAction("Index", "Home");
        }
    }
}