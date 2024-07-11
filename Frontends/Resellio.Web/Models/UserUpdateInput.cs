namespace Resellio.Web.Models
{
    public class UserUpdateInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }
        public string PictureUrl { get; set; }
        public IFormFile PhotoFormFile { get; set; }
    }
}
