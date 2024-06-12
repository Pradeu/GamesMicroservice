namespace Game.DB.Entities
{
    public class DeveloperGame
    {
        public int GameId { get; set; }

        public DbGame? Game { get; set; }

        public int DeveloperId { get; set; }

        public DbDeveloper? Developer { get; set; }
    }
}
