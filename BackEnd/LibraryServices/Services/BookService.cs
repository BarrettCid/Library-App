using LibraryModel.Context;
using LibraryServices.Interfaces;
using LibraryViewModels.ViewModels;
using LibraryModel.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using AutoMapper;
using LibraryUtilities;
using LibraryViewModels.DTO.Request;
using System.Net;

namespace LibraryServices.Services
{
    public class BookService : IBookService
    {
        private IMapper _mapper;
        private LibraryDbContext _libraryDbContext;

        public BookService(LibraryDbContext libraryDbContext, IMapper mapper) 
        { 
            this._libraryDbContext = libraryDbContext;
            this._mapper = mapper;
        }

        public async Task<ICollection<BookVM>> BookSearch(LibraryBookSearchRequest request)
        {
            var filters = new Dictionary<string, object> ();
            if (!String.IsNullOrEmpty(request.Title))
            {
                if (filters.ContainsKey("Title"))
                {
                    filters["Title"] = request.Title;
                }
                else
                {
                    filters.Add("Title", request.Title);
                }
            }
            if (!String.IsNullOrEmpty(request.Author))
            {
                if (filters.ContainsKey("Author"))
                {
                    filters["Author"] = request.Author;
                }
                else
                {
                    filters.Add("Author", request.Author);
                }
            }
            if (!String.IsNullOrEmpty(request.Publisher))
            {
                if (filters.ContainsKey("Publisher"))
                {
                    filters["Publisher"] = request.Publisher;
                }
                else
                {
                    filters.Add("Publisher", request.Publisher);
                }
            }
            var expression = Expressions.CreateContainsExpression(filters);
            var result = await this._libraryDbContext.Books.Where(expression).ToListAsync();
            return this._mapper.Map<ICollection<BookVM>>(result);
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            try
            {
                Book? entity = await this._libraryDbContext.Books.Where(b => b.BookId == bookId).FirstOrDefaultAsync();
                if (entity == null)
                {
                    throw new Exception("Unable to find entity you requested to delete. Please try again later.");
                }
                this._libraryDbContext.Books.Remove(entity);
                await this._libraryDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BookVM> GetBook(int id)
        {
            Book? book = await this._libraryDbContext.Books.Where(b => b.BookId == id).FirstOrDefaultAsync();
            return this._mapper.Map<BookVM>(book);
        }

        public async Task<ICollection<BookVM>> GetBooks()
        {
            ICollection<Book> books = await this._libraryDbContext.Books.ToListAsync();
            return this._mapper.Map<ICollection<BookVM>>(books);
        }

        public async Task<BookVM> InsertBook(BookVM bookVM)
        {
            try
            {
                Book book = _mapper.Map<Book>(bookVM);
                this._libraryDbContext.Add(book);
                await this._libraryDbContext.SaveChangesAsync();
                return this._mapper.Map<BookVM>(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<BookVM> UpdateBook(BookVM bookVM)
        {
            try
            {
                Book book = _mapper.Map<Book>(bookVM);
                this._libraryDbContext.Update(book);
                await this._libraryDbContext.SaveChangesAsync();
                return this._mapper.Map<BookVM>(book);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<BookVM>> GetRandomSampling(int count)
        {
            var books = await this._libraryDbContext.Books.OrderBy(x => Guid.NewGuid()).Take(count).ToListAsync();
            return this._mapper.Map<ICollection<BookVM>>(books);
        }

        public async Task<bool> LockBook(int bookId)
        {
            if (this._libraryDbContext.Books.Any(b => b.BookId == bookId && b.Locked == true)) 
            {
                throw new Exception("The book is already locked. Please try again later.");
            }
            var bookEntity = await this._libraryDbContext.Books.Where(b => b.BookId == bookId).FirstOrDefaultAsync();
            bookEntity.Locked = true;
            this._libraryDbContext.Books.Update(bookEntity);
            await this._libraryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UnlockBook(int bookId)
        {
            if (this._libraryDbContext.Books.Any(b => b.BookId == bookId && b.Locked == false))
            {
                throw new Exception("The book is already unlocked.");
            }
            var bookEntity = await this._libraryDbContext.Books.Where(b => b.BookId == bookId).FirstOrDefaultAsync();
            bookEntity.Locked = false;
            this._libraryDbContext.Books.Update(bookEntity);
            await this._libraryDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<string> PhotoExists(string filename,int bookId)
        {
            if(this._libraryDbContext.Books.Any(x => x.CoverImage.Equals(filename)))
            {
                var ext = Path.GetExtension(filename);
                var newname = Guid.NewGuid().ToString() + ext;
                var book = await this._libraryDbContext.Books.Where(x => x.BookId == bookId).FirstOrDefaultAsync();
                book.CoverImage = newname;
                await this._libraryDbContext.SaveChangesAsync();
                return newname;
            } else
            {
                return filename;
            }
        }

        public async Task<BookVM> Checkout(int bookId, string libraryUserId)
        {
            var book = await this._libraryDbContext.Books.Where(x => x.BookId == bookId).FirstOrDefaultAsync();
            if(book.CurrentStock > 0)
            {
                //remove stock to prevent error in system with other uses trying to checkout the book.
                book.CurrentStock--;
                this._libraryDbContext.Books.Update(book);
                await this._libraryDbContext.SaveChangesAsync();
                var userCheckout = new UserCheckout();
                userCheckout.LibraryUserId = libraryUserId;
                userCheckout.BookId = bookId;
                userCheckout.DateCheckedOut = DateTime.Now;
                await this._libraryDbContext.UserCheckouts.AddAsync(userCheckout);
                await this._libraryDbContext.SaveChangesAsync();
                return this._mapper.Map<BookVM>(book);
            } 
            else
            {
                throw new Exception("There are no more copies of this book availabe. Please check back later.");
            }
        }
    }
}
