using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public string MessageText { get; set; }
        public Person Reciever { get; set; }
        public Person Sender { get; set; }

        public int SenderId { get; set; }
        public int RecieverId { get; set; }
    }
}