using Api.Data;
using Api.Data.Models;
using Api.Infrastructure;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Api.Services
{
    public class ApiService : IApiService
    {
        private readonly ApiDbContext context;
        private readonly IMemoryCache memoryCache;

        public ApiService(ApiDbContext context, IMemoryCache mamoryCache)
        {
            this.context = context;
            this.memoryCache = mamoryCache;
        }

        public async Task<bool> CreateAuthorAsync(AuthorModel author)
        {
            var books = author.Books.Select(b => new Book
            {
                Genre = b.Genre,
                PublicationYear = b.PublicationYear,
                Title = b.Title
            }).ToList();

            var result =  context.Author.Add(new Author
            {
                BirthYear = author.BirthYear,
                Name = author.Name,
                Books = books
            });

          var isCreated = await context.SaveChangesAsync();

          return isCreated > 0 ? true : false;
        }

        public async Task<bool> DeleteAuthorAsync(string id)
        {
            var author =  await context
                .Author
                .Where(a => a.AuthorId == id)
                .FirstOrDefaultAsync();

            if (author == null)
            {
                return false;
            }

            context.Author.Remove(author);

         var result = await context.SaveChangesAsync();

            return result > 0 ? true : false;
        }

        public async Task<AuthorModel> GetAuthorAsync(string id)
        {
            AuthorModel author;
           
            bool isCached =  memoryCache.TryGetValue(id, out author);

            if (!isCached)
            {
                author = await context.Author
                           .AsNoTracking()
                           .Where(i => i.AuthorId == id)
                           .Select(a => new AuthorModel
                           {
                               AuthorId = a.AuthorId,
                               BirthYear = a.BirthYear,
                               Name = a.Name,
                               Books = a.Books
                                     .Select(b => new BookModel
                                     {
                                         BookId = b.BookId,
                                         Genre = b.Genre,
                                         PublicationYear = b.PublicationYear,
                                         Title = b.Title
                                     }).ToList()
                           }).FirstOrDefaultAsync();
                var issd = context.Author.FirstOrDefault(s => s.Name == "Pesho").AuthorId;
                if (author != null)
                {
                    this.memoryCache.Set(id, author, TimeSpan.FromSeconds(600));
                }

            }
            
             return author;
        }

        public async Task<bool> UpdateAuthorAsync(AuthorModel author)
        {
            var entity = new Author
            {
                AuthorId = author.AuthorId,
                BirthYear = author.BirthYear,
                Name = author.Name,

                Books = author.Books.Select(b => new Book
                {
                    BookId = b.BookId,
                    Genre = b.Genre,
                    PublicationYear = b.PublicationYear,
                    Title = b.Title
                }).ToList()

            };

            this.memoryCache.Remove(author.AuthorId);
            this.memoryCache.Set(author.AuthorId, author, TimeSpan.FromSeconds(600));

            context.Author.Update(entity);

            var isSuccessed = await context.SaveChangesAsync();

            return isSuccessed > 0 ? true : false;
        }

        public async Task<List<AuthorModel>> GetAuthorListAsync(AuthorsListModel rules)
        {
            var filterBy = rules.FilterBy;
            var filterComparisonOperator = rules.FilterComparisonOperator;
            var filterValue = rules.FilterValue;
            var paging = rules.Paging == 0 ? 10 : rules.Paging;
            var orderBy = rules.OrderBy;
            var desc = rules.Desc;

            var uniqueCacheKey = $"{filterBy}{filterComparisonOperator}{filterValue}{paging}{orderBy}{desc}";

            var authors = new List<AuthorModel>();

            var isCached = this.memoryCache.TryGetValue(uniqueCacheKey, out authors);

            if (isCached)
            {
                 authors = await context.Author
                    .AsNoTracking()
                    .Where(filterBy, filterComparisonOperator, filterValue)
                    .OrderBy(orderBy, desc)
                    .Take(paging).Select(a => new AuthorModel
                    {
                        AuthorId = a.AuthorId,
                        BirthYear = a.BirthYear,
                        Name = a.Name,
                        Books = a.Books.Select(b => new BookModel
                        {
                            BookId = b.BookId,
                            Genre = b.BookId,
                            PublicationYear = b.PublicationYear,
                            Title = b.Title
                        }).ToList()
                    }).ToListAsync();

                if (authors.Count > 0)
                {
                    this.memoryCache.Set(uniqueCacheKey, authors, TimeSpan.FromSeconds(600));
                }
            }
            return authors;
        }


        public bool CheckPropertyExist(string propertyName)
        {
             var property = typeof(Author).GetProperty(propertyName);

             return  property == null;

        }
    }
}