using System.Diagnostics.CodeAnalysis;
using DEPLOY.BookStore.Application.Interfaces.Book;
using DEPLOY.BookStore.Application.Interfaces.BookPublisher;
using DEPLOY.BookStore.Application.Services.Book;
using DEPLOY.BookStore.Application.Services.BookPublisher;
using DEPLOY.BookStore.Domain.Aggregates.Book.Entities;
using DEPLOY.BookStore.Domain.Aggregates.Book.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Aggregates.Book.Interfaces.Services;
using DEPLOY.BookStore.Domain.Aggregates.Book.Services;
using DEPLOY.BookStore.Domain.Aggregates.Book.Validators;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Entities;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Repositories;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Interfaces.Services;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Services;
using DEPLOY.BookStore.Domain.Aggregates.BookPublisher.Validators;
using DEPLOY.BookStore.Domain.Base.Repository.MongoDB;
using DEPLOY.BookStore.Infra.Database.Repositories.Base.MongoDB;
using DEPLOY.BookStore.Infra.Database.Repositories.Book;
using DEPLOY.BookStore.Infra.Database.Repositories.BookPublisher;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DEPLOY.BookStore.Infra.CrossCutting
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static void AddRegisterDependencyInjections(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper(typeof(Application.AutoMapperConfigs.Configs));

            serviceCollection.AddSingleton<IMongoDBContext, MongoDBContext>();

            serviceCollection.AddScoped<IBookPublisherAppService, BookPublisherAppService>();

            serviceCollection.AddScoped<IBookPublisherService, BookPublisherService>();

            serviceCollection.AddTransient<IValidator<BookPublisher>, BookPublisherValidator>();

            serviceCollection.AddScoped<IBookPublisherRepository, BookPublisherRepository>();

            serviceCollection.AddScoped<IBookAppService, BookAppService>();

            serviceCollection.AddScoped<IBookService, BookService>();

            serviceCollection.AddTransient<IValidator<Book>, BookValidator>();

            serviceCollection.AddScoped<IBookRepository, BookRepository>();
        }
    }
}