using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.DTO.Request
{
    public class LibraryCoverUploadRequest
    {
        public IFormFile? File { get; set; }
        public string? BookId { get; set; }
    }
}
