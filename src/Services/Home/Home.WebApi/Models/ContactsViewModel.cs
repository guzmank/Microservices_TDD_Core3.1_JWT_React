namespace Home.WebApi.Models
{
    public class ContactsViewModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string[] ErrorMessage { get; set; }
    }
}
