﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Base;
using AutoMapper;
using Domain.DataTransferObjects.Book;
using Domain.DataTransferObjects;
using Domain.Entities;
using Domain.Models.Exceptions.Book;
using Domain.Models.Exceptions;
using Domain.Models.LinkModel.Base;
using Domain.Models.RequestFeatures;
using Infrastructure.Repositories.Base;
using Application.Contracts.Interfaces;

namespace Application.Contracts.Services
{
    public class BookService : IBookService
    {
    
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IBookLinks _bookLinks;

        public BookService(IRepositoryManager manager,
            ILoggerService logger,
            IMapper mapper,
            IBookLinks bookLinks)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
            _bookLinks = bookLinks;
        }
        public async Task<BookDto> CreateOneBookAsync(BookDtoForInsertion bookDto)
        {
            //var category = await _categoryService
            //    .GetOneCategoryByIdAsync(bookDto.CategoryId, false);

            var entity = _mapper.Map<Book>(bookDto);
            _manager.Book.CreateOneBook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }
        public async Task DeleteOneBookAsync(int id, bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
            _manager.Book.DeleteOneBook(entity);
            await _manager.SaveAsync();
        }

        public async Task<(LinkResponse linkResponse, MetaData metaData)>
            GetAllBooksAsync(LinkParameters linkParameters,
            bool trackChanges)
        {
            if (!linkParameters.BookParameters.ValidPriceRange)
                throw new PriceOutofRangeBadRequestException();

            var booksWithMetaData = await _manager
                .Book
                .GetAllBooksAsync(linkParameters.BookParameters, trackChanges);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(booksWithMetaData);
            var links = _bookLinks.TryGenerateLinks(booksDto,
                linkParameters.BookParameters.Fields,
                linkParameters.HttpContext);

            return (linkResponse: links, metaData: booksWithMetaData.MetaData);
        }

        public async Task<List<Book>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            return books;
        }

        public async Task<IEnumerable<Book>> GetAllBooksWithDetailsAsync(bool trackChanges)
        {
            return await _manager
                .Book
                .GetAllBooksWithDetailsAsync(trackChanges);
        }

        public async Task<BookDto> GetOneBookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExists(id, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)>
            GetOneBookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetOneBookByIdAndCheckExists(id, trackChanges);
            var bookDtoForUpdate = _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDtoForUpdate, Book book)
        {
            _mapper.Map(bookDtoForUpdate, book);
            await _manager.SaveAsync();
        }

        public async Task UpdateOneBookAsync(int id,
            BookDtoForUpdate bookDto,
            bool trackChanges)
        {
            var entity = await GetOneBookByIdAndCheckExists(id, trackChanges);
            entity = _mapper.Map<Book>(bookDto);
            _manager.Book.Update(entity);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetOneBookByIdAndCheckExists(int id, bool trackChanges)
        {
            // check entity 
            var entity = await _manager.Book.GetOneBookByIdAsync(id, trackChanges);

            if (entity is null)
                throw new BookNotFoundException(id);

            return entity;
        }
    }
}
