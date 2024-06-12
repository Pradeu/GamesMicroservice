namespace Game.DB.Entities
{
    public class DbDeveloper
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual List<DbGame>? Games { get; set; }
        public virtual List<DeveloperGame>? DeveloperGames { get; set; }
    }
}
