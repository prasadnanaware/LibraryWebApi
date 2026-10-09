namespace LibraryWebApi.Models
{
    public class Member
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int Dateofjoined { get; set; }

        public bool LibraryID { get; set; }
    }
}