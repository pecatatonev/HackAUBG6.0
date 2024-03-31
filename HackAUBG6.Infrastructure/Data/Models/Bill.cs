using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Infrastructure.Data.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateOfBill { get; set; }
        public ICollection<Order> Orders { get; set; }
        public string ApplicationUserId { get; set; } = string.Empty;
        public ApplicationUser ApplicationUser { get; set; }
    }
}
