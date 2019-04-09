using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataLayer.Repositories
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext dataContext)
        {
            
            var examplePerson1 = new Person
            {
                FirstName = "Jesper",
                LastName = "Andersson",
                SocialNumber = "199108191111",
                Gender = "Male",
                City = "Stockholm",
                Mail = "jesper@live.se",
                UserName = "Jesper",
                Password = "test",
                PresentationText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                isSearchable = false
            };

            var examplePerson2 = new Person
            {
                FirstName = "Victoria",
                LastName = "Svensson",
                SocialNumber = "199108191111",
                Gender = "Female",
                City = "Stockholm",
                Mail = "Vvictoria@live.se",
                UserName = "Victoria",
                Password = "test",
                PresentationText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                isSearchable = false
            };

            var examplePerson3 = new Person
            {
                FirstName = "Robert",
                LastName = "Jakobsson",
                SocialNumber = "199108191111",
                Gender = "Male",
                City = "Stockholm",
                Mail = "robert@live.se",
                UserName = "Robert",
                Password = "test",
                PresentationText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                isSearchable = false
            };

            var examplePerson4 = new Person
            {
                FirstName = "Britt",
                LastName = "Rogthenstein",
                SocialNumber = "199108191111",
                Gender = "Female",
                City = "Stockholm",
                Mail = "britt@live.se",
                UserName = "Britt",
                Password = "test",
                PresentationText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                isSearchable = false
            };

            dataContext.User.Add(examplePerson1);
            dataContext.User.Add(examplePerson2);
            dataContext.User.Add(examplePerson3);
            dataContext.User.Add(examplePerson4);

            dataContext.SaveChanges();
            
        }
    }
}