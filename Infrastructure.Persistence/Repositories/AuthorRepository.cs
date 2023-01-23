using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class AuthorRepository : GenericRepositoryAsync<Author>, IAuthorRepository
    {
        private readonly DbSet<Author> _authors;

        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _authors = dbContext.Set<Author>();
        }

        public override async Task<IReadOnlyList<Author>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _authors
                .Include(a => a.Books)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
