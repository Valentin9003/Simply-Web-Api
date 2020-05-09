using Api.Data;
using Api.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace Api.Infrastructure
{
    public static class SeedDatabase
    {
        public static IApplicationBuilder InitializeDatabase(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();
                  var context = services.ServiceProvider.GetService<ApiDbContext>();

            if (!context.Author.Any())
            {
              context.Author.AddRange(
                new Author
                {
                    Name = "Anna",
                    BirthYear = "1960",
                    Books = new List<Book>
                    {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1980",
                            Title = "Author1-Title1"
                        },
                        new Book
                        {
                            Genre = "Crime",
                            PublicationYear = "1981",
                            Title = "Author1-Title2"
                        },
                         new Book
                         {
                            Genre = "Drama",
                            PublicationYear = "1980",
                            Title = "Author1-Title3"
                         }
                    }
                },
                new Author
                {
                    Name = "Pesho",
                    BirthYear = "1961",
                    Books = new List<Book>
                    {
                        new Book
                        {
                           Genre = "Drama",
                           PublicationYear = "1980",
                           Title = "Author2-Title1"
                        },
                        new Book
                        {
                           Genre = "Crime",
                           PublicationYear = "1984",
                           Title = "Author2-Title2"
                        },
                        new Book
                        {
                           Genre = "Drama",
                           PublicationYear = "1984",
                           Title = "Author2-Title3"
                        }
                    },

                },
                 new Author
                 {
                     Name = "Yoana",
                     BirthYear = "1961",
                     Books = new List<Book>
                     {
                         new Book
                         {
                            Genre = "Drama",
                            PublicationYear = "1981",
                            Title = "Author3-Title1"
                         },
                         new Book
                         {
                            Genre = "Crime",
                            PublicationYear = "1983",
                            Title = "Author3-Title2"
                         },
                         new Book
                         {
                            Genre = "Drama",
                            PublicationYear = "1984",
                            Title = "Author3-Title3"
                         }
                     },

                 },
                 new Author
                 {
                     Name = "Maria",
                     BirthYear = "1940",
                     Books = new List<Book>
                     {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1951",
                            Title = "Author4-Title1"
                        },
                        new Book
                        {
                            Genre = "Crime",
                            PublicationYear = "1987",
                            Title = "Author4-Title2"
                        },
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1990",
                            Title = "Author4-Title3"
                        }
                     },

                 },
                 new Author
                 {
                     Name = "Anna-Maria",
                     BirthYear = "1990",
                     Books = new List<Book>
                     {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "2020",
                            Title = "Author5-Title1"
                        },
                         new Book
                         {
                            Genre = "Crime",
                            PublicationYear = "2021",
                            Title = "Author5-Title2"
                         },
                          new Book
                          {
                            Genre = "Drama",
                            PublicationYear = "2020",
                            Title = "Author5-Title3"
                          }
                    },

                 },
                 new Author
                 {
                     Name = "Ivan",
                     BirthYear = "1961",
                     Books = new List<Book>
                     {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1981",
                            Title = "Author6-Title1"
                        },
                        new Book
                        {
                            Genre = "Crime",
                            PublicationYear = "1983",
                            Title = "Author6-Title2"
                        },
                        new Book
                         {
                            Genre = "Drama",
                            PublicationYear = "1984",
                            Title = "Author6-Title3"
                        }
                    },

                 },
                 new Author
                 {
                     Name = "Hristo",
                     BirthYear = "1930",
                     Books = new List<Book>
                     {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1940",
                            Title = "Author7-Title1"
                        },
                        new Book
                        {
                           Genre = "Crime",
                           PublicationYear = "1950",
                           Title = "Author7-Title2"
                        },
                        new Book
                        {
                          Genre = "Drama",
                          PublicationYear = "1950",
                          Title = "Author7-Title3"
                        }
                     },

                 },
                 new Author
                 {
                     Name = "Ivan",
                     BirthYear = "1950",
                     Books = new List<Book>
                     {
                      new Book
                      {
                          Genre = "Drama",
                          PublicationYear = "1981",
                          Title = "Author8-Title1"
                      },
                       new Book
                       {
                          Genre = "Crime",
                          PublicationYear = "1983",
                          Title = "Author8-Title2"
                       },
                        new Book
                        {
                          Genre = "Drama",
                          PublicationYear = "1984",
                          Title = "Author8-Title3"
                        }
                     },

                 },
                 new Author
                 {
                     Name = "Maq",
                     BirthYear = "2000",
                     Books = new List<Book>
                     {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "2020",
                            Title = "Author9-Title1"
                        },
                        new Book
                        {
                            Genre = "Crime",
                            PublicationYear = "2021",
                            Title = "Author9-Title2"
                        },
                        new Book
                        {
                          Genre = "Drama",
                          PublicationYear = "2021",
                          Title = "Author9-Title3"
                        }
                     },

                 },
                 new Author
                 {
                     Name = "Iva",
                     BirthYear = "1943",
                     Books = new List<Book>
                    {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1981",
                            Title = "Author10-Title1"
                        },
                         new Book
                         {
                            Genre = "Crime",
                            PublicationYear = "1983",
                            Title = "Author10-Title2"
                         },
                         new Book
                         {
                            Genre = "Drama",
                            PublicationYear = "1984",
                            Title = "Author10-Title3"
                         }
                    },

                 },
                 new Author
                 {
                     Name = "Vanq",
                     BirthYear = "1961",
                     Books = new List<Book>
                    {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1981",
                            Title = "Author11-Title1"
                        },
                         new Book
                         {
                            Genre = "Crime",
                            PublicationYear = "1983",
                            Title = "Author11-Title2"
                         },
                          new Book
                          {
                            Genre = "Drama",
                            PublicationYear = "1984",
                            Title = "Author11-Title3"
                          }
                    },

                 },
                 new Author
                 {
                     Name = "Maria-Magdalena",
                     BirthYear = "1961",
                     Books = new List<Book>
                     {
                        new Book
                        {
                            Genre = "Drama",
                            PublicationYear = "1981",
                            Title = "Author12-Title1"
                        },
                        new Book
                        {
                            Genre = "Crime",
                            PublicationYear = "1983",
                            Title = "Author12-Title2"
                        },
                        new Book
                        {
                          Genre = "Drama",
                          PublicationYear = "1984",
                          Title = "Author12-Title3"
                        }
                    },

                 });
               context.SaveChanges();
            }
               return app;
        }
    }
}
