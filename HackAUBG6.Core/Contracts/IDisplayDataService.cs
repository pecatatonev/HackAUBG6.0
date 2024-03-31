using HackAUBG6.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.Contracts
{
    public interface IDisplayDataService
    {
        Task<ICollection<BillIdViewModel>> GetAllOrdersByBillId(string id);
    }
}
