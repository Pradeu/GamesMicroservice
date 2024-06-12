namespace Game.DB.Entities
{
    public class DbEngine
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual List<DbGame>? Games { get; set; }
        public virtual List<EngineGame>? EngineGames { get; set; }
    }
}
