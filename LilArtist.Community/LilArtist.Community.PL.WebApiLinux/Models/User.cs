namespace LilArtist.Community.PL.WebApiLinux.Models
{
    public class User : IParameterPolicy
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<Role>? Roles { get; set; }
    }
}
