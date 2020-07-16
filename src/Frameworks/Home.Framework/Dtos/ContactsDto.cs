using System;
using System.Collections.Generic;
using System.Text;

namespace Home.Framework.Dtos
{
    public class ContactsDto
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string[] ErrorMessage { get; set; }
    }
}
