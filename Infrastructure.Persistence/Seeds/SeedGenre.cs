using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using System.Linq;

namespace Infrastructure.Persistence.Seeds
{
    public static class SeedGenre
    {
        public static async Task SeedAsync(IGenreRepository genreRepository)
        {
            var genries = await genreRepository.GetAllAsync();
            var genriesCount = genries.Count();

            if (genriesCount <= 0)
            {
                await genreRepository.AddAsync(new Domain.Entities.Genre() { Name = "Фантастика" });
                await genreRepository.AddAsync(new Domain.Entities.Genre() { Name = "Дизайн" });
                await genreRepository.AddAsync(new Domain.Entities.Genre() { Name = "Философия" });
                await genreRepository.AddAsync(new Domain.Entities.Genre() { Name = "Проза" });
            }
        }
    }
}
