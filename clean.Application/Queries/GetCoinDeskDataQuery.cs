using Demo.Domain.Interface;
using MediatR;
using Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Queries
{
    public record GetCoinDeskDataQuery() : IRequest<CoinDeskData>;
    public class GetCoinkDeskDataQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetCoinDeskDataQuery, CoinDeskData>
    {
        public async Task<CoinDeskData> Handle(GetCoinDeskDataQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetData();
        }
    }
}
