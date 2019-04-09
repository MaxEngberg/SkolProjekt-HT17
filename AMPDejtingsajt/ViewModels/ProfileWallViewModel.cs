using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMPDejtingsajt.ViewModels
{
    public class ProfileWallViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<Message> Message { get; set; }
    }
}