using Demo.Application.Commands;
using Demo.Application.Queries;
using Demo.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clean_architecture_demo_v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalVendorController(ISender sender) : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetCoinDeskData()
        {
            var result = await sender.Send(new GetCoinDeskDataQuery());
            return Ok(result);
        }

        [HttpGet("joke")]
        public async Task<IActionResult> GetJoke()
        {
            var result = await sender.Send(new GetJokeQuery());
            return Ok(result);
        }
    }
}
