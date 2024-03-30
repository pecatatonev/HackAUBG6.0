﻿using HackAUBG6.Core.DTOs;

namespace HackAUBG6.Core.Contracts
{
    public interface IGetDataService
    {
        Task<IEnumerable<GetDataBillDTO>> AllBillAsync(string data);
    }
}
