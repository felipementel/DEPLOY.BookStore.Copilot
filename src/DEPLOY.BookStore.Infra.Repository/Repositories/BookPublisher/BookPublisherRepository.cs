using System.Threading.Tasks;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Base.Repository.MongoDB;
using DEPLOY.BookStore.Infra.Database.Repositories.Base;
using MongoDB.Driver;

namespace DEPLOY.BookStore.Infra.Database.Repositories.BookPublisher
{
    public class BookPublisherRepository :
        BaseRepository<Domain.Aggregates.BookPublisher.Entities.BookPublisher, string>,
        IBookPublisherRepository
    {
        private readonly IMongoDBContext _mongoDBContext;
        public BookPublisherRepository(IMongoDBContext mongoDBContext) : base(mongoDBContext, "BookPublisher")
        {
            _mongoDBContext = mongoDBContext;
        }

        public Task<bool> BookExistsAsync(string name)
        {
            var filter = Builders<Domain.Aggregates.BookPublisher.Entities.BookPublisher>.Filter.Eq(x => x.Name, name);

            return _mongoDBContext.GetCollection<Domain.Aggregates.BookPublisher.Entities.BookPublisher>("BookPublisher")
                .Find(filter)
                .AnyAsync();
        }
    }
}