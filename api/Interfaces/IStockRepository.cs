using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.api.Models;
using WebApplication1.api.Dtos.Stock;
using WebApplication1.api.Helpers;

namespace WebApplication1.api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);  //Interfaces allow us to plug this code elsewhere & abstract our code away
        Task<Stock?> GetByIdAsync(int id);  //? beacuse we have a firstordefault() which can be null
        Task<Stock?> GetBySymbolAsync(string symbol);
        Task<Stock> CreateAsync(Stock stockModel);

        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);

        Task<Stock?> DeleteAsync(int id);
        Task<bool> StockExists(int id);

    }
}
