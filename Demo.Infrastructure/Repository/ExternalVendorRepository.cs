using Demo.Domain.Interface;
using Demo.Infrastructure.Services;
using Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Repository
{
    public class ExternalVendorRepository(ICoinDeskHttpClientService coinDeskHttpClientService, 
        IJokeHttpClientService jokeHttpClientService)
        : IExternalVendorRepository
    {
        public async Task<CoinDeskData> GetData()
        {
            return await coinDeskHttpClientService.GetData();
        }

        public async Task<JokeModel> GetJoke()
        {
            return await jokeHttpClientService.GetData();
        }
    }
}
