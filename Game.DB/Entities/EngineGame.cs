namespace Game.DB.Entities
{
    public class EngineGame
    {
        public int GameId { get; set; }

        public DbGame? Game { get; set; }

        public int EngineId { get; set; }

        public DbEngine? Engine { get; set; }
    }
}
