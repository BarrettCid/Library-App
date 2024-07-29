using LibraryViewModels.DTO.Response;
using LibraryViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Interfaces
{
    public interface IReviewService
    {
        ICollection<LibraryReviewResponse> GetBookReviewsVM(int bookId);
        Task<ICollection<ReviewVM>> GetBookReviews(int bookId);
        Task<ReviewVM>  InsertReview(ReviewVM reviewVM);
        Task<bool> DeleteReview(int reviewId);
        Task<ICollection<ReviewVM>> PageReviewsByBook(int bookId, int reviewIndex);
    }
}
