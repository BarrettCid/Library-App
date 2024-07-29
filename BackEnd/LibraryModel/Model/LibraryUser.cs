using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Model
{
    public class LibraryUser :  IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
