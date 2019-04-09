using DataLayer.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AMPDejtingsajt.Controllers.Api
{
    public class ApiMessageController : ApiController
    {
        private DataContext database = new DataContext();

        [HttpPost]
        public void CreateNewMessage([FromBody]Message newMessage)
        {
            database.Message.Add(newMessage);
            database.SaveChanges();
        }
    }
}