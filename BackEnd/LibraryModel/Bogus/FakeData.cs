using Bogus;
using LibraryModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Bogus
{
    public static class FakeData
    {
        public static int BookId = 1;
        public static List<Book> Books = new List<Book>();

        private static Faker? faker;
        public static void Init(int count)
        {
            faker = new Faker();

            GenerateBooks(count);

        }
        private static void GenerateBooks(int count)
        {
            for (var i = 0; i < count; i++, BookId++)
            {
                var Book = new Book
                {
                    BookId = BookId,
                    Title = faker?.Hacker.Phrase(),
                    Description = faker?.Lorem.Paragraph(),
                    Author = faker?.Hacker.Noun(),
                    CoverImage = faker?.PickRandom(new List<string>
                    {
                        "1.jpeg",
                        "2.jpeg",
                        "3.jpeg",
                        "4.jpeg",
                        "5.jpeg"
                    }),
                    Publisher = faker?.Hacker.Noun(),
                    Isbn = faker?.Random.ReplaceNumbers("###-####-###-####-#"),
                    PageCount = (int)faker?.Random.Number(),
                    TotalStock = (int)faker?.Random.Number(1,1),
                    CurrentStock = (int)faker?.Random.Number(1,1),
                    Locked = false,
                };

                Books.Add(Book);
            }
        }

    }
}
