using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.DTOs;
using HackAUBG6.Infrastructure.Data;
using System.Net;

namespace HackAUBG6.Core.Services
{
    public class GetDataService : IGetDataService
    {
        private readonly ApplicationDbContext context;
        public GetDataService(ApplicationDbContext _context)
        {
            context= _context;
        }

        public async Task<IEnumerable<GetDataBillDTO>> AllBillAsync(string data)
        {
            List<GetDataBillDTO> getDataBillDTOs = data.DeserializeFromJson<List<GetDataBillDTO>>();

            return getDataBillDTOs;
        }
    }
}
