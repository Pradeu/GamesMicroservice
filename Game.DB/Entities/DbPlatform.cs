namespace Game.DB.Entities
{
    public class DbPlatform
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual ICollection<DbGame> Games { get; set; }
            = new List<DbGame>();
        public virtual ICollection<PlatformGame> PlatformGames { get; set; }
            = new List<PlatformGame>();
    }
}