using Game.DB.Entities;

namespace Game.API.Models
{
    public class DtoGame
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public float Score { get; set; }
        public int ScoresCount { get; set; }

        public required ICollection<int> GenreId { get; set; }
        public required ICollection<int> PlatformId { get; set; }
        public required ICollection<int> EngineId { get; set; }
        public required ICollection<int> DeveloperId { get; set; }

        public ICollection<int>? UsersId { get; set; }

        public List<DtoGenre>? GenreList { get; set; } = new List<DtoGenre>();
        public List<DtoPlatform>? PlatformList { get; set; } = new List<DtoPlatform>();
        public List<DtoEngine>? EngineList { get; set; } = new List<DtoEngine>();
        public List<DtoDeveloper>? DeveloperList { get; set; } = new List<DtoDeveloper>();
    }
}