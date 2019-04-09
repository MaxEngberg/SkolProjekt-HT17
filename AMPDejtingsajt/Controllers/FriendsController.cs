using DataLayer.Models;
using DataLayer.Repositories;
using AMPDejtingsajt.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AMPDejtingsajt.Controllers
{
    public class FriendsController : Controller
    {
        private DataContext dataContext = new DataContext();
        private PersonRepository personRepository;

        public FriendsController()
        {
            personRepository = new PersonRepository(dataContext);
        }

        [HttpGet]
        public ActionResult User(int id)
        {
            var model = GetFriends();
            List<Person> userID = new List<Person>();
            List<int> ids = new List<int>();
            var friendRequests = dataContext.FriendRequest.Where(p => p.ReceiverId == id).ToList();

            foreach (var item in friendRequests)
            {
                ids.Add(item.SenderId);
            }

            foreach (var itemId in ids)
            {
                var person = dataContext.User.Where(p => p.PersonID == itemId).ToList();

                foreach (var finalPerson in person)
                {
                    userID.Add(finalPerson);
                }
            }

            List<Person> userIDTwo = new List<Person>();
            List<int> idsTwo = new List<int>();
            var friendRequestsTwo = dataContext.FriendRequest.Where(p => p.SenderId == id).ToList();

            foreach (var item in friendRequestsTwo)
            {
                idsTwo.Add(item.ReceiverId);
            }

            foreach (var itemIdTwo in idsTwo)
            {
                var person = dataContext.User.Where(p => p.PersonID == itemIdTwo).ToList();

                foreach (var finalPerson in person)
                {
                    userIDTwo.Add(finalPerson);
                }
            }

            model.Person = userID;
            model.PersonTwo = userIDTwo;

            return View(model);
        }


        private FriendsViewModel GetFriends()
        {
            return new FriendsViewModel { Person = new List<Person>(), PersonTwo = new List<Person>() };
        }
    }
}