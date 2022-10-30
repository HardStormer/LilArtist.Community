namespace LilArtist.Community.PL.WebApi.Models
{
    public class Role
    {
        public Role(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
