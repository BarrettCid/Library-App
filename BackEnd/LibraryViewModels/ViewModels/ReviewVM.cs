using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.ViewModels
{
    public class ReviewVM
    {
        public int ReviewId { get; set; }
        public int BookId { get; set; }
        public string? ReviewText { get; set; }
        public string? LibraryUserId { get; set; }
        public int Rating { get; set; }
        public virtual BookVM? Book { get; set; }
        public virtual LibraryUserVM? LibraryUser { get; set; }
    }
}
