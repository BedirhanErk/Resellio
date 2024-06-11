namespace Resellio.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> GetUserProps()
        {
            yield return Name;
            yield return Surname;
            yield return Email;
        }
    }
}
