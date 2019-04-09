using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class FriendRequest
    {
        public int FriendRequestID { get; set; }

        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public string Status { get; set; }
        public DateTime FriendRequestDate { get; set; }

        public virtual Person Sender { get; set; }
        public virtual Person Receiver { get; set; }
    }
}