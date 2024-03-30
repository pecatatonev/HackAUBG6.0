using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.DTOs;
using HackAUBG6.Infrastructure.Data;
using HackAUBG6.Infrastructure.Data.Models;
using System.Diagnostics.Contracts;
using System.Globalization;
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

        public GetDataBillDTO AllBill(string data)
        {
            GetDataBillDTO getDataBillDTOs = data.DeserializeFromJson<GetDataBillDTO>();

            return getDataBillDTOs;
        }

        public void SaveBill(GetDataBillDTO dataDTO)
        {
            DateTime start = DateTime.Now;

            if (!DateTime.TryParseExact(dataDTO.DateTime,
            "dd/MM/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out start))
            {
                return -1;
            }

            Bill billToAdd = new Bill()
            {
            DateOfBill = dataDTO.DateTime.,
            };
        }
    }
}
