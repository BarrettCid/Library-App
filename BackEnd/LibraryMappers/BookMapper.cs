using AutoMapper;
using LibraryModel.Model;
using LibraryViewModels.ViewModels;

namespace LibraryMappers
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            this.CreateMap<Book, BookVM>();
            this.CreateMap<Book, BookVM>().ReverseMap();

            this.CreateMap<UserCheckout, UserCheckoutVM>();
            this.CreateMap<UserCheckout, UserCheckoutVM>().ReverseMap();
        }
    }
}
