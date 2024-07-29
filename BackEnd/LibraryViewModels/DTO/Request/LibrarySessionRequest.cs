using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryViewModels.DTO.Request
{
    public class LibrarySessionRequest
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
