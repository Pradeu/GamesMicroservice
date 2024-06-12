namespace Game.DB.Entities
{
    public class DbUserList
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public DbGame? Game { get; set; }
        public int UserId { get; set; }
        public int UserScore { get; set; }
        public int StatusId { get; set; }
        public DbUserStatus? UserStatus { get; set; }
    }
}
