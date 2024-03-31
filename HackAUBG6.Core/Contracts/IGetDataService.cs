using HackAUBG6.Core.DTOs;

namespace HackAUBG6.Core.Contracts
{
    public interface IGetDataService
    {
        GetDataBillDTO AllBill(string data);
        Task<bool> SaveBillAsync(GetDataBillDTO dataDTO);
    }
} 