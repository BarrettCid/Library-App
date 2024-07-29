using AutoMapper;
using LibraryModel.Context;
using LibraryModel.Model;
using LibraryServices.Interfaces;
using LibraryViewModels.DTO.Response;
using LibraryViewModels.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryServices.Services
{
    public class ReviewService : IReviewService
    {
        private LibraryDbContext _libraryDbContext;
        private IMapper _mapper;

        public ReviewService(LibraryDbContext libraryDbContext, IMapper mapper) 
        {
            this._libraryDbContext = libraryDbContext;
            this._mapper = mapper;
        }

        public async Task<bool> DeleteReview(int reviewId)
        {
            try
            {
                var review = await this._libraryDbContext.Reviews.Where(x => x.ReviewId == reviewId).FirstOrDefaultAsync();
                if (review == null)
                {
                    throw new Exception("Unable to delete the reivew you requested. Please try again later.");
                }
                this._libraryDbContext.Reviews.Remove(review);
                await this._libraryDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<LibraryReviewResponse> GetBookReviewsVM(int bookId)
        {
            var reviews = this._libraryDbContext.Reviews.Include(r => r.LibraryUser).Where(r => r.BookId == bookId)
                .Select(r => new LibraryReviewResponse()
                {
                    Reviewer = r.LibraryUser.Email,
                    ReviewText = r.ReviewText,
                    Rating = r.Rating,
                }).ToList();
            return reviews;
        }


        public async Task<ICollection<ReviewVM>> GetBookReviews(int bookId)
        {
            var reviews = await this._libraryDbContext.Reviews.Where(r => r.BookId == bookId).ToListAsync();
            return this._mapper.Map<ICollection<ReviewVM>>(reviews);
        }

        public async Task<ReviewVM> InsertReview(ReviewVM reviewVM)
        {
            try
            {
                if (this._libraryDbContext.Reviews.Any(r => r.BookId == reviewVM.BookId && r.LibraryUserId == reviewVM.LibraryUserId))
                {
                    throw new Exception("You can't review a book twice. Thanks for your previous review.");
                }
                var review = this._mapper.Map<Review>(reviewVM);
                await this._libraryDbContext.Reviews.AddAsync(review);
                await this._libraryDbContext.SaveChangesAsync();
                return this._mapper.Map<ReviewVM>(review);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ICollection<ReviewVM>> PageReviewsByBook(int bookId, int reviewIndex)
        {
           return this._mapper.Map<ICollection<ReviewVM>>(await this._libraryDbContext.Reviews.Where(r => r.BookId == bookId).Skip(reviewIndex).Take(5).ToListAsync());
        }
    }
}
