using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Base.Repository.MongoDB;
using DEPLOY.BookStore.Infra.Database.Repositories.Base;

namespace DEPLOY.BookStore.Infra.Database.Repositories.BookPublisher
{
    public class BookPublisherRepository(IMongoDBContext mongoDBContext) :
        BaseRepository<Domain.Aggregates.BookPublisher.Entities.BookPublisher, string>(mongoDBContext, "BookPublisher"),
        IBookPublisherRepository
    {
    }
}