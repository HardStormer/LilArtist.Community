namespace LilArtist.Community.BLL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public IEnumerable<Role>? Roles { get; set; }
    }
}
