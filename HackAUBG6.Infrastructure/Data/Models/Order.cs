using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Infrastructure.Data.Models
{
    public class Order
    {
        [Key]
        [Comment("Order Identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("ProductName")]
        [MaxLength(100)]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        [Comment("ProductPrice")]
        [Range(0, 5000)]
        public decimal ProductPrice { get; set; }
        [Required]
        [Comment("ProductQuantity")]
        public int Quantity { get; set; }
    }
}
