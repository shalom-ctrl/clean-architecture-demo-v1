using Demo.Domain.Models;
using System.Net.Http.Json;

namespace Demo.Infrastructure.Services
{
    public class CoinDeskHttpClientService(HttpClient httpClient) : ICoinDeskHttpClientService
    {
        public async Task<CoinDeskData> GetData()
        {
            var mockData = new CoinDeskData
            {
                ChartName = "Bitcoin",
                Disclaimer = "This is local mock data due to corporate environment restrictions.",
                Time = new Time
                {
                    Updated = "Jul 1, 2026 12:00:00 UTC",
                    UpdatedISO = System.DateTime.UtcNow,
                    Updateduk = "Jul 1, 2026 at 13:00 BST"
                },
                Bpi = new Bpi
                {
                    USD = new USD { Code = "USD", Rate = "65,432.10", RateFloat = 65432.1f, Symbol = "&#36;", Description = "United States Dollar" },
                    GBP = new GBP { Code = "GBP", Rate = "51,200.50", RateFloat = 51200.5f, Symbol = "&pound;", Description = "British Pound Sterling" },
                    EUR = new EUR { Code = "EUR", Rate = "60,110.25", RateFloat = 60110.25f, Symbol = "&euro;", Description = "Euro" }
                }
            };

            // 2. Return it instantly using Task.FromResult to satisfy the async signature
            return await Task.FromResult(mockData);
        }
    }
}
