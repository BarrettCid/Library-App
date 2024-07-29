using LibraryModel.Model;
using LibraryServices.Interfaces;
using LibraryUtilities;
using LibraryViewModels.DTO.Request;
using LibraryViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = $"{RoleEnum.Librarian}, {RoleEnum.Public}")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<BookVM>>> GetBooks()
        {
            return Json(await this._bookService.GetBooks());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<BookVM>> GetBook(int id)
        {
            return Json(await this._bookService.GetBook(id));
        }

        [HttpPost]
        [Authorize(Roles = RoleEnum.Librarian)]
        public async Task<ActionResult<BookVM>> AddBook(BookVM book)
        {
            try
            {
                var result = await this._bookService.InsertBook(book);
                return Json(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = RoleEnum.Librarian)]
        public async Task<ActionResult<BookVM>> UpdateBook(BookVM book)
        {
            try
            {
                return Json(await this._bookService.UpdateBook(book));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = RoleEnum.Librarian)]
        [Route("{bookId}")]
        public async Task<ActionResult<bool>> DeleteBook(int bookId)
        {
            try
            {
                return Json(await this._bookService.DeleteBook(bookId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("uploadcover")]
        public async Task<ActionResult> UploadCover([FromForm] LibraryCoverUploadRequest request)
        {
            try
            {
                var directory = Directory.GetCurrentDirectory();
                var filename = await this._bookService.PhotoExists(request.File.FileName, int.Parse(request.BookId));
                var file = request.File;
                using (var stream = System.IO.File.OpenWrite($"{directory}/Assets/CoverImages/{filename}"))
                {
                    await file.CopyToAsync(stream);
                }
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("getRandomSampling/{count}")]
        public async Task<ActionResult> GetRandomSampling(int count)
        {
            return Json(await this._bookService.GetRandomSampling(count));
        }

        [HttpPost]
        [Route("checkout/{bookId}/{libraryUserId}")]
        public async Task<ActionResult> CheckoutBook(int bookId, string libraryUserId)
        {
            try
            {
                return Json(await this._bookService.Checkout(bookId, libraryUserId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("search")]
        public async Task<ActionResult<ICollection<BookVM>>> BookSearch(LibraryBookSearchRequest request)
        {
            try
            {
                var result = await this._bookService.BookSearch(request);
                return Json(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = RoleEnum.Librarian)]
        [HttpGet]
        [Route("lock/{bookId}")]
        public async Task<ActionResult> LockBook(int bookId)
        {
            try
            {
                return Json(await this._bookService.LockBook(bookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize(Roles = RoleEnum.Librarian)]
        [HttpGet]
        [Route("unlock/{bookId}")]
        public async Task<ActionResult> UnlockBook(int bookId)
        {
            try
            {
                return Json(await this._bookService.UnlockBook(bookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
