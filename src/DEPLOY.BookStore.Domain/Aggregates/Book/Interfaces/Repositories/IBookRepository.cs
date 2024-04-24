using System.Threading.Tasks;
using DEPLOY.BookStore.Domain.Base.Repository;

namespace DEPLOY.BookStore.Domain.Aggregates.Book.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<Entities.Book, string>
    {
        Task<bool> GetByTitleAsync(string title);
    }
}