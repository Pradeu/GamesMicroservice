namespace Game.DB.Entities
{
    public class DbGame
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public float Score { get; set; }
        public int ScoresCount { get; set; }

        public ICollection<DbUserList> UserLists { get; set; } = new List<DbUserList>();
        public virtual List<DbGenre> Genres { get; set; } = new List<DbGenre>();
        public virtual List<GenreGame> GenreGames { get; set; } = new List<GenreGame>();
        public virtual List<DbPlatform> Platforms { get; set; } = new List<DbPlatform>();
        public virtual List<PlatformGame> PlatformGames { get; set; } = new List<PlatformGame>();
        public virtual List<DbEngine> Engines { get; set; } = new List<DbEngine>();
        public virtual List<EngineGame> EngineGames { get; set; } = new List<EngineGame>();
        public virtual List<DbDeveloper> Developers { get; set; } = new List<DbDeveloper>();
        public virtual List<DeveloperGame> DeveloperGames { get; set; } = new List<DeveloperGame>();

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}