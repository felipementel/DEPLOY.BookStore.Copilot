﻿using AutoMapper;
using DEPLOY.BookStore.Application.Dtos.Book;
using DEPLOY.BookStore.Application.Interfaces.Book;
using DEPLOY.BookStore.Domain.Aggregates.Book.Interfaces.Services;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace DEPLOY.BookStore.Application.Services.Book
{
    [ExcludeFromCodeCoverage]
    public class BookAppService : IBookAppService
    {
        private readonly IMapper _mapper;

        private readonly IBookService _BookService;

        public BookAppService(IMapper mapper, IBookService BookService)
        {
            _mapper = mapper;
            _BookService = BookService;
        }

        public async Task<BookDto> AddBookAsync(BookDto BookDto)
        {
            var itemDomain = _mapper.Map<BookDto, Domain.Aggregates.Book.Entities.Book>(BookDto);

            var item = await _BookService.AddBookAsync(itemDomain);

            return _mapper.Map<Domain.Aggregates.Book.Entities.Book, BookDto>(item);
        }

        public async Task<bool> DeleteBookAsync(string id)
        {
            return await _BookService.DeleteBookAsync(id);
        }

        public async Task<BookDto> GetBookAsync(string id)
        {
            var item = await _BookService.GetBookAsync(id);

            return _mapper.Map<Domain.Aggregates.Book.Entities.Book, BookDto>(item);
        }

        public async Task<List<BookDto>> ListBookAsync()
        {
            var item = await _BookService.ListBookAsync();

            return _mapper.Map<List<Domain.Aggregates.Book.Entities.Book>, List<BookDto>>(item);
        }

        public async Task<BookDto> UpdateBookAsync(string id, BookDto BookDto)
        {
            var itemDomain = _mapper.Map<BookDto, Domain.Aggregates.Book.Entities.Book>(BookDto);

            var itemUpdated = await _BookService.UpdateBookAsync(id, itemDomain);

            return _mapper.Map<Domain.Aggregates.Book.Entities.Book, BookDto>(itemUpdated);
        }
    }
}