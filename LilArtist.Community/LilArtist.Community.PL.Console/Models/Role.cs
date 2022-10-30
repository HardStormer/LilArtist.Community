namespace LilArtist.Community.PL.MyConsole.Models
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
