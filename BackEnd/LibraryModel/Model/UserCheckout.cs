using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Model
{
    public class UserCheckout
    {
        public int UserCheckoutId {  get; set; }
        public int BookId { get; set; }
        public string? LibraryUserId { get; set; }
        public DateTime DateCheckedOut { get; set; }
        public Book? Book { get; set; }
        public LibraryUser? LibraryUser { get; set; }

    }
}
