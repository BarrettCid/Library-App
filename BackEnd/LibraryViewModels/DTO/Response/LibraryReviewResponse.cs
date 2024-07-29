using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.DTO.Response
{
    public class LibraryReviewResponse
    {
        public string? Reviewer {  get; set; }
        public string? ReviewText { get; set; }
        public int? Rating { get; set; }
    }
}
