using AutoMapper;
using LibraryModel.Model;
using LibraryViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMappers
{
    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
            this.CreateMap<Review, ReviewVM>();
            this.CreateMap<Review, ReviewVM>().ReverseMap();
        }
    }
}
