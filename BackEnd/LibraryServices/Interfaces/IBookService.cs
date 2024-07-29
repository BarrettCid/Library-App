using LibraryViewModels.DTO.Request;
using LibraryViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface IBookService
    { 
        Task<BookVM> GetBook(int id);
        Task<ICollection<BookVM>> GetBooks();
        Task<ICollection<BookVM>> BookSearch(LibraryBookSearchRequest request);
        Task<BookVM> InsertBook(BookVM bookVM);
        Task<BookVM> UpdateBook(BookVM bookVM);
        Task<bool> DeleteBook(int bookId);
        Task<ICollection<BookVM>> GetRandomSampling(int count);
        Task<bool> LockBook(int bookId);
        Task<bool> UnlockBook(int bookId);
        Task<string> PhotoExists(string filename, int bookId);
        Task<BookVM> Checkout(int bookId, string LibraryUserId);
    }
}
