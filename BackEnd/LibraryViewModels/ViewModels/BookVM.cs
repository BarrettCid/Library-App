using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.ViewModels
{
    public class BookVM
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? CoverImage { get; set; }
        public string? Publisher { get; set; }
        public string? Isbn { get; set; }
        public int PageCount { get; set; }
        public bool Locked { get; set; }
        public int TotalStock { get; set; }
        public int CurrentStock { get; set; }
        public List<ReviewVM>? Reviews { get; set; }
    }
}
