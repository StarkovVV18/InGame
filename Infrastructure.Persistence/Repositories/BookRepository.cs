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
    public class BookRepository : GenericRepositoryAsync<Book>, IBookRepository
    {
        private readonly DbSet<Book> _books;

        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _books = dbContext.Set<Book>();
        }

        public override async Task<IReadOnlyList<Book>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _books
                .Include(b => b.Author)
                .Include(b => b.Genre)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
