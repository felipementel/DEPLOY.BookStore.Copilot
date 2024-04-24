using DEPLOY.BookStore.Application.Dtos.Base;
using System.Diagnostics.CodeAnalysis;

namespace DEPLOY.BookStore.Application.Dtos.BookPublisher
{
    [ExcludeFromCodeCoverage]
    public class BookPublisherDto : BaseDto
    {
        public string Nome { get; set; }
    }
}