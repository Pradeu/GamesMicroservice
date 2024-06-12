namespace Game.DB.Entities
{
    public class GenreGame
    {
        public int GameId { get; set; }

        public DbGame? Game { get; set; }

        public int GenreId { get; set; }

        public DbGenre? Genre { get; set; }

    }
}