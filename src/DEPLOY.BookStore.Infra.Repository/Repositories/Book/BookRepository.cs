using System.Threading.Tasks;
using DEPLOY.BookStore.Domain.Aggregates.Book.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Base.Repository.MongoDB;
using DEPLOY.BookStore.Infra.Database.Repositories.Base;
using MongoDB.Driver;

namespace DEPLOY.BookStore.Infra.Database.Repositories.Book
{
    public class BookRepository : BaseRepository<Domain.Aggregates.Book.Entities.Book, string>, IBookRepository
    {
        private readonly IMongoDBContext _context;

        public BookRepository(IMongoDBContext context) : base(context, "Book")
        {
            _context = context;
        }

        public async Task<bool> GetByTitleAsync(string title)
        {
            FilterDefinition<Domain.Aggregates.Book.Entities.Book> filter = Builders<Domain.Aggregates.Book.Entities.Book>.Filter.Eq(x => x.Title, title);

            var item = await _collection.FindAsync(filter: filter);

            return await item.AnyAsync();
        }
    }
}
