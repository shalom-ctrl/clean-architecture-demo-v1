using Demo.Domain.Interface;
using Demo.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Queries
{
    public record GetJokeQuery() : IRequest<JokeModel>;
    public class GetJokeQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetJokeQuery, JokeModel>
    {
        public async Task<JokeModel> Handle(GetJokeQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetJoke();
        }
    }
}
