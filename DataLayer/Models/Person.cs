using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DataLayer.Models
{
    public class Person
    {
        public Person()
        {
            FriendRequestReceive = new HashSet<FriendRequest>();
            FriendRequestSend = new HashSet<FriendRequest>();
            MessageRecieve = new HashSet<Message>();
            MessageSend = new HashSet<Message>();
        }

        [Key]
        public int PersonID { get; set; }

        [Required(ErrorMessage = "A first name is required.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Your firstname needs to be atleast 2 letters long")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Your firstname can only contain letters")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "A last name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your lastname needs to be atleast 3 letters long")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Your lastname can only contain letters")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "A social number is required.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Your socialnumber needs to be 12 numbers long")]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Your socialnumber can only contain numbers")]
        [Display(Name = "Social Number:")]
        public string SocialNumber { get; set; }

        [Required(ErrorMessage = "A gender is required.")]
        [Display(Name = "Gender:")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "A city is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The name of your city needs to be atleast 3 letters long")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "The name of your city can only contain letters")]
        [Display(Name = "City:")]
        public string City { get; set; }

        [Required(ErrorMessage = "A mail is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        [Display(Name = "Mail:")]
        public string Mail { get; set; }

        [Display(Name = "ProfilePicture:")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Presentation:")]
        public string PresentationText { get; set; }

        [Display(Name = "Preference:")]
        public string Preference { get; set; }

        [Required(ErrorMessage = "A username is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Your username needs to be atleast 3 letters long")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Your username can only contain letters")]
        [Display(Name = "User Name:")]
        public string UserName { get; set; }

        [Compare("Password", ErrorMessage = "A password is required.")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public virtual ICollection<FriendRequest> FriendRequestReceive { get; set; }
        public virtual ICollection<FriendRequest> FriendRequestSend { get; set; }
        public virtual ICollection<Message> MessageRecieve { get; set; }
        public virtual ICollection<Message> MessageSend { get; set; }

        public string FileName { get;  set; }


        public string ContentType { get;  set; }
        public byte[] File { get;  set; }

        public bool isSearchable { get; set; }
    }
}