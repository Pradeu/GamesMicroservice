namespace Game.DB.Entities
{
    public class PlatformGame
    {
        public int GameId { get; set; }

        public DbGame? Game { get; set; }

        public int PlatformId { get; set; }

        public DbPlatform? Platform { get; set; }
    }
}