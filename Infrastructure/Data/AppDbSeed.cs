using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public class AppDbSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.Books.Any()) return;
            if (context.Readers.Any()) return;

            var books = new List<Book>
                {
                    new Book
                    {
                        Name = "Book 1",
                        Author = "Author 1",
                        Article = "Article 1",
                        PublishingYear = 1996,
                        Count = 20
                    },
                    new Book
                    {
                        Name = "Book 2",
                        Author = "Author 1",
                        Article = "Article 2",
                        PublishingYear = 2000,
                        Count = 35
                    },
                    new Book
                    {
                        Name = "Book 3",
                        Author = "Author 2",
                        Article = "Article 3",
                        PublishingYear = 1998,
                        Count = 60
                    }
                };

            var readers = new List<Reader>
            {
                new Reader
                {
                    FirstName = "Alex",
                    LastName = "Weis",
                    MiddleName = "Middlename1",
                    DateOfBirth = new DateTime(1996, 06, 11)
                },
                new Reader
                {
                    FirstName = "Leha",
                    LastName = "Navalny",
                    MiddleName = "Sisyan",
                    DateOfBirth = new DateTime(1975, 06, 11)
                },
                new Reader
                {
                    FirstName = "Ozon",
                    LastName = "Games",
                    MiddleName = "shestsemodin",
                    DateOfBirth = new DateTime(1985, 06, 11)
                }
            };

            await context.Books.AddRangeAsync(books);
            await context.Readers.AddRangeAsync(readers);
            await context.SaveChangesAsync();
        }
    }
}