using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.Models
{
    public class BillIdViewModel
    {
        public int BillId { get; set; }
        public ICollection<AllOrdersByUserIdViewModel> Orders { get; set; }
    }
}
