using LibraryServices.Interfaces;
using LibraryUtilities;
using LibraryViewModels.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Authorize(Roles = $"{RoleEnum.Librarian}, {RoleEnum.Public}")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private IReviewService _reviewService;
        public ReviewController(IReviewService reviewService) 
        {
            this._reviewService = reviewService;
        }

        [HttpPost]
        public async Task<ActionResult> AddReview(ReviewVM review)
        {
            try
            {
                var result = await this._reviewService.InsertReview(review);
                return Json(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [Authorize(Roles = RoleEnum.Librarian)]
        [HttpDelete]
        public ActionResult DeleteReview(int reviewId)
        {
            try
            {
                return Json(this._reviewService.DeleteReview(reviewId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("reviewsbybookvm/{bookId}")]
        public ActionResult GetBookReviewsVM(int bookId)
        {
            return Json(this._reviewService.GetBookReviewsVM(bookId));
        }

        [HttpGet]
        [Route("reviewsbybook/{bookId}")]
        public ActionResult GetBookReviews(int bookId)
        {
            return Json(this._reviewService.GetBookReviews(bookId));
        }

        [HttpGet]
        [Route("pagereviewsbybook/{bookId}/{reviewIndex}")]
        public ActionResult PageReviewsByBook(int bookId, int reviewIndex)
        {
            return Json(this._reviewService.PageReviewsByBook(bookId, reviewIndex));
        }
    }
}
