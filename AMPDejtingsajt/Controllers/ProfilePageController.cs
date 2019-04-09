using DataLayer.Models;
using DataLayer.Repositories;
using AMPDejtingsajt.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPDejtingsajt.Controllers
{
    public class ProfilePageController : Controller
    {
        private DataContext dataContext = new DataContext();
        private PersonRepository personRepository;
        private MessageRepository messageRepository;


        public ProfilePageController()
        {

            personRepository = new PersonRepository(dataContext);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult User(int id)
        {
            string personid = (string)(Session["PersonID"]);
            
            if(personid == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var model = GetProfileWall();
                var user = personRepository.GetById(id);
                var message = dataContext.Message.Where(p => p.RecieverId == id).ToList();

                model.Person = user;
                model.Message = message;

                ViewBag.UserProfile = id;
                ViewBag.SendingProfile = personid;
                return View(model);
            }
        }

        private ProfileWallViewModel GetProfileWall()
        {
            return new ProfileWallViewModel { Person = new Person(), Message = new List<Message>() };
        }


        public ActionResult Edit(int id)
        {
            var person = personRepository.GetById(id);
            var userid = person.PersonID.ToString();
            string personid = (string)(Session["PersonID"]);

            if (userid == personid)
            {
                var model = person;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost]
        public ActionResult Edit(Person person, HttpPostedFileBase upload)
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
                personRepository.Edit(person);

                personRepository.Save(person);

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public ActionResult Image(int id)
        {
            var user = personRepository.GetById(id);

            return File(user.File, user.ContentType);
        }

        public ActionResult AddFriend(int receiverID)
        {
            using (DataContext db = new DataContext())
            {
                string senderID = (string)(Session["PersonID"]);
                int newSenderID = Int32.Parse(senderID);
                var friendRequests = dataContext.FriendRequest.Where(p => p.ReceiverId == receiverID)
                    .Where(p => p.SenderId == newSenderID)
                    .ToList();
                if (!friendRequests.Any())
                {
                    var friendRequest = new FriendRequest
                    {
                        SenderId = newSenderID,
                        ReceiverId = receiverID,
                        Status = "In progress",
                        FriendRequestDate = DateTime.Today
                    };

                    db.FriendRequest.Add(friendRequest);
                    db.SaveChanges();

                    return RedirectToAction("User", "Friends", new { id = senderID });
                }

                else {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
              
        
            }
        }
    }
}