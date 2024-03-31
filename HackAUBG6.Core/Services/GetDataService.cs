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

        public async Task<bool> SaveBillAsync(GetDataBillDTO dataDTO)
        {
            DateTime start = DateTime.Now;
            

            if (!DateTime.TryParseExact(dataDTO.DateTime,
            DataConstants.DateConstants,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out start))
            {
                return false;
            }

            Bill billToAdd = new Bill()
            {
                DateOfBill = start,
                ApplicationUserId = dataDTO.ApplicationUserId,
                Orders = new List<Order>()
            };

            var orders = dataDTO.Orders.ToList();
            Order OrderToAdd;
            for (int i = 0; i < orders.Count(); i++)
            {
                OrderToAdd = new Order()
                {
                    ProductName = orders[i].ProductName,
                    Quantity = orders[i].Quantity,
                    ProductPrice = decimal.Parse(orders[i].ProductPrice)
                };

                billToAdd.Orders.Add(OrderToAdd);
                context.Orders.Add(OrderToAdd);
            }
           
            await context.Bills.AddAsync(billToAdd);

            await context.SaveChangesAsync();
            

            return true;
        }
    }
}
