using System.Threading.Tasks;
using DEPLOY.BookStore.Domain.Base.Repository;

namespace DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories
{
    public interface IBookPublisherRepository : IBaseRepository<BookPublisher.Entities.BookPublisher, string>
    {
        
    }
}