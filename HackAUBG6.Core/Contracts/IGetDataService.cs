using HackAUBG6.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.Contracts
{
    public interface IGetDataService
    {
        Task<IEnumerable<GetDataOrders>> AllEventsAsync();
    }
}
