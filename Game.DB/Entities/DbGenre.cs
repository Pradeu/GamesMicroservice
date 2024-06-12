namespace Game.DB.Entities
{
    public class DbGenre
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public virtual List<DbGame>? Games { get; set; }
        public virtual List<GenreGame>? GenreGames { get; set; }
    }
}