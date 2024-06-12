namespace Game.DB.Entities
{
    public class DbUserStatus
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<DbUserList> UserLists { get; set; }
    }
}
