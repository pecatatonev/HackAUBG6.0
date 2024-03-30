using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.DTOs
{
    public class GetDataBillDTO
    {
        public string DateTime { get; set; } = string.Empty;
        public string ApplicationUserId { get; set; } = string.Empty;
        public ICollection<GetDataOrdersDTO> Orders { get; set; } = new List<GetDataOrdersDTO>();
    }
}
