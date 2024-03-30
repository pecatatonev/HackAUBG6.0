using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.DTOs;
using HackAUBG6.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.Services
{
    public class GetDataService : IGetDataService
    {
        private readonly ApplicationDbContext context;
        public GetDataService(ApplicationDbContext _context)
        {
            context= _context;
        }
        public Task<IEnumerable<GetDataOrders>> AllEventsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
