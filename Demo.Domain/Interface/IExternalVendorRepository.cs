using Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Domain.Interface
{
    public interface IExternalVendorRepository
    {
        Task<CoinDeskData> GetData();
        Task<JokeModel> GetJoke();
    }
}
