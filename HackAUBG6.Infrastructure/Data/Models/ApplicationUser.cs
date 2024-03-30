using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Infrastructure.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    }
}
