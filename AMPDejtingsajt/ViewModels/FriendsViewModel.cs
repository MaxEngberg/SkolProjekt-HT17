using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMPDejtingsajt.ViewModels
{
    public class FriendsViewModel
    {
        public IEnumerable<Person> Person { get; set; }
        public IEnumerable<Person> PersonTwo { get; set; }
    }
}