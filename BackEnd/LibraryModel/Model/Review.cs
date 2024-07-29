using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Model
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public int Rating { get; set; }
        public string? LibraryUserId { get; set; }
        public string? ReviewText { get; set; }
        public Book? Book { get; set; }
        public LibraryUser? LibraryUser { get; set; }

    }
}
