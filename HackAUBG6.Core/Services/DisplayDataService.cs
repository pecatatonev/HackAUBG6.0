using HackAUBG6.Core.Contracts;
using HackAUBG6.Core.Models;
using HackAUBG6.Infrastructure.Data;
using HackAUBG6.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackAUBG6.Core.Services
{
    public class DisplayDataService : IDisplayDataService
    {
        private readonly ApplicationDbContext context;
        public DisplayDataService(ApplicationDbContext _context)
        {
            context = _context;
        }
        public async Task<ICollection<BillIdViewModel>> GetAllBillsAndOrdersByUserId(string id)
        {
            var listOfBills =  await context.Bills
            .Where(b => b.ApplicationUserId == id)
            .Include(b => b.Orders)
            .ToListAsync();

            var model = listOfBills.Select(b => new BillIdViewModel
            {
                BillId = b.Id,
                Orders = b.Orders.Select(o => new AllOrdersByUserIdViewModel()
                {
                    ProductName = o.ProductName,
                    Quantity = o.Quantity,
                    ProductPrice = o.ProductPrice,
                })
                .ToList()
            }).ToList();

            return model;
        }
    }
}
