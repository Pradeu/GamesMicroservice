namespace Game.API.Models
{
    public class DtoUserList
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public DtoGame? Game { get; set; }
        public int UserId { get; set; }
        public int UserScore { get; set; }
        public int StatusId { get; set; }

    }
}
