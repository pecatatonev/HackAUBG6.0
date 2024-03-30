using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.DTOs
{
    public class GetDataOrdersDTO
    {
        public string ProductName { get; set; } = string.Empty;
        public string ProductPrice { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
