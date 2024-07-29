using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.ViewModels
{
    public class UserCheckoutVM
    {
        public int UserCheckoutId { get; set; }
        public int BookId { get; set; }
        public int LibraryUserId { get; set; }
        public DateTime DateCheckedOut { get; set; }
        public BookVM? Book { get; set; }
        public LibraryUserVM? LibraryUser { get; set; }
    }
}
