using Demo.Domain.Models;

namespace Demo.Infrastructure.Services
{
    public interface ICoinDeskHttpClientService
    {
        Task<CoinDeskData> GetData();
    }
}