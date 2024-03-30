using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.DTOs;
using HackAUBG6.Infrastructure.Data;

namespace HackAUBG6.Core.Services
{
    public class GetDataService : IGetDataService
    {
        private readonly ApplicationDbContext context;
        public GetDataService(ApplicationDbContext _context)
        {
            context= _context;
        }

        public async Task<IEnumerable<GetDataBill>> AllBillAsync()
        {
            throw new NotImplementedException();
        }
    }
}
