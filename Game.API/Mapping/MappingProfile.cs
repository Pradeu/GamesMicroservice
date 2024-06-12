using AutoMapper;
using Game.API.Models;
using Game.DB.Entities;

namespace Game.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DbGame, DtoGame>()
                .ForMember(dest => dest.GenreList, opt => opt.MapFrom(src => src.Genres.ToList()))
                .ForMember(dest => dest.PlatformList, opt => opt.MapFrom(src => src.Platforms.ToList()))
                .ForMember(dest => dest.EngineList, opt => opt.MapFrom(src => src.Engines.ToList()))
                .ForMember(dest => dest.DeveloperList, opt => opt.MapFrom(src => src.Developers.ToList()))
                .ForMember(dest => dest.UsersId, opt => opt.MapFrom(src => src.UserLists.Select(q => q.UserId).ToList()));
            CreateMap<DtoGame, DbGame>()
                .ForMember(dest => dest.GenreGames, m => m.MapFrom(src => CreateGenreGames(src.GenreId)))
                .ForMember(dest => dest.PlatformGames, m => m.MapFrom(src => CreatePlatformGames(src.PlatformId)))
                .ForMember(dest => dest.EngineGames, m => m.MapFrom(src => CreateEngineGames(src.EngineId)))
                .ForMember(dest => dest.DeveloperGames, m => m.MapFrom(src => CreateDeveloperGames(src.DeveloperId)));
            CreateMap<DbGenre, DtoGenre>();
            CreateMap<DtoGenre, DbGenre>();
            CreateMap<DbPlatform, DtoPlatform>()
                .ReverseMap();
            CreateMap<DbEngine, DtoEngine>()
                .ReverseMap();
            CreateMap<DbDeveloper, DtoDeveloper>() 
                .ReverseMap();
            CreateMap<DbUserList, DtoUserList>()
                .ReverseMap();
            CreateMap<DbUserStatus, DtoUserStatus>()
                .ReverseMap();
        }

        private static List<GenreGame> CreateGenreGames(ICollection<int> genreIds)
        {
            List<GenreGame> genreGames = new();

            foreach (int id in genreIds)
            {
                genreGames.Add(new GenreGame
                {
                    GenreId = id,
                });
            }

            return genreGames.ToList();
        }

        private static List<PlatformGame> CreatePlatformGames(ICollection<int> platformIds)
        {
            List<PlatformGame> platformGames = new();

            foreach (int id in platformIds)
            {
                platformGames.Add(new PlatformGame
                {
                    PlatformId = id,
                });
            }

            return platformGames.ToList();
        }

        private static List<EngineGame> CreateEngineGames(ICollection<int> engineIds)
        {
            List<EngineGame> engineGames = new();

            foreach (int id in engineIds)
            {
                engineGames.Add(new EngineGame
                {
                    EngineId = id,
                });
            }

            return engineGames.ToList();
        }

        private static List<DeveloperGame> CreateDeveloperGames(ICollection<int> developerIds)
        {
            List<DeveloperGame> developerGames = new();

            foreach (int id in developerIds)
            {
                developerGames.Add(new DeveloperGame
                {
                    DeveloperId = id,
                });
            }

            return developerGames.ToList();
        }
    }
}