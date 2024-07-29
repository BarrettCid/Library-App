using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.DTO.Request
{
    public class LibraryBookSearchRequest
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
    }
}
