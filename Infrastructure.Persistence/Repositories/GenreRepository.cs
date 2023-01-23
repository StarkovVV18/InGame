using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class GenreRepository : GenericRepositoryAsync<Genre>, IGenreRepository
    {
        private readonly DbSet<Genre> _genries;

        public GenreRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _genries = dbContext.Set<Genre>();
        }
    }
}
